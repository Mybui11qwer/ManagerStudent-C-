using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerStudent.Models
{
    public class LoginViewModel
    {
        public string EmailLogin { get; set; }  // Có thể là MSSV hoặc MaGV
        public string PasswordLogin { get; set; }
    }
}