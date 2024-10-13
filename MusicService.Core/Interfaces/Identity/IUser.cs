using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.IdentityDTOs;

namespace MusicService.Core.Interfaces.Identity
{
    public interface IUser
    {
        Task<ResponseDTO> GetUserByEmail (string email);
        Task<ResponseDTO> UpdateUserInformation(UpdateUserInfo update);
        Task<ResponseDTO> DeleteUser(string email);
        Task<ResponseDTO> ChangeUserPassword(ChangePassword changePassword);
    }
}
