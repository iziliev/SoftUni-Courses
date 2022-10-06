using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using WebShopApp.Core.Contracts;
using WebShopApp.Core.Data.Common;
using WebShopApp.Core.Data.Models;
using WebShopApp.Core.Models;

namespace WebShopApp.Core.Services
{
    /// <summary>
    /// Manipulate products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IConfiguration configuration;

        private readonly IRepository repository;

        public ProductService(
            IConfiguration _configuration,
            IRepository _repository)
        {
            configuration = _configuration;
            repository = _repository;
        }

        /// <summary>
        /// Add or edit product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Add(ProductViewModel model)
        {
            if (model.Id == Guid.Empty)
            {
                var product = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    Description = model.Description,
                    CreatedUser = model.CreatedUser
                };

                await repository.AddAsync(product);
            }
            else
            {
                var product = await repository.GetByIdAsync<Product>(model.Id);

                product.Name = model.Name;
                product.Price = model.Price;
                product.Quantity = model.Quantity;
                product.Description = model.Description;
                product.LastEditedDate = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
                product.EditedUser = model.EditedUser;
            }

            await repository.SaveChangesAsync();
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Delete(Guid id, string username)
        {
            var product = await repository.GetByIdAsync<Product>(id);

            if (product != null)
            {
                product.DeletedDate = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
                product.IsDeleted = true;
                product.DeletedUser = username;
                await repository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Show all avaylable products
        /// </summary>
        /// <returns>Avaylable products</returns>
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return await repository.All<Product>()
                .Where(p => !p.IsDeleted)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Description = p.Description,
                    CreatedUser = p.CreatedUser
                }).ToListAsync();
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product by id</returns>
        public async Task<Product> GetById(Guid id)
        {
            return await repository.GetByIdAsync<Product>(id);
        }

        /// <summary>
        /// Search products by name
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductViewModel>> Search(string name)
        {
            return await repository
                .All<Product>()
                .Where(p => p.Name.ToLower().Contains(name.ToLower()) && !p.IsDeleted)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Description = p.Description
                }).ToListAsync();
        }
    }
}
