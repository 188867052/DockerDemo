using System;
using System.Collections.Generic;

namespace DockerDemo.Models
{
    public partial class Role
    {
        public Role()
        {
            EntityRole = new HashSet<EntityRole>();
            ModuleRole = new HashSet<ModuleRole>();
            RoleClaim = new HashSet<RoleClaim>();
            UserRole = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Remark { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDefault { get; set; }
        public bool IsSystem { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public Guid? MessageId { get; set; }

        public virtual Message Message { get; set; }
        public virtual ICollection<EntityRole> EntityRole { get; set; }
        public virtual ICollection<ModuleRole> ModuleRole { get; set; }
        public virtual ICollection<RoleClaim> RoleClaim { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
