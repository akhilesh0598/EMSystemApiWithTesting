using EMSystem.Exceptions;
using EMSystem.Models.Requets;
using EMSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IDepartmentsService _departmentsService;

        public EmployeesController(IEmployeesService employeesService, IDepartmentsService departmentsService)
        {
            _employeesService = employeesService;
            _departmentsService = departmentsService;
        }

        // GET: api/<EmployeeController>
        [HttpGet("{EmailId}")]
        public IActionResult Get([FromRoute]EmailIdRequest emailIdRequest)
        {
            try
            {
                var employee = _employeesService.GetById(emailIdRequest.EmailId);
                return Ok(employee);
            }
            catch(IdNotFoundException ex)
            {
                return NotFound(ex.Message);

            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeRequest employeeRequest)
        {
            try
            {
                _employeesService.Add(employeeRequest);
                return Created("~api/employees/", new { message = "successfully created" });
            }
            catch (IdFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(WrongDataInBodyException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{departmentName}")]
        public IActionResult CountByDepartmentName(string departmentName)
        {
            try
            {
                var employees = _employeesService.CountByDepartmentName(departmentName);
                return Ok(employees);
            }
            catch (IdNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
