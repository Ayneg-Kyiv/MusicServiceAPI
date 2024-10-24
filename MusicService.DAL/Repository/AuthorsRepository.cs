using MusicService.Core.Models.DTOs.AuthorDTOs;
using MusicService.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using MusicService.Core.Models;
using MusicService.DAL.Data;
using MusicService.Infrastructure.FileOperations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicService.Core.Models.DTOs;
using Azure;
using MusicService.Core.Models.DTOs.MelodyDTOs;
using MusicService.Core.Models.DTOs.GenreDTOs;

namespace MusicService.DAL.Repository
{
    public class AuthorsRepository( ApplicationDbContext _context, 
                                   IMapper _mapper,
                                   IWebHostEnvironment _environment) : IAuthor
    {
        private ResponseDTO Response {  get; set; } = new ResponseDTO();

        public async Task<ResponseDTO> CreateAuthorAsync(CreateAuthorDTO author)
        {
            if (author == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Transit object is Empty";

                return Response;
            }

            var newAuthor = _mapper.Map<Author>(author);

            if(newAuthor == null)
            {
                Response.IsSuccess = false;
                Response.Message = "New author object is Empty";

                return Response;
            }

            if (author.ImageFile != null)
            {
                var nameAndPath = await FileOperations.SaveFileAsync(author.ImageFile,
                                     _environment.ContentRootPath, "Files/Authors");

                newAuthor.ImageFileName = nameAndPath.Item1;
                newAuthor.ImageLocalPath = nameAndPath.Item2;
            }
            else
            {
                newAuthor.ImageFileName = "Default.png";
                newAuthor.ImageLocalPath = Path.Combine(_environment.ContentRootPath, "Files/Authors/Default.png");
            }    

            await _context.Authors.AddAsync(newAuthor);

            var result = await _context.SaveChangesAsync();
            
            if(result <= 0)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured when object delete from database";

                return Response;
            }

            Response.Result = _mapper.Map<GetAuthorDTO?>(newAuthor);

            return Response;
        }

        public async Task<ResponseDTO> DeleteAuthorAsync(Guid id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Can't find object in database";

                return Response;
            }

            var fileName = author.ImageFileName;
            var filePath = author.ImageLocalPath;

            _context.Authors.Remove(author);

            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured when object delete from database";

                return Response;
            }

            if(fileName != "Default.png")
                FileOperations.DeleteFile(filePath);

            return Response;
        }

        public async Task<ResponseDTO> GetAllAuthorsAsync()
        {
            IEnumerable<Author> authors = [.. _context.Authors.Include(a => a.Melodies)];

           var getAuthors = await Task.FromResult<IEnumerable<GetAuthorDTO>>
                            (_mapper.Map<IEnumerable<GetAuthorDTO>>(authors));

            foreach (var author in getAuthors)
            {
                IEnumerable<Guid> guidsGenre = await _context.GenreAuthors.Where(g => g.AuthorId == author.Id)
                                                                      .Select(g => g.GenreId)
                                                                      .ToListAsync();

                IEnumerable<GetUnconnectedGenreDTO> genres = _mapper.Map<IEnumerable<GetUnconnectedGenreDTO>>
                    (_context.Genres.Where(g => guidsGenre.Contains(g.ID)).ToList());

                author.Genres = genres;
            }

            Response.Result = getAuthors;

            return Response;
        }

        public async Task<ResponseDTO> GetAuthorByIdAsync(Guid id)
        {
            var author = await _context.Authors.FindAsync(id);

            if(author == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Can't find object in database";

                return Response;
            }

            Response.Result = _mapper.Map<GetAuthorDTO>(author);

            return Response;
        }

        public async Task<ResponseDTO> UpdateAuthorAsync(Guid id, UpdateAuthorDTO author)
        {
            var currentAuthor = await _context.Authors.FindAsync(id);

            if(currentAuthor == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Can't find object in database";

                return Response;
            }

            _context.Entry<Author>(currentAuthor).CurrentValues.SetValues(author);
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured while save in DataBase";

                return Response;
            }

            if (author.ImageFile != null)
            {
                FileOperations.DeleteFile(currentAuthor?.ImageLocalPath ?? "");
             
                if (currentAuthor == null)
                {
                    Response.IsSuccess = false;
                    Response.Message = "Object is missing";

                    return Response;
                }

                (string, string) nameAndPath = await FileOperations.SaveFileAsync(author.ImageFile,
                                                                    _environment.ContentRootPath,
                                                                    "Files/Authors");

                currentAuthor.ImageFileName = nameAndPath.Item1;
                currentAuthor.ImageLocalPath = nameAndPath.Item2;
            }

            Response.Result = _mapper?.Map<GetAuthorDTO>(currentAuthor);
            return Response;
        }
    }
}
