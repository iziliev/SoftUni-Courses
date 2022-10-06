using System.ComponentModel.DataAnnotations;

namespace TextSplitterApp.Models
{
    public class TextViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string InputText { get; set; } = null!;

        public string SplitedText { get; set; } = null!;
    }
}
