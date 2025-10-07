using AutoCooler.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Domain.Dto
{
    public class ServiceOrderForTechnicianDto
    {
        public int CompanyId { get; set; }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }

        public int VehicleId { get; set; }
        public string Plate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public int ServiceOrderId { get; set; }
        public string Type { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Activities { get; set; }
        public string? Observations { get; set; }
        public int Status { get; set; }
        public int? TechnicianId { get; set; }

        public string StatusName { get; set; }
    }
}
