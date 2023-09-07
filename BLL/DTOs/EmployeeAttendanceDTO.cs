using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EmployeeAttendanceDTO
    {
        public int EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public int IsPresent { get; set; }
        public int IsAbsent { get; set; }
        public int IsOffDay { get; set; }
    }
}
