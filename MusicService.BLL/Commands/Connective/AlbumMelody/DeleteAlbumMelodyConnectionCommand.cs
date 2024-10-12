
using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Connective;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Commands.Connective.AlbumMelody
{
    public record DeleteAlbumMelodyConnectionCommand(Guid Id)
        : IRequest<ResponseDTO>;

    public class DeleteAlbumMelodyConnectionCommandHandler(IAlbumMelody albumMelodyRepository,
        IPublisher mediatR)
        : IRequestHandler<DeleteAlbumMelodyConnectionCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(DeleteAlbumMelodyConnectionCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await albumMelodyRepository.DeleteConnectionAsync(request.Id);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
