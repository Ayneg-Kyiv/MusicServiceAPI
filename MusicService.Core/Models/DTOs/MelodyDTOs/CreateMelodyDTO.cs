using Microsoft.AspNetCore.Http;

namespace MusicService.Core.Models.DTOs.MelodyDTOs
{
    public class CreateMelodyDTO
    {
        public string Title { get; set; } = null!;
      
        public int Duration { get; set; }

        public Guid AuthorId { get; set; }

        public IFormFile AudioFile { get; set; } = null!;
        public IFormFile? ImageFile { get; set; }
    }
}
