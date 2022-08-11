#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Mongohosting.Model;
using Mongohosting.Services;

namespace Mongohosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
      //  private readonly EmployeeContextClass _context;

        public EmployeeServices _employeeservices;
        public EmployeeController(EmployeeServices employeeservices)
        {
            //_context = context;
            _employeeservices = employeeservices;
        }
        [HttpGet]
        public string Get()
        {
            return "Hi";
        }
        // GET: api/Employees
        [HttpGet]
        [Route("GetByID")]
        public Employee Get(int id)
        {
            return _employeeservices.Get(id);
        }
        [HttpPost]
        [Route("Add Employee")]
        public void AddEmp(int ID, string Name, string Address)
        {
            _employeeservices.AddEmp(ID, Name, Address);
        }
        [HttpPost]
        [Route("Update Employee")]
        public void UpdateEmp(int ID,string Name)
        {
            _employeeservices.Update(ID,Name);
        }
        [HttpDelete]
        public void DeleteEmp(int ID)
        {
            _employeeservices.Delete(ID);
        }

       
    }
}
