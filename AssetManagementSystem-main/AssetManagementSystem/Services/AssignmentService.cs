using AssetManagementSystem.Data;
using AssetManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementSystem.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly AppDbContext _context;

        public AssignmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Assignment>> GetAllAssignmentsAsync()
        {
            return await _context.Assignments
                .Include(a => a.Asset)
                .Include(a => a.Employee)
                .ToListAsync();
        }

        public async Task AssignAssetAsync(int assetId, int employeeId, string notes)
        {
            var asset = await _context.Assets.FindAsync(assetId);
            if (asset == null || asset.Status != "Available")
                throw new InvalidOperationException("Asset not available");

            var assignment = new Assignment
            {
                AssetId = assetId,
                EmployeeId = employeeId,
                AssignedDate = DateTime.UtcNow,
                Notes = notes
            };

            asset.Status = "Assigned";
            _context.Assignments.Add(assignment);
            _context.Assets.Update(asset);
            await _context.SaveChangesAsync();
        }

        public async Task ReturnAssetAsync(int assignmentId, string notes)
        {
            var assignment = await _context.Assignments
                .Include(a => a.Asset)
                .FirstOrDefaultAsync(a => a.Id == assignmentId);

            if (assignment == null || assignment.ReturnedDate != null)
                throw new InvalidOperationException("Assignment not valid");

            assignment.ReturnedDate = DateTime.UtcNow;
            assignment.Notes += "\nReturned: " + notes;

            assignment.Asset.Status = "Available";

            _context.Assignments.Update(assignment);
            _context.Assets.Update(assignment.Asset);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByEmployeeAsync(int employeeId)
        {
            return await _context.Assignments
                .Include(a => a.Asset)
                .Where(a => a.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByAssetAsync(int assetId)
        {
            return await _context.Assignments
                .Include(a => a.Employee)
                .Where(a => a.AssetId == assetId)
                .ToListAsync();
        }
    }
}
