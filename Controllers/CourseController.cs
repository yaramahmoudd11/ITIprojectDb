using ITIprojectDb.Data;
using ITIprojectDb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITIprojectDb.Controllers
{
    public class CourseController : Controller
    {
        public readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }


        public ActionResult Index()
        {
            var courses = _context.Courses.
                Include(t=>t.Instructor)
                .ToList();
            return View(courses);
        }

        public ActionResult Details(int id)
        {
            var course= _context.Courses.Where(I=>I.Id==id)
                .Include(t=>t.Instructor)
                .FirstOrDefault();
            
            return View(course);
        }

        public ActionResult Create()
        {
            var instructors =_context.Instructors.ToList();

            SelectList instructorList=new SelectList(instructors, "Id", "Name", "select Instructor");

            ViewBag.MyList = instructorList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if(ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var instructors = _context.Instructors.ToList();

            SelectList instructorList = new SelectList(instructors, "Id", "Name", "select Instructor");

            ViewBag.MyList = instructorList;
            return View(course);
        }

        public ActionResult Edit(int id)
        {
            var course = _context.Courses.Where (I=>I.Id==id).FirstOrDefault();
            var instructors = _context.Instructors.ToList();

            SelectList instructorList = new SelectList(instructors, "Id", "Name", "select Instructor");

            ViewBag.MyList = instructorList;
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            var instructors = _context.Instructors.ToList();

            SelectList instructorList = new SelectList(instructors, "Id", "Name", "select Instructor");

            ViewBag.MyList = instructorList;
            return View(course);
        }


        public ActionResult Delete(int id)
        {
            var course = _context.Courses.Where(I => I.Id == id).FirstOrDefault();
            var instructors = _context.Instructors.ToList();

            SelectList instructorList = new SelectList(instructors, "Id", "Name", "select Instructor");

            ViewBag.MyList = instructorList;
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var instructors = _context.Instructors.ToList();

            SelectList instructorList = new SelectList(instructors, "Id", "Name", "select Instructor");

            ViewBag.MyList = instructorList;
            return View(course);

        }
    }
}
