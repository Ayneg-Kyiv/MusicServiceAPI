using MusicService.Core.Models.Abstract;
using MusicService.Core.Models.Connective;

namespace MusicService.Core.Models
{
    public class Melody : BaseModel
    {
        public string Title { get; set; } = null!;
        public int Duration { get; set; }

        public string AudioFileName { get; set; } = null!;
        public string LocalPath { get; set; } = null!;

        public string ImageFileName { get; set; } = null!;
        public string ImageLocalPath { get; set; } = null!;

        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public virtual List<GenreMelody> Genres { get; set; } = [];
        public virtual List<AlbumMelody> Albums { get; set; } = [];
        public virtual List<ApplicationUserMelody> ApplicationUsers { get; set; } = [];
    }
}
