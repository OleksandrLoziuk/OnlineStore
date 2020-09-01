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
            });
            CreateMap<Product, ProductForDetailedDto>()
            .ForMember(dest => dest.ColorName, opt => {
                opt.MapFrom(src => src.Color.ColorName);
            })
            .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            });
            CreateMap<Category, CategoryForListDto>()
            .ForMember(dest => dest.photoUrl, opt => { 
                opt.MapFrom(src => src.photoCategory.Url); 
            });
            CreateMap<Category, CategoryToReturnDto>()
            .ForMember(dest => dest.photoUrl, opt => { 
                opt.MapFrom(src => src.photoCategory.Url); 
            });
            CreateMap<Photo, PhotoForDetailedDto>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoCategory, PhotoCategoryForReturnDto>();
            CreateMap<PhotoCategoryForCreationDto, PhotoCategory>();
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<PhotoForCreationDto, Photo>();
        }
    }
}