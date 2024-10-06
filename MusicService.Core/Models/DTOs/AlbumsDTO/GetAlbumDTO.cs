using MusicService.Core.Models.DTOs.AuthorDTOs;
using MusicService.Core.Models.DTOs.GenreDTOs;
using MusicService.Core.Models.DTOs.MelodyDTOs;

namespace MusicService.Core.Models.DTOs.AlbumsDTO
{
    public class GetAlbumDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string ImageFileName { get; set; } = null!;
        public string? ImageUrl { get; set; }

        public GetAuthorDTO Author { get; set; } = null!;
        public IEnumerable<GetUnconnectedGenreDTO>? Genres { get; set; }
        public IEnumerable<GetUnconnectedMelodyDTO>? Melodies { get; set; }

    }
}
