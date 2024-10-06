using MusicService.Core.Models.Abstract;

namespace MusicService.Core.Models.Connective
{
    public class GenreMelody : BaseModel
    {
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        public Guid MelodyId { get; set; }
        public Melody Melody { get; set; } = null!;
    }
}
