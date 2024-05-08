using AutoMapper;
using MyEshop_Clean.Application.DTOs.Category;
using MyEshop_Clean.Application.DTOs.CategoryToProduct;
using MyEshop_Clean.Application.DTOs.Order;
using MyEshop_Clean.Application.DTOs.OrderDetail;
using MyEshop_Clean.Application.DTOs.Product;
using MyEshop_Clean.Application.DTOs.User;
using MyEshop_Clean.Domain;

namespace MyEshop_Clean.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Product Mapping
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            #endregion

            #region Order Mapping
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            #endregion
            #region OrderDetail Mapping
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDto>().ReverseMap();
            #endregion

            #region User Mapping
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            #endregion

            #region Category
            CreateMap<CategoryToProduct, CategoryToProductDto>().ReverseMap();
            CreateMap<CategoryToProduct, CreateCategoryToProductDto>().ReverseMap();
            CreateMap<CategoryToProduct, UpdateCategoryToProductDto>().ReverseMap();
            
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            #endregion


        }
    }
}
