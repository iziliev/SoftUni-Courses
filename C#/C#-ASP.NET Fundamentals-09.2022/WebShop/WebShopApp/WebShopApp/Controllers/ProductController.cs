using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebShopApp.Core.Contracts;
using WebShopApp.Core.Data.Models;
using WebShopApp.Core.Models;

namespace WebShopApp.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await productService.GetAll();

            ViewData["Title"] = "All products";

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductViewModel();

            ViewData["Title"] = "Add product";

            return View("Edit", model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await productService.GetById(id);

            ViewData["Title"] = product == null ? "Add product" : "Edit product";

            if (product != null)
            {
                var model = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Description = product.Description,
                    CreatedUser = product.CreatedUser
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
                return View(model);
            }

            if (model.Id != Guid.Empty)
            {
                if (model.CreatedUser != User.Identity?.Name)
                {
                    ModelState.AddModelError("", "You can edit product created only by you!");
                    
                    return View(model);
                }

                model.EditedUser = User.Identity?.Name;
            }
            else
            {
                model.CreatedUser = User.Identity?.Name;
            }

            await productService.Add(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, string username)
        {
            await productService.Delete(id, username);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Search(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                ViewData["Title"] = $"All products > '{name}'";

                var model = await productService.Search(name);

                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Info(Guid id)
        {
            var product = await productService.GetById(id);

            if (product !=null)
            {
                ViewData["Title"] = $"{product.Name}";

                var model = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Description = product.Description
                };

                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
