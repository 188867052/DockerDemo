﻿using System;
using System.Collections.Generic;

namespace DockerDemo.Models
{
    public partial class AuditOperation
    {
        public AuditOperation()
        {
            AuditEntity = new HashSet<AuditEntity>();
        }

        public Guid Id { get; set; }
        public string FunctionName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Ip { get; set; }
        public string OperationSystem { get; set; }
        public string Browser { get; set; }
        public string UserAgent { get; set; }
        public int ResultType { get; set; }
        public string Message { get; set; }
        public int Elapsed { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual ICollection<AuditEntity> AuditEntity { get; set; }
    }
}
