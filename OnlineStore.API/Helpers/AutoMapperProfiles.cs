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
            /*CreateMap<Category, CategoryForDetailedDto>().ForMember(dest => dest.Products, opt => {
                opt.MapFrom(src => src.Products);
            });*/
        }
    }
}