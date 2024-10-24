using MusicServiceMauiClient.DTOs.GenreDTOs;

namespace MusicServiceMauiClient.Services
{
    public interface IGenre
    {
        public Task<IEnumerable<GetGenreDTO>> GetGenresAsync();
        Task<bool> DeleteGenreAsync(Guid genreId); 
    }
}
