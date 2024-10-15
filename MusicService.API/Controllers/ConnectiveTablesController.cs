using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicService.BLL.Commands.Connective.AlbumMelody;
using MusicService.BLL.Commands.Connective.GenreAlbum;
using MusicService.BLL.Commands.Connective.GenreAuthor;
using MusicService.BLL.Commands.Connective.GenreMelody;
using MusicService.Core.Models.DTOs.ConnectiveDTOs;

namespace MusicService.API.Controllers
{
    [Authorize(Policy = "RoleAuthor")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectiveTablesController(ISender sender) : ControllerBase
    {
        [HttpPost("AlbumToMelody")]
        public async Task<IActionResult> CreateAlbumToMelodyConnectionAsync
            ([FromForm] ConnectFromToDTO connect)
        {
            var result = await sender.Send(new CreateAlbumMelodyConnectionCommand(connect));

            return Ok(result);
        }

        [HttpPost("GenreToAlbum")]
        public async Task<IActionResult> CreateGenreToAlbumAsync
            ([FromForm] ConnectFromToDTO connect)
        {
            var result = await sender.Send(new CreateGenreAlbumConnectionCommand(connect));

            return Ok(result);
        }

        [HttpPost("GenreToAuthor")]
        public async Task<IActionResult> CreateGenreToAuthorAsync
            ([FromForm] ConnectFromToDTO connect)
        {
            var result = await sender.Send(new CreateGenreAuthorConnectionCommand(connect));

            return Ok(result);
        }

        [HttpPost("GenreToMelody")]
        public async Task<IActionResult> CreateGenreToMelodyAsync
            ([FromForm] ConnectFromToDTO connect)
        {
            var result = await sender.Send(new CreateGenreMelodyConnectionCommand(connect));

            return Ok(result);
        }

        [HttpDelete("AlbumToMelody/{id}")]
        public async Task<IActionResult> DeleteAlbumToMelodyConnectionAsync
            ([FromRoute] Guid id)
        {
            var result = await sender.Send(new DeleteAlbumMelodyConnectionCommand(id));

            return Ok(result);
        }

        [HttpDelete("GenreToAlbum/{id}")]
        public async Task<IActionResult> DeleteGenreToAlbumConnectionAsync
            ([FromRoute] Guid id)
        {
            var result = await sender.Send(new DeleteGenreAlbumConnectionCommand(id));

            return Ok(result);
        }

        [HttpDelete("GenreToAuthor/{id}")]
        public async Task<IActionResult> DeleteGenreToAuthorConnectionAsync
            ([FromRoute] Guid id)
        {
            var result = await sender.Send(new DeleteGenreAuthorConnectionCommand(id));

            return Ok(result);
        }

        [HttpDelete("GenreToMelody/{id}")]
        public async Task<IActionResult> DeleteGenreToMelodyConnectionAsync
            ([FromRoute] Guid id)
        {
            var result = await sender.Send(new DeleteGenreMelodyConnectionCommand(id));

            return Ok(result);
        }
    }
}
