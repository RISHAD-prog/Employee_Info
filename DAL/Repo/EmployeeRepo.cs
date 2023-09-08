using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class EmployeeRepo : IRepo<Employee, int, Employee,string>, IEmpInfo<Employee>, IEmpAttendance<Employee, int>
    {
        private readonly EmployeeEntities db;

        public EmployeeRepo(EmployeeEntities _db)
        {
            db = _db;
        }
        public  Employee Add(Employee obj)
        {
            db.Employees.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Employee EmpSalary()
        {
            var thirdHighest= db.Employees.OrderByDescending(x=> x.EmployeeSalary).
                Skip(2).Take(1).FirstOrDefault();
            if(thirdHighest != null)
            {
                return thirdHighest;
            }
            return null;
        }

        public bool Get(string EmpCode)
        {
            var d = db.Employees.SingleOrDefault(x => x.EmployeeCode.Equals(EmpCode));
            if(d == null)
            {
                return false;
            }
            return true;
        }

        public Employee Get(int id)
        {
            return db.Employees.SingleOrDefault(x => x.EmployeeId.Equals(id));
        }

        public  Employee Update(Employee obj)
        {
            var data = Get(obj.EmployeeId);
            db.Entry(data).CurrentValues.SetValues(obj);
            var d = db.SaveChanges();
            if(d > 0)
            {
                return data;
            }
            return null;
        }
        public List<Employee> GetPresentEmployees()
        {
            var emp = db.Employees;
            var empAtd = db.employeeAttendances;
            // here, the condition is set a if any condition retuns false it coverts to true but If
            // one row matches the condtion then it returns false. 
            var employeesWithPerfectAttendance = emp
                .Where(e => !empAtd.Where(a => e.EmployeeId == a.EmployeeId)
                .Any(a => a.IsPresent != 1 || a.IsAbsent != 0))
                .OrderByDescending(e => e.EmployeeSalary)
                .ToList();

            return employeesWithPerfectAttendance;
        }

        
    }
}
