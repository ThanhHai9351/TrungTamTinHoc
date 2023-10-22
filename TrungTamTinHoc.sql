use master
create database TrungTamTinHoc
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
    UnpaidAmount money,
    Birthday DATE
);
CREATE TABLE Classrooms (
    ClassroomId char(10) PRIMARY KEY,
    ClassroomName NVARCHAR(50),
    Capacity INT,
    TeacherID char(10) not null,
    AmountOfMoney money,
    FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID),
);
CREATE TABLE AccountStudents(
	AccountStudentsID int IDENTITY(1,1) PRIMARY KEY,
	StudentID char(10) not null,
	Passwd char(10) not null,
	FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
)
CREATE TABLE AccountTeachers(
	AccountTeachersID int IDENTITY(1,1) PRIMARY KEY,
	TeacherID char(10) not null,
	Passwd char(10) not null,
	FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID)
)
CREATE TABLE PAYMENTS(
	PaymentsID char(10) PRIMARY KEY,
	StudentID char(10) not null,
	ClassroomId char(10) not null,
	AmountOfMoney money,
	Active char(3),
	FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
	FOREIGN KEY (ClassroomId) REFERENCES Classrooms(ClassroomId)
)
CREATE TABLE SCHEDULE(
	ScheduleID char(10) PRIMARY KEY,
	StartDate DATE,
    EndDate DATE,
	ClassroomId char(10) not null,
	FOREIGN KEY (ClassroomId) REFERENCES Classrooms(ClassroomId)
)
CREATE TABLE MANAGERCLASS(
	StudentID char(10) not null,
	ClassroomId char(10) not null,
	TeacherID char(10) not null,
	FOREIGN KEY (ClassroomId) REFERENCES Classrooms(ClassroomId),
	FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
	FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID),
	PRIMARY KEY (StudentID, ClassroomId)
)
GO
CREATE TRIGGER trg_UpdateCapacity
ON MANAGERCLASS
AFTER INSERT, DELETE
AS
BEGIN
    UPDATE c
    SET Capacity = Capacity + i.Cnt
    FROM Classrooms c
    INNER JOIN (SELECT ClassroomId, COUNT(*) as Cnt FROM INSERTED GROUP BY ClassroomId) i
    ON c.ClassroomId = i.ClassroomId;

    UPDATE c
    SET Capacity = Capacity - d.Cnt
    FROM Classrooms c
    INNER JOIN (SELECT ClassroomId, COUNT(*) as Cnt FROM DELETED GROUP BY ClassroomId) d
    ON c.ClassroomId = d.ClassroomId;
END
GO
CREATE TRIGGER tr_AutoCreateStudentAccount 
ON Student
AFTER INSERT
AS
BEGIN
    INSERT INTO AccountStudents (StudentID, Passwd)
    SELECT StudentID, 'mk10'
    FROM INSERTED
END
GO
CREATE TRIGGER tr_AutoCreateTeacherAccount 
ON Teacher
AFTER INSERT
AS
BEGIN
    INSERT INTO AccountTeachers (TeacherID, Passwd)
    SELECT TeacherID, 'mk10'
    FROM INSERTED
END
GO
INSERT INTO Student 
VALUES 
('S001', N'Ngọc', N'Trần', 'ngoc.tran01@email.com.vn', '9876543210', 500.00, '2000-03-15'),
('S002', N'Dung', N'Nguyễn', 'dung.nguyen02@email.com.vn', '9876543211', 300.00, '2002-04-20'),
('S003', N'Hưng', N'Lê', 'huong.le03@email.com.vn', '9876543212', 0.00, '1999-05-10'),
('S004', N'Phát', N'Đặng', 'phat.dang04@email.com.vn', '9876543213', 250.00, '2003-06-12'),
('S005', N'Thảo', N'Phạm', 'thao.pham05@email.com.vn', '9876543214', 0.00, '2001-07-18'),
('S006', N'Bình', N'Võ', 'binh.vo06@email.com.vn', '9876543215', 100.00, '1998-08-25'),
('S007', N'Lan', N'Hồ', 'lan.ho07@email.com.vn', '9876543216', 0.00, '2002-09-19'),
('S008', N'Khang', N'Bùi', 'khang.bui08@email.com.vn', '9876543217', 450.00, '2000-11-23'),
('S009', N'Mai', N'Lương', 'mai.luong09@email.com.vn', '9876543218', 600.00, '1997-01-14'),
('S010', N'Việt', N'Chu', 'viet.chu10@email.com.vn', '9876543219', 0.00, '1999-02-28'),
('S011', N'Thu', N'Dương', 'thu.duong11@email.com.vn', '9876543220', 430.00, '2002-01-15'),
('S012', N'Khiêm', N'Đỗ', 'khiem.do12@email.com.vn', '9876543221', 250.00, '2001-05-09'),
('S013', N'Chi', N'Lý', 'chi.ly13@email.com.vn', '9876543222', 120.00, '2000-06-13'),
('S014', N'Nga', N'Ngô', 'nga.ngo14@email.com.vn', '9876543223', 350.00, '2002-08-21'),
('S015', N'Hào', N'Vương', 'hao.vuong15@email.com.vn', '9876543224', 0.00, '1999-12-05'),
('S016', N'Trang', N'Cao', 'trang.cao16@email.com.vn', '9876543225', 500.00, '2001-11-29'),
('S017', N'Hải', N'Mã', 'hai.ma17@email.com.vn', '9876543226', 270.00, '2003-02-20'),
('S018', N'Tuyết', N'Đinh', 'tuyet.dinh18@email.com.vn', '9876543227', 0.00, '2002-10-27'),
('S019', N'Duy', N'Phùng', 'duy.phung19@email.com.vn', '9876543228', 120.00, '1998-09-11'),
('S020', N'Thủy', N'Hà', 'thuy.ha20@email.com.vn', '9876543229', 300.00, '2000-03-23'),
('S021', N'Lâm', N'La', 'lam.la21@email.com.vn', '9876543230', 480.00, '2001-04-04'),
('S022', N'Tâm', N'Khương', 'tam.khuong22@email.com.vn', '9876543231', 0.00, '1997-05-15'),
('S023', N'Phong', N'Phan', 'phong.phan23@email.com.vn', '9876543232', 290.00, '2002-07-07'),
('S024', N'Mỹ', N'Đào', 'my.dao24@email.com.vn', '9876543233', 130.00, '1999-08-16'),
('S025', N'Quang', N'Hứa', 'quang.hua25@email.com.vn', '9876543234', 0.00, '2003-11-12'),
('S026', N'Nguyên', N'Bạch', 'nguyen.bach26@email.com.vn', '9876543235', 540.00, '2002-09-21'),
('S027', N'Yến', N'Chung', 'yen.chung27@email.com.vn', '9876543236', 600.00, '2000-10-30'),
('S028', N'Sơn', N'Lục', 'son.luc28@email.com.vn', '9876543237', 0.00, '1998-12-10'),
('S029', N'Thanh', N'Yên', 'thanh.yen29@email.com.vn', '9876543238', 210.00, '1999-01-20'),
('S030', N'Nhi', N'Nguyễn', 'nhi.nguyen30@email.com.vn', '9876543239', 320.00, '2001-02-22')

SELECT * FROM Student
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

SELECT * FROM Teacher
INSERT INTO Classrooms
VALUES 
('C001', N'Lập trình C# cơ bản', 0, 'T001', 5000000),
('C002', N'Thiết kế giao diện web', 0, 'T002', 5500000),
('C003', N'Lập trình Java', 0, 'T003', 5300000),
('C004', N'Quản trị cơ sơ dữ liệu', 0, 'T004', 6000000),
('C005', N'Lập trình Python', 0, 'T005', 4800000),
('C006', N'Phân tích thiết kế hệ thống', 0, 'T006', 6500000),
('C007', N'Lập trình web PHP', 0, 'T007', 5100000),
('C008', N'Lập trình Android', 0, 'T008', 5800000),
('C009', N'Thiết kế đồ họa', 0, 'T009', 5200000),
('C010', N'Kĩ thuật lập trình', 0, 'T010', 5400000)

SELECT * FROM Classrooms
INSERT INTO AccountStudents
VALUES 
('S001', 'mk10'),
('S002', 'mk10'),
('S003', 'mk10'),
('S004', 'mk10'),
('S005', 'mk10'),
('S006', 'mk10'),
('S007', 'mk10'),
('S008', 'mk10'),
('S009', 'mk10'),
('S010', 'mk10'),
('S011', 'mk10'),
('S012', 'mk10'),
('S013', 'mk10'),
('S014', 'mk10'),
('S015', 'mk10'),
('S016', 'mk10'),
('S017', 'mk10'),
('S018', 'mk10'),
('S019', 'mk10'),
('S020', 'mk10'),
('S021', 'mk10'),
('S022', 'mk10'),
('S023', 'mk10'),
('S024', 'mk10'),
('S025', 'mk10'),
('S026', 'mk10'),
('S027', 'mk10'),
('S028', 'mk10'),
('S029', 'mk10'),
('S030', 'mk10')

SELECT * FROM AccountStudents
INSERT INTO AccountTeachers
VALUES 
('T001', 'mk10'),
('T002', 'mk10'),
('T003', 'mk10'),
('T004', 'mk10'),
('T005', 'mk10'),
('T006', 'mk10'),
('T007', 'mk10'),
('T008', 'mk10'),
('T009', 'mk10'),
('T010', 'mk10')

SELECT * FROM AccountTeachers
INSERT INTO PAYMENTS
VALUES 
('PMT001', 'S001', 'C001', 1000000, 'No'),
('PMT002', 'S002', 'C002', 1500000, 'No'),
('PMT003', 'S003', 'C003', 1200000, 'Yes'),
('PMT004', 'S004', 'C004', 1100000, 'No'),
('PMT005', 'S005', 'C005', 1300000, 'No'),
('PMT006', 'S006', 'C006', 1400000, 'No'),
('PMT007', 'S007', 'C007', 1000000, 'Yes'),
('PMT008', 'S008', 'C008', 1500000, 'No'),
('PMT009', 'S009', 'C009', 1200000, 'No'),
('PMT010', 'S010', 'C010', 1400000, 'Yes'),
('PMT011', 'S011', 'C001', 1005000, 'No'),
('PMT012', 'S012', 'C002', 1550000, 'No'),
('PMT013', 'S013', 'C003', 1230000, 'No'),
('PMT014', 'S014', 'C004', 1105000, 'No'),
('PMT015', 'S015', 'C005', 1340000, 'Yes'),
('PMT016', 'S016', 'C006', 1450000, 'No'),
('PMT017', 'S017', 'C007', 1010000, 'No'),
('PMT018', 'S018', 'C008', 1520000, 'Yes'),
('PMT019', 'S019', 'C009', 1250000, 'No'),
('PMT020', 'S020', 'C010', 1460000, 'No'),
('PMT021', 'S021', 'C001', 1015000, 'No'),
('PMT022', 'S022', 'C002', 1560000, 'Yes'),
('PMT023', 'S023', 'C003', 1280000, 'No'),
('PMT024', 'S024', 'C004', 1125000, 'No'),
('PMT025', 'S025', 'C005', 1370000, 'Yes'),
('PMT026', 'S026', 'C006', 1490000, 'No'),
('PMT027', 'S027', 'C007', 1050000, 'No'),
('PMT028', 'S028', 'C008', 1570000, 'Yes'),
('PMT029', 'S029', 'C009', 1290000, 'No'),
('PMT030', 'S030', 'C010', 1500000, 'No')

SELECT * FROM PAYMENTS
INSERT INTO SCHEDULE
VALUES 
('SCH001', '2023-01-10', '2023-05-20', 'C001'),
('SCH002', '2023-01-15', '2023-06-01', 'C002'),
('SCH003', '2023-02-01', '2023-06-15', 'C003'),
('SCH004', '2023-02-05', '2023-06-20', 'C004'),
('SCH005', '2023-03-01', '2023-07-10', 'C005'),
('SCH006', '2023-03-10', '2023-07-20', 'C006'),
('SCH007', '2023-03-15', '2023-07-25', 'C007'),
('SCH008', '2023-04-01', '2023-08-10', 'C008'),
('SCH009', '2023-04-05', '2023-08-15', 'C009'),
('SCH010', '2023-04-10', '2023-08-20', 'C010')

SELECT * FROM SCHEDULE
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

SELECT * FROM MANAGERCLASS