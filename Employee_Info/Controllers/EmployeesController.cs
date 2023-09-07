using BLL.DTOs;
using BLL.Services;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeEntities db;

        public EmployeesController(EmployeeEntities _db)
        {
            db = _db;
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeDTO employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employeeService = new EmployeeService(db);
                    var data = employeeService.AddEmployee(employee);
                    return Ok(data);
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        public IActionResult UpdateEmployee(EmployeeDTO employee)
        {
            try
            {
                var employeeService = new EmployeeService(db);
                var result = employeeService.UpdateData(employee);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var employeeService = new EmployeeService(db);
                var result = employeeService.GetData();
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e?.Message);
            }
        }
    }
}
