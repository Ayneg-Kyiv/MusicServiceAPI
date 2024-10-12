using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.GenreDTOs;


namespace MusicService.BLL.Commands
{
    public record UpdateGenreCommand(Guid Id, UpdateGenreDTO Genre) : IRequest<ResponseDTO>;
         
    public class UpdateGenreCommandHandler(IGenre genresRepository, IPublisher mediatR)
        : IRequestHandler<UpdateGenreCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(UpdateGenreCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await genresRepository.UpdateGenreAsync(request.Id, request.Genre);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
