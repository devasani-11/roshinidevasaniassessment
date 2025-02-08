using EmployeeManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Data
{
    public static class EmployeeContextInitializer
    {
        public static async Task Initialize(EmployeeContext context)
        {
            if (!context.Employees.Any())
            {
                var employees = GetPreconfiguredEmployees();
                await context.Employees.AddRangeAsync(employees);
                await context.SaveChangesAsync();

                var salaries = GetPreconfiguredSalaries(employees);
                await context.EmployeeSalaries.AddRangeAsync(salaries);
                await context.SaveChangesAsync();
            }
        }

        private static List<Employee> GetPreconfiguredEmployees()
        {
            var random = new Random();
            var employees = new List<Employee>();

            for (int i = 0; i < 100; i++)
            {
                var dob = DateTime.Now.AddYears(-random.Next(22, 65)).AddDays(-random.Next(1, 365));
                var joinDate = DateTime.Now.AddYears(-random.Next(0, 10)).AddDays(-random.Next(1, 365));

                employees.Add(new Employee
                {
                    Name = $"Employee{i}",
                    SSN = $"{random.Next(100, 999)}-{random.Next(10, 99)}-{random.Next(1000, 9999)}",
                    DOB = dob,
                    Address = $"Address{i}",
                    City = $"City{i}",
                    State = $"State{i}",
                    Zip = $"{random.Next(10000, 99999)}",
                    Phone = $"{random.Next(100, 999)}-{random.Next(100, 999)}-{random.Next(1000, 9999)}",
                    JoinDate = joinDate
                });
            }

            return employees;
        }

        private static List<EmployeeSalary> GetPreconfiguredSalaries(List<Employee> employees)
        {
            var random = new Random();
            var titles = new[] { "Developer", "Manager", "HR", "Analyst", "Tester" };
            var salaries = new List<EmployeeSalary>();

            foreach (var employee in employees)
            {
                salaries.Add(new EmployeeSalary
                {
                    FromDate = employee.JoinDate,
                    ToDate = null,
                    Title = titles[random.Next(0, titles.Length)],
                    Salary = random.Next(50000, 150000),
                    EmployeeId = employee.EmployeeId 
                });
            }

            return salaries;
        }
    }
}