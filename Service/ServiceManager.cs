﻿using ServiceAbstraction.IService;

namespace Services;
internal class ServiceManager(Func<IProductService> productFactory,
    Func<IAuthenticationService> authFactory,
    Func<IOrderService> orderFactory,
    Func<IBasketService> basketFactory,
    Func<ICashService> cashFactory,
    Func<IPaymentService> paymentFactory,
    Func<IBrandService> brandFactory,
    Func<ITypeService> typeFactory)
    : IServiceManager
{
    public IProductService ProductService => productFactory.Invoke();
    public IBasketService BasketService => basketFactory.Invoke();
    public IAuthenticationService AuthenticationService => authFactory.Invoke();
    public IOrderService OrderService => orderFactory.Invoke();
    public ICashService CashService => cashFactory.Invoke();
    public IPaymentService PaymentService => paymentFactory.Invoke();
    public IBrandService BrandService => brandFactory.Invoke();
    public ITypeService TypeService => typeFactory.Invoke();
}
