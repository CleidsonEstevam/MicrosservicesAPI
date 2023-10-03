﻿using AutoMapper;
using ServiceWeb.CartAPI.DTO;
using ServiceWeb.CartAPI.Model.Entities;

namespace ServiceWeb.CartAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<CartDTO, Cart>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
