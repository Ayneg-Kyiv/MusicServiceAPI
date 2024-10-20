using MusicServiceMauiClient.Constants;
using MusicServiceMauiClient.DTOs.GenreDTOs;
using MusicServiceMauiClient.Models;
using Newtonsoft.Json;

namespace MusicServiceMauiClient.Services
{
    public class GenreService : IGenre
    {
        private readonly HttpClient _httpClient = new();
        private readonly string BaseUrl = $"https://{TunnelUrlData.Url}/";

        public async Task<IEnumerable<GetGenreDTO>> GetGenresAsync()
        {
            var dataUrl = "api/Genre";
            var response = await _httpClient.GetAsync(BaseUrl + dataUrl);

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseDTO>(content);

            return JsonConvert.DeserializeObject<IEnumerable<GetGenreDTO>>
                (data?.Result?.ToString() ?? "") ?? [];
        }
    }
}
