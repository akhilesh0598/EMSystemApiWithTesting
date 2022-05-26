using EMSystem.Data;
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

        public static void MockResources(EMSystemContext context)
        {
            employeeRepositoryMock.Setup(x => x.Create(It.IsAny<EmployeeDTO>()));
            employeeRepositoryMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((string emailId) =>
              {
                  var res=context.Employees.FirstOrDefault(e => e.EmailId == emailId);
                  return res;
              });
            employeeRepositoryMock.Setup(x => x.CountByDepartmentName(It.IsAny<string>())).Returns((string departmentName)=>
            {
                return context.Employees.Where(e => e.Department.Name == departmentName).Count();
            });

        }
    }
}
