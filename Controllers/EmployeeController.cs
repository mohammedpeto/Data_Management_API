using First_API.Models;
using First_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_API.DTO;

namespace First_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController(IEmplloyeeRepo _emplloyeeRepo)
        {
            EmplloyeeRepo = _emplloyeeRepo;
        }

        public IEmplloyeeRepo EmplloyeeRepo { get; }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            List<Employee> emplist = EmplloyeeRepo.GetAll();
           
            
            
            return Ok(emplist);
        }

        [HttpGet("{id:int}",Name ="GetOneEmployeeRoute")]
        public IActionResult GetEmployeeByID(int id)
        {
            Employee em = EmplloyeeRepo.GetByID(id);
            EmployeeDepartmentDTO empdep = new EmployeeDepartmentDTO();
            empdep.EmployeeID = em.ID;
            empdep.EmployeeName = em.Name;
            empdep.EmployeePhone = em.Phone;
            empdep.EmployeeAddress = em.Address;
            empdep.EmployeeSalarry = em.Salary;
            empdep.DepartmentName = em.Department.Name;
            return Ok(empdep);
        }

        [HttpPost]
        public IActionResult Create(Employee e)
        {
            if(ModelState.IsValid == true)
            {
                EmplloyeeRepo.Create(e);
                string url = Url.Link("GetOneEmployeeRoute", new { id = e.ID });
                return Created(url, e);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute]int id ,[FromBody]Employee e)
        {
            if(ModelState.IsValid == true)
            {
                EmplloyeeRepo.Update(id, e);
                return StatusCode(204, "Data Updated");
            }
            return BadRequest(ModelState);

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if(ModelState.IsValid == true)
            {
                EmplloyeeRepo.Delete(id);
                return StatusCode(204, "Data Deletted");
            }
            return BadRequest(ModelState);
        }

    }
}
