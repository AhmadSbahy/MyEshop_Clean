using AutoMapper;
using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.Category;
using MyEshop_Clean.MVC.Models.User;

namespace MyEshop_Clean.MVC.Base
{
    public class CategoryService : BaseHttpService , ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorageService;

        public CategoryService(IClient client, ILocalStorageService localStorage, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorage)
        {
            _mapper = mapper;
            _client = client;
            _localStorageService = localStorageService;
        }

        public async Task<List<CategoryViewModel>> GetCategory()
        {
            var category = await _client.CategoryAllAsync();
            return _mapper.Map<List<CategoryViewModel>>(category);
        }

        public async Task<CategoryViewModel> GetCategoryDetail(int id)
        {
            var category = await _client.CategoryGETAsync(id);
            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task<Response<int>> CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            try
            {
                var response = new Response<int>();
                var createCategory = _mapper.Map<CreateCategoryDto>(createCategoryViewModel);

                var apiResponse = await _client.CategoryPOSTAsync(createCategory);

                if ((bool)apiResponse.IsSuccess)
                {
                    response.IsSuccess = true;
                    response.Data = (int)apiResponse.Id;
                    response.Message = "Category Created";
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

        public async Task<Response<int>> UpdateCategory(int id, UpdateCategoryViewModel updateCategoryViewModel)
        {
            try
            {
                var category = _mapper.Map<UpdateCategoryDto>(updateCategoryViewModel);
                await _client.CategoryPUTAsync(id, category);
                return new Response<int>() { IsSuccess = true, Message = "Category Updated" };
            }
            catch (ApiException e)
            {
                return ConvertApiException<int>(e);
            }
        }

        public async Task<Response<int>> DeleteCategory(int id)
        {
            try
            {
                await _client.CategoryDELETEAsync(id);
                return new Response<int>() { IsSuccess = true, Message = "Category Deleted" };
            }
            catch (ApiException e)
            {
                return ConvertApiException<int>(e);
            }
        }

        public async Task<List<CategoryViewModel>> GetProductCategories(int productId)
        {
            var categories = await _client.CategoryAllAsync();
            
            var productCategory = categories
                .SelectMany(p=> p.CategoryToProducts)
                .Select(p=> p.Category).ToList();

            return _mapper.Map<List<CategoryViewModel>>(productCategory);
        }

        public async Task<IEnumerable<ShowCategoryViewModel>> GetCategoriesForShow()
        {
            var categories = await _client.CategoryAllAsync();
           var showCategoreisVM =  categories.Select(c => new ShowCategoryViewModel()
            {
                Name = c.Name,
                GroupId = (int)c.Id,
                ProductCount = c.CategoryToProducts.Count
            }).ToList();

            return showCategoreisVM;
        }
    }
}
    