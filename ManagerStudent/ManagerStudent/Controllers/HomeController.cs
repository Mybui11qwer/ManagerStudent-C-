using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerStudent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Information()
        {
            return View();
        }
        public ActionResult Notification()
        {
            return View();
        }
        public ActionResult ProgramEdu()
        {
            return View();
        }
        public ActionResult Schedule()
        {
            return View();
        }
        public ActionResult ExamSchedule()
        {
            return View();
        }
    }
}