using System.Collections.Immutable;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using MyEshop_Clean.MVC.Base;
using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Contracts;

namespace MyEshop_Clean.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var ApiAddress = builder.Configuration["ApiAddress"];
            
            builder.Services.AddHttpClient<IClient, Client>(client =>
            
            {
                client.BaseAddress = new Uri(ApiAddress);
            });
            builder.Services.AddControllersWithViews().AddJsonOptions(options=>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            builder.Services.AddRazorPages();
			builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICategoryToProductService, CategoryToProductService>();

            #region Authentication

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	            .AddCookie(option =>
	            {
		            option.LoginPath = "/Account/Login";
		            option.LogoutPath = "/Account/Logout";
		            option.ExpireTimeSpan = TimeSpan.FromDays(10);
	            });

            #endregion

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCookiePolicy();
            
            app.UseAuthentication();
            
            app.UseHttpsRedirection();
            
            app.UseStaticFiles();
            
            app.UseRouting();
			
            app.UseAuthorization();
			
			app.MapRazorPages();

			app.Use(async (context, next) =>
			{
				// Do work that doesn't write to the Response.
				if (context.Request.Path.StartsWithSegments("/Admin"))
				{
					if (!context.User.Identity.IsAuthenticated)
					{
						context.Response.Redirect("/Account/Login");
					}
					else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
					{
						context.Response.Redirect("/Account/Login");
					}
				}
				await next.Invoke();
				// Do logging or other work that doesn't write to the Response.
			});

			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
