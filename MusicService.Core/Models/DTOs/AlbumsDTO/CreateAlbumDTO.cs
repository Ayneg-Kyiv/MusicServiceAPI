using Microsoft.AspNetCore.Http;

namespace MusicService.Core.Models.DTOs.AlbumsDTO
{
    public class CreateAlbumDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public IFormFile? ImageFile { get; set; }
    }
}
