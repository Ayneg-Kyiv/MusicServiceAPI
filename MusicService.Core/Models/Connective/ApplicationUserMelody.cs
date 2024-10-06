using MusicService.Core.Models.Abstract;
using MusicService.Core.Models.Identity;

namespace MusicService.Core.Models.Connective
{
    public class ApplicationUserMelody : BaseModel
    {
        public string ApplicationUserId { get; set; } = null!;
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid MelodyId { get; set; }
        public Melody Melody { get; set; } = null!;
    }
}
