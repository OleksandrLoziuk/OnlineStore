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
            CreateMap<Product, ProductForListDto>();
            CreateMap<Product, ProductForDetailedDto>()
            .ForMember(dest => dest.ColorName, opt => {
                opt.MapFrom(src => src.Color.ColorName);
            });
        }
    }
}