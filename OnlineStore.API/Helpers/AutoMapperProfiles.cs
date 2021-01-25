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
            .ForMember(dest => dest.Status, opt => {
                opt.MapFrom(src => src.Status.Name);
            })
            .ForMember(dest => dest.ClientPhone, opt => {
                opt.MapFrom(src => src.Client.PhoneNumber);
            });
            CreateMap<Order, OrderForDetailDto>()
            .ForMember(dest => dest.ClientId, opt => {
                opt.MapFrom(src => src.ClientId);
            })
            .ForMember(dest => dest.ClientName, opt => {
                opt.MapFrom(src => src.Client.ClientName);
            })
            .ForMember(dest => dest.ClientSurname, opt => {
                opt.MapFrom(src => src.Client.ClientSurname);
            })
            .ForMember(dest => dest.Patronymic, opt => {
                opt.MapFrom(src => src.Client.Patronymic);
            })
            .ForMember(dest => dest.PhoneNumber, opt => {
                opt.MapFrom(src => src.Client.PhoneNumber);
            })
            .ForMember(dest => dest.Place, opt => {
                opt.MapFrom(src => src.Client.Place);
            })
            .ForMember(dest => dest.PlaceNumber, opt => {
                opt.MapFrom(src => src.Client.PlaceNumber);
            })
            .ForMember(dest => dest.PaymentMethod, opt => {
                opt.MapFrom(src => src.Client.PaymentMethod);
            })
            .ForMember(dest => dest.DeliveryMethod, opt => {
                opt.MapFrom(src => src.Client.DeliveryMethod);
            })
            .ForMember(dest => dest.Email, opt => {
                opt.MapFrom(src => src.Client.Email);
            })
            .ForMember(dest => dest.DateTimeOrder, opt => {
                opt.MapFrom(src => src.DateTimeOrder.ToLongDateString());
            })
            .ForMember(dest => dest.StatusName, opt => {
                opt.MapFrom(src => src.Status.Name);
            });
            CreateMap<StringsOrder, StingsOrderForListDto>()
            .ForMember(dest => dest.ProductName, opt => {
                opt.MapFrom(src =>src.Product.ProductName);
            })
            .ForMember(dest => dest.Quantity, opt => {
                opt.MapFrom(src => src.Quantity);
            })
            .ForMember(dest => dest.Amount, opt => {
                opt.MapFrom(src => src.Quantity * src.Product.Cost);
            });
            
        }
    }
}