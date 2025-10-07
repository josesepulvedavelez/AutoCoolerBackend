using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Domain.Entity
{
    public class Role_Permission
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Permission))]
        public int PermissionId { get; set; }
        public Permission Permission { get; set; } = null!;
    }
}
