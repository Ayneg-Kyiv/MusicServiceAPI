using MediatR;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Queries.Identity.Admin
{
    public record GetUsersQuery() : IRequest<ResponseDTO>;
    
    public class GetUsersQueryHandler(IAdmin adminsRepository)
        :IRequestHandler<GetUsersQuery, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(GetUsersQuery request,
            CancellationToken cancellationToken)
        {
            return await adminsRepository.GetUsers();
        }
    }
}
