using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentControllersMysql.Models;

namespace StudentControllersMysql.Controllers
{
    public class StudentsController : Controller
    {
        // GET: StudentsController
        public ActionResult Index()
        {
            List<Student> lstEmp = Student.GetAllStudents();
            return View(lstEmp);
        }

        // GET: StudentsController/Details/5
        public ActionResult Details(int id)
        {
            Student obj = Student.GetSingleStudent(id);
            return View(obj);
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student obj,IFormCollection collection)
        {
            try
            {
                Student.InsertStudent(obj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Edit/5
        public ActionResult Edit(int id)
        {
            Student obj = Student.GetSingleStudent(id);
            return View(obj);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Student obj = Student.GetSingleStudent(id);
                return View(obj);
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Delete/5
        public ActionResult Delete(int id)
        {
            Student obj = Student.GetSingleStudent(id);
            return View(obj);
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Student.DeleteStudent(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
