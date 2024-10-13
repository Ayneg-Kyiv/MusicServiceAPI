using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.IdentityDTOs;
using MusicService.Core.Models.Identity;

namespace MusicService.DAL.Repository.Identity
{
    public class AdminRepository( UserManager<ApplicationUser> _userManager,
                                  RoleManager<IdentityRole> _roleManager ) : IAdmin
    {
        private ResponseDTO Response { get; set; } = new();

        public async Task<ResponseDTO> ChangeUsersRole(ChangeRole changeRole)
        {
            var user = await _userManager.FindByEmailAsync(changeRole.UserEmail ?? "");

            if (user == null)
            {
                Response.Message = $"User {changeRole.UserEmail} not found";
                Response.IsSuccess = false;

                return Response;
            }

            if (!await _roleManager.RoleExistsAsync(changeRole.NewRole ?? ""))
            {
                Response.Message = $"Role {changeRole.NewRole} does not exist";
                Response.IsSuccess = false;

                return Response;
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, currentRoles);

            if (!result.Succeeded)
            {
                Response.Message = "Failed to remove current roles from User";
                Response.IsSuccess = false;

                return Response;
            }

            var addResult = await _userManager.AddToRoleAsync(user, changeRole.NewRole ?? "");

            if (!addResult.Succeeded)
            {
                Response.Message = "Error occured during role change";
                Response.IsSuccess = false;

                return Response;
            }

            Response.Message = "Role successfully changed";

            return Response;
        }

        public async Task<ResponseDTO> CreateRole(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
            {
                Response.Message = "Role already exists";
                Response.IsSuccess = false;

                return Response;
            }

            var result = await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = roleName
            });

            if (!result.Succeeded)
            {
                Response.Message = "Error occured during creating a role";
                Response.IsSuccess = false;

                return Response;
            }

            Response.Message = "Role has been successfully created";

            return Response;
        }

        public async Task<ResponseDTO> CreateUser(Register register)
        {
            if (!IsValidEmail(register.Email ?? ""))
            {
                Response.Message = "Invalid email format";
                Response.IsSuccess = false;
                
                return Response;
            }

            var existingUser = await _userManager.FindByEmailAsync(register.Email ?? "");

            if (existingUser != null)
            {
                Response.Message = "Email is already claimed";
                Response.IsSuccess = false;

                return Response;
            }

            var user = new ApplicationUser()
            {
                UserName = register.Email,
                Email = register.Email
            };

            var account = await _userManager.CreateAsync(user, register.Password ?? "");

            if (!account.Succeeded)
            {
                Response.Message = "Error occured during create of account";
                Response.IsSuccess = false;

                return Response;
            }

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("User"));

                if (!roleResult.Succeeded)
                {
                    await _userManager.CreateAsync(user);

                    Response.Message = "Failed to create \"User\" role";
                    Response.IsSuccess = false;

                    return Response;
                }
            }

            await _userManager.AddToRoleAsync(user, "User");

            Response.Message = "User was successfully created";

            return Response;
        }

        public async Task<ResponseDTO> DeleteRoleById(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                Response.Message = "Role does not exists";
                Response.IsSuccess = false;

                return Response;
            }

            if (role.Name == "Admin")
            {
                Response.Message = "Role cannot be deleted";
                Response.IsSuccess = false;

                return Response;
            }

            var result = await _roleManager.DeleteAsync(role!);

            if (!result.Succeeded)
            {
                Response.Message = "Error occured during delete";
                Response.IsSuccess = false;

                return Response;
            }

            Response.Message = "Role has been successfully deleted";

            return Response;
        }

        public async Task<ResponseDTO> DeleteUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                Response.Message = "Target email is empty";
                Response.IsSuccess = false;

                return Response;
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                Response.Message = "There is no user with target email";
                Response.IsSuccess = false;

                return Response;
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                Response.Message = "Error occured during remove of user";
                Response.IsSuccess = false;

                return Response;
            }

            Response.Message = "User has been successfully deleted";

            return Response;
        }

        public async Task<ResponseDTO> GetRoles()
        {
            var roles = await _roleManager.Roles.Select(r => new GetRoleDTO
            {
                Id = r.Id,
                Name = r.Name ?? ""
            }).ToListAsync();

            Response.Result = roles;

            return Response;
        }

        public async Task<ResponseDTO> GetUsers()
        {
            var users = await _userManager.Users.Select(u => new GetUserDTO
            {
                Id = u.Id,
                Email = u.Email ?? "",
                PhoneNumber = u.PhoneNumber ?? ""
            }).ToListAsync();

            Response.Result = users;

            return Response;
        }

        public async Task<ResponseDTO> UpdateAdminInfo(UpdateUserInfo update)
        {
            var admin = await _userManager.FindByEmailAsync(update.Email ?? "");

            if (admin == null)
            {
                Response.Message = $"Admin {update.Email} not found";
                Response.IsSuccess = false;

                return Response;
            }

            admin.Email = update.Email;
            admin.UserName = update.Email;
            admin.PhoneNumber = update.PhoneNumber;

            var result = await _userManager.UpdateAsync(admin);
            if (!result.Succeeded)
            {
                Response.Message = "Error occured during information change";
                Response.IsSuccess = false;

                return Response;
            }

            Response.Message = $"Information for admin {update.Email} changed";

            return Response;
        }

        public async Task<ResponseDTO> UpdateAdminPassword(ChangePassword changePassword)
        {
            var admin = await _userManager.FindByEmailAsync(changePassword.Email ?? "");

            if (admin == null)
            {
                Response.Message = $"Admin {changePassword.Email} not found";
                Response.IsSuccess = false;

                return Response;
            }

            var result = await _userManager.ChangePasswordAsync(admin, 
                changePassword.CurrentPassword ?? "", changePassword.NewPassword ?? "");

            if (!result.Succeeded)
            {
                Response.Message = "Error occured during information change";
                Response.IsSuccess = false;

                return Response;
            }

            Response.Message = "Password successfully changed";

            return Response;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return (address.Address == email);
            }
            catch
            {
                return false;
            }
        }
    }
}
