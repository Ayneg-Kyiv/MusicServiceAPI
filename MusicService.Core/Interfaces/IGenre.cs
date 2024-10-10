using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.GenreDTOs;

namespace MusicService.Core.Interfaces
{
    public interface IGenre
    {
        Task<ResponseDTO> GetAllGenresAsync();
        Task<ResponseDTO> CreateGenreAsync(CreateGenreDTO genre);
        Task<ResponseDTO> UpdateGenreAsync(Guid id, UpdateGenreDTO genre);
        Task<ResponseDTO> DeleteGenreAsync(Guid id);
        Task<ResponseDTO> GetGenreByIdAsync(Guid id);
    }
}
