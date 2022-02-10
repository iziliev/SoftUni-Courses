namespace CarWebSystem.Models
{
    using CarWebSystem.Data;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
