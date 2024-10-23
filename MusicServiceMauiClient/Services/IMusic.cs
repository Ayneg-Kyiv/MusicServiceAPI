using MusicServiceMauiClient.DTOs.MelodyDTOs;

namespace MusicServiceMauiClient.Services
{
    public interface IMusic
    {
        public Task<IEnumerable<GetMelodyDTO>> GetMusicAsync();
        public Task<bool> DeleteMelodyAsync(Guid guid);
        public Task<GetMelodyDTO> AddMelodyAsync(CreateMelodyDTO melody);

    }
}
