using System;
using System.Collections.Generic;

namespace DockerDemo.Models
{
    public partial class User
    {
        public User()
        {
            EntityUser = new HashSet<EntityUser>();
            LoginLog = new HashSet<LoginLog>();
            Message = new HashSet<Message>();
            MessageReceive = new HashSet<MessageReceive>();
            MessageReply = new HashSet<MessageReply>();
            ModuleUser = new HashSet<ModuleUser>();
            UserClaim = new HashSet<UserClaim>();
            UserLogin = new HashSet<UserLogin>();
            UserRole = new HashSet<UserRole>();
            UserToken = new HashSet<UserToken>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string NormalizeEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string HeadImg { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public bool IsSystem { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string Remark { get; set; }
        public Guid? MessageId { get; set; }

        public virtual Message MessageNavigation { get; set; }
        public virtual UserDetail UserDetail { get; set; }
        public virtual ICollection<EntityUser> EntityUser { get; set; }
        public virtual ICollection<LoginLog> LoginLog { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<MessageReceive> MessageReceive { get; set; }
        public virtual ICollection<MessageReply> MessageReply { get; set; }
        public virtual ICollection<ModuleUser> ModuleUser { get; set; }
        public virtual ICollection<UserClaim> UserClaim { get; set; }
        public virtual ICollection<UserLogin> UserLogin { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
        public virtual ICollection<UserToken> UserToken { get; set; }
    }
}
