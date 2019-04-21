using CollegeSystem.Entity;
using CollegeSystem.Models;
using System.Linq;
using System.Web.Mvc;

namespace CollegeSystem.Controllers
{
    public class StudantGradeController : Controller
    {
        // GET: StudantGrade
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddStudantGrade(StudantGrade studantGrade)
        {
            if (studantGrade == null)
            {
                return Json(new { Message = "Error", HasError = true });
            }

            var dao = new StudantGradeDAO();
            var message = dao.AddStudantGrade(studantGrade);

            return Json(new { Message = message });
        }

        [HttpPost]
        public JsonResult UpdateStudant(StudantGrade studantGrade)
        {
            if (studantGrade == null)
            {
                return Json(new { Message = "Error", HasError = true });
            }

            var dao = new StudantGradeDAO();
            var message = dao.UpdateStudantGrade(studantGrade);

            return Json(new { Message = message });
        }

        [HttpGet]
        public JsonResult ListStudant(StudantGrade studantGrade)
        {
            if (studantGrade == null)
            {
                return Json(new { Message = "Error", HasError = true });
            }

            var dao = new StudantGradeDAO();
            var List = dao.ListStudantGrade();

            if (!List.Any())
            {
                return Json(new { Message = "No entry found" });
            }

            return Json(List, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteStudant(StudantGrade studantGrade)
        {
            if (studantGrade == null)
            {
                return Json(new { Message = "Erro", HasError = true });
            }

            var dao = new StudantGradeDAO();
            var message = dao.deleteStudantGrade(studantGrade);

            return Json(new { Message = message });
        }
    }
}