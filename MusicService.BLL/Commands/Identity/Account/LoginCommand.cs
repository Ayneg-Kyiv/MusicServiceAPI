using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.IdentityDTOs;

namespace MusicService.BLL.Commands.Identity.Account
{
    public record LoginCommand(Login Login): IRequest<ResponseDTO>;

    public class LoginCommandHandler(IAccount accountsRepository, IPublisher mediatR)
        : IRequestHandler<LoginCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(LoginCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await accountsRepository.Login(request.Login);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
