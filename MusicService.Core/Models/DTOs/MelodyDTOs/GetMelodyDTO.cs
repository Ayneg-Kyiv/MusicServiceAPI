using MusicService.Core.Models.DTOs.AlbumsDTO;
using MusicService.Core.Models.DTOs.AuthorDTOs;
using MusicService.Core.Models.DTOs.GenreDTOs;

namespace MusicService.Core.Models.DTOs.MelodyDTOs
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
