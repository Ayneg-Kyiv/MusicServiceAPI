using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using MusicServiceMauiClient.Services;


namespace MusicServiceMauiClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
          
            builder.Services.AddScoped<IMusic, MusicService>();
            builder.Services.AddScoped<IAuthor, AuthorService>();
            builder.Services.AddScoped<IGenre, GenreService>();
            builder.Services.AddScoped<ILogin, LoginService>();
            builder.Services.AddScoped<IRegister, RegistrationService>();
            builder.Services.AddScoped<IAuthorization, AuthorizationService>();
          
            builder.Services.AddMauiBlazorWebView();

            #if DEBUG
    		    builder.Services.AddBlazorWebViewDeveloperTools();
    		    builder.Logging.AddDebug();
            #endif

            return builder.Build();
        }
    }
}
