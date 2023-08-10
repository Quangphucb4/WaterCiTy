/*using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WaterCity.Repository.Models
{
    public partial class NhaMayNuocContext : DbContext
    {
        public NhaMayNuocContext()
        {
        }

        public NhaMayNuocContext(DbContextOptions<NhaMayNuocContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiSoDongHo> ChiSoDongHos { get; set; } = null!;
        public virtual DbSet<ChiTietGium> ChiTietGia { get; set; } = null!;
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; } = null!;
        public virtual DbSet<ChucNang> ChucNangs { get; set; } = null!;
        public virtual DbSet<ChucVu> ChucVus { get; set; } = null!;
        public virtual DbSet<DanhSachDoiTuongGium> DanhSachDoiTuongGia { get; set; } = null!;
        public virtual DbSet<DoiTuongGium> DoiTuongGia { get; set; } = null!;
        public virtual DbSet<DongHoNuoc> DongHoNuocs { get; set; } = null!;
        public virtual DbSet<DongHoNuocSuCo> DongHoNuocSuCos { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<HopDong> HopDongs { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<KhuVuc> KhuVucs { get; set; } = null!;
        public virtual DbSet<KyGhiChiSo> KyGhiChiSos { get; set; } = null!;
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; } = null!;
        public virtual DbSet<NhaMay> NhaMays { get; set; } = null!;
        public virtual DbSet<NhatKyDuLieu> NhatKyDuLieus { get; set; } = null!;
        public virtual DbSet<NhatKyHoaDon> NhatKyHoaDons { get; set; } = null!;
        public virtual DbSet<SoDocChiSo> SoDocChiSos { get; set; } = null!;
        public virtual DbSet<SuCo> SuCos { get; set; } = null!;
        public virtual DbSet<ThatThoat> ThatThoats { get; set; } = null!;
        public virtual DbSet<ThongBao> ThongBaos { get; set; } = null!;
        public virtual DbSet<TrangThaiGhi> TrangThaiGhis { get; set; } = null!;
        public virtual DbSet<TuyenDoc> TuyenDocs { get; set; } = null!;
        public virtual DbSet<TyLeBaoPhu> TyLeBaoPhus { get; set; } = null!;
        public virtual DbSet<Vung> Vungs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=12345;database=NhaMayNuoc;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiSoDongHo>(entity =>
            {

                entity.ToTable("ChiSoDongHo");


                entity.Property(e => e.GhiChu).HasMaxLength(1000);

                entity.Property(e => e.IdDongHoNuoc).HasMaxLength(50);

                entity.Property(e => e.IdSoDocChiSo).HasMaxLength(50);

                entity.Property(e => e.IdTrangThaiGhi).HasMaxLength(50);

                entity.Property(e => e.NgayDoc).HasColumnType("datetime");

                entity.Property(e => e.NgayDongBo).HasColumnType("datetime");

                entity.Property(e => e.Tthu)
                    .HasMaxLength(50)
                    .HasColumnName("TThu");

                entity.HasOne(d => d.IdDongHoNuocNavigation)
                    .WithMany(p => p.ChiSoDongHos)
                    .HasForeignKey(d => d.IdDongHoNuoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiSoDongHo_DongHoNuoc");

                entity.HasOne(d => d.IdSoDocChiSoNavigation)
                    .WithMany(p => p.ChiSoDongHos)
                    .HasForeignKey(d => d.IdSoDocChiSo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiSoDongHo_SoDocChiSo");

                entity.HasOne(d => d.IdTrangThaiGhiNavigation)
                    .WithMany(p => p.ChiSoDongHos)
                    .HasForeignKey(d => d.IdTrangThaiGhi)
                    .HasConstraintName("FK_ChiSoDongHo_ChiSoDongHo");
            });

            modelBuilder.Entity<ChiTietGium>(entity =>
            {
                entity.HasKey(e => e.IdChiTietGia)
                    .HasName("PK_Record");

                entity.Property(e => e.IdChiTietGia).HasMaxLength(50);

                entity.Property(e => e.GiaCoVat).HasColumnName("GiaCoVAT");

                entity.Property(e => e.IdDoiTuongGia).HasMaxLength(50);

                entity.Property(e => e.MoTaChiTiet).HasMaxLength(1000);

                entity.HasOne(d => d.IdDoiTuongGiaNavigation)
                    .WithMany(p => p.ChiTietGia)
                    .HasForeignKey(d => d.IdDoiTuongGia)
                    .HasConstraintName("FK_ChiTietGia_DoiTuongGia");
            });

            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.HasKey(e => e.IdChiTietHoaDon);

                entity.ToTable("ChiTietHoaDon");

                entity.Property(e => e.IdChiTietHoaDon).HasMaxLength(50);

                entity.Property(e => e.GiaCoVat).HasColumnName("GiaCoVAT");

                entity.Property(e => e.IdHoaDon).HasMaxLength(50);

                entity.HasOne(d => d.IdHoaDonNavigation)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.IdHoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDon_HoaDon");
            });

            modelBuilder.Entity<ChucNang>(entity =>
            {
                entity.HasKey(e => e.IdChucNang)
                    .HasName("PK_Function");

                entity.ToTable("ChucNang");

                entity.Property(e => e.IdChucNang).HasMaxLength(50);

                entity.Property(e => e.TenChucNang).HasMaxLength(1000);
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.IdChucVu)
                    .HasName("PK_Role");

                entity.ToTable("ChucVu");

                entity.Property(e => e.IdChucVu).HasMaxLength(50);

                entity.Property(e => e.TenChucVu).HasMaxLength(1000);
            });

            modelBuilder.Entity<DanhSachDoiTuongGium>(entity =>
            {
                entity.HasKey(e => e.IdDanhSachDoiTuongGia);

                entity.Property(e => e.IdDanhSachDoiTuongGia).HasMaxLength(50);

                entity.Property(e => e.DonViTinh).HasMaxLength(50);

                entity.Property(e => e.KyHieu).HasMaxLength(50);

                entity.Property(e => e.MoTa).HasMaxLength(1000);
            });

            modelBuilder.Entity<DoiTuongGium>(entity =>
            {
                entity.HasKey(e => e.IdDoiTuongGia)
                    .HasName("PK_PriceObject");

                entity.Property(e => e.IdDoiTuongGia).HasMaxLength(50);

                entity.Property(e => e.CoVat).HasColumnName("CoVAT");

                entity.Property(e => e.IdDanhSachDoiTuongGia).HasMaxLength(50);

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");

                entity.Property(e => e.PhiBvmt).HasColumnName("PhiBVMT");

                entity.Property(e => e.VatphiDuyTri).HasColumnName("VATPhiDuyTri");

                entity.HasOne(d => d.IdDanhSachDoiTuongGiaNavigation)
                    .WithMany(p => p.DoiTuongGia)
                    .HasForeignKey(d => d.IdDanhSachDoiTuongGia)
                    .HasConstraintName("FK_DoiTuongGia_DoiTuongGia");
            });

            modelBuilder.Entity<DongHoNuoc>(entity =>
            {
                entity.HasKey(e => e.IdDongHoNuoc)
                    .HasName("PK_WaterClock");

                entity.ToTable("DongHoNuoc");

                entity.Property(e => e.IdDongHoNuoc).HasMaxLength(50);

                entity.Property(e => e.IdDongHoChinh).HasMaxLength(50);

                entity.Property(e => e.IdHopDong).HasMaxLength(50);

                entity.Property(e => e.IdNguoiDung).HasMaxLength(50);

                entity.Property(e => e.LoaiDongHo).HasMaxLength(50);

                entity.Property(e => e.LyDoHuy).HasMaxLength(1000);

                entity.Property(e => e.PhamVi).HasMaxLength(50);

                entity.Property(e => e.SeriDongHo).HasMaxLength(50);

                entity.Property(e => e.TrangThaiSuDung).HasMaxLength(50);

                entity.HasOne(d => d.IdHopDongNavigation)
                    .WithMany(p => p.DongHoNuocs)
                    .HasForeignKey(d => d.IdHopDong)
                    .HasConstraintName("FK_DongHoNuoc_HopDong");
            });

            modelBuilder.Entity<DongHoNuocSuCo>(entity =>
            {
                entity.HasKey(e => new { e.IdDongHoNuoc, e.IdSuCo })
                    .HasName("PK_WaterBlock_Problem");

                entity.ToTable("DongHoNuoc_SuCo");

                entity.Property(e => e.IdDongHoNuoc).HasMaxLength(50);

                entity.Property(e => e.IdSuCo).HasMaxLength(50);

                entity.Property(e => e.CachKhacPhuc).HasMaxLength(50);

                entity.Property(e => e.IdNguoiBaoCao).HasMaxLength(50);

                entity.Property(e => e.IdNguoiThucHien).HasMaxLength(50);

                entity.Property(e => e.NgaySuCo).HasColumnType("datetime");

                entity.HasOne(d => d.IdDongHoNuocNavigation)
                    .WithMany(p => p.DongHoNuocSuCos)
                    .HasForeignKey(d => d.IdDongHoNuoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WaterBlock_Problem_WaterBlock_Problem");

                entity.HasOne(d => d.IdSuCoNavigation)
                    .WithMany(p => p.DongHoNuocSuCos)
                    .HasForeignKey(d => d.IdSuCo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WaterClock_Problem_Problem");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.IdHoaDon)
                    .HasName("PK_Invoice");

                entity.ToTable("HoaDon");

                entity.Property(e => e.IdHoaDon).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(1000);

                entity.Property(e => e.IdHopDong).HasMaxLength(50);

                entity.Property(e => e.IdNguoiThuTien).HasMaxLength(50);

                entity.Property(e => e.IdThongBao).HasMaxLength(50);

                entity.Property(e => e.PhiBvmt).HasColumnName("PhiBVMT");

                entity.Property(e => e.PhiDtdn).HasColumnName("PhiDTDN");

                entity.Property(e => e.SeriHoaDon).HasMaxLength(50);

                entity.Property(e => e.TongTienTruocVat).HasColumnName("TongTienTruocVAT");

                entity.Property(e => e.TrangThaiThanhToan).HasMaxLength(50);

                entity.Property(e => e.Vat).HasColumnName("VAT");

                entity.HasOne(d => d.IdHopDongNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IdHopDong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Contract");

                entity.HasOne(d => d.IdThongBaoNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IdThongBao)
                    .HasConstraintName("FK_HoaDon_ThongBao");
            });

            modelBuilder.Entity<HopDong>(entity =>
            {
                entity.HasKey(e => e.IdHopDong)
                    .HasName("PK_Contract");

                entity.ToTable("HopDong");

                entity.Property(e => e.IdHopDong).HasMaxLength(50);

                entity.Property(e => e.Diachi).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.IdDanhSachDoiTuongGia).HasMaxLength(50);

                entity.Property(e => e.IdKhachHang).HasMaxLength(50);

                entity.Property(e => e.IdNhaMay).HasMaxLength(50);

                entity.Property(e => e.IdTuyenDoc).HasMaxLength(50);

                entity.Property(e => e.KhuVucThanhToan).HasMaxLength(50);

                entity.Property(e => e.MucDichSuDung).HasMaxLength(1000);

                entity.Property(e => e.NgayCoHieuLuc).HasColumnType("datetime");

                entity.Property(e => e.NgayKyHopDong).HasColumnType("datetime");

                entity.Property(e => e.NgayLapDat).HasColumnType("datetime");

                entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);

                entity.HasOne(d => d.IdDanhSachDoiTuongGiaNavigation)
                    .WithMany(p => p.HopDongs)
                    .HasForeignKey(d => d.IdDanhSachDoiTuongGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HopDong_DanhSachDoiTuongGia");

                entity.HasOne(d => d.IdKhachHangNavigation)
                    .WithMany(p => p.HopDongs)
                    .HasForeignKey(d => d.IdKhachHang)
                    .HasConstraintName("FK_Contract_Customer");

                entity.HasOne(d => d.IdTuyenDocNavigation)
                    .WithMany(p => p.HopDongs)
                    .HasForeignKey(d => d.IdTuyenDoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HopDong_TuyenDoc");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.IdKhachHang)
                    .HasName("PK_Customer");

                entity.ToTable("KhachHang");

                entity.Property(e => e.IdKhachHang).HasMaxLength(50);

                entity.Property(e => e.DienThoai).HasMaxLength(50);

                entity.Property(e => e.DoiTuong).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.IdNhaMay).HasMaxLength(50);

                entity.Property(e => e.LoaiKhachHang).HasMaxLength(50);

                entity.Property(e => e.MaSoThue).HasMaxLength(50);

                entity.Property(e => e.NgayCapCmnd)
                    .HasMaxLength(50)
                    .HasColumnName("NgayCapCMND");

                entity.Property(e => e.NguonNuoc).HasMaxLength(50);

                entity.Property(e => e.NoiCapCmnd)
                    .HasMaxLength(50)
                    .HasColumnName("NoiCapCMND");

                entity.Property(e => e.SoCmnd)
                    .HasMaxLength(50)
                    .HasColumnName("SoCMND");

                entity.Property(e => e.SoGcn)
                    .HasMaxLength(50)
                    .HasColumnName("SoGCN");

                entity.Property(e => e.TenKhachHang).HasMaxLength(50);

                entity.Property(e => e.TenThuongGoi).HasMaxLength(50);
            });

            modelBuilder.Entity<KhuVuc>(entity =>
            {
                entity.HasKey(e => e.IdKhuvuc)
                    .HasName("PK_LineRead_Area");

                entity.ToTable("KhuVuc");

                entity.Property(e => e.IdKhuvuc).HasMaxLength(50);

                entity.Property(e => e.IdVung).HasMaxLength(50);

                entity.Property(e => e.TenKhuVuc).HasMaxLength(1000);

                entity.HasOne(d => d.IdVungNavigation)
                    .WithMany(p => p.KhuVucs)
                    .HasForeignKey(d => d.IdVung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LineRead_Area_LineReadRegion");
            });

            modelBuilder.Entity<KyGhiChiSo>(entity =>
            {
                entity.HasKey(e => e.IdKyGhiChiSo);

                entity.ToTable("KyGhiChiSo");

                entity.Property(e => e.IdKyGhiChiSo).HasMaxLength(50);

                entity.Property(e => e.IdNhaMay).HasMaxLength(50);

                entity.Property(e => e.Mota).HasMaxLength(1000);

                entity.Property(e => e.NgayHoaDon).HasColumnType("datetime");

                entity.Property(e => e.NgaySuDungDen).HasColumnType("datetime");

                entity.Property(e => e.NgaySuDungTu).HasColumnType("datetime");
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.IdNguoiDung)
                    .HasName("PK_User");

                entity.ToTable("NguoiDung");

                entity.Property(e => e.IdNguoiDung).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IdDangNhap).HasMaxLength(50);

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.HasMany(d => d.IdChucNangs)
                    .WithMany(p => p.IdNguoiDungs)
                    .UsingEntity<Dictionary<string, object>>(
                        "NguoiDungChucNang",
                        l => l.HasOne<ChucNang>().WithMany().HasForeignKey("IdChucNang").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_NguoiDung_ChucNang_ChucNang"),
                        r => r.HasOne<NguoiDung>().WithMany().HasForeignKey("IdNguoiDung").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Role_Function_Function"),
                        j =>
                        {
                            j.HasKey("IdNguoiDung", "IdChucNang").HasName("PK_Role_Function");

                            j.ToTable("NguoiDung_ChucNang");

                            j.IndexerProperty<string>("IdNguoiDung").HasMaxLength(50);

                            j.IndexerProperty<string>("IdChucNang").HasMaxLength(50);
                        });

                entity.HasMany(d => d.IdChucVus)
                    .WithMany(p => p.IdNguoiDungs)
                    .UsingEntity<Dictionary<string, object>>(
                        "NguoiDungChucVu",
                        l => l.HasOne<ChucVu>().WithMany().HasForeignKey("IdChucVu").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_User_Role_Role"),
                        r => r.HasOne<NguoiDung>().WithMany().HasForeignKey("IdNguoiDung").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_User_Role_User"),
                        j =>
                        {
                            j.HasKey("IdNguoiDung", "IdChucVu").HasName("PK_User_Role");

                            j.ToTable("NguoiDung_ChucVu");

                            j.IndexerProperty<string>("IdNguoiDung").HasMaxLength(50);

                            j.IndexerProperty<string>("IdChucVu").HasMaxLength(50);
                        });
            });

            modelBuilder.Entity<NhaMay>(entity =>
            {
                entity.HasKey(e => e.IdNhaMay)
                    .HasName("PK_Factory");

                entity.ToTable("NhaMay");

                entity.Property(e => e.IdNhaMay).HasMaxLength(50);
            });

            modelBuilder.Entity<NhatKyDuLieu>(entity =>
            {
                entity.HasKey(e => e.IdNhatKy);

                entity.ToTable("NhatKyDuLieu");

                entity.Property(e => e.IdNhatKy).HasMaxLength(50);

                entity.Property(e => e.IdNhaMay).HasMaxLength(50);

                entity.Property(e => e.IdNhanVien).HasMaxLength(50);

                entity.Property(e => e.Ip)
                    .HasMaxLength(50)
                    .HasColumnName("IP");

                entity.Property(e => e.Mota).HasMaxLength(1000);

                entity.Property(e => e.SuKien).HasMaxLength(50);

                entity.Property(e => e.ThoiGian).HasColumnType("datetime");

                entity.Property(e => e.ThuocBang).HasMaxLength(50);
            });

            modelBuilder.Entity<NhatKyHoaDon>(entity =>
            {
                entity.HasKey(e => e.IdNhatKyHoaDon);

                entity.ToTable("NhatKyHoaDon");

                entity.Property(e => e.IdNhatKyHoaDon).HasMaxLength(50);

                entity.Property(e => e.IdHoaDon).HasMaxLength(50);

                entity.Property(e => e.IdNguoiDung).HasMaxLength(50);

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NoiDung).HasMaxLength(1000);

                entity.HasOne(d => d.IdHoaDonNavigation)
                    .WithMany(p => p.NhatKyHoaDons)
                    .HasForeignKey(d => d.IdHoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NhatKyHoaDon_HoaDon");
            });

            modelBuilder.Entity<SoDocChiSo>(entity =>
            {
                entity.HasKey(e => e.IdSoDocChiSo);

                entity.ToTable("SoDocChiSo");

                entity.Property(e => e.IdSoDocChiSo).HasMaxLength(50);

                entity.Property(e => e.HoaDon).HasMaxLength(50);

                entity.Property(e => e.IdKyGhiChiSo).HasMaxLength(50);

                entity.Property(e => e.IdNguoiDung).HasMaxLength(50);

                entity.Property(e => e.IdNhaMay).HasMaxLength(50);

                entity.Property(e => e.IdTuyenDoc).HasMaxLength(50);

                entity.Property(e => e.NgayChot).HasColumnType("datetime");

                entity.Property(e => e.SoDhdaGhi).HasColumnName("SoDHDaGhi");

                entity.Property(e => e.TenSo).HasMaxLength(1000);

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.IdKyGhiChiSoNavigation)
                    .WithMany(p => p.SoDocChiSos)
                    .HasForeignKey(d => d.IdKyGhiChiSo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoDocChiSo_SoDocChiSo");

                entity.HasOne(d => d.IdTuyenDocNavigation)
                    .WithMany(p => p.SoDocChiSos)
                    .HasForeignKey(d => d.IdTuyenDoc)
                    .HasConstraintName("FK_SoDocChiSo_TuyenDoc");
            });

            modelBuilder.Entity<SuCo>(entity =>
            {
                entity.HasKey(e => e.IdSuCo)
                    .HasName("PK_WaterClock_Problem");

                entity.ToTable("SuCo");

                entity.Property(e => e.IdSuCo).HasMaxLength(50);

                entity.Property(e => e.MoTa).HasMaxLength(1000);

                entity.Property(e => e.TenSuCo).HasMaxLength(1000);
            });

            modelBuilder.Entity<ThatThoat>(entity =>
            {
                entity.HasKey(e => e.IdThatThoat)
                    .HasName("PK_WaterLoss_Block");

                entity.ToTable("ThatThoat");

                entity.Property(e => e.IdThatThoat).HasMaxLength(50);

                entity.Property(e => e.IdDongHoNuoc).HasMaxLength(50);

                entity.Property(e => e.Sldhc).HasColumnName("SLDHC");

                entity.Property(e => e.ThoiGian).HasColumnType("datetime");

                entity.HasOne(d => d.IdDongHoNuocNavigation)
                    .WithMany(p => p.ThatThoats)
                    .HasForeignKey(d => d.IdDongHoNuoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThatThoat_ThatThoat");
            });

            modelBuilder.Entity<ThongBao>(entity =>
            {
                entity.HasKey(e => e.IdThongBao);

                entity.ToTable("ThongBao");

                entity.Property(e => e.IdThongBao).HasMaxLength(50);

                entity.Property(e => e.IdNguoiDoc).HasMaxLength(50);

                entity.Property(e => e.IdNhaMay).HasMaxLength(50);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.TenPhien).HasMaxLength(1000);
            });

            modelBuilder.Entity<TrangThaiGhi>(entity =>
            {
                entity.HasKey(e => e.IdTrangThaiGhi);

                entity.ToTable("TrangThaiGhi");

                entity.Property(e => e.IdTrangThaiGhi).HasMaxLength(50);

                entity.Property(e => e.MaMau).HasMaxLength(50);

                entity.Property(e => e.MoTaNgan).HasMaxLength(1000);

                entity.Property(e => e.SoTt).HasColumnName("SoTT");

                entity.Property(e => e.TenTrangThai).HasMaxLength(50);
            });

            modelBuilder.Entity<TuyenDoc>(entity =>
            {
                entity.HasKey(e => e.IdTuyenDoc)
                    .HasName("PK_LineRead");

                entity.ToTable("TuyenDoc");

                entity.Property(e => e.IdTuyenDoc).HasMaxLength(50);

                entity.Property(e => e.IdKhuVuc).HasMaxLength(50);

                entity.Property(e => e.IdNguoiQuanLy).HasMaxLength(50);

                entity.Property(e => e.IdNguoiThuTien).HasMaxLength(50);

                entity.Property(e => e.IdNhaMay).HasMaxLength(50);

                entity.Property(e => e.MaTuyen).HasMaxLength(50);

                entity.Property(e => e.TenTuyen).HasMaxLength(1000);

                entity.HasOne(d => d.IdKhuVucNavigation)
                    .WithMany(p => p.TuyenDocs)
                    .HasForeignKey(d => d.IdKhuVuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LineRead_LineRead");
            });

            modelBuilder.Entity<TyLeBaoPhu>(entity =>
            {
                entity.HasKey(e => e.IdTuyenDocVung)
                    .HasName("PK_CoverageRate");

                entity.ToTable("TyLeBaoPhu");

                entity.Property(e => e.IdTuyenDocVung)
                    .HasMaxLength(50)
                    .HasColumnName("IdTuyenDoc_Vung");
            });

            modelBuilder.Entity<Vung>(entity =>
            {
                entity.HasKey(e => e.IdVung)
                    .HasName("PK_LineReadRegion");

                entity.ToTable("Vung");

                entity.Property(e => e.IdVung).HasMaxLength(50);

                entity.Property(e => e.IdNhaMay).HasMaxLength(50);

                entity.Property(e => e.TenVung).HasMaxLength(1000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
*/