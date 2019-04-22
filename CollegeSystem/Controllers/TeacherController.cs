using CollegeSystem.Entity;
using CollegeSystem.Models;
using System.Linq;
using System.Web.Mvc;

namespace CollegeSystem.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                return Json(new { Message = "Error", HasError = true });
            }

            var dao = new TeacherDAO();
            var message = dao.AddTeacher(teacher);

            return Json(new { Message = message });
        }

        [HttpPost]
        public JsonResult UpdateTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                return Json(new { Message = "Error", HasError = true });
            }

            var dao = new TeacherDAO();
            var message = dao.UpdateTeacher(teacher);

            return Json(new { Message = message });
        }

        [HttpGet]
        public JsonResult ListTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                return Json(new { Message = "Error", HasError = true });
            }

            var dao = new TeacherDAO();
            var List = dao.ListTeacher();

            if (!List.Any())
            {
                return Json(new { Message = "No entry found" });
            }

            return Json(List, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                return Json(new { Message = "Erro", HasError = true });
            }

            var dao = new TeacherDAO();
            var message = dao.DeleteTeacher(teacher);

            return Json(new { Message = message });
        }
    }
}