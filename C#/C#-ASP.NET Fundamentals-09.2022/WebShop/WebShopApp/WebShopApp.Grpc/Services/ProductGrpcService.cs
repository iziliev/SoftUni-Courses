using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using WebShopApp.Core.Contracts;
using WebShopApp.Core.Services;
using WebShopApp.Grpc;

namespace WebShopApp.Grpc.Services
{
    public class ProductGrpcService : Product.ProductBase
    {
        private readonly IProductService productService;

        public ProductGrpcService(IProductService _productService)
        {
            productService = _productService;
        }

        public override async Task<ProductList> GetAll(Empty request, ServerCallContext context)
        {
            var products = new ProductList();

            var productData = await productService.GetAll();

            products.Item.Add(productData.Select(p => new ProductItem
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                Price = (double)p.Price,
                Quantity = p.Quantity
            }));

            return products;
        }
    }
}