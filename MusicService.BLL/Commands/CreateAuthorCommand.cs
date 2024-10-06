using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.AuthorDTOs;

namespace MusicService.BLL.Commands
{
    public record CreateAuthorCommand(CreateAuthorDTO Author) : IRequest<ResponseDTO>;

    public class CreateAuthorCommandHandler(IAuthor authorsRepository, IPublisher mediatR)
        : IRequestHandler<CreateAuthorCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(CreateAuthorCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await authorsRepository.CreateAuthorAsync(request.Author);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
