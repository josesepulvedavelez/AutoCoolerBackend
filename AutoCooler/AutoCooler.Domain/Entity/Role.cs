using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Domain.Entity
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required, MaxLength(50)]
        public string RoleName { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
                
        public ICollection<User_Role> UserRoles { get; set; } = new List<User_Role>();
        public ICollection<Role_Permission> RolePermissions { get; set; } = new List<Role_Permission>();
    }
}
