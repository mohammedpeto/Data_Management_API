using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace First_API.Models
{
    public class Employee
    {
        
        public int ID { get; set; }
        [Required]
        [StringLength(25,MinimumLength =3)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Salary { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public int Phone { get; set; }
            
        [ForeignKey("Department")]
        public int DeptID { get; set; }
       
        public virtual Department Department { get; set; }


    }
}
