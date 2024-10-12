using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Connective;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.ConnectiveDTOs;

namespace MusicService.BLL.Commands.Connective.GenreMelody
{
    public record CreateGenreMelodyConnectionCommand(ConnectFromToDTO Connect)
        : IRequest<ResponseDTO>;

    public class CreateGenreMelodyConnectionCommandHandler(IGenreMelody genreMelodyRepository,
        IPublisher mediatR)
        : IRequestHandler<CreateGenreMelodyConnectionCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(CreateGenreMelodyConnectionCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await genreMelodyRepository.CreateConnectionAsync(request.Connect);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
