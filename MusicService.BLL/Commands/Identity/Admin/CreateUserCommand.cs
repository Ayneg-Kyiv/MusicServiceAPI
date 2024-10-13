using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.IdentityDTOs;

namespace MusicService.BLL.Commands.Identity.Admin
{
    public record CreateUserCommand (Register Register): IRequest<ResponseDTO>;

    public class CreateUserCommandHandler(IAdmin adminsRepository, IPublisher mediatR)
        : IRequestHandler<CreateUserCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(CreateUserCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await adminsRepository.CreateUser(request.Register);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
