using MusicServiceMauiClient.DTOs.IdentityDTOs;

namespace MusicServiceMauiClient.Services
{
    public interface ILogin
    {
        bool IsLoggedIn();

        Task<string> LoginAsync(LoginDTO loginModel);

        public string GetEmail();
        public string GetToken();

        public bool DoesRoleExists(string roleName);

        public string GetToken();

        public void LogOut();
    }
}
