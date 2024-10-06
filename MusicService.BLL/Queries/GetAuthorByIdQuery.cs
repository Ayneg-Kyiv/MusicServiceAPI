using MediatR;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Queries
{
    public record GetAuthorByIdQuery(Guid Id) : IRequest<ResponseDTO>;

    public class GetAuthorByIdQueryHandler(IAuthor authorsRepository)
        : IRequestHandler<GetAuthorByIdQuery, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(GetAuthorByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await authorsRepository.GetAuthorByIdAsync(request.Id);
        }
    }
}
