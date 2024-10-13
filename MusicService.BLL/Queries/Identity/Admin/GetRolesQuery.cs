using MediatR;
using MusicService.Core.Interfaces.Identity;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Queries.Identity.Admin
{
    public record GetRolesQuery() : IRequest<ResponseDTO>;
    
    public class GetRolesQueryHandler(IAdmin adminsRepository)
        :IRequestHandler<GetRolesQuery, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(GetRolesQuery request,
            CancellationToken cancellationToken)
        {
            return await adminsRepository.GetRoles();
        }
    }
}
