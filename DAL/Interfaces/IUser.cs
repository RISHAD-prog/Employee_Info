using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUser<CLASS, RETURNTYPE>
    {
        CLASS? CreatePasswordHash(CLASS cLASS);
        RETURNTYPE? GetLoginDetails(string name);
        CLASS? GetRegisterDetails(string name);
    }
}
