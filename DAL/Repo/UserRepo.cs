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
    internal class UserRepo : IUser<User, string>
    {
        private readonly EmployeeEntities db;

        public UserRepo(EmployeeEntities _db)
        {
            db = _db;
        }
        public User? CreatePasswordHash(User cLASS)
        {
            db.users.Add(cLASS);
            if (db.SaveChanges() > 0)
            {
                return cLASS;
            }
            return null;
        }

        public string? GetLoginDetails(string name)
        {
            var result = db.users.SingleOrDefault(x => x.UserName == name);
            if(result != null)
            {
                return result.UserName;
            }
            return null;
        }
        public User? GetRegisterDetails(string name)
        {
            var result = db.users.SingleOrDefault(x => x.UserName == name);
            if(result != null)
            {
                return result;
            }
            return null;
        }
    }
}
