using MusicService.Core.Models.DTOs.AlbumsDTO;
using MusicService.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using MusicService.DAL.Data;
using MusicService.Core.Models;
using MusicService.Core.Models.DTOs;
using MusicService.Infrastructure.FileOperations;
using Microsoft.EntityFrameworkCore;
using MusicService.Core.Models.DTOs.MelodyDTOs;

namespace MusicService.DAL.Repository
{
    public class AlbumRepository(ApplicationDbContext _context, 
         IMapper _mapper,
         IWebHostEnvironment _env) : IAlbum
    {
        private ResponseDTO Response {  get; set; } = new ResponseDTO();

        public async Task<ResponseDTO> CreateAlbumAsync(CreateAlbumDTO album)
        {
            if (album == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Transit object is Empty";

                return Response;
            }

            var newAlbum = _mapper.Map<Album>(album);

            if (newAlbum == null)
            {
                Response.IsSuccess = false;
                Response.Message = "New album object is Empty";

                return Response;
            }

            if (album.ImageFile != null)
            {
                var nameAndPath = await FileOperations.SaveFileAsync(album.ImageFile,
                                     _env.ContentRootPath, "Files/Albums");

                newAlbum.ImageFileName = nameAndPath.Item1;
                newAlbum.ImageLocalPath = nameAndPath.Item2;
            }
            else
            {
                newAlbum.ImageFileName = "Default.png";
                newAlbum.ImageLocalPath = Path.Combine(_env.ContentRootPath, "Files/Albums/Default.png");
            }

            await _context.Albums.AddAsync(newAlbum);

            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured when object delete from database";

                return Response;
            }

            Response.Result = _mapper.Map<GetAlbumDTO?>(newAlbum);

            return Response;
        }

        public async Task<ResponseDTO> DeleteAlbumAsync(Guid id)
        {
            var album = await _context.Albums.FindAsync(id);

            if (album == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Can't find object in database";

                return Response;
            }

            var filePath = album.ImageLocalPath;

            _context.Albums.Remove(album);

            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured when object delete from database";

                return Response;
            }

            FileOperations.DeleteFile(filePath);
            return Response;
        }

        public async Task<ResponseDTO> GetAlbumByIdAsync(Guid id)
        {
            var album = await _context.Albums.FindAsync(id);

            if (album == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Can't find object in database";

                return Response;
            }

            Response.Result = _mapper.Map<GetAlbumDTO>(album);

            return Response;
        }

        public async Task<ResponseDTO> GetAllAlbumsAsync()
        {
            IEnumerable<Album> albums = [.. _context.Albums.Include(a => a.Author)];

            var getAlbums = await Task.FromResult<IEnumerable<GetAlbumDTO>>
                            (_mapper.Map<IEnumerable<GetAlbumDTO>>(albums));

            foreach (var album in getAlbums)
            {
                IEnumerable<Guid> melodyGuids = await _context.AlbumMelodies.Where(a => a.AlbumId == album.Id)
                                                                      .Select(a => a.MelodyId)
                                                                      .ToListAsync();

                IEnumerable<GetUnconnectedMelodyDTO> melodies = _mapper.Map<IEnumerable<GetUnconnectedMelodyDTO>>
                    (_context.Melodies.Where(m => melodyGuids.Contains(m.ID)).ToList());

                album.Melodies = melodies;
            }

            Response.Result = getAlbums;

            return Response;
        }

        public async Task<ResponseDTO> UpdateAlbumAsync(Guid id, UpdateAlbumDTO album)
        {
            var currentAlbum = await _context.Albums.FindAsync(id);

            if (currentAlbum == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Can't find object in database";

                return Response;
            }

            _context.Entry<Album>(currentAlbum).CurrentValues.SetValues(album);
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured while save in DataBase";

                return Response;
            }

            if (album.ImageFile != null)
            {
                FileOperations.DeleteFile(currentAlbum?.ImageLocalPath ?? "");

                if (currentAlbum == null)
                {
                    Response.IsSuccess = false;
                    Response.Message = "Object is missing";

                    return Response;
                }

                (string, string) nameAndPath = await FileOperations.SaveFileAsync(album.ImageFile,
                                                                    _env.ContentRootPath,
                                                                    "Files/Albums");

                currentAlbum.ImageFileName = nameAndPath.Item1;
                currentAlbum.ImageLocalPath = nameAndPath.Item2;
            }

            Response.Result = _mapper?.Map<GetAlbumDTO>(currentAlbum);
            return Response; throw new NotImplementedException();
        }
    }
}
