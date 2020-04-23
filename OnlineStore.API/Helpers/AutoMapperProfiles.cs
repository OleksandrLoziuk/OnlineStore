using System.Linq;
using AutoMapper;
using OnlineStore.API.Dtos;
using OnlineStore.API.Models;

namespace OnlineStore.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductForListDto>()
            .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            });;
            CreateMap<Product, ProductForDetailedDto>()
            .ForMember(dest => dest.ColorName, opt => {
                opt.MapFrom(src => src.Color.ColorName);
            })
            .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            });
            CreateMap<Photo, PhotoForDetailedDto>();
        }
    }
}