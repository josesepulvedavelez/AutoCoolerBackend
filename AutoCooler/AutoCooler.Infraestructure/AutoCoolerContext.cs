using AutoCooler.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AutoCooler.Infraestructure
{
    public class AutoCoolerContext : DbContext
    {
        public AutoCoolerContext(DbContextOptions<AutoCoolerContext> options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<ServiceOrder> ServiceOrder { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<User_Role> UserRole { get; set; }
        public DbSet<Role_Permission> RolePermission { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.CompanyId, u.Username })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.CompanyId, u.Email })
                .IsUnique();

            modelBuilder.Entity<User_Role>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });

                entity.HasOne(ur => ur.User)
                      .WithMany(u => u.UserRoles)
                      .HasForeignKey(ur => ur.UserId);

                entity.HasOne(ur => ur.Role)
                      .WithMany(r => r.UserRoles)
                      .HasForeignKey(ur => ur.RoleId);
            });

            modelBuilder.Entity<Role_Permission>(entity =>
            {
                entity.HasKey(rp => new { rp.RoleId, rp.PermissionId });

                entity.HasOne(rp => rp.Role)
                      .WithMany(r => r.RolePermissions)
                      .HasForeignKey(rp => rp.RoleId);

                entity.HasOne(rp => rp.Permission)
                      .WithMany(p => p.RolePermissions)
                      .HasForeignKey(rp => rp.PermissionId);
            });

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Company)
                .WithMany(cmp => cmp.Customers)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Company)
                .WithMany(cmp => cmp.Employees)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Customer)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(v => v.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServiceOrder>()
                .HasOne(s => s.Vehicle)
                .WithMany(v => v.ServiceOrders)
                .HasForeignKey(s => s.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServiceOrder>()
                .HasOne(s => s.Company)
                .WithMany(cmp => cmp.ServiceOrders)
                .HasForeignKey(s => s.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServiceOrder>()
                .HasOne(s => s.Technician)
                .WithMany(e => e.ServiceOrdersAsTechnician)
                .HasForeignKey(s => s.TechnicianId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithMany(cmp => cmp.Users)
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Employee)
                .WithMany(e => e.Users)
                .HasForeignKey(u => u.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }

}
