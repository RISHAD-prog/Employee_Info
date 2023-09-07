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
}
