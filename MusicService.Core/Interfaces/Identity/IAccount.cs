using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.IdentityDTOs;

namespace MusicService.Core.Interfaces.Identity
{
    public interface IAccount
    {
        Task<ResponseDTO> Register(Register register);
        Task<ResponseDTO> Login(Login login);
    }
}
