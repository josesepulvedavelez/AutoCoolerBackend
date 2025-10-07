using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutoCooler.Domain.Entity
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }


        [Required, StringLength(100)]
        public string Name { get; set; } = null!;

        [Required, StringLength(200)]
        public string Address { get; set; } = null!;

        [Required, StringLength(20)]
        public string Phone { get; set; } = null!;

        [Required, StringLength(100)]
        public string Email { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
