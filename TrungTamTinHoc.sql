﻿Create database TrungTamTinHoc

use TrungTamTinHoc

CREATE TABLE Teacher 
(
    TeacherID char(10) PRIMARY KEY,
    FirstName nvarchar(50),
    LastName nvarchar(50),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Birthday DATE
);

CREATE TABLE Student (
    StudentID char(10) PRIMARY KEY,
    FirstName nvarchar(50),
    LastName nvarchar(50),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Birthday DATE
);

CREATE TABLE Classrooms (
    ClassroomId char(10) PRIMARY KEY,
    ClassroomName NVARCHAR(50),
    Capacity INT,
    TeacherID char(10) not null,
    AmountOfMoney int,
    FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID),
);

CREATE TABLE PAYMENTS(
	PaymentsID char(10) PRIMARY KEY,
	StudentID char(10) not null,
	ClassroomId char(10) not null,
	AmountOfMoney int,
	Active char(3),
	MoneyDate DateTime,
	FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
	FOREIGN KEY (ClassroomId) REFERENCES Classrooms(ClassroomId)
)

CREATE TABLE SCHEDULE(
	ScheduleID char(10) PRIMARY KEY,
	StartDate DATE,
    	EndDate DATE,
	ClassroomId char(10) not null,
	Ca int,
	FOREIGN KEY (ClassroomId) REFERENCES Classrooms(ClassroomId)
)

CREATE TABLE MANAGERCLASS(
	StudentID char(10) not null,
	ClassroomId char(10) not null,
	TeacherID char(10) not null,
	FOREIGN KEY (ClassroomId) REFERENCES Classrooms(ClassroomId),
	FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
	FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID),
)

CREATE TABLE ACCOUNT
(
	StudentID char(10) primary key,
	Pass char(20),
	Constraint FK_ACCOUNT_STUDENT foreign key(StudentID) references Student(StudentID)
)

INSERT INTO Student 
VALUES 
('S001', N'Ngọc', N'Trần', 'ngoc.tran01@email.com.vn', '9876543210', '2000-03-15'),
('S002', N'Dũng', N'Nguyễn', 'dung.nguyen02@email.com.vn', '9876543211', '2002-04-20'),
('S003', N'Hương', N'Lê', 'huong.le03@email.com.vn', '9876543212', '1999-05-10'),
('S004', N'Phát', N'Đặng', 'phat.dang04@email.com.vn', '9876543213', '2003-06-12'),
('S005', N'Thảo', N'Phạm', 'thao.pham05@email.com.vn', '9876543214', '2001-07-18'),
('S006', N'Bình', N'Võ', 'binh.vo06@email.com.vn', '9876543215', '1998-08-25'),
('S007', N'Lan', N'Hồ', 'lan.ho07@email.com.vn', '9876543216', '2002-09-19'),
('S008', N'Khang', N'Bùi', 'khang.bui08@email.com.vn', '9876543217', '2000-11-23'),
('S009', N'Mai', N'Lương', 'mai.luong09@email.com.vn', '9876543218', '1997-01-14'),
('S010', N'Việt', N'Chu', 'viet.chu10@email.com.vn', '9876543219', '1999-02-28'),
('S011', N'Thu', N'Dương', 'thu.duong11@email.com.vn', '9876543220', '2002-01-15'),
('S012', N'Khiêm', N'Đỗ', 'khiem.do12@email.com.vn', '9876543221', '2001-05-09'),
('S013', N'Chi', N'Lý', 'chi.ly13@email.com.vn', '9876543222', '2000-06-13'),
('S014', N'Nga', N'Ngô', 'nga.ngo14@email.com.vn', '9876543223', '2002-08-21'),
('S015', N'Hào', N'Vương', 'hao.vuong15@email.com.vn', '9876543224', '1999-12-05'),
('S016', N'Trang', N'Cao', 'trang.cao16@email.com.vn', '9876543225', '2001-11-29'),
('S017', N'Hải', N'Mã', 'hai.ma17@email.com.vn', '9876543226', '2003-02-20'),
('S018', N'Tuyết', N'Đinh', 'tuyet.dinh18@email.com.vn', '9876543227', '2002-10-27'),
('S019', N'Duy', N'Phùng', 'duy.phung19@email.com.vn', '9876543228', '1998-09-11'),
('S020', N'Thủy', N'Hà', 'thuy.ha20@email.com.vn', '9876543229', '2000-03-23'),
('S021', N'Lâm', N'La', 'lam.la21@email.com.vn', '9876543230', '2001-04-04'),
('S022', N'Tâm', N'Khương', 'tam.khuong22@email.com.vn', '9876543231', '1997-05-15'),
('S023', N'Phong', N'Phan', 'phong.phan23@email.com.vn', '9876543232', '2002-07-07'),
('S024', N'Mỹ', N'Đào', 'my.dao24@email.com.vn', '9876543233', '1999-08-16'),
('S025', N'Quang', N'Hứa', 'quang.hua25@email.com.vn', '9876543234', '2003-11-12'),
('S026', N'Nguyên', N'Bạch', 'nguyen.bach26@email.com.vn', '9876543235', '2002-09-21'),
('S027', N'Yến', N'Chung', 'yen.chung27@email.com.vn', '9876543236', '2000-10-30'),
('S028', N'Sơn', N'Lục', 'son.luc28@email.com.vn', '9876543237', '1998-12-10'),
('S029', N'Thanh', N'Yên', 'thanh.yen29@email.com.vn', '9876543238', '1999-01-20'),
('S030', N'Nhi', N'Nguyễn', 'nhi.nguyen30@email.com.vn', '9876543239', '2001-02-22')

INSERT INTO Teacher 
VALUES 
('T001', N'Hải', N'Nguyễn', 'hai.nguyen01@email.com.vn', '0123456789', '1985-03-15'),
('T002', N'Lan', N'Phạm', 'lan.pham02@email.com.vn', '0123456790', '1982-04-20'),
('T003', N'Nam', N'Lê', 'nam.le03@email.com.vn', '0123456791', '1986-05-10'),
('T004', N'Phượng', N'Đặng', 'phuong.dang04@email.com.vn', '0123456792', '1980-06-12'),
('T005', N'Tùng', N'Trần', 'tung.tran05@email.com.vn', '0123456793', '1984-07-18'),
('T006', N'Hương', N'Võ', 'huong.vo06@email.com.vn', '0123456794', '1983-08-25'),
('T007', N'Bảo', N'Hồ', 'bao.ho07@email.com.vn', '0123456795', '1981-09-19'),
('T008', N'Thảo', N'Bùi', 'thao.bui08@email.com.vn', '0123456796', '1982-11-23'),
('T009', N'Sơn', N'Lương', 'son.luong09@email.com.vn', '0123456797', '1987-01-14'),
('T010', N'Mai', N'Chu', 'mai.chu10@email.com.vn', '0123456798', '1983-02-28')

INSERT INTO Classrooms
VALUES 
('C001', N'Lập trình C# căn bản', 0, 'T001', 5000000),
('C002', N'Thiết kế giao diện web', 0, 'T002', 5500000),
('C003', N'Lập trình Java', 0, 'T003', 5300000),
('C004', N'Quản trị cơ sở dữ liệu', 0, 'T004', 6000000),
('C005', N'Lập trình Python', 0, 'T005', 4800000),
('C006', N'Phân tích thiết kế hệ thống', 0, 'T006', 6500000),
('C007', N'Lập trình web PHP', 0, 'T007', 5100000),
('C008', N'Lập trình Android', 0, 'T008', 5800000),
('C009', N'Thiết kế đồ họa', 0, 'T009', 5200000),
('C010', N'Kỹ thuật lập trình', 0, 'T010', 5400000)

INSERT INTO PAYMENTS
VALUES 
('PMT031', 'S001', 'C003', 333333, 'yes','2023-10-25')
INSERT INTO PAYMENTS
VALUES 
('PMT001', 'S001', 'C001', 1000000, 'No',null),
('PMT002', 'S002', 'C002', 1500000, 'No', null),
('PMT003', 'S003', 'C003', 1200000, 'Yes','2023-10-22'),
('PMT004', 'S004', 'C004', 1100000, 'No',null),
('PMT005', 'S005', 'C005', 1300000, 'No',null),
('PMT006', 'S006', 'C006', 1400000, 'No',null),
('PMT007', 'S007', 'C007', 1000000, 'Yes','2023-10-22'),
('PMT008', 'S008', 'C008', 1500000, 'No',null),
('PMT009', 'S009', 'C009', 1200000, 'No',null),
('PMT010', 'S010', 'C010', 1400000, 'Yes','2023-10-22'),
('PMT011', 'S011', 'C001', 1005000, 'No',null),
('PMT012', 'S012', 'C002', 1550000, 'No',null),
('PMT013', 'S013', 'C003', 1230000, 'No',null),
('PMT014', 'S014', 'C004', 1105000, 'No',null),
('PMT015', 'S015', 'C005', 1340000, 'Yes','2023-10-22'),
('PMT016', 'S016', 'C006', 1450000, 'No',null),
('PMT017', 'S017', 'C007', 1010000,'No',null),
('PMT018', 'S018', 'C008', 1520000, 'Yes','2023-10-22'),
('PMT019', 'S019', 'C009', 1250000, 'No',null),
('PMT020', 'S020', 'C010', 1460000, 'No',null),
('PMT021', 'S021', 'C001', 1015000, 'No',null),
('PMT022', 'S022', 'C002', 1560000, 'Yes','2023-10-22'),
('PMT023', 'S023', 'C003', 1280000, 'No',null),
('PMT024', 'S024', 'C004', 1125000, 'No',null),
('PMT025', 'S025', 'C005', 1370000, 'Yes','2023-10-22'),
('PMT026', 'S026', 'C006', 1490000, 'No',null),
('PMT027', 'S027', 'C007', 1050000, 'No',null),
('PMT028', 'S028', 'C008', 1570000, 'Yes','2023-10-22'),
('PMT029', 'S029', 'C009', 1290000, 'No',null),
('PMT030', 'S030', 'C010', 1500000, 'No',null)

INSERT INTO SCHEDULE
VALUES 
('SCH001', '2023-01-10 14:00:00', '2023-01-10 17:00:00', 'C001', 3),
('SCH002', '2023-01-17 17:00:00', '2023-01-17 20:00:00', 'C001',4),
('SCH003', '2023-01-24 14:00:00', '2023-01-24 17:00:00', 'C001',3),
('SCH004', '2023-01-31 7:00:00', '2023-01-31 10:00:00', 'C001',1),
('SCH005', '2023-01-7 14:00:00', '2023-01-7 17:00:00', 'C001',3),
('SCH006', '2023-01-14 10:00:00', '2023-01-14 13:00:00', 'C001',2),
('SCH007', '2023-01-21 14:00:00', '2023-01-21 17:00:00', 'C001',3),
('SCH008', '2023-01-28 14:00:00', '2023-01-28 17:00:00', 'C001',3),
('SCH009', '2023-08-15 17:00:00', '2023-08-15 20:00:00', 'C002',4),
('SCH010', '2023-08-22 7:00:00', '2023-08-22 10:00:00', 'C002',1),
('SCH011', '2023-08-29 7:00:00', '2023-08-29 10:00:00', 'C002',1),
('SCH012', '2023-09-05 7:00:00', '2023-09-05 10:00:00', 'C002',1),
('SCH013', '2023-09-12 10:00:00', '2023-09-12 13:00:00', 'C002',2),
('SCH014', '2023-09-15 7:00:00', '2023-09-15 10:00:00', 'C002',1),
('SCH015', '2023-09-22 14:00:00', '2023-09-22 17:00:00', 'C002',3),
('SCH016', '2023-09-29 7:00:00', '2023-09-29 10:00:00', 'C002',1),
('SCH017', '2023-02-01 14:00:00', '2023-02-01 17:00:00', 'C003',3),
('SCH018', '2023-02-08 14:00:00', '2023-02-08 17:00:00', 'C003',3),
('SCH019', '2023-02-15 14:00:00', '2023-02-15 17:00:00', 'C003',3),
('SCH020', '2023-02-22 7:00:00', '2023-02-22 10:00:00', 'C003',1),
('SCH021', '2023-03-01 17:00:00', '2023-03-01 20:00:00', 'C003',4),
('SCH022', '2023-03-05 14:00:00', '2023-03-05 17:00:00', 'C003',3),
('SCH023', '2023-03-12 10:00:00', '2023-03-12 13:00:00', 'C003',2),
('SCH024', '2023-03-19 14:00:00', '2023-03-19 17:00:00', 'C003',3),
('SCH025', '2023-02-05 10:00:00', '2023-02-05 13:00:00', 'C004',2),
('SCH026', '2023-02-12 10:00:00', '2023-02-12 13:00:00', 'C004',2),
('SCH027', '2023-02-17 14:00:00', '2023-02-17 17:00:00', 'C004',3),
('SCH028', '2023-02-24 17:00:00', '2023-02-24 20:00:00', 'C004',4),
('SCH029', '2023-02-28 14:00:00', '2023-02-28 17:00:00', 'C004',3),
('SCH030', '2023-03-07 7:00:00', '2023-03-07 10:00:00', 'C004',1),
('SCH031', '2023-03-14 17:00:00', '2023-03-14 20:00:00', 'C004',4),
('SCH032', '2023-03-21 17:00:00', '2023-03-21 20:00:00', 'C004',4),
('SCH033', '2023-02-03 7:00:00', '2023-02-03 10:00:00', 'C005',1),
('SCH034', '2023-02-10 7:00:00', '2023-02-10 10:00:00', 'C005',1),
('SCH035', '2023-02-17 7:00:00', '2023-02-17 10:00:00', 'C005',1),
('SCH036', '2023-02-24 14:00:00', '2023-02-24 17:00:00', 'C005',3),
('SCH037', '2023-03-02 17:00:00', '2023-03-02 20:00:00', 'C005',4),
('SCH038', '2023-03-09 7:00:00', '2023-03-07 10:00:00', 'C005',1),
('SCH039', '2023-03-16 17:00:00', '2023-03-14 20:00:00', 'C005',4),
('SCH040', '2023-03-23 7:00:00', '2023-03-21 10:00:00', 'C005',1),
('SCH041', '2023-08-10 17:00:00', '2023-08-10 20:00:00', 'C006',4),
('SCH042', '2023-08-17 17:00:00', '2023-08-17 20:00:00', 'C006',4),
('SCH043', '2023-08-24 17:00:00', '2023-08-24 20:00:00', 'C006',4),
('SCH044', '2023-08-31 17:00:00', '2023-08-31 20:00:00', 'C006',4),
('SCH045', '2023-09-07 17:00:00', '2023-09-07 20:00:00', 'C006',4),
('SCH046', '2023-09-14 17:00:00', '2023-09-14 20:00:00', 'C006',4),
('SCH047', '2023-09-21 17:00:00', '2023-09-21 20:00:00', 'C006',4),
('SCH048', '2023-09-29 17:00:00', '2023-09-29 20:00:00', 'C006',4),
('SCH049', '2023-06-15 14:00:00', '2023-06-15 17:00:00', 'C007',3),
('SCH050', '2023-06-22 7:00:00', '2023-06-22 10:00:00', 'C007',1),
('SCH051', '2023-06-29 10:00:00', '2023-06-29 13:00:00', 'C007',2),
('SCH052', '2023-07-06 7:00:00', '2023-07-06 10:00:00', 'C007',1),
('SCH053', '2023-07-13 17:00:00', '2023-07-13 20:00:00', 'C007',4),
('SCH054', '2023-07-20 14:00:00', '2023-07-20 17:00:00', 'C007',3),
('SCH055', '2023-07-27 17:00:00', '2023-07-27 20:00:00', 'C007',4),
('SCH056', '2023-08-03 14:00:00', '2023-08-03 17:00:00', 'C007',3),
('SCH057', '2023-04-01 14:00:00', '2023-04-01 17:00:00', 'C008',3),
('SCH058', '2023-04-08 14:00:00', '2023-04-08 17:00:00', 'C008',3),
('SCH059', '2023-04-15 7:00:00', '2023-04-15 10:00:00', 'C008',1),
('SCH060', '2023-04-22 7:00:00', '2023-04-22 10:00:00', 'C008',1),
('SCH061', '2023-04-29 7:00:00', '2023-04-29 10:00:00', 'C008',1),
('SCH062', '2023-05-06 17:00:00', '2023-05-06 20:00:00', 'C008',4),
('SCH063', '2023-05-13 17:00:00', '2023-05-13 20:00:00', 'C008',4),
('SCH064', '2023-05-20 10:00:00', '2023-05-20 13:00:00', 'C008',2),
('SCH065', '2023-09-02 7:00:00', '2023-09-02 10:00:00', 'C009',1),
('SCH066', '2023-09-09 7:00:00', '2023-09-09 10:00:00', 'C009',1),
('SCH067', '2023-09-16 14:00:00', '2023-09-16 17:00:00', 'C009',3),
('SCH068', '2023-09-23 14:00:00', '2023-09-23 17:00:00', 'C009',3),
('SCH069', '2023-09-30 14:00:00', '2023-09-30 17:00:00', 'C009',3),
('SCH070', '2023-10-07 17:00:00', '2023-10-07 20:00:00', 'C009',4),
('SCH071', '2023-10-14 17:00:00', '2023-10-14 20:00:00', 'C009',4),
('SCH072', '2023-10-21 17:00:00', '2023-10-21 20:00:00', 'C009',4),
('SCH073', '2023-04-25 7:00:00', '2023-04-25 10:00:00', 'C010',1),
('SCH074', '2023-05-02 7:00:00', '2023-05-02 10:00:00', 'C010',1),
('SCH075', '2023-05-09 7:00:00', '2023-05-09 10:00:00', 'C010',1),
('SCH076', '2023-05-16 7:00:00', '2023-05-16 10:00:00', 'C010',1),
('SCH077', '2023-05-23 17:00:00', '2023-05-23 20:00:00', 'C010',4),
('SCH078', '2023-05-30 17:00:00', '2023-05-30 20:00:00', 'C010',4),
('SCH079', '2023-06-06 17:00:00', '2023-06-06 20:00:00', 'C010',4),
('SCH080', '2023-06-13 17:00:00', '2023-06-13 20:00:00', 'C010',4);

INSERT INTO MANAGERCLASS
VALUES 
('S001', 'C001', 'T001'),
('S002', 'C001', 'T001'),
('S003', 'C001', 'T001'),
('S004', 'C002', 'T002'),
('S005', 'C002', 'T002'),
('S006', 'C002', 'T002'),
('S007', 'C003', 'T003'),
('S008', 'C003', 'T003'),
('S009', 'C003', 'T003'),
('S010', 'C004', 'T004'),
('S011', 'C004', 'T004'),
('S012', 'C004', 'T004'),
('S013', 'C005', 'T005'),
('S014', 'C005', 'T005'),
('S015', 'C005', 'T005'),
('S016', 'C006', 'T006'),
('S017', 'C006', 'T006'),
('S018', 'C006', 'T006'),
('S019', 'C007', 'T007'),
('S020', 'C007', 'T007'),
('S021', 'C007', 'T007'),
('S022', 'C008', 'T008'),
('S023', 'C008', 'T008'),
('S024', 'C008', 'T008'),
('S025', 'C009', 'T009'),
('S026', 'C009', 'T009'),
('S027', 'C009', 'T009'),
('S028', 'C010', 'T010'),
('S029', 'C010', 'T010'),
('S030', 'C010', 'T010')


insert into ACCOUNT values
('S001', '123'),
('S002','123'),
('S003', '123'),
('S004', '123'),
('S005', '123'),
('S006','123'),
('S007', '123'),
('S008', '123'),
('S009', '123'),
('S010', '123'),
('S011', '123'),
('S012', '123'),
('S013', '123'),
('S014', '123'),
('S015', '123'),
('S016', '123'),
('S017', '123'),
('S018','123'),
('S019', '123'),
('S020', '123'),
('S021', '123'),
('S022', '123'),
('S023', '123'),
('S024', '123'),
('S025', '123'),
('S026', '123'),
('S027', '123'),
('S028', '123'),
('S029', '123'),
('S030', '123')

CREATE FUNCTION SearchStudents (@searchTerm NVARCHAR(100))
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM Student
    WHERE CONCAT_WS(' ', StudentID, FirstName, LastName, Email, Phone) LIKE '%' + @searchTerm + '%'
);

CREATE FUNCTION SearchTeachers (@searchTerm NVARCHAR(100))
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM Teacher
    WHERE CONCAT_WS(' ', TeacherID, FirstName, LastName, Email, Phone) LIKE '%' + @searchTerm + '%'
);

CREATE FUNCTION SearchClassrooms (@searchTerm NVARCHAR(100))
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM Classrooms
    WHERE CONCAT_WS(' ', ClassroomId,ClassroomName,Capacity, TeacherID, AmountOfMoney) LIKE '%' + @searchTerm + '%'
);

SELECT * FROM dbo.SearchStudents('001');
SELECT * FROM dbo.SearchTeachers('001');
SELECT * FROM dbo.SearchClassrooms('001');


select sum(AmountOfMoney) from PAYMENTS where StudentID = 'S001'

select * from Classrooms

update Classrooms
set Capacity = (select count(*) from MANAGERCLASS where Classrooms.ClassroomId = MANAGERCLASS.ClassroomId)

CREATE TRIGGER trg_UpdateCapacity
ON MANAGERCLASS
AFTER INSERT, DELETE
AS
BEGIN
    SET NOCOUNT ON;

  update Classrooms
	set Capacity = (select count(*) from MANAGERCLASS where Classrooms.ClassroomId = MANAGERCLASS.ClassroomId)

END;
GO

Create trigger updateAccount
ON STUDENT
AFTER INSERT
AS
BEGIN
	declare @tk char(10),@mk char(20)
	set @mk = '123';
	Select @tk = StudentID from inserted;
	insert into ACCOUNT values (@tk,@mk)
END;

Create trigger updateAccount1
ON STUDENT
AFTER DELETE
AS
BEGIN
	declare @ma char(10)
	select @ma = StudentID from deleted
	delete ACCOUNT where StudentID = @ma;
END;


