using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TASK03.Context;
using TASK03.Models;

namespace TASK03.Controllers
{
    public class StudentController : Controller
    {
       ContextClass db = new ContextClass();

        
        [HttpGet]
        public IActionResult Index()
        {
            // View Model
            var allStudents = db.Students.Include(stu => stu.Department);
            return View(allStudents);
        }
        
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var student = db.Students.Include(stu => stu.Department).FirstOrDefault(stu => stu.Id == id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            return View(student);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(db.Departments, "Id", "DeptName");
            return View();
        }
        

        [HttpPost]
        public IActionResult Create(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oldStudent = db.Students.Include(e => e.Department).FirstOrDefault(stu => stu.Id == id);
            if (oldStudent == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(db.Departments, "Id", "DeptName");
            return View(oldStudent);
        }
      
       
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var oldStudent = db.Students.FirstOrDefault(stu => stu.Id == student.Id);
            if (oldStudent == null)
            {
                return RedirectToAction("Index");
            }
            oldStudent.Name = student.Name;
            oldStudent.Age = student.Age;
            oldStudent.Address = student.Address;
            oldStudent.DepartmentId =student.DepartmentId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public IActionResult Delete(int id)
        {
            var studentToDelete = db.Students.FirstOrDefault(stu => stu.Id == id);
            if (studentToDelete == null)
            {
                return RedirectToAction("Index");
            }
            db.Students.Remove(studentToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
