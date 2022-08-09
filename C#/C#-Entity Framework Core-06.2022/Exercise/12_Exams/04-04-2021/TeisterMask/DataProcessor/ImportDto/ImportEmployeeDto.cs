using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeisterMask.Data.Models;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        public ImportEmployeeDto()
        {
            this.Tasks = new HashSet<int>();
        }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression("([A-Z]+[0-9]*)|([a-z]+[0-9]*)|([0-9]+)")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(12)]
        [RegularExpression("^([0-9]{3}-[0-9]{3}-[0-9]{4})$")]
        public string Phone { get; set; }

        public HashSet<int> Tasks { get; set; }
    }
}
