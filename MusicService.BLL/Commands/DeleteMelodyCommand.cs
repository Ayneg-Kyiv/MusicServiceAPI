using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Commands
{
    public record DeleteMelodyCommand(Guid Id) : IRequest<ResponseDTO>;

    public class DeleteMelodyCommandHandler(IMelody melodiesRepository, IPublisher mediatR)
        : IRequestHandler<DeleteMelodyCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(DeleteMelodyCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await melodiesRepository.DeleteMelodyAsync(request.Id);

            await mediatR.Publish(new UserCreatedEvent(response.Message ?? ""));

            return response;
        }
    }
}
