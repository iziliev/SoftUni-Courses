using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductShop.Model
{
    public class User
    {
        public User()
        {
            this.SoldProducts = new HashSet<Product>();
            this.BoughtProducts = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int? Age { get; set; }

        [InverseProperty("Seller")]
        public virtual ICollection<Product> SoldProducts { get; set; }

        [InverseProperty("Buyer")]
        public virtual ICollection<Product> BoughtProducts { get; set; }
    }
}
