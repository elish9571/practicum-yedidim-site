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
            }
            await _context.SaveChangesAsync();
            return job;
        }
        //public async Task DeleteJobAsync(int empId, int positionId)
        //{
        //    var temp = _context.Employees.FirstOrDefaultAsync(e=>e.Id==empId);
        //    if (temp != null)
        //    {
               
        //    }
        //    _context.JobPositions.Remove(temp);
        //    await _context.SaveChangesAsync();
        //}
        //public async Task<bool> DeletRoleToEmployeeAsync(int employeeId, int roleId)
        //{
        //    var roleEmployee = await _context.EmployeeInRoles.FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.RoleId == roleId);
        //    if (roleEmployee != null)
        //    {
        //        roleEmployee.StatusActive = false;
        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    return false;
        //}


        public async Task DeleteJobAsync(int empId, int positionId)
        {
            // מצא את העובד לפי ה־empId
            var employee = await _context.Employees
                .Include(e => e.JobPositions)
                .FirstOrDefaultAsync(e => e.Id == empId);

            if (employee != null)
            {
                // מצא את התפקיד למחיקה מתוך רשימת התפקידים של העובד
                var jobPositionToRemove = employee.JobPositions.FirstOrDefault(jp => jp.Id == positionId);

                if (jobPositionToRemove != null)
                {
                    // הסר את התפקיד מרשימת התפקידים של העובד
                    employee.JobPositions.Remove(jobPositionToRemove);

                    // עדכן את השינויים במסד הנתונים
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
