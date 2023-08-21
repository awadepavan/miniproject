using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentsCollations.Models;

public partial class Ktjune23Context : DbContext
{
    public Ktjune23Context()
    {

    }

    public Ktjune23Context(DbContextOptions<Ktjune23Context> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentMany> StudentManies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MsSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentMany>(entity =>
        {
            entity.HasKey(e => e.StuId).HasName("PK__Student__C31F9D8D1EA790C9");

            entity.ToTable("StudentMany");

            entity.Property(e => e.StuId)
                .ValueGeneratedNever()
                .HasColumnName(" StuId");
            entity.Property(e => e.StuCourse)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName(" StuCourse");
            entity.Property(e => e.StuCourseFees).HasColumnName(" StuCourseFees");
            entity.Property(e => e.StuEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StuName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StuPhoneNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StuSurName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
