using System;
using System.Collections.Generic;

namespace DockerDemo.Models
{
    public partial class LoginLog
    {
        public Guid Id { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public DateTime? LogoutTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
