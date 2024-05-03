using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.API.Models;
using Server.Core.DTOs;
using Server.Core.Models;
using Server.Core.Services;
using Server.Service;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            var employeeDto = employees.Select(e => _mapper.Map<EmployeeDto>(e)).ToList();
            return Ok(employeeDto);
        }
        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            var employee = await _employeeService.GetEmployeesAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }
        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeePostModel value)
        {
            var newEmployee = await _employeeService.AddEmployeeAsync(_mapper.Map<Employee>(value));
            return Ok(newEmployee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeePostModel employee)
        {
            var updateEmployee = await _employeeService.UpdateEmployeeAsync(id, _mapper.Map<Employee>(employee));
            return Ok(updateEmployee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}
