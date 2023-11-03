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
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }
        [Required]
        public string? EmployeeName { get; set; }
        [Required]
        public string? EmployeeCode { get; set; }
        [Required]
        public int? EmployeeSalary { get; set; }
        [Required]
        public int? SupervisorId { get; set; }

        public virtual List<EmployeeAttendance> EmployeeAttendances { get; set; }
        public Employee()
        {
            EmployeeAttendances = new List<EmployeeAttendance>();
        }
    }
}
