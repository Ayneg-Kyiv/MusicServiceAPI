using MediatR;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Queries
{
    public record GetAllGenresQuery(): IRequest<ResponseDTO>;


    public class GetAllGenresQueryHandler(IGenre genresRepository)
       : IRequestHandler<GetAllGenresQuery, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(GetAllGenresQuery request,
            CancellationToken cancellationToken)
        {
            return await genresRepository.GetAllGenresAsync();
        }
    }
}
