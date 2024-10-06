using MusicService.Identity;
using MusicService.Core;
using MusicService.DAL;
using MusicService.BLL;
using Microsoft.Extensions.FileProviders;
using MusicService.Core.Models.Constants;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

TunnelUrlData.Url = builder.Configuration["TunnelUrl"] ?? "";

builder.Services.AddCoreDI(builder.Configuration);
builder.Services.AddInfrastructureDI();
builder.Services.AddDalDI();
builder.Services.AddIdentityDI(builder.Configuration);
builder.Services.AddBllDI();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(option =>
{
    option.AllowAnyOrigin();
    option.AllowAnyHeader();
    option.AllowAnyMethod();
});

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine
                    (app.Environment.ContentRootPath + "/Files")),
    RequestPath = "/Files"
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
