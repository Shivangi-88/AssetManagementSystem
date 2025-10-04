using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty; // updated from Name to FullName

        [Required]
        public string Department { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Designation { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "Active";

        // Navigation property for assignments
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}
