using EMSystem.Exceptions;
using EMSystem.Models.DB;
using EMSystem.Models.Responses;
using EMSystem.Repositories;
using EMSystem.Services;
using EMSystem.Test.MockData;
using EMSystem.Test.MockResources;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;

namespace EMSystem.Test.Services
{
    public class EmployeesServiceTest
    {
        public EmployeesServiceTest()
        {
            EmployeesRepositoryMock.MockResources();
            DepartmentsRepositoryMock.MockResources();
        }
        //Add method testing
        
        [Fact]
        public void AddWhenEmailIdAlreadyExist()
        {
            var employeesService = new EmployeesService(EmployeesRepositoryMock.employeeRepositoryMock.Object, DepartmentsRepositoryMock.departmentsRepositoryMock.Object);
            var ex = Assert.Throws<IdFoundException>(() => employeesService.Add(EmployeeRequestData.GetEmployeeRequestWhenEmailIdExist()));
            Assert.Equal("In Employee Entity EmailId = 'akhil@test.com' already exist", ex.Message);
        }
        [Fact]
        public void AddWhenEmailIdNotExistAndDepartmentIdNotExist()
        {
            var employeesService = new EmployeesService(EmployeesRepositoryMock.employeeRepositoryMock.Object, DepartmentsRepositoryMock.departmentsRepositoryMock.Object);
            var ex=Assert.Throws<WrongDataInBodyException>(() => employeesService.Add(EmployeeRequestData.GetEmployeeRequestWhenEmailIdNotExistAndDepartmentIdNotExist()));
            Assert.Equal("In Department Entity Id = '3' not found", ex.Message);
        }
        [Fact]
        public void AddWhenAllIsGood()
        {
            var employeesService = new EmployeesService(EmployeesRepositoryMock.employeeRepositoryMock.Object, DepartmentsRepositoryMock.departmentsRepositoryMock.Object);
            employeesService.Add(EmployeeRequestData.GetEmployeeRequestWhenAllIsGood());
            EmployeesRepositoryMock.employeeRepositoryMock.Verify(x => x.Create(It.IsAny<EmployeeDTO>()), Times.Exactly(1));
        }
        //GetById Method Testing
        [Fact]
        public void GetByIdWhenIdNotFound()
        {
            
            var employeesService = new EmployeesService(EmployeesRepositoryMock.employeeRepositoryMock.Object, DepartmentsRepositoryMock.departmentsRepositoryMock.Object);
            var ex=Assert.Throws<IdNotFoundException>(() => employeesService.GetById("aman@test.com"));
            Assert.Equal("In Employee Entity Id = 'aman@test.com' not found", ex.Message);
        }
        [Fact]
        public void GetByIdWhenIdFound()
        {
            var employeesService = new EmployeesService(EmployeesRepositoryMock.employeeRepositoryMock.Object, DepartmentsRepositoryMock.departmentsRepositoryMock.Object);
            var result=employeesService.GetById("akhil@test.com");
            var res1 = JsonConvert.SerializeObject(result);
            var res2 = JsonConvert.SerializeObject(EmployeeResponseData.GetEmployeeResponse());
            Assert.Equal(res2,res1);
        }
        //CountByDepartmentName method
        [Fact]
        public void CountByDepartmentName_WhenDepartmentNameNotExist()
        {
            var employeesService = new EmployeesService(EmployeesRepositoryMock.employeeRepositoryMock.Object, DepartmentsRepositoryMock.departmentsRepositoryMock.Object);
            var ex=Assert.Throws<IdNotFoundException>(() => employeesService.CountByDepartmentName("Sales"));
            Assert.Equal("In Department Entity Name = 'Sales' not found", ex.Message);
        }
        [Fact]
        public void CountByDepartmentName_WhenDepartmentNameExist()
        {
            var employeesService = new EmployeesService(EmployeesRepositoryMock.employeeRepositoryMock.Object, DepartmentsRepositoryMock.departmentsRepositoryMock.Object);
            var result=employeesService.CountByDepartmentName("IT");
            Assert.Equal(2, result);
        }
    }
}
