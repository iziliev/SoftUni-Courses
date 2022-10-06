using MCV_Intro_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace MCV_Intro_Demo.Controllers
{
    public class ProductsController : Controller
    {
        private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name ="Cheese",
                Price = 7.00
            },
            new ProductViewModel()
            {
                Id = 2,
                Name ="Ham",
                Price = 5.50
            },
            new ProductViewModel()
            {
                Id = 3,
                Name ="Bread",
                Price = 1.50
            }
        };
        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword!=null)
            {
                var product = this.products.Where(pr => pr.Name.ToLower().Contains(keyword.ToLower()));
                return View(product);
            }
            return View(this.products);
        }

        public IActionResult ById(int id)
        {
            var currentProduct = this.products.FirstOrDefault(x => x.Id == id);

            if (currentProduct == null)
            {
                return BadRequest();
            }
            return View(currentProduct);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            return Json(this.products,options);
        }

        public IActionResult AllAsText()
        {
            var sb = new StringBuilder();
            foreach (var product in this.products)
            {
                sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price}lv");
            }
            return Content(sb.ToString().Trim());
        }

        public IActionResult AllAsTextFile()
        {
            var sb = new StringBuilder();
            foreach (var product in this.products)
            {
                sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price}lv");
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString().Trim()), "text/plain", "products.txt");
        }
    }
}
