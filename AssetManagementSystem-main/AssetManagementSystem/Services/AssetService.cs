using AssetManagementSystem.Data;
using AssetManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementSystem.Services
{
    public class AssetService : IAssetService
    {
        private readonly AppDbContext _context;

        public AssetService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asset>> GetAllAssetsAsync()
        {
            return await _context.Assets.ToListAsync();
        }

        public async Task<Asset> GetAssetByIdAsync(int id)
        {
            return await _context.Assets.FindAsync(id);
        }

        public async Task AddAssetAsync(Asset asset)
        {
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAssetAsync(Asset asset)
        {
            _context.Assets.Update(asset);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssetAsync(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset != null)
            {
                _context.Assets.Remove(asset);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Asset>> GetAssetsByTypeAsync(string type)
        {
            
            return await _context.Assets.Where(a => a.Type == type).ToListAsync();
        }

        public async Task<IEnumerable<Asset>> GetAssetsByStatusAsync(string status)
        {
            return await _context.Assets.Where(a => a.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<Asset>> GetAssetsAssignedToEmployeeAsync(int employeeId)
        {
            return await _context.Assignments
                .Where(x => x.EmployeeId == employeeId && x.ReturnedDate == null)
                .Select(x => x.Asset)
                .ToListAsync();
        }

      
        public async Task<IEnumerable<Asset>> GetAvailableAssetsAsync()
        {
            return await _context.Assets
                .Where(a => a.Status == "Available")
                .ToListAsync();
        }
    }
}
