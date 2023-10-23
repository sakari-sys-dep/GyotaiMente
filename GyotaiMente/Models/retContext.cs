using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GyotaiMente.Models
{
    public partial class retContext : DbContext
    {
        public retContext()
        {
        }

        public retContext(DbContextOptions<retContext> options)
            : base(options)
        {
        }

        public virtual DbSet<法人マスタ> 法人マスタ { get; set; } = null!;

        //public virtual DbSet<倉庫マスタ> 倉庫マスタ { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //                optionsBuilder.UseSqlServer("Server=DCEDPSV0017;Database=ret;user id=sa;password=sakariadmin;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<法人マスタ>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("法人マスタ");

                entity.Property(e => e.与信管理単位区分)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.更新日時)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.法人カナ名)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .UseCollation("Japanese_90_BIN2");

                entity.Property(e => e.法人コード)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .UseCollation("Japanese_90_BIN2");

                entity.Property(e => e.法人名)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .UseCollation("Japanese_90_BIN2");

                entity.Property(e => e.法人正式名)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .UseCollation("Japanese_90_BIN2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
