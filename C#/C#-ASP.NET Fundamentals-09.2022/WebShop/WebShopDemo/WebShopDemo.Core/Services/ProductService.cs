using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Data.Common;
using WebShopDemo.Core.Data.Models;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Core.Services
{
    /// <summary>
    /// Manipulate products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IConfiguration config;

        private readonly IRepository repo;

        /// <summary>
        /// Ioc
        /// </summary>
        /// <param name="_config"></param>
        /// <param name="_repo">Application configuration</param>
        public ProductService(
            IConfiguration _config,
            IRepository _repo)
        {
            config = _config;
            repo = _repo;
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="productViewModel"> Product model</param>
        /// <returns></returns>
        public async Task Add(ProductViewModel productViewModel)
        {
            var product = new Product()
            {
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Quantity = productViewModel.Quantity,
            };
            if (productViewModel.Id == Guid.Empty)
            {
                
                await repo.AddAsync(product);
            }

            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Delete(Guid id)
        {
            var product = await repo.All<Product>()
                .FirstOrDefaultAsync(p => p.Id.Equals(id));

            if (product!=null)
            {
                product.IsAvaylable = false;
                product.DeletedDate = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
                await repo.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get products
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return await repo.All<Product>()
                .Where(p=>p.IsAvaylable)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                }).ToListAsync();
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetById(Guid id)
        {
            return await repo.All<Product>()
                .FirstOrDefaultAsync(p => p.Id.Equals(id));

            
        }

        /// <summary>
        /// Buy product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Buy(ProductViewModel model)
        {
            var product = await repo.All<Product>()
                .FirstOrDefaultAsync(p => p.Id.Equals(model.Id));

            if (product != null && product.Quantity >=model.Quantity)
            {
                product.Quantity -= model.Quantity;
                await repo.SaveChangesAsync();
            }
        }
    }
}
