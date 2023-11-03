using BLL.DTOs;
using BLL.Services;
using DAL.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService edb;
        public EmployeesController(EmployeeService edb)
        {
            this.edb = edb;
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeDTO employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var employeeService = new EmployeeService(db);
                    var data = edb.AddEmployee(employee);
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
               // var employeeService = new EmployeeService(db);
                var result = edb.UpdateData(employee);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            try
            {
                //var employeeService = new EmployeeService(db);
                var result = edb.GetData();
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e?.Message);
            }
        }
        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetEmpHir([FromRoute] int Id)
        {
            try
            {
                //var employeeService = new EmployeeService(db);
                var result = edb.GetHirerarcy(Id);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
