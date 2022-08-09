using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            this.EmployeesTasks = new HashSet<EmployeeTask>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength =3)]
        [RegularExpression("([A-Z]+[0-9]*)|([a-z]+[0-9]*)|([0-9]+)")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(12)]
        [RegularExpression("^([0-9]{3}-[0-9]{3}-[0-9]{4})$")]
        public string Phone { get; set; }

        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }
    }
}
