using AutoMapper;
using ServiceWeb.ProductAPI.DTO;
using ServiceWeb.ProductAPI.Model.Entities;

namespace ServiceWeb.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductDTO, Product>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
