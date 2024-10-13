using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicService.BLL.Commands.Identity.User;
using MusicService.BLL.Queries.Identity.User;
using MusicService.Core.Models.DTOs.IdentityDTOs;

namespace MusicService.API.Controllers
{
    [Authorize(Policy = "RoleUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(ISender sender) : ControllerBase
    {
        [HttpPut(" ChangeUserPassword")]
        public async Task<IActionResult> ChangeUserPassword([FromBody] ChangePassword changePassword)
        {
            var result = await sender.Send(new ChangedUserPasswordCommand(changePassword));
            return Ok(result);
        }

        [HttpGet("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail([FromBody] string email)
        {
            var result = await sender.Send(new GetUsersByEmailQuery(email));
            return Ok(result);  

        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] string email)
        {
              var result = await sender.Send(new DeleteUserCommand(email));

             return Ok(result);
        }

        [HttpPut("UpdateUserInformation")]
        public async Task<IActionResult> UpdateUserInformation([FromBody] UpdateUserInfo update)
        {
          var result  = await sender.Send(new UpdateUserInfromationCommand(update));
            
          return Ok(result);
        }

    }
}
