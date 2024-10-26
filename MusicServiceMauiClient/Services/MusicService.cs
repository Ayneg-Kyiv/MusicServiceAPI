using MusicServiceMauiClient.Constants;
using MusicServiceMauiClient.Models;
using Newtonsoft.Json;
using MusicServiceMauiClient.DTOs.MelodyDTOs;
using System.Net.Http.Headers;

namespace MusicServiceMauiClient.Services
{
    public class MusicService (ILogin _login) : IMusic
    {
        private readonly HttpClient _httpClient = new();
        private readonly string BaseUrl = $"https://{TunnelUrlData.Url}/";

        public async Task<bool> DeleteMelodyAsync(Guid guid)
        {
            try
            {
                var dataUrl = "api/Melodies/";
                var token = _login.GetToken();

                _httpClient.DefaultRequestHeaders.Clear();

                _httpClient.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue("Bearer", token);
                _httpClient.DefaultRequestHeaders.Add("id", guid.ToString());

                var response = await _httpClient.DeleteAsync(BaseUrl + dataUrl);

                var content = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<ResponseDTO>(content);

                if (data == null)
                    return false;
                return data.IsSuccess;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<GetMelodyDTO>> GetMusicAsync()
        {
            var dataUrl = "api/Melodies/All";
            var response = await _httpClient.GetAsync(BaseUrl + dataUrl);

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseDTO>(content);

            return JsonConvert.DeserializeObject<IEnumerable<GetMelodyDTO>>
                (data?.Result?.ToString() ?? "") ?? [];
        }
    }
}
