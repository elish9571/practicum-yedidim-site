using Server.Core.Models;


namespace Server.Core.Repositories
{
    public interface IJobPositionRepository
    {
        Task<List<JobPosition>> GetAllJobsAsync();

        Task<JobPosition> AddJobAsync(JobPosition job);

        Task<JobPosition> UpdateJobAsync(int id, JobPosition job);

        Task DeleteJobAsync(int id);
    }
}
