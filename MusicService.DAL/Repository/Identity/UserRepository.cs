using Microsoft.AspNetCore.Identity;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.IdentityDTOs;
using MusicService.Core.Models.Identity;

namespace MusicService.DAL.Repository.Identity
{
    public class UserRepository(UserManager<ApplicationUser> _userManager) : IUser
    {
        private ResponseDTO Response { get; set; } = new ResponseDTO();
        public async Task<ResponseDTO> ChangeUserPassword(ChangePassword changePassword)
        {
            var user = await _userManager.FindByEmailAsync(changePassword.Email ?? "");

            if (user == null)
            {
                Response.Message = "Email not found";
                Response.IsSuccess = false;
                return Response;
            }

            var result = await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword ?? "", changePassword.NewPassword ?? "");

            if (!result.Succeeded)
            {
                Response.Message = "Error during change password";
                Response.IsSuccess = false;
                return Response;
            }
            Response.Message = "Change password succes";
            return Response;
        }

        public async Task<ResponseDTO> DeleteUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                Response.Message = "Email not found";
                Response.IsSuccess = false;
                return Response;
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                Response.Message = "Error during change password";
                Response.IsSuccess = false;
                return Response;
            }
            Response.Message = "Delete user succes";
            return Response;
        }

        public async Task<ResponseDTO> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                Response.Message = "Email not found";
                Response.IsSuccess = false;
                return Response;
            }
            Response.Result = user;
            Response.Message = "User found succes";
            return Response;


        }

        public async Task<ResponseDTO> UpdateUserInformation(UpdateUserInfo update)
        {
            var user = await _userManager.FindByEmailAsync(update.Email ?? "");

            if (user == null)
            {
                Response.Message = "Email not found";
                Response.IsSuccess = false;
                return Response;
            }

            user.Email = update.Email;
            user.UserName = update.Email;
            user.PhoneNumber = update.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                Response.Message = "Error during change password";
                Response.IsSuccess = false;
                return Response;
            }
            Response.Message = "Delete user succes";
            return Response;

        }
    }

}