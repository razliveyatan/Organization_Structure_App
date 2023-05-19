using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Types
{
    public class Org_Structure_DbContext : DbContext
    {
        public Org_Structure_DbContext(DbContextOptions<Org_Structure_DbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<CustomTask> CustomTasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath = "Org_Structure_Db.db";
            optionsBuilder.UseSqlite($"Data Source={databasePath};");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>()
            //    .HasMany(e => e.Reports)
            //    .WithOne()
            //    .HasForeignKey(r => r.EmployeeId);
            //modelBuilder.Entity<Employee>()
            //    .HasMany(e => e.CustomTasks)
            //    .WithOne()
            //    .HasForeignKey(ct => ct.EmployeeId);
            //modelBuilder.Entity<Manager>()
            //    .HasMany(m => m.Employees)
            //    .WithOne()
            //    .HasForeignKey(e => e.ManagerId);
            //modelBuilder.Entity<Manager>()
            //    .HasMany(m => m.Reports)
            //    .WithOne()
            //    .HasForeignKey(e => e.ManagerId);
            //modelBuilder.Entity<Manager>()
            //    .HasMany(m => m.CustomTasks)
            //    .WithOne()
            //    .HasForeignKey(e => e.ManagerId);
        }

    }
}
