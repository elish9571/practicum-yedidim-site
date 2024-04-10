using Server.Core.Models;
using Server.Core.Repositories;
using Server.Core.Services;


namespace Server.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepositoy;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepositoy = employeeRepository;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepositoy.GetEmployeesAsync();
        }
        public async Task<Employee> GetEmployeesAsync(int id)
        {
            return await _employeeRepositoy.GetEmployeeAsync(id);
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            return await _employeeRepositoy.AddEmployeeAsync(employee);
        }
        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            return await _employeeRepositoy.UpdateEmployeeAsync(id, employee);
        }
        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepositoy.DeleteEmployeeAsync(id);
        }

    }
}
