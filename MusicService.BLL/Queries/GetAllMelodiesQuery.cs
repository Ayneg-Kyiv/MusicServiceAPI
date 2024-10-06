using MediatR;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Queries
{
    public record GetAllMelodiesQuery() : IRequest<ResponseDTO>;

    public class GetAllMelodiesQueryHandler(IMelody melodiesRepository)
        : IRequestHandler<GetAllMelodiesQuery, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(GetAllMelodiesQuery request,
            CancellationToken cancellationToken)
        {
            return await melodiesRepository.GetAllMelodiesAsync();
        }
    }
}
