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
        private readonly EmployeeEntities db;

        public EmployeeAttendanceService(EmployeeEntities _db)
        {
            db = _db;
        }
        public EmployeeAttendanceDTO AddEmployeeAttendance(EmployeeAttendanceDTO employeeAttendance)
        {
            var config = Service.Mapping<EmployeeAttendanceDTO, EmployeeAttendance>();
            var mapper = new Mapper(config);
            var EmployeeData = mapper.Map<EmployeeAttendance>(employeeAttendance);
            var dataAccessFactory = new DataAccessFactory(db);
            var data = dataAccessFactory.EmployeeAttendanceCrud().Add(EmployeeData);
            if (data != null)
            {
                return mapper.Map<EmployeeAttendanceDTO>(data);
            }
            return null;
        }
    }
}
