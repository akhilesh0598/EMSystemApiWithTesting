using EMSystem.Models.Requets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSystem.Test.MockData
{
    class EmployeeRequestData
    {
        public static EmployeeRequest GetEmployeeRequestWhenEmailIdExist()
        {
            return new EmployeeRequest()
            {
                EmailId = "akhil@test.com",
                FirstName = "akhil",
                LastName = "chaurasiya",
                ContactNumber = "9891618600",
                Qualification = "BTech",
                DepartmentId = 1,
            };
        }
        public static EmployeeRequest GetEmployeeRequestWhenEmailIdNotExistAndDepartmentIdNotExist()
        {
            return new EmployeeRequest()
            {
                EmailId = "akhilesh@test.com",
                FirstName = "akhil",
                LastName = "chaurasiya",
                ContactNumber = "9891618600",
                Qualification = "BTech",
                DepartmentId = 3,
            };
        }
        public static EmployeeRequest GetEmployeeRequestWhenAllIsGood()
        {
            return new EmployeeRequest()
            {
                EmailId = "akhilesh@test.com",
                FirstName = "akhil",
                LastName = "chaurasiya",
                ContactNumber = "9891618600",
                Qualification = "BTech",
                DepartmentId = 1,
            };
        }
    }
}
