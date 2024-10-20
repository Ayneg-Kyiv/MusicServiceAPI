using MusicServiceMauiClient.Constants;
using MusicServiceMauiClient.DTOs.IdentityDTOs;
using MusicServiceMauiClient.Models;
using Newtonsoft.Json;
using System.Text;


namespace MusicServiceMauiClient.Services
{
    public class LoginService : ILogin
    {
        private readonly HttpClient _httpClient = new();
        private readonly string BaseUrl = $"https://{TunnelUrlData.Url}/";
        private string? _authToken;
        private string? _email; 

        public async Task<string> LoginAsync(LoginDTO loginModel)
        {
            var dataUrl = $"{BaseUrl}api/Account/Login";
            var jsonContent = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(dataUrl, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseDTO>(responseString);
            var token = data!.Result!.ToString();

            if (!string.IsNullOrEmpty(token))
            {
                _authToken = token;
                _email = loginModel.Email;
                return token;
            }
            else
            {
                return string.Empty;
            }
        }

        public bool IsLoggedIn()
        {
            
            return !string.IsNullOrEmpty(_authToken);
        }

        public string GetEmail()
        {
            return _email;
        }

        public void LogOut()
        {
            _authToken = null;
            _email = null;
        }
    }
}
