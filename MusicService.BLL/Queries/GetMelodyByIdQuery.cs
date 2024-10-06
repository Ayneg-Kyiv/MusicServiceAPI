using MediatR;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Queries
{
    public record GetMelodyByIdQuery(Guid Id) : IRequest<ResponseDTO>;

    public class GetMelodyByIdQueryHandler(IMelody melodiesRepository)
        : IRequestHandler<GetMelodyByIdQuery, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(GetMelodyByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await melodiesRepository.GetMelodyByIdAsync(request.Id);
        }
    }
}
