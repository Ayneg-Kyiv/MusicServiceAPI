using MusicServiceMauiClient.Constants;
using MusicServiceMauiClient.DTOs.GenreDTOs;
using MusicServiceMauiClient.Models;
using Newtonsoft.Json;

namespace MusicServiceMauiClient.Services
{
    public class GenreService(ILogin login) : IGenre
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

        public async Task<bool> DeleteGenreAsync(Guid guid)
        {
            try
            {
                var dataUrl = $"api/Genre";
                var token = login.GetToken();

                _httpClient.DefaultRequestHeaders.Clear();

                _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);
                _httpClient.DefaultRequestHeaders.Add("id", guid.ToString());

                var response = await _httpClient.DeleteAsync(BaseUrl + dataUrl);

                var content = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<ResponseDTO>(content);

                if (data == null)
                    return false;

                return data!.IsSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}


