using MusicServiceMauiClient.Models;

namespace MusicServiceMauiClient.Services
{
    public interface IMusic
    {
        public Task<IEnumerable<GetMelodyDTO>> GetMusicAsync();
    }
}
