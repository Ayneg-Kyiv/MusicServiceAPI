using MusicServiceMauiClient.DTOs.MelodyDTOs;

namespace MusicServiceMauiClient.Services
{
    public interface IMusic
    {
        public Task<IEnumerable<GetMelodyDTO>> GetMusicAsync();

    }
}
