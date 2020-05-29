using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DockerDemo.Models
{
    public partial class OSharpSiteContext : DbContext
    {
        public OSharpSiteContext()
        {
        }

        public OSharpSiteContext(DbContextOptions<OSharpSiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditEntity> AuditEntity { get; set; }
        public virtual DbSet<AuditOperation> AuditOperation { get; set; }
        public virtual DbSet<AuditProperty> AuditProperty { get; set; }
        public virtual DbSet<EntityInfo> EntityInfo { get; set; }
        public virtual DbSet<EntityRole> EntityRole { get; set; }
        public virtual DbSet<EntityUser> EntityUser { get; set; }
        public virtual DbSet<Function> Function { get; set; }
        public virtual DbSet<KeyValue> KeyValue { get; set; }
        public virtual DbSet<LoginLog> LoginLog { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<MessageReceive> MessageReceive { get; set; }
        public virtual DbSet<MessageReply> MessageReply { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<ModuleFunction> ModuleFunction { get; set; }
        public virtual DbSet<ModuleRole> ModuleRole { get; set; }
        public virtual DbSet<ModuleUser> ModuleUser { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleClaim> RoleClaim { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<UserDetail> UserDetail { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserToken> UserToken { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=47.105.214.235;Database=OSharp.Site;User Id=sa;Password=931592457czA;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditEntity>(entity =>
            {
                entity.HasIndex(e => e.OperationId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.AuditEntity)
                    .HasForeignKey(d => d.OperationId);
            });

            modelBuilder.Entity<AuditOperation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<AuditProperty>(entity =>
            {
                entity.HasIndex(e => e.AuditEntityId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.AuditEntity)
                    .WithMany(p => p.AuditProperty)
                    .HasForeignKey(d => d.AuditEntityId);
            });

            modelBuilder.Entity<EntityInfo>(entity =>
            {
                entity.HasIndex(e => e.TypeName)
                    .HasName("ClassFullNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PropertyJson).IsRequired();

                entity.Property(e => e.TypeName).IsRequired();
            });

            modelBuilder.Entity<EntityRole>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => new { e.EntityId, e.RoleId, e.Operation })
                    .HasName("EntityRoleIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.EntityRole)
                    .HasForeignKey(d => d.EntityId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.EntityRole)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<EntityUser>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new { e.EntityId, e.UserId })
                    .HasName("EntityUserIndex");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.EntityUser)
                    .HasForeignKey(d => d.EntityId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EntityUser)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.HasIndex(e => new { e.Area, e.Controller, e.Action })
                    .HasName("AreaControllerActionIndex")
                    .IsUnique()
                    .HasFilter("([Area] IS NOT NULL AND [Controller] IS NOT NULL AND [Action] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<KeyValue>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Key).IsRequired();
            });

            modelBuilder.Entity<LoginLog>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginLog)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasIndex(e => e.SenderId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.SenderId);
            });

            modelBuilder.Entity<MessageReceive>(entity =>
            {
                entity.HasIndex(e => e.MessageId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.MessageReceive)
                    .HasForeignKey(d => d.MessageId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MessageReceive)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MessageReply>(entity =>
            {
                entity.HasIndex(e => e.BelongMessageId);

                entity.HasIndex(e => e.ParentMessageId);

                entity.HasIndex(e => e.ParentReplyId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content).IsRequired();

                entity.HasOne(d => d.BelongMessage)
                    .WithMany(p => p.MessageReplyBelongMessage)
                    .HasForeignKey(d => d.BelongMessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ParentMessage)
                    .WithMany(p => p.MessageReplyParentMessage)
                    .HasForeignKey(d => d.ParentMessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ParentReply)
                    .WithMany(p => p.InverseParentReply)
                    .HasForeignKey(d => d.ParentReplyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MessageReply)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasIndex(e => e.ParentId);

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);
            });

            modelBuilder.Entity<ModuleFunction>(entity =>
            {
                entity.HasIndex(e => e.FunctionId);

                entity.HasIndex(e => new { e.ModuleId, e.FunctionId })
                    .HasName("ModuleFunctionIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.ModuleFunction)
                    .HasForeignKey(d => d.FunctionId);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.ModuleFunction)
                    .HasForeignKey(d => d.ModuleId);
            });

            modelBuilder.Entity<ModuleRole>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => new { e.ModuleId, e.RoleId })
                    .HasName("ModuleRoleIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.ModuleRole)
                    .HasForeignKey(d => d.ModuleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ModuleRole)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<ModuleUser>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new { e.ModuleId, e.UserId })
                    .HasName("ModuleUserIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.ModuleUser)
                    .HasForeignKey(d => d.ModuleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ModuleUser)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasIndex(e => e.ParentId);

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.MessageId);

                entity.HasIndex(e => new { e.NormalizedName, e.DeletedTime })
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([DeletedTime] IS NOT NULL)");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.NormalizedName).IsRequired();

                entity.Property(e => e.Remark).HasMaxLength(512);

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Role)
                    .HasForeignKey(d => d.MessageId);
            });

            modelBuilder.Entity<RoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaim)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.MessageId);

                entity.HasIndex(e => new { e.NormalizeEmail, e.DeletedTime })
                    .HasName("EmailIndex");

                entity.HasIndex(e => new { e.NormalizedUserName, e.DeletedTime })
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([DeletedTime] IS NOT NULL)");

                entity.Property(e => e.NormalizedUserName).IsRequired();

                entity.Property(e => e.UserName).IsRequired();

                entity.HasOne(d => d.MessageNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.MessageId);
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.ClaimType).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaim)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .IsUnique();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserDetail)
                    .HasForeignKey<UserDetail>(d => d.UserId);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("UserLoginIndex")
                    .IsUnique()
                    .HasFilter("([LoginProvider] IS NOT NULL AND [ProviderKey] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogin)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => new { e.UserId, e.RoleId, e.DeletedTime })
                    .HasName("UserRoleIndex")
                    .IsUnique()
                    .HasFilter("([DeletedTime] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("UserTokenIndex")
                    .IsUnique()
                    .HasFilter("([LoginProvider] IS NOT NULL AND [Name] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserToken)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
