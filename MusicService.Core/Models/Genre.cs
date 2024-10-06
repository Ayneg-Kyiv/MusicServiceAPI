using MusicService.Core.Models.Abstract;
using MusicService.Core.Models.Connective;

namespace MusicService.Core.Models
{
    public class Genre: BaseModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual List<GenreAlbum>? Albums { get; set; }
        public virtual List<GenreAuthor>? Authors { get; set; }
        public virtual List<GenreMelody>? Melodies { get; set; }
    }
}
