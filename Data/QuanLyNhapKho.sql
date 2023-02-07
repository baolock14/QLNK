Create Database QL_Nhap_Kho
go


Use QL_Nhap_Kho
Go


Create Table TaiKhoan
(
	UserName Nvarchar(100) Primary Key,
	Password Nvarchar(1000) NOT NULL Default 0,
)

Insert Into TaiKhoan
Values
	('Phuc', '1'),
	('Minh', '1')
Go


Create Table HangSX
(
	IDHang Int identity Primary Key,
	tenHang Varchar(100) --not null
)
Go

Insert Into HangSX
(tenHang)
Values
('Samsung'),
('Apple'),
('Xiaomi'),
('LG'),
('HTC'),
('Nokia')
Go


Create Table SanPham
(
	maSP Varchar(50) Primary Key,
	tenSP Nvarchar(100) not null Default N'Smartphone',
	tongSluong Int default 0,
	IDHang Int,
	nuocSX Nvarchar(100),
	gia Float
)
Alter Table SanPham
	Add constraint FK_HangSX Foreign Key (IDHang) References HangSX(IDHang)
ON UPDATE CASCADE
ON DELETE CASCADE
Go

Insert Into SanPham
(maSP, tenSP, tongSluong, IDHang, nuocSX, gia)
Values
('XM001', N'Xiaomi Redmi Note 7', 30 , 3, N'China', 4000000),
('XM002', N'Xiaomi Mi 10', 20 , 3, N'China', 13000000),
('IP001', N'Iphone XS Max', 25 , 2, N'USA', 19000000),
('IP002', N'Iphone 8 Plus', 30 , 2, N'USA', 9000000),
('IP003', N'Iphone 11 Pro Max', 10 , 2, N'USA', 25000000),
('SS001', N'Samsung Galaxy Note 11 Ultra', 30 , 1, N'Korea', 29000000),
('SS002', N'Samsung Galaxy A50', 5 , 1, N'Korea', 6500000),
('SS003', N'Samsung Galaxy S11', 17 , 1, N'Korea', 20000000),
('SS004', N'Samsung Galaxy J7 Prime', 10 , 1, N'Korea', 7000000),
('SS005', N'Samsung Galaxy Fold', 25 , 1, N'Korea', 50000000),
('SS006', N'Samsung Galaxy S10 Plus', 15 , 1, N'Korea', 20000000),
('HT001', N'HTC One 11', 22 , 5, N'Taiwan', 10000000),
('HT002', N'HTC U11', 22 , 5, N'Taiwan', 12000000),
('NK001', N'Nokia 7.1', 11 , 6, N'USA', 5000000),
('NK002', N'Nokia 9.1', 24 , 6, N'USA', 8000000),
('LG001', N'LG V20', 14 , 4, N'Korea', 10000000),
('LG002', N'LG V10', 12 , 4, N'Korea', 8000000)
Go


Create Table PhieuNK
(
	maPhieu Int Identity Primary Key,
	maSP Varchar(50),
	ngayNhap Date,
	soLuong Int
)
Alter Table PhieuNK
	Add Constraint FK_SanPham Foreign Key (maSP) References SanPham(maSP)
ON UPDATE CASCADE
ON DELETE CASCADE
Go

Insert Into PhieuNK
(maSP, ngayNhap, soLuong)
Values
('SS001','2020-02-05', 20),
('LG001','2020-03-15', 10),
('IP002','2020-03-25', 20)
Go


Create Proc CheckLogin
 @UserName Nvarchar(100), @Password Nvarchar(1000)
As
Begin
	Select * From TaiKhoan 
	Where UserName = @UserName and Password = @Password
End
Go


Create Proc	SanPham_SelectAllBID
 @IDHang int
As
Begin
	Select * From SanPham Where IDHang = @IDHang
End
Go


Create Proc	HangSX_SelectAll
As
Begin
	Select * From HangSX
End
Go

Create Proc USP_InsertPNK
@maSP Varchar(50), @ngayNhap Date, @soLuong Int
As
Begin

	Insert Into PhieuNK ( maSP, ngayNhap, soLuong)
	Values (@maSP, @ngayNhap, @soLuong)
End
Go

--Sửa phiếu
create proc USP_UpdatePNK
@maSP Varchar(50), @ngayNhap Date, @soLuong Int, @maPhieu int
As
Begin
	Update PhieuNK set  maSP = @maSP, ngayNhap = @ngayNhap, soLuong = @soLuong where maPhieu = @maPhieu
End
Go

--Xóa phiếu
create proc USP_DeletePNK
@maPhieu int
As
Begin
	Delete from PhieuNK where maPhieu = @maPhieu
End
Go

-- cập nhập hàng trong kho sau khi thêm hàng
create Trigger trg_CapNhapHang On PhieuNK
After Insert
As
Begin
	Update SanPham Set tongSluong = tongSluong +
		(Select soLuong From inserted Where maSP = SanPham.maSP)
	From SanPham join inserted On SanPham.maSP = inserted.maSP
End
Go

-- cập nhập hàng trong kho sau khi sửa phiếu nhập hàng
Create Trigger trg_SuaPhieuNK On PhieuNK
After update
As
Begin
	Update SanPham Set tongSluong = tongSluong - 
	(Select soLuong From deleted Where maSP = SanPham.maSP) +  
	(Select soLuong From inserted Where maSP = SanPham.maSP)
	From SanPham join deleted  On SanPham.maSP = deleted.maSP
End
Go

-- cập nhập hàng trong kho sau khi Xóa phiếu nhập hàng
alter Trigger trg_XoaPhieuNK On PhieuNK
After delete
As
Begin
	Update SanPham Set tongSluong = tongSluong - 
	(Select soLuong From deleted Where maSP = SanPham.maSP)
	From SanPham join deleted  On SanPham.maSP = deleted.maSP
End
Go

-- Select thông tin Phiếu nhập kho
Select maPhieu, sp.tenSP, pnk.maSP, ngayNhap, soLuong, soLuong * gia As thanhTien  From PhieuNK As pnk join SanPham As sp
On sp.maSP = pnk.maSP
Go

-- Tạo báo cáo nhập hàng theo ngày
Create Proc USP_ThongKeTheoNgay
(@ngayNhap Date)
As
Begin
	Select maPhieu, sp.tenSP, pnk.maSP, ngayNhap, soLuong, soLuong * gia As thanhTien From PhieuNK As pnk join SanPham As sp
	On sp.maSP = pnk.maSP 
	Where ngayNhap = @ngayNhap
End
Go