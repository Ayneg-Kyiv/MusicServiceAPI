using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicService.BLL.Commands;
using MusicService.BLL.Queries;
using MusicService.Core.Models.DTOs.AuthorDTOs;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController(ISender sender) : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Policy = "RoleAuthor")]
        public async Task<IActionResult> CreateAuthorAsync([FromForm] CreateAuthorDTO author)
        {
            var result = await sender.Send(new CreateAuthorCommand(author));

            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Policy = "RoleAuthor, RoleAdmin")]
        public async Task<IActionResult> DeleteAuthorAsync([FromHeader] Guid id)
        {
            var result = await sender.Send(new DeleteAuthorCommand(id));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthorsAsync()
        {
            var result = await sender.Send(new GetAllAuthorsQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorByIdAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new GetAuthorByIdQuery(id));

            return Ok(result);
        }

        [HttpPut]
        [Authorize(Policy = "RoleAuthor")]
        public async Task <IActionResult> UpdateAuthorAsync([FromHeader] Guid id, 
                                                            [FromForm] UpdateAuthorDTO author)
        {
            var result = await sender.Send(new UpdateAuthorCommand(id, author));

            return Ok(result);
        }
    }
}
