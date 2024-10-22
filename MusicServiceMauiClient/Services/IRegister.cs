using MusicServiceMauiClient.DTOs.IdentityDTOs;

namespace MusicServiceMauiClient.Services
{
    public interface IRegister
    {
        public Task<bool> Register(RegisterDTO register);
    }
}
