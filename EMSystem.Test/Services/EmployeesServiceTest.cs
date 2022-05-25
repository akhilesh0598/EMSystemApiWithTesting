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
            
            Assert.Throws<IdFoundException>(() => employeesService.Add(EmployeeRequestData.GetEmployeeRequestWhenEmailIdExist()));

        }
        [Fact]
        public void AddWhenEmailIdNotExistAndDepartmentIdNotExist()
        {
            
            var employeesService = new EmployeesService(EmployeesRepositoryMock.employeeRepositoryMock.Object, DepartmentsRepositoryMock.departmentsRepositoryMock.Object);

            Assert.Throws<WrongDataInBodyException>(() => employeesService.Add(EmployeeRequestData.GetEmployeeRequestWhenEmailIdNotExistAndDepartmentIdNotExist()));

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
            Assert.Throws<IdNotFoundException>(() => employeesService.GetById("aman@test.com"));

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
            Assert.Throws<IdNotFoundException>(() => employeesService.CountByDepartmentName("Sales"));
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
