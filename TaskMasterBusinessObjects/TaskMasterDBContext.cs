using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskMasterBusinessObjects
{
    public partial class TaskMasterDBContext : DbContext
    {
        public TaskMasterDBContext()
        {
        }

        public TaskMasterDBContext(DbContextOptions<TaskMasterDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProjActionLog> ProjActionLogs { get; set; } = null!;
        public virtual DbSet<ProjComment> ProjComments { get; set; } = null!;
        public virtual DbSet<ProjDocument> ProjDocuments { get; set; } = null!;
        public virtual DbSet<ProjExceptionLog> ProjExceptionLogs { get; set; } = null!;
        public virtual DbSet<ProjNotification> ProjNotifications { get; set; } = null!;
        public virtual DbSet<ProjProject> ProjProjects { get; set; } = null!;
        public virtual DbSet<ProjProjectUser> ProjProjectUsers { get; set; } = null!;
        public virtual DbSet<ProjStatus> ProjStatuses { get; set; } = null!;
        public virtual DbSet<ProjTask> ProjTasks { get; set; } = null!;
        public virtual DbSet<ProjUser> ProjUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=TaskMasterDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjActionLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK_ActionLogs");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjActionLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_proj_ActionLogs_proj_User");
            });

            modelBuilder.Entity<ProjComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK_Comment");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.ProjComments)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_proj_Comment_proj_Task");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjComments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_proj_Comment_proj_User");
            });

            modelBuilder.Entity<ProjDocument>(entity =>
            {
                entity.HasKey(e => e.DocumentId)
                    .HasName("PK_Document");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.ProjDocuments)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_proj_Document_proj_Task");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjDocuments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_proj_Document_proj_User");
            });

            modelBuilder.Entity<ProjExceptionLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK_ExceptionLog");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjExceptionLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_proj_ExceptionLog_proj_User");
            });

            modelBuilder.Entity<ProjNotification>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjNotifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_proj_Notification_proj_User");
            });

            modelBuilder.Entity<ProjProject>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK_Project");
            });

            modelBuilder.Entity<ProjProjectUser>(entity =>
            {
                entity.HasKey(e => e.ProjectUserId)
                    .HasName("PK_ProjectUser");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjProjectUsers)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_proj_ProjectUser_proj_Project");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjProjectUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_proj_ProjectUser_proj_User1");
            });

            modelBuilder.Entity<ProjStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK_Status");
            });

            modelBuilder.Entity<ProjTask>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK_Task");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjTasks)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_proj_Task_proj_Project");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ProjTasks)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_proj_Task_proj_Status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjTasks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_proj_Task_proj_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
