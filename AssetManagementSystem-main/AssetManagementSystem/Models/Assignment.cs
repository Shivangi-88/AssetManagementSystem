using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementSystem.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        
        [Required]
        public int AssetId { get; set; }
        public Asset Asset { get; set; } = null!;

       
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        [Required]
        public string Notes { get; set; } = string.Empty;

        public DateTime AssignedDate { get; set; } = DateTime.Now;
        public DateTime? ReturnedDate { get; set; }  
    }
}
