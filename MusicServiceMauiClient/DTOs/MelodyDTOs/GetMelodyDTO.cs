using MusicServiceMauiClient.DTOs.AlbumsDTO;
using MusicServiceMauiClient.DTOs.AuthorDTOs;
using MusicServiceMauiClient.DTOs.GenreDTOs;

namespace MusicServiceMauiClient.DTOs.MelodyDTOs
{
    public class GetMelodyDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public int Duration { get; set; }

        public string ImageFileName { get; set; } = null!;
        public string? ImageUrl { get; set; }

        public GetUnconnectedAuthorDTO? Author { get; set; }
        public IEnumerable<GetUnconnectedAlbumDTO>? Albums { get; set; }
        public IEnumerable<GetUnconnectedGenreDTO>? Genres { get; set; }
    }
}
