using Microsoft.AspNetCore.Http;

namespace MusicService.Core.Models.DTOs.AlbumsDTO
{
    public class UpdateAlbumDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public IFormFile? ImageFile { get; set; }
    }
}
