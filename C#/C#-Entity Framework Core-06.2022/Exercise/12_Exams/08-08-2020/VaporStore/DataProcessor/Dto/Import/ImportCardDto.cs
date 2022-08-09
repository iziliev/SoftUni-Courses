using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportCardDto
    {
        [Required]
        [RegularExpression(@"^([0-9]{4}\s?)+$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{3})$")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }
}