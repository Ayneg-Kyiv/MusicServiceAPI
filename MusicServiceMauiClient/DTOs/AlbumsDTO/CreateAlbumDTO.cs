namespace MusicServiceMauiClient.DTOs.AlbumsDTO
{
    public class CreateAlbumDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public Guid AuthorId { get; set; }

        //public IFormFile? ImageFile { get; set; }
    }
}
