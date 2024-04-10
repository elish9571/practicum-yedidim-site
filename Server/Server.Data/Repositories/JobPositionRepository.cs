using Microsoft.EntityFrameworkCore;
using Server.Core.Models;
using Server.Core.Repositories;


namespace Server.Data.Repositories
{
    public class JobPositionRepository : IJobPositionRepository
    {
        private readonly DataContext _context;
        public JobPositionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<JobPosition>> GetAllJobsAsync()
        {
        //    return await _context.JobPositions.Include(j => j.Employees).ToListAsync();
        return await _context.JobPositions.ToListAsync();
        }
        public async Task<JobPosition> AddJobAsync(JobPosition job)
        {
            _context.JobPositions.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }
        public async Task<JobPosition> UpdateJobAsync(int id, JobPosition job)
        {
            var temp = _context.JobPositions.Find(id);
            if (temp != null)
            {
                temp.Id = job.Id;
                temp.Name = job.Name;
                temp.Start = job.Start;
                temp.IsManagementRole = job.IsManagementRole;
            }
            await _context.SaveChangesAsync();
            return job;
        }
        public async Task DeleteJobAsync(int id)
        {
            var temp = _context.JobPositions.Find(id);
            _context.JobPositions.Remove(temp);
            await _context.SaveChangesAsync();
        }
    }
}
