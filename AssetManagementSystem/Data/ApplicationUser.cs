using Microsoft.AspNetCore.Identity;

namespace AssetManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        // You can add additional properties here if needed
        public string Name { get; set; } = string.Empty;
    }
}

