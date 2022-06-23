--Problem 1. Create Database

CREATE DATABASE [Minions]

--Problem 2. Create Tables

CREATE TABLE [Minions](
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT
)

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

--Problem 3. Alter Minions Table

ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])

--Problem 4. Insert Records in Both Tables

INSERT INTO [Towns]([Id],[Name])
	VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO [Minions]([Id],[Name],[Age],[TownId])
VALUES
(1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',NULL,2)

--Problem 5. Truncate Table Minions

TRUNCATE TABLE [Minions]

--Problem 6. Drop All Tables

DROP TABLE [Minions]
DROP TABLE [Towns]

--Problem 7. Create Table People

CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX)
	CHECK(DATALENGTH([Picture]) < 2000000),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1)
	CHECK([Gender]='m' OR [Gender]='f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name],[Picture],[Height],[Weight],[Gender],[Birthdate],[Biography])
VALUES 
('A',NULL,1.95,105.25,'m','1995-01-01','A1'),
('B',NULL,1.96,105.26,'f','1996-01-01','B2'),
('C',NULL,1.97,105.27,'f','1997-01-01','C3'),
('D',NULL,1.98,105.28,'m','1998-01-01','D4'),
('E',NULL,1.99,105.29,'m','1999-01-01','E5')

--Problem 8. Create Table Users

CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX)
	CHECK(DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT NOT NULL
)

INSERT INTO [Users]([Username],[Password],[ProfilePicture],[LastLoginTime],[IsDeleted])
VALUES 
('A','12300',NULL,'2022-01-01',1),
('B','1234',NULL,'2023-01-01',0),
('C','1235',NULL,'2024-01-01',1),
('D','1236',NULL,'2025-01-01',0),
('E','1237',NULL,'2026-01-01',1)

--Problem 9. Change Primary Key

TRUNCATE TABLE [Users]

ALTER TABLE [Users]
DROP PK_Users_Id

ALTER TABLE [Users]
ADD PRIMARY KEY ([Id],[Username])

--Problem 10. Add Check Constraint

TRUNCATE TABLE [Users]

ALTER TABLE [Users] 
ADD CONSTRAINT CK_Password CHECK(LEN([Password]) >= 5)

INSERT INTO [Users]([Username],[Password],[ProfilePicture],[LastLoginTime],[IsDeleted])
VALUES 
('A','12300',NULL,'2022-01-01',1),
('B','12340',NULL,'2023-01-01',0),
('C','12350',NULL,'2024-01-01',1),
('D','12360',NULL,'2025-01-01',0),
('E','12370',NULL,'2026-01-01',1)

--Problem 11. Set Default Value of a Field

ALTER TABLE [Users]
ADD CONSTRAINT DF_Users DEFAULT GETDATE() FOR [LastLoginTime]

--Problem 12. Set Unique Field

ALTER TABLE [Users]
DROP PK__Users__7722245991152C01
ALTER TABLE [Users]
ADD CONSTRAINT PK_Users_Id PRIMARY KEY ([Id])
ALTER TABLE [Users]
ADD CONSTRAINT UC_Users_Username UNIQUE ([Username])
ALTER TABLE [Users] 
ADD CONSTRAINT CK_Users CHECK(LEN([Username]) >= 3)

--Problem 13. Movies Database

CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Directors]([DirectorName],[Notes])
VALUES
('A','123'),
('B','1234'),
('C','1235'),
('D','1236'),
('E','1237')

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Genres]([GenreName],[Notes])
VALUES
('Action','123'),
('Comedy','1234'),
('Drama','1235'),
('Horror','1236'),
('Animation','1237')

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Categories]([CategoryName],[Notes])
VALUES
('Action Films','123'),
('Comedy Films','1234'),
('Drama Films','1235'),
('Horror Films','1236'),
('Animation Films','1237')

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT NOT NULL FOREIGN KEY REFERENCES [Directors]([Id]),
	[CopyrightYear] DATETIME2,
	[Lenght] VARCHAR(15),
	[GenreId] INT NOT NULL FOREIGN KEY REFERENCES [Genres]([Id]),
	[CategoryId] INT NOT NULL FOREIGN KEY REFERENCES [Categories]([Id]),
	[Rating] INT,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Movies]([Title],[DirectorId],[CopyrightYear],[Lenght],[GenreId],[CategoryId],[Rating],[Notes])
VALUES
('GGG','1','1985-01-01','03:05:18','1','5','10','123'),
('TTTT','5','1986-01-01','08:05:18','5','1','9','1234'),
('YYY','3','1987-01-01','05:05:18','3','2','1','1238'),
('RRR','1','1983-01-01','09:05:18','2','4','10','1239'),
('EEE','2','1984-01-01','08:05:18','5','5','8','1230')

--Problem 14. Car Rental Database

CREATE DATABASE [CarRental]

USE [CarRental]

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[DailyRate] DECIMAL(10,2) NOT NULL,
	[WeeklyRate] DECIMAL(10,2) NOT NULL,
	[WeekendRate] DECIMAL(10,2) NOT NULL,
)

INSERT INTO [Categories]([CategoryName],[DailyRate],[WeeklyRate],[WeekendRate])
VALUES
('Car',15.25,100.23,52.89),
('Motor',5.25,10.23,5.89),
('Bus',105.25,1500.23,152.89)

CREATE TABLE [Cars](
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] NVARCHAR(50) NOT NULL,
	[Manufacturer] NVARCHAR(50) NOT NULL,
	[Model] NVARCHAR(50) NOT NULL,
	[CarYear] VARCHAR(4) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
	[Doors] VARCHAR(1) NOT NULL,
	[Picture] VARBINARY(MAX)
	CHECK(DATALENGTH([Picture]) < 900000),
	[Condition] VARCHAR(5),
	[Available] BIT NOT NULL
)

INSERT INTO [Cars]([PlateNumber],[Manufacturer],[Model],[CarYear],[CategoryId],[Doors],[Picture],[Condition],[Available])
VALUES
('В2843АП','Хонда','Сивик','1994',1,'2',NULL,'old',1),
('H2843АП','Reno','Scenic','2022',1,'5',NULL,'new',1),
('В2943АП','Reno','Master','2000',3,'3',NULL,'old',0)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(10),
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees]([FirstName],[LastName],[Title],[Notes])
VALUES
('Ivo','Iliev','Mr','ttttttt'),
('Ivo1','Iliev2','Ms','tttttyyyytttt'),
('Ivo2','Iliev3','Miss','ttttuuuttt')

CREATE TABLE [Customers](
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] VARCHAR(15) NOT NULL,
	[FullName] NVARCHAR(100) NOT NULL,
	[Address] NVARCHAR(50),
	[City] NVARCHAR(50),
	[ZIPCode] VARCHAR(10),
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Customers]([DriverLicenceNumber],[FullName],[Address],[City],[ZIPCode],[Notes])
VALUES
('85463','Ivo Iliev','58','Varna','9000','898'),
('854653','Ivo Iliev2','55555','Varna1','9002','85558'),
('854763','Ivo Iliev4','59999','Varna3','9001','896668'),

CREATE TABLE [RentalOrders](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT NOT NULL FOREIGN KEY REFERENCES [Employees]([Id]),
	[CustomerId] INT NOT NULL FOREIGN KEY REFERENCES [Customers]([Id]),
	[CarId] INT NOT NULL FOREIGN KEY REFERENCES [Cars]([Id]),
	[TankLevel] DECIMAL(6,2),
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL 
	CHECK([KilometrageEnd] > [KilometrageStart]),
	[TotalKilometrage] INT NOT NULL
	CHECK([TotalKilometrage] = [KilometrageEnd]-[KilometrageStart]),
	[StartDate] DATE,
	[EndDate] DATE,
	[TotalDays] INT NOT NULL
	CHECK([TotalDays] = DATEDIFF(DAY,[EndDate],[StartDate]),
	[RateApplied] VARCHAR(10),
	[TaxRate] DECIMAL(4,2),
	[OrderStatus] VARCHAR(10),
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [RentalOrders]([EmployeeId],[CustomerId],[CarId],[TankLevel],[KilometrageStart],[KilometrageEnd],[TotalKilometrage],[StartDate],[EndDate],[TotalDays],[RateApplied],[TaxRate],[OrderStatus],[Notes])
VALUES
(1,2,3,60.58,100525,100625,100,'1955-01-01','1955-01-03',2,'1',15.25,'processing','585'),
(3,1,1,61.58,100585,100685,100,'1956-01-01','1956-01-03',2,'3',16.25,'use','5885'),
(2,3,2,62.58,100565,100675,110,'1957-01-01','1957-01-03',2,'2',18.25,'yyyy','5985')

--Problem 15. Hotel Database

CREATE DATABASE [Hotel]

USE [Hotel]

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees]([FirstName],[LastName],[Title],[Notes])
VALUES 
('Ivo','Iliev','Mr','123'),
('Ivo1','Iliev1','Mr2','1234'),
('Ivo2','Iliev2','Mr1','1235')

CREATE TABLE [Customers](
	[AccountNumber] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[PhoneNumber] VARCHAR(15),
	[EmergencyName] NVARCHAR(15),
	[EmergencyNumber] INT,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Customers]([FirstName],[LastName],[PhoneNumber],[EmergencyName],[EmergencyNumber],[Notes])
VALUES 
('1','2','0885065945','01',112,'555'),
('2','3','08850659485','02',113,'5555'),
('4','5','08850659495','03',114,'5655')

CREATE TABLE [RoomStatus](
	[RoomStatus] NVARCHAR(50) PRIMARY KEY,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO[RoomStatus]([RoomStatus],[Notes])
VALUES
('Avaylable','5'),
('Not Avaylable','7'),
('InProgress','6')

CREATE TABLE [RoomTypes](
	[RoomType] NVARCHAR(50) PRIMARY KEY,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO[RoomTypes]([RoomType],[Notes])
VALUES
('Double','7'),
('Apartment','0'),
('One','1')

CREATE TABLE [BedTypes](
	[BedType] NVARCHAR(50) PRIMARY KEY,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO[BedTypes]([BedType],[Notes])
VALUES
('Doubles','7'),
('King','0'),
('Queen','1')

CREATE TABLE [Rooms](
	[RoomNumber] INT PRIMARY KEY IDENTITY,
	[RoomType] NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES [RoomTypes]([RoomType]),
	[BedType] NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES [BedTypes]([BedType]),
	[Rate] VARCHAR(5),
	[RoomStatus] NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]),
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Rooms]([RoomType],[BedType],[Rate],[RoomStatus],[Notes])
VALUES
('Double','King','av','Avaylable','15'),
('Apartment','Doubles','av','Avaylable','15'),
('One','Queen','av','Avaylable','15')

CREATE TABLE [Payments](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT NOT NULL FOREIGN KEY REFERENCES [Employees]([Id]),
	[PaymentDate] DATETIME2,
	[AccountNumber] INT NOT NULL FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
	[FirstDateOccupied] DATE,
	[LastDateOccupied] DATE,
	[TotalDays] INT
	CHECK([TotalDays] = (DATEDIFF(DAY,[LastDateOccupied],[FirstDateOccupied]))),
	[AmountCharged] DECIMAL(10,2),
	[TaxRate] DECIMAL(4,2),
	[TaxAmount] DECIMAL(10,2)
	CHECK([TaxAmount] = [AmountCharged] * [TaxRate]),
	[PaymentTotal] DECIMAL(10,2)
	CHECK([PaymentTotal] = [AmountCharged] + [TaxAmount]),
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Payments]([EmployeeId],[PaymentDate],[AccountNumber],[FirstDateOccupied],[LastDateOccupied],[TotalDays],[AmountCharged],[TaxRate],[TaxAmount],[PaymentTotal],[Notes])
VALUES
(1,'1995-01-01',1,'1995-01-01','1995-01-01',0,15.25,20.00,155.00,165.23,'222'),
(2,'1996-01-01',1,'1996-01-01','1996-01-01',0,16.25,22.00,165.00,175.23,'322'),
(3,'1997-01-01',1,'1996-01-01','1996-01-01',0,17.25,21.00,175.00,185.23,'522')

CREATE TABLE [Occupancies](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT NOT NULL FOREIGN KEY REFERENCES [Employees]([Id]),
	[DateOccupied] DATETIME2,
	[AccountNumber] INT NOT NULL FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
	[RoomNumber] INT NOT NULL FOREIGN KEY REFERENCES [Rooms]([RoomNumber]),
	[RateApplied] VARCHAR(10),
	[PhoneCharge] DECIMAL(10,2),
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Occupancies]([EmployeeId],[DateOccupied],[AccountNumber],[RoomNumber],[RateApplied],[PhoneCharge],[Notes])
VALUES
('1','1995-01-01','1','2','5',15.25,'ppp'),
('3','1996-01-01','2','3','5',15.36,'pipp'),
('2','1997-01-01','3','1','5',15.75,'popp')

--Problem 16. Create SoftUni Database

CREATE DATABASE [SoftUni]

USE [SoftUni]

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Addressess](
	[Id] INT PRIMARY KEY IDENTITY,
	[AddressText] NVARCHAR(50) NOT NULL,
	[TownId] INT NOT NULL FOREIGN KEY REFERENCES [Towns]([Id])
)

CREATE TABLE [Departments](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[MiddleName] NVARCHAR(50),
	[LastName] NVARCHAR(50) NOT NULL,
	[JobTitle] NVARCHAR(50),
	[DepartmentId] INT NOT NULL FOREIGN KEY REFERENCES [Departments]([Id]),
	[HireDate] DATETIME2,
	[Salary] DECIMAL(10,2),
	[AddressId] INT NOT NULL FOREIGN KEY REFERENCES [Addressess]([Id])
)

--Problem 17. Backup Database

BACKUP DATABASE [SoftUni] TO DISK = 'D:\softuni-backup.bak'

USE [CarRental]

DROP DATABASE [SoftUni]

RESTORE DATABASE [SoftUni] FROM DISK = 'D:\softuni-backup.bak'

--Problem 18. Basic Insert

USE [SoftUni]

INSERT INTO [Towns]([Name])
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO [Departments]([Name])
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO [Employees]([FirstName],[MiddleName],[LastName],[JobTitle],[DepartmentId],[HireDate],[Salary],[AddressId])
VALUES
('Ivan','Ivanov','Ivanov','.NET Developer',4,'02-01-2013',3500.00,1),
('Petar','Petrov','Petrov','Senior Engineer',1,'03-02-2004',4000.00,3),
('Maria','Petrova','Ivanova','Intern',5,'08-28-2016',525.25,4),
('Georgi','Terziev','Ivanov','CEO',2,'12-09-2007',3000.00,1),
('Peter','Pan','Pan','Intern',3,'08-28-2016',599.88,2)

--Problem 19. Basic Select All Fields

SELECT 
	* 
	FROM[Towns]

SELECT 
	* 
	FROM[Departments]

SELECT 
	* 
	FROM[Employees]

--Problem 20. Basic Select All Fields and Order Them

SELECT 
	*
	FROM [Towns]
	ORDER BY [Name] ASC

SELECT 
	*
	FROM [Departments]
	ORDER BY [Name] ASC

SELECT 
	*
	FROM [Employees]
	ORDER BY [Salary] DESC

--Problem 21. Basic Select Some Fields

SELECT 
	[Name]
	FROM [Towns]
	ORDER BY [Name] ASC

SELECT 
	[Name]
	FROM [Departments]
	ORDER BY [Name] ASC

SELECT 
	[FirstName],
	[LastName],
	[JobTitle],
	[Salary]
	FROM [Employees]
	ORDER BY [Salary] DESC

--Problem 22. Increase Employees Salary

UPDATE [Employees] 
	SET [Salary] = [Salary]*1.1

SELECT
	[Salary]
	FROM[Employees]
	
--Problem 23.Decrease Tax Rate

USE [Hotel]

UPDATE [Payments]
	SET[TaxRate]=[TaxRate]*0.97

SELECT
	[TaxRate]
	FROM[Payments]

--Problem 24. Delete All Records

TRUNCATE TABLE[Occupancies]