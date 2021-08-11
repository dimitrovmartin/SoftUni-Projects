CREATE DATABASE Relations

USE Relations

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY IDENTITY (101,1),
	PassportNumber CHAR(8)
)

CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName CHAR(50),
	Salary DECIMAL(16,2),
	PassportID INT UNIQUE FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Passports
VALUES
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2')

INSERT INTO Persons
VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)


CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	EstablishedOn DATE NOT NULL
)

CREATE TABLE Models
(
	ModelID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	ManufacturerID INT REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers
VALUES
('BMW',	'07/03/1916'),
('Tesla',	'01/01/2003'),
('Lada',	'01/05/1966')

INSERT INTO Models
VALUES
('X1',	1	 ),
('i6',	1	 ),
('Model S',	2),
('Model X',	2),
('Model 3',	2),
('Nova',	3)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(50)
)

CREATE TABLE StudentsExams
(
	StudentID INT REFERENCES Students(StudentID),
	ExamID INT REFERENCES Exams(ExamID)

	CONSTRAINT PK_StudentID_ExamID PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO Students
VALUES
	('Mila'),                                      
	('Toni'),
	('Ron')

INSERT INTO Exams
VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

INSERT INTO StudentsExams
VALUES
	(1,	101),
	(1,	102),
	(2,	101),
	(3,	103),
	(2,	102),
	(2,	103)

CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(50),
	ManagerID INT REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers
VALUES
	('John',	NULL),
	('Maya',	106	),
	('Silvia',	106	),
	('Ted',		105	),
	('Mark',	101	),
	('Greta',	101	)

CREATE TABLE Cities
(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	Birthday DATE,
	CityID INT REFERENCES Cities(CityID)
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY IDENTITY, 
	[Name] VARCHAR(50),
	ItemTypeID INT REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems
(
	OrderID INT REFERENCES Orders(OrderID),
	ItemID INT REFERENCES Items(ItemID)

	CONSTRAINT PK_OrderID_ItemID PRIMARY KEY(OrderID, ItemID)
)

CREATE DATABASE UniversityDB

USE UniversityDB

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber INT NOT NULL,
	StudentName VARCHAR(50) NOT NULL,
	MajorID INT REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE,
	PaymentAmount DECIMAL (16,2),
	StudentID INT REFERENCES Students(StudentID)
)

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(50)
)

CREATE TABLE Agenda
(
	StudentID INT REFERENCES Students(StudentID),
	SubjectID INT REFERENCES Subjects(SubjectID)

	CONSTRAINT PK_StudentID_SubjectID PRIMARY KEY(StudentID, SubjectID)
)

USE Geography

Select MountainRange, PeakName,Elevation
FROM PEAKS
JOIN Mountains ON Peaks.MountainId = Mountains.Id
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC