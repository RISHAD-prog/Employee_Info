﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEmpAttendance<CLASS, ID>
    {
        List<CLASS> GetPresentEmployees();
        List<CLASS> GetEmpMonthlyAttendance(string m, int id);
    }
}
