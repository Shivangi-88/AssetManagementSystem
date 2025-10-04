using AssetManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.Migrate();

            // Seed Employees
            if (!context.Employees.Any())
            {
                var employees = new List<Employee>
                {
                    new Employee { Name = "John Doe", Department = "IT", Email = "john@example.com", PhoneNumber = "1234567890", Designation = "Developer", Status = "Active" },
                    new Employee { Name = "Jane Smith", Department = "HR", Email = "jane@example.com", PhoneNumber = "0987654321", Designation = "Manager", Status = "Active" }
                };
                context.Employees.AddRange(employees);
                context.SaveChanges();
            }

            // Seed Assets
            if (!context.Assets.Any())
            {
                var assets = new List<Asset>
                {
                    new Asset { Name = "Dell Laptop", Type = "Laptop", Status = "Available", IsSpare = false, Specifications = "16GB RAM, 512GB SSD" },
                    new Asset { Name = "HP Printer", Type = "Printer", Status = "Available", IsSpare = true, Specifications = "LaserJet, Black & White" },
                    new Asset { Name = "iPhone 14", Type = "Phone", Status = "Available", IsSpare = false, Specifications = "128GB, Space Gray" }
                };
                context.Assets.AddRange(assets);
                context.SaveChanges();
            }

            // Seed Assignments
            if (!context.Assignments.Any())
            {
                var employee = context.Employees.First();
                var asset = context.Assets.First();

                var assignments = new List<Assignment>
                {
                    new Assignment
                    {
                        EmployeeId = employee.Id,
                        AssetId = asset.Id,
                        Notes = "Assigned for project work",
                        AssignedDate = DateTime.Now,
                        ReturnedDate = null
                    }
                };
                context.Assignments.AddRange(assignments);
                context.SaveChanges();
            }
        }
    }
}

