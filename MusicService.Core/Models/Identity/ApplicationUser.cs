using Microsoft.AspNetCore.Identity;
using MusicService.Core.Models.Connective;

namespace MusicService.Core.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public virtual List<ApplicationUserMelody> Melodies { get; set; } = [];
    }
}
