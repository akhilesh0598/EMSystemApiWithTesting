using EMSystem.Data;
using EMSystem.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Repositories
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        private readonly EMSystemContext _context;

        public DepartmentsRepository(EMSystemContext context)
        {
            _context = context;
        }
        public DepartmentDTO GetById(int departmentId)
        {
            return _context.Departments.Find(departmentId);
        }
        public DepartmentDTO GetByName(string departmentName)
        {
            return _context.Departments.FirstOrDefault(d => d.Name == departmentName);
        }
    }
}
