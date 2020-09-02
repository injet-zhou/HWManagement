using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HW.Entities
{
    public partial class homeworkContext : DbContext
    {
        public homeworkContext()
        {
        }

        public homeworkContext(DbContextOptions<homeworkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Homework> Homework { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Submission> Submission { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;database=homework;uid=sa;pwd=1194058385");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Intro)
                    .HasColumnName("intro")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpenId)
                    .HasColumnName("openId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Open)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.OpenId)
                    .HasConstraintName("FK_COURSE_REFERENCE_TEACHER");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("enrollment");

                entity.Property(e => e.EnrollmentId)
                    .HasColumnName("enrollmentId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpenId)
                    .HasColumnName("openId")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Score).HasColumnName("score");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_ENROLLME_REFERENCE_COURSE");

                entity.HasOne(d => d.Open)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.OpenId)
                    .HasConstraintName("FK_ENROLLME_REFERENCE_STUDENT");
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.ToTable("homework");

                entity.Property(e => e.HomeworkId)
                    .HasColumnName("homeworkId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text");

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Due)
                    .HasColumnName("due")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mulsubmit).HasColumnName("mulsubmit");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Published).HasColumnName("published");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Homework)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_HOMEWORK_REFERENCE_COURSE");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("resource");

                entity.Property(e => e.ResourceId)
                    .HasColumnName("resourceId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.OpenId)
                    .HasName("PK_STUDENT");

                entity.ToTable("student");

                entity.Property(e => e.OpenId)
                    .HasColumnName("openId")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.School)
                    .HasColumnName("school")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sclass)
                    .HasColumnName("sclass")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .HasColumnName("studentId")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.ToTable("submission");

                entity.Property(e => e.SubmissionId)
                    .HasColumnName("submissionId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text");

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomeworkId)
                    .HasColumnName("homeworkId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpenId)
                    .HasColumnName("openId")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceId)
                    .HasColumnName("resourceId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.SubTime)
                    .HasColumnName("sub_time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_SUBMISSI_REFERENCE_COURSE");

                entity.HasOne(d => d.Homework)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.HomeworkId)
                    .HasConstraintName("FK_SUBMISSI_REFERENCE_HOMEWORK");

                entity.HasOne(d => d.Open)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.OpenId)
                    .HasConstraintName("FK_SUBMISSI_REFERENCE_STUDENT");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.ResourceId)
                    .HasConstraintName("FK_SUBMISSI_REFERENCE_RESOURCE");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.OpenId)
                    .HasName("PK_TEACHER");

                entity.ToTable("teacher");

                entity.Property(e => e.OpenId)
                    .HasColumnName("openId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.School)
                    .HasColumnName("school")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherId)
                    .HasColumnName("teacherId")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
