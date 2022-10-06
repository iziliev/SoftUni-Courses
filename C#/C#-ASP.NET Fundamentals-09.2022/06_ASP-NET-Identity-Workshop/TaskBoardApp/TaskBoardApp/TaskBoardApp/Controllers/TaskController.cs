using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Data.Models;
using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public TaskController(TaskBoardAppDbContext context)
        {
            data = context;
        }

        public IActionResult Create()
        {
            var taskModel = new TaskFormModel()
            {
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public IActionResult Create(TaskFormModel taskModel)
        {
            if (!GetBoards().Any(b=>b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            var currentUserId = GetUserId();

            var task = new Data.Models.Task
            {
                Title = taskModel.Title,
                Description = taskModel.Descripotion,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId
            };

            data.Tasks.Add(task);
            data.SaveChanges();

            var boards = data.Boards;

            return RedirectToAction("All", "Boards");
        }

        public IActionResult Details(int id)
        {
            var task = data.Tasks.Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                }).FirstOrDefault();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        public IActionResult Edit(int id)
        {
            var task = data.Tasks.Find(id);

            if (task==null)
            {
                return BadRequest();
            }

            var currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            var taskModel = new TaskFormModel()
            {
                Title = task.Title,
                Descripotion = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public IActionResult Edit(int id,TaskFormModel taskModel)
        {
            var task = data.Tasks.Find(id);

            if (task == null)
            {
                return BadRequest();
            }

            var currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetBoards().Any(b=>b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Descripotion;
            task.BoardId = taskModel.BoardId;

            data.SaveChanges();
            return RedirectToAction("All", "Boards");
        }

        public IActionResult Delete(int id)
        {
            var task = data.Tasks.Find(id);

            if (task == null)
            {
                return BadRequest();
            }

            var currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            var taskModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };
            return View(taskModel);
        }

        [HttpPost]
        public IActionResult Delete(TaskViewModel taskModel)
        {
            var task = data.Tasks.Find(taskModel.Id);

            if (task == null)
            {
                return BadRequest();
            }

            var currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            data.Tasks.Remove(task);
            data.SaveChanges();

            return RedirectToAction("All", "Boards");
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private IEnumerable<TaskBoardModel> GetBoards()
        {
            return data.Boards.Select(b => new TaskBoardModel
            {
                Id = b.Id,
                Name = b.Name
            });
        }
    }
}
