CREATE DATABASE QLTTNN

Use QLTTNN

drop database QLTTNN

Create table ThiSinh (
	Id int IDENTITY(1,1) primary key,
	CMND nchar(12) not null,
	HoTen nvarchar (40) not null,
	GioiTinh nvarchar(5) not null,
	NgaySinh date not null,
	NoiSinh nvarchar (10) not null,
	NgayCap date not null,
	NoiCap nvarchar (10) not null,
	SDT nchar (12) not null,
	Email nchar (40) not null
);

Create table KhoaThi (
	Id int IDENTITY(1,1) primary key,
	TenKhoaThi nvarchar(40) not null,
	NgayThi date not null
);

Create table PhongThi (
	Id int IDENTITY(1,1) primary key,
	TenPhongThi nvarchar (40) not null,
	TrinhDo varchar(2),
	CaThi nvarchar(8),
	ID_KhoaThi int not null
);


Create table PhieuDangKy(
	Id_ThiSinh int not null,
	Id_KhoaThi int not null,
	TrinhDo varchar(2) not null,
	NgayDangKy date not null
	CONSTRAINT PK_PhieuDangKy PRIMARY KEY (Id_ThiSinh, Id_KhoaThi)
);

Create table DanhSachPhongThi(
	Id int IDENTITY(1,1) primary key,
	Id_ThiSinh int not null,
	Id_PhongThi int not null,
	SBD varchar(8),
	DiemNghe float,
	DiemNoi float,
	DiemDoc float,
	DiemViet float
);

ALTER TABLE PhongThi
ADD FOREIGN KEY (Id_KhoaThi) REFERENCES KhoaThi(Id) ON DELETE CASCADE;
ALTER TABLE PhieuDangKy
ADD FOREIGN KEY (Id_ThiSinh) REFERENCES ThiSinh(Id) ON DELETE CASCADE;
ALTER TABLE PhieuDangKy
ADD FOREIGN KEY (Id_KhoaThi) REFERENCES KhoaThi(Id) ON DELETE CASCADE;
ALTER TABLE DanhSachPhongThi
ADD FOREIGN KEY (Id_PhongThi) REFERENCES PhongThi(Id) ON DELETE CASCADE;
ALTER TABLE DanhSachPhongThi
ADD FOREIGN KEY (Id_ThiSinh) REFERENCES ThiSinh(Id) ON DELETE CASCADE;