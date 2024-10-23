namespace MusicServiceMauiClient.Services
{
    public class AuthorizationService : IAuthorization
    {
        private readonly ILogin loginService;

        public AuthorizationService(ILogin loginService)
        {
            this.loginService = loginService;
        }

        public bool IsUserLoggedIn() => loginService.IsLoggedIn();
        
        public string GetEmailUser() => loginService.GetEmail();

        public bool DoesRoleExists(string roleName) => loginService.DoesRoleExists(roleName);

        public void LogOut() =>loginService.LogOut();
    }
}

