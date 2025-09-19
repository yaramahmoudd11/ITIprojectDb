using ITIprojectDb.Data;
using ITIprojectDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIprojectDb.Controllers
{
    public class InstructorController : Controller
    {
        public AppDbContext _context;
        public InstructorController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Instructors=_context.Instructors.ToList();
            return View(Instructors);
        }
        public IActionResult Test()
        {
            return View("Create");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name")]  Instructor instructor)
        {
            if(ModelState.IsValid)
            {
                _context.Instructors.Add(instructor);
                _context.SaveChanges();
                TempData["message"] = "Instructor Created Successfully";
                return RedirectToAction("Index");
            }
            TempData["failed"] = "Cannot add the record";
            return View(instructor);
        }

        public IActionResult Edit(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("Index");
            }
            var instructor = _context.Instructors.Where(a => a.Id == id).FirstOrDefault();
            return View(instructor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Instructors.Update(instructor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var instructor = _context.Instructors.Where(a => a.Id == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                _context.Instructors.Remove(instructor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Instructors.Remove(instructor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }


        public IActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Index");
            }
            var instructor=_context.Instructors.Where(a=>a.Id == id)
                .Include(t=>t.Courses)
                .FirstOrDefault();
            return View(instructor);
        }
    }
}
