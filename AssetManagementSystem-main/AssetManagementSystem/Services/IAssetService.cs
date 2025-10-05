using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagementSystem.Models;

namespace AssetManagementSystem.Services
{
    public interface IAssetService
    {
        Task<IEnumerable<Asset>> GetAllAssetsAsync();
        Task<Asset> GetAssetByIdAsync(int id);
        Task AddAssetAsync(Asset asset);
        Task UpdateAssetAsync(Asset asset);
        Task DeleteAssetAsync(int id);

       
        Task<IEnumerable<Asset>> GetAssetsByTypeAsync(string type);
        Task<IEnumerable<Asset>> GetAssetsByStatusAsync(string status);
        Task<IEnumerable<Asset>> GetAssetsAssignedToEmployeeAsync(int employeeId);

  
        Task<IEnumerable<Asset>> GetAvailableAssetsAsync();
    }
}
