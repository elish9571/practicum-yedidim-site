using Server.Core.Models;
using Server.Core.Repositories;
using Server.Core.Services;


namespace Server.Service
{
    public class JobPositionService : IJobPositionService
    {
        private readonly IJobPositionRepository _jobPositionRepository;
        public JobPositionService(IJobPositionRepository jobPositionRepository)
        {
            _jobPositionRepository = jobPositionRepository;
        }
        public async Task<List<JobPosition>> GetAllJobsAsync()
        {
            return await _jobPositionRepository.GetAllJobsAsync();
        }
        public async Task<JobPosition> AddJobAsync(JobPosition job)
        {
            return await _jobPositionRepository.AddJobAsync(job);
        }
        public async Task<JobPosition> UpdateJobAsync(int id, JobPosition job)
        {
            return await _jobPositionRepository.UpdateJobAsync(id, job);
        }
        public async Task DeleteJobAsync(int empId, int positionId)
        {
            await _jobPositionRepository.DeleteJobAsync(empId,positionId);
        }



    }
}
