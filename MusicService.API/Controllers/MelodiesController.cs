using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicService.BLL.Commands;
using MusicService.BLL.Queries;
using MusicService.Core.Models.DTOs.MelodyDTOs;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MelodiesController(ISender sender) : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Policy = "RoleAuthor")]
        public async Task<IActionResult> CreateMelodyAsync([FromForm] CreateMelodyDTO melody)
        {
            var result = await sender.Send(new CreateMelodyCommand(melody));

            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Policy = "RoleAuthor")]
        public async Task<IActionResult> DeleteMelodyAsync([FromHeader] Guid id)
        {
            var result = await sender.Send(new DeleteMelodyCommand(id));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMelodyStreamAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new GetMelodyStreamQuery(id));

            if (result == null)
                return NotFound();

            return File(result, "audio/mp3", true);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllMelodiesAsync()
        {
            var result = await sender.Send(new GetAllMelodiesQuery());

            return Ok(result);
        }

        [HttpGet("Single/{id}")]
        public async Task<IActionResult> GetMelodyByIdAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new GetMelodyByIdQuery(id));

            return Ok(result);
        }

        [HttpPut]
        [Authorize(Policy = "RoleAuthor")]
        public async Task<IActionResult> UpdateMelodyAsync([FromHeader] Guid id, [FromForm] UpdateMelodyDTO melody)
        {
            var result = await sender.Send(new UpdateMelodyCommand(id, melody));

            return Ok(result);
        }
    }
}
