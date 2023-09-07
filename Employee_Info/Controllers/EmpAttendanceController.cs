using BLL.DTOs;
using BLL.Services;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpAttendanceController : ControllerBase
    {
        private readonly EmployeeEntities db;

        public EmpAttendanceController(EmployeeEntities _db)
        {
            db = _db;
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeAttendanceDTO employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employeeService = new EmployeeAttendanceService(db);
                    var data = employeeService.AddEmployeeAttendance(employee);
                    return Ok(data);
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
