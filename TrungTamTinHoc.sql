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
    ClassroomName VARCHAR(50),
    Capacity INT,
    TeacherID char(10) not null,
    AmountOfMoney money,
    FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID),
);
CREATE TABLE AccountStudents(
	AccountStudentsID char(10) PRIMARY KEY,
	StudentID char(10) not null,
	Passwd char(10) not null,
	FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
)
CREATE TABLE AccountTeachers(
	AccountTeachersID char(10) PRIMARY KEY,
	Passwd char(10) not null,
	TeacherID char(10) not null,
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

CREATE TRIGGER trg_UpdateCapacity
ON MANAGERCLASS
AFTER INSERT, DELETE
AS
BEGIN
    DECLARE @InsertedClassroomId char(10);
    SELECT @InsertedClassroomId = ClassroomId FROM INSERTED;
    IF @InsertedClassroomId IS NOT NULL
    BEGIN
        UPDATE Classrooms 
        SET Capacity = Capacity + 1 
        WHERE ClassroomId = @InsertedClassroomId;
    END

    DECLARE @DeletedClassroomId char(10);
    SELECT @DeletedClassroomId = ClassroomId FROM DELETED;
    IF @DeletedClassroomId IS NOT NULL
    BEGIN
        UPDATE Classrooms 
        SET Capacity = Capacity - 1 
        WHERE ClassroomId = @DeletedClassroomId;
    END
END;

INSERT INTO Student 
VALUES 
('S001', 'Ng?c', 'Tr?n', 'ngoc.tran01@email.com.vn', '9876543210', 500.00, '2000-03-15'),
('S002', 'D?ng', 'Nguy?n', 'dung.nguyen02@email.com.vn', '9876543211', 300.00, '2002-04-20'),
('S003', 'H??ng', 'Lê', 'huong.le03@email.com.vn', '9876543212', 0.00, '1999-05-10'),
('S004', 'Phát', '??ng', 'phat.dang04@email.com.vn', '9876543213', 250.00, '2003-06-12'),
('S005', 'Th?o', 'Ph?m', 'thao.pham05@email.com.vn', '9876543214', 0.00, '2001-07-18'),
('S006', 'Bình', 'Võ', 'binh.vo06@email.com.vn', '9876543215', 100.00, '1998-08-25'),
('S007', 'Lan', 'H?', 'lan.ho07@email.com.vn', '9876543216', 0.00, '2002-09-19'),
('S008', 'Khang', 'Bùi', 'khang.bui08@email.com.vn', '9876543217', 450.00, '2000-11-23'),
('S009', 'Mai', 'L??ng', 'mai.luong09@email.com.vn', '9876543218', 600.00, '1997-01-14'),
('S010', 'Vi?t', 'Chu', 'viet.chu10@email.com.vn', '9876543219', 0.00, '1999-02-28'),
('S011', 'Thu', 'D??ng', 'thu.duong11@email.com.vn', '9876543220', 430.00, '2002-01-15'),
('S012', 'Khiêm', '??', 'khiem.do12@email.com.vn', '9876543221', 250.00, '2001-05-09'),
('S013', 'Chi', 'Lý', 'chi.ly13@email.com.vn', '9876543222', 120.00, '2000-06-13'),
('S014', 'Nga', 'Ngô', 'nga.ngo14@email.com.vn', '9876543223', 350.00, '2002-08-21'),
('S015', 'Hào', 'V??ng', 'hao.vuong15@email.com.vn', '9876543224', 0.00, '1999-12-05'),
('S016', 'Trang', 'Cao', 'trang.cao16@email.com.vn', '9876543225', 500.00, '2001-11-29'),
('S017', 'H?i', 'Mã', 'hai.ma17@email.com.vn', '9876543226', 270.00, '2003-02-20'),
('S018', 'Tuy?t', '?inh', 'tuyet.dinh18@email.com.vn', '9876543227', 0.00, '2002-10-27'),
('S019', 'Duy', 'Phùng', 'duy.phung19@email.com.vn', '9876543228', 120.00, '1998-09-11'),
('S020', 'Th?y', 'Hà', 'thuy.ha20@email.com.vn', '9876543229', 300.00, '2000-03-23'),
('S021', 'Lâm', 'La', 'lam.la21@email.com.vn', '9876543230', 480.00, '2001-04-04'),
('S022', 'Tâm', 'Kh??ng', 'tam.khuong22@email.com.vn', '9876543231', 0.00, '1997-05-15'),
('S023', 'Phong', 'Phan', 'phong.phan23@email.com.vn', '9876543232', 290.00, '2002-07-07'),
('S024', 'M?', '?ào', 'my.dao24@email.com.vn', '9876543233', 130.00, '1999-08-16'),
('S025', 'Quang', 'H?a', 'quang.hua25@email.com.vn', '9876543234', 0.00, '2003-11-12'),
('S026', 'Nguyên', 'B?ch', 'nguyen.bach26@email.com.vn', '9876543235', 540.00, '2002-09-21'),
('S027', 'Y?n', 'Chung', 'yen.chung27@email.com.vn', '9876543236', 600.00, '2000-10-30'),
('S028', 'S?n', 'L?c', 'son.luc28@email.com.vn', '9876543237', 0.00, '1998-12-10'),
('S029', 'Thanh', 'Yên', 'thanh.yen29@email.com.vn', '9876543238', 210.00, '1999-01-20'),
('S030', 'Nhi', 'Nguy?n', 'nhi.nguyen30@email.com.vn', '9876543239', 320.00, '2001-02-22')

INSERT INTO Teacher 
VALUES 
('T001', 'H?i', 'Nguy?n', 'hai.nguyen01@email.com.vn', '0123456789', '1985-03-15'),
('T002', 'Lan', 'Ph?m', 'lan.pham02@email.com.vn', '0123456790', '1982-04-20'),
('T003', 'Nam', 'Lê', 'nam.le03@email.com.vn', '0123456791', '1986-05-10'),
('T004', 'Ph??ng', '??ng', 'phuong.dang04@email.com.vn', '0123456792', '1980-06-12'),
('T005', 'Tùng', 'Tr?n', 'tung.tran05@email.com.vn', '0123456793', '1984-07-18'),
('T006', 'H??ng', 'Võ', 'huong.vo06@email.com.vn', '0123456794', '1983-08-25'),
('T007', 'B?o', 'H?', 'bao.ho07@email.com.vn', '0123456795', '1981-09-19'),
('T008', 'Th?o', 'Bùi', 'thao.bui08@email.com.vn', '0123456796', '1982-11-23'),
('T009', 'S?n', 'L??ng', 'son.luong09@email.com.vn', '0123456797', '1987-01-14'),
('T010', 'Mai', 'Chu', 'mai.chu10@email.com.vn', '0123456798', '1983-02-28')

INSERT INTO Classrooms
VALUES 
('C001', 'L?p trình C# c?n b?n', 0, 'T001', 5000000),
('C002', 'Thi?t k? giao di?n web', 0, 'T002', 5500000),
('C003', 'L?p trình Java', 0, 'T003', 5300000),
('C004', 'Qu?n tr? c? s? d? li?u', 0, 'T004', 6000000),
('C005', 'L?p trình Python', 0, 'T005', 4800000),
('C006', 'Phân tích thi?t k? h? th?ng', 0, 'T006', 6500000),
('C007', 'L?p trình web PHP', 0, 'T007', 5100000),
('C008', 'L?p trình Android', 0, 'T008', 5800000),
('C009', 'Thi?t k? ?? h?a', 0, 'T009', 5200000),
('C010', 'K? thu?t l?p trình', 0, 'T010', 5400000)

INSERT INTO AccountStudents
VALUES 
('A001', 'S001', 'mk10'),
('A002', 'S002', 'mk10'),
('A003', 'S003', 'mk10'),
('A004', 'S004', 'mk10'),
('A005', 'S005', 'mk10'),
('A006', 'S006', 'mk10'),
('A007', 'S007', 'mk10'),
('A008', 'S008', 'mk10'),
('A009', 'S009', 'mk10'),
('A010', 'S010', 'mk10'),
('A011', 'S011', 'mk10'),
('A012', 'S012', 'mk10'),
('A013', 'S013', 'mk10'),
('A014', 'S014', 'mk10'),
('A015', 'S015', 'mk10'),
('A016', 'S016', 'mk10'),
('A017', 'S017', 'mk10'),
('A018', 'S018', 'mk10'),
('A019', 'S019', 'mk10'),
('A020', 'S020', 'mk10'),
('A021', 'S021', 'mk10'),
('A022', 'S022', 'mk10'),
('A023', 'S023', 'mk10'),
('A024', 'S024', 'mk10'),
('A025', 'S025', 'mk10'),
('A026', 'S026', 'mk10'),
('A027', 'S027', 'mk10'),
('A028', 'S028', 'mk10'),
('A029', 'S029', 'mk10'),
('A030', 'S030', 'mk10')

INSERT INTO AccountTeachers
VALUES 
('AT001', 'T001', 'mk01'),
('AT002', 'T002', 'mk02'),
('AT003', 'T003', 'mk03'),
('AT004', 'T004', 'mk04'),
('AT005', 'T005', 'mk05'),
('AT006', 'T006', 'mk06'),
('AT007', 'T007', 'mk07'),
('AT008', 'T008', 'mk08'),
('AT009', 'T009', 'mk09'),
('AT010', 'T010', 'mk10')

INSERT INTO PAYMENTS
VALUES 
('PMT001', 'S001', 'C001', 1000000, No),
('PMT002', 'S002', 'C002', 1500000, No),
('PMT003', 'S003', 'C003', 1200000, Yes),
('PMT004', 'S004', 'C004', 1100000, No),
('PMT005', 'S005', 'C005', 1300000, No),
('PMT006', 'S006', 'C006', 1400000, No),
('PMT007', 'S007', 'C007', 1000000, Yes),
('PMT008', 'S008', 'C008', 1500000, No),
('PMT009', 'S009', 'C009', 1200000, No),
('PMT010', 'S010', 'C010', 1400000, Yes),
('PMT011', 'S011', 'C001', 1005000, No),
('PMT012', 'S012', 'C002', 1550000, No),
('PMT013', 'S013', 'C003', 1230000, No),
('PMT014', 'S014', 'C004', 1105000, No),
('PMT015', 'S015', 'C005', 1340000, Yes),
('PMT016', 'S016', 'C006', 1450000, No),
('PMT017', 'S017', 'C007', 1010000, No),
('PMT018', 'S018', 'C008', 1520000, Yes),
('PMT019', 'S019', 'C009', 1250000, No),
('PMT020', 'S020', 'C010', 1460000, No),
('PMT021', 'S021', 'C001', 1015000, No),
('PMT022', 'S022', 'C002', 1560000, Yes),
('PMT023', 'S023', 'C003', 1280000, No),
('PMT024', 'S024', 'C004', 1125000, No),
('PMT025', 'S025', 'C005', 1370000, Yes),
('PMT026', 'S026', 'C006', 1490000, No),
('PMT027', 'S027', 'C007', 1050000, No),
('PMT028', 'S028', 'C008', 1570000, Yes),
('PMT029', 'S029', 'C009', 1290000, No),
('PMT030', 'S030', 'C010', 1500000, No)

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

INSERT INTO MANAGERCLASS
(StudentID, ClassroomId, TeacherID)
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
