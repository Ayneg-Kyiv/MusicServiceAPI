using MediatR;

namespace MusicService.BLL.Events
{
    public record UserCreatedEvent(string message): INotification;
}
