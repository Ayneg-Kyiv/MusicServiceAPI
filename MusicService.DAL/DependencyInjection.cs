using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MusicService.Core.Interfaces;
using MusicService.Core.Interfaces.Connective;
using MusicService.Core.Options;
using MusicService.DAL.Data;
using MusicService.DAL.Repository;
using MusicService.DAL.Repository.Connective;

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

            services.AddScoped<IAuthor, AuthorsRepository>();
            services.AddScoped<IMelody, MelodiesRepository>();
            services.AddScoped<IGenre, GenreRepository>();
            services.AddScoped<IAlbum, AlbumRepository>();

            services.AddScoped<IAlbumMelody, AlbumMelodyRepository>();
            services.AddScoped<IGenreAlbum, GenreAlbumRepository>();
            services.AddScoped<IGenreAuthor, GenreAuthorRepository>();
            services.AddScoped<IGenreMelody, GenreMelodyRepository>();

            return services;
        }
    }
}
