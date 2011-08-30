USE MASTER
GO

IF EXISTS( SELECT * FROM  sys.databases WHERE NAME = 'TANHOA_WATER')
   DROP DATABASE TANHOA_WATER
USE MASTER
GO
CREATE DATABASE TANHOA_WATER
GO	
USE TANHOA_WATER
GO

CREATE TABLE QUAN
(
	MAQUAN INT PRIMARY KEY NOT NULL,
	TENQUAN NVARCHAR(50)
)
GO

INSERT INTO QUAN(MAQUAN, TENQUAN) VALUES(22, N' Phú Nhuận')
INSERT INTO QUAN(MAQUAN, TENQUAN) VALUES(23, N' Tân Bình')
INSERT INTO QUAN(MAQUAN, TENQUAN) VALUES(31, N' Tân Phú')

CREATE TABLE PHUONG
(
	MAQUAN INT NOT NULL,
	MAPHUONG VARCHAR(10) NOT NULL,
	TENPHUONG NVARCHAR(50),
	CONSTRAINT PR_PHUONG PRIMARY KEY(MAQUAN, MAPHUONG),
	CONSTRAINT FR_PHUONG FOREIGN KEY (MAQUAN) REFERENCES QUAN(MAQUAN)
)
GO
INSERT INTO PHUONG VALUES(22,'10',N' 10')
INSERT INTO PHUONG VALUES(23,'01',N' 1')
INSERT INTO PHUONG VALUES(23,'02',N' 2')
INSERT INTO PHUONG VALUES(23,'03',N' 3')
INSERT INTO PHUONG VALUES(23,'04',N' 4')
INSERT INTO PHUONG VALUES(23,'05',N' 5')
INSERT INTO PHUONG VALUES(23,'06',N' 6')
INSERT INTO PHUONG VALUES(23,'07',N' 7')
INSERT INTO PHUONG VALUES(23,'08',N' 8')
INSERT INTO PHUONG VALUES(23,'09',N' 9')
INSERT INTO PHUONG VALUES(23,'10',N' 10')
INSERT INTO PHUONG VALUES(23,'11',N' 11')
INSERT INTO PHUONG VALUES(23,'12',N' 12')
INSERT INTO PHUONG VALUES(23,'13',N' 13')
INSERT INTO PHUONG VALUES(23,'14',N' 14')
INSERT INTO PHUONG VALUES(23,'15',N' 15')
INSERT INTO PHUONG VALUES(31,'01',N' Tân Sơn Nhì')
INSERT INTO PHUONG VALUES(31,'02',N' Tân Quý')
INSERT INTO PHUONG VALUES(31,'03',N' Sơn Kỳ')
INSERT INTO PHUONG VALUES(31,'04',N' Tân Thành')
INSERT INTO PHUONG VALUES(31,'05',N' Phú Thọ Hòa')
INSERT INTO PHUONG VALUES(31,'06',N' Phú Thạnh')
INSERT INTO PHUONG VALUES(31,'07',N' Phú Trung')
INSERT INTO PHUONG VALUES(31,'08',N' Hòa Thạnh')
INSERT INTO PHUONG VALUES(31,'09',N' Tân Thới Hòa')
INSERT INTO PHUONG VALUES(31,'10',N' Hiệp Tân')
INSERT INTO PHUONG VALUES(31,'11',N' Tây Thạnh')


CREATE TABLE LICHDOCSO
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	MAQUAN INT NOT NULL,
	MAPHUONG VARCHAR(10) NOT NULL,
	KY INT NOT NULL,
	NAM INT NOT NULL,
	DOT INT NOT NULL,
	NGAY DATETIME NOT NULL,
	NOTES NVARCHAR(500)
)
GO

CREATE TABLE ROLES(
	ROLEID VARCHAR(5)  PRIMARY KEY NOT NULL,
	ROLENAME NVARCHAR(50)	
)
GO

INSERT INTO ROLES VALUES('AD','Administrators')
INSERT INTO ROLES VALUES('US','Users')

CREATE TABLE PHONGBANDOI
(
	MAPHONG VARCHAR(20) PRIMARY KEY NOT NULL,
	TENPHONG NVARCHAR(250) NOT NULL,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME)
GO

INSERT INTO PHONGBANDOI VALUES('TTK',N'Tổ Thiết Kế',null, null,null, null)
INSERT INTO PHONGBANDOI VALUES('TIT',N'Tổ IT',null, null,null, null)
INSERT INTO PHONGBANDOI VALUES('KTKS',N'Tổ Kiểm Tra KS',null, null,null, null)
INSERT INTO PHONGBANDOI VALUES('VTTH',N'Phòng VTTH',null, null,null, null)

CREATE TABLE USERS
(
	USERNAME VARCHAR(20) PRIMARY KEY NOT NULL,
	PASSWORD VARCHAR(50),
	FULLNAME NVARCHAR(50),
	ROLEID VARCHAR(5),
	ENABLED BIT,
	CAP	INT,
	MAPHONG VARCHAR(20)
	CONSTRAINT FR_USERS FOREIGN KEY (ROLEID) REFERENCES ROLES(ROLEID),
	CONSTRAINT FR_PHONG FOREIGN KEY (MAPHONG) REFERENCES PHONGBANDOI(MAPHONG),
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(50),
	MODIFYDATE DATETIME
)
GO

INSERT INTO USERS VALUES('admin','y47NNdw/OT0=',N'LÊ TẤN ĐẠT','AD','True',0,'TIT', null, null,null,null)
INSERT INTO USERS VALUES('user','y47NNdw/OT0=',N'ĐỔ LƯU HUỲNH','US','True',0,'TIT', null, null,null,null)
INSERT INTO USERS VALUES('nta','y47NNdw/OT0=',N'NGUYEN VĂN A','US','True',0,'VTTH', null, null,null,null)
INSERT INTO USERS VALUES('ttb','y47NNdw/OT0=',N'TRẦN THỊ B','US','True',0,'VTTH', null, null,null,null)
INSERT INTO USERS VALUES('ltc','y47NNdw/OT0=',N'LÂM THỊ C','US','True',0,'VTTH', null, null,null,null)
INSERT INTO USERS VALUES('thanhtrung','y47NNdw/OT0=',N'Thành Trung','US','True',2,'TTK', null, null,null,null)
INSERT INTO USERS VALUES('chanhthang','y47NNdw/OT0=',N'Chánh Thắng','US','True',2,'TTK', null, null,null,null)
INSERT INTO USERS VALUES('minhhung','y47NNdw/OT0=',N'Minh Hùng','US','True',2,'TTK', null, null,null,null)





CREATE TABLE LOAI_HOSO
(
	MALOAI VARCHAR(10) PRIMARY KEY NOT NULL,
	TENLOAI NVARCHAR(250) NOT NULL,
	CREATEBY VARCHAR(20),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME
)
GO

INSERT INTO LOAI_HOSO VALUES('GM',N'Gắn Mới Đồng Hồ Nước',null, null,null, null)
INSERT INTO LOAI_HOSO VALUES('BT',N'Bồi Thường Đồng Hồ Nước',null, null,null, null)
INSERT INTO LOAI_HOSO VALUES('DD',N'Di Dời Đồng Hồ Nước',null, null,null, null)
INSERT INTO LOAI_HOSO VALUES('TK',N'Thiết Kế Lại Ống Ngánh & Bồi Thường ĐHN',null, null,null, null)
INSERT INTO LOAI_HOSO VALUES('DB',N'Di Dời & Bồi Thường ĐHN',null, null,null, null)
INSERT INTO LOAI_HOSO VALUES('DN',N'Di Dời & Nâng ĐHN',null, null,null, null)
INSERT INTO LOAI_HOSO VALUES('TO',N'Thay Ống Ngánh',null, null,null, null)
INSERT INTO LOAI_HOSO VALUES('CT',N'Công Trình',null, null,null, null)
INSERT INTO LOAI_HOSO VALUES('TL',N'Tái Lập Danh Bộ',null, null,null, null)


CREATE TABLE DOT_NHAN_DON
(
	MADOT VARCHAR(20) PRIMARY KEY NOT NULL,
	NGAYLAPDON DATETIME NOT NULL,
	LOAIDON VARCHAR(10) NOT NULL,
	CHUYENDON BIT ,
	BOPHANCHUYEN VARCHAR(20),
	NGAYCHUYEN DATETIME,
	NGUOICHUYEN VARCHAR(20),
	CREATEBY VARCHAR(20),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	CONSTRAINT FR_DON FOREIGN KEY (LOAIDON) REFERENCES LOAI_HOSO(MALOAI)
)
GO

CREATE TABLE LOAI_KHACHHANG(
	MALOAI VARCHAR(10) PRIMARY KEY NOT NULL,
	TENLOAI NVARCHAR(50) NOT NULL
)
GO

INSERT INTO LOAI_KHACHHANG VALUES('CN',N'Cá Nhân')
INSERT INTO LOAI_KHACHHANG VALUES('TT',N'Tập Thể')
INSERT INTO LOAI_KHACHHANG VALUES('CQ',N'Cơ Quan')
INSERT INTO LOAI_KHACHHANG VALUES('CT',N'Công Trình')


CREATE TABLE DON_KHACHHANG(
	ID INT IDENTITY (1,1) ,
	MADOT VARCHAR(20) NOT NULL,
	SOHOSO VARCHAR(50) NOT NULL,
	SHS VARCHAR(50) NOT NULL,
	DANHBO VARCHAR(50),
	HOPDONG VARCHAR(50),
	HOTEN NVARCHAR(50),
	DIENTHOAI NVARCHAR(20),
	SOHOBD INT,
	SOHO INT,
	SONHA VARCHAR(50),
	DUONG NVARCHAR(50),		
	PHUONG VARCHAR(10) NOT NULL, 
	QUAN INT NOT NULL,
	NGAYNHAN DATETIME,
	LOAIKH VARCHAR(10),
	LOAIHOSO VARCHAR(10),
	TAPTHE INT,
	TINHKHOAN BIT,
	LOAIMIENPHI NVARCHAR(50),
	GHICHU NVARCHAR(250),
	HOSOKHAN BIT,
	GHICHUKHAN NVARCHAR(250),
	CHUYEN_HOSO BIT DEFAULT 0,
	BOPHANCHUYEN VARCHAR(20),
	NGUOICHUYEN_HOSO VARCHAR(20),
	NGAYCHUYEN_HOSO DATETIME,	
	TRONGAICHUYEN_HOSO BIT DEFAULT 0,
	NOIDUNGTNCHUYEN NVARCHAR(50),	
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	CONSTRAINT PK_HOS PRIMARY KEY (SOHOSO),
	CONSTRAINT FR_KH_HS FOREIGN KEY (LOAIHOSO) REFERENCES LOAI_HOSO(MALOAI),
	CONSTRAINT FR_LOAIKH FOREIGN KEY (LOAIKH) REFERENCES LOAI_KHACHHANG(MALOAI),
	CONSTRAINT FR_MADOT FOREIGN KEY (MADOT) REFERENCES DOT_NHAN_DON(MADOT),
	CONSTRAINT FR_MAQUAN FOREIGN KEY (QUAN) REFERENCES QUAN(MAQUAN),
	CONSTRAINT FR_PHONGBAN FOREIGN KEY (BOPHANCHUYEN) REFERENCES PHONGBANDOI(MAPHONG)
)
GO

CREATE TABLE TOTHIETKE(
	ID INT IDENTITY (1,1)  NOT NULL,
	MADOT VARCHAR(20) NOT NULL,
	SOHOSO VARCHAR(50) PRIMARY KEY NOT NULL,
	SHS VARCHAR(50) NOT NULL,	
	NGAYNHAN DATETIME,
	SODOVIEN VARCHAR(20),
	NGAYGIAOSDV DATETIME,
	TRAHS BIT,
	NGAYTRAHS DATETIME,
	TRONGAITHIETKE BIT DEFAULT 0,
	NOIDUNGTRONGAI NVARCHAR(250),
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	CONSTRAINT FR_TOTHIETKE FOREIGN KEY (SOHOSO) REFERENCES DON_KHACHHANG(SOHOSO),
	CONSTRAINT FR_TTK_USER FOREIGN KEY (SODOVIEN) REFERENCES USERS(USERNAME)
)
GO