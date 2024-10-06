using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MusicService.Core.Options;
using MusicService.Infrastructure.Mappers;

namespace MusicService.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddAutoMapper(options => options.AddProfile<AutoMapperConfigProfile>());

            return services;
        }
    }
}
