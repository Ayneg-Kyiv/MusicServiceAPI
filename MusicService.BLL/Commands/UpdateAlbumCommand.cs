using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.AlbumsDTO;

namespace MusicService.BLL.Commands
{
    public record UpdateAlbumCommand(Guid Id, UpdateAlbumDTO Album) : IRequest<ResponseDTO>;

    public class UpdateAlbumCommandHandler(IAlbum albumsRepository, IPublisher mediatR)
       : IRequestHandler<UpdateAlbumCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(UpdateAlbumCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await albumsRepository.UpdateAlbumAsync(request.Id, request.Album);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }

}
