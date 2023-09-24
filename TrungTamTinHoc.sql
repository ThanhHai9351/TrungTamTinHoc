create database TrungTamTinHoc

use TrungTamTinHoc
go

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

CREATE TABLE Courses (
    CourseID char(10) PRIMARY KEY,
    CourseName nvarchar(100),
    Description nvarchar(100),
    StartDate DATE,
    EndDate DATE,
    TeacherID char(10),
    FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID)
);

CREATE TABLE Enrollments (
    EnrollmentID char(10) PRIMARY KEY,
    StudentID char(10),
    CourseID char(10),
    EnrollmentDate DATE,
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Grades (
    GradeID char(10) PRIMARY KEY,
    StudentID char(10),
    CourseID char(10),
    Score FLOAT,
    GradeDate DATE,
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Classrooms (
    ClassroomId char(10) PRIMARY KEY,
    ClassroomName VARCHAR(50),
    Capacity INT,
    CourseID char(10),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);


INSERT INTO Student
VALUES 
('S0001', 'Nguyen', 'Van A', 'a.nguyen@example.com', '0123456789', '2000-01-01'),
('S0002', 'Tran', 'Van B', 'b.tran@example.com', '0123456790', '2001-02-02'),
('S0003', 'Le', 'Van C', 'c.le@example.com', '0123456781', '2002-03-03'),
('S0004', 'Pham', 'Van D', 'd.pham@example.com', '0123456782', '2003-04-04'),
('S0005', 'Hoang', 'Van E', 'e.hoang@example.com', '0123456783', '2004-05-05'),
('S0006', 'Doan', 'Van F', 'f.doan@example.com', '0123456784', '2000-06-06'),
('S0007', 'Vu', 'Van G', 'g.vu@example.com', '0123456785', '2001-07-07'),
('S0008', 'Dinh', 'Van H', 'h.dinh@example.com', '0123456786', '2002-08-08'),
('S0009', 'Duong', 'Van I', 'i.duong@example.com', '0123456787', '2003-09-09'),
('S0010', 'Ngo', 'Van J', 'j.ngo@example.com', '0123456788', '2004-10-10'),
('S0011', 'Phan', 'Van K', 'k.phan@example.com', '0123456789', '2005-11-11'),
('S0012', 'Truong', 'Van L', 'l.truong@example.com', '0123456790', '2006-12-12'),
('S0013', 'Le', 'Van M', 'm.le@example.com', '0123456791', '2007-01-01'),
('S0014', 'Nguyen', 'Van N', 'n.nguyen@example.com', '0123456792', '2008-02-02'),
('S0015', 'Tran', 'Van O', 'o.tran@example.com', '0123456793', '2009-03-03'),
('S0016', 'Bui', 'Van P', 'p.bui@example.com', '0123456794', '2010-04-04'),
('S0017', 'Vo', 'Van Q', 'q.vo@example.com', '0123456795', '2011-05-05'),
('S0018', 'Dang', 'Van R', 'r.dang@example.com', '0123456796', '2012-06-06'),
('S0019', 'Pham', 'Van S', 's.pham@example.com', '0123456797', '2013-07-07'),
('S0020', 'Ho', 'Van T', 't.ho@example.com', '0123456798', '2014-08-08'),
('S0021', 'Ly', 'Van U', 'u.ly@example.com', '0123456799', '2015-09-09'),
('S0022', 'Mai', 'Van V', 'v.mai@example.com', '0123456700', '2016-10-10'),
('S0023', 'Ta', 'Van W', 'w.ta@example.com', '0123456701', '2017-11-11'),
('S0024', 'Dao', 'Van X', 'x.dao@example.com', '0123456702', '2018-12-12'),
('S0025', 'Diep', 'Van Y', 'y.diep@example.com', '0123456703', '2019-01-01'),
('S0026', 'Chu', 'Van Z', 'z.chu@example.com', '0123456704', '2020-02-02'),
('S0027', 'Thach', 'Van AA', 'aa.thach@example.com', '0123456705', '2021-03-03'),
('S0028', 'Kieu', 'Van AB', 'ab.kieu@example.com', '0123456706', '2021-04-04'),
('S0029', 'Tang', 'Van AC', 'ac.tang@example.com', '0123456707', '2021-05-05'),
('S0030', 'Do', 'Van AD', 'ad.do@example.com', '0123456708', '2021-06-06'),
('S0031', 'Le', 'Van AE', 'ae.le@example.com', '0123456709', '2021-07-07'),
('S0032', 'Vinh', 'Van AF', 'af.vinh@example.com', '0123456710', '2021-08-08'),
('S0033', 'Thai', 'Van AG', 'ag.thai@example.com', '0123456711', '2021-09-09'),
('S0034', 'Quang', 'Van AH', 'ah.quang@example.com', '0123456712', '2021-10-10'),
('S0035', 'Ha', 'Van AI', 'ai.ha@example.com', '0123456713', '2021-11-11');


INSERT INTO Teacher
VALUES
('T0001', 'Vu', 'Thi A', 'a.vu@example.com', '0213456789', '1980-01-01'),
('T0002', 'Do', 'Thi B', 'b.do@example.com', '0213456790', '1981-02-02'),
('T0003', 'Bui', 'Thi C', 'c.bui@example.com', '0213456781', '1982-03-03'),
('T0004', 'Ly', 'Thi D', 'd.ly@example.com', '0213456782', '1983-04-04'),
('T0005', 'Truong', 'Thi E', 'e.truong@example.com', '0213456783', '1984-05-05'),
('T0006', 'Dang', 'Thi F', 'f.dang@example.com', '0213456784', '1985-06-06'),
('T0007', 'Nguyen', 'Thi G', 'g.nguyen@example.com', '0213456785', '1986-07-07'),
('T0008', 'Tran', 'Thi H', 'h.tran@example.com', '0213456786', '1987-08-08'),
('T0009', 'Le', 'Thi I', 'i.le@example.com', '0213456787', '1988-09-09'),
('T0010', 'Pham', 'Thi J', 'j.pham@example.com', '0213456788', '1989-10-10');


INSERT INTO Courses 
VALUES
('C0001', 'Lap Trinh C', 'Khoa hoc lap trinh C co ban', '2023-01-01', '2023-03-01', 'T0001'),
('C0002', 'Lap Trinh Java', 'Khoa hoc lap trinh Java co ban', '2023-02-01', '2023-04-01', 'T0002'),
('C0003', 'Lap Trinh Python', 'Khoa hoc lap trinh Python co ban', '2023-03-01', '2023-05-01', 'T0003'),
('C0004', 'Lap Trinh PHP', 'Khoa hoc lap trinh PHP co ban', '2023-04-01', '2023-06-01', 'T0004'),
('C0005', 'Lap Trinh JavaScript', 'Khoa hoc lap trinh JavaScript co ban', '2023-05-01', '2023-07-01', 'T0005');

INSERT INTO Enrollments 
VALUES
('E0001', 'S0001', 'C0001', '2023-01-01'),
('E0002', 'S0002', 'C0002', '2023-02-01'),
('E0003', 'S0003', 'C0003', '2023-03-01'),
('E0004', 'S0004', 'C0004', '2023-04-01'),
('E0005', 'S0005', 'C0005', '2023-05-01');

INSERT INTO Grades
VALUES
('G0001', 'S0001', 'C0001', 9.5, '2023-03-01'),
('G0002', 'S0002', 'C0002', 8.5, '2023-04-01'),
('G0003', 'S0003', 'C0003', 7.5, '2023-05-01'),
('G0004', 'S0004', 'C0004', 6.5, '2023-06-01'),
('G0005', 'S0005', 'C0005', 5.5, '2023-07-01');

INSERT INTO Classrooms 
VALUES
('CL001', 'Phong A', 30, 'C0001'),
('CL002', 'Phong B', 25, 'C0002'),
('CL003', 'Phong C', 20, 'C0003'),
('CL004', 'Phong D', 15, 'C0004'),
('CL005', 'Phong E', 10, 'C0005');


