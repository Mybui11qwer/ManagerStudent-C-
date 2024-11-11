using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerStudent.Models
{
    public class ViewSinhVienModel
    {
        public List<SINHVIEN> SinhViens { get; set; }
        public List<KHOA> Khoas { get; set; }
        public List<KHOAHOC> KhoaHocs { get; set; }
        public List<MONHOC> MonHocs { get; set; }
        public List<LOPHOCPHAN> LopHocPhans { get; set; }
        public List<TINHTRANGHOC> TinhTrangHocs { get; set; }
    }
}