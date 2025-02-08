using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.Salaries)
                .ToListAsync();
        }

        public async Task<IEnumerable<object>> GetAllTitlesAsync()
        {
            return await _context.EmployeeSalaries
                .GroupBy(es => es.Title)
                .Select(g => new
                {
                    Title = g.Key,
                    MinSalary = g.Min(es => es.Salary),
                    MaxSalary = g.Max(es => es.Salary)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByTitleAsync(string title)
        {
            return await _context.Employees
                .Include(e => e.Salaries)
                .Where(e => e.Salaries.Any(s => s.Title.Contains(title)))
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByNameAsync(string name)
        {
            return await _context.Employees
                .Include(e => e.Salaries)
                .Where(e => e.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            if (employee.Salaries != null)
            {
                foreach (var salary in employee.Salaries)
                {
                    salary.EmployeeId = employee.EmployeeId;
                }
            }

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}