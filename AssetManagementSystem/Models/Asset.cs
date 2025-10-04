using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Models
{
    public class Asset
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;  // Asset name

        [Required]
        public string Type { get; set; } = string.Empty;  // Asset type

        [Required]
        public string Status { get; set; } = "Available"; // for assignment tracking

        public bool IsSpare { get; set; }

        public string Specifications { get; set; } = string.Empty;

        // New properties to match Razor page
        public string MakeModel { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;

        // Navigation property for assignments
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}


