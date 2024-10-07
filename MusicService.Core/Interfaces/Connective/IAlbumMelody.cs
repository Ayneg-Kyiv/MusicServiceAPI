using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.AlbumsDTO;
using MusicService.Core.Models.DTOs.ConnectiveDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicService.Core.Interfaces.Connective
{
    public interface IAlbumMelody
    {
       Task<ResponseDTO> CreateConnectionAsync(ConnectFromToDTO connect);
       Task<ResponseDTO> DeleteConnectionAsync(Guid Id);
    }
}
