using System;
using System.Collections.Generic;

namespace DockerDemo.Models
{
    public partial class Module
    {
        public Module()
        {
            InverseParent = new HashSet<Module>();
            ModuleFunction = new HashSet<ModuleFunction>();
            ModuleRole = new HashSet<ModuleRole>();
            ModuleUser = new HashSet<ModuleUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public string Code { get; set; }
        public double OrderCode { get; set; }
        public string TreePathString { get; set; }
        public int? ParentId { get; set; }

        public virtual Module Parent { get; set; }
        public virtual ICollection<Module> InverseParent { get; set; }
        public virtual ICollection<ModuleFunction> ModuleFunction { get; set; }
        public virtual ICollection<ModuleRole> ModuleRole { get; set; }
        public virtual ICollection<ModuleUser> ModuleUser { get; set; }
    }
}
