namespace MusicService.Core.Models.DTOs.ConnectiveDTOs
{
    public class ConnectToApplicationUser
    {
        public Guid MelodyId { get; set; }

        public string ApplicationUserId { get; set; } = null!;
    }
}
