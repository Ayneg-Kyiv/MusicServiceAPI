using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Commands
{
    public record DeleteAlbumCommand(Guid Id) : IRequest<ResponseDTO>;
    public class DeleteAlbumCommandHandler(IAlbum albumsRepository, IPublisher mediatR)
        : IRequestHandler<DeleteAlbumCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(DeleteAlbumCommand request,
                                               CancellationToken cancellationToken)
        {
            var result = await albumsRepository.DeleteAlbumAsync(request.Id);


            await mediatR.Publish(new UserCreatedEvent(result?.Message ?? ""));
            return result;
        }
    }
}
