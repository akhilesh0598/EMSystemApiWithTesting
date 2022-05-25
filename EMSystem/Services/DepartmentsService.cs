using EMSystem.Models.Responses;
using EMSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly IDepartmentsRepository _departmentsRepository;

        public DepartmentsService(IDepartmentsRepository departmentsRepository)
        {
            _departmentsRepository = departmentsRepository;
        }
        public DepartmentResponse GetById(int departmentId)
        {
            var department = _departmentsRepository.GetById(departmentId);
            if (department == null)
                return null;
            return new DepartmentResponse()
            {
                Id=department.Id,
                Name = department.Name,
                Address=department.Address
            };
        }
        public DepartmentResponse GetByName(string departmentName)
        {
            var department = _departmentsRepository.GetByName(departmentName);
            if (department == null)
                return null;
            return new DepartmentResponse()
            {
                Id = department.Id,
                Name = department.Name,
                Address = department.Address
            };
        }
    }
}
