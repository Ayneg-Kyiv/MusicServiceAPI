using MusicService.Core.Models.DTOs.IdentityDTOs;

namespace MusicService.Core.Interfaces.Identity
{
    public interface IAdmin
    {
        Task<IEnumerable<GetUserDTO>> GetUsers();
        Task<bool> CreateUser(Register register);
        Task<bool> DeleteUserByEmail(string email);
        Task<IEnumerable<GetRoleDTO>> GetRoles();
        Task<bool> CreateRole(string roleName);
        Task<bool> DeleteRoleById(string roleName);
        Task<bool> ChangeUsersRole(ChangeRole changeRole);
        Task<bool> UpdateAdminInfo( UpdateUserInfo update);
        Task<bool> UpdateAdminPassword( ChangePassword changePassword);
    }
}
