namespace MusicService.Core.Models.DTOs.IdentityDTOs
{
    public class TokenReturn
    {
        public string Token { get; set; } = string.Empty;
        public IEnumerable<string> Roles { get; set; } = [];
    }
}
