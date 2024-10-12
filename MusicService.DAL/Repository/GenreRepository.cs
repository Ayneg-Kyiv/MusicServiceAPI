using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MusicService.Core.Interfaces;
using MusicService.Core.Models;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.GenreDTOs;
using MusicService.DAL.Data;
using MusicService.Core.Models.DTOs.AuthorDTOs;
using MusicService.Core.Models.DTOs.GenreDTOs;
using MusicService.DAL.Data;
using MusicService.Infrastructure.FileOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicService.DAL.Repository
{
    public class GenreRepository(ApplicationDbContext _context,
                                   IMapper _mapper
                                     ) : IGenre
    {
        public ResponseDTO Response { get; set; } = new ResponseDTO(); 
        public async Task<ResponseDTO> CreateGenreAsync(CreateGenreDTO genre)
        {
            if (genre == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Transit object is Empty";

                return Response;
            }

            var newGenre = _mapper.Map<Genre>(genre);

            if (newGenre == null)
            {
                Response.IsSuccess = false;
                Response.Message = "New genre object is Empty";
                return Response;
            }


            await _context.Genres.AddAsync(newGenre);

            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured when object delete from database";

                return Response;
            }

            Response.Result = _mapper.Map<GetGenreDTO?>(newGenre);

            return Response;
        }

        public async Task<ResponseDTO> DeleteGenreAsync(Guid id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Can't find object in database";

                return Response;
            }

            _context.Genres.Remove(genre);

            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured when object delete from database";

                return Response;
            }
            return Response;
        }

        public async Task<ResponseDTO> GetGenreByIdAsync(Guid id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Can't find object in database";

                return Response;
            }

            Response.Result = _mapper.Map<GetGenreDTO>(genre);

            return Response;
        }

        public async Task<ResponseDTO> GetAllGenresAsync()
        {
            IEnumerable<Genre> genres = [.. _context.Genres.Include(a => a.Melodies)];

            Response.Result = await Task.FromResult<IEnumerable<GetGenreDTO>>
                            (_mapper.Map<IEnumerable<GetGenreDTO>>(genres));

            return Response;
        }

        public async Task<ResponseDTO> UpdateGenreAsync(Guid id, UpdateGenreDTO genre)
        {
            var currentGenre = await _context.Genres.FindAsync(id);

            if (currentGenre == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Can't find object in database";

                return Response;
            }

            _context.Entry<Genre>(currentGenre).CurrentValues.SetValues(genre);
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured while save in DataBase";

                return Response;
            }

            Response.Result = _mapper?.Map<GetGenreDTO>(currentGenre);
            return Response;
        }
    }
}
