using AutoCooler.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Domain.Dto
{
    public class UserTechnician
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        public int EmpleyeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public List<ServiceOrder> serviceOrders { get; set; } = new List<ServiceOrder>();
    }
}
