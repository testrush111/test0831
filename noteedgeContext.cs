using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace test20200831
{
    public partial class noteedgeContext : DbContext
    {
        public noteedgeContext()
        {
        }

        public noteedgeContext(DbContextOptions<noteedgeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TMember> TMember { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:noteledge.database.windows.net,1433;Initial Catalog=note$edge;Persist Security Info=False;User ID=noteledge;Password=n@tE$edGe31415926;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TMember>(entity =>
            {
                entity.HasKey(e => e.FMemberId);

                entity.ToTable("tMember");

                entity.Property(e => e.FMemberId).HasColumnName("fMemberID");

                entity.Property(e => e.FAccount)
                    .IsRequired()
                    .HasColumnName("fAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.FPassword)
                    .IsRequired()
                    .HasColumnName("fPassword")
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
