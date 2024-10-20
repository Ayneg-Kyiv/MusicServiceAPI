using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicServiceMauiClient.Services
{
    public class AuthorizationService : IAuthorization
    {
        private readonly ILogin loginService;

        public AuthorizationService(ILogin loginService)
        {
            this.loginService = loginService;
        }

        public bool IsUserLoggedIn()
        {
            return loginService.IsLoggedIn();
        }

        public string GetEmailUser()
        {
            return loginService.GetEmail();
        }

        public void LogOut()
        {
            loginService.LogOut();
        }
    }
}

