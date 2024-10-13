using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.IdentityDTOs;

namespace MusicService.BLL.Commands.Identity.Admin
{
    public record UpdateAdminInfoCommand(UpdateUserInfo Update): IRequest<ResponseDTO>;

    public class UpdateAdminInfoCommandHandle(IAdmin adminsRepository, IPublisher mediatR)
        : IRequestHandler<UpdateAdminInfoCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(UpdateAdminInfoCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await adminsRepository.UpdateAdminInfo(request.Update);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
