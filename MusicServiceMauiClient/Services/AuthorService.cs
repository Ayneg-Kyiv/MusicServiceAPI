using MusicServiceMauiClient.Constants;
using MusicServiceMauiClient.DTOs.AuthorDTOs;
using MusicServiceMauiClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MusicServiceMauiClient.Services
{
    public class AuthorService (ILogin _login) : IAuthor
    {
        private readonly HttpClient _httpClient = new();
        private readonly string BaseUrl = $"https://{TunnelUrlData.Url}/";

        public async Task<GetAuthorDTO> AddAuthorAsync(CreateAuthorDTO author)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAuthorAsync(Guid guid)
        {
            var dataUrl = "api/Authors/";

            var token = _login.GetToken();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _httpClient.DefaultRequestHeaders.Add("id", guid.ToString());

            var response = await _httpClient.DeleteAsync(BaseUrl + dataUrl);

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseDTO>(content);

            return data.IsSuccess;
        }

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
