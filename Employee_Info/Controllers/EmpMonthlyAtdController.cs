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
        private readonly EmpMonthlyAttendanceService aserv;
        public EmpMonthlyAtdController(EmpMonthlyAttendanceService _aserv)
        {
            this.aserv = _aserv;
        }
        /*[HttpGet]
        public IActionResult GetMonthlyAtd()
        {
            try
            {
                //var employeeService = new EmpMonthlyAttendanceService(db);
                var data = aserv.MonthlyAttendance();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/

        [HttpGet]
        public IActionResult GetWeeklyAtd(String month, int id)
        {
            try
            {
                var result = aserv.empMonthlyAttendance(month, id);
                return Ok(result);
            }
            catch(Exception e) { 
                return BadRequest(e.Message);
            }
        }
    }
}
