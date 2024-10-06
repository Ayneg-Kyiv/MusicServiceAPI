using MusicService.Core.Models.DTOs.AlbumsDTO;
using MusicService.Core.Models.DTOs.GenreDTOs;
using MusicService.Core.Models.DTOs.MelodyDTOs;

namespace MusicService.Core.Models.DTOs.AuthorDTOs
{
    public class GetAuthorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? About { get; set; }

        public string ImageFileName { get; set; } = null!;
        public string? ImageUrl { get; set; }

        public IEnumerable<GetUnconnectedGenreDTO>? Genres { get; set; }
        public IEnumerable<GetUnconnectedMelodyDTO>? Melodies { get; set; }
        public IEnumerable<GetUnconnectedMelodyDTO>? Albums { get; set; }
    }
}
