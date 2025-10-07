using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Domain.Entity
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [Required, MaxLength(20)]
        public string Plate { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Make { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Model { get; set; } = null!;

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; } = null!;

        public ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
    }
}
