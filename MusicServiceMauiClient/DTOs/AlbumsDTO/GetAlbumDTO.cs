using MusicServiceMauiClient.DTOs.AuthorDTOs;
using MusicServiceMauiClient.DTOs.GenreDTOs;
using MusicServiceMauiClient.DTOs.MelodyDTOs;

namespace MusicServiceMauiClient.DTOs.AlbumsDTO
{
    public class GetAlbumDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string ImageFileName { get; set; } = null!;
        public string? ImageUrl { get; set; }

        public GetUnconnectedAuthorDTO Author { get; set; } = null!;
        public IEnumerable<GetUnconnectedGenreDTO>? Genres { get; set; }
        public IEnumerable<GetUnconnectedMelodyDTO>? Melodies { get; set; }

    }
}
