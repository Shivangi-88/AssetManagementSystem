using Microsoft.AspNetCore.Identity;

namespace AssetManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public string FullName { get; set; } = string.Empty;
    }
}
