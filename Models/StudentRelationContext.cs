using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentRelationApi.Models;

public partial class StudentRelationContext : DbContext
{
    public StudentRelationContext()
    {
    }

    public StudentRelationContext(DbContextOptions<StudentRelationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Stud> Stud { get; set; }

    public virtual DbSet<Tech> Teches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
#warning

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.CourseId).ValueGeneratedNever();
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stud>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("Stud");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tech>(entity =>
        {
            entity.HasKey(e => e.TeacherId);

            entity.ToTable("Tech");

            entity.Property(e => e.TeacherId)
                .ValueGeneratedNever()
                .HasColumnName("TeacherID");
            entity.Property(e => e.TeacherName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
