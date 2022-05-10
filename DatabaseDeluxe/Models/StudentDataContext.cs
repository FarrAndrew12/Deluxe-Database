using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatabaseDeluxe.Models
{
    public partial class StudentDataContext : DbContext
    {
        public StudentDataContext()
        {
        }

        public StudentDataContext(DbContextOptions<StudentDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentId> StudentIds { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=StudentData;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentId>(entity =>
            {
                entity.ToTable("StudentID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FavFood)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HomeTown)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
