using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShopApp.Core.Contracts;
using WebShopApp.Core.Models;

namespace WebShopApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200,StatusCode = StatusCodes.Status200OK,Type =typeof(IEnumerable<ProductViewModel>))]
        public async Task<IActionResult> GetAll()
        {
            var products = await productService.GetAll();

            return Ok(products);
        }
    }
}
