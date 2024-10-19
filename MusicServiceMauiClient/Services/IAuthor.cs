using MusicServiceMauiClient.DTOs.AuthorDTOs;
using MusicServiceMauiClient.DTOs.MelodyDTOs;
namespace MusicServiceMauiClient.Services
{
    public interface IAuthor
    {
        public Task<IEnumerable<GetAuthorDTO>> GetAuthorsAsync();

    }
}
