using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicServiceMauiClient.DTOs.AuthorDTOs
{
    public class GetUnconnectedAuthorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? About { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
}
