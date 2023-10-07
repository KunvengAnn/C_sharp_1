SELECT * From Giang_Vien

DELETE FROM Giang_Vien WHERE Ma_GV = 'GV05' ;

select * from Giang_Vien where HoVaTenGV like '%'+'n'+'%';

INSERT INTO Giang_Vien VALUES('GV03',N'Trận', N'Thị C',N'C@gmail.com','012344');



---------------------------------
ALTER TABLE Giang_Vien
ADD Ma_GV NVARCHAR(10) NOT NULL;

ALTER TABLE Giang_Vien
ADD HoVaTenGV NVARCHAR(50) NOT NULL;

ALTER TABLE Giang_Vien
ADD email NVARCHAR(60);

ALTER TABLE Giang_Vien
ADD SDT NVARCHAR(10);
--=======================================
select * from Lop_Hoc
ALTER TABLE Lop_Hoc
ADD TenLop NVARCHAR(50) NOT NULL;

-- Drop the existing constraints if they exist
ALTER TABLE Lop_Hoc
DROP CONSTRAINT FK_Lop_Hoc_Hoc_Ky;

ALTER TABLE Phan_Cong_Giang_Day
DROP CONSTRAINT FK_Phan_Cong_Giang_Day_Bo_Mon;


ALTER TABLE Lop_Hoc
ADD Ma_MH NVARCHAR(50) NOT NULL;
ALTER TABLE Lop_Hoc
ADD Ma_HK	NVARCHAR(50) NOT NULL;
-- Add the foreign key constraint
ALTER TABLE Lop_Hoc
ADD CONSTRAINT FK_Lop_Hoc_Mon_Hoc
FOREIGN KEY (Ma_MH)
REFERENCES Mon_Hoc(Ma_MH)
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE Lop_Hoc
ADD CONSTRAINT FK_Lop_Hoc_Hoc_Ky
FOREIGN KEY (Ma_HK)
REFERENCES Hoc_Ky(Ma_HK)
ON DELETE CASCADE
ON UPDATE CASCADE;

--==================================
select * from Phan_Cong_Giang_Day
-- Add the foreign key constraint
ALTER TABLE Phan_Cong_Giang_Day
ADD CONSTRAINT FK_Phan_Cong_Giang_Day_Hoc_Ky
FOREIGN KEY (Ma_Hk)
REFERENCES Hoc_Ky(Ma_Hk)
ON DELETE CASCADE
ON UPDATE CASCADE;



--==================================
SELECT Ma_GV , HoVaTenGV From Giang_Vien


--==================================
SELECT Ma_BM,Ten_Bo_Mon  FROM Bo_Mon

--==================================
SELECT  id_PCGV FROM Phan_Cong_Giang_Day  WHERE id_PCGV = 1 ;

INSERT INTO Phan_Cong_Giang_Day VALUES (N'2',N'GV02',N'MH02',N'HK02',5);

--=========
ALTER TABLE Phan_Cong_Giang_Day
ADD id_PCGV NVARCHAR(50) NOT NULL;

ALTER TABLE Phan_Cong_Giang_Day
ADD Ma_GV NVARCHAR(50) NOT NULL;

ALTER TABLE Phan_Cong_Giang_Day
ADD Ma_MH NVARCHAR(50)NOT NULL;

ALTER TABLE Phan_Cong_Giang_Day
ADD Ma_Lop NVARCHAR(50);


ALTER TABLE Phan_Cong_Giang_Day
ADD Ma_BM NVARCHAR(50)NOT NULL;
ALTER TABLE Phan_Cong_Giang_Day
ADD SoTiet_1Tuan int NOT NULL;

--==================================
SELECT  PGV.id_PCGV,Gv.Ma_GV, GV.HoVaTenGV, MH.Ten_MH, LH.TenLop, HK.Ten_Hoc_Ky, BM.Ten_Bo_Mon, PGV.SoTiet_1Tuan, HK.Ma_HK FROM Phan_Cong_Giang_Day  PGV
INNER JOIN Mon_Hoc MH
on Mh.Ma_MH = PGV.Ma_MH
INNER JOIN Giang_Vien GV
on GV.Ma_GV = PGV.Ma_GV
INNER JOIN Bo_Mon BM
on BM.Ma_BM = Mh.Ma_BM
INNER JOIN Hoc_Ky HK
on HK.Ma_HK = PGV.Ma_HK
INNER JOIN Lop_Hoc LH
on LH.Ma_MH = MH.Ma_MH
ORDER BY id_PCGV ASC;

SELECT  GV.HoVaTenGV, MH.Ten_MH, LH.TenLop, HK.Ten_Hoc_Ky, BM.Ten_Bo_Mon, PGV.SoTiet_1Tuan
FROM Phan_Cong_Giang_Day  PGV, Mon_Hoc MH, Giang_Vien GV, Bo_Mon BM, Hoc_Ky HK, Lop_Hoc LH
WHERE MH.Ma_MH = PGV.Ma_MH
  AND GV.Ma_GV = PGV.Ma_GV
  AND BM.Ma_BM = Mh.Ma_BM
  AND HK.Ma_HK = PGV.Ma_HK
  AND LH.Ma_MH = MH.Ma_MH 
  AND PGV.id_PCGV = 10


--=================================================

SELECT DISTINCT *
FROM Giang_Vien ;



DELETE FROM Phan_Cong_Giang_Day WHERE id_PCGV = '5';

--=======================
UPDATE Phan_Cong_Giang_Day PGV
INNER JOIN Mon_Hoc MH ON MH.Ma_MH = PGV.Ma_MH
INNER JOIN Giang_Vien GV ON GV.Ma_GV = PGV.Ma_GV
INNER JOIN Bo_Mon BM ON BM.Ma_BM = MH.Ma_BM
INNER JOIN Hoc_Ky HK ON HK.Ma_HK = PGV.Ma_HK
INNER JOIN Lop_Hoc LH ON LH.Ma_MH = MH.Ma_MH
SET   
  GV.Ma_GV = 'GV02',
  GV.HoVaTenGV = NewValue3,
  MH.Ten_MH = NewValue4,
  LH.TenLop = NewValue5,
  HK.Ten_Hoc_Ky = NewValue6,
  BM.Ten_Bo_Mon = NewValue7,
  PGV.SoTiet_1Tuan = NewValue8;

  --=============================================
  --
SELECT
  GV.HoVaTenGV,
  MH.Ten_MH,
  LH.TenLop,
  HK.Ten_Hoc_Ky,
  HK.Ngay_Bat_Dau_HK,
  HK.Ngay_Ket_Thuc_HK,
  BM.Ten_Bo_Mon
FROM
  Phan_Cong_Giang_Day PGV
  INNER JOIN Mon_Hoc MH ON MH.Ma_MH = PGV.Ma_MH
  INNER JOIN Giang_Vien GV ON GV.Ma_GV = PGV.Ma_GV
  INNER JOIN Bo_Mon BM ON BM.Ma_BM = MH.Ma_BM
  INNER JOIN Hoc_Ky HK ON HK.Ma_HK = PGV.Ma_HK
  INNER JOIN Lop_Hoc LH ON LH.Ma_MH = MH.Ma_MH
WHERE
  PGV.id_PCGV = 1
GROUP BY
  GV.HoVaTenGV,
  MH.Ten_MH,
  LH.TenLop,
  HK.Ten_Hoc_Ky,
  HK.Ngay_Bat_Dau_HK,
  HK.Ngay_Ket_Thuc_HK,
  BM.Ten_Bo_Mon;


  SELECT SUM(SoTiet_1Tuan) AS Total_HoursGD1KY FROM Phan_Cong_Giang_Day
WHERE Ma_GV = 'GV02' AND Ma_HK = 'HK02';

SELECT
  GV.HoVaTenGV,
   MH.Ten_MH,
  LH.TenLop,
  HK.Ten_Hoc_Ky,
  HK.Ngay_Bat_Dau_HK,
  HK.Ngay_Ket_Thuc_HK,
  BM.Ten_Bo_Mon,
  SUM(PGV.SoTiet_1Tuan) AS Total_HoursGD1KY
FROM
  Phan_Cong_Giang_Day PGV
  INNER JOIN Mon_Hoc MH ON MH.Ma_MH = PGV.Ma_MH
  INNER JOIN Giang_Vien GV ON GV.Ma_GV = PGV.Ma_GV
  INNER JOIN Bo_Mon BM ON BM.Ma_BM = MH.Ma_BM
  INNER JOIN Hoc_Ky HK ON HK.Ma_HK = PGV.Ma_HK
  INNER JOIN Lop_Hoc LH ON LH.Ma_MH = MH.Ma_MH
WHERE
  GV.Ma_GV = 'GV02' AND HK.Ma_HK = 'HK02'
GROUP BY
  GV.HoVaTenGV,
  HK.Ten_Hoc_Ky,
   MH.Ten_MH,
  LH.TenLop,
  HK.Ngay_Bat_Dau_HK,
  HK.Ngay_Ket_Thuc_HK,
  BM.Ten_Bo_Mon;





SELECT* from Phan_Cong_Giang_Day 

INSERT INTO Phan_Cong_Giang_Day ('55', 'GV01', 'MH01', ',HK01', '8')
SELECT 'Ma_Lop', 'value2', 'value3', 'value4', 'value5'
FROM Lop_Hoc
WHERE ;

ALTER TABLE Lop_Hoc
ADD CONSTRAINT UC_MaMH_TenLop_MaHK UNIQUE (Ma_MH, TenLop, Ma_HK);

ALTER TABLE Lop_Hoc
DROP CONSTRAINT UC_MaMH_TenLop_MaHK;


SELECT PC.Ma_GV ,MH.Ten_MH, LH.TenLop, HK.Ma_HK, HK.Ten_Hoc_Ky
FROM Phan_Cong_Giang_Day PC
INNER join Mon_Hoc MH ON MH.Ma_MH = PC.Ma_MH
INNER JOIN Lop_Hoc LH ON LH.Ma_MH = MH.Ma_MH
INNER JOIN Hoc_Ky HK ON HK.Ma_HK = LH.Ma_HK 
where MH.Ten_MH = 'C#' or HK.Ten_Hoc_Ky= '2';

insert into Phan_Cong_Giang_Day PC values()  
PC.Ma_GV ,MH.Ten_MH, LH.TenLop, HK.Ma_HK, HK.Ten_Hoc_Ky
INNER join Mon_Hoc MH ON MH.Ma_MH = PC.Ma_MH
INNER JOIN Lop_Hoc LH ON LH.Ma_MH = MH.Ma_MH
INNER JOIN Hoc_Ky HK ON HK.Ma_HK = LH.Ma_HK;

--table Phan_Cong_Giang_Day
--Ma_GV
--Ma_MH
--id_PCGV
--Ma_HK
--SoTiet_1Tuan

--table Giang_Vien
--email
--HoVaTenGV
--Ma_GV
--SDT

--table Mon_Hoc
--Ma_BM
--Ten_MH
--Ma_MH

--table Hoc_Ky
--Ten_Hoc_Ky
--Ngay_Bat_Dau_HK
--Ngay_Ket_Thuc_HK
--Ma_HK

--table Lop_Hoc
--Ma_Lop
--Ma_MH
--TenLop
--Ma_HK

--table Bo_Mon
--Ten_Bo_Mon
--Ma_BM


SELECT LP.Ma_Lop, LP.TenLop, MH.Ten_MH, HK.Ten_Hoc_Ky FROM Lop_Hoc LP 
INNER join Mon_Hoc MH ON LP.Ma_MH = LP.Ma_MH
INNER JOIN Hoc_Ky HK ON HK.Ma_HK = LP.Ma_HK;

