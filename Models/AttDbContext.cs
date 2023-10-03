using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_API.Models
{
    public class AttDbContext :DbContext
    {
        public AttDbContext()
        {
        }

        public AttDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
