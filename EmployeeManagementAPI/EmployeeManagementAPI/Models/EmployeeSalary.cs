using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeManagementAPI.Models
{
    public class EmployeeSalary
    {
        public int EmployeeSalaryId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Title { get; set; }
        public decimal Salary { get; set; }
        public int EmployeeId { get; set; }

        [JsonIgnore]
        public Employee? Employee { get; set; }
    }
}