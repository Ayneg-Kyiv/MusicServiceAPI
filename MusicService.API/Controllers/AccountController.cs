using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicService.BLL.Commands.Identity.Account;
using MusicService.Core.Models.DTOs.IdentityDTOs;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(ISender _sender) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            var result = await _sender.Send(new RegisterCommand(register));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var result = await _sender.Send(new LoginCommand(login));

            if(!result.IsSuccess)
                return Unauthorized(result);

            return Ok(result);
        }

    }
}
