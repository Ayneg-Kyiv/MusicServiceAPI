using MusicServiceMauiClient.DTOs.AuthorDTOs;
namespace MusicServiceMauiClient.Services
{
    public interface IAuthor
    {
        public Task<IEnumerable<GetAuthorDTO>> GetAuthorsAsync();
        public Task<bool> DeleteAuthorAsync(Guid guid);
        public Task<GetAuthorDTO> AddAuthorAsync(CreateAuthorDTO author);
    }
}
