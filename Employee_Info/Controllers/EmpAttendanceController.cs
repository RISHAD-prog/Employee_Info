using BLL.DTOs;
using BLL.Services;
using DAL.EF;
using DAL.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpAttendanceController : ControllerBase
    {
        private readonly EmployeeAttendanceService _eservice;
        public EmpAttendanceController(EmployeeAttendanceService ndb)
        {
            this._eservice = ndb;
        }
        [HttpPost]
        public async  Task<IActionResult> AddEmployee(EmployeeAttendanceDTO employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var employeeService = new EmployeeAttendanceService(db);
                    var data = _eservice.AddEmployeeAttendance(employee);
                    return Ok(data);
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet]

        public async Task<IActionResult> GetAtdEmployee()
        {
            try
            {
                //var employeeService = new EmployeeAttendanceService(db);
                var data = _eservice.GetAttendanceRepot();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]

        public IActionResult GetSingleEmployeeAttendanceReport([FromRoute] int id) {
            try
            {
                var data = _eservice.GetSingleEmployeeAttendance(id);
                return Ok(data);
            }catch (Exception e) { 
                return  BadRequest(e.Message);
            }
        }
        
    }
}
