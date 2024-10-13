using MediatR;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;


namespace MusicService.BLL.Queries.Identity.User
{
    public record GetUsersByEmailQuery(string email) : IRequest<ResponseDTO>;


    public class GetUserByEmailQueryHandler(IUser usersRepository)
         : IRequestHandler<GetUsersByEmailQuery , ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(GetUsersByEmailQuery request,
            CancellationToken cancellationToken)
        {
            return await usersRepository.GetUserByEmail(request.email);
        }
    }
}
