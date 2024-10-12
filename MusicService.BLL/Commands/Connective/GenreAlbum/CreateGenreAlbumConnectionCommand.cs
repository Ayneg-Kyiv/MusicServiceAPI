using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Connective;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.ConnectiveDTOs;

namespace MusicService.BLL.Commands.Connective.GenreAlbum
{
    public record CreateGenreAlbumConnectionCommand(ConnectFromToDTO Connect)
        : IRequest<ResponseDTO>;

    public class CreateGenreAlbumConnectionCommandHandler(IGenreAlbum genreAlbumRepository,
        IPublisher mediatR)
        : IRequestHandler<CreateGenreAlbumConnectionCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(CreateGenreAlbumConnectionCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await genreAlbumRepository.CreateConnectionAsync(request.Connect);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
