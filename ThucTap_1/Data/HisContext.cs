using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ThucTap_1.Models;

namespace ThucTap_1.Data;

public partial class HisContext : DbContext
{
    public HisContext()
    {
    }

    public HisContext(DbContextOptions<HisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BkKtcc> BkKtccs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-1E6RROK\\SQLEXPRESS;Initial Catalog=HIS;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BkKtcc>(entity =>
        {
            entity.ToTable("BK_KTCC", "EMR");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.B6a).HasColumnName("B6A");
            entity.Property(e => e.B6b).HasColumnName("B6B");
            entity.Property(e => e.KhoaKt).HasColumnName("KhoaKT");
            entity.Property(e => e.NgayKt)
                .HasColumnType("date")
                .HasColumnName("NgayKT");
            entity.Property(e => e.NguoiDuocKt).HasColumnName("NguoiDuocKT");
            entity.Property(e => e.NguoiKt).HasColumnName("NguoiKT");
            entity.Property(e => e.SoHs)
                .HasMaxLength(50)
                .HasColumnName("SoHS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
