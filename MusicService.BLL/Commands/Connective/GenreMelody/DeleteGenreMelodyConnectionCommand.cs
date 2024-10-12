using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Connective;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Commands.Connective.GenreMelody
{
    public record DeleteGenreMelodyConnectionCommand(Guid Id)
        : IRequest<ResponseDTO>;

    public class DeleteGenreMelodyConnectionCommandHandler(IGenreMelody genreMelodyRepository,
        IPublisher mediatR)
        : IRequestHandler<DeleteGenreMelodyConnectionCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(DeleteGenreMelodyConnectionCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await genreMelodyRepository.DeleteConnectionAsync(request.Id);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
