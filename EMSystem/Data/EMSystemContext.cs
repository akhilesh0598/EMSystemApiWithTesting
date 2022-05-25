using EMSystem.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Data
{
    public class EMSystemContext:DbContext
    {
        public EMSystemContext(DbContextOptions<EMSystemContext> options):base(options)
        {

        }
        public DbSet<EmployeeDTO> Employees { get; set; }
        public DbSet<DepartmentDTO> Departments { get; set; }


    }
}
