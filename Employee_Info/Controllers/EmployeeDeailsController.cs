using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeDeailsController : ControllerBase
    {
        private readonly EmployeeService edb;
        public EmployeeDeailsController(EmployeeService edb)
        {
            this.edb = edb;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var ans = edb.Get();
                return Ok(ans);
            }
            catch(Exception ex) { 
                return  BadRequest(ex.Message);
            }
        } 
    }
}
