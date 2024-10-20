using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicServiceMauiClient.Services
{
    public interface IAuthorization
    {
        bool IsUserLoggedIn();
        public string GetEmailUser();
        public void LogOut();
    }
}
