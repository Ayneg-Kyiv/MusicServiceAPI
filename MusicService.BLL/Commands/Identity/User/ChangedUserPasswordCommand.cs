using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.IdentityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicService.BLL.Commands.Identity.User
{
    public record ChangedUserPasswordCommand(ChangePassword ChangedPassword) : IRequest<ResponseDTO>;


    public class ChangedUserPasswordCommandHandler(IUser usersRepository, IPublisher mediatR)
        : IRequestHandler<ChangedUserPasswordCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(ChangedUserPasswordCommand request,
            CancellationToken cancellationToken)
        {
            var response = await usersRepository.ChangeUserPassword(request.ChangedPassword);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));
            return response;
        }
    }
}
