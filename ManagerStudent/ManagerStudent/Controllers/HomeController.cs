using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
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
            var MSSV = Session["MaSV"];
            // Lấy thông tin sinh viên từ cơ sở dữ liệu
            var checkUserProgram = database.SINHVIENs
                .Include(s => s.KHOAHOC)
                .Include(s => s.KHOA)
                .Include(m => m.KHOA.MONHOCs.Select(mon => mon.LOPHOCPHANs))
                .FirstOrDefault(s => s.MaSV == MSSV);
            return View(checkUserProgram);
        }
        public ActionResult Schedule()
        {
            var MSSV = Session["MaSV"];
            var checkSchedule = database.SINHVIENs
                .Include(kh => kh.KHOAHOC)
                .Include(k => k.KHOA)
                .Include(m => m.KHOA.MONHOCs)
                .Include(lhp => lhp.KHOA.MONHOCs.Select(mon => mon.LOPHOCPHANs))
                .FirstOrDefault(s => s.MaSV == MSSV);
            return View(checkSchedule);
        }
        public ActionResult ExamSchedule()
        {
            return View();
        }
    }
}