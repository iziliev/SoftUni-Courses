using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        /// <summary>
        /// List all Product
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAll();

            ViewData["Title"] = "Products";

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductViewModel();

            ViewData["Title"] = "Add new product";

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewData["Title"] = "Edit product";

            var product = await productService.GetById(id);

            if (product != null)
            {

                var model = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    ModifiedDate = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)
                };

                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Add new product";

                return View(model);
            }

            if (model.Id == Guid.Empty)
            {
                await productService.Add(model);
            }
            else
            {
                ViewData["Title"] = "Edit product";

                var product = await productService.GetById(model.Id);

                if (product != null)
                {
                    product.Name = model.Name;
                    product.Price = model.Price;
                    product.Quantity = model.Quantity;
                    product.ModifiedDate = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
                }

                await productService.Add(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] string id)
        {
            var idGuid = Guid.Parse(id);

            await productService.Delete(idGuid);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Buy(Guid id)
        {
            ViewData["Title"] = "Buy product";

            var product = await productService.GetById(id);

            ViewBag.Message = product.Quantity;

            if (product != null)
            {

                var model = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                };

                return View(model);
            }

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<IActionResult> Buy(ProductViewModel model)
        {
            ViewData["Title"] = "Buy product";

            var product = await productService.GetById(model.Id);

            if (model.Quantity > product.Quantity)
            {
                return View(model);
            }

            await productService.Buy(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
