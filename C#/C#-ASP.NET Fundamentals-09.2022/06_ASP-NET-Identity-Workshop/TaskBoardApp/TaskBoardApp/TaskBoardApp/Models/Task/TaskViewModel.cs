

using System.ComponentModel.DataAnnotations;

namespace TaskBoardApp.Models.Task
{
    public class TaskViewModel
    {
        [Required]
        public int Id { get; init; }

        public string Title { get; init; }

        public string Description { get; init; }

        public string Owner { get; init; }
    }
}
