using AutoMapper;
using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.Category;
using MyEshop_Clean.MVC.Models.CategoryToProduct;

namespace MyEshop_Clean.MVC.Base
{
	public class CategoryToProductService : BaseHttpService, ICategoryToProductService
	{
		private readonly IMapper _mapper;
		private readonly IClient _client;
		private readonly ILocalStorageService _localStorageService;

		public CategoryToProductService(IClient client, ILocalStorageService localStorage, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorage)
		{
			_mapper = mapper;
			_client = client;
			_localStorageService = localStorageService;
		}
		public async Task<List<CategoryToProductViewModel>> GetCategoryToProduct()
		{
			var category = await _client.CategoryToProductAllAsync();
			return _mapper.Map<List<CategoryToProductViewModel>>(category);
		}

		public async Task<CategoryToProductViewModel> GetCategoryDetailToProduct(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<Response<int>> CreateCategoryToProduct(CreateCategoryToProductViewModel createCategoryToProductView)
		{
			try
			{
				var response = new Response<int>();
				var createCategory = _mapper.Map<CreateCategoryToProductDto>(createCategoryToProductView);

				var apiResponse = await _client.CategoryToProductPOSTAsync(createCategory);

				if ((bool)apiResponse.IsSuccess)
				{
					response.IsSuccess = true;
					response.Data = (int)apiResponse.Id;
					response.Message = "CategoryToProduct Created";
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

		public async Task<Response<int>> UpdateCategoryToProduct(int id, UpdateCategoryToProductViewModel createCategoryToProductView)
		{
			throw new NotImplementedException();
		}

		public async Task<Response<int>> DeleteCategoryToProduct(int id)
		{
			try
			{
				await _client.CategoryToProductDELETEAsync(id);
				return new Response<int>() { IsSuccess = true, Message = "CTtoPR Deleted" };
			}
			catch (ApiException e)
			{
				return ConvertApiException<int>(e);
			}
		}
	}
}
