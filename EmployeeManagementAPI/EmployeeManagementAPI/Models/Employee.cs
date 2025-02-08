using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EmployeeManagementAPI.Models
{
    public class Employee
    {
        public Employee()
        {
            Salaries = new List<EmployeeSalary>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? ExitDate { get; set; }

        public ICollection<EmployeeSalary> Salaries { get; set; }
    }
}