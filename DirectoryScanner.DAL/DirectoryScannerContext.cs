using DirectoryScanner.DAL.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace DirectoryScanner.DAL
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

        public virtual DbSet<Models.DB.File> Files { get; set; } = null!;
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
            modelBuilder.Entity<Models.DB.File>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.FolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
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
