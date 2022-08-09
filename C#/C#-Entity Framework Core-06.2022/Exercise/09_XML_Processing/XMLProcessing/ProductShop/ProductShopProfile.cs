using AutoMapper;
using ProductShop.DTO.Input;
using ProductShop.Model;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<InputUserDto, User>();
            this.CreateMap<InputProductDto, Product>();
            this.CreateMap<InputCategoryDto, Category>();
            this.CreateMap<InputCategoryProductDto, CategoryProduct>();
        }
    }
}
