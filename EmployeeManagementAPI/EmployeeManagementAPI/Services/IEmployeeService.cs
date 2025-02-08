using EmployeeManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<IEnumerable<object>> GetAllTitlesAsync();
        Task<IEnumerable<Employee>> GetEmployeesByTitleAsync(string title);
        Task<IEnumerable<Employee>> GetEmployeesByNameAsync(string name);
        Task<Employee> AddEmployeeAsync(Employee employee);
    }
}