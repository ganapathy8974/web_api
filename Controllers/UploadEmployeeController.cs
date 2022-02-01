using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.IO;
using ExcelDataReader;
using webapi.model;
using webapi.dao;

namespace webapi.Controllers
{
    [Route("employee/upload")]
    [ApiController]
    public class UploadEmployeeController : ControllerBase
    {          
        [HttpPost]
        public void Post(IFormFile file)
        {            
            using (var stream = new MemoryStream())
            {
                Employee emp = new Employee();
                EmployeeDTO empDTO = new EmployeeDTO();
                file.CopyTo(stream);
                stream.Position = 0;
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        emp.name = reader.GetValue(0).ToString();
                        emp.age = Convert.ToInt16(reader.GetValue(1).ToString());
                        emp.address = reader.GetValue(2).ToString();
                        emp.email = reader.GetValue(3).ToString();
                        emp.mobile = reader.GetValue(4).ToString();
                        emp.department = reader.GetValue(5).ToString();
                        emp.salary = Convert.ToDecimal(reader.GetValue(6).ToString());
                        empDTO.addEmployee(emp);
                    }
                }
            }
        }
        
    }
}
