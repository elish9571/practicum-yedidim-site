//using Server.Core.Models;
//using Server.Core.Repositories;
//using Server.Core.Services;

//namespace Server.Service
//{
//    public class EmployeeJobPositionService : IEmployeeJobPositionService
//    {
//        private readonly IEmployeeJobPositionRepository _employeeJobPositionRepository;
//        public EmployeeJobPositionService(IEmployeeJobPositionRepository employeeJobPositionRepository)
//        {
//            _employeeJobPositionRepository = employeeJobPositionRepository;
//        }

//        public async Task<List<EmployeeJobPosition>> GetEmployeeJobsAsync(int employeeId)
//        {
//            return await _employeeJobPositionRepository.GetEmployeeJobsAsync(employeeId);
//        }
//        public async Task<EmployeeJobPosition> GetEmployeeJobsByIdAsync(int employeeId, int positionId)
//        {
//            return await _employeeJobPositionRepository.GetEmployeeJobsByIdAsync(employeeId, positionId);
//        }

//        public async Task<EmployeeJobPosition> AddPositionToEmployeeAsync(int id, EmployeeJobPosition employeeJobPosition)
//        {
//            employeeJobPosition.EmployeeId = id;
//            if (employeeJobPosition.Employee != null || employeeJobPosition.Start < employeeJobPosition.Employee.BirthDate)
//            {
//                return null;
//            }
//            return await _employeeJobPositionRepository.AddPositionToEmployeeAsync(employeeJobPosition);
//        }

//       public async Task<EmployeeJobPosition> UpdatePositionToEmployeeAsync(int employeeId, int positionId, EmployeeJobPosition employeeJobPosition)
//        {
//            employeeJobPosition.EmployeeId = employeeId;
//            if (employeeJobPosition.Employee != null || employeeJobPosition.Start < employeeJobPosition.Employee.BirthDate)
//            {
//                return null;
//            }
//            return await _employeeJobPositionRepository.UpdatePositionToEmployeeAsync(employeeId, positionId, employeeJobPosition);

//        }

//      public async Task DeleteEmployeePositionAsync(int employeeId, int positionId)
//        {
//            await _employeeJobPositionRepository.DeleteEmployeePositionAsync(employeeId, positionId);
//        }
//    }
//}
