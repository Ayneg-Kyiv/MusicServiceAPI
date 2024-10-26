using MusicServiceMauiClient.Constants;
using MusicServiceMauiClient.DTOs.IdentityDTOs;
using MusicServiceMauiClient.Models;
using Newtonsoft.Json;
using System.Text;

namespace MusicServiceMauiClient.Services
{
    public class RegistrationService : IRegister
    {
        private readonly HttpClient _httpClient = new();
        private readonly string BaseUrl = $"https://{TunnelUrlData.Url}/";

        public async Task<bool> Register(RegisterDTO register)
        {
            try
            {
                var dataUrl = $"{BaseUrl}api/Account/Register";

                var jsonContent = JsonConvert.SerializeObject(register);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(dataUrl, content);
                var responseString = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<ResponseDTO>(responseString);

                if (data == null)
                    return false;

                var message = data!.Result!.ToString();

                if (message == "You been succesfully registered"
                    || message == "User created but target role is not exists")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
