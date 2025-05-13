using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceAbstraction.IService;
using Shared.Setting;
using Microsoft.Extensions.Options;
using Services;
using Service.Services;


namespace Service
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this  IServiceCollection services , IConfiguration configuration)
        {
            

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IServiceManager, ServiceManager>();

            // Service 
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ICashService, CashService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ITypeService, TypeService>();


            // Factory Delegate Registration
            services.AddScoped<Func<IProductService>>(provider => ()
             => provider.GetRequiredService<IProductService>());
            services.AddScoped<Func<IAuthenticationService>>(provider => ()
             => provider.GetRequiredService<IAuthenticationService>());
            services.AddScoped<Func<IBasketService>>(provider => ()
             => provider.GetRequiredService<IBasketService>());
            services.AddScoped<Func<IOrderService>>(provider => ()
             => provider.GetRequiredService<IOrderService>());
            services.AddScoped<Func<ICashService>>(provider => ()
            => provider.GetRequiredService<ICashService>());
            services.AddScoped<Func<IPaymentService>>(provider => ()
            => provider.GetRequiredService<IPaymentService>());
            services.AddScoped<Func<IBrandService>>(provider => ()
            => provider.GetRequiredService<IBrandService>());
            services.AddScoped<Func<ITypeService>>(provider => ()
            => provider.GetRequiredService<ITypeService>());

            return services;
        }
    }
}
