namespace ServiceAbstraction.IService
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        IBasketService  BasketService{ get; }
    }
}
