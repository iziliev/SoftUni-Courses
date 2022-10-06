using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Data.DataConstants.Task;

namespace TaskBoardApp.Data.Models
{
    public class Task
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxTaskTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxTaskDescription)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Board))]
        public int BoardId { get; set; }
        public Board Board { get; set; }

        [Required]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;
        public User Owner { get; set; }
    }
}
