namespace MusicServiceMauiClient.Models
{
    public class GetMelodyDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public int Duration { get; set; }

        public string ImageLocalPath { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
