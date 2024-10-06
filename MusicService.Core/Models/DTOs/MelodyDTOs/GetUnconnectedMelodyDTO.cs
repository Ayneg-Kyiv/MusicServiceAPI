namespace MusicService.Core.Models.DTOs.MelodyDTOs
{
    public class GetUnconnectedMelodyDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public int Duration { get; set; }

        public string ImageLocalPath { get; set; } = null!;
    }
}
