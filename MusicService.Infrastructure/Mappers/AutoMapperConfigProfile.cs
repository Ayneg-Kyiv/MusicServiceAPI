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
            CreateMap<Author, GetUnconnectedAuthorDTO>();
            CreateMap<Author, GetAuthorDTO>()
                .ForMember(dest => dest.Melodies,
                options => options.MapFrom(src => src.Melodies));

            CreateMap<CreateGenreDTO, Genre>();
            CreateMap<UpdateGenreDTO, Genre>();
            CreateMap<Genre, GetUnconnectedGenreDTO>();
            CreateMap<Genre, GetGenreDTO>();

            CreateMap<CreateAlbumDTO, Album>();
            CreateMap<UpdateAlbumDTO, Album>();
            CreateMap<Album, GetUnconnectedAlbumDTO>();
            CreateMap<Album, GetAlbumDTO>()
                .ForMember(dest => dest.Author,
                options => options.MapFrom(src => src.Author));

            CreateMap<CreateMelodyDTO, Melody>();
            CreateMap<UpdateMelodyDTO, Melody>();
            CreateMap<Melody, GetUnconnectedMelodyDTO>();
            CreateMap<Melody, GetMelodyDTO>()
                .ForMember(dest => dest.Author,
                options => options.MapFrom(src => src.Author))
                .ForMember(dest => dest.ImageUrl,
                options => options.MapFrom(src => $"https://{TunnelUrlData.Url}/Files/Melodies/Pictures/" + src.ImageFileName));

            CreateMap<ConnectFromToDTO, AlbumMelody>()
                .ForMember(dest=> dest.MelodyId, 
                options => options.MapFrom(src => src.FromId))
                .ForMember(dest=> dest.AlbumId, 
                options => options.MapFrom(src => src.ToId))
                .ReverseMap();

            CreateMap<ConnectFromToDTO, ApplicationUserMelody>()
                .ForMember(dest => dest.MelodyId,
                options => options.MapFrom(src => src.FromId))
                .ForMember(dest => dest.ApplicationUserId,
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
        }
    }
}
