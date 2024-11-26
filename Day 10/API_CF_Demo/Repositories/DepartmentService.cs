using API_CF_Demo.Data;
using API_CF_Demo.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_CF_Demo.Repositories
{
    public class DepartmentService : IDepartmentService
    {
        private readonly MyDbContext _context;
        private readonly ILogger<DepartmentService> _logger;

        public DepartmentService(MyDbContext context, ILogger<DepartmentService> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Get all department data
        public List<Department> GetAllDepartments()
        {
            _logger.LogInformation("GetAllDepartments Called");
            var departments = _context.Departments.ToList();
            return departments.Count > 0 ? departments : new List<Department>();
        }

        // Search for a department by name
        public List<Department> SearchByName(string name)
        {
            return _context.Departments
                .Where(x => x.Name.Contains(name))
                .ToList();
        }

        // Add a new department
        public int AddNewDepartment(Department department)
        {
            try
            {
                if (department == null)
                {
                    _logger.LogWarning("Attempted to add a null department");
                    return 0;
                }

                _context.Departments.Add(department);
                _context.SaveChanges();
                _logger.LogInformation($"{department.Id} added successfully");

                return department.Id;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while adding a new department");
                throw;
            }
        }

        // Delete a department by ID
        public string DeleteDepartment(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Invalid ID provided for deletion");
                return "ID should not be null or zero.";
            }

            var department = _context.Departments.FirstOrDefault(x => x.Id == id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
                _logger.LogInformation($"{department.Id} deleted successfully");

                return $"The given Department ID {id} was removed.";
            }

            _logger.LogWarning($"Department with ID {id} not found for deletion");
            return "Department not found for deletion.";
        }

        // Get a department by ID
        public Department GetDepartmentById(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Invalid ID provided for retrieval");
                return null;
            }

            var department = _context.Departments.FirstOrDefault(x => x.Id == id);
            if (department == null)
            {
                _logger.LogWarning($"Department with ID {id} not found.");
            }

            return department;
        }

        // Update an existing department
        public string UpdateDepartment(Department department)
        {
            if (department == null || department.Id <= 0)
            {
                _logger.LogWarning("Invalid department data provided for update");
                return "Invalid department data.";
            }

            var existingDepartment = _context.Departments.FirstOrDefault(x => x.Id == department.Id);
            if (existingDepartment != null)
            {
                existingDepartment.Name = department.Name;
                existingDepartment.DepartmentHead = department.DepartmentHead;
                _context.Entry(existingDepartment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                _logger.LogInformation($"Department ID {department.Id} updated successfully");

                return "Record updated successfully.";
            }

            _logger.LogWarning($"Department with ID {department.Id} not found for update");
            return "Department not found for update.";
        }
    }
}
