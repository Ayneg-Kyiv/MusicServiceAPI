using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicService.BLL.Commands.Identity.Admin;
using MusicService.BLL.Queries.Identity.Admin;
using MusicService.Core.Models.DTOs.IdentityDTOs;

namespace MusicService.API.Controllers
{
    [Authorize(Policy = "RoleAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController (ISender _sender) : ControllerBase
    {
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _sender.Send(new GetUsersQuery());

            return Ok(result);
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _sender.Send(new GetRolesQuery());

            return Ok(result);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromForm] Register register)
        {
            var result = await _sender.Send(new CreateUserCommand(register));

            return Ok(result);
        }

        [HttpDelete("DeleteUser/{email}")]
        public async Task<IActionResult> DeleteUserByEmail([FromRoute]string email)
        {
            var result = await _sender.Send(new DeleteUserByEmailCommand(email));

            return Ok(result);
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromForm] string roleName)
        {
            var result = await _sender.Send(new CreateRoleCommand(roleName));

            return Ok(result);
        }

        [HttpDelete("DeleteRole/{roleId}")]
        public async Task<IActionResult> DeleteRoleById([FromRoute] string roleId)
        {
            var result = await _sender.Send(new DeleteRoleByIdCommand(roleId));

            return Ok(result);
        }

        [HttpPut("ChangeUsersRole")]
        public async Task<IActionResult> ChangeUsersRole([FromForm] ChangeRole changeRole)
        {
            var result = await _sender.Send(new ChangeUsersRoleCommand(changeRole));

            return Ok(result);
        }

        [HttpPut("UpdateAdminInfo")]
        public async Task<IActionResult> UpdateAdminInfo([FromForm] UpdateUserInfo update)
        {
            var result = await _sender.Send(new UpdateAdminInfoCommand(update));

            return Ok(result);
        }

        [HttpPut("UpdateAdminPassword")]
        public async Task<IActionResult> UpdateAdminPassword([FromForm] ChangePassword changePassword)
        {
            var result = await _sender.Send(new UpdateAdminPasswordCommand(changePassword));

            return Ok(result);
        }
    }
}
