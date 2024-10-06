using MusicService.Core.Models.Abstract;

namespace MusicService.Core.Models.Connective
{
    public class GenreAlbum: BaseModel
    {
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        public Guid AlbumId { get; set; }
        public Album Album { get; set; } = null!;
    }
}
