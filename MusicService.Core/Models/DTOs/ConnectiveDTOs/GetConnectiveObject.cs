namespace MusicService.Core.Models.DTOs.ConnectiveDTOs
{
    public class GetConnectiveObject
    {
        public Guid FromId { get; set; }
        public Guid ToId { get; set; }

        public object? Object { get; set; }
    }
}
