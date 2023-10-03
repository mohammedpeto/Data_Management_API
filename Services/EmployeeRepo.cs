using First_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_API.Services
{
    public class EmployeeRepo : IEmplloyeeRepo
    {
        public EmployeeRepo(AttDbContext _context)
        {
            context = _context;
        }

        public AttDbContext context { get; }

        public int Create(Employee e)
        {
            context.Employees.Add(e);
            int roe = context.SaveChanges();
            return roe;
        }

        public int Delete(int id)
        {
            try
            {
                context.Employees.Remove(context.Employees.FirstOrDefault(e => e.ID == id));
                int row = context.SaveChanges();
                return row;
            }
            catch(Exception e)
            {
                return -1;
            }
           
        }

        public List<Employee> GetAll()
        {
            return context.Employees.Include(e=>e.Department).ToList();
        }

        public Employee GetByID(int id)
        {
            return context.Employees.Include(e=>e.Department).FirstOrDefault(e => e.ID == id);
        }

        public int Update(int id, Employee e)
        {
            Employee emp = context.Employees.FirstOrDefault(em => em.ID == id);
            if(emp != null)
            {
                emp.Name = e.Name;
                emp.Salary = e.Salary;
                emp.Address = emp.Address;
                emp.Phone = e.Phone;

                int row = context.SaveChanges();
                return row;
            }
            return -1;
        }
    }
}
