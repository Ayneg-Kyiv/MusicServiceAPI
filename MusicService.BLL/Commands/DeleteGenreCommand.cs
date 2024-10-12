using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Commands
{
    public record DeleteGenreCommand(Guid Id) : IRequest<ResponseDTO>;

    public class DeleteGenreCommandHandler(IGenre genresRepository, IPublisher mediatR)
        : IRequestHandler<DeleteGenreCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(DeleteGenreCommand request,
                                              CancellationToken cancellationToken)
        {
            var response = await genresRepository.DeleteGenreAsync(request.Id);

            await mediatR.Publish(new UserCreatedEvent(response.Message ?? ""));

            return response;
        }
    }
}
