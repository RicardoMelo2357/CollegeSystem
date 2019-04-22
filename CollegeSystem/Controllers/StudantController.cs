using CollegeSystem.Entity;
using CollegeSystem.Models;
using System.Linq;
using System.Web.Mvc;

namespace CollegeSystem.Controllers
{
    public class StudantController : Controller
    {
        // GET: Studant
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddStudant(Studant studant)
        {
            if (studant == null)
            {
                return Json(new { Message = "Error", HasError = true }, JsonRequestBehavior.AllowGet);
            }

            var dao = new StudantDAO();
            var message = dao.AddStudant(studant);

            return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateStudant(Studant studant)
        {
            if (studant == null)
            {
                return Json(new { Message = "Error", HasError = true }, JsonRequestBehavior.AllowGet);
            }

            var dao = new StudantDAO();
            var message = dao.UpdateStudant(studant);

            return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListStudant(Studant studant)
        {
            if (studant == null)
            {
                return Json(new { Message = "Error", HasError = true }, JsonRequestBehavior.AllowGet);
            }

            var dao = new StudantDAO();
            var List = dao.ListStudant();

            if (!List.Any())
            {
                return Json(new { Message = "No entry found" }, JsonRequestBehavior.AllowGet);
            }

            return Json(List, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteStudant(Studant studant)
        {
            if (studant == null)
            {
                return Json(new { Message = "Erro", HasError = true }, JsonRequestBehavior.AllowGet);
            }

            var dao = new StudantDAO();
            var message = dao.deleteStudant(studant);

            return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}