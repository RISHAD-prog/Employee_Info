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
    public class EmployeeService
    {
        private readonly EmployeeEntities db;

        public EmployeeService(EmployeeEntities _db)
        {
            db = _db;
        }
        public EmployeeDTO AddEmployee(EmployeeDTO employee)
        {
            var config = Service.Mapping<EmployeeDTO, Employee>();
            var mapper = new Mapper(config);
            var EmployeeData = mapper.Map<Employee>(employee);
            var dataAccessFactory = new DataAccessFactory(db);
            var data = dataAccessFactory.EmployeeCrud().Add(EmployeeData);
            if(data != null)
            {
                return mapper.Map<EmployeeDTO>(data);
            }
            return null;
        }
        public EmployeeDTO UpdateData(EmployeeDTO employee)
        {
            var dataAccessFactory = new DataAccessFactory(db);
            var isAvailable = dataAccessFactory.EmployeeCrud().Get(employee.EmployeeCode);
            if (isAvailable)
            {
                return null;
            }
            else
            {
                var config = Service.Mapping<EmployeeDTO, Employee>();
                var mapper = new Mapper(config);
                var data = mapper.Map<Employee>(employee);
                var result = dataAccessFactory.EmployeeCrud().Update(data);
                var UpdatedInfo=mapper.Map<EmployeeDTO>(result);
                return UpdatedInfo;
            }
        }
        public int? GetData()
        {
            var dataAccessFactory = new DataAccessFactory(db);
            var config = Service.OneTimeMapping<Employee, EmployeeDTO>();
            var mapper = new Mapper(config);
            var result = dataAccessFactory.EmpInfo().EmpSalary();
            if(result != null)
            {
                var f= mapper.Map<EmployeeDTO>(result);
                return f.EmployeeSalary;
            }
            return null;
        }
    }
}
