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
            CreateMap<ColorForCreationDto, Color>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<Balance, BalanceForListDto>()
            .ForMember(dest => dest.ProductName, opt => {
                opt.MapFrom(src => src.Product.ProductName);
            });
            CreateMap<Receipt, ReceiptForListDto>()
            .ForMember(dest => dest.ProductName, opt => {
                opt.MapFrom(src => src.Product.ProductName);
            })
            .ForMember(dest => dest.ProductCost, opt => {
                opt.MapFrom(src => src.Product.Cost);
            })
            .ForMember(dest => dest.ProductCost, opt => {
                opt.MapFrom(src => src.Product.Cost);
            })
            .ForMember(dest => dest.DateAdded, opt => {
                opt.MapFrom(src => src.DateAdded.ToShortDateString());
            });
            CreateMap<ReceiptForCreationDto, Receipt>();
            CreateMap<ReceiptForCreationDto, BalanceForCreationDto>();
            CreateMap<Order, OrderToListDto>()
            .ForMember(dest => dest.ClientPhone, opt => {
                opt.MapFrom(src => src.Client.PhoneNumber);
            })
            .ForMember(dest => dest.Status, opt => {
                opt.MapFrom(src => src.Status.Name);
            })
            .ForMember(dest => dest.DateTimeOrder, opt => {
                opt.MapFrom(src => src.DateTimeOrder.ToLongDateString());
            });
            
        }
    }
}