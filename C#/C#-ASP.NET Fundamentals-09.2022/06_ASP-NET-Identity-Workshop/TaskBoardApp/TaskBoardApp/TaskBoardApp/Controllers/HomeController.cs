﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public HomeController(TaskBoardAppDbContext context)
        {
            data = context;
        }


        public IActionResult Index()
        {
            var taskBoards = data.Boards
                .Select(b => b.Name)
                .Distinct();

            var taskCounts = new List<HomeBoardModel>();

            foreach (var boardName in taskBoards)
            {
                var taskinBoard = data.Tasks.Where(t => t.Board.Name == boardName).Count();
                taskCounts.Add(new HomeBoardModel()
                {
                    BoardName = boardName,
                    TasksCount = taskinBoard
                });
            }

            var userTasksCount = -1;

            if (User.Identity.IsAuthenticated)
            {
                var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                userTasksCount = data.Tasks.Where(t => t.OwnerId == currentUser).Count();
            }
            var homeModel = new HomeViewModel()
            {
                AllTasksCount = data.Tasks.Count(),
                BoardsWithTasksCount = taskCounts,
                UserTasksCount = userTasksCount
            };

            return View(homeModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}