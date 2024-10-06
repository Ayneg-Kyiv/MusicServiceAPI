using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicService.Core.Models.DTOs.AuthorDTOs
{
    public class GetUnconnectedAuthorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? About { get; set; }

        public string ImageLocalPath { get; set; } = null!;
    }
}
