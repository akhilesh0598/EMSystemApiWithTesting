using EMSystem.Models.DB;
using EMSystem.Repositories;
using EMSystem.Test.MockData;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSystem.Test.MockResources
{
    class EmployeesRepositoryMock
    {
        public static Mock<IEmployeesRepository> employeeRepositoryMock = new Mock<IEmployeesRepository>();

        public static readonly IEnumerable<EmployeeDTO> employeeDTOs = EmployeeDTOData.employeeDTOs;
        public static void MockResources()
        {
            employeeRepositoryMock.Setup(x => x.Create(It.IsAny<EmployeeDTO>()));
            employeeRepositoryMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((string emailId) =>
              {
                  return employeeDTOs.FirstOrDefault(e => e.EmailId == emailId);
              });
            employeeRepositoryMock.Setup(x => x.CountByDepartmentName(It.IsAny<string>())).Returns((string departmentName)=>
            {
                return employeeDTOs.Where(e => e.Department.Name == departmentName).Count();
            });

        }
    }
}
