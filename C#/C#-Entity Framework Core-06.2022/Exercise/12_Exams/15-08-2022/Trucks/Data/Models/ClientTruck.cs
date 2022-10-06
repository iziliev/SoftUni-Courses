using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Trucks.Data.Models
{
    public class ClientTruck
    {
        [ForeignKey(nameof(Client))]
        [Required]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey(nameof(Truck))]
        [Required]
        public int TruckId { get; set; }
        public virtual Truck Truck { get; set; }
    }
}
