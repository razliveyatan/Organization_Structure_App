using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Org_Structure_DbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<CustomTask> CustomTasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Server=DESKTOP-5Q4NC7V\SQLEXPRESS;Database=Org_Structure_Db;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employees)
                .WithOne(e => e.Manager)
                .HasForeignKey(e => e.ManagerId);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Reports)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CustomTasks)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CustomTasks)
                .WithOne(e => e.Manager)
                .HasForeignKey(e => e.ManagerId);
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
