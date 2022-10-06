using WebShopApp.Core.Data.Models;
using WebShopApp.Core.Models;

namespace WebShopApp.Core.Contracts
{
    /// <summary>
    /// Manipulate products
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Show all avaylable products
        /// </summary>
        /// <returns>Avaylable products</returns>
        Task<IEnumerable<ProductViewModel>> GetAll();

        /// <summary>
        /// Show product by Id
        /// </summary>
        /// <returns>Product by id</returns>
        Task<Product> GetById(Guid id);

        /// <summary>
        /// Add or edit product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task Add(ProductViewModel model);

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task Delete(Guid id, string username);

        /// <summary>
        /// Search product by name
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductViewModel>> Search(string name);

    }
}
