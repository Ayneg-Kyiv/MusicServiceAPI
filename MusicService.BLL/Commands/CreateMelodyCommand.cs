using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.MelodyDTOs;

namespace MusicService.BLL.Commands
{
    public record CreateMelodyCommand(CreateMelodyDTO Melody) : IRequest<ResponseDTO>;

    public class CreateMelodyCommandHandler(IMelody melodiesRepository, IPublisher mediatR)
        : IRequestHandler<CreateMelodyCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(CreateMelodyCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await melodiesRepository.CreateMelodyAsync(request.Melody);

            await mediatR.Publish(new UserCreatedEvent(response?.Message ?? ""));
            
            return response;
        }
    }
}
