using MediatR;
using MusicService.BLL.Events;
using MusicService.Core.Interfaces;
using MusicService.Core.Models.DTOs;
using MusicService.Core.Models.DTOs.MelodyDTOs;

namespace MusicService.BLL.Commands
{
    public record UpdateMelodyCommand(Guid Id, UpdateMelodyDTO Melody) : IRequest<ResponseDTO>;

    public class UpdateMelodyCommandHandler(IMelody melodiesRepository, IPublisher mediatR)
        : IRequestHandler<UpdateMelodyCommand, ResponseDTO>
    {
        public async Task<ResponseDTO> Handle(UpdateMelodyCommand request,
                                               CancellationToken cancellationToken)
        {
            var response = await melodiesRepository.UpdateMelodyAsync(request.Id, request.Melody);

            await mediatR.Publish(new UserCreatedEvent(response.IsSuccess.ToString() ?? ""));

            return response;
        }
    }
}
