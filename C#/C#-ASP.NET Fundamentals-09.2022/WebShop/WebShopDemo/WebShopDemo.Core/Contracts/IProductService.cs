using WebShopDemo.Core.Data.Models;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Core.Contracts
{
    /// <summary>
    /// Manipulate product
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Get All products
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductViewModel>> GetAll();

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="productViewModel"> Product model</param>
        /// <returns></returns>
        Task Add(ProductViewModel productViewModel);

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);

        /// <summary>
        /// Get All products
        /// </summary>
        /// <returns></returns>
        Task<Product> GetById(Guid id);

        /// <summary>
        /// Buy product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Buy(ProductViewModel model);
    }
}
