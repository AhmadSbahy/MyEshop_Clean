using AutoMapper;
using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.Order;
using MyEshop_Clean.MVC.Models.OrderDetail;

namespace MyEshop_Clean.MVC.Base
{
    public class OrderDetailService : BaseHttpService , IOrderDetailService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorageService;

        public OrderDetailService(IClient client, ILocalStorageService localStorage, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorage)
        {
            _mapper = mapper;
            _client = client;
            _localStorageService = localStorageService;
        }

        public async Task<List<OrderDetailViewModel>> GetOrderDetail()
        {
            var orderDetails = await _client.OrderDetailAllAsync();
            return _mapper.Map<List<OrderDetailViewModel>>(orderDetails);
        }

        public async Task<OrderDetailViewModel> GetOrderDetailDetail(int id)
        {
            var orderDetail = await _client.OrderDetailGETAsync(id);
            return _mapper.Map<OrderDetailViewModel>(orderDetail);
        }

        public async Task<Response<int>> CreateOrderDetail(CreateOrderDetailViewModel createOrderDetailViewModel)
        {
            try
            {
                var response = new Response<int>();
                var createOrderDetail = _mapper.Map<CreateOrderDetailDto>(createOrderDetailViewModel);

                var apiResponse = await _client.OrderDetailPOSTAsync(createOrderDetail);

                if ((bool)apiResponse.IsSuccess)
                {
                    response.IsSuccess = true;
                    response.Data = (int)apiResponse.Id;
                    response.Message = "OrderDetail Created";
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

        public async Task<Response<int>> UpdateOrderDetail(int id, UpdateOrderDetailViewModel updateOrderDetailViewModel)
        {
            try
            {
                var orderDetail = _mapper.Map<UpdateOrderDetailDto>(updateOrderDetailViewModel);
                await _client.OrderDetailPUTAsync(id, orderDetail);
                return new Response<int>() { IsSuccess = true, Message = "OrderDetail Edited" };
            }
            catch (ApiException e)
            {
                return ConvertApiException<int>(e);
            }
        }

        public async Task<Response<int>> DeleteOrderDetail(int id)
        {
            try
            {
                await _client.OrderDetailDELETEAsync(id);
                return new Response<int>() { IsSuccess = true, Message = "OrderDetail Deleted" };
            }
            catch (ApiException e)
            {
                return ConvertApiException<int>(e);
            }
        }
    }
}
