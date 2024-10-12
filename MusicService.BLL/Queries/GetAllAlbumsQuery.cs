using MediatR;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;


namespace MusicService.BLL.Queries
{
    public record GetAllAlbumsQuery(): IRequest<ResponseDTO>;

    public class GetAllAlbumsQueryHandler(IAlbum albumsRepository)
       : IRequestHandler<GetAllAlbumsQuery, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(GetAllAlbumsQuery request,
            CancellationToken cancellationToken)
        {
            return await albumsRepository.GetAllAlbumsAsync();
        }
    }
}
