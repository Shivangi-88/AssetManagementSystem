using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Models
{
    public class Asset
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;  

        [Required]
        public string Type { get; set; } = string.Empty;  

        [Required]
        public string Status { get; set; } = "Available"; 

        public bool IsSpare { get; set; }

        public string Specifications { get; set; } = string.Empty;

       
        public string MakeModel { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;

       
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}


