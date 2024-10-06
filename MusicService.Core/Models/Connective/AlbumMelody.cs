using MusicService.Core.Models.Abstract;

namespace MusicService.Core.Models.Connective
{
    public class AlbumMelody : BaseModel
    {
        public Guid AlbumId { get; set; }
        public Album Album { get; set; } = null!;

        public Guid MelodyId { get; set; }
        public Melody Melody { get; set; } = null!;
    }
}
