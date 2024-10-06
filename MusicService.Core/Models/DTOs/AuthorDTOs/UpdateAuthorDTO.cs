using Microsoft.AspNetCore.Http;

namespace MusicService.Core.Models.DTOs.AuthorDTOs
{
    public class UpdateAuthorDTO
    {
        public string Name { get; set; } = null!;
        public string? About { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
