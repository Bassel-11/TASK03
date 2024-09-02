using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TASK03.Context;
using TASK03.Models;

namespace TASK03.Controllers
{
    public class DepartmentController : Controller
    {
       
       ContextClass db = new ContextClass();

        [HttpGet]
        public IActionResult Index()
        {
            var _Departments = db.Departments;
            return View(_Departments);
        }
        
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _Departmnet = db.Departments.Find(id);
            if (_Departmnet == null)
            {
                return RedirectToAction("Index");
            }
            return View(_Departmnet);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
