using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DirectoryScanner.DAL.Models.DB
{
    public partial class DirectoryScannerContext : DbContext
    {
        public DirectoryScannerContext()
        {
        }

        public DirectoryScannerContext(DbContextOptions<DirectoryScannerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<File> Files { get; set; } = null!;
        public virtual DbSet<Folder> Folders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CodeAcademyDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_Files_FoldersID");
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
