using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEmpHir<CLASS, ID>
    {
        CLASS GetEmployee(ID id);   
    }
}
