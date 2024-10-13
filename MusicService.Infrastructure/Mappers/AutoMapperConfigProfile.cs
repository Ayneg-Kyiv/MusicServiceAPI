using AutoMapper;
using MusicService.Core.Models;
using MusicService.Core.Models.Connective;
using MusicService.Core.Models.Constants;
using MusicService.Core.Models.DTOs.AlbumsDTO;
using MusicService.Core.Models.DTOs.AuthorDTOs;
using MusicService.Core.Models.DTOs.ConnectiveDTOs;
using MusicService.Core.Models.DTOs.GenreDTOs;
using MusicService.Core.Models.DTOs.MelodyDTOs;

namespace MusicService.Infrastructure.Mappers
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<CreateAuthorDTO, Author>();
            CreateMap<UpdateAuthorDTO, Author>();
            CreateMap<Author, GetUnconnectedAuthorDTO>()
                .ForMember(dest => dest.ImageUrl,
                options => options.MapFrom(src => $"https://{TunnelUrlData.Url}/Files/Authors/" + src.ImageFileName));
            CreateMap<Author, GetAuthorDTO>()
                .ForMember(dest => dest.Melodies,
                options => options.MapFrom(src => src.Melodies))
                .ForMember(dest => dest.Albums,
                options => options.MapFrom(src => src.Albums))
                .ForMember(dest => dest.Genres,
                options => options.MapFrom(src => src.Genres))
                .ForMember(dest => dest.ImageUrl,
                options => options.MapFrom(src => $"https://{TunnelUrlData.Url}/Files/Authors/" + src.ImageFileName));

            CreateMap<CreateGenreDTO, Genre>();
            CreateMap<UpdateGenreDTO, Genre>();
            CreateMap<Genre, GetUnconnectedGenreDTO>();
            CreateMap<Genre, GetGenreDTO>()
                .ForMember(dest => dest.Authors,
                options => options.MapFrom(src => src.Authors))
                .ForMember(dest => dest.Melodies,
                options => options.MapFrom(src => src.Melodies))
                .ForMember(dest => dest.Albums,
                options => options.MapFrom(src => src.Albums));

            CreateMap<CreateAlbumDTO, Album>();
            CreateMap<UpdateAlbumDTO, Album>();
            CreateMap<Album, GetUnconnectedAlbumDTO>();
            CreateMap<Album, GetAlbumDTO>()
                .ForMember(dest => dest.Author,
                options => options.MapFrom(src => src.Author))
                .ForMember(dest => dest.Melodies,
                options => options.MapFrom(src => src.Melodies))
                .ForMember(dest => dest.Genres,
                options => options.MapFrom(src => src.Genres))
                .ForMember(dest => dest.ImageUrl,
                options => options.MapFrom(src => $"https://{TunnelUrlData.Url}/Files/Albums/" + src.ImageFileName));

            CreateMap<CreateMelodyDTO, Melody>();
            CreateMap<UpdateMelodyDTO, Melody>();
            CreateMap<Melody, GetUnconnectedMelodyDTO>()
                .ForMember(dest => dest.ImageUrl,
                options => options.MapFrom(src => $"https://{TunnelUrlData.Url}/Files/Melodies/Pictures/" + src.ImageFileName));
            CreateMap<Melody, GetMelodyDTO>()
                .ForMember(dest => dest.Author,
                options => options.MapFrom(src => src.Author))
                .ForMember(dest => dest.Albums,
                options => options.MapFrom(src => src.Albums))
                .ForMember(dest => dest.Genres,
                options => options.MapFrom(src => src.Genres))
                .ForMember(dest => dest.ImageUrl,
                options => options.MapFrom(src => $"https://{TunnelUrlData.Url}/Files/Melodies/Pictures/" + src.ImageFileName));

            CreateMap<ConnectFromToDTO, AlbumMelody>()
                .ForMember(dest=> dest.AlbumId, 
                options => options.MapFrom(src => src.FromId))
                .ForMember(dest=> dest.MelodyId, 
                options => options.MapFrom(src => src.ToId))
                .ReverseMap();

            CreateMap<ConnectFromToDTO, ApplicationUserMelody>()
                .ForMember(dest => dest.ApplicationUserId,
                options => options.MapFrom(src => src.FromId))
                .ForMember(dest => dest.MelodyId,
                options => options.MapFrom(src => src.ToId))
                .ReverseMap();

            CreateMap<ConnectFromToDTO, GenreAlbum>()
                .ForMember(dest => dest.GenreId,
                options => options.MapFrom(src => src.FromId))
                .ForMember(dest => dest.AlbumId,
                options => options.MapFrom(src => src.ToId))
                .ReverseMap();

            CreateMap<ConnectFromToDTO, GenreAuthor>()
                .ForMember(dest => dest.GenreId,
                options => options.MapFrom(src => src.FromId))
                .ForMember(dest => dest.AuthorId,
                options => options.MapFrom(src => src.ToId))
                .ReverseMap();

            CreateMap<ConnectFromToDTO, GenreMelody>()
                .ForMember(dest => dest.GenreId,
                options => options.MapFrom(src => src.FromId))
                .ForMember(dest => dest.MelodyId,
                options => options.MapFrom(src => src.ToId))
                .ReverseMap();

            CreateMap<AlbumMelody, GetConnectiveObject>();
        }
    }
}
