using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Services
{
    public interface IJobPositionService
    {
        Task<List<JobPosition>> GetAllJobsAsync();

        Task<JobPosition> AddJobAsync(JobPosition job);

        Task<JobPosition> UpdateJobAsync(int id, JobPosition job);

        Task DeleteJobAsync(int id);
    }
}
