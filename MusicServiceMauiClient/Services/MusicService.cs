using MusicServiceMauiClient.Constants;
using MusicServiceMauiClient.Models;
using Newtonsoft.Json;

namespace MusicServiceMauiClient.Services
{
    public class MusicService : IMusic
    {
        private readonly HttpClient _httpClient = new();
        private readonly string BaseUrl = $"https://{TunnelUrlData.Url}/";

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
