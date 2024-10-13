using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Commands.Identity.Admin
{
    public record CreateRoleCommand (string RoleName): IRequest<ResponseDTO>;

    public class CreateRoleCommandHandler(IAdmin adminsRepository, IPublisher mediatR)
        : IRequestHandler<CreateRoleCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(CreateRoleCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await adminsRepository.CreateRole(request.RoleName);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
