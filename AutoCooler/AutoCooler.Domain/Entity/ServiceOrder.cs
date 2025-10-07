using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Domain.Entity
{
    public class ServiceOrder
    {
        [Key]
        public int ServiceOrderId { get; set; }

        [Required, MaxLength(20)]
        public string Type { get; set; } = null!;

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;
                
        public string? Activities { get; set; } = null!;

        public string? Observations { get; set; }

        [Required]
        public int Status { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }
        public Company? Company { get; set; } = null!;

        [ForeignKey(nameof(Vehicle))]
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; } = null!;

        [ForeignKey(nameof(Technician))]
        public int? TechnicianId { get; set; }
        public Employee? Technician { get; set; }
    }
}
