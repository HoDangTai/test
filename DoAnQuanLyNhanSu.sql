CREATE DATABASE QuanlynhansuChampaIsland_63135354;
GO
USE QuanlynhansuChampaIsland_63135354;
GO

CREATE TABLE QUANTRI
(
    EMAIL VARCHAR(50) PRIMARY KEY,
    ADMIN BINARY(2),
    HoTen VARCHAR(50),
    PASSWORD VARCHAR(50)
);
GO
CREATE TABLE CHUCVU
(
    MACV VARCHAR(2) PRIMARY KEY,
    TENCV NVARCHAR(50)
);



GO
CREATE TABLE NHANVIEN
(
    MANV VARCHAR(6) PRIMARY KEY,
    MACV VARCHAR(2)
        FOREIGN KEY REFERENCES CHUCVU (MACV) ON DELETE CASCADE ON UPDATE CASCADE,
    HONV NVARCHAR(20),
    TENLOT NVARCHAR(20),
    TENNV NVARCHAR(20),
    NGAYSINH DATE,
    DIACHI NVARCHAR(50),
    GIOITINH BIT
        DEFAULT (1),
    SDT VARCHAR(10),
    EMAIL VARCHAR(50),
    NGAYVAOLAM DATE,
    CCCD VARCHAR(13),
    ANHNV NVARCHAR(50)
);
GO
CREATE TABLE LUONG
(
    MALUONG VARCHAR(7) PRIMARY KEY,
    MANV VARCHAR(6)
        FOREIGN KEY REFERENCES NHANVIEN (MANV) ON DELETE CASCADE ON UPDATE CASCADE,
    THANG VARCHAR(2),
    NAM VARCHAR(4),
    LUONGCOBAN DECIMAL(10, 2) NOT NULL,
    PHUCAP DECIMAL(10, 2) NOT NULL,
    LUONGTONG DECIMAL(10, 2)
);

GO
CREATE TABLE CALAMVIEC
(
    MACA VARCHAR(6) PRIMARY KEY,
    MOTACALAMVIEC NVARCHAR(50),
    TGBATDAU TIME,
    TGKETTHUC TIME,
    NGAYLAMVIEC DATE,
    SLNHANVIEN INT
);
GO
CREATE TABLE CHAMCONG
(
    MACHAMCONG VARCHAR(8) PRIMARY KEY,
    MANV VARCHAR(6)
        FOREIGN KEY REFERENCES NHANVIEN (MANV) ON DELETE CASCADE ON UPDATE CASCADE,
    THANG VARCHAR(2),
    NAM VARCHAR(4),
    NGAYLAMVIEC DATE,
    MACA VARCHAR(6)
        FOREIGN KEY REFERENCES CALAMVIEC (MACA) ON DELETE CASCADE ON UPDATE CASCADE,
    TT BIT
        DEFAULT (0)
);


GO
CREATE TABLE PHANCONG
(
    MAPC VARCHAR(7),
    MACA VARCHAR(6)
        FOREIGN KEY REFERENCES CALAMVIEC (MACA) ON DELETE CASCADE ON UPDATE CASCADE,
    MANV VARCHAR(6)
        FOREIGN KEY REFERENCES NHANVIEN (MANV) ON DELETE CASCADE ON UPDATE CASCADE,
    PRIMARY KEY (
                    MAPC,
                    MACA,
                    MANV
                )
);

GO
INSERT INTO dbo.CHUCVU
(
    MACV,
    TENCV
)
VALUES
(   'NV',        -- MACV - varchar(2)
    N'Nhân viên' -- TENCV - nvarchar(50)
    ),
(   'QL',      -- MACV - varchar(2)
    N'Quản lý' -- TENCV - nvarchar(50)
),
(   'GD',       -- MACV - varchar(2)
    N'Giám đốc' -- TENCV - nvarchar(50)
);
GO

INSERT INTO dbo.NHANVIEN
(
    MANV,
    MACV,
    HONV,
    TENLOT,
    TENNV,
    NGAYSINH,
    DIACHI,
    GIOITINH,
    SDT,
    EMAIL,
    NGAYVAOLAM,
    CCCD,
    ANHNV
)
VALUES
(   'NV001',                     -- MANV - varchar(6)
    'GD',                        -- MACV - varchar(2)
    N'Hồ',                     -- HONV - nvarchar(20)
    N'Đăng',                    -- TENLOT - nvarchar(20)
    N'Tài',                     -- TENNV - nvarchar(20)
    CAST(N'2002-01-07' AS DATE), -- NGAYSINH - date
    N'Nha Trang,Khánh Hòa',         -- DIACHI - nvarchar(50)
    1,                           -- GIOITINH - binary(2)
    '0972589020',                -- SDT - varchar(10)
    'ABCD@gmail.com',            -- EMAIL - varchar(50)
    CAST(N'2023-05-20' AS DATE), -- NGAYVAOLAM - date

    '1236795531546',             -- CCCD - varchar(13),
    N'employee.png'),
(   'NV002',                     -- MANV - varchar(6)
    'NV',                        -- MACV - varchar(2)
    N'Nguyễn',                   -- HONV - nvarchar(20)
    N'Thành',                    -- TENLOT - nvarchar(20)
    N'Luân',                    -- TENNV - nvarchar(20)
    CAST(N'2002-02-05' AS DATE), -- NGAYSINH - date

    N'Nha Trang,Khánh Hòa',         -- DIACHI - nvarchar(50)
    1,                           -- GIOITINH - binary(2)
    '0764654876',                -- SDT - varchar(10)
    'ABCD@gmail.com',            -- EMAIL - varchar(50)
    CAST(N'2023-05-20' AS DATE), -- NGAYVAOLAM - date

    '1236795531546',             -- CCCD - varchar(13),
    N'employee.png'),
(   'NV003',                     -- MANV - varchar(6)
    'NV',                        -- MACV - varchar(2)
    N'Trần',                     -- HONV - nvarchar(20)
    N'Thị',                      -- TENLOT - nvarchar(20)
    N'Thúy',                      -- TENNV - nvarchar(20)
    CAST(N'2002-06-03' AS DATE), -- NGAYSINH - date

    N'Nha Trang,Khánh Hòa',              -- DIACHI - nvarchar(50)
    0,                           -- GIOITINH - binary(2)
    '0567943156',                -- SDT - varchar(10)
    'ABCD@gmail.com',            -- EMAIL - varchar(50)
    CAST(N'2023-05-20' AS DATE), -- NGAYVAOLAM - date

    '1236795531546',             -- CCCD - varchar(13),
    N'employee.png'),
(   'NV004',                     -- MANV - varchar(6)
    'NV',                        -- MACV - varchar(2)
    N'Võ',                    -- HONV - nvarchar(20)
    N'Tấn',                     -- TENLOT - nvarchar(20)
    N'Thành',                      -- TENNV - nvarchar(20)
    CAST(N'2002-06-04' AS DATE), -- NGAYSINH - date


    N'Nha Trang,Khánh Hòa',           -- DIACHI - nvarchar(50)
    1,                           -- GIOITINH - binary(2)
    '0985412365',                -- SDT - varchar(10)
    'thanhvt@gmail.com',           -- EMAIL - varchar(50)
    CAST(N'2023-05-21' AS DATE), -- NGAYVAOLAM - date
    '5531123679546',             -- CCCD - varchar(13),
    N'employee.png'),
(   'NV005',                     -- MANV - varchar(6)
    'QL',                        -- MACV - varchar(2)
    N'Huỳnh',                    -- HONV - nvarchar(20)
    N'Ngọc',                      -- TENLOT - nvarchar(20)
    N'Tú',                       -- TENNV - nvarchar(20)
    CAST(N'2002-05-22' AS DATE), -- NGAYSINH - date
    N'Nha Trang,Khánh Hòa',           -- DIACHI - nvarchar(50)
    0,                           -- GIOITINH - binary(2)
    '0541265756',                -- SDT - varchar(10)
    'tuhn@gmail.com',            -- EMAIL - varchar(50)
    CAST(N'2023-05-21' AS DATE), -- NGAYVAOLAM - date

    '3155123679546',             -- CCCD - varchar(13),
    N'employee.png'),
(   'NV006',                     -- MANV - varchar(6)
    'NV',                        -- MACV - varchar(2)
    N'Võ',                   -- HONV - nvarchar(20)
    N'Chí',                      -- TENLOT - nvarchar(20)
    N'Khoa',                    -- TENNV - nvarchar(20)
    CAST(N'2002-06-04' AS DATE), -- NGAYSINH - date
    N'Nha Trang,Khánh Hòa',             -- DIACHI - nvarchar(50)
    1,                           -- GIOITINH - binary(2)
    '0969554211',                -- SDT - varchar(10)
    'khoavc@gmail.com',         -- EMAIL - varchar(50)
    CAST(N'2023-05-23' AS DATE), -- NGAYVAOLAM - date
    '7954315512366',             -- CCCD - varchar(13),
    N'employee.png');
	
GO
INSERT INTO dbo.LUONG
(
    MALUONG,
    MANV,
    THANG,
    NAM,
    LUONGCOBAN,
    PHUCAP,
    LUONGTONG
)
VALUES
(   'LG01013', -- MALUONG - varchar(7)
    'NV001',   -- MANV - varchar(6)
    '01',      -- THANG - varchar(2)
    '2023',    -- NAM - char(4)
    20000,     -- LUONGCOBAN - decimal(10, 2)
    200000,    -- PHUCAP - decimal(10, 2)
    NULL       -- LUONGTONG - decimal(10, 2)
    ),
(   'LG01023', -- MALUONG - varchar(7)
    'NV002',   -- MANV - varchar(6)
    '01',      -- THANG - varchar(2)
    '2023',    -- NAM - char(4)
    15000,     -- LUONGCOBAN - decimal(10, 2)
    100000,    -- PHUCAP - decimal(10, 2)
    NULL       -- LUONGTONG - decimal(10, 2)
),
(   'LG01033', -- MALUONG - varchar(7)
    'NV003',   -- MANV - varchar(6)
    '01',      -- THANG - varchar(2)
    '2023',    -- NAM - char(4)
    20000,     -- LUONGCOBAN - decimal(10, 2)
    200000,    -- PHUCAP - decimal(10, 2)
    NULL       -- LUONGTONG - decimal(10, 2)
),
(   'LG01043', -- MALUONG - varchar(7)
    'NV004',   -- MANV - varchar(6)
    '01',      -- THANG - varchar(2)
    '2023',    -- NAM - char(4)
    20000,     -- LUONGCOBAN - decimal(10, 2)
    200000,    -- PHUCAP - decimal(10, 2)
    NULL       -- LUONGTONG - decimal(10, 2)
),
(   'LG01053', -- MALUONG - varchar(7)
    'NV005',   -- MANV - varchar(6)
    '01',      -- THANG - varchar(2)
    '2023',    -- NAM - char(4)
    20000,     -- LUONGCOBAN - decimal(10, 2)
    200000,    -- PHUCAP - decimal(10, 2)
    NULL       -- LUONGTONG - decimal(10, 2)
),
(   'LG01063', -- MALUONG - varchar(7)
    'NV006',   -- MANV - varchar(6)
    '01',      -- THANG - varchar(2)
    '2023',    -- NAM - char(4)
    20000,     -- LUONGCOBAN - decimal(10, 2)
    200000,    -- PHUCAP - decimal(10, 2)
    NULL       -- LUONGTONG - decimal(10, 2)
);
GO
INSERT INTO dbo.CALAMVIEC
(
    MACA,
    MOTACALAMVIEC,
    TGBATDAU,
    TGKETTHUC,
    NGAYLAMVIEC,
    SLNHANVIEN
)
VALUES
(   'CA01',      -- MACA - varchar(6)
    N'Ca sáng',   -- MOTACALAMVIEC - nvarchar(50)
    '08:00',      -- TGBATDAU - time(7)
    '11:30',      -- TGKETTHUC - time(7)
    '2023-06-01', -- NGAYLAMVIEC - date
    '3'           -- SLNHANVIEN - int
    ),
(   'CA02',      -- MACA - varchar(6)
    N'Ca chiều',  -- MOTACALAMVIEC - nvarchar(50)
    '14:00',      -- TGBATDAU - time(7)
    '17:30',      -- TGKETTHUC - time(7)
    '2023-06-01', -- NGAYLAMVIEC - date
    '2'           -- SLNHANVIEN - int
),
(   'CA03',      -- MACA - varchar(6)
    N'Ca tối',    -- MOTACALAMVIEC - nvarchar(50)
    '17:30',      -- TGBATDAU - time(7)
    '21:00',      -- TGKETTHUC - time(7)
    '2023-06-01', -- NGAYLAMVIEC - date
    '2'           -- SLNHANVIEN - int
),
(   'CA04',      -- MACA - varchar(6)
    N'Ca sáng',   -- MOTACALAMVIEC - nvarchar(50)
    '08:00',      -- TGBATDAU - time(7)
    '11:30',      -- TGKETTHUC - time(7)
    '2023-06-02', -- NGAYLAMVIEC - date
    '3'           -- SLNHANVIEN - int
),
(   'CA05',      -- MACA - varchar(6)
    N'Ca chiều',  -- MOTACALAMVIEC - nvarchar(50)
    '14:00',      -- TGBATDAU - time(7)
    '17:30',      -- TGKETTHUC - time(7)
    '2023-06-02', -- NGAYLAMVIEC - date
    '2'           -- SLNHANVIEN - int
),
(   'CA06',      -- MACA - varchar(6)
    N'Ca tối',    -- MOTACALAMVIEC - nvarchar(50)
    '17:30',      -- TGBATDAU - time(7)
    '21:00',      -- TGKETTHUC - time(7)
    '2023-06-02', -- NGAYLAMVIEC - date
    '2'           -- SLNHANVIEN - int
);

GO


INSERT INTO dbo.PHANCONG
(
    MAPC,
    MACA,
    MANV
)
VALUES
(   'PC001', -- MAPC - varchar(7)
    'CA01', -- MACA - varchar(6)
    'NV002'  -- MANV - varchar(6)
    ),
(   'PC002', -- MAPC - varchar(6)
    'CA02', -- MACA - varchar(6)
    'NV003'  -- MANV - varchar(6)
),
(   'PC003', -- MAPC - varchar(6)
    'CA03', -- MACA - varchar(6)
    'NV004'  -- MANV - varchar(6)
),
(   'PC004', -- MAPC - varchar(6)
    'CA04', -- MACA - varchar(6)
    'NV005'  -- MANV - varchar(6)
),
(   'PC005', -- MAPC - varchar(7)
    'CA05', -- MACA - varchar(6)
    'NV006'  -- MANV - varchar(6)
),
(   'PC006', -- MAPC - varchar(7)
    'CA06', -- MACA - varchar(6)
    'NV006'  -- MANV - varchar(6)
);
go
INSERT INTO dbo.QUANTRI
(
    EMAIL,
    ADMIN,
    HoTen,
    PASSWORD
)
VALUES
(   'hotai422@gmail.com',   -- EMAIL - varchar(50)
    1, -- ADMIN - binary(2)
    'Hồ Đăng Tài', -- HoTen - varchar(50)
    '123456'  -- PASSWORD - varchar(50)
    )

	go
CREATE PROCEDURE NhanVien_TimKiemNC
    @MaNV varchar(6)=NULL,
	@HoTen nvarchar(50)=NULL,
	@GioiTinh nvarchar(3)= NULL,
	@SDT varchar(10)=NULL,
	@CCCD varchar(13)=NULL,
	@DiaChi nvarchar(50)=NULL,
	@MaCV varchar(2)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM NHANVIEN
       WHERE  (1=1)
       '
IF @MaNV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MANV LIKE ''%'+@MaNV+'%'')
              '
IF @HoTen IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (HONV+'' ''+TENNV LIKE ''%'+@HoTen+'%'')
              '
IF @GioiTinh IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (GIOITINH LIKE ''%'+@GioiTinh+'%'')
             '
IF @CCCD IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (CCCD LIKE ''%'+@CCCD+'%'')
             '
			 IF @SDT IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (SDT LIKE ''%'+@SDT+'%'')
             '
IF @DiaChi IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (DIACHI LIKE ''%'+@DiaChi+'%'')
              '
IF @MACV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MACV LIKE ''%'+@MACV+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END

GO
CREATE PROCEDURE CaLamViec_TimKiemNC
    @MaCA varchar(6)=NULL,
	@MOTA nvarchar(50)=NULL,
	@NGAYLAMVIEC nvarchar(20)= NULL

AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM CALAMVIEC
       WHERE  (1=1)
       '
IF @MaCA IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MACA LIKE ''%'+@MaCA+'%'')
              '
IF @MOTA IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (MOTACALAMVIEC LIKE ''%'+@MOTA+'%'')
             '
IF @NGAYLAMVIEC IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (NGAYLAMVIEC LIKE ''%'+@NGAYLAMVIEC+'%'')
             '


	EXEC SP_EXECUTESQL @SqlStr
END



