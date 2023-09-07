using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS, ID, RETURNTYPE, empId>
    {
        bool Get(empId id);
        RETURNTYPE Get(ID id);
        RETURNTYPE Add(CLASS obj);
        bool Delete(/*CLASS obj*/ ID id);
        RETURNTYPE Update(CLASS obj);
    }
}
