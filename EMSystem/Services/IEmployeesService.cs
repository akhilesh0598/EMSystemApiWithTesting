using EMSystem.Models.Requets;
using EMSystem.Models.Responses;
using System.Collections.Generic;

namespace EMSystem.Services
{
    public interface IEmployeesService
    {
        void Add(EmployeeRequest employeeRequest);
        int CountByDepartmentName(string departmentName);
        EmployeeResponse GetById(string employeeEmailId);
    }
}