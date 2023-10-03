using First_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_API.Services
{
    public class DepartmentRepo : IDepartmentRepo
    {
        public DepartmentRepo(AttDbContext _context)
        {
            context = _context;
        }

        public AttDbContext context { get; }

        public int Create(Department d)
        {
            context.Departments.Add(d);
            int row = context.SaveChanges();
            return row;
        }

        public int Delete(int id)
        {
            context.Departments.Remove(context.Departments.FirstOrDefault(d => d.ID == id));
            int row = context.SaveChanges();
            return row;
        }

        public List<Department> GetAll()
        {
            return context.Departments.Include(d => d.Employees).ToList();
        }

        public Department GetByID(int id)
        {
            return context.Departments.Include(d=>d.Employees).FirstOrDefault(d => d.ID == id);
        }

        public int Update(int id, Department d)
        {
            Department dep = context.Departments.FirstOrDefault(d => d.ID == id);
            if(dep != null)
            {
                dep.Name = d.Name;
                dep.Manager = d.Manager;
                return context.SaveChanges();
            }
            return -1;
        }
    }
}
