using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.AlbumsDTO;

namespace MusicService.BLL.Commands
{
    public record CreateAlbumCommand(CreateAlbumDTO Album) : IRequest<ResponseDTO>;
    
        public class CreateAlbumCommandHandler(IAlbum albumsRepository, IPublisher mediatR)
        : IRequestHandler<CreateAlbumCommand, ResponseDTO>
        {
            public async Task<ResponseDTO> Handle(CreateAlbumCommand request,
                                                   CancellationToken cancellationToken)
            {
                var response = await albumsRepository.CreateAlbumAsync(request.Album);

                await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

                return response;
            }
        }
    
}
