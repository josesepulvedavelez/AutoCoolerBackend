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
    public class UserLoginDto
    {        
        public int EmployeeId { get; set; }             
        public string FirstName { get; set; }                
        public string LastName { get; set; }        
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsTechnician { get; set; }
        
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
