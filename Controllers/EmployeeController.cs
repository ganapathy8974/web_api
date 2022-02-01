using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.dao;
using webapi.model;
using MySql.Data.MySqlClient;
using System.Collections;

namespace webapi.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {        
        [HttpGet]
        public ArrayList Get()
        {
            EmployeeDTO emp = new EmployeeDTO();
            return emp.getAllEmployee();
        }
              
        
        [HttpPost]
        public IActionResult Post([FromBody] Employee employeeData)
        {
            EmployeeDTO emp = new EmployeeDTO();
            if (emp.addEmployee(employeeData))
            {
                return StatusCode(200);
            }
            return StatusCode(404);
        }
       
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employeeData)
        {
            EmployeeDTO emp = new EmployeeDTO();
            if (emp.updateEmployee(employeeData,id))
            {
                return StatusCode(200);
            }
                return StatusCode(404);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EmployeeDTO emp = new EmployeeDTO();
            if (emp.deleteEmployee(id))
            {
                return StatusCode(200);
            }
            return StatusCode(500);
        }
    }
}
