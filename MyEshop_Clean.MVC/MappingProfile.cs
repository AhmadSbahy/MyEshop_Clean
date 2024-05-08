using AutoMapper;
using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Models.Category;
using MyEshop_Clean.MVC.Models.CategoryToProduct;
using MyEshop_Clean.MVC.Models.Order;
using MyEshop_Clean.MVC.Models.OrderDetail;
using MyEshop_Clean.MVC.Models.Product;
using MyEshop_Clean.MVC.Models.User;

namespace MyEshop_Clean.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<UserDto, UserViewModel>().ReverseMap();
            CreateMap<UpdateUserViewModel, UserViewModel>().ReverseMap();
            CreateMap<CreateUserDto, CreateUserViewModel>().ReverseMap();
            CreateMap<UpdateUserDto, UpdateUserViewModel>().ReverseMap();
            #endregion

            #region Product
            CreateMap<ProductDto, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductDto, CreateProductViewModel>().ReverseMap();
            CreateMap<UpdateProductDto, UpdateProductViewModel>().ReverseMap();
            CreateMap<ProductViewModel, UpdateProductViewModel>().ReverseMap();
            #endregion

            #region Category
            CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();
            CreateMap<CreateCategoryDto, CreateCategoryViewModel>().ReverseMap();
            CreateMap<UpdateCategoryDto, UpdateCategoryViewModel>().ReverseMap();


            CreateMap<CategoryToProductDto, CategoryToProduct>().ReverseMap();
            CreateMap<CategoryToProductViewModel, CategoryToProductDto>().ReverseMap();
            CreateMap<CreateCategoryToProductDto, CreateCategoryToProductViewModel>().ReverseMap();
            CreateMap<UpdateCategoryToProductDto, UpdateCategoryToProductViewModel>().ReverseMap();

			#endregion

			#region Order
			CreateMap<OrderDto, OrderViewModel>().ReverseMap();
            CreateMap<CreateOrderDto, CreateOrderViewModel>().ReverseMap();
            CreateMap<UpdateOrderDto, UpdateOrderViewModel>().ReverseMap();
            CreateMap<OrderViewModel, UpdateOrderViewModel>().ReverseMap();
            #endregion
            
            #region OrderDetail
            CreateMap<OrderDetailDto, OrderDetailViewModel>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailViewModel>().ReverseMap();
            CreateMap<CreateOrderDetailDto, CreateOrderDetailViewModel>().ReverseMap();
            CreateMap<UpdateOrderDetailDto, UpdateOrderDetailViewModel>().ReverseMap();
            CreateMap<OrderDetailViewModel, UpdateOrderDetailViewModel>().ReverseMap();

            #endregion
        }
    }
}
