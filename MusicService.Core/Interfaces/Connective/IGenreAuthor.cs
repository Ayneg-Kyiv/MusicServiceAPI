using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.ConnectiveDTOs;

namespace MusicService.Core.Interfaces.Connective
{
    public interface IGenreAuthor
    {
        Task<ResponseDTO> CreateConnectionAsync(ConnectFromToDTO connect);
        Task<ResponseDTO> DeleteConnectionAsync(Guid Id);
    }
}
