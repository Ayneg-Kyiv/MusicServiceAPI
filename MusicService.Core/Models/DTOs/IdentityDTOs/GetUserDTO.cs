namespace MusicService.Core.Models.DTOs.IdentityDTOs
{
    public class GetUserDTO
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
