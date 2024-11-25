using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerStudent.Models
{
    public class NotificationViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public DateTime SentTime { get; set; }
    }
}