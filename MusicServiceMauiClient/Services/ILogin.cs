using MusicServiceMauiClient.DTOs.IdentityDTOs;

namespace MusicServiceMauiClient.Services
{
    public interface ILogin
    {
        bool IsLoggedIn();
        Task<string> LoginAsync(LoginDTO loginModel);

        public string GetEmail();
        public void LogOut();
    }
}
