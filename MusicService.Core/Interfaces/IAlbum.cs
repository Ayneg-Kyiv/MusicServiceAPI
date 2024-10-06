using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.AlbumsDTO;

namespace MusicService.Core.Interfaces
{
    public interface IAlbum
    {
        Task<ResponseDTO> GetAllAlbumsAsync();
        Task<ResponseDTO> GetAlbumByIdAsync(Guid id);
        Task<ResponseDTO> CreateAlbumAsync(CreateAlbumDTO album);
        Task<ResponseDTO> UpdateAlbumAsync(Guid id, UpdateAlbumDTO album);
        Task<ResponseDTO> DeleteAlbumAsync(Guid id);
    }
}
