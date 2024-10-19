using MusicServiceMauiClient.Constants;
using MusicServiceMauiClient.DTOs.AuthorDTOs;
using MusicServiceMauiClient.Models;
using Newtonsoft.Json;

namespace MusicServiceMauiClient.Services
{
    public class AuthorService : IAuthor
    {
        private readonly HttpClient _httpClient = new();
        private readonly string BaseUrl = $"https://{TunnelUrlData.Url}/";
        public async Task<IEnumerable<GetAuthorDTO>> GetAuthorsAsync()
        {
            var dataUrl = "api/Authors/";
            var response = await _httpClient.GetAsync(BaseUrl + dataUrl);

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseDTO>(content);

            return JsonConvert.DeserializeObject<IEnumerable<GetAuthorDTO>>(
                data?.Result?.ToString() ?? "") ?? [];
        }

    }
}
