using MediatR;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;

namespace MusicService.BLL.Queries
{
    public record GetAllAuthorsQuery() : IRequest<ResponseDTO>;

    public class GetAllAuthorsQueryHandler(IAuthor authorsRepository)
        : IRequestHandler<GetAllAuthorsQuery, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(GetAllAuthorsQuery request,
            CancellationToken cancellationToken)
        {
            return await authorsRepository.GetAllAuthorsAsync();
        }
    }
}
