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
    public record UpdateUserInfromationCommand(UpdateUserInfo update) : IRequest<ResponseDTO>;

    public class UpdateUserInfromationHandler(IUser usersRepository, IPublisher mediatR)
        : IRequestHandler<UpdateUserInfromationCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(UpdateUserInfromationCommand request,
            CancellationToken cancellationToken)
        {
            var response = await usersRepository.UpdateUserInformation(request.update);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;    
        }

    }
}
