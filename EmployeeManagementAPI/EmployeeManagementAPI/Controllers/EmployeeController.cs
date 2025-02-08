using Microsoft.AspNetCore.Mvc;
using EmployeeManagementAPI.Services;
using EmployeeManagementAPI.Models;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("titles")]
        public async Task<IActionResult> GetTitles()
        {
            var titles = await _employeeService.GetAllTitlesAsync();
            return Ok(titles);
        }

        [HttpGet("list/{title}")]
        public async Task<IActionResult> GetEmployeesByTitle(string title)
        {
            var employees = await _employeeService.GetEmployeesByTitleAsync(title);
            return Ok(employees);
        }

        [HttpGet("list/name/{name}")]
        public async Task<IActionResult> GetEmployeesByName(string name)
        {
            var employees = await _employeeService.GetEmployeesByNameAsync(name);
            return Ok(employees);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var addedEmployee = await _employeeService.AddEmployeeAsync(employee);
            return Ok(addedEmployee);
        }
    }
}   