using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Connective;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.ConnectiveDTOs;

namespace MusicService.BLL.Commands.Connective.AlbumMelody
{
    public record CreateAlbumMelodyConnectionCommand(ConnectFromToDTO Connect) 
        : IRequest<ResponseDTO>;

    public class CreateAlbumMelodyConnectionCommandHandler(IAlbumMelody albumMelodyRepository,
        IPublisher mediatR)
        : IRequestHandler<CreateAlbumMelodyConnectionCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(CreateAlbumMelodyConnectionCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await albumMelodyRepository.CreateConnectionAsync(request.Connect);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
