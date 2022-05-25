using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Models.Responses
{
    public class EmployeeResponse
    {
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        public string ContactNumber { get; set; }
        public DepartmentResponse Department { get; set; }
    }
}
