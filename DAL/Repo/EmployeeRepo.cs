using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class EmployeeRepo : IRepo<Employee, int, Employee,string>, IEmpInfo<Employee>, IEmpAttendance<Employee, int>, IEmpHir<Employee,Employee>
    {
        private readonly EmployeeEntities db;

        public EmployeeRepo(EmployeeEntities _db)
        {
            db = _db;
        }
        public async Task<Employee> Add(Employee obj)
        {
            await db.Employees.AddAsync(obj);
            if (db.SaveChanges() > 0)
            {
                return (obj);
            }
            return null!;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> EmpSalary()
        {
            var thirdHighest= await db.Employees.OrderByDescending(x=> x.EmployeeSalary).
                Skip(2).Take(1).FirstOrDefaultAsync();
            if(thirdHighest != null)
            {
                return thirdHighest;
            }
            return null!;
        }

        public async Task<bool> Get(string EmpCode)
        {
            var d = await db.Employees.SingleOrDefaultAsync(x => x.EmployeeCode.Equals(EmpCode));
            if(d == null)
            {
                return false;
            }
            return true;
        }

        public Employee Get(int id)
        {
            var res= db.Employees.SingleOrDefault(x => x.EmployeeId.Equals(id));
            return res!;
        }

        public async Task<Employee> Update(Employee obj)
        {
            var data = Get(obj.EmployeeId);
            db.Entry(data).CurrentValues.SetValues(obj);
            var d =await db.SaveChangesAsync();
            if(d > 0)
            {
                return data;
            }
            return null!;
        }
        public List<Employee> GetPresentEmployees()
        {
            var emp = db.Employees;
            var empAtd = db.employeeAttendances;
            // here, the condition is set a if all condition retuns false it coverts to true but If
            // one condition returns true then it converts to false. 
            // Every condition has to be false first before convert.
            var employeesWithPerfectAttendance = emp
                .Where(e => !empAtd.Where(a => e.EmployeeId == a.EmployeeId)
                .Any(a => a.IsPresent != 1 || a.IsAbsent != 0))
                .OrderByDescending(e => e.EmployeeSalary)
                .ToList();

            return employeesWithPerfectAttendance;
        }

        public List<Employee> Get()
        {
            return db.Employees.ToList();
        }

        public Employee GetEmployee(Employee e)
        {
            return db.Employees.SingleOrDefault(x => x.EmployeeId == e.SupervisorId)!;
        }

        public List<Employee> GetEmpMonthlyAttendance(string m, int id)
        {
            throw new NotImplementedException();
        }
    }
}
