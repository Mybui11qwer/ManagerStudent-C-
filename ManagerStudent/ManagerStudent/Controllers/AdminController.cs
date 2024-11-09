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
            return View();
        }
    }
}