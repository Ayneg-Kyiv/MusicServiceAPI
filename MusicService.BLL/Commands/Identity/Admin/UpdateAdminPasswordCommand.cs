using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.IdentityDTOs;

namespace MusicService.BLL.Commands.Identity.Admin
{
    public record UpdateAdminPasswordCommand(ChangePassword ChangePassword) : IRequest<ResponseDTO>;

    public class UpdateAdminPasswordCommandHandle(IAdmin adminsRepository, IPublisher mediatR)
        : IRequestHandler<UpdateAdminPasswordCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(UpdateAdminPasswordCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await adminsRepository.UpdateAdminPassword(request.ChangePassword);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
