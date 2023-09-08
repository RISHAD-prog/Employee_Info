using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EmpMonthlyAttendanceDTO
    {
        public string? EmployeeName { get; set; }
        public int? EmployeeSalary { get; set; }
        public string Month { get; set; }
        public int IsPresent { get; set; }
        public int IsAbsent { get; set; }
        public int IsOffDay { get; set; }
    }
}
