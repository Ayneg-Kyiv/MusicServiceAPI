using MusicServiceMauiClient.Constants;
using MusicServiceMauiClient.DTOs.GenreDTOs;
using MusicServiceMauiClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MusicServiceMauiClient.Services
{
    public class GenreService : IGenre
    {
        private readonly HttpClient _httpClient = new();
        private readonly string BaseUrl = $"https://{TunnelUrlData.Url}/";
        private readonly ILogin _login;

        public async Task<IEnumerable<GetGenreDTO>> GetGenresAsync()
        {
            var dataUrl = "api/Genre";
            var response = await _httpClient.GetAsync(BaseUrl + dataUrl);

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseDTO>(content);

            return JsonConvert.DeserializeObject<IEnumerable<GetGenreDTO>>
                (data?.Result?.ToString() ?? "") ?? [];
        }

        private void SetAuthorizationHeader()
        {
            var token = _login.GetToken(); 
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public GenreService(ILogin login)
        {
            _login = login; 
            SetAuthorizationHeader(); 
        }

        public async Task<HttpResponseMessage> AddGenreAsync(CreateGenreDTO newGenre)
        {
            var dataUrl = "api/Genre";
            var jsonContent = new StringContent(JsonConvert.SerializeObject(newGenre), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(BaseUrl + dataUrl, jsonContent);

            return response;
        }

        public async Task<bool> DeleteGenreAsync(Guid guid)
        {
            var dataUrl = $"api/Genre";
            var token = _login.GetToken();

            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);
            _httpClient.DefaultRequestHeaders.Add("id", guid.ToString());


            var response = await _httpClient.DeleteAsync(BaseUrl + dataUrl);

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseDTO>(content);
            return data!.IsSuccess;
        }
    }
}


