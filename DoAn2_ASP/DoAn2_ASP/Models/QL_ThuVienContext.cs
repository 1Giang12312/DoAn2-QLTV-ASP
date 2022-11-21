using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DoAn2_ASP.ModelView;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DoAn2_ASP.Models
{
    public partial class QL_ThuVienContext : DbContext
    {
        public QL_ThuVienContext()
        {
        }

        public QL_ThuVienContext(DbContextOptions<QL_ThuVienContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblChiTietDonMuon> TblChiTietDonMuon { get; set; }
        public virtual DbSet<TblDonMuonSach> TblDonMuonSach { get; set; }
        public virtual DbSet<TblKeSach> TblKeSach { get; set; }
        public virtual DbSet<TblKhoa> TblKhoa { get; set; }
        public virtual DbSet<TblLoaiSach> TblLoaiSach { get; set; }
        public virtual DbSet<TblQuyenHan> TblQuyenHan { get; set; }
        public virtual DbSet<TblSach> TblSach { get; set; }
        public virtual DbSet<TblSinhVien> TblSinhVien { get; set; }
        public virtual DbSet<TblTacGia> TblTacGia { get; set; }
        public virtual DbSet<TblTaiKhoan> TblTaiKhoan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2022BHG\\GIANG;Database=QL_ThuVien;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblChiTietDonMuon>(entity =>
            {
                entity.HasKey(e => new { e.StMaDonMuon, e.StMaSach });

                entity.ToTable("Tbl_ChiTietDonMuon");

                entity.Property(e => e.StMaDonMuon)
                    .HasColumnName("St_MaDonMuon")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StMaSach).HasColumnName("St_MaSach");

                entity.Property(e => e.DaNgayMuon)
                    .HasColumnName("Da_NgayMuon")
                    .HasColumnType("date");

                entity.Property(e => e.DaNgayTra)
                    .HasColumnName("Da_NgayTra")
                    .HasColumnType("date");

                entity.Property(e => e.InSoLuong).HasColumnName("in_SoLuong");

                entity.HasOne(d => d.StMaDonMuonNavigation)
                    .WithMany(p => p.TblChiTietDonMuon)
                    .HasForeignKey(d => d.StMaDonMuon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ChiTietDonMuon_Tbl_DonMuonSach");

                entity.HasOne(d => d.StMaSachNavigation)
                    .WithMany(p => p.TblChiTietDonMuon)
                    .HasForeignKey(d => d.StMaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ChiTietDonMuon_Tbl_Sach");
            });

            modelBuilder.Entity<TblDonMuonSach>(entity =>
            {
                entity.HasKey(e => e.StMaDonMuon);

                entity.ToTable("Tbl_DonMuonSach");

                entity.Property(e => e.StMaDonMuon).HasColumnName("St_MaDonMuon");

                entity.Property(e => e.StMaKhoa)
                    .IsRequired()
                    .HasColumnName("St_MaKhoa")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.StMaSinhVien)
                    .IsRequired()
                    .HasColumnName("St_MaSinhVien")
                    .HasMaxLength(9);

                entity.HasOne(d => d.StMaSinhVienNavigation)
                    .WithMany(p => p.TblDonMuonSach)
                    .HasForeignKey(d => d.StMaSinhVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_DonMuonSach_Tbl_SinhVien");
                entity.Property(e => e.DaNgayMuon)
                    .HasColumnName("Da_NgayMuon")
                    .HasColumnType("date");

                entity.Property(e => e.DaNgayTra)
                    .HasColumnName("Da_NgayTra")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<TblKeSach>(entity =>
            {
                entity.HasKey(e => e.StMaKeSach);

                entity.ToTable("Tbl_KeSach");

                entity.Property(e => e.StMaKeSach).HasColumnName("St_MaKeSach");

                entity.Property(e => e.StTenKeSach)
                    .IsRequired()
                    .HasColumnName("St_TenKeSach")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblKhoa>(entity =>
            {
                entity.HasKey(e => e.StMaKhoa);

                entity.ToTable("Tbl_Khoa");

                entity.Property(e => e.StMaKhoa).HasColumnName("St_MaKhoa");

                entity.Property(e => e.StTenKhoa)
                    .IsRequired()
                    .HasColumnName("St_TenKhoa")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblLoaiSach>(entity =>
            {
                entity.HasKey(e => e.StMaLoaiSach);

                entity.ToTable("Tbl_LoaiSach");

                entity.Property(e => e.StMaLoaiSach).HasColumnName("St_MaLoaiSach");

                entity.Property(e => e.StTenSach)
                    .IsRequired()
                    .HasColumnName("St_TenSach")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblQuyenHan>(entity =>
            {
                entity.HasKey(e => e.InMaQuyenHan);

                entity.Property(e => e.InMaQuyenHan).HasColumnName("In_MaQuyenHan");

                entity.Property(e => e.StGhiChu)
                    .IsRequired()
                    .HasColumnName("St_GhiChu")
                    .HasMaxLength(50);

                entity.Property(e => e.StTenQuyenHan)
                    .IsRequired()
                    .HasColumnName("St_TenQuyenHan")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblSach>(entity =>
            {
                entity.HasKey(e => e.StMaSach);

                entity.ToTable("Tbl_Sach");

                entity.Property(e => e.StMaSach).HasColumnName("St_MaSach");

                entity.Property(e => e.InSoLuong).HasColumnName("In_SoLuong");

                entity.Property(e => e.StAnh)
                    .HasColumnName("St_Anh")
                    .HasMaxLength(50);

                entity.Property(e => e.StMaKeSach).HasColumnName("St_MaKeSach");

                entity.Property(e => e.StMaLoaiSach).HasColumnName("St_MaLoaiSach");

                entity.Property(e => e.StMaTacGia).HasColumnName("St_MaTacGia");

                entity.Property(e => e.StTenSach)
                    .IsRequired()
                    .HasColumnName("St_TenSach")
                    .HasMaxLength(50);

                entity.Property(e => e.StTinhTrang)
                    .IsRequired()
                    .HasColumnName("St_TinhTrang")
                    .HasMaxLength(50);

                entity.Property(e => e.StTomTat)
                    .IsRequired()
                    .HasColumnName("St_TomTat")
                    .HasMaxLength(50);

                entity.HasOne(d => d.StMaKeSachNavigation)
                    .WithMany(p => p.TblSach)
                    .HasForeignKey(d => d.StMaKeSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Sach_Tbl_KeSach");

                entity.HasOne(d => d.StMaLoaiSachNavigation)
                    .WithMany(p => p.TblSach)
                    .HasForeignKey(d => d.StMaLoaiSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Sach_Tbl_LoaiSach");

                entity.HasOne(d => d.StMaTacGiaNavigation)
                    .WithMany(p => p.TblSach)
                    .HasForeignKey(d => d.StMaTacGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Sach_Tbl_TacGia");
            });

            modelBuilder.Entity<TblSinhVien>(entity =>
            {
                entity.HasKey(e => e.StMaSinhVien);

                entity.ToTable("Tbl_SinhVien");

                entity.Property(e => e.StMaSinhVien)
                    .HasColumnName("St_MaSinhVien")
                    .HasMaxLength(9);

                entity.Property(e => e.InSoLanBiPhat).HasColumnName("In_SoLanBiPhat");

                entity.Property(e => e.StGmail)
                    .IsRequired()
                    .HasColumnName("St_Gmail")
                    .HasMaxLength(50);

                entity.Property(e => e.StMaKhoa).HasColumnName("St_MaKhoa");

                entity.Property(e => e.StSoDienThoai)
                    .IsRequired()
                    .HasColumnName("St_SoDienThoai")
                    .HasMaxLength(12);

                entity.Property(e => e.StTenSinhVien)
                    .IsRequired()
                    .HasColumnName("St_TenSinhVien")
                    .HasMaxLength(50);

                entity.HasOne(d => d.StMaKhoaNavigation)
                    .WithMany(p => p.TblSinhVien)
                    .HasForeignKey(d => d.StMaKhoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_SinhVien_Tbl_Khoa");
            });

            modelBuilder.Entity<TblTacGia>(entity =>
            {
                entity.HasKey(e => e.StMaTacGia);

                entity.ToTable("Tbl_TacGia");

                entity.Property(e => e.StMaTacGia).HasColumnName("St_MaTacGia");

                entity.Property(e => e.StTenTacGia)
                    .IsRequired()
                    .HasColumnName("St_TenTacGia")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblTaiKhoan>(entity =>
            {
                entity.HasKey(e => e.InMaTaiKhoan);

                entity.ToTable("Tbl_TaiKhoan");

                entity.Property(e => e.InMaTaiKhoan).HasColumnName("In_MaTaiKhoan");

                entity.Property(e => e.BiTrangThai).HasColumnName("Bi_TrangThai");

                entity.Property(e => e.DaNgayDangNhap)
                    .HasColumnName("Da_NgayDangNhap")
                    .HasColumnType("datetime");

                entity.Property(e => e.DaNgayTao)
                    .HasColumnName("Da_NgayTao")
                    .HasColumnType("datetime");

                entity.Property(e => e.InMaQuyenHan).HasColumnName("In_MaQuyenHan");

                entity.Property(e => e.StMaSinhVien)
                    .IsRequired()
                    .HasColumnName("St_MaSinhVien")
                    .HasMaxLength(9);

                entity.Property(e => e.StSalt)
                    .IsRequired()
                    .HasColumnName("St_Salt")
                    .HasMaxLength(50);

                entity.Property(e => e.StMatKhau)
                    .IsRequired()
                    .HasColumnName("St_MatKhau")
                    .HasMaxLength(50);

                entity.HasOne(d => d.InMaQuyenHanNavigation)
                    .WithMany(p => p.TblTaiKhoan)
                    .HasForeignKey(d => d.InMaQuyenHan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_TaiKhoan_TblQuyenHan");

                entity.HasOne(d => d.StMaSinhVienNavigation)
                    .WithMany(p => p.TblTaiKhoan)
                    .HasForeignKey(d => d.StMaSinhVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_TaiKhoan_Tbl_SinhVien");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<DoAn2_ASP.ModelView.RegisterVM> RegisterVM { get; set; }

        public DbSet<DoAn2_ASP.ModelView.LoginVM> LoginVM { get; set; }
    }
}
