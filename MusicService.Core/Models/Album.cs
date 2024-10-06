using MusicService.Core.Models.Abstract;
using MusicService.Core.Models.Connective;

namespace MusicService.Core.Models
{
    public class Album : BaseModel
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string ImageFileName { get; set; } = null!;
        public string ImageLocalPath { get; set; } = null!;

        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public virtual List<AlbumMelody>? Melodies { get; set; }
        public virtual List<GenreAlbum>? Genres { get; set; }
    }
}
