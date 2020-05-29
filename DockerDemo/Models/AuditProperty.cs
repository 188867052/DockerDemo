﻿using System;
using System.Collections.Generic;

namespace DockerDemo.Models
{
    public partial class AuditProperty
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string FieldName { get; set; }
        public string OriginalValue { get; set; }
        public string NewValue { get; set; }
        public string DataType { get; set; }
        public Guid AuditEntityId { get; set; }

        public virtual AuditEntity AuditEntity { get; set; }
    }
}
