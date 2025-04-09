-- Create database
CREATE DATABASE QuanCafe;
GO

USE QuanCafe;
GO

-- Bảng Danh mục sản phẩm
CREATE TABLE DanhMucSanPham (
    id_danh_muc INT IDENTITY PRIMARY KEY,
    ten_danh_muc NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
    mo_ta NVARCHAR(MAX)
);

-- Bảng Bàn
CREATE TABLE Ban (
    id_ban INT IDENTITY PRIMARY KEY,
    ten_ban NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa có tên',
    trang_thai NVARCHAR(100) NOT NULL DEFAULT N'Trống' -- Trống || Có người
);

-- Bảng Nhân viên
CREATE TABLE NhanVien (
    id_nhan_vien INT IDENTITY PRIMARY KEY,
    ten_nhan_vien NVARCHAR(100),
    chuc_vu NVARCHAR(50),
    so_dien_thoai VARCHAR(20),
    email NVARCHAR(100)
);

-- Bảng Khách hàng
CREATE TABLE KhachHang (
    id_khach_hang INT IDENTITY PRIMARY KEY,
    ten_khach_hang NVARCHAR(100),
    so_dien_thoai VARCHAR(20),
    email NVARCHAR(100),
    ghi_chu NVARCHAR(MAX)
);

-- Bảng Sản phẩm
CREATE TABLE SanPham (
    id_san_pham INT IDENTITY PRIMARY KEY,
    ten_san_pham NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
    gia FLOAT NOT NULL DEFAULT 0,
    id_danh_muc INT NOT NULL,
    mo_ta NVARCHAR(MAX),

    CONSTRAINT FK_SanPham_DanhMuc FOREIGN KEY (id_danh_muc) REFERENCES DanhMucSanPham(id_danh_muc)
);



-- Bảng Hóa đơn
CREATE TABLE HoaDon (
    id_hoa_don INT IDENTITY PRIMARY KEY,
    id_ban INT NOT NULL,
    id_nhan_vien INT NOT NULL,
    id_khach_hang INT,
    thoi_gian DATETIME NOT NULL DEFAULT GETDATE(),
    trang_thai INT NOT NULL DEFAULT 0, -- 1: đã thanh toán || 0: chưa thanh toán
    tong_tien DECIMAL(18,2) DEFAULT 0,

    CONSTRAINT FK_HoaDon_Ban FOREIGN KEY (id_ban) REFERENCES Ban(id_ban),
    CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY (id_nhan_vien) REFERENCES NhanVien(id_nhan_vien),
    CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY (id_khach_hang) REFERENCES KhachHang(id_khach_hang)
);

-- Bảng Chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    id_chi_tiet_hoa_don INT IDENTITY PRIMARY KEY,
    id_hoa_don INT NOT NULL,
    id_san_pham INT NOT NULL,
    so_luong INT NOT NULL DEFAULT 0,
    don_gia DECIMAL(18,2) NOT NULL DEFAULT 0,

    CONSTRAINT FK_CTHD_HoaDon FOREIGN KEY (id_hoa_don) REFERENCES HoaDon(id_hoa_don),
    CONSTRAINT FK_CTHD_SanPham FOREIGN KEY (id_san_pham) REFERENCES SanPham(id_san_pham)
);


SELECT * FROM DanhMucSanPham;
SELECT * FROM Ban;
SELECT * FROM NhanVien;
SELECT * FROM KhachHang;
SELECT * FROM SanPham;
SELECT * FROM HoaDon;
SELECT * FROM ChiTietHoaDon;