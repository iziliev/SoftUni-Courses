using AutoMapper;
using ProductShop.DTO;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {

            this.CreateMap<CategoryDto, Category>();
            this.CreateMap<CategoryProductDto, CategoryProduct>();
            this.CreateMap<ProductDto, Product>();
            this.CreateMap<UserDto, User>();
        }
    }
}
