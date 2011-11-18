USE MASTER
GO
/*
IF EXISTS( SELECT * FROM  sys.databases WHERE NAME = 'TANHOA_WATER')
   DROP DATABASE TANHOA_WATER
USE MASTER
GO*/
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
	SONHA VARCHAR(250),
	DUONG NVARCHAR(250),		
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
	SONHA VARCHAR(250),
	SONHA_TTK VARCHAR(250),
	DUONG NVARCHAR(250),		
	PHUONG VARCHAR(10) NOT NULL, 
	QUAN INT NOT NULL,
	NGAYNHAN DATETIME,
	LOAIKH VARCHAR(100),
	LOAIHOSO VARCHAR(100),
	TAPTHE BIT,
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
	NGAYDONGTIEN DATETIME,
	SOHOADON VARCHAR(MAX),
	SOTIEN FLOAT,
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
	NOIDUNGTRONGAI NVARCHAR(MAX),
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
INSERT INTO LOAISD VALUES('CMTH',N'Cấp Mới Thu Hồi')
INSERT INTO LOAISD VALUES('HHTH',N'Hiện Hữu Thu Hồi')
INSERT INTO LOAISD VALUES('AP',N'Thử Áp')

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
	TENVT NVARCHAR(MAX),
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
	TENKETCAU NVARCHAR(MAX),
	DVT NVARCHAR(20),
	DONGIA FLOAT,
	DONGIASO INT,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME
)
GO

CREATE TABLE DONGIATAILAPMATDUONG(
	STT INT,
	MADANHMUC VARCHAR(20),
	DONGIA FLOAT,
	DGVATLIEU FLOAT,
	DGNHANCONG FLOAT,
	DGMAYTHICONG FLOAT,
	NGAYHIEULUC DATETIME,
	CHON BIT,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	CONSTRAINT PK_DONGIATLMD PRIMARY KEY (STT,MADANHMUC),
	CONSTRAINT FR_DONGIATLMD  FOREIGN KEY (MADANHMUC) REFERENCES DANHMUCTAILAPMATDUONG(MADANHMUC)
)
GO


CREATE TABLE BG_KICHTHUOCPHUIDAO
(
	STT INT IDENTITY(1,1) PRIMARY KEY,
	SHS VARCHAR(50) NOT NULL,
	MADANHMUC VARCHAR(20) NOT NULL,
	TENKETCAU NVARCHAR(MAX),
	DVT NVARCHAR(20),
	DAI FLOAT,
	RONG FLOAT,
	DOSAU FLOAT,
	SOLUONG FLOAT,
	KHOILUONG FLOAT,
	CHUVI FLOAT,
	THETICH FLOAT,
	COTINHTL BIT,
	GHICHU NVARCHAR(250),
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	CONSTRAINT FR_KTPD_SHS FOREIGN KEY (SHS) REFERENCES DON_KHACHHANG(SHS),
	CONSTRAINT FR_KTPD_VT FOREIGN KEY (MADANHMUC) REFERENCES DANHMUCTAILAPMATDUONG(MADANHMUC)	
)
GO

CREATE TABLE BG_KHOILUONGXDCB
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
	CHIPHITRUCTIEP FLOAT,
	CHIPHICHUNG FLOAT,	
	TAILAPMATDUONG FLOAT,
	TLMDTRUOCTHUE FLOAT,
	CPGAN FLOAT DEFAULT 0,
	CPNHUA FLOAT DEFAULT 0,
	CONG1 FLOAT,
	THUE55 FLOAT,
	CONG3 FLOAT,
	THUEGTGT FLOAT,
	TONGIATRI FLOAT,
	GHICHU NVARCHAR(250),
	PHICABA BIT DEFAULT 0,
	PHIGIAMSAT BIT DEFAULT 1,
	PHIQUANLY BIT DEFAULT 1,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	BGLOG NVARCHAR(MAX),
	CONSTRAINT FR_KLXDVB_SHS FOREIGN KEY (SHS) REFERENCES DON_KHACHHANG(SHS)
)
GO

CREATE TABLE BG_CONGTACBANGIA
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
	DONGIAMTC FLOAT,
	GHICHU NVARCHAR(250),
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	CONSTRAINT FR_CTBG_SHS FOREIGN KEY (SHS) REFERENCES DON_KHACHHANG(SHS),
	CONSTRAINT FR_CTBG_VT FOREIGN KEY (MAHIEU) REFERENCES DANHMUCVATTU(MAHIEU)	
)
GO

CREATE TABLE BG_HESOBANGGIA
(
	STT INT IDENTITY(1,1) PRIMARY KEY,
	NC FLOAT,
	MTC FLOAT,
	CABA FLOAT,
	PHIKHAC FLOAT,
	PHICHUNG FLOAT,
	TRUOCTHUE FLOAT,
	PHIKSTK FLOAT,
	HSKSTK FLOAT,
	PHIGIAMSAT FLOAT,
	CHIPHIQL FLOAT,
	VAT FLOAT,
	HSSDL FLOAT,
	HSTH FLOAT,
	CHON BIT,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME
)
GO

INSERT INTO BG_HESOBANGGIA(NC,MTC,CABA,PHIKHAC,PHICHUNG,TRUOCTHUE,PHIKSTK,HSKSTK,PHIGIAMSAT,CHIPHIQL,VAT,HSSDL,HSTH,CHON,CREATEBY,CREATEDATE,MODIFYBY,MODIFYDATE) 
VALUES(2.8,1.34,30,2,5,5.5,2.07,1.3,1.964,2.125,10,1.6,0.6,'True', null,null,null,null)

CREATE TABLE BG_HESOPHUIDAO
(
	STT INT IDENTITY(1,1) PRIMARY KEY,
	KL_NHUA12 FLOAT,
	DATC4_NHUA12 FLOAT,
	KL_NHUA10 FLOAT,
	DATC4_NHUA10 FLOAT,
	KL_BT10 FLOAT,
	DATC4_BT10 FLOAT,
	DATC4_DAXANH FLOAT,
	DATC4_DADO FLOAT,
	KLDA04_TNHA FLOAT,
	CHISODD FLOAT,
	KL_CONLAI FLOAT,
	DATC4_CONLAI FLOAT,	
	CHON BIT,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME
)
GO

INSERT INTO BG_HESOPHUIDAO(KL_NHUA12,DATC4_NHUA12,KL_NHUA10,DATC4_NHUA10,KL_BT10,DATC4_BT10,DATC4_DAXANH,DATC4_DADO,KLDA04_TNHA,CHISODD,KL_CONLAI,DATC4_CONLAI,CHON,CREATEBY,CREATEDATE,MODIFYBY,MODIFYDATE) 
VALUES( 0.12,0.4,0.1,0.3,0.1,0.3,0.25,0.25,0.1,0.18,0.05,0.1,'True', null,null,null,null)


CREATE TABLE BG_REPORT(
	STT INT IDENTITY(1,1) PRIMARY KEY,
	LINE1 NVARCHAR(MAX),
	LINE2 NVARCHAR(MAX),	
	LINE3 NVARCHAR(MAX),
	LINE4 NVARCHAR(MAX),
	LINE5 NVARCHAR(MAX),
	LINE6 NVARCHAR(MAX),	
	DUYET NVARCHAR(MAX),
	NGUOIDUYET NVARCHAR(MAX),
	THANHLAP NVARCHAR(MAX),
	NGUOILAP NVARCHAR(MAX)
)
GO

INSERT INTO BG_REPORT(LINE1,LINE2,LINE3,LINE4,LINE5,LINE6,DUYET,NGUOIDUYET,THANHLAP,NGUOILAP)
VALUES(N'(Căn cứ theo Nghị định 117/NĐ-CP ngày 11-07-2007 của Chính Phủ về sản xuất, cung cấp và tiêu thụ nước sạch) ',
N'(Căn cứ theo tờ trình 061/TTr-TH-KTCN ngày 09/03/2011 V/v điều chỉnh Nhân công và Ca máy theo công văn số 10505/SXD-QLKTXD ngày 28/12/2010 v/v hướng dẫn điều chỉnh dự toán xây dựng công trình trên địa bàn TP.HCM theo văn bản số 6465/UBND-ĐTMT ngày 14/12/2010 của Ủy ban nhân dân thành phố)',
N'(Căn cứ theo tờ trình 119/TTr-TH-KTCN ngày 19/04/2011 V/v điều chỉnh chi phí trực tiếp, chi phí chung, chi phí quản lý của Bộ Xây Dựng)',
N'(ÁP DỤNG THEO ĐƠN GIÁ XDCB KHU VỰC TPHCM THÁNG 10/2010 CỦA SXD VÀ TỜ TRÌNH SỐ 101/TTr-KT NGÀY 22/08/2008)',
N'(ÁP DỤNG THEO CÔNG VĂN SỐ 1150/QLCTGTSG NGÀY 24/12/2008 V/V ÁP DỤNG ĐƠN GIÁ TÁI LẬP MẶT ĐƯỜNG VÀ ĐƠN GIÁ TÁI LẬP VỈA HÈ THEO VĂN BẢN SỐ 808/SGTVT-GT NGÀY 16/10/2008 VÀ VĂN BẢN SỐ 1256/SGTVT-GT  NGÀY 12/12/2008 CỦA SỞ GIAO THÔNG VẬN TẢI)',
N'',N'PHÓ GIÁM ĐỐC KỸ THUẬT',N'PHAN MẠNH HIỂN',N'PHÒNG KỸ THUẬT CÔNG NGHỆ',N'LÊ VĂN NGHIÊM')

CREATE TABLE KH_BAOCAOPHUIDAO
(
	STT INT IDENTITY(1,1) PRIMARY KEY,
	SHS VARCHAR(50) NOT NULL,
	MADANHMUC VARCHAR(20) NOT NULL,
	TENKETCAU NVARCHAR(MAX),
	KICHTHUOC NVARCHAR(MAX)
)
GO

CREATE TABLE KH_NOICAPPHEP(
	MACAPPHEP VARCHAR(30) PRIMARY KEY NOT NULL,
	NOICAPPHEP NVARCHAR(250),
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
)
GO
INSERT INTO KH_NOICAPPHEP(MACAPPHEP,NOICAPPHEP) VALUES('Q10',N'Quận 10')
INSERT INTO KH_NOICAPPHEP(MACAPPHEP,NOICAPPHEP) VALUES('Q11',N'Quận 11')
INSERT INTO KH_NOICAPPHEP(MACAPPHEP,NOICAPPHEP) VALUES('QTB',N'Quận Tân Bình')
INSERT INTO KH_NOICAPPHEP(MACAPPHEP,NOICAPPHEP) VALUES('QTP',N'Quận Tân Phú')
INSERT INTO KH_NOICAPPHEP(MACAPPHEP,NOICAPPHEP) VALUES('KHU',N'Khu')

CREATE TABLE KH_XINPHEPDAODUONG(
	MADOT VARCHAR(250) PRIMARY KEY NOT NULL,
	NOICAPPHEP VARCHAR(30),
	NGAYLAP DATETIME,
	MAQUANLY VARCHAR(250),
	COPHEP BIT DEFAULT 0,
	NGAYCOPHEP DATETIME,
	GHICHU NVARCHAR(500),
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	CONSTRAINT FR_XPDD FOREIGN KEY (NOICAPPHEP) REFERENCES KH_NOICAPPHEP(MACAPPHEP)
)
GO

CREATE TABLE KH_BC_XINPHEPDD(
	STT INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	CANCU_MP NVARCHAR(MAX),
	CANCUCOPHEP1 NVARCHAR(MAX),
	CANCUCOPHEP2 NVARCHAR(MAX),
	CANCUFOOTER1 NVARCHAR(MAX),
	CANCUFOOTER2 NVARCHAR(MAX),
	CANCUFOOTER3 NVARCHAR(MAX),
	CHUCVU NVARCHAR(MAX),
	NGUOIDUYET NVARCHAR(MAX)	
)
GO

INSERT INTO KH_BC_XINPHEPDD(CANCU_MP,CANCUCOPHEP1,CANCUCOPHEP2,CANCUFOOTER1,CANCUFOOTER2,CANCUFOOTER3)
VALUES(N'Kế hoạch đào đường để lắp đặt, di dời, cắt hủy, thay ống đồng hồ nước, cơi van...(thuộc đối tượng miễn GP đào đường) địa bàn',N'Căn cứ quy định về việc đào đường và tái lập mặt đường khi xây  lắp các công trình hạ tần kỹ thuật trên đia bàn Thành Phố Hồ Chí Minh ban hành theo quyết định số 145/2002/QĐ-UB ngày 09/12/2002 của Ủy Ban Nhân Dân Thành Phố Hồ Chí Minh.',N'Căn cứ  văn bản số 1670 GTGT ngày 24/12/2002 về việc hướng dẫn thủ tục cấp phép đào đường trên địa bàn thành phố.',N'Công ty TNHH MTV Cấp Nước Tân Hòa cam kết thi công, tái lập mặt đường đúng theo kết cấu trong hồ sơ thiết kế tái lập hoặc theo kết cấu định hình đã được ban hành theo quyết định số 145/2003/QĐ-UB ngày 09/12/2002 ủa Ủy Ban Nhân Dân Thành Phố Hồ ',N'GIÁM ĐỐC',N'NGUYỄN VĂN PHÚ') 

CREATE TABLE KH_DOTTHICONG
(
	MADOTTC VARCHAR(250) PRIMARY KEY NOT NULL,
	NGAYLAP DATETIME,
	SOLUONGTLK INT,
	DONVITHICONG INT,
	DONVITAILAP INT,
	NGAYCHUYENDVTC DATETIME,
	CHUYENBUHANMUC DATETIME,
	BANGKE NVARCHAR(MAX),
	LOAIBANGKE NVARCHAR(MAX),
	NGAYCHUYENHC DATETIME,
	CHUYENHOANCONG BIT,
	NGAYHC DATETIME,
	GHICHUHC NVARCHAR(MAX),
	SOLUONG_HCTLK INT,
	CONLAI_TLK INT,
	QUYETTOAN BIT,
	NGAYCHUYENKT DATETIME,
	NGAYTHANHTOAN DATETIME,
	TRONGAITC NVARCHAR(MAX),
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	CONSTRAINT FR_DVTC FOREIGN KEY (DONVITHICONG) REFERENCES KH_DONVITHICONG(ID),
	CONSTRAINT FR_DVTL FOREIGN KEY (DONVITAILAP) REFERENCES KH_DONVITAILAP(ID)
)
GO

CREATE TABLE KH_DONVITHICONG(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TENCONGTY NVARCHAR(MAX),
	SOHOPDONG NVARCHAR(MAX),
	NGAYKYHD DATETIME,
	XOA BIT DEFAULT 0,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME
)
GO

INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'Thi Công Tu Bổ','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty An Phát','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty Bình Tân','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty Đại Đức','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty Đại Tín','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'Vạn Thuận Phát','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'QLCTGTSH','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty XDGTSG','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'Ban QLDA','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'Ban Chống TTN','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'Cơ Khí Công Trình','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty Cổ Phần Đại Lộc','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty TNHH Nhật Tân','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty TNHH Tân Như','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty TNHH Đức Nghĩa','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty CP Khoan Và XLCTN','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty QLCT Cầu Phà','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITHICONG(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'Tổ Thi Công Độc Lập','0001/HĐ-TH-KHVT','12/30/2010')


CREATE TABLE KH_DONVITAILAP(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TENCONGTY NVARCHAR(MAX),
	SOHOPDONG NVARCHAR(MAX),
	NGAYKYHD DATETIME,
	XOA BIT DEFAULT 0,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME
)
GO

INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'Cty DVGTĐT TB','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'QLCTGTSG','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'Cty XDGTSG','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty Bình Tân','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty Đại Tín','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'Vạn Thuận Phát','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty CP CKCT','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty XDGTSG','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty Cổ Phần Đại Lộc','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty TNHH Nhật Tân','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty TNHH Tân Như','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty TNHH Đức Nghĩa','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty QLCT Cầu Phà','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'C.Ty CP Khoan Và XLCTN','0001/HĐ-TH-KHVT','12/30/2010')
INSERT INTO KH_DONVITAILAP(TENCONGTY,SOHOPDONG,NGAYKYHD) VALUES(N'Tổ Thi Công Độc Lập','0001/HĐ-TH-KHVT','12/30/2010')

CREATE TABLE KH_LOAIBANGKE
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MABANGKE VARCHAR(10),
	TENBANGKE NVARCHAR(MAX) NOT NULL,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME
)
GO

INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('GM',N'Gắn Mới')
INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('GM117',N'Gắn Mới(NĐ117)')
INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('DOI',N'Dời')
INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('BT',N'Bồi Thường')
INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('DBT',N'Dời-BT')
INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('DMP',N'Dời MP')
INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('OC',N'Ống Cái')
INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('XLGC',N'XL Giao Cắt')
INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('CTQ',N'Cải Tạo Ống')
INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('GQSC',N'GQ Sự Cố')
INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('PTM',N'PT Mạng')
INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('CT',N'Công Trình')
INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('THTCH',N'Thu Hồi TCH')
INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('LMTCH',N'Lập Mới TCH')
INSERT INTO KH_LOAIBANGKE(MABANGKE,TENBANGKE) VALUES('DTCH',N'Di Dời TCH')

CREATE TABLE KH_DONVIGIAMSAT(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TENDONVI NVARCHAR(MAX),
)
GO

INSERT INTO KH_DONVIGIAMSAT(TENDONVI) VALUES(N'Phòng GNKDT Cty TNHH MTV Cấp Nước Tân Hòa')

CREATE TABLE KH_TC_BAOCAO
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	CVDUYET NVARCHAR(MAX),
	NGUOIDUYET NVARCHAR(MAX),
	CVKEHOACH NVARCHAR(MAX),
	NGUOITL NVARCHAR(MAX)
)
GO

INSERT INTO KH_TC_BAOCAO(CVDUYET,NGUOIDUYET,CVKEHOACH,NGUOITL) VALUES(N'GIÁM ĐỐC',N'NGUYỄN VĂN PHÚ',N'PHÓ TRƯỞNG PHÒNG KH-VT-TH',N'TRƯƠNG THỊ HỒNG MAI')

CREATE TABLE KH_HOSOKHACHHANG(
	ID INT IDENTITY (1,1)  NOT NULL,
	MADOT VARCHAR(20),
	SHS VARCHAR(50) PRIMARY KEY,	
	NGAYNHAN DATETIME,
	MADOTDD VARCHAR(250),
	CHOPHEP BIT DEFAULT 0,
	NGAYCOPHEP DATETIME,
	MADOTTC VARCHAR(250),	
	TRONGAI BIT DEFAULT 0,
	NOIDUNGTN NVARCHAR(MAX),
	GHICHU NVARCHAR(MAX),
	COTLK INT,
	CPVATTU	FLOAT,
	CPNHANCONG FLOAT,
	CPMAYTHICONG FLOAT,
	CPCABA	FLOAT,
	CHIPHITRUCTIEP FLOAT,
	CHIPHICHUNG FLOAT,	
	TAILAPMATDUONG FLOAT,
	TLMDTRUOCTHUE FLOAT,
	CPGAN FLOAT DEFAULT 0,
	CPNHUA FLOAT DEFAULT 0,
	CONG1 FLOAT,
	THUE55 FLOAT,
	CONG3 FLOAT,
	THUEGTGT FLOAT,
	TONGIATRI FLOAT,
	CHUYENHOANCONG BIT,
	NGAYCHUYENHC DATETIME,
	HOANCONG BIT,
	NGAYHOANCONG DATETIME,
	NGAYTHICONG DATETIME,
	CHISO INT DEFAULT 0,
	SOTHANTLK VARCHAR(30),	
	DHN_HOTEN NVARCHAR(MAX),
	DHN_SONHA NVARCHAR(MAX),
	DHN_DIACHI NVARCHAR(MAX),
	DHN_SOHOPDONG VARCHAR(MAX),
	DHN_GIABIEU INT DEFAULT 11,
	DHN_DMGOC INT DEFAULT 0,
	DHN_DMCAPBU INT DEFAULT 0,
	DHN_SODANHBO VARCHAR(50),
	DHN_MADMA VARCHAR(MAX),
	DHN_HIEULUC VARCHAR(MAX),
	DHN_MAQUANPHUONG VARCHAR(4),
	DHN_HSCONGTY VARCHAR(MAX),
	DHN_MASOTHUE VARCHAR(MAX),
	DHN_SOHO INT DEFAULT 0,
	DHN_SONHANKHAU INT DEFAULT 0,
	DHN_SOHOKHAU VARCHAR(MAX),
	DHN_SODOT VARCHAR(50),
	DHN_CHODB BIT DEFAULT 0,
	DHN_NGAYCHOSODB DATETIME,
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME,
	MODIFYLOG NTEXT,
	CONSTRAINT FR_KH_KHACHHANG FOREIGN KEY (SHS) REFERENCES DON_KHACHHANG(SHS),
	CONSTRAINT FR_DAODUONG FOREIGN KEY (MADOTDD) REFERENCES KH_XINPHEPDAODUONG(MADOT),
	CONSTRAINT FR_THICONG FOREIGN KEY (MADOTTC) REFERENCES KH_DOTTHICONG(MADOTTC)
)
GO

CREATE TABLE DB_HOKHAU
(
	STT INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	SODANHBO VARCHAR(50),
	SOHOKHAU VARCHAR(50),
	GHICHU NVARCHAR(MAX),
	CREATEBY VARCHAR(50),
	CREATEDATE DATETIME,
	MODIFYBY VARCHAR(20),
	MODIFYDATE DATETIME
)
GO

CREATE TABLE DHN_BAOCAO
(
	STT INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	KTGIAMDOC_CV NVARCHAR(MAX),
	TENKT NVARCHAR(MAX),
	THANHLAP NVARCHAR(MAX),
	TENTHL NVARCHAR(MAX)
)
GO

INSERT INTO DHN_BAOCAO(KTGIAMDOC_CV,TENKT,THANHLAP,TENTHL) VALUES(N'Phó Giám Đốc Kinh Doanh',N'Lê Văn Sơn',N'Đội QUẢN LÝ ĐỒNG HỒ NƯỚC',N'Trần Công Lễ')