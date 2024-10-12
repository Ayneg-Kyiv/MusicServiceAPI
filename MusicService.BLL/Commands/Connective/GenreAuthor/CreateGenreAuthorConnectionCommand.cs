using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Connective;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.ConnectiveDTOs;

namespace MusicService.BLL.Commands.Connective.GenreAuthor
{
    public record CreateGenreAuthorConnectionCommand(ConnectFromToDTO Connect)
        : IRequest<ResponseDTO>;

    public class CreateGenreAuthorConnectionCommandHandler(IGenreAuthor genreAuthorRepository,
        IPublisher mediatR)
        : IRequestHandler<CreateGenreAuthorConnectionCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(CreateGenreAuthorConnectionCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await genreAuthorRepository.CreateConnectionAsync(request.Connect);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
