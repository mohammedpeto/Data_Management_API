using First_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_API.Services
{
    public interface IDepartmentRepo
    {
        public Department GetByID(int id);
        public List<Department> GetAll();

        public int Create(Department d);
        public int Update(int id, Department d);
        public int Delete(int id);

    }
}
