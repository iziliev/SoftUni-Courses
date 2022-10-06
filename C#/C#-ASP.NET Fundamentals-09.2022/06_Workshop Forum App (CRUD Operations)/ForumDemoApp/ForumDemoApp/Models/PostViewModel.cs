using System.ComponentModel.DataAnnotations;
using static ForumDemoApp.Data.Constants.DataConstants.Post;
namespace ForumDemoApp.Models
{
    /// <summary>
    /// Product model
    /// </summary>
    public class PostViewModel
    {
        /// <summary>
        /// Product id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product title
        /// </summary>
        [Required]
        [StringLength(MaxTitleLenght,MinimumLength =MinTitleLenght)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Product content
        /// </summary>
        [Required]
        [StringLength(MaxContentLenght, MinimumLength = MinContentLenght)]
        public string Content { get; set; } = null!;

        /// <summary>
        /// Product edited date
        /// </summary>
        public string? EditedDate { get; set; }
    }
}
