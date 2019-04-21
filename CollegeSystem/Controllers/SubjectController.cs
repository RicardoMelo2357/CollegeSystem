using CollegeSystem.Entity;
using CollegeSystem.Models;
using System.Linq;
using System.Web.Mvc;

namespace CollegeSystem.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddSubject(Subject subject)
        {
            if (subject == null)
            {
                return Json(new { Message = "Error", HasError = true }, JsonRequestBehavior.AllowGet);
            }

            var dao = new SubjectDAO();
            var message = dao.AddSubject(subject);

            return Json(new { Message = message}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateSubject(Subject subject)
        {
            if (subject == null)
            {
                return Json(new { Message = "Error", HasError = true }, JsonRequestBehavior.AllowGet);
            }

            var dao = new SubjectDAO();
            var message = dao.UpdateSubject(subject);

            return Json(new { Message = message}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListSubject(Subject subject)
        {
            if (subject == null)
            {
                return Json(new { Message = "Error", HasError = true }, JsonRequestBehavior.AllowGet);
            }

            var dao = new SubjectDAO();
            var List = dao.ListSubject();

            if (!List.Any())
            {
                return Json(new { Message = "No entry found" }, JsonRequestBehavior.AllowGet);
            }

            return Json(List, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteSubject(Subject subject)
        {
            if (subject == null)
            {
                return Json(new { Message = "Erro", HasError = true }, JsonRequestBehavior.AllowGet);
            }

            var dao = new SubjectDAO();
            var message = dao.deleteSubject(subject);

            return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}