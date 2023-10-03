using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First_API.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string Manager { get; set; }

     
        public virtual List<Employee> Employees { get; set; }



    }
}
