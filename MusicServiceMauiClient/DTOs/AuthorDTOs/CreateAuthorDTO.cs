namespace MusicServiceMauiClient.DTOs.AuthorDTOs
{
    public class CreateAuthorDTO
    {
        public string Name { get; set; } = null!;
        public string? About { get; set; }

        //public IFormFile? ImageFile { get; set; }
    }
}