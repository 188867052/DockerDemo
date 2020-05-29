using System;
using System.Collections.Generic;

namespace DockerDemo.Models
{
    public partial class UserDetail
    {
        public int Id { get; set; }
        public string RegisterIp { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
