using AutoMapper;
using InventryManager.API.Models;
using InventryManager.Service.Dto;

namespace InventryManager.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, ProductDto>();
        }
    }
}
