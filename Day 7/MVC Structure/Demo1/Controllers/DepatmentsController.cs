using Demo1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Demo1.Controllers
{
    public class DepatmentsController : Controller
    {
        static List<Department> departments = new List<Department>
        {
            new Department() { DepartmentId = 1, Name = "HR", Location = "Delhi" },
            new Department() { DepartmentId = 2, Name = "IT", Location = "Indore" },
            new Department() { DepartmentId = 3, Name = "Admin", Location = "Bhopal" },
            new Department() { DepartmentId = 4, Name = "Transport", Location = "Pune" },
        };

        public DepatmentsController() { }

        // GET: /Depatments/
        public IActionResult Index()
        {
            return View(departments);
        }

        // GET: /Depatments/Details/5
        public IActionResult Details(int id)
        {
            var department = departments.FirstOrDefault(x => x.DepartmentId == id);
            if (department != null)
            {
                return View(department);
            }
            return RedirectToAction("Index");
        }

        // GET: /Depatments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Depatments/Create
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                departments.Add(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: /Depatments/Edit/5
        public IActionResult Edit(int id)
        {
            var department = departments.FirstOrDefault(x => x.DepartmentId == id);
            if (department != null)
            {
                return View(department);
            }
            return RedirectToAction("Index");
        }

        // POST: /Depatments/Edit/5
        [HttpPost]
        public IActionResult Edit(Department updateDepartment)
        {
            if (ModelState.IsValid)
            {
                var department = departments.FirstOrDefault(x => x.DepartmentId == updateDepartment.DepartmentId);
                if (department != null)
                {
                    department.Name = updateDepartment.Name;
                    department.Location = updateDepartment.Location;
                    return RedirectToAction("Index");
                }
            }
            return View(updateDepartment);
        }

        // GET: /Depatments/Delete/5
        public IActionResult Delete(int id)
        {
            var department = departments.FirstOrDefault(x => x.DepartmentId == id);
            if (department != null)
            {
                return View(department);
            }
            return RedirectToAction("Index");
        }

        // POST: /Depatments/DeleteConfirmed
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = departments.FirstOrDefault(x => x.DepartmentId == id);
            if (department != null)
            {
                departments.Remove(department);
            }
            return RedirectToAction("Index");
        }
    }
}
