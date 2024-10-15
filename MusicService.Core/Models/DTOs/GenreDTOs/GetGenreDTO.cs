using MusicService.Core.Models.DTOs.AlbumsDTO;
using MusicService.Core.Models.DTOs.AuthorDTOs;
using MusicService.Core.Models.DTOs.MelodyDTOs;

namespace MusicService.Core.Models.DTOs.GenreDTOs
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
