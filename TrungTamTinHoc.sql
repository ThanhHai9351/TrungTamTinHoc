create database TrungTamTinHoc

use TrungTamTinHoc
go

create table Student (
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
    Description_ nvarchar(100),
    StartDate DATE,
    EndDate DATE
);

create table Teacher 
(
	TeacherID char(10) primary key,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Email VARCHAR(100),
    Phone VARCHAR(20),
	Birthday DATE
);

CREATE TABLE Enrollments (
    EnrollmentID char(10) PRIMARY KEY,
    StudentID char(10),
    CourseID char(10),
	TeacherID char(10),
    EnrollmentDate DATE,
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID)
);



