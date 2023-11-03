using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class EmployeeAttendance
    {
        public int Id { get; set; }
        [ForeignKey("EmployeeId")]
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public DateTime AttendanceDate { get; set; }
        [Required]
        public int IsPresent { get; set; }
        [Required]
        public int IsAbsent { get; set; }
        [Required]
        public int IsOffDay { get; set; }

        public virtual Employee? Attendance { get; set; }
    }
}
