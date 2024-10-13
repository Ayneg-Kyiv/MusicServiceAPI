using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Commands.Identity.Admin
{
    public record DeleteRoleByIdCommand(string RoleId) : IRequest<ResponseDTO>;

    public class DeleteRoleByIdCommandHandle (IAdmin adminsRepository, IPublisher mediatR)
        : IRequestHandler<DeleteRoleByIdCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle (DeleteRoleByIdCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await adminsRepository.DeleteRoleById(request.RoleId);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
