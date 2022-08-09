using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30,MinimumLength =4)]
        public string FullName { get; set; }

        public bool	IsMainCharacter { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 15)]
        [RegularExpression(@"[+44]+-[0-9]{2}-[0-9]{3}-[0-9]{4}")]
        public string PhoneNumber  { get; set; }

        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }
        public virtual Play Play { get; set; }
    }
}