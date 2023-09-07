using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EmployeeEntities:DbContext
    {
        public EmployeeEntities(DbContextOptions<EmployeeEntities> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendance> employeeAttendances { get; set; }
    }
}
