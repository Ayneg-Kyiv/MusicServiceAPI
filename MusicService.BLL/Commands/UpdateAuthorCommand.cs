using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs.AuthorDTOs;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Commands
{
    public record UpdateAuthorCommand(Guid Id, UpdateAuthorDTO Author) : IRequest<ResponseDTO>;

    public class UpdateAuthorCommandHandler(IAuthor authorsRepository, IPublisher mediatR)
        : IRequestHandler<UpdateAuthorCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(UpdateAuthorCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await authorsRepository.UpdateAuthorAsync(request.Id,request.Author);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
