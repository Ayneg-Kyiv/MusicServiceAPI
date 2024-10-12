using MediatR;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Queries
{
    public record GetGenreByIdQuery(Guid Id) : IRequest<ResponseDTO>;

    public class GetGenreByIdQueryHandler(IGenre genresRepository)
       : IRequestHandler<GetGenreByIdQuery, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(GetGenreByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await genresRepository.GetGenreByIdAsync(request.Id);
        }
    }
}
