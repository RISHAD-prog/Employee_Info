using BLL.Services;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpMonthlyAtdController : ControllerBase
    {
        private readonly EmployeeEntities db;

        public EmpMonthlyAtdController(EmployeeEntities _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetMonthlyAtd()
        {
            try
            {
                var employeeService = new EmpMonthlyAttendanceService(db);
                var data = employeeService.MonthlyAttendance();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
