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
        private readonly IJobPositionService _JobPositionService;
        //private readonly IEmployeeJobPositionService _employeeJobPositionService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IJobPositionService jobPositionService, IMapper mapper)
        {
            _employeeService = employeeService;
            _JobPositionService = jobPositionService;
            //_employeeJobPositionService = employeeJobPositionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            var employeeDto = employees.Select(e => _mapper.Map<EmployeeDto>(e));
            return Ok(employeeDto);
        }

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

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeePostModel value)
        {
            var empToAdd = new Employee
            {
                FirstName = value.FirstName,
                LastName = value.LastName,
                Tz = value.Tz,
                BirthDate = value.BirthDate,
                IsMale = value.IsMale,
                BeginningOfWork = value.BeginningOfWork,
                IsDeleted = false
            };
            empToAdd.JobPositions = new List<EmployeeJobPosition>();
            for (int i = 0; i < value.JobPositions.Count; i++)
            {
                var jobToAdd = new EmployeeJobPosition
                {
                    Name = value.JobPositions[i].Name,
                    Start = value.JobPositions[i].Start,
                    IsManagementRole = value.JobPositions[i].IsManagementRole,
                    IsActive = true
                };
                empToAdd.JobPositions.Add(jobToAdd);
            }
            return Ok(await _employeeService.AddEmployeeAsync(empToAdd));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeePostModel employee)
        {
            var updateEmployee = await _employeeService.UpdateEmployeeAsync(id, _mapper.Map<Employee>(employee));
            return Ok(updateEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}

/*                             positions                                     */
/*                             positions                                     */
/*                             positions                                     */


//        [HttpGet("{id}/position")]
//        public async Task<ActionResult<IEnumerable<JobPositionDto>>> GetPositions(int id)
//        {
//            var employeePositions = await _employeeJobPositionService.GetEmployeeJobsAsync(id);

//            //var positionDtos = employeePositions.Select(p => _mapper.Map<JobPositionDto>(p));
//            var positionDtos = _mapper.Map<IEnumerable<JobPositionDto>>(employeePositions);
//            return Ok(positionDtos);
//        }

//        [HttpPost("{id}/position")]
//        public async Task<ActionResult> AddPosition(int empId, [FromBody] EmployeeJobPositionPostModel empPosition)
//        {
//            var newEmpPosition = await _employeeJobPositionService.AddPositionToEmployeeAsync(empId, _mapper.Map<EmployeeJobPosition>(empPosition));
//            if (newEmpPosition == null)
//            {
//                return null;
//            }
//            return Ok(newEmpPosition);
//        }

//        [HttpGet("{id}/position/{positionId})")]
//        public async Task<ActionResult> GetPositionById(int employeeId, int positionId)
//        {
//            var empPosition = await _employeeJobPositionService.GetEmployeeJobsByIdAsync(employeeId, positionId);
//            var empPositionDto = _mapper.Map<EmployeeJobPositionDto>(empPosition);
//            return Ok(empPositionDto);

//        }

//        [HttpPut("{id}/position/{positionId}")]
//        public async Task<ActionResult> UpdatePosition(int employeeId, int positionId, [FromBody] EmployeeJobPositionPostModel updateEmpPosition)
//        {
//            var updatePosition = await _employeeJobPositionService.UpdatePositionToEmployeeAsync(employeeId, positionId, _mapper.Map<EmployeeJobPosition>(updateEmpPosition));
//            if (updatePosition == null)
//            {
//                return Ok(null);
//            }
//            return Ok(updatePosition);
//        }
//          [HttpDelete("{id}/position/{positionId}")]
//          public async Task<ActionResult> DeletePositionFromEmployee(int empId, int positionId)
//          {
//            await _employeeService.DeleteEmployeePositionAsync(empId, positionId);
//            return Ok();
//}
//       
//    }
//}


