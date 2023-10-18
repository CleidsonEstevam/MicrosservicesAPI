using AutoMapper;
using ServiceWeb.CartAPI.DTO;
using ServiceWeb.CartAPI.DTO.Messages;
using ServiceWeb.CartAPI.Model.Entities;
using ServiceWeb.CartAPI.ViewModels;

namespace ServiceWeb.CartAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<CartDTO, Cart>().ReverseMap();
                config.CreateMap<CartHeaderDTO, CartHeader>().ReverseMap();
                config.CreateMap<CartItemDTO, CartItem>().ReverseMap();

                config.CreateMap<CartViewModel, CartDTO>().ReverseMap();
                config.CreateMap<CartHeaderViewModel, CartHeaderDTO>().ReverseMap();
                config.CreateMap<CartItemViewModel, CartItemDTO>().ReverseMap();

                config.CreateMap<CheckoutHeaderViewModel, CheckoutHeaderDTO>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
