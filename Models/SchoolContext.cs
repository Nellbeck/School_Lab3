using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School_Lab3.Models;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<SecretStudent> SecretStudents { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FPHO4OK;Initial Catalog=School;Integrated Security=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("Class");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FkStudenNumber).HasColumnName("FK_StudenNumber");
            entity.Property(e => e.FkWorkerNumber).HasColumnName("FK_WorkerNumber");

            entity.HasOne(d => d.FkStudenNumberNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.FkStudenNumber)
                .HasConstraintName("FK_Class_Students");

            entity.HasOne(d => d.FkWorkerNumberNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.FkWorkerNumber)
                .HasConstraintName("FK_Class_Workers");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK_Grade");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseGradeSet)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CourseGradeSetDate)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FkStudenNumber).HasColumnName("FK_StudenNumber");
            entity.Property(e => e.FkWorkerNumber).HasColumnName("FK_WorkerNumber");

            entity.HasOne(d => d.FkStudenNumberNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.FkStudenNumber)
                .HasConstraintName("FK_Grade_Students");

            entity.HasOne(d => d.FkWorkerNumberNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.FkWorkerNumber)
                .HasConstraintName("FK_Grade_Workers");
        });

        modelBuilder.Entity<SecretStudent>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.StudentBirthDate)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.StudentFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentLastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentNumber).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentNumber);

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("TR_FindAge");
                    tb.HasTrigger("TR_FindGender");
                });

            entity.Property(e => e.StudentBirthDate)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.StudentFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentGender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StudentLastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.WorkerNumber).HasName("PK_Person");

            entity.Property(e => e.WorkerBirthDate)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.WorkerFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WorkerLastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WorkerProfession)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
