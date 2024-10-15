using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicService.BLL.Commands;
using MusicService.BLL.Queries;
using MusicService.Core.Models.DTOs.AlbumsDTO;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController(ISender sender) : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Policy = "RoleAuthor")]
        public async Task<IActionResult> CreateAlbumAsync([FromForm] CreateAlbumDTO album)
        {
            var result = await sender.Send(new CreateAlbumCommand(album));

            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Policy = "RoleAuthor, RoleAdmin")]
        public async Task<IActionResult> DeleteAlbumAsync([FromHeader] Guid id)
        {
            var result = await sender.Send(new DeleteAlbumCommand(id));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlbumAsync()
        {
            var result = await sender.Send(new GetAllAlbumsQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumsByIdAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new GetAlbumByIdQuery(id));

            return Ok(result);
        }

        [HttpPut]
        [Authorize(Policy = "RoleAuthor")]
        public async Task<IActionResult> UpdateAlbumsAsync([FromHeader] Guid id,
                                                            [FromForm] UpdateAlbumDTO album)
        {
            var result = await sender.Send(new UpdateAlbumCommand(id, album));

            return Ok(result);
        }
    }
}
