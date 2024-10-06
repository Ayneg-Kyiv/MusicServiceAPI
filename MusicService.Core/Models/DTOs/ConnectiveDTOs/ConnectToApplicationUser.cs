using MusicService.Core.Models.Identity;

namespace MusicService.Core.Models.DTOs.ConnectiveDTOs
{
    public class ConnectToApplicationUser
    {
        public string ApplicationUserId { get; set; } = null!;

        public Guid MelodyId { get; set; }
    }
}
