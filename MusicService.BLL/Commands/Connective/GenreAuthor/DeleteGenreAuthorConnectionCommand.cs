using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Connective;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Commands.Connective.GenreAuthor
{
    public record DeleteGenreAuthorConnectionCommand(Guid Id)
        : IRequest<ResponseDTO>;

    public class DeleteGenreAuthorConnectionCommandHandler(IGenreAuthor genreAuthorRepository,
        IPublisher mediatR)
        : IRequestHandler<DeleteGenreAuthorConnectionCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(DeleteGenreAuthorConnectionCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await genreAuthorRepository.DeleteConnectionAsync(request.Id);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
