using EMSystem.Exceptions;
using EMSystem.Models.DB;
using EMSystem.Models.Requets;
using EMSystem.Models.Responses;
using EMSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IDepartmentsRepository _departmentsRepository;
        private readonly IEmployeesRepository _employeesRepository;
        public EmployeesService(IEmployeesRepository employeesRepository, IDepartmentsRepository departmentsRepository)
        {
            _employeesRepository = employeesRepository;
            _departmentsRepository = departmentsRepository;
        }
        public void Add(EmployeeRequest employeeRequest)
        {
            
            var employee = _employeesRepository.GetById(employeeRequest.EmailId);
            if (employee != null)
                throw new IdFoundException($"In Employee Entity EmailId = '{employeeRequest.EmailId}' already exist");
            var department = _departmentsRepository.GetById(employeeRequest.DepartmentId);
            if (department == null)
                throw new WrongDataInBodyException($"In Department Entity Id = '{employeeRequest.DepartmentId}' not found");
            var employeeDTO = new EmployeeDTO()
            {
                EmailId = employeeRequest.EmailId,
                FirstName = employeeRequest.FirstName,
                LastName = employeeRequest.LastName,
                Qualification = employeeRequest.Qualification,
                ContactNumber = employeeRequest.ContactNumber,
                DepartmentId= employeeRequest.DepartmentId,
            };
            _employeesRepository.Create(employeeDTO);
        }
        public EmployeeResponse GetById(string employeeEmailId)
        {
            var employeeDTO = _employeesRepository.GetById(employeeEmailId);
            if (employeeDTO == null)
                throw new IdNotFoundException($"In Employee Entity Id = '{employeeEmailId}' not found");
            return new EmployeeResponse()
            {
                EmailId = employeeDTO.EmailId,
                FirstName=employeeDTO.FirstName,
                LastName=employeeDTO.LastName,
                Qualification=employeeDTO.Qualification,
                ContactNumber=employeeDTO.ContactNumber,
                Department=new DepartmentResponse()
                {
                    Id=employeeDTO.Department.Id,
                    Name=employeeDTO.Department.Name,
                    Address=employeeDTO.Department.Address
                }
            };
        }
        public int CountByDepartmentName(string departmentName)
        {
            var department = _departmentsRepository.GetByName(departmentName);
            if (department == null)
                throw new IdNotFoundException($"In Department Entity Name = '{departmentName}' not found");
            var employeesCount = _employeesRepository.CountByDepartmentName(departmentName);
            return employeesCount;
        }

    }
}
