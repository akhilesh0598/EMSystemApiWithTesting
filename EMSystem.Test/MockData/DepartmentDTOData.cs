using EMSystem.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSystem.Test.MockData
{
    class DepartmentDTOData
    {
        public static readonly IEnumerable<DepartmentDTO> departmentDTOs = new List<DepartmentDTO>()
        {
            new DepartmentDTO()
            {
                Id=1,
                Name="IT",
                Address="Pune"
            },
            new DepartmentDTO()
            {
                Id=2,
                Name="Finance",
                Address="Mumbai"
            },
        };
    }
}
