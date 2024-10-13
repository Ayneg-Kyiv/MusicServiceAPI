using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.IdentityDTOs;
namespace MusicService.BLL.Commands.Identity.Account
{
    public record RegisterCommand(Register Register) : IRequest<ResponseDTO>;

    public class RegisterCommandHandler(IAccount accountsRepository, IPublisher mediatR)
        : IRequestHandler<RegisterCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(RegisterCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await accountsRepository.Register(request.Register);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}