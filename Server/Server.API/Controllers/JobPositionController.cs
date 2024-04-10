using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.API.Models;
using Server.Core.DTOs;
using Server.Core.Models;
using Server.Core.Services;
using Server.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPositionController : ControllerBase
    {
        private readonly IJobPositionService _jobPositionService;
        private readonly IMapper _mapper;
        public JobPositionController(IJobPositionService jobPositionService, IMapper mapper)
        {
            _jobPositionService = jobPositionService;
            _mapper = mapper;
        }

        // GET: api/<JobPositionController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var jobs = await _jobPositionService.GetAllJobsAsync();
            var jobsDto = jobs.Select(job => _mapper.Map<JobPositionDto>(job)).ToList();
            return Ok(jobsDto);
        }


        // GET api/<JobPositionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var jobs = await _jobPositionService.GetAllJobsAsync();
            var jobDto = jobs
                .Where(job => job.Id == id)
                .Select(j => _mapper.Map<JobPositionDto>(j))
                .FirstOrDefault();
            if (jobDto == null)
                return NotFound();
            return Ok(jobDto);
        }

        // POST api/<JobPositionController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] JobPositionPostModel value)
        {
            var jobToAdd = new JobPosition
            {
                Name = value.Name,
                Start = value.Start,
                IsManagementRole = value.IsManagementRole
            };
            await _jobPositionService.AddJobAsync(jobToAdd);
            return NoContent();
        }

        // PUT api/<JobPositionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] JobPositionPostModel value)
        {
            var jobToAdd = new JobPosition
            {
                Name = value.Name,
                Start = value.Start,
                IsManagementRole = value.IsManagementRole
            };
            await _jobPositionService.UpdateJobAsync(id, jobToAdd);
            return NoContent();
        }

        // DELETE api/<JobPositionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _jobPositionService.DeleteJobAsync(id);
            return NoContent();
        }
    }
}
