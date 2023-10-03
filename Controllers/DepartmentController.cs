using First_API.Models;
using First_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public DepartmentController(IDepartmentRepo _DepRepo)
        {
            DepRepo = _DepRepo;
        }

        public IDepartmentRepo DepRepo { get; }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Department> de = DepRepo.GetAll();
            return Ok(de);
        }

        [HttpGet("{id:int}",Name ="GetDepartmrnt")]
        public IActionResult GetById(int id)
        {
            Department de = DepRepo.GetByID(id);
            return Ok(de);
        }

        [HttpPost]
        public IActionResult Create(Department d)
        {
            if(ModelState.IsValid == true)
            {
                DepRepo.Create(d);
                string url = Url.Link("GetDepartmrnt", new { id = d.ID });
                return Created(url, d);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute]int id , [FromBody]Department d)
        {
            if(ModelState.IsValid == true)
            {
                DepRepo.Update(id, d);
                return StatusCode(204, "Data Updated");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                DepRepo.Delete(id);
                return StatusCode(204, "DataDeleted");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }
        

    }
}
