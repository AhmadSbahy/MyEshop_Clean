using AutoMapper;
using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.Order;
using MyEshop_Clean.MVC.Models.Product;
using MyEshop_Clean.MVC.Models.User;

namespace MyEshop_Clean.MVC.Base
{
    public class OrderService : BaseHttpService , IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorageService;

        public OrderService(IClient client, ILocalStorageService localStorage, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorage)
        {
            _mapper = mapper;
            _client = client;
            _localStorageService = localStorageService;
        }

        public async Task<List<OrderViewModel>> GetOrder()
        {
            var orders = await _client.OrderAllAsync();
            return _mapper.Map<List<OrderViewModel>>(orders);
        }

        public async Task<OrderViewModel> GetProductDetail(int id)
        {
            var order = await _client.OrderGETAsync(id);
            return _mapper.Map<OrderViewModel>(order);
        }

        public async Task<Response<int>> CreateOrder(CreateOrderViewModel createOrderViewModel)
        {
            try
            {
                var response = new Response<int>();
                var createOrder = _mapper.Map<CreateOrderDto>(createOrderViewModel);

                var apiResponse = await _client.OrderPOSTAsync(createOrder);

                if ((bool)apiResponse.IsSuccess)
                {
                    response.IsSuccess = true;
                    response.Data = (int)apiResponse.Id;
                    response.Message = "Order Created";
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

        public async Task<Response<int>> UpdateOrder(int id, UpdateOrderViewModel updateOrderViewModel)
        {
            try
            {
                var order = _mapper.Map<UpdateOrderDto>(updateOrderViewModel);
                await _client.OrderPUTAsync(id, order);
                return new Response<int>() { IsSuccess = true, Message = "Order Edited" };
            }
            catch (ApiException e)
            {
                return ConvertApiException<int>(e);
            }
        }

        public async Task<Response<int>> DeleteOrder(int id)
        {
            try
            {
                await _client.OrderDELETEAsync(id);
                return new Response<int>() { IsSuccess = true, Message = "Order Deleted" };
            }
            catch (ApiException e)
            {
                return ConvertApiException<int>(e);
            }
        }
    }
}
