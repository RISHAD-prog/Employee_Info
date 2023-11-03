using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeAttendanceService
    {
        private readonly DataAccessFactory daf;

        public EmployeeAttendanceService(DataAccessFactory _daf)
        {
            this.daf = _daf;
        }
        public EmployeeAttendanceDTO AddEmployeeAttendance(EmployeeAttendanceDTO employeeAttendance)
        {
            var config = Service.Mapping<EmployeeAttendanceDTO, EmployeeAttendance>();
            var mapper = new Mapper(config);
            var EmployeeData = mapper.Map<EmployeeAttendance>(employeeAttendance);
            //var dataAccessFactory = new DataAccessFactory(db);
            var data = daf.EmployeeAttendanceCrud().Add(EmployeeData);
            if (data != null)
            {
                return mapper.Map<EmployeeAttendanceDTO>(data);
            }
            return null;
        }

        public List<EmployeeDTO>? GetAttendanceRepot()
        {
            //var dataAccessFactory = new DataAccessFactory(db);
            var AtdEmp= daf.GetEmployee().GetPresentEmployees();
            if(AtdEmp != null)
            {
                var config = Service.Mapping<Employee, EmployeeDTO>();
                var mapper = new Mapper(config);
                return mapper.Map<List<EmployeeDTO>>(AtdEmp);
            }
            return null;
        }

        public List<EmpMonthlyAttendanceDTO> GetSingleEmployeeAttendance(int id)
        {
            var attendances = daf.singleEmpdetail().GetAttendance(id);
            if (attendances != null)
            {
                var config = Service.OneTimeMapping<EmployeeAttendance, EmpMonthlyAttendanceDTO>();  
                var mapper = new Mapper(config);
                var result = new List<EmpMonthlyAttendanceDTO>();
                var emp = daf.EmployeeCrud().Get(id);
                foreach (var item in attendances)
                {
                    
                    if (emp != null)
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
                }
                
                return mapper.Map<List<EmpMonthlyAttendanceDTO>>(result);
            }
            return null;
        }
    }
}
