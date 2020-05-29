using System;
using System.Collections.Generic;

namespace DockerDemo.Models
{
    public partial class EntityInfo
    {
        public EntityInfo()
        {
            EntityRole = new HashSet<EntityRole>();
            EntityUser = new HashSet<EntityUser>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
        public bool AuditEnabled { get; set; }
        public string PropertyJson { get; set; }

        public virtual ICollection<EntityRole> EntityRole { get; set; }
        public virtual ICollection<EntityUser> EntityUser { get; set; }
    }
}
