using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repo;

namespace DAL;
public class DataAccessFactory
{
    private readonly EmployeeEntities db;

    public DataAccessFactory(EmployeeEntities _db)
    {
        db = _db;
    }
    public IRepo<Employee, int, Employee, string> EmployeeCrud()
    {
        return new EmployeeRepo(db);
    }
    public IEmpInfo<Employee> EmpInfo()
    {
        return new EmployeeRepo(db);
    }
    public IRepo<EmployeeAttendance, int, EmployeeAttendance, string> EmployeeAttendanceCrud()
    {
        return new EmployeeAttendanceRepo(db);
    }
    public ISingleEmpdetail<EmployeeAttendance> singleEmpdetail()
    {
        return new EmployeeAttendanceRepo(db);
    }
    public IEmpAttendance<Employee, int> GetEmployee()
    {
        return new EmployeeRepo(db);
    }
    public IEmpAttendance<EmployeeAttendance, int> GetEmployeeAttendance()
    {
        return new EmployeeAttendanceRepo(db);
    }
    public IEmpHir<Employee, Employee> EmpHir()
    {
        return new EmployeeRepo(db);
    }
    public IUser<User, string> User()
    {
        return new UserRepo(db);
    }
}
