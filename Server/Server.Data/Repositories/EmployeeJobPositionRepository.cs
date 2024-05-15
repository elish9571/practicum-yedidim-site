//using Microsoft.EntityFrameworkCore;
//using Server.Core.Models;
//using Server.Core.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Server.Data.Repositories
//{
//    public class EmployeeJobPositionRepository : IEmployeeJobPositionRepository
//    {
//        private readonly DataContext _context;
//        public EmployeeJobPositionRepository(DataContext context)
//        {
//            _context = context;
//        }
//        public async Task<List<EmployeeJobPosition>> GetEmployeeJobsAsync(int employeeId)
//        {
//            var positions = await _context.EmployeeJobPositions
//                           .Where(e => e.EmployeeId == employeeId)
//                           .Include(p => p.Position)
//                           .Include(p2 => p2.Employee)
//                           .ToListAsync();
//            return positions.Any() ? positions : null;
//        }
//        public async Task<EmployeeJobPosition> GetEmployeeJobsByIdAsync(int employeeId, int positionId)
//        {
//            return await _context.EmployeeJobPositions.FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.PositionId == positionId);
//        }
//        public async Task<EmployeeJobPosition> AddPositionToEmployeeAsync(EmployeeJobPosition employeeJobPosition)
//        {
//            var existingPosition = await _context.EmployeeJobPositions
//                .FirstOrDefaultAsync(ejp => ejp.EmployeeId == employeeJobPosition.EmployeeId
//                                           && ejp.PositionId == employeeJobPosition.PositionId
//                                           && ejp.IsActive == false);
//            if (existingPosition != null)
//            {
//                return await UpdatePositionToEmployeeAsync(employeeJobPosition.EmployeeId, employeeJobPosition.PositionId, existingPosition);
//            }
//            await _context.EmployeeJobPositions.AddAsync(employeeJobPosition);
//            await _context.SaveChangesAsync();
//            return employeeJobPosition;
//        }
//        public async Task<EmployeeJobPosition> UpdatePositionToEmployeeAsync(int employeeId, int positionId, EmployeeJobPosition employeeJobPosition)
//        {
//            var updatePosition = await _context.EmployeeJobPositions.FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.PositionId == positionId);
//            if (updatePosition == null)
//            {
//                return null;
//            }

//            updatePosition.IsActive = true;
//            updatePosition.Start = employeeJobPosition.Start;
//            updatePosition.IsManagementRole = employeeJobPosition.IsManagementRole;

//            await _context.SaveChangesAsync();
//            return updatePosition;
//        }
//        public async Task DeleteEmployeePositionAsync(int employeeId, int positionId)
//        {
//            var deletePosition = await _context.EmployeeJobPositions.FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.PositionId == positionId);
//            if (deletePosition != null)
//            {
//                deletePosition.IsActive = false;
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
