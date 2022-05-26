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
    class DepartmentsRepositoryMock
    {
        public static Mock<IDepartmentsRepository> departmentsRepositoryMock = new Mock<IDepartmentsRepository>();
        public static void MockResources(EMSystemContext context)
        {
            departmentsRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns((int departmentId) =>
            {
                return context.Departments.FirstOrDefault(d => d.Id == departmentId);
            });
            departmentsRepositoryMock.Setup(x => x.GetByName(It.IsAny<string>())).Returns((string departmentName) =>
            {
                return context.Departments.FirstOrDefault(d => d.Name == departmentName);
            });
        }
    }
}
