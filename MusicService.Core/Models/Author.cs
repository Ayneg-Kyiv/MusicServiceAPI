using MusicService.Core.Models.Abstract;
using MusicService.Core.Models.Connective;

namespace MusicService.Core.Models
{
    public class Author : BaseModel
    {
        public string Name { get; set; } = null!;
        public string? About { get; set; }

        public string ImageFileName { get; set; } = null!;
        public string ImageLocalPath { get; set; } = null!;

        public virtual List<GenreAuthor>? Genres { get; set; }
        public virtual List<Melody>? Melodies { get; set; }
        public virtual List<Album>? Albums { get; set; }
    }
}
