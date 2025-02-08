using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);
            modelBuilder.Entity<EmployeeSalary>().HasKey(es => es.EmployeeSalaryId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Salaries)
                .WithOne(es => es.Employee)
                .HasForeignKey(es => es.EmployeeId);

            modelBuilder.Entity<EmployeeSalary>()
                .HasOne(es => es.Employee)
                .WithMany(e => e.Salaries)
                .HasForeignKey(es => es.EmployeeId)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}