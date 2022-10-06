using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopApp.Core.Models.Account
{
    /// <summary>
    /// User view model
    /// </summary>
    public class ApplicationUserViewModel
    {
        /// <summary>
        /// user first name
        /// </summary>
        [Required]
        [StringLength(25,MinimumLength =3)]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// user last name
        /// </summary>
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// user gender
        /// </summary>
        [Required]
        public string Gender { get; set; } = null!;

        /// <summary>
        /// user birthdate
        /// </summary>
        [Required]
        public string BirthDate { get; set; } = null!;
    }
}
