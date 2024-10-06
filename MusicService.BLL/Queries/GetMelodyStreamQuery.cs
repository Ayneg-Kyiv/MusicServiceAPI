using MediatR;
using MusicService.Core.Interfaces;

namespace MusicService.BLL.Queries
{
    public record GetMelodyStreamQuery(Guid Id) : IRequest<byte[]?>;

    public class GetMelodyStreamQueryHandler(IMelody melodiesRepository)
        : IRequestHandler<GetMelodyStreamQuery, byte[]?>
    {
        public async Task<byte[]?> Handle(GetMelodyStreamQuery request,
            CancellationToken cancellationToken)
        {
            return await melodiesRepository.GetMelodyStream(request.Id);
        }
    }
}
