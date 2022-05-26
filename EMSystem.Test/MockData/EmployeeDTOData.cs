using EMSystem.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSystem.Test.MockData
{
    class EmployeeDTOData
    {
        public static readonly IEnumerable<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>()
        {
            new EmployeeDTO()
            {
                EmailId = "akhil@test.com",
                FirstName = "akhil",
                LastName = "chaurasiya",
                ContactNumber = "9891618600",
                Qualification = "BTech",
                DepartmentId = 1,
                Department=new DepartmentDTO()
                {
                    Id=1,
                    Name="IT",
                    Address="Pune"
                }
            },
            new EmployeeDTO()
            {
                EmailId = "akhil2@test.com",
                FirstName = "akhil",
                LastName = "chaurasiya",
                ContactNumber = "9891618600",
                Qualification = "BTech",
                DepartmentId = 1,
                Department=new DepartmentDTO()
                {
                    Id=1,
                    Name="IT",
                    Address="Pune"
                }
            },
        };
    }
}
