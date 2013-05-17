
DROP VIEW W_KH_BCKINHPHI
GO
CREATE VIEW  W_KH_BCKINHPHI
AS
	SELECT hskh.MADOTTC,COUNT(hskh.SHS) as 'TLK', dvtc.TENCONGTY, SUM(CPVATTU) as 'CPVATTU', SUM(CPNHANCONG) as 'CPNHANCONG', SUM(CPMAYTHICONG) as 'CPMAYTHICONG',SUM(CHIPHITRUCTIEP) as 'CHIPHITRUCTIEP' ,SUM(CHIPHICHUNG) as 'CHIPHICHUNG' ,SUM(CHIPHICHUNG) as 'TAILAPMATDUONG' ,SUM(TONGIATRI) as 'TONGIATRI' 
	FROM KH_HOSOKHACHHANG hskh,KH_DOTTHICONG dotc,KH_DONVITHICONG dvtc
	WHERE dotc.MADOTTC=hskh.MADOTTC AND dotc.DONVITHICONG= dvtc.ID
	GROUP BY hskh.MADOTTC,dvtc.TENCONGTY
GO


DROP VIEW W_KH_BCTONGKET
go

SELECT * FROM W_KH_BCTONGKET

CREATE VIEW W_KH_BCTONGKET
AS
	SELECT hskh.*,p.TENPHUONG,q.TENQUAN
	FROM (SELECT kh.*,KH_DOTTHICONG.NGAYCHUYENTC AS 'NGAYCHUYENDVTC',KH_DOTTHICONG.DONVITHICONG
		 FROM (SELECT DON_KHACHHANG.SHS,DON_KHACHHANG.MADOT,DON_KHACHHANG.LOAIHOSO,DON_KHACHHANG.NGAYNHAN,REPLACE(DON_KHACHHANG.HOTEN,N'(ĐD '+CONVERT(VARCHAR(10),DON_KHACHHANG.SOHO)+N' Hộ)',' ') AS 'HOTEN',
					DON_KHACHHANG.SONHA,DON_KHACHHANG.DUONG, DON_KHACHHANG.PHUONG,DON_KHACHHANG.QUAN , DON_KHACHHANG.TRONGAITHIETKE,DON_KHACHHANG.NOIDUNGTRONGAI,DON_KHACHHANG.NGAYDONGTIEN, 
					'' as 'HOANTATTK',KH_HOSOKHACHHANG.MADOTTC,'' as 'DONVITC' ,  KH_HOSOKHACHHANG.NGAYHOANCONG as 'HOANCONG',KH_HOSOKHACHHANG.HOANCONG as 'QUYETTOAN',
					KH_HOSOKHACHHANG.CPVATTU,KH_HOSOKHACHHANG.CPNHANCONG,KH_HOSOKHACHHANG.CPMAYTHICONG, KH_HOSOKHACHHANG.CPCABA,
					KH_HOSOKHACHHANG.CHIPHITRUCTIEP,KH_HOSOKHACHHANG.CHIPHICHUNG,KH_HOSOKHACHHANG.TAILAPMATDUONG,
					KH_HOSOKHACHHANG.TLMDTRUOCTHUE,KH_HOSOKHACHHANG.CPGAN,KH_HOSOKHACHHANG.CPNHUA,KH_HOSOKHACHHANG.THUEGTGT,
					KH_HOSOKHACHHANG.TONGIATRI,KH_HOSOKHACHHANG.NGAYCHUYENHC,KH_HOSOKHACHHANG.NGAYTHICONG,KH_HOSOKHACHHANG.CREATEDATE
				FROM  DON_KHACHHANG
				LEFT JOIN KH_HOSOKHACHHANG
				ON DON_KHACHHANG.SHS = KH_HOSOKHACHHANG.SHS  ) as kh
			  LEFT JOIN KH_DOTTHICONG
			  ON kh.MADOTTC=KH_DOTTHICONG.MADOTTC) as hskh, PHUONG p, QUAN q
	WHERE  hskh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND hskh.PHUONG=p.MAPHUONG
GO

DROP VIEW W_KH_BCTONGCONG
GO

CREATE VIEW W_KH_BCTONGCONG
AS
	SELECT COUNT(KHVT.KH_SHS) as 'HOSO',
		   COUNT(KHVT.TTK_SHS) as 'GIAOKT',
		   COUNT(KHVT.HOANTATTK) as 'HOANTATTK',  
		   COUNT(KHVT.TRONGAITHIETKE) as 'TRONGAITHIETKE',
		   COUNT(KHVT.TTK_SHS) - (COUNT(KHVT.HOANTATTK)+COUNT(KHVT.TRONGAITHIETKE)) as 'TONTK',
		   COUNT(KHVT.NGAYDONGTIEN) as 'DONGTIEN',
		   COUNT(KHVT.HOANTATTK) - COUNT(KHVT.NGAYDONGTIEN) as 'MIENPHI',
		   COUNT(KH_HOSOKHACHHANG.MADOTTC) as 'CHUYENTC',
		   COUNT(KH_HOSOKHACHHANG.SHS)-COUNT(KH_HOSOKHACHHANG.MADOTTC) as 'TONTC',
		   COUNT(KH_HOSOKHACHHANG.HOANCONG) as 'HOANCONG'
	FROM (SELECT DON_KHACHHANG.LOAIHOSO,DON_KHACHHANG.NGAYNHAN,DON_KHACHHANG.PHUONG,DON_KHACHHANG.QUAN, DON_KHACHHANG.SHS as 'KH_SHS',TOTHIETKE.SHS as'TTK_SHS' ,TOTHIETKE.HOANTATTK,TOTHIETKE.TRONGAITHIETKE,DON_KHACHHANG.NGAYDONGTIEN		
		 FROM  DON_KHACHHANG
		 LEFT JOIN TOTHIETKE
		 ON DON_KHACHHANG.SHS = TOTHIETKE.SHS ) as KHVT
	LEFT JOIN KH_HOSOKHACHHANG
	ON KHVT.KH_SHS=KH_HOSOKHACHHANG.SHS
	WHERE KHVT.LOAIHOSO='GM'
GO



DROP VIEW W_BAOTONGHOP
GO


SELECT MADOT, SOHOSO, SHS, DANHBO, HOPDONG, HOTEN, DIENTHOAI, SOHOBD, SOHO, SONHA, DUONG, PHUONG, p.TENPHUONG, QUAN, q.TENQUAN, NGAYNHAN,
		 LOAIKH, LOAIHOSO, TAPTHE, TINHKHOAN, LOAIMIENPHI, GHICHU, HOSOKHAN, GHICHUKHAN, CHUYEN_HOSO,
		 BOPHANCHUYEN, NGUOICHUYEN_HOSO, NGAYCHUYEN_HOSO, TRONGAICHUYEN_HOSO, NOIDUNGTNCHUYEN, TRONGAITHIETKE AS 'TN_DONKH',
		 NOIDUNGTRONGAI AS 'TN_NOIDUNG' , HOSOCHA, XINPHEPDAODUONG, TRINHKYBGD, NGAYDONGTIEN, SOHOADON, SOTIEN
FROM DON_KHACHHANG dokh, PHUONG p, QUAN q
WHERE  dokh.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN AND dokh.PHUONG=p.MAPHUONG