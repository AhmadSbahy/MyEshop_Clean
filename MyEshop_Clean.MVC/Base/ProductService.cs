using AutoMapper;
using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.Product;
using System.Reflection;

namespace MyEshop_Clean.MVC.Base
{
	public class ProductService : BaseHttpService, IProductService
	{
		private readonly IMapper _mapper;
		private readonly IClient _client;
		private readonly ILocalStorageService _localStorageService;

		public ProductService(IClient client, ILocalStorageService localStorage, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorage)
		{
			_mapper = mapper;
			_client = client;
			_localStorageService = localStorageService;
		}

		public async Task<List<ProductViewModel>> GetProducts()
		{
			var products = await _client.ProductsAllAsync();
			return _mapper.Map<List<ProductViewModel>>(products);
		}

		public async Task<ProductViewModel> GetProductDetail(int id)
		{
			var product = await _client.ProductsGETAsync(id);
			var x = _mapper.Map<ProductViewModel>(product);
			return x;
		}

		public async Task<Response<int>> CreateProduct(CreateProductViewModel createProductViewModel)
		{
			try
			{
				var response = new Response<int>();
				var createProduct = _mapper.Map<CreateProductDto>(createProductViewModel);
				
				var apiResponse = await _client.ProductsPOSTAsync(createProduct);

				if ((bool)apiResponse.IsSuccess)
				{
					response.IsSuccess = true;
					response.Data = (int)apiResponse.Id;
					response.Message = "Product Created";
				}
				else
				{
					foreach (var err in apiResponse.ErroresList)
					{
						response.ValidationErrors += err + Environment.NewLine;
					}
				}

				return response;
			}
			catch (ApiException e)
			{
				return ConvertApiException<int>(e);
			}
		}

		public async Task<Response<int>> UpdateProduct(int id, UpdateProductViewModel updateProductViewModel)
		{
			try
			{
				var product = _mapper.Map<UpdateProductDto>(updateProductViewModel);
				product.ItemDto = new ItemDto()
				{
					Id = updateProductViewModel.Item.Id,
					Price = updateProductViewModel.Item.Price,
					QuantityInStock = updateProductViewModel.Item.QuantityInStock
				};
				await _client.ProductsPUTAsync(id, product);
				return new Response<int>() { IsSuccess = true, Message = "Product Edited" ,Data = (int)product.Id};
			}
			catch (ApiException e)
			{
				return ConvertApiException<int>(e);
			}
		}

		public async Task<Response<int>> DeleteProduct(int id)
		{
			try
			{
				await _client.ProductsDELETEAsync(id);
				return new Response<int>() { IsSuccess = true, Message = "Product Deleted" };
			}
			catch (ApiException e)
			{
				return ConvertApiException<int>(e);
			}
		}

		public async Task<List<ProductViewModel>> GetProductsByCategoryId(int id)
		{
			var products = (await _client.CategoryAllAsync())
				.Where(p => p.Id == id)
				.SelectMany(p => p.CategoryToProducts)
				.Select(p => p.Product);

			return _mapper.Map<List<ProductViewModel>>(products);
		}
	}
}
