using MusicService.Core.Models.DTOs.IdentityDTOs;

namespace MusicService.Core.Interfaces.Identity
{
    public interface IUser
    {
        Task<GetUserDTO> GetUserByEmail (string email);
        Task<bool> UpdateUserInformation(UpdateUserInfo update);
        Task<bool> DeleteUser(string email);
        Task<bool> ChangeUserPassword(ChangePassword changePassword);
    }
}
