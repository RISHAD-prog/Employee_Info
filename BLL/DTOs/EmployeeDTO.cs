using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EmployeeDTO
    {
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeCode { get; set; }
        public int? EmployeeSalary { get; set; }
        public int? SupervisorId { get; set; }
    }
}
