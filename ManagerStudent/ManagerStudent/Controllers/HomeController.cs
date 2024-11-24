using ManagerStudent.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

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
                .Include("KHOA")
                .Include("KHOA.MONHOCs")
                .Include("KHOA.MONHOCs.LOPHOCPHANs")
                .FirstOrDefault(s => s.MaSV == MSSV); ;
            return View(checkUserProgram);
        }
        public ActionResult Schedule()
        {
            var MSSV = Session["MaSV"];
            var checkSchedule = database.SINHVIENs
                .Include(kh => kh.DangKyHocs)
                .Include(lhp => lhp.DangKyHocs.Select(mon => mon.LOPHOCPHAN))
                .FirstOrDefault(s => s.MaSV == MSSV);
            return View(checkSchedule);
        }
        public ActionResult ExamSchedule()
        {
            return View();
        }
        public ActionResult Result()
        {
            var MSSV = Session["MaSV"];
            var checkResult = database.Diems.Where(d => d.MaSV == MSSV).ToList();
            return View(checkResult);
        }
    }
}