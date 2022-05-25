using EMSystem.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSystem.Test.MockData
{
    class EmployeeResponseData
    {
        public static EmployeeResponse GetEmployeeResponse()
        {
            return new EmployeeResponse()
            {
                EmailId = "akhil@test.com",
                FirstName = "akhil",
                LastName = "chaurasiya",
                ContactNumber = "9891618600",
                Qualification = "BTech",
                Department = new DepartmentResponse()
                {
                    Id = 1,
                    Name = "IT",
                    Address = "Pune"
                }
            };
        }
    }
}
