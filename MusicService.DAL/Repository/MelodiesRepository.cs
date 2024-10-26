using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MusicService.Core.Interfaces;
using MusicService.Core.Models;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.GenreDTOs;
using MusicService.Core.Models.DTOs.MelodyDTOs;
using MusicService.DAL.Data;
using MusicService.Infrastructure.FileOperations;

namespace MusicService.DAL.Repository
{
    public class MelodiesRepository( ApplicationDbContext _context,
                                     IMapper _mapper,
                                     IWebHostEnvironment _environment) : IMelody
    {
        private ResponseDTO Response { get; set; } = new();

        public async Task<ResponseDTO> CreateMelodyAsync(CreateMelodyDTO melody)
        {
            if (melody == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Transit object is Empty";

                return Response;
            }

            var newMelody = _mapper.Map<Melody>(melody);
            if (newMelody == null)
            {
                Response.IsSuccess = false;
                Response.Message = "New melody object is Empty";

                return Response;
            }

            var author = await _context.Authors.FindAsync(melody.AuthorId);
            if (author == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Author is missing";

                return Response;
            }

            if (melody.ImageFile != null)
            {
                (string, string) nameAndPath = await FileOperations.SaveFileAsync(melody.ImageFile,
                                               _environment.ContentRootPath,
                                               "Files/Melodies/Pictures");

                newMelody.ImageFileName = nameAndPath.Item1;
                newMelody.ImageLocalPath = nameAndPath.Item2;
            }
            else
            {
                    newMelody.ImageFileName = author.ImageFileName;
                    newMelody.ImageLocalPath = await FileOperations.CopyFileAsync(author.ImageLocalPath, 
                                                                                  _environment.ContentRootPath,
                                                                                  "Files/Melodies/Pictures",
                                                                                  newMelody.ImageFileName);
            }

            if (melody.AudioFile != null)
            {
                (string, string) nameAndPath = await FileOperations.SaveFileAsync(melody.AudioFile,
                                               _environment.ContentRootPath,
                                               "Files/Melodies/Audio");

                newMelody.AudioFileName = nameAndPath.Item1;
                newMelody.LocalPath = nameAndPath.Item2;
            }
            await _context.Melodies.AddAsync(newMelody);

            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured while saving object in DataBase";

                FileOperations.DeleteFile(newMelody.LocalPath);
                FileOperations.DeleteFile(newMelody.ImageLocalPath);

                return Response;
            }

            Response.Result = _mapper.Map<GetMelodyDTO?>(newMelody);

            return Response;
        }

        public async Task<ResponseDTO> DeleteMelodyAsync(Guid id)
        {
            var melody = _context.Melodies.Find(id);

            if (melody == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Can't find object in database";

                return Response;
            }

            var author = _context.Authors.Where(a => a.ID == melody.AuthorId).SingleOrDefault();
            var melodyFilePath = melody.LocalPath;
            var imageName = melody.ImageFileName;
            var imageFilePath = melody.ImageLocalPath;

            try
            {
                var albums = await _context.AlbumMelodies.Where(a => a.MelodyId == melody.ID).ToListAsync();
                _context.AlbumMelodies.RemoveRange(albums);

                var genres = await _context.GenreMelodies.Where(a => a.MelodyId == melody.ID).ToListAsync();
                _context.GenreMelodies.RemoveRange(genres);

                var users = await _context.UserMelodies.Where(a => a.MelodyId == melody.ID).ToListAsync();
                _context.UserMelodies.RemoveRange(users);
            }
            catch(Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured when object delete from database";

                return Response;
            }

            _context.Melodies.Remove(melody);

            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured when object delete from database";

                return Response;
            }

            FileOperations.DeleteFile(melodyFilePath);

            if(imageName != "Default.png")
                FileOperations.DeleteFile(imageFilePath);

            return Response;
        }

        public async Task<ResponseDTO> GetAllMelodiesAsync()
        {
            IEnumerable<Melody> melodies = [.. _context.Melodies.Include(m => m.Author)];

            IEnumerable<GetMelodyDTO> result = await Task.FromResult<IEnumerable<GetMelodyDTO>>
                            (_mapper.Map<IEnumerable<GetMelodyDTO>>(melodies));

            foreach (var melody in result)
            {
                IEnumerable<Guid> genreGuids = await _context.GenreMelodies.Where(a => a.MelodyId == melody.Id)
                                                                      .Select(a => a.GenreId)
                                                                      .ToListAsync();

                IEnumerable<GetUnconnectedGenreDTO> genres = _mapper.Map<IEnumerable<GetUnconnectedGenreDTO>>
                    (_context.Genres.Where(a => genreGuids.Contains(a.ID)).ToList());

                melody.Genres = genres;
            }

            Response.Result = result;

            return Response;
        }

        public async Task<ResponseDTO> GetMelodyByIdAsync(Guid id)
        {
            var melody = await _context.Melodies.FindAsync(id);

            if (melody == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Can't find object in database";

                return Response;
            }

            Response.Result = _mapper.Map<Melody>(melody);

            return Response;
        }

        public async Task<byte[]?> GetMelodyStream(Guid id)
        {
            return await File.ReadAllBytesAsync(_context.Melodies.Where(m => m.ID == id)
                                                                 .Select(m => m.LocalPath)
                                                                 .SingleOrDefault() ?? "");
        }

        public async Task<ResponseDTO> UpdateMelodyAsync(Guid id, UpdateMelodyDTO melody)
        {
            var currentMelody = await _context.Melodies.FindAsync(id);
            if (currentMelody == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Can't find object in DataBase";

                return Response;
            }

            _context.Entry<Melody>(currentMelody).CurrentValues.SetValues(melody);
            var result = await _context.SaveChangesAsync();

            if(result <= 0)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured while save in DataBase";

                return Response;
            }

            if (melody.ImageFile != null)
            {
                FileOperations.DeleteFile(currentMelody?.ImageLocalPath ?? "");

                if (currentMelody == null)
                {
                    Response.IsSuccess = false;
                    Response.Message = "Object is missing";

                    return Response;
                }

                (string, string) nameAndPath = await FileOperations.SaveFileAsync(melody.ImageFile,
                                               _environment.ContentRootPath,
                                               "Files/Melodies/Pictures");

                currentMelody.ImageFileName = nameAndPath.Item1;
                currentMelody.ImageLocalPath = nameAndPath.Item2;
            }

            if (melody.AudioFile != null) 
            {
                FileOperations.DeleteFile(currentMelody.LocalPath ?? "");

                if (currentMelody == null)
                {
                    Response.IsSuccess = false;
                    Response.Message = "Object is missing";

                    return Response;
                }

                (string, string) nameAndPath = await FileOperations.SaveFileAsync(melody.AudioFile,
                                               _environment.ContentRootPath,
                                               "Files/Melodies/Audio");

                currentMelody.AudioFileName = nameAndPath.Item1;
                currentMelody.LocalPath = nameAndPath.Item2;
            }

            Response.Result = _mapper?.Map<GetMelodyDTO>(currentMelody);
            return Response;
        }
    }
}