using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagerStudent.Models;

namespace ManagerStudent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ManagerStudentEntities database = new ManagerStudentEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Information()
        {
            var MSSV = Session["MaSV"];
            var sinhvien = database.SINHVIENs
                .Include(s => s.KHOAHOC)
                .Include(s => s.KHOA)
                .Include(s => s.TINHTRANGHOC).FirstOrDefault(s => s.MaSV == MSSV);
            return View(sinhvien);
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