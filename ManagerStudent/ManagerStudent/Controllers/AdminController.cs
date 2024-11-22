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
            var toltalStudents = database.SINHVIENs.Count();
            var toltalTeachers = database.GIANGVIENs.Count();

            ViewBag.toltalStudents = toltalStudents;
            ViewBag.toltalTeachers = toltalTeachers;

            return View();
        }
        public ActionResult ManagerStudent()
        {
            List<SINHVIEN> sINHVIENs = database.SINHVIENs.ToList();
            return View(sINHVIENs);
        }
        public ActionResult AddNewStudent()
        {
            var sinhvien = new ViewSinhVienModel()
            {
                SinhViens = database.SINHVIENs.ToList(),
                Khoas = database.KHOAs.ToList(),
                KhoaHocs = database.KHOAHOCs.ToList(),
                MonHocs = database.MONHOCs.ToList(),
                LopHocPhans = database.LOPHOCPHANs.ToList(),
                TinhTrangHocs = database.TINHTRANGHOCs.ToList()
            };
            return View(sinhvien);
        }
        [HttpPost]
        public ActionResult AddNewStudent(SINHVIEN sinhvien)
        {
            try
            {
                sinhvien.MatKhau = "123";
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