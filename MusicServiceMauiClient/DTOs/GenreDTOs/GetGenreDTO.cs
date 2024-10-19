using MusicServiceMauiClient.DTOs.AlbumsDTO;
using MusicServiceMauiClient.DTOs.AuthorDTOs;
using MusicServiceMauiClient.DTOs.MelodyDTOs;

namespace MusicServiceMauiClient.DTOs.GenreDTOs
{
    public class GetGenreDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public IEnumerable<GetUnconnectedAuthorDTO>? Authors { get; set; }
        public IEnumerable<GetUnconnectedAlbumDTO>? Albums { get; set; }
        public IEnumerable<GetUnconnectedMelodyDTO>? Melodies { get; set; }
    }
}
