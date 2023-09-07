﻿using BLL.DTOs;
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
                    var employeeService= new EmployeeService(db);
                    var data = employeeService.AddEmployee(employee);
                    return Ok(data);
                }
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}