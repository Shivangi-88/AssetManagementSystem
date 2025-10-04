using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagementSystem.Models;

namespace AssetManagementSystem.Services
{
	public interface IAssignmentService
	{
		Task<IEnumerable<Assignment>> GetAllAssignmentsAsync();
		Task AssignAssetAsync(int assetId, int employeeId, string notes);
		Task ReturnAssetAsync(int assignmentId, string notes);
		Task<IEnumerable<Assignment>> GetAssignmentsByEmployeeAsync(int employeeId);
		Task<IEnumerable<Assignment>> GetAssignmentsByAssetAsync(int assetId);
	}
}
