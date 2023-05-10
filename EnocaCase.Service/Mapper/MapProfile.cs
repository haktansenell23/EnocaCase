using AutoMapper;
using EnocaCase.Core.Dtos;
using EnocaCase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Service.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Carriers, CarriersDto>().ReverseMap();

            CreateMap<CarrierConfigurationDto, CarrierConfiguration>().ReverseMap();

            CreateMap<Orders, OrderDto>().ReverseMap();

            CreateMap<Carriers, UpdateCarrierDto>().ReverseMap();

            CreateMap<OrderDeleteDto, OrderDto>().ReverseMap();

            CreateMap<OrderDto, OrderPlusCarrierInformation>().ReverseMap();

            CreateMap<UpdateCarrierDto, Carriers>().ReverseMap();

            CreateMap<CarrierConfiguration, UpdateCarrierConfigurationDto>();

      
        }
    }
}
