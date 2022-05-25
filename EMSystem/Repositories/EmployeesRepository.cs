using EMSystem.Data;
using EMSystem.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly EMSystemContext _context;
        public EmployeesRepository(EMSystemContext context)
        {
            _context = context;
        }
        public void Create(EmployeeDTO employeeDTO)
        {
            _context.Employees.Add(employeeDTO);
            _context.SaveChanges();
        }
        public EmployeeDTO GetById(string empoyeeEmailId)
        {
            var employee = _context.Employees
                                    .Include(d => d.Department)
                                    .FirstOrDefault(e => e.EmailId == empoyeeEmailId);
            return employee;
        }
        public int CountByDepartmentName(string departmentName)
        {
            var employeesCount = _context.Employees.Include(d => d.Department).Where(e => e.Department.Name == departmentName).Count();
            return employeesCount;
        }
    }
}
