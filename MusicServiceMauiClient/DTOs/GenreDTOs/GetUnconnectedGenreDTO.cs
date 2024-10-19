namespace MusicServiceMauiClient.DTOs.GenreDTOs
{
    public class GetUnconnectedGenreDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

    }
}
