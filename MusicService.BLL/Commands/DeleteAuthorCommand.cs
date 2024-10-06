using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Commands
{
    public record DeleteAuthorCommand(Guid Id) : IRequest<ResponseDTO>;

    public class DeleteAuthorCommandHandler(IAuthor authorsRepository, IPublisher mediatR)
        : IRequestHandler<DeleteAuthorCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(DeleteAuthorCommand request,
                                               CancellationToken cancellationToken)
        {
            var result = await authorsRepository.DeleteAuthorAsync(request.Id);


            await mediatR.Publish(new UserCreatedEvent(result?.Message ?? ""));
            return result;
        }
    }
}
