using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.IdentityDTOs;

namespace MusicService.BLL.Commands.Identity.Admin
{
    public record ChangeUsersRoleCommand(ChangeRole ChangeRole) : IRequest<ResponseDTO>;

    public class ChangeUsersRoleCommandHandler (IAdmin adminsRepository, IPublisher mediatR)
        : IRequestHandler<ChangeUsersRoleCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle (ChangeUsersRoleCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await adminsRepository.ChangeUsersRole(request.ChangeRole);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
