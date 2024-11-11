using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagerStudent.Models;

namespace ManagerStudent.Controllers
{
    public class AdminController : Controller
    {
        public ManagerStudentEntities database = new ManagerStudentEntities();
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult ManagerStudent()
        {
            List<SINHVIEN> sINHVIENs = database.SINHVIENs.ToList();
            return View(sINHVIENs);
        }
        public ActionResult AddNewStudent()
        {
            var sinhvien = database.SINHVIENs
                .Include(s => s.KHOAHOC)
                .Include(s => s.KHOA)
                .Include(k => k.KHOA.MONHOCs)
                .Include(m => m.KHOA.MONHOCs.Select(mon => mon.LOPHOCPHAN)).ToList();
            return View(sinhvien);
        }
        [HttpPost]
        public ActionResult AddNewStudent(SINHVIEN sinhvien)
        {
            try
            {
                database.SINHVIENs.Add(sinhvien);
                database.SaveChanges();
                return RedirectToAction("ManagerStudent");
            }
            catch
            {
                return View("AddNewStudent");
            }
        }
    }
}