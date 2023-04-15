using AutoMapper;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Config
{
    public class ConfigAutoMapper :Profile
    {
        public ConfigAutoMapper() {
            CreateMap<ProductDto, Product>();
        }
    }
}
