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
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employees)
                .WithOne(e => e.Manager)
                .HasForeignKey(e => e.ManagerId);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Reports)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Reports)
                .WithOne()
                .HasForeignKey(e => e.ManagerId);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CustomTasks)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId);
            modelBuilder.Entity<CustomTask>()
                .HasOne(e => e.Manager)
                .WithMany()
                .HasForeignKey(e => e.ManagerId);
            base.OnModelCreating(modelBuilder);
        }

    }
}
