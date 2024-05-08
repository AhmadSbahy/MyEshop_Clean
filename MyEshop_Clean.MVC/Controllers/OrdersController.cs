using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEshop_Clean.MVC.Contracts;
using System.Security.Claims;
using AutoMapper;
using MyEshop_Clean.MVC.Models.Order;
using MyEshop_Clean.MVC.Models.OrderDetail;
using ZarinpalSandbox;

namespace MyEshop_Clean.MVC.Controllers
{
	public class OrdersController : Controller
	{
		private readonly IOrderService _orderService;
		private readonly IOrderDetailService _orderDetailService;
		private readonly IProductService _productService;
		private readonly IMapper _mapper;


		public OrdersController(IOrderService orderService, IOrderDetailService orderDetailService, IProductService productService, IMapper mapper)
		{
			_orderService = orderService;
			_orderDetailService = orderDetailService;
			_productService = productService;
			_mapper = mapper;
		}

		[Authorize]
		public async Task<IActionResult> ShowCart()
		{
			int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
			var order = (await _orderService.GetOrder()).FirstOrDefault(x => !x.IsFinally && x.UserId == userId);
			return View(order);
		}

		[Authorize]
		public async Task<IActionResult> AddToCart(int itemId)
		{
			var product = (await _productService.GetProducts()).SingleOrDefault(x=>x.ItemId == itemId);
			int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());

			var order = (await _orderService.GetOrder()).FirstOrDefault(x => !x.IsFinally && x.UserId == userId);

			if (order != null)
			{
				var orderDetail = (await _orderDetailService.GetOrderDetail())
					.FirstOrDefault(x => x.OrderId == order.Id && x.ProductId == product.Id);
				if (orderDetail != null)
				{
					orderDetail.Count += 1;
					await _orderDetailService.UpdateOrderDetail(orderDetail.Id,
						_mapper.Map<UpdateOrderDetailViewModel>(orderDetail));
				}
				else
				{
					await _orderDetailService.CreateOrderDetail(new CreateOrderDetailViewModel()
					{
						Count = 1,
						OrderId = order.Id,
						Price = (double)product.Item.Price,
						ProductId = product.Id
					});
				}

			}
			else
			{
				var createOrder = new CreateOrderViewModel()
				{
					CreateDate = DateTime.Now,
					IsFinally = false,
					UserId = userId
				};
				var id = await _orderService.CreateOrder(createOrder);

				await _orderDetailService.CreateOrderDetail(new CreateOrderDetailViewModel()
				{
					Count = 1,
					OrderId = id.Data,
					Price = (double)product.Item.Price,
					ProductId = product.Id
				});
			}

			return RedirectToAction("ShowCart");
		}
		[Authorize]
		public async Task<IActionResult> RemoveCart(int detailId)
		{

			var orderDetail = _orderDetailService.GetOrderDetailDetail(detailId);
			await _orderDetailService.DeleteOrderDetail(detailId);

			return RedirectToAction("ShowCart");
		}

		#region Payment

		[Authorize]
		public async Task<IActionResult> Payment()
		{
			int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());

			var order = (await _orderService.GetOrder()).FirstOrDefault(x => !x.IsFinally && x.UserId == userId);
			
			if (order == null)
				return NotFound();
			
			var payment = new Payment((int)order.OrderDetails.Sum(d => d.Price));
			var res = payment.PaymentRequest($"پرداخت فاکتور شماره {order.Id}",
				"https://localhost:44311/Orders/OnlinePayment/" + order.Id, "Ahmad@gmail.com", "09373600708");
			if (res.Result.Status == 100)
			{
				return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
			}
			else
			{
				return BadRequest();
			}

		}

		public async Task<IActionResult> OnlinePayment(int id)
		{
			if (HttpContext.Request.Query["Status"] != "" &&
			    HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
			    HttpContext.Request.Query["Authority"] != "")
			{
				string authority = HttpContext.Request.Query["Authority"].ToString();
				var order = (await _orderService.GetOrder()).FirstOrDefault(x => x.Id == id);

				var payment = new Payment((int)order.OrderDetails.Sum(d => d.Price));
				var res = payment.Verification(authority).Result;
				if (res.Status == 100)
				{
					order.IsFinally = true;
					
					await _orderService.UpdateOrder(order.Id,
						_mapper.Map<UpdateOrderViewModel>(order));

					ViewBag.code = res.RefId;
					return View();
				}
			}

			return NotFound();
		}

		#endregion
	}
}
