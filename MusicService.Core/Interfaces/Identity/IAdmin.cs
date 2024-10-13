using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.IdentityDTOs;

namespace MusicService.Core.Interfaces.Identity
{
    public interface IAdmin
    {
        Task<ResponseDTO> GetUsers();
        Task<ResponseDTO> CreateUser(Register register);
        Task<ResponseDTO> DeleteUserByEmail(string email);
        Task<ResponseDTO> GetRoles();
        Task<ResponseDTO> CreateRole(string roleName);
        Task<ResponseDTO> DeleteRoleById(string roleId);
        Task<ResponseDTO> ChangeUsersRole( ChangeRole changeRole);
        Task<ResponseDTO> UpdateAdminInfo( UpdateUserInfo update);
        Task<ResponseDTO> UpdateAdminPassword( ChangePassword changePassword);
    }
}
