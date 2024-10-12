using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.GenreDTOs;

namespace MusicService.BLL.Commands
{
    public record CreateGenreCommand(CreateGenreDTO Genre) : IRequest<ResponseDTO>;
    
    public class CreateGenreCommandHandler(IGenre genresRepository,IPublisher mediatR)
        : IRequestHandler<CreateGenreCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(CreateGenreCommand request,
                                             CancellationToken cancellationToken)
        {
            var response = await genresRepository.CreateGenreAsync(request.Genre);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
    
}
