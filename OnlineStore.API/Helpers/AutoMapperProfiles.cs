using AutoMapper;
using OnlineStore.API.Dtos;
using OnlineStore.API.Models;

namespace OnlineStore.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CategoryForListDto>()
            .ForMember(dest => dest.Url, opt => {
                opt.MapFrom(src => src.CategorySign.Url);
            });
            CreateMap<CategorySign, CategorySignForCategoryDto>();
        }
    }
}