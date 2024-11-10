using ManagerStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerStudent.Controllers
{
    public class AccountController : Controller
    {
        private ManagerStudentEntities database = new ManagerStudentEntities();

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel User)
        {
            if (ModelState.IsValid)
            {
                //Check bảng Sinh Viên
                var studentCheck = database.SINHVIENs.FirstOrDefault(u => u.Email == User.EmailLogin && u.MatKhau == User.PasswordLogin);
                if (studentCheck != null)
                {
                    // Set role and session info for studen
                    Session["Email"] = studentCheck.Email;
                    Session["HoTen"] = studentCheck.HoTen;
                    Session["GioiTinh"] = studentCheck.GioiTinh;
                    Session["MaSV"] = studentCheck.MaSV;
                    Session["DiaChi"] = studentCheck.DiaChi;
                    Session["CMND"] = studentCheck.CMND;
                    Session["NienKhoa"] = studentCheck.NienKhoa;
                    Session["SoDienThoai"] = studentCheck.SoDienThoai;
                    Session["NgaySinh"] = studentCheck.NgaySinh;
                    Session["MaKhoa"] = studentCheck.MaKhoa;
                    Session["MaKH"] = studentCheck.MaKH;
                    Session["ID_Status"] = studentCheck.ID_Status;
                    return RedirectToAction("Index", "Home");
                }
                //Check Bảng Giảng Viên
                var teacherCheck = database.GIANGVIENs.FirstOrDefault(u => u.Email == User.EmailLogin && u.MatKhau == User.PasswordLogin);
                if (teacherCheck != null)
                {
                    // Set role and session info for student
                    TempData["UserRole"] = "Teacher";
                    Session["Email"] = teacherCheck.Email;
                    Session["HoTen"] = teacherCheck.HoTen;
                    Session["GioiTinh"] = teacherCheck.GioiTinh;
                    Session["DiaChi"] = teacherCheck.DiaChi;
                    Session["ChucVu"] = teacherCheck.ChucVu;
                    Session["SoDienThoai"] = teacherCheck.SoDienThoai;
                    Session["NgaySinh"] = teacherCheck.NgaySinh;
                    Session["MaKhoa"] = teacherCheck.MaKhoa;
                    Session["NgayVaoLam"] = teacherCheck.NgayVaoLam;
                    return RedirectToAction("Index", "Home");
                }
                //Check bảng Admin
                var adminCheck = database.ADMIN_ACCOUNT.FirstOrDefault(u => u.MaAd == User.EmailLogin && u.MatKhau == User.PasswordLogin);
                if (adminCheck != null)
                {
                    TempData["UserRole"] = "Admin";
                    Session["MaAd"] = adminCheck.MaAd;
                    
                    return RedirectToAction("Dashboard", "Admin");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            // Clear the session data
            Session.Clear();
            Session.Abandon();

            // Redirect to the login page or home page
            return RedirectToAction("Login", "Account");
        }
    }
}