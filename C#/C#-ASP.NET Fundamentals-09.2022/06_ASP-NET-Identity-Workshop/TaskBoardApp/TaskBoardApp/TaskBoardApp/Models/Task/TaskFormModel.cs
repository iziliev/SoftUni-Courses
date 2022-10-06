
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.Task;

namespace TaskBoardApp.Models.Task
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(MaxTaskTitle,MinimumLength =3,ErrorMessage ="Title should be at lease {2} characters long.")]
        public string Title { get; set; }

        [Required]
        [StringLength(MaxTaskDescription, MinimumLength = 3, ErrorMessage = "Description should be at lease {2} characters long.")]
        public string Descripotion { get; set; }

        [Display(Name ="Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; }
    }
}
