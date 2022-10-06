using ForumDemoApp.Data;
using ForumDemoApp.Data.Models;
using ForumDemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ForumDemoApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumDemoAppDbContext context;

        public PostController(ForumDemoAppDbContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "All posts";

            var model = await context.Posts
                .Where(p => !p.IsDeleted)
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                }).ToListAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Title"] = "Add post";

            var model = new PostViewModel();

            return View("Edit", model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await context.Posts
                .Where(p => p.Id == id)
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    EditedDate = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)
                    
                }).ToListAsync();

            if (model != null)
            {
                ViewData["Title"] = "Edit post";

                return View(model[0]);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel model)
        {
            ViewData["Title"] = model.Id == 0 ? "Add" : "Edit";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id == 0)
            {
                await context.Posts.AddAsync(new Post
                {
                    Title = model.Title,
                    Content = model.Content,
                    CreatedDate = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)
                });
            }
            else
            {
                var post = await context.Posts.FindAsync(model.Id);

                if (post != null)
                {
                    post.Title = model.Title;
                    post.Content = model.Content;
                    post.EditedDate = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
                }
            }

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var post = await context.Posts.FindAsync(id);

            if (post != null)
            {
                post.IsDeleted = true;
                post.DeletedDate = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
