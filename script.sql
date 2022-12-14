USE [master]
GO
/****** Object:  Database [QL_ThuVien]    Script Date: 11/30/2022 11:45:16 PM ******/
CREATE DATABASE [QL_ThuVien]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_ThuVien', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.GIANG\MSSQL\DATA\QL_ThuVien.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QL_ThuVien_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.GIANG\MSSQL\DATA\QL_ThuVien_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QL_ThuVien] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_ThuVien].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_ThuVien] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_ThuVien] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_ThuVien] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_ThuVien] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_ThuVien] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_ThuVien] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QL_ThuVien] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_ThuVien] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_ThuVien] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_ThuVien] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_ThuVien] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_ThuVien] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_ThuVien] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_ThuVien] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_ThuVien] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QL_ThuVien] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_ThuVien] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_ThuVien] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_ThuVien] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_ThuVien] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_ThuVien] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_ThuVien] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_ThuVien] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QL_ThuVien] SET  MULTI_USER 
GO
ALTER DATABASE [QL_ThuVien] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_ThuVien] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_ThuVien] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_ThuVien] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QL_ThuVien] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QL_ThuVien] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QL_ThuVien', N'ON'
GO
ALTER DATABASE [QL_ThuVien] SET QUERY_STORE = OFF
GO
USE [QL_ThuVien]
GO
/****** Object:  Table [dbo].[Tbl_ChiTietDonMuon]    Script Date: 11/30/2022 11:45:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_ChiTietDonMuon](
	[St_MaDonMuon] [int] NOT NULL,
	[St_MaSach] [int] NOT NULL,
	[in_SoLuong] [smallint] NOT NULL,
	[Da_NgayMuon] [date] NULL,
	[Da_NgayTra] [date] NULL,
	[Bi_TrangThai] [bit] NULL,
 CONSTRAINT [PK_Tbl_ChiTietDonMuon] PRIMARY KEY CLUSTERED 
(
	[St_MaDonMuon] ASC,
	[St_MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_DonMuonSach]    Script Date: 11/30/2022 11:45:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_DonMuonSach](
	[St_MaDonMuon] [int] IDENTITY(1,1) NOT NULL,
	[St_MaSinhVien] [nvarchar](9) NOT NULL,
	[St_MaKhoa] [nchar](10) NOT NULL,
	[Da_NgayMuon] [date] NULL,
	[Da_NgayTra] [date] NOT NULL,
	[Bi_TrangThai] [bit] NOT NULL,
 CONSTRAINT [PK_Tbl_DonMuonSach] PRIMARY KEY CLUSTERED 
(
	[St_MaDonMuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_KeSach]    Script Date: 11/30/2022 11:45:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_KeSach](
	[St_MaKeSach] [int] IDENTITY(1,1) NOT NULL,
	[St_TenKeSach] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_KeSach] PRIMARY KEY CLUSTERED 
(
	[St_MaKeSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Khoa]    Script Date: 11/30/2022 11:45:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Khoa](
	[St_MaKhoa] [int] IDENTITY(1,1) NOT NULL,
	[St_TenKhoa] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Khoa] PRIMARY KEY CLUSTERED 
(
	[St_MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_LoaiSach]    Script Date: 11/30/2022 11:45:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_LoaiSach](
	[St_MaLoaiSach] [int] IDENTITY(1,1) NOT NULL,
	[St_TenSach] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_LoaiSach] PRIMARY KEY CLUSTERED 
(
	[St_MaLoaiSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Sach]    Script Date: 11/30/2022 11:45:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Sach](
	[St_MaSach] [int] IDENTITY(1,1) NOT NULL,
	[St_TenSach] [nvarchar](max) NOT NULL,
	[St_MaLoaiSach] [int] NOT NULL,
	[St_MaTacGia] [int] NOT NULL,
	[St_MaKeSach] [int] NOT NULL,
	[St_TomTat] [nvarchar](max) NOT NULL,
	[St_TinhTrang] [nvarchar](max) NOT NULL,
	[St_Anh] [nvarchar](max) NULL,
	[In_SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_Sach] PRIMARY KEY CLUSTERED 
(
	[St_MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_SinhVien]    Script Date: 11/30/2022 11:45:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_SinhVien](
	[St_MaSinhVien] [nvarchar](9) NOT NULL,
	[St_TenSinhVien] [nvarchar](50) NOT NULL,
	[St_MaKhoa] [int] NOT NULL,
	[In_SoLanBiPhat] [smallint] NOT NULL,
	[St_Gmail] [nvarchar](50) NOT NULL,
	[St_SoDienThoai] [nvarchar](12) NOT NULL,
 CONSTRAINT [PK_Tbl_SinhVien] PRIMARY KEY CLUSTERED 
(
	[St_MaSinhVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_TacGia]    Script Date: 11/30/2022 11:45:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_TacGia](
	[St_MaTacGia] [int] IDENTITY(1,1) NOT NULL,
	[St_TenTacGia] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_TacGia] PRIMARY KEY CLUSTERED 
(
	[St_MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_TaiKhoan]    Script Date: 11/30/2022 11:45:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_TaiKhoan](
	[In_MaTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[St_MaSinhVien] [nvarchar](9) NOT NULL,
	[St_MatKhau] [nvarchar](max) NOT NULL,
	[In_MaQuyenHan] [smallint] NOT NULL,
	[Bi_TrangThai] [bit] NOT NULL,
	[Da_NgayDangNhap] [datetime] NULL,
	[Da_NgayTao] [datetime] NOT NULL,
	[St_Salt] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Tbl_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[In_MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblQuyenHan]    Script Date: 11/30/2022 11:45:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblQuyenHan](
	[In_MaQuyenHan] [smallint] IDENTITY(1,1) NOT NULL,
	[St_TenQuyenHan] [nvarchar](50) NOT NULL,
	[St_GhiChu] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TblQuyenHan] PRIMARY KEY CLUSTERED 
(
	[In_MaQuyenHan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (21, 23, 3, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (22, 23, 2, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (23, 19, 1, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (23, 23, 3, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (24, 19, 1, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (24, 23, 4, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (37, 23, 1, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (38, 19, 1, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (38, 22, 1, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (38, 23, 2, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (39, 19, 1, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (39, 23, 1, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (40, 21, 1, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (40, 22, 1, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (40, 23, 1, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (41, 18, 1, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (41, 21, 1, NULL, NULL, NULL)
INSERT [dbo].[Tbl_ChiTietDonMuon] ([St_MaDonMuon], [St_MaSach], [in_SoLuong], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (41, 22, 1, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Tbl_DonMuonSach] ON 

INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (21, N'DPM195207', N'1         ', NULL, CAST(N'0022-03-08' AS Date), 1)
INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (22, N'DPM195207', N'1         ', NULL, CAST(N'0001-01-01' AS Date), 1)
INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (23, N'DPM195207', N'1         ', NULL, CAST(N'0001-01-01' AS Date), 1)
INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (24, N'DPM195207', N'1         ', CAST(N'0001-01-01' AS Date), CAST(N'0001-01-01' AS Date), 0)
INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (26, N'DPM195207', N'1         ', NULL, CAST(N'0001-01-01' AS Date), 0)
INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (27, N'DPM195207', N'1         ', NULL, CAST(N'0001-01-01' AS Date), 0)
INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (28, N'DPM195207', N'1         ', NULL, CAST(N'0001-01-01' AS Date), 0)
INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (29, N'DPM195207', N'1         ', NULL, CAST(N'0001-01-01' AS Date), 0)
INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (30, N'DPM195207', N'1         ', NULL, CAST(N'0001-01-01' AS Date), 0)
INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (36, N'DPM195207', N'1         ', NULL, CAST(N'0001-01-01' AS Date), 0)
INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (37, N'DPM195206', N'1         ', CAST(N'0001-01-01' AS Date), CAST(N'0001-01-01' AS Date), 1)
INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (38, N'DPM195206', N'1         ', CAST(N'0001-01-01' AS Date), CAST(N'0001-01-01' AS Date), 0)
INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (39, N'DPM195208', N'1         ', CAST(N'2022-01-04' AS Date), CAST(N'2022-03-04' AS Date), 0)
INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (40, N'DPM195208', N'1         ', CAST(N'2022-01-01' AS Date), CAST(N'2022-04-01' AS Date), 0)
INSERT [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon], [St_MaSinhVien], [St_MaKhoa], [Da_NgayMuon], [Da_NgayTra], [Bi_TrangThai]) VALUES (41, N'DPM195208', N'1         ', CAST(N'2022-01-04' AS Date), CAST(N'2022-01-03' AS Date), 0)
SET IDENTITY_INSERT [dbo].[Tbl_DonMuonSach] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_KeSach] ON 

INSERT [dbo].[Tbl_KeSach] ([St_MaKeSach], [St_TenKeSach]) VALUES (1, N'Kệ 1')
INSERT [dbo].[Tbl_KeSach] ([St_MaKeSach], [St_TenKeSach]) VALUES (2, N'Kệ 1A')
INSERT [dbo].[Tbl_KeSach] ([St_MaKeSach], [St_TenKeSach]) VALUES (3, N'Kệ 2')
SET IDENTITY_INSERT [dbo].[Tbl_KeSach] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Khoa] ON 

INSERT [dbo].[Tbl_Khoa] ([St_MaKhoa], [St_TenKhoa]) VALUES (1, N'CNTT')
INSERT [dbo].[Tbl_Khoa] ([St_MaKhoa], [St_TenKhoa]) VALUES (2, N'Khoa ky thuat moi truong')
INSERT [dbo].[Tbl_Khoa] ([St_MaKhoa], [St_TenKhoa]) VALUES (3, N'Công nghệ thông tin')
SET IDENTITY_INSERT [dbo].[Tbl_Khoa] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_LoaiSach] ON 

INSERT [dbo].[Tbl_LoaiSach] ([St_MaLoaiSach], [St_TenSach]) VALUES (1, N'Sách ngôn ngữ')
INSERT [dbo].[Tbl_LoaiSach] ([St_MaLoaiSach], [St_TenSach]) VALUES (2, N'Sách địa lý')
SET IDENTITY_INSERT [dbo].[Tbl_LoaiSach] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Sach] ON 

INSERT [dbo].[Tbl_Sach] ([St_MaSach], [St_TenSach], [St_MaLoaiSach], [St_MaTacGia], [St_MaKeSach], [St_TomTat], [St_TinhTrang], [St_Anh], [In_SoLuong]) VALUES (18, N'sách tiếng việt', 1, 1, 1, N'Sách tiếng việt 1Sách tiếng việt 1Sách tiếng việt 1Sách tiếng việt 1Sách tiếng việt 1Sách tiếng việt 1Sách tiếng việt 1Sách tiếng việt 1Sách tiếng việt 1Sách tiếng việt 1Sách tiếng việt 1Sách tiếng việt 1Sách tiếng việt 1', N'còn', N'3e841f1a-5423-472c-baeb-512c6ef5cab1_000.jpg', 1)
INSERT [dbo].[Tbl_Sach] ([St_MaSach], [St_TenSach], [St_MaLoaiSach], [St_MaTacGia], [St_MaKeSach], [St_TomTat], [St_TinhTrang], [St_Anh], [In_SoLuong]) VALUES (19, N'Sách tiếng anh', 1, 1, 1, N'Sách tiếng anh cho trẻ em', N'còn', N'817b6d6d-6ce5-4673-b945-7f8a09ea3abe_ẢNH-3D-1.jpg', 2)
INSERT [dbo].[Tbl_Sach] ([St_MaSach], [St_TenSach], [St_MaLoaiSach], [St_MaTacGia], [St_MaKeSach], [St_TomTat], [St_TinhTrang], [St_Anh], [In_SoLuong]) VALUES (20, N'sách địa lý', 2, 1, 1, N'sách địa lý 1', N'còn', N'ac747024-d82d-4375-bd1b-80cb30bab0f0_nhung-tu-nhan-cua-dia-ly.jpg', 1)
INSERT [dbo].[Tbl_Sach] ([St_MaSach], [St_TenSach], [St_MaLoaiSach], [St_MaTacGia], [St_MaKeSach], [St_TomTat], [St_TinhTrang], [St_Anh], [In_SoLuong]) VALUES (21, N'Sách tiếng pháp', 1, 1, 1, N'tự học tiếng pháp', N'còn', N'68a2af45-c926-40de-a3f2-e7b26917f867_Tu-hoc-tieng-phap-tap-1-500x554.jpg', 1)
INSERT [dbo].[Tbl_Sach] ([St_MaSach], [St_TenSach], [St_MaLoaiSach], [St_MaTacGia], [St_MaKeSach], [St_TomTat], [St_TinhTrang], [St_Anh], [In_SoLuong]) VALUES (22, N'sách tiếng trung', 1, 1, 1, N'123123', N'còn', N'10b3b0de-dba0-4cfd-ae9c-25d2fa133be8_tải xuống.jpg', 1)
INSERT [dbo].[Tbl_Sach] ([St_MaSach], [St_TenSach], [St_MaLoaiSach], [St_MaTacGia], [St_MaKeSach], [St_TomTat], [St_TinhTrang], [St_Anh], [In_SoLuong]) VALUES (23, N'SÁCH TEST', 1, 1, 1, N'TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST', N'CON', N'31f74312-6c93-4dbf-8220-80689c6d62b5_Tu-hoc-tieng-phap-tap-1-500x554.jpg', 1)
SET IDENTITY_INSERT [dbo].[Tbl_Sach] OFF
GO
INSERT [dbo].[Tbl_SinhVien] ([St_MaSinhVien], [St_TenSinhVien], [St_MaKhoa], [In_SoLanBiPhat], [St_Gmail], [St_SoDienThoai]) VALUES (N'DPM195201', N'Giang vương', 1, 0, N'giang1@gmail.com', N'0111111111')
INSERT [dbo].[Tbl_SinhVien] ([St_MaSinhVien], [St_TenSinhVien], [St_MaKhoa], [In_SoLanBiPhat], [St_Gmail], [St_SoDienThoai]) VALUES (N'DPM195202', N'Giang vương', 1, 0, N'giang@gmail.com1', N'01234567893')
INSERT [dbo].[Tbl_SinhVien] ([St_MaSinhVien], [St_TenSinhVien], [St_MaKhoa], [In_SoLanBiPhat], [St_Gmail], [St_SoDienThoai]) VALUES (N'DPM195203', N'Giang vương', 1, 0, N'giang2@gmail.com', N'0111111112')
INSERT [dbo].[Tbl_SinhVien] ([St_MaSinhVien], [St_TenSinhVien], [St_MaKhoa], [In_SoLanBiPhat], [St_Gmail], [St_SoDienThoai]) VALUES (N'DPM195204', N'Giang vương', 1, 0, N'giang2@gmail.com', N'0111111113')
INSERT [dbo].[Tbl_SinhVien] ([St_MaSinhVien], [St_TenSinhVien], [St_MaKhoa], [In_SoLanBiPhat], [St_Gmail], [St_SoDienThoai]) VALUES (N'DPM195205', N'Giang vương', 1, 0, N'giang123@gmail.com', N'0123456781')
INSERT [dbo].[Tbl_SinhVien] ([St_MaSinhVien], [St_TenSinhVien], [St_MaKhoa], [In_SoLanBiPhat], [St_Gmail], [St_SoDienThoai]) VALUES (N'DPM195206', N'giang', 1, 1, N'1', N'1')
INSERT [dbo].[Tbl_SinhVien] ([St_MaSinhVien], [St_TenSinhVien], [St_MaKhoa], [In_SoLanBiPhat], [St_Gmail], [St_SoDienThoai]) VALUES (N'DPM195207', N'Giang vương', 1, 0, N'giang123@gmail.com', N'0123336789')
INSERT [dbo].[Tbl_SinhVien] ([St_MaSinhVien], [St_TenSinhVien], [St_MaKhoa], [In_SoLanBiPhat], [St_Gmail], [St_SoDienThoai]) VALUES (N'DPM195208', N'Giang vương', 1, 0, N'giang11@gmail.com', N'0123336784')
INSERT [dbo].[Tbl_SinhVien] ([St_MaSinhVien], [St_TenSinhVien], [St_MaKhoa], [In_SoLanBiPhat], [St_Gmail], [St_SoDienThoai]) VALUES (N'DPM195209', N'Giang vương', 1, 0, N'giang3@gmail.com', N'0111111114')
INSERT [dbo].[Tbl_SinhVien] ([St_MaSinhVien], [St_TenSinhVien], [St_MaKhoa], [In_SoLanBiPhat], [St_Gmail], [St_SoDienThoai]) VALUES (N'dpm195222', N'testfi', 1, 0, N'asldf@gmail.com', N'0111111110')
GO
SET IDENTITY_INSERT [dbo].[Tbl_TacGia] ON 

INSERT [dbo].[Tbl_TacGia] ([St_MaTacGia], [St_TenTacGia]) VALUES (1, N'Nhà bác học test')
INSERT [dbo].[Tbl_TacGia] ([St_MaTacGia], [St_TenTacGia]) VALUES (3, N'Phạm  Văn Đồng')
INSERT [dbo].[Tbl_TacGia] ([St_MaTacGia], [St_TenTacGia]) VALUES (4, N'Nguyễn Du')
SET IDENTITY_INSERT [dbo].[Tbl_TacGia] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_TaiKhoan] ON 

INSERT [dbo].[Tbl_TaiKhoan] ([In_MaTaiKhoan], [St_MaSinhVien], [St_MatKhau], [In_MaQuyenHan], [Bi_TrangThai], [Da_NgayDangNhap], [Da_NgayTao], [St_Salt]) VALUES (4, N'DPM195206', N'579d8858b523fb3be5c2e28d77a32072', 1, 1, CAST(N'2022-11-18T19:59:46.000' AS DateTime), CAST(N'2022-11-18T19:59:46.000' AS DateTime), N'7nl7@')
INSERT [dbo].[Tbl_TaiKhoan] ([In_MaTaiKhoan], [St_MaSinhVien], [St_MatKhau], [In_MaQuyenHan], [Bi_TrangThai], [Da_NgayDangNhap], [Da_NgayTao], [St_Salt]) VALUES (5, N'DPM195207', N'91b425af2e4bc3ba396ba08acb083a06', 2, 1, CAST(N'2022-11-18T20:04:02.180' AS DateTime), CAST(N'2022-11-18T20:04:02.167' AS DateTime), N'[^j3&')
INSERT [dbo].[Tbl_TaiKhoan] ([In_MaTaiKhoan], [St_MaSinhVien], [St_MatKhau], [In_MaQuyenHan], [Bi_TrangThai], [Da_NgayDangNhap], [Da_NgayTao], [St_Salt]) VALUES (6, N'DPM195201', N'fc23a1b608d20ecf03dc610e7eb6381f', 2, 1, CAST(N'2022-11-18T21:00:47.370' AS DateTime), CAST(N'2022-11-18T21:00:47.357' AS DateTime), N'd0ek$')
INSERT [dbo].[Tbl_TaiKhoan] ([In_MaTaiKhoan], [St_MaSinhVien], [St_MatKhau], [In_MaQuyenHan], [Bi_TrangThai], [Da_NgayDangNhap], [Da_NgayTao], [St_Salt]) VALUES (7, N'DPM195203', N'89bb8e01e095f35ef1042a1502146d15', 2, 1, CAST(N'2022-11-18T21:02:49.413' AS DateTime), CAST(N'2022-11-18T21:02:49.400' AS DateTime), N'kk^@f')
INSERT [dbo].[Tbl_TaiKhoan] ([In_MaTaiKhoan], [St_MaSinhVien], [St_MatKhau], [In_MaQuyenHan], [Bi_TrangThai], [Da_NgayDangNhap], [Da_NgayTao], [St_Salt]) VALUES (8, N'DPM195204', N'5d39cf76744d1f4e29c4287825265613', 2, 1, CAST(N'2022-11-18T21:07:43.053' AS DateTime), CAST(N'2022-11-18T21:07:43.053' AS DateTime), N'a7zg$')
INSERT [dbo].[Tbl_TaiKhoan] ([In_MaTaiKhoan], [St_MaSinhVien], [St_MatKhau], [In_MaQuyenHan], [Bi_TrangThai], [Da_NgayDangNhap], [Da_NgayTao], [St_Salt]) VALUES (9, N'DPM195205', N'3444b4a859771750d0daf57513ea642a', 2, 1, CAST(N'2022-11-20T13:18:25.440' AS DateTime), CAST(N'2022-11-20T13:18:25.440' AS DateTime), N'txx(1')
INSERT [dbo].[Tbl_TaiKhoan] ([In_MaTaiKhoan], [St_MaSinhVien], [St_MatKhau], [In_MaQuyenHan], [Bi_TrangThai], [Da_NgayDangNhap], [Da_NgayTao], [St_Salt]) VALUES (10, N'DPM195208', N'ad1c8f807b23b999fc644636013268be', 2, 1, CAST(N'2022-11-20T13:22:44.470' AS DateTime), CAST(N'2022-11-20T13:22:44.470' AS DateTime), N'%h&k@')
INSERT [dbo].[Tbl_TaiKhoan] ([In_MaTaiKhoan], [St_MaSinhVien], [St_MatKhau], [In_MaQuyenHan], [Bi_TrangThai], [Da_NgayDangNhap], [Da_NgayTao], [St_Salt]) VALUES (12, N'dpm195222', N'82d9c08e0bdf68cead3fab2cd7d50dda', 2, 1, CAST(N'2022-11-30T20:12:15.627' AS DateTime), CAST(N'2022-11-30T20:12:15.627' AS DateTime), N'2{!~i')
SET IDENTITY_INSERT [dbo].[Tbl_TaiKhoan] OFF
GO
SET IDENTITY_INSERT [dbo].[TblQuyenHan] ON 

INSERT [dbo].[TblQuyenHan] ([In_MaQuyenHan], [St_TenQuyenHan], [St_GhiChu]) VALUES (1, N'admin', N'quản trị')
INSERT [dbo].[TblQuyenHan] ([In_MaQuyenHan], [St_TenQuyenHan], [St_GhiChu]) VALUES (2, N'user', N'người dùng')
SET IDENTITY_INSERT [dbo].[TblQuyenHan] OFF
GO
ALTER TABLE [dbo].[Tbl_ChiTietDonMuon]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_ChiTietDonMuon_Tbl_DonMuonSach] FOREIGN KEY([St_MaDonMuon])
REFERENCES [dbo].[Tbl_DonMuonSach] ([St_MaDonMuon])
GO
ALTER TABLE [dbo].[Tbl_ChiTietDonMuon] CHECK CONSTRAINT [FK_Tbl_ChiTietDonMuon_Tbl_DonMuonSach]
GO
ALTER TABLE [dbo].[Tbl_ChiTietDonMuon]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_ChiTietDonMuon_Tbl_Sach] FOREIGN KEY([St_MaSach])
REFERENCES [dbo].[Tbl_Sach] ([St_MaSach])
GO
ALTER TABLE [dbo].[Tbl_ChiTietDonMuon] CHECK CONSTRAINT [FK_Tbl_ChiTietDonMuon_Tbl_Sach]
GO
ALTER TABLE [dbo].[Tbl_DonMuonSach]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_DonMuonSach_Tbl_SinhVien] FOREIGN KEY([St_MaSinhVien])
REFERENCES [dbo].[Tbl_SinhVien] ([St_MaSinhVien])
GO
ALTER TABLE [dbo].[Tbl_DonMuonSach] CHECK CONSTRAINT [FK_Tbl_DonMuonSach_Tbl_SinhVien]
GO
ALTER TABLE [dbo].[Tbl_Sach]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Sach_Tbl_KeSach] FOREIGN KEY([St_MaKeSach])
REFERENCES [dbo].[Tbl_KeSach] ([St_MaKeSach])
GO
ALTER TABLE [dbo].[Tbl_Sach] CHECK CONSTRAINT [FK_Tbl_Sach_Tbl_KeSach]
GO
ALTER TABLE [dbo].[Tbl_Sach]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Sach_Tbl_LoaiSach] FOREIGN KEY([St_MaLoaiSach])
REFERENCES [dbo].[Tbl_LoaiSach] ([St_MaLoaiSach])
GO
ALTER TABLE [dbo].[Tbl_Sach] CHECK CONSTRAINT [FK_Tbl_Sach_Tbl_LoaiSach]
GO
ALTER TABLE [dbo].[Tbl_Sach]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Sach_Tbl_TacGia] FOREIGN KEY([St_MaTacGia])
REFERENCES [dbo].[Tbl_TacGia] ([St_MaTacGia])
GO
ALTER TABLE [dbo].[Tbl_Sach] CHECK CONSTRAINT [FK_Tbl_Sach_Tbl_TacGia]
GO
ALTER TABLE [dbo].[Tbl_SinhVien]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_SinhVien_Tbl_Khoa] FOREIGN KEY([St_MaKhoa])
REFERENCES [dbo].[Tbl_Khoa] ([St_MaKhoa])
GO
ALTER TABLE [dbo].[Tbl_SinhVien] CHECK CONSTRAINT [FK_Tbl_SinhVien_Tbl_Khoa]
GO
ALTER TABLE [dbo].[Tbl_TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_TaiKhoan_Tbl_SinhVien] FOREIGN KEY([St_MaSinhVien])
REFERENCES [dbo].[Tbl_SinhVien] ([St_MaSinhVien])
GO
ALTER TABLE [dbo].[Tbl_TaiKhoan] CHECK CONSTRAINT [FK_Tbl_TaiKhoan_Tbl_SinhVien]
GO
ALTER TABLE [dbo].[Tbl_TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_TaiKhoan_TblQuyenHan] FOREIGN KEY([In_MaQuyenHan])
REFERENCES [dbo].[TblQuyenHan] ([In_MaQuyenHan])
GO
ALTER TABLE [dbo].[Tbl_TaiKhoan] CHECK CONSTRAINT [FK_Tbl_TaiKhoan_TblQuyenHan]
GO
USE [master]
GO
ALTER DATABASE [QL_ThuVien] SET  READ_WRITE 
GO
