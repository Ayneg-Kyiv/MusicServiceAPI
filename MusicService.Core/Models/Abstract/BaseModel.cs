using System.ComponentModel.DataAnnotations;

namespace MusicService.Core.Models.Abstract
{
    public abstract class BaseModel
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
