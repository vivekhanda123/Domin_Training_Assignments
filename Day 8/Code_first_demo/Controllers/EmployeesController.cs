using Code_first_demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Code_first_demo.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MyContext _context;

        public EmployeesController(MyContext context)
        {
            _context = context;
        }
        // GET Employees
        public IActionResult Index()
        {
            var employees = _context.Employees.Include(e => e.Department).ToList();
            return View(employees);
        }

        //GET Employees/Details
        public IActionResult Details(int id)
        {
            var employee = _context.Employees.Include(e => e.Department).FirstOrDefault(e => e.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET Employee/Create
        public IActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId","DepartmentId");
            return View();
        }
        // POST Employees/Create
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET Employees/Edit/5
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);
        }

        // POST Employee/Edit/5
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);
        }

        //GET Employees/Delete/5
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Include(e => e.Department).FirstOrDefault(e => e.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST Employee/Delete/5
        [HttpPost,ActionName("Delete")]
        public IActionResult DelteCofirmed(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
