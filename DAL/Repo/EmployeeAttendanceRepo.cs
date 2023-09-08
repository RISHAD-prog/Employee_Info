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
    internal class EmployeeAttendanceRepo : IRepo<EmployeeAttendance, int, EmployeeAttendance, string>
    {
        private readonly EmployeeEntities db;

        public EmployeeAttendanceRepo(EmployeeEntities _db)
        {
            db = _db;
        }
        
        public EmployeeAttendance Add(EmployeeAttendance obj)
        {
            db.employeeAttendances.Add(obj);
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

        public bool Get(string id)
        {
            throw new NotImplementedException();
        }

        public EmployeeAttendance Get(int id)
        {
            throw new NotImplementedException();
        }

        /*public List<EmployeeAttendance> GetAttendance()
        {
            return db.employeeAttendances.Where(x => x.IsAbsent == 0).ToList();
        
        }*/

        

        public EmployeeAttendance Update(EmployeeAttendance obj)
        {
            throw new NotImplementedException();
        }
    }
}
