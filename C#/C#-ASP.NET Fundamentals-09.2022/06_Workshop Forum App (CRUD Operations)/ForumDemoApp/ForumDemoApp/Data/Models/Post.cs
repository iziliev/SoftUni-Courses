using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static ForumDemoApp.Data.Constants.DataConstants.Post;

namespace ForumDemoApp.Data.Models
{
    [Comment("Post")]
    public class Post
    {
        [Comment("Post id")]
        [Key]
        public int Id { get; set; }

        [Comment("Post title")]
        [Required]
        [StringLength(MaxTitleLenght)]
        public string Title { get; set; } = null!;

        [Comment("Post content")]
        [Required]
        [StringLength(MaxContentLenght)]
        public string Content { get; set; } = null!;

        [Comment("Post is deleted")]
        [Required]
        public bool IsDeleted { get; set; } = false;

        [Comment("Post create on")]
        [Required]
        public string CreatedDate { get; set; } = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);

        [Comment("Post last edited on")]
        public string? EditedDate { get; set; }

        [Comment("Post deleted on")]
        public string? DeletedDate { get; set; }
    }
}
