using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.IdentityDTOs;
using MusicService.Core.Models.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicService.DAL.Repository.Identity
{
    public class AccountRepository(UserManager<ApplicationUser> _userManager,
                                   RoleManager<IdentityRole> _roleManager,
                                   IConfiguration _configuration) : IAccount
    {
        private ResponseDTO Response { get; set; } = new();

        public async Task<ResponseDTO> Login(Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email ?? "");

            if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password ?? ""))
            {
                Response.Message = "Unauthorized login";
                Response.IsSuccess = false;

                return Response;
            }

            var authorizeClaims = new List<Claim>
                {
                    new (JwtRegisteredClaimNames.Sub, user.UserName ?? ""),
                    new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new (JwtRegisteredClaimNames.Email, user.Email ?? ""),
                    new ("userId", user.Id)
                };

            var UserRoles = await _userManager.GetRolesAsync(user);

            authorizeClaims.AddRange(UserRoles.Select(role =>
                new Claim(ClaimTypes.Role, role)));

            var Token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(
                    double.Parse(_configuration["Jwt:ExpiryMinutes"] ?? "")),
                claims: authorizeClaims,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)),
                    SecurityAlgorithms.HmacSha256));


            var handledToken =  new JwtSecurityTokenHandler().WriteToken(Token);
            var roles = await _userManager.GetRolesAsync(user);

            TokenReturn tokenReturn = new() { Token = handledToken, Roles = roles };

            Response.Result = tokenReturn;

            return Response;
        }

        public async Task<ResponseDTO> Register(Register register)
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
                Response.Message = "Email already claimed";
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
                Response.Message = "Error occured while account was created";
                Response.IsSuccess = false;

                return Response;
            }

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("User"));

                if (!roleResult.Succeeded)
                {
                    await _userManager.CreateAsync(user);

                    Response.Message = "User role creation failed";
                    Response.IsSuccess = false;

                    return Response;
                }
            }

            await _userManager.AddToRoleAsync(user, "User");
            
            if (!string.IsNullOrWhiteSpace(register.RoleName) && register.RoleName != "Admin")
            {
                if(!await _roleManager.RoleExistsAsync(register.RoleName))
                {
                    Response.Message = "User created but target role is not exists";

                    return Response;
                } 
                await _userManager.AddToRoleAsync(user, register.RoleName);
            }

            Response.Message = "You been succesfully registered";

            return Response;
        }

        private bool IsValidEmail(string email)
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
