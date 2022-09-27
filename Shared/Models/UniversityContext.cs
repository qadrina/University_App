using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using University_App.Shared.StoredProcedures;

namespace University_App.Shared.Models
{
    public partial class UniversityContext : DbContext
    {
        public UniversityContext()
        {
        }

        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Student_Course> Student_Courses { get; set; } = null!;
        public virtual DbSet<spCourses> spCourses { get; set; } = null!;
        public virtual DbSet<spFaculty> spFaculties { get; set; } = null!;
        public virtual DbSet<spStudents> spStudents { get; set; } = null!;
        public virtual DbSet<spStudent_Course> spStudent_Courses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=NQHW\\DUBAI; Database=University; Trusted_Connection=True; MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Course_Id);

                entity.Property(e => e.Course_Id).HasMaxLength(50);

                entity.Property(e => e.Course_Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Faculty");

                entity.Property(e => e.Dean_Id).HasMaxLength(50);

                entity.Property(e => e.Dean_Name).HasMaxLength(50);

                entity.Property(e => e.Faculty_Id).HasMaxLength(50);

                entity.Property(e => e.Faculty_Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Student_Id);

                entity.HasIndex(e => new { e.Faculty_Id, e.Student_Id }, "IX_Students");

                entity.Property(e => e.Student_Id).HasMaxLength(50);

                entity.Property(e => e.Birth_Date).HasColumnType("datetime");

                entity.Property(e => e.Faculty_Id).HasMaxLength(50);

                entity.Property(e => e.Student_Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Student_Course>(entity =>
            {
                entity.HasKey(e => new { e.Student_Id, e.Course_Id });

                entity.ToTable("Student_Course");

                entity.HasIndex(e => new { e.Course_Id, e.Student_Id }, "IX_Course_Student");

                entity.HasIndex(e => new { e.Student_Id, e.Course_Id }, "IX_Student_Course");

                entity.Property(e => e.Student_Id).HasMaxLength(50);

                entity.Property(e => e.Course_Id).HasMaxLength(50);
            });

            modelBuilder.Entity<spCourses>().HasNoKey();
            modelBuilder.Entity<spFaculty>().HasNoKey();
            modelBuilder.Entity<spStudents>().HasNoKey();
            modelBuilder.Entity<spStudent_Course>().HasNoKey();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
