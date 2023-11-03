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
        private readonly DataAccessFactory daf;

        public EmpMonthlyAttendanceService(DataAccessFactory _daf)
        {
            this.daf = _daf;
        }
        public List<EmpMonthlyAttendanceDTO> MonthlyAttendance()
        {
            //var dataAccessFactory = new DataAccessFactory(db);
            var Emp = daf.EmployeeCrud().Get();
            
            var result = new List<EmpMonthlyAttendanceDTO>();
            foreach (var employee in Emp)
            {
                var report = daf.EmployeeAttendanceCrud().Get(employee.EmployeeId);
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

        public List<EmpMonthlyAttendanceDTO> empMonthlyAttendance(string month, int id)
        {
            var attemp = daf.GetEmployeeAttendance().GetEmpMonthlyAttendance(month, id);
            var config = Service.OneTimeMapping<EmployeeAttendance, EmpMonthlyAttendanceDTO>();
            var mapper = new Mapper(config);
            var emp = daf.EmployeeCrud().Get(id);
            if (emp!= null)
            {
                var result = new List<EmpMonthlyAttendanceDTO>();
                foreach (var item in attemp)
                {
                    var monthlyAttendance = new EmpMonthlyAttendanceDTO
                    {
                        EmployeeName = emp.EmployeeName,
                        EmployeeSalary = emp.EmployeeSalary,
                        IsPresent = item.IsPresent,
                        IsAbsent = item.IsAbsent,
                        IsOffDay = item.IsOffDay,
                        Month = item.AttendanceDate.ToString("MMMM")
                    };
                    result.Add(monthlyAttendance);
                }
                
                return mapper.Map<List<EmpMonthlyAttendanceDTO>>(result);    
            }
            return null;
        }
    }
}
