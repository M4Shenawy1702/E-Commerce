using AutoMapper;
using Domain.Contracts;
using ServiceAbstraction.IService;

namespace Service
{
    public class ServiceManager(IUnitOfWork _unitOfWork, IMapper _mapper,IBasketRepsitory _basketRepsitory)
        : IServiceManager
    {
        private readonly Lazy<IProductService> _productService = new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
        public IProductService ProductService => _productService.Value;


        private readonly Lazy<IBasketService> _basketService = new Lazy<IBasketService>(() => new BasketService(_basketRepsitory ,_mapper));
        public IBasketService BasketService => _basketService.Value;
    }
}
