using MusicService.Core.Models;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.AuthorDTOs;

namespace MusicService.Core.Interfaces
{
    public interface IAuthor
    {
        Task<ResponseDTO> GetAllAuthorsAsync();
        Task<ResponseDTO> GetAuthorByIdAsync(Guid id);
        Task<ResponseDTO> CreateAuthorAsync(CreateAuthorDTO author);
        Task<ResponseDTO> UpdateAuthorAsync(Guid id, UpdateAuthorDTO author);
        Task<ResponseDTO> DeleteAuthorAsync (Guid id);
    }
}
