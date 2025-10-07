using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Domain.Entity
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        [Required, MaxLength(100)]
        public string PermissionName { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        public ICollection<Role_Permission> RolePermissions { get; set; } = new List<Role_Permission>();
    }
}
