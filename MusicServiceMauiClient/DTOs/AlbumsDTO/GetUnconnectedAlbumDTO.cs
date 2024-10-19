
namespace MusicServiceMauiClient.DTOs.AlbumsDTO
{
    public class GetUnconnectedAlbumDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
