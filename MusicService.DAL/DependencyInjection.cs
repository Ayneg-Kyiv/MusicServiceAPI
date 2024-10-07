using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MusicService.Core.Interfaces;
using MusicService.Core.Options;
using MusicService.DAL.Data;
using MusicService.DAL.Repository;

namespace MusicService.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalDI(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService
                    <IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });

            services.AddScoped<IAuthor, AuthorsRepositories>();
            services.AddScoped<IMelody, MelodiesRepositories>();

            return services;
        }
    }
}
