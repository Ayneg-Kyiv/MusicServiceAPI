namespace MusicService.Core.Models.DTOs.GenreDTOs
{
    public class CreateGenreDTO
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
