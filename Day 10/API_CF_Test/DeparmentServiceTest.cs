using API_CF_Demo.Data;
using API_CF_Demo.Models;
using API_CF_Demo.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_CF_Test
{
    internal class DepartmentServiceTest
    {
        private Mock<DbSet<Department>> _mockDepartmentSet;
        private Mock<MyDbContext> _mockContext;
        private DepartmentService _departmentService;
        private List<Department> _departments;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase").Options;

            _departments = new List<Department>
            {
                new Department { Id = 1, Name = "HR", DepartmentHead = "John Doe" },
                new Department { Id = 2, Name = "Finance", DepartmentHead = "Jane Smith" }
            };

            _mockDepartmentSet = new Mock<DbSet<Department>>();
            var queryableDepartments = _departments.AsQueryable();

            _mockDepartmentSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(queryableDepartments.Provider);
            _mockDepartmentSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(queryableDepartments.Expression);
            _mockDepartmentSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(queryableDepartments.ElementType);
            _mockDepartmentSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(queryableDepartments.GetEnumerator());

            // Setting up Add and Remove methods
            _mockDepartmentSet.Setup(m => m.Add(It.IsAny<Department>())).Callback<Department>((d) => _departments.Add(d));
            _mockDepartmentSet.Setup(m => m.Remove(It.IsAny<Department>())).Callback<Department>((d) => _departments.Remove(d));

            _mockContext = new Mock<MyDbContext>(options);
            _mockContext.Setup(c => c.Departments).Returns(_mockDepartmentSet.Object);

            _departmentService = new DepartmentService(_mockContext.Object);
        }

        [Test]
        public void GetAllDepartments_ShouldReturnAllDepartments()
        {
            var result = _departmentService.GetAllDepartments();
            Assert.NotNull(result);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void SearchByName_ShouldReturnMatchingDepartments()
        {
            var result = _departmentService.SearchByName("HR");
            Assert.NotNull(result);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.First().Name, Is.EqualTo("HR"));
        }

        [Test]
        public void AddNewDepartment_ShouldReturnNewDepartmentId()
        {
            var newDepartment = new Department() { Id = 3, Name = "IT", DepartmentHead = "Nithin" };
            var result = _departmentService.AddNewDepartment(newDepartment);
            Assert.That(result, Is.EqualTo(3));
            _mockContext.Verify(m => m.Departments.Add(It.IsAny<Department>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteDepartment_ShouldRemoveDepartment()
        {
            var result = _departmentService.DeleteDepartment(1);
            Assert.That(result, Is.EqualTo("the given Department id 1 Removed"));
            _mockContext.Verify(m => m.Departments.Remove(It.IsAny<Department>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteDepartment_ShouldReturnError_WhenDepartmentIdNotFound()
        {
            var result = _departmentService.DeleteDepartment(3);
            Assert.That(result, Is.EqualTo("Something went wrong with deletion"));
            _mockContext.Verify(m => m.Departments.Remove(It.IsAny<Department>()), Times.Never);
            _mockContext.Verify(m => m.SaveChanges(), Times.Never);
        }

        [Test]
        public void GetDepartmentById_ShouldReturnCorrectDepartment()
        {
            var result = _departmentService.GetDepartmentById(1);
            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo("HR"));
        }

        [Test]
        public void GetDepartmentById_ShouldReturnNull_WhenDepartmentIdNotFound()
        {
            var result = _departmentService.GetDepartmentById(3);
            Assert.IsNull(result);
        }

        [Test]
        public void UpdateDepartment_ShouldUpdateDepartment_WhenDepartmentExists()
        {
            var updateDepartment = new Department
            {
                Id = 1,
                Name = "Human Resource",
                DepartmentHead = "Sam"
            };

            var result = _departmentService.UpdateDepartment(updateDepartment);
            Assert.That(result, Is.EqualTo("Record Updated successfully"));
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void UpdateDepartment_ShouldReturnError_WhenDepartmentDoesNotExist()
        {
            var updateDepartment = new Department { Id = 3, Name = "No Department", DepartmentHead = "Tim" };
            var result = _departmentService.UpdateDepartment(updateDepartment);
            Assert.That(result, Is.EqualTo("Something went wrong while updating."));
            _mockContext.Verify(m => m.SaveChanges(), Times.Never);
        }
    }
}
