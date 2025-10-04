using Microsoft.AspNetCore.Identity;

namespace AssetManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add extra properties if needed, e.g., FullName
        public string FullName { get; set; } = string.Empty;
    }
}
