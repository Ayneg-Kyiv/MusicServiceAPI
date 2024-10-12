using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Connective;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Commands.Connective.GenreAlbum
{
    public record DeleteGenreAlbumConnectionCommand(Guid Id)
        : IRequest<ResponseDTO>;

    public class DeleteGenreAlbumConnectionCommandHandler(IGenreAlbum genreAlbumRepository,
        IPublisher mediatR)
        : IRequestHandler<DeleteGenreAlbumConnectionCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(DeleteGenreAlbumConnectionCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await genreAlbumRepository.DeleteConnectionAsync(request.Id);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
