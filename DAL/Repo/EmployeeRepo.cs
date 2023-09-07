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
    internal class EmployeeRepo : IRepo<Employee, int, Employee>
    {
        private readonly EmployeeEntities db;

        public EmployeeRepo(EmployeeEntities _db)
        {
            db = _db;
        }
        public  Employee Add(Employee obj)
        {
            db.Employees.Add(obj);
            var d= db.SaveChanges();
            if (d > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public  List<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public  Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public  Employee Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}
