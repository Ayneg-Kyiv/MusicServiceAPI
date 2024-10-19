namespace MusicServiceMauiClient.DTOs.MelodyDTOs
{
    public class GetUnconnectedMelodyDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
      
        public int Duration { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
}
