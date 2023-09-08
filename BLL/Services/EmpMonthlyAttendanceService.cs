using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmpMonthlyAttendanceService
    {
        private readonly EmployeeEntities db;

        public EmpMonthlyAttendanceService(EmployeeEntities _db)
        {
            db = _db;
        }
        public List<EmpMonthlyAttendanceDTO> MonthlyAttendance()
        {
            var dataAccessFactory = new DataAccessFactory(db);
            var Emp = dataAccessFactory.EmployeeCrud().Get();
            
            var result = new List<EmpMonthlyAttendanceDTO>();
            foreach (var employee in Emp)
            {
                var report = dataAccessFactory.EmployeeAttendanceCrud().Get(employee.EmployeeId);
                if(report != null)
                {
                    var monthlyAttendance = new EmpMonthlyAttendanceDTO
                    {
                        EmployeeName = employee.EmployeeName,
                        EmployeeSalary = employee.EmployeeSalary,
                        IsPresent = report.IsPresent,
                        IsAbsent = report.IsAbsent,
                        IsOffDay = report.IsOffDay,
                        Month = report.AttendanceDate.ToString("MMMM")
                    };

                    result.Add(monthlyAttendance);
                }
                
            }

            return result;

        }
    }
}
