using MediatR;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;

using System.Threading.Tasks;

namespace MusicService.BLL.Queries
{
    public record GetAlbumByIdQuery(Guid Id) : IRequest<ResponseDTO>;

    public class GetAlbumByIdQueryHandler(IAlbum albumsRepository)
       : IRequestHandler<GetAlbumByIdQuery, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(GetAlbumByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await albumsRepository.GetAlbumByIdAsync(request.Id);
        }
    }
}
