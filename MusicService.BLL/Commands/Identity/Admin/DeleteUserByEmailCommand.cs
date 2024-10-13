using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Commands.Identity.Admin
{
    public record DeleteUserByEmailCommand(string Email): IRequest<ResponseDTO>;

    public class DeleteUserByEmailCommandHandler(IAdmin adminsRepository, IPublisher mediatR)
        : IRequestHandler<DeleteUserByEmailCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(DeleteUserByEmailCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await adminsRepository.DeleteUserByEmail(request.Email);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }

}
