using First_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_API.Services
{
   public interface IEmplloyeeRepo
    {
        public List<Employee> GetAll();
        public Employee GetByID(int id);
        public int Create(Employee e);
        public int Update(int id, Employee e);
        public int Delete(int id);
    }
}
