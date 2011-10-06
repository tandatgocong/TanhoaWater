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

CREATE TABLE TENDUONG(
	STT INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DUONG NVARCHAR(100) NOT NULL,
	MAPHUONG VARCHAR(10) NOT NULL,
	MAQUAN INT NOT NULL,
	CONSTRAINT FR_TENDUONG FOREIGN KEY (MAQUAN) REFERENCES QUAN(MAQUAN)
)
GO

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

INSERT INTO USERS VALUES('admin','y47NNdw/OT0=',N'Lê Tấn Đạt','AD','True',0,'TIT', null, null,null,null)
INSERT INTO USERS VALUES('user','y47NNdw/OT0=',N'Đổ Lưu Huỳnh','US','True',0,'TIT', null, null,null,null)
INSERT INTO USERS VALUES('nta','y47NNdw/OT0=',N'Nguyễn Thị A','US','True',0,'VTTH', null, null,null,null)
INSERT INTO USERS VALUES('ttb','y47NNdw/OT0=',N'Lâm Thị B','US','True',0,'VTTH', null, null,null,null)
INSERT INTO USERS VALUES('ltc','y47NNdw/OT0=',N'Trần Thị C','US','True',0,'VTTH', null, null,null,null)
INSERT INTO USERS VALUES('thanhtrung','y47NNdw/OT0=',N'Nguyễn Thành Trung','US','True',2,'TTK', null, null,null,null)
INSERT INTO USERS VALUES('chanhthang','y47NNdw/OT0=',N'Nguyễn Chánh Thắng','US','True',2,'TTK', null, null,null,null)
INSERT INTO USERS VALUES('minhhung','y47NNdw/OT0=',N'Nguyễn Minh Hùng','US','True',2,'TTK', null, null,null,null)

CREATE TABLE LOAI_NHANDON(
	LOAIDON VARCHAR(10) PRIMARY KEY NOT NULL,
	TENLOAI NVARCHAR(100)
)
GO

INSERT INTO LOAI_NHANDON VALUES('GM',N'Gắn Mới')
INSERT INTO LOAI_NHANDON VALUES('BT',N'Bồi Thường')
INSERT INTO LOAI_NHANDON VALUES('DD',N'Di Dời ')

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

CREATE TABLE BIENNHANDON(
	SHS VARCHAR(50) PRIMARY KEY NOT NULL,
	LOAIDON VARCHAR(10) NOT NULL,
	HOTEN NVARCHAR(250),
	DIENTHOAI VARCHAR(20),
	SONHA VARCHAR(50),
	DUONG NVARCHAR(50),		
	PHUONG VARCHAR(10) NOT NULL, 
	QUAN INT NOT NULL,
	NGAYNHAN DATETIME,
	HKTK BIT,
	CHUQUYENNHA BIT,
	GIAYPHEPXD BIT,	
	CREATEBY VARCHAR(20),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	CONSTRAINT FR_BNDON FOREIGN KEY (LOAIDON) REFERENCES LOAI_NHANDON(LOAIDON)
)
GO

INSERT INTO BIENNHANDON VALUES('1100000','GM','LE TAN DAT','01689722766','78/2','Tân Sơn Nhì','01',31,'01/01/2011','True','True','True',null,null,null,null)
INSERT INTO BIENNHANDON VALUES('11DD000','DD','LE TAN DAT','01689722766','78/2','Tân Sơn Nhì','01',31,'01/01/2011','True','True','True',null,null,null,null)
INSERT INTO BIENNHANDON VALUES('11BT000','BT','LE TAN DAT','01689722766','78/2','Tân Sơn Nhì','01',31,'01/01/2011','True','True','True',null,null,null,null)

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
	SONHA_TTK VARCHAR(50),
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
	TRONGAITHIETKE BIT DEFAULT 0,
	NOIDUNGTRONGAI NVARCHAR(250),
	HOSOCHA VARCHAR(30),
	XINPHEPDAODUONG BIT DEFAULT 1,
	TRINHKYBGD BIT DEFAULT 1,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	MODIFYLOG NTEXT,
	CONSTRAINT PK_HOS PRIMARY KEY (SHS),
	CONSTRAINT FR_KH_HS FOREIGN KEY (LOAIHOSO) REFERENCES LOAI_HOSO(MALOAI),
	CONSTRAINT FR_LOAIKH FOREIGN KEY (LOAIKH) REFERENCES LOAI_KHACHHANG(MALOAI),
	CONSTRAINT FR_MADOT FOREIGN KEY (MADOT) REFERENCES DOT_NHAN_DON(MADOT),
	CONSTRAINT FR_MAQUAN FOREIGN KEY (QUAN) REFERENCES QUAN(MAQUAN),
	CONSTRAINT FR_PHONGBAN FOREIGN KEY (BOPHANCHUYEN) REFERENCES PHONGBANDOI(MAPHONG)
)
GO


CREATE TABLE TMP_TAIXET(
	MAHOSO VARCHAR(20) PRIMARY KEY,
	CHUYEN BIT,
	NGUOICHUYEN NVARCHAR(20),
	NGAYCHUYEN DATETIME ,
	CREATEDATE DATETIME

)

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
	NGAYCHUYENHS DATETIME,
	BOPHANCHUYEN VARCHAR(20),
	TRONGAITHIETKE BIT DEFAULT 0,
	NOIDUNGTRONGAI NVARCHAR(250),
	NGAYTKGD DATETIME,
	HOANTATTK BIT,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	MODIFYLOG NTEXT,
	CONSTRAINT FR_TOTHIETKE FOREIGN KEY (SHS) REFERENCES DON_KHACHHANG(SHS),
	CONSTRAINT FR_TTK_USER FOREIGN KEY (SODOVIEN) REFERENCES USERS(USERNAME)
)
GO

CREATE TABLE LOAISD(	
	MALOAI VARCHAR(5) PRIMARY KEY NOT NULL,
	TENLOAI NVARCHAR(250)
)
GO

INSERT INTO LOAISD VALUES('CM',N'Cấp Mới')
INSERT INTO LOAISD VALUES('SDL',N'Sữ Dụng Lại')
INSERT INTO LOAISD VALUES('TH','TH')
INSERT INTO LOAISD VALUES('AP','AP')

CREATE TABLE DVT(
	ID INT IDENTITY (1,1) PRIMARY KEY,
	DONVI NVARCHAR(20)
)
GO

INSERT INTO DVT VALUES(N'm')
INSERT INTO DVT VALUES(N'm²')
INSERT INTO DVT VALUES(N'm³')
INSERT INTO DVT VALUES(N'Tấm')
INSERT INTO DVT VALUES(N'Bộ')
INSERT INTO DVT VALUES(N'Cái')
INSERT INTO DVT VALUES(N'Viên')
INSERT INTO DVT VALUES(N'Công')
INSERT INTO DVT VALUES(N'Lít')

CREATE TABLE NHOMVATTU(
	ID INT IDENTITY (1,1) PRIMARY KEY,
	TENNHOMVT NVARCHAR(20)
)
GO

INSERT INTO NHOMVATTU VALUES(N'Gang')
INSERT INTO NHOMVATTU VALUES(N'Nhựa')
INSERT INTO NHOMVATTU VALUES(N'XDCB')

CREATE TABLE DANHMUCVATTU(
	MAHIEU VARCHAR(20) PRIMARY KEY NOT NULL,
	MAHDG VARCHAR(20),
	TENVT NVARCHAR(250),
	DVT NVARCHAR(50),
	KLBTCC FLOAT,
	NHOMVT NVARCHAR(50),
	BOVT BIT DEFAULT 0,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
)
GO

CREATE TABLE DONGIAVATTU(
	STT INT,
	MAHIEUDG VARCHAR(20),
	DGVATLIEU FLOAT,
	DGNHANCONG FLOAT,
	DGMAYTHICONG FLOAT,
	NGAYHIEULUC DATETIME,
	CHON BIT,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	CONSTRAINT PK_DONGIAVATTU PRIMARY KEY (STT,MAHIEUDG),
	CONSTRAINT FR_DONGIAVATTU FOREIGN KEY (MAHIEUDG) REFERENCES DANHMUCVATTU(MAHIEU)
)
GO

CREATE TABLE DANHMUCBOVATTU(
	MABOVT VARCHAR(20),
	MAHIEU VARCHAR(20),
	TENVT NVARCHAR(250),
	DM INT,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	CONSTRAINT PK_DANHMUCBOVATTU PRIMARY KEY (MABOVT,MAHIEU),
	CONSTRAINT FR_DANHMUCBOVATTU FOREIGN KEY (MABOVT) REFERENCES DANHMUCVATTU(MAHIEU)
)
GO

CREATE TABLE DANHMUCTAILAPMATDUONG
(
	MADANHMUC VARCHAR(20) PRIMARY KEY NOT NULL,
	TENKETCAU NVARCHAR(250),
	DVT NVARCHAR(20),
	DONGIA FLOAT,
	DONGIASO INT,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME
)
GO


CREATE TABLE KICHTHUOCPHUIDAO
(
	STT INT IDENTITY(1,1) PRIMARY KEY,
	SHS VARCHAR(50) NOT NULL,
	MADANHMUC VARCHAR(20) NOT NULL,
	TENKETCAU NVARCHAR(250),
	DVT NVARCHAR(20),
	DAI FLOAT,
	RONG FLOAT,
	DOSAU FLOAT,
	SOLUONG FLOAT,
	CHUVI FLOAT,
	THETICH FLOAT,
	COTINHTL BIT,
	DONGIA FLOAT,
	GHICHU NVARCHAR(250),
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	CONSTRAINT FR_KTPD_SHS FOREIGN KEY (SHS) REFERENCES DON_KHACHHANG(SHS),
	CONSTRAINT FR_KTPD_VT FOREIGN KEY (MADANHMUC) REFERENCES DANHMUCTAILAPMATDUONG(MADANHMUC)	
)
GO

CREATE TABLE KHOILUONGXDCB
(
	STT INT IDENTITY(1,1) PRIMARY KEY,
	SHS VARCHAR(50) NOT NULL,
	CATNHUA FLOAT,
	BOCNHUA FLOAT,
	CATBTXM FLOAT,
	BOCBTXM FLOAT,
	DATCAP4 FLOAT,
	DATCAP3 FLOAT,
	CAT		FLOAT,
	DA04	FLOAT,
	XUCDAT	FLOAT,
	CPVATTU	FLOAT,
	CPNHANCONG FLOAT,
	CPMAYTHICONG FLOAT,
	CPCABA	FLOAT,
	CHIPHICHUNG FLOAT,
	CONG1 FLOAT,
	THUE55 FLOAT,
	CONG3 FLOAT,
	THUEGTGT FLOAT,
	TONGIATRI FLOAT,
	GHICHU NVARCHAR(250),
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	CONSTRAINT FR_KLXDVB_SHS FOREIGN KEY (SHS) REFERENCES DON_KHACHHANG(SHS)
)
GO


CREATE TABLE DANHSACHCONGTACBANGIA
(
	STT INT IDENTITY (1,1) PRIMARY KEY,
	SHS VARCHAR(50),
	MAHIEU VARCHAR(20),
	MAHDG VARCHAR(20),
	TENVT NVARCHAR(250), 
	DVT NVARCHAR(20),
	NHOM NVARCHAR(20),
	LOAISN VARCHAR(20),
	KHOILUONG FLOAT,
	DONGIAVL FLOAT,
	DONGIANC FLOAT,
	DONGIAXM FLOAT,
	GHICHU NVARCHAR(250),
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	CONSTRAINT FR_CTBG_SHS FOREIGN KEY (SHS) REFERENCES DON_KHACHHANG(SHS),
	CONSTRAINT FR_CTBG_VT FOREIGN KEY (MAHIEU) REFERENCES DANHMUCVATTU(MAHIEU)	
)
GO