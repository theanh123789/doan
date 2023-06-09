create database [QuanLyBanDungcuTheThao]
go

USE [QuanLyBanDungcuTheThao]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_DoanhThuTheoThang]    Script Date: 21/05/2023 8:07:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_DoanhThuTheoThang] (@thang int, @nam int)
RETURNS @DoanhThu TABLE (
    Ngay DATE,
    DoanhThu FLOAT
)
AS
BEGIN
    DECLARE @StartDate DATE
    DECLARE @EndDate DATE
    SET @StartDate = CAST(CAST(@nam AS VARCHAR) + '-' + CAST(@thang AS VARCHAR) + '-01' AS DATE)
    SET @EndDate = DATEADD(DAY, -1, DATEADD(MONTH, 1, @StartDate))
    
    INSERT INTO @DoanhThu (Ngay, DoanhThu)
    SELECT CONVERT(DATE, ngayBan) AS Ngay, SUM(tongTien) AS DoanhThu
    FROM hoaDonBan
    WHERE NgayBan BETWEEN @StartDate AND @EndDate
    GROUP BY CONVERT(DATE, NgayBan)
    
    RETURN
END
GO
/****** Object:  Table [dbo].[chiTietHoaDonBan]    Script Date: 21/05/2023 8:07:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chiTietHoaDonBan](
	[idChiTietHoaDonBan] [char](10) NULL,
	[idSanPham] [char](10) NULL,
	[soLuong] [int] NULL,
	[giaBan] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chiTietHoaDonNhap]    Script Date: 21/05/2023 8:07:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chiTietHoaDonNhap](
	[idHoaDonNhap] [char](10) NULL,
	[idSanpham] [char](10) NULL,
	[soluong] [int] NULL,
	[DonGia] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hoaDonBan]    Script Date: 21/05/2023 8:07:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoaDonBan](
	[idHoaDonBan] [char](10) NOT NULL,
	[idNhanVien] [char](10) NULL,
	[idKhachHang] [char](10) NULL,
	[ngayBan] [date] NULL,
	[tongTien] [float] NULL,
 CONSTRAINT [PK_hoaDonBan] PRIMARY KEY CLUSTERED 
(
	[idHoaDonBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hoaDonNhap]    Script Date: 21/05/2023 8:07:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoaDonNhap](
	[idHoaDonNhap] [char](10) NOT NULL,
	[idNhanVien] [char](10) NOT NULL,
	[idNhaCC] [char](10) NOT NULL,
	[ngayNhap] [date] NOT NULL,
	[tongTien] [float] NOT NULL,
 CONSTRAINT [PK_hoaDonNhap] PRIMARY KEY CLUSTERED 
(
	[idHoaDonNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khachHang]    Script Date: 21/05/2023 8:07:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachHang](
	[idKhachHang] [char](10) NOT NULL,
	[tenKhachHang] [nvarchar](50) NULL,
	[sdtKhachHang] [char](13) NULL,
 CONSTRAINT [PK_khachHang] PRIMARY KEY CLUSTERED 
(
	[idKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhaCC]    Script Date: 21/05/2023 8:07:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhaCC](
	[idNhaCC] [char](10) NOT NULL,
	[tenNhaCC] [nvarchar](50) NULL,
	[sdtNhaCC] [char](12) NULL,
	[diaChiNhaCC] [nchar](10) NULL,
 CONSTRAINT [PK_nhaCC] PRIMARY KEY CLUSTERED 
(
	[idNhaCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhanVien]    Script Date: 21/05/2023 8:07:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhanVien](
	[idNhanVien] [char](10) NOT NULL,
	[tenNv] [nvarchar](50) NULL,
	[namSinh] [date] NULL,
	[queQuanNv] [nvarchar](50) NULL,
	[sdtNv] [char](12) NULL,
	[luongCb] [int] NULL,
	[taiKhoan] [char](100) NULL,
	[matKhau] [char](100) NULL,
	[quyen] [int] NULL,
 CONSTRAINT [PK_nhanVien] PRIMARY KEY CLUSTERED 
(
	[idNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


go
/****** Object:  Table [dbo].[sanPham]    Script Date: 21/05/2023 8:07:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanPham](
	[idSanPham] [char](10) NOT NULL,
	[tenSanPham] [nvarchar](50) NULL,
	[hangSx] [nvarchar](50) NULL,
	[loaiSanPham] [nvarchar](50) NULL,
	[moTa] [nvarchar](50) NULL,
	[giaBan] [int] NULL,
	[soLuong] [int] NULL,
 CONSTRAINT [PK_sanPham] PRIMARY KEY CLUSTERED 
(
	[idSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[chiTietHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_chiTietHoaDonBan_hoaDonBan] FOREIGN KEY([idChiTietHoaDonBan])
REFERENCES [dbo].[hoaDonBan] ([idHoaDonBan])
GO
ALTER TABLE [dbo].[chiTietHoaDonBan] CHECK CONSTRAINT [FK_chiTietHoaDonBan_hoaDonBan]
GO
ALTER TABLE [dbo].[chiTietHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_chiTietHoaDonBan_sanPham] FOREIGN KEY([idSanPham])
REFERENCES [dbo].[sanPham] ([idSanPham])
GO
ALTER TABLE [dbo].[chiTietHoaDonBan] CHECK CONSTRAINT [FK_chiTietHoaDonBan_sanPham]
GO
ALTER TABLE [dbo].[chiTietHoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_chiTietHoaDonNhap_hoaDonNhap] FOREIGN KEY([idHoaDonNhap])
REFERENCES [dbo].[hoaDonNhap] ([idHoaDonNhap])
GO
ALTER TABLE [dbo].[chiTietHoaDonNhap] CHECK CONSTRAINT [FK_chiTietHoaDonNhap_hoaDonNhap]
GO
ALTER TABLE [dbo].[chiTietHoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_chiTietHoaDonNhap_sanPham] FOREIGN KEY([idSanpham])
REFERENCES [dbo].[sanPham] ([idSanPham])
GO
ALTER TABLE [dbo].[chiTietHoaDonNhap] CHECK CONSTRAINT [FK_chiTietHoaDonNhap_sanPham]
GO
ALTER TABLE [dbo].[hoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_hoaDonBan_khachHang] FOREIGN KEY([idKhachHang])
REFERENCES [dbo].[khachHang] ([idKhachHang])
GO
ALTER TABLE [dbo].[hoaDonBan] CHECK CONSTRAINT [FK_hoaDonBan_khachHang]
GO
ALTER TABLE [dbo].[hoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_hoaDonBan_nhanVien] FOREIGN KEY([idNhanVien])
REFERENCES [dbo].[nhanVien] ([idNhanVien])
GO
ALTER TABLE [dbo].[hoaDonBan] CHECK CONSTRAINT [FK_hoaDonBan_nhanVien]
GO
ALTER TABLE [dbo].[hoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_hoaDonNhap_nhaCC] FOREIGN KEY([idNhaCC])
REFERENCES [dbo].[nhaCC] ([idNhaCC])
GO
ALTER TABLE [dbo].[hoaDonNhap] CHECK CONSTRAINT [FK_hoaDonNhap_nhaCC]
GO
ALTER TABLE [dbo].[hoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_hoaDonNhap_nhanVien] FOREIGN KEY([idNhanVien])
REFERENCES [dbo].[nhanVien] ([idNhanVien])
GO
ALTER TABLE [dbo].[hoaDonNhap] CHECK CONSTRAINT [FK_hoaDonNhap_nhanVien]
GO
/****** Object:  StoredProcedure [dbo].[ThemHoaDonban]    Script Date: 21/05/2023 8:07:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ThemHoaDonban]
    @MaHoaDon char(10),
    @MaSanPham char(10),
    @SoLuong INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE  @TongTienMoi FLOAT;
	select @TongTienMoi = @SoLuong * giaBan  from dbo.sanPham where idSanpham = @MaSanPham
	
	

    IF EXISTS (SELECT 1 FROM chiTietHoaDonBan WHERE idChiTietHoaDonBan = @MaHoaDon AND idSanpham = @MaSanPham)
    BEGIN
	
		UPDATE dbo.chiTietHoaDonBan set soluong = soluong+@SoLuong  ,giaBan =giaBan+@TongTienMoi  where idChiTietHoaDonBan =@MaHoaDon AND idSanpham = @MaSanPham
		UPDATE dbo.hoaDonNhap set tongTien = tongTien+ @TongTienMoi where idHoaDonNhap =@MaHoaDon
		UPDATE dbo.sanPham set soLuong = soLuong- @SoLuong where idSanpham = @MaSanPham

    END
    ELSE
    BEGIN

		insert into dbo.chiTietHoaDonBan(idChiTietHoaDonBan,idSanpham,soluong,giaBan) values(@MaHoaDon,@MaSanPham,@SoLuong,@TongTienMoi)
		UPDATE dbo.hoaDonBan set tongTien = tongTien+ @TongTienMoi where idHoaDonBan =@MaHoaDon
		UPDATE dbo.sanPham set soLuong = soLuong- @SoLuong where idSanpham = @MaSanPham

        
    END
END

GO
/****** Object:  StoredProcedure [dbo].[ThemHoaDonNhap]    Script Date: 21/05/2023 8:07:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ThemHoaDonNhap]
    @MaHoaDon char(10),
    @MaSanPham char(10),
    @SoLuong INT,
    @Gia FLOAT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE  @TongTienMoi FLOAT;

	
	

    IF EXISTS (SELECT 1 FROM chiTietHoaDonNhap WHERE idHoaDonNhap = @MaHoaDon AND idSanpham = @MaSanPham)
    BEGIN
	
		UPDATE dbo.chiTietHoaDonNhap set soluong = soluong+@SoLuong  ,DonGia =DonGia+@Gia  where idHoaDonNhap =@MaHoaDon AND idSanpham = @MaSanPham
		UPDATE dbo.hoaDonNhap set tongTien = tongTien+ @Gia where idHoaDonNhap =@MaHoaDon
		UPDATE dbo.sanPham set soLuong = soLuong+ @SoLuong where idSanpham = @MaSanPham

    END
    ELSE
    BEGIN

		insert into dbo.chiTietHoaDonNhap(idHoaDonNhap,idSanpham,soluong,DonGia) values(@MaHoaDon,@MaSanPham,@SoLuong,@Gia)
		UPDATE dbo.hoaDonNhap set tongTien = tongTien+ @Gia where idHoaDonNhap =@MaHoaDon
		UPDATE dbo.sanPham set soLuong = soLuong+ @SoLuong where idSanpham = @MaSanPham

        
    END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 21/05/2023 8:07:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[USP_Login]
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.nhanVien WHERE taiKhoan = @userName AND matKhau = @passWord
END
GO
/****** Object:  StoredProcedure [dbo].[xoaHoaDonBan]    Script Date: 21/05/2023 8:07:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[xoaHoaDonBan]
    @MaHoaDon char(10),
    @MaSanPham char(10)

AS
BEGIN

	DECLARE  @TongTien FLOAT,@SoLuong int;
	select @TongTien = giaBan  ,@SoLuong=soluong from dbo.chiTietHoaDonBan where idChiTietHoaDonBan = @MaHoaDon AND idSanpham = @MaSanPham
	
		UPDATE dbo.hoaDonBan set tongTien = tongTien- @TongTien where idHoaDonBan =@MaHoaDon
		UPDATE dbo.sanPham set soLuong = soLuong+ @SoLuong where idSanpham = @MaSanPham
		delete from dbo.chiTietHoaDonBan where idChiTietHoaDonBan = @MaHoaDon AND idSanpham = @MaSanPham
	 
   
	

END

GO
/****** Object:  StoredProcedure [dbo].[xoaHoaDonNhap]    Script Date: 21/05/2023 8:07:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[xoaHoaDonNhap]
    @MaHoaDon char(10),
    @MaSanPham char(10)

AS
BEGIN

	DECLARE  @TongTien FLOAT,@SoLuong int;
	select @TongTien = DonGia  ,@SoLuong=soluong from dbo.chiTietHoaDonNhap where idHoaDonNhap = @MaHoaDon AND idSanpham = @MaSanPham
	
		UPDATE dbo.hoaDonNhap set tongTien = tongTien- @TongTien where idHoaDonNhap =@MaHoaDon
		UPDATE dbo.sanPham set soLuong = soLuong- @SoLuong where idSanpham = @MaSanPham
		delete from dbo.chiTietHoaDonNhap where idHoaDonNhap = @MaHoaDon AND idSanpham = @MaSanPham
	 
   
	

END

GO
