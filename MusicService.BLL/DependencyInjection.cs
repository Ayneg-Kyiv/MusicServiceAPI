using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;

namespace MusicService.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBllDI(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                config.NotificationPublisher = new TaskWhenAllPublisher();
            });

            return services;
        }
    }
}
