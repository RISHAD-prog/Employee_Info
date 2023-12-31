﻿using AutoMapper;
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
        private readonly DataAccessFactory daf;

        public EmployeeService(DataAccessFactory _daf)
        {
            this.daf = _daf;
        }
        public EmployeeDTO AddEmployee(EmployeeDTO employee)
        {
            var config = Service.Mapping<EmployeeDTO, Employee>();
            var mapper = new Mapper(config);
            var EmployeeData = mapper.Map<Employee>(employee);
            //var dataAccessFactory = new DataAccessFactory(db);
            var data = daf.EmployeeCrud().Add(EmployeeData);
            if(data != null)
            {
                return mapper.Map<EmployeeDTO>(data);
            }
            return null;
        }
        public EmployeeDTO UpdateData(EmployeeDTO employee)
        {
            //var dataAccessFactory = new DataAccessFactory(db);
            var isAvailable = daf.EmployeeCrud().Get(employee.EmployeeCode);
            if (isAvailable)
            {
                return null;
            }
            else
            {
                var config = Service.Mapping<EmployeeDTO, Employee>();
                var mapper = new Mapper(config);
                var data = mapper.Map<Employee>(employee);
                var result = daf.EmployeeCrud().Update(data);
                var UpdatedInfo=mapper.Map<EmployeeDTO>(result);
                return UpdatedInfo;
            }
        }
        public int? GetData()
        {
            //var dataAccessFactory = new DataAccessFactory(db);
            var config = Service.OneTimeMapping<Employee, EmployeeDTO>();
            var mapper = new Mapper(config);
            var result = daf.EmpInfo().EmpSalary();
            if(result != null)
            {
                var f= mapper.Map<EmployeeDTO>(result);
                return f.EmployeeSalary;
            }
            return null;
        }
        public List<EmployeeDTO> GetHirerarcy(int id)
        {
            //var dataAccessFactory = new DataAccessFactory(db);
            var data = daf.EmployeeCrud().Get(id);
            var result = new List<EmployeeDTO>();
            var config = Service.OneTimeMapping<Employee, EmployeeDTO>();
            var mapper = new Mapper(config);
            var d = mapper.Map<EmployeeDTO>(data);
            result?.Add(d);
            var Id = data;
            if(Id != null)
            {
                while (data.SupervisorId != id)
                {
                     data = daf.EmpHir().GetEmployee(data);
                     var da = mapper.Map<EmployeeDTO>(data);
                     result?.Add(da);
                }
                return result;
            }
            return null;
        }
        public List<EmployeeDTO> Get()
        {
            var config = Service.OneTimeMapping<Employee, EmployeeDTO>();
            var mapper = new Mapper(config);
            var Emp = daf.EmployeeCrud().Get();
            return mapper.Map<List<EmployeeDTO>>(Emp);
        }
    }
}
