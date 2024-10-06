using MusicService.Core.Models.DTOs.IdentityDTOs;

namespace MusicService.Core.Interfaces.Identity
{
    public interface IAccount
    {
        Task<bool> Register(Register register);
        Task<bool> Login(Login login);
    }
}
