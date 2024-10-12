using AutoMapper;
using MusicService.Core.Interfaces.Connective;
using MusicService.Core.Models.Connective;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.ConnectiveDTOs;
using MusicService.DAL.Data;

namespace MusicService.DAL.Repository.Connective
{
    public class GenreAuthorRepository(ApplicationDbContext _context,
                                       IMapper _mapper) : IGenreAuthor
    {
        private ResponseDTO Response { get; set; } = new ResponseDTO();

        public async Task<ResponseDTO> CreateConnectionAsync(ConnectFromToDTO connect)
        {
            if (connect == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Transit object is Empty";

                return Response;
            }

            var connective = _mapper.Map<GenreAuthor>(connect);

            if (connective == null)
            {
                Response.IsSuccess = false;
                Response.Message = "New connective object is Empty";

                return Response;
            }

            _context.GenreAuthors.Add(connective);
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured when object delete from database";

                return Response;
            }

            Response.Result = connective;

            return Response;
        }

        public async Task<ResponseDTO> DeleteConnectionAsync(Guid Id)
        {
            var connective = _context.GenreAuthors.Find(Id);

            if (connective == null)
            {
                Response.IsSuccess = false;
                Response.Message = "Can't find object in database";

                return Response;
            }

            _context.GenreAuthors.Remove(connective);

            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                Response.IsSuccess = false;
                Response.Message = "Error occured when object delete from database";

                return Response;
            }

            return Response;
        }
    }
}
