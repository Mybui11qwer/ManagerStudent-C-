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
        public ActionResult UpdateStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteStudent(int id)
        {
            try
            {
                var sinhvien = database.SINHVIENs.Find(id);
                if (sinhvien != null)
                {
                    database.SINHVIENs.Remove(sinhvien);
                    database.SaveChanges();
                }
                return RedirectToAction("ManagerStudent");
            }
            catch
            {
                return RedirectToAction("ManagerStudent");
            }
        }

        public ActionResult LHP()
        {
            var lopHocPhans = database.LOPHOCPHANs.ToList();
            if (lopHocPhans == null || lopHocPhans.Count == 0)
            {
                ViewBag.Message = "No courses available.";
            }
            return View(lopHocPhans);
        }



        public ActionResult AddLHP()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLHP(LOPHOCPHAN lopHocPhan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    database.LOPHOCPHANs.Add(lopHocPhan);
                    database.SaveChanges();
                    return RedirectToAction("LHP");
                }
                catch
                {
                    // If there is an error, return the view with the model to display validation errors
                    ViewBag.ErrorMessage = "There was an error while adding the course.";
                    return View(lopHocPhan);
                }
            }
            return View(lopHocPhan);
        }

        public ActionResult EditLHP(int id)
        {
            var lopHocPhan = database.LOPHOCPHANs.Find(id);
            if (lopHocPhan == null)
                return HttpNotFound();
            return View(lopHocPhan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLHP(int id)
        {
            try
            {
                var lopHocPhan = database.LOPHOCPHANs.Find(id);
                if (lopHocPhan == null)
                {
                    return HttpNotFound();
                }

                database.LOPHOCPHANs.Remove(lopHocPhan);
                database.SaveChanges();
                return RedirectToAction("LHP");
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine(ex.Message);
                return RedirectToAction("LHP");
            }
        }
    }
}