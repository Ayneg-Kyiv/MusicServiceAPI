using Microsoft.AspNetCore.Mvc;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.MelodyDTOs;

namespace MusicService.Core.Interfaces
{
    public interface IMelody
    {
        Task<ResponseDTO> GetAllMelodiesAsync();
        Task<ResponseDTO> GetMelodyByIdAsync(Guid id);
        Task<byte[]?> GetMelodyStream(Guid id);
        Task<ResponseDTO> CreateMelodyAsync(CreateMelodyDTO melody);
        Task<ResponseDTO> UpdateMelodyAsync(Guid id, UpdateMelodyDTO melody);
        Task<ResponseDTO> DeleteMelodyAsync(Guid id);
    }
}
