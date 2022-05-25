using EMSystem.Models.DB;
using System.Collections.Generic;

namespace EMSystem.Repositories
{
    public interface IEmployeesRepository
    {
        void Create(EmployeeDTO employeeDTO);
        int CountByDepartmentName(string departmentName);
        EmployeeDTO GetById(string empoyeeEmailId);
    }
}