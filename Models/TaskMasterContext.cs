using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContosoPizza.Models
{
    public partial class TaskMasterContext : DbContext
    {
        public TaskMasterContext()
        {
        }

        public TaskMasterContext(DbContextOptions<TaskMasterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TaskComment> TaskComments { get; set; } = null!;
        public virtual DbSet<TaskItem> TaskItems { get; set; } = null!;
        public virtual DbSet<TaskList> TaskLists { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TaskMaster;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskComment>(entity =>
            {
                entity.ToTable("task_comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .HasColumnName("value");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TaskComments)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__task_comm__item___2D27B809");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TaskComments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__task_comm__user___2C3393D0");
            });

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.ToTable("task_items");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ListId).HasColumnName("list_id");

                entity.Property(e => e.Task)
                    .HasMaxLength(255)
                    .HasColumnName("task");

                entity.HasOne(d => d.List)
                    .WithMany(p => p.TaskItems)
                    .HasForeignKey(d => d.ListId)
                    .HasConstraintName("FK__task_item__list___2B3F6F97");
            });

            modelBuilder.Entity<TaskList>(entity =>
            {
                entity.ToTable("task_list");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .HasColumnName("value");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TaskLists)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__task_list__user___2A4B4B5E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .HasColumnName("full_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
