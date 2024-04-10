using Microsoft.EntityFrameworkCore;
using Server.Core.Models;
using Server.Core.Repositories;

namespace Server.Data.Repositories
{
    public class EmployeeRpository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRpository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees
                           .Where(e => e.IsDeleted == false)
                           .Include(e => e.JobPositions)
                           .ToListAsync();
        }
        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var temp = _context.Employees.Find(id);
            if (temp != null)
            {
                temp.Id = employee.Id;
                temp.FirstName = employee.FirstName;
                temp.LastName = employee.LastName;
                temp.Tz = employee.Tz;
                temp.BeginningOfWork = employee.BeginningOfWork;
                temp.BirthDate = employee.BirthDate;
                temp.IsMale = employee.IsMale;
                temp.JobPositions = employee.JobPositions;
            }
            await _context.SaveChangesAsync();
            return temp;
        }
        public async Task DeleteEmployeeAsync(int id)
        {
            var temp = _context.Employees.Find(id);
            if (temp != null)
            {
                temp.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }

    }
}
