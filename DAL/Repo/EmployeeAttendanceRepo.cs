﻿using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class EmployeeAttendanceRepo : IRepo<EmployeeAttendance, int, EmployeeAttendance, string>, ISingleEmpdetail<EmployeeAttendance>, IEmpAttendance<EmployeeAttendance, int>
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
            return null!;
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

            var data = db.employeeAttendances
                .Where(x => x.EmployeeId == id)
                .GroupBy(x => x.EmployeeId)
                .Select(g => new EmployeeAttendance
                {
                    EmployeeId = g.Key,
                    IsPresent = g.Count(x => x.IsPresent == 1),
                    IsAbsent = g.Count(x => x.IsAbsent == 1),
                    IsOffDay = g.Count(x => x.IsOffDay == 1),
                    AttendanceDate = g.Select(x => x.AttendanceDate).FirstOrDefault()
                })
                .FirstOrDefault();

            return data!;
        }


        public List<EmployeeAttendance> Get()
        {
            return db.employeeAttendances.ToList();
        }

        public List<EmployeeAttendance> GetAttendance(int empid)
        {
            var data = db.employeeAttendances.Where(e=> e.EmployeeId == empid).ToList();
            return data;
            
        }

        public List<EmployeeAttendance> GetEmpMonthlyAttendance(string m, int id)
        {
            int month = DateTime.ParseExact(m, "MMMM", CultureInfo.CurrentCulture).Month;


            var match = db.employeeAttendances.Where(e=>
            (e.AttendanceDate.Month == month) && 
            (e.EmployeeId.Equals(id)))     
            .OrderBy(x=> x.AttendanceDate)
            .ToList();
            return match;
        }

        public List<EmployeeAttendance> GetPresentEmployees()
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
