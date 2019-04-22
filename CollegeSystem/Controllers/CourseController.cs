using CollegeSystem.Entity;
using CollegeSystem.Models;
using System.Linq;
using System.Web.Mvc;

namespace CollegeSystem.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public JsonResult AddCourse(Course course)
        {
            if (course == null)
            {
                return Json(new { Message = "Error", HasError = true });
            }

            var dao = new CourseDAO();
            var message = dao.AddCourse(course);

           return Json(new { Message = message });
        }

        [HttpPut]
        public JsonResult UpdateCourse(Course course)
        {
            if (course == null)
            {
                return Json(new { Message = "Error", HasError = true });
            }

            var dao = new CourseDAO();
            var message = dao.UpdateCourse(course);

            return Json(new { Message = message, HasError = false });
        }

        [HttpGet]
        public JsonResult ListCourse(Course course)
        {
            if (course == null)
            {
                return Json(new { Message = "Error", HasError = true });
            }

            var dao = new CourseDAO();
            var List = dao.ListCourses();

            if (!List.Any())
            {
                return Json(new { Message = "No entry found", HasError = true, JsonRequestBehavior.AllowGet }); 
            }

            return Json(List, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult CourseDelete(Course course)
        {
            if (course == null)
            {
                return Json(new { Message = "Erro", HasError = true });
            }

            var dao = new CourseDAO();
            var message = dao.deleteCourse(course);

            return Json(new { Message = message });
        }
    }
}