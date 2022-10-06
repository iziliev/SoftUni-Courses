using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Grpc;

namespace WebShopDemo.Grpc.Services
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

            products.Item.AddRange(productData.Select(p => new ProductItem
            {
                Name = p.Name,
                Id = p.Id.ToString(),
                Price = (double)p.Price,
                Quantity = p.Quantity,
            }));

            return products;
        }
    }
}