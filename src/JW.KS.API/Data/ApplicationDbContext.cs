﻿using JW.KS.API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JW.KS.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().ToTable("Roles").Property(x => x.Id).HasMaxLength(50).IsUnicode(false);
            builder.Entity<User>().ToTable("Users").Property(x => x.Id).HasMaxLength(50).IsUnicode(false);
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

            builder.Entity<LabelInKnowledgeBase>()
                        .HasKey(c => new { c.LabelId, c.KnowledgeBaseId });

            builder.Entity<Permission>()
                       .HasKey(c => new { c.RoleId, c.FunctionId, c.CommandId });

            builder.Entity<Vote>()
                        .HasKey(c => new { c.KnowledgeBaseId, c.UserId });

            builder.Entity<CommandInFunction>()
                       .HasKey(c => new { c.CommandId, c.FunctionId });

            builder.HasSequence("KnowledgeBaseSequence");
        }

        public DbSet<Command> Commands { set; get; }
        public DbSet<CommandInFunction> CommandInFunctions { set; get; }

        public DbSet<ActivityLog> ActivityLogs { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<Function> Functions { set; get; }
        public DbSet<KnowledgeBase> KnowledgeBases { set; get; }
        public DbSet<Label> Labels { set; get; }
        public DbSet<LabelInKnowledgeBase> LabelInKnowledgeBases { set; get; }
        public DbSet<Permission> Permissions { set; get; }
        public DbSet<Report> Reports { set; get; }
        public DbSet<Vote> Votes { set; get; }

        public DbSet<Attachment> Attachments { get; set; }
    }
}