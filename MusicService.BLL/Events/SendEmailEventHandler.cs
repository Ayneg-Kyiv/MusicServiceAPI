using Microsoft.Extensions.Logging;
using MediatR;

namespace MusicService.BLL.Events
{
    public class SendEmailEventHandler(ILogger<SendEmailEventHandler> logger)
        : INotificationHandler<UserCreatedEvent>
    {
        public async Task Handle(UserCreatedEvent notification,
            CancellationToken cancellationToken)
        {
            logger.LogDebug(notification.message, cancellationToken);
        }
    }
}
