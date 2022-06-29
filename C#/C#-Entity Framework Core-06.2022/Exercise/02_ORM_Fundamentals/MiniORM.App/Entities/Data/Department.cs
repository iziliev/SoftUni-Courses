using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniORM.App.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; }
    }
}
