using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicService.BLL.Commands.Identity.User
{
    public record DeleteUserCommand(string email) : IRequest<ResponseDTO>;

    public class DeleteUserCommandHandler(IUser usersRepository, IPublisher mediatR)
        : IRequestHandler<DeleteUserCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(DeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            var response = await usersRepository.DeleteUser(request.email);
            
            await mediatR.Publish(new UserCreatedEvent(response.Message ?? ""));

            return response;
        }
    }
}
