using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicService.BLL.Commands;
using MusicService.BLL.Queries;
using MusicService.Core.Models.DTOs.GenreDTOs;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController(ISender sender) : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Policy = "RoleAdmin")]
        public async Task<IActionResult> CreateGenreAsync([FromForm] CreateGenreDTO genre)
        {
            var result = await sender.Send(new CreateGenreCommand(genre));

            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Policy = "RoleAdmin")]
        public async Task<IActionResult> DeleteGenreAsync([FromHeader] Guid id)
        {
            var result = await sender.Send(new DeleteGenreCommand(id));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenreAsync()
        {
            var result = await sender.Send(new GetAllGenresQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenresByIdAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new GetGenreByIdQuery(id));

            return Ok(result);
        }

        [HttpPut]
        [Authorize(Policy = "RoleAdmin")]
        public async Task<IActionResult> UpdateGenresAsync([FromHeader] Guid id,
                                                            [FromForm] UpdateGenreDTO genre)
        {
            var result = await sender.Send(new UpdateGenreCommand(id, genre));

            return Ok(result);
        }
    }
}
