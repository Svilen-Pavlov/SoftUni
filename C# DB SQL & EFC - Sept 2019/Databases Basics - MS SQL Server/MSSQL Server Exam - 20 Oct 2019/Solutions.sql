-- 01. DDL

Create Table Users
(
Id INT PRIMARY KEY IDENTITY
,[Username] NVARCHAR(30) NOT NULL UNIQUE
,[Password] NVARCHAR(50) NOT NULL
,[Name] NVARCHAR(50) 
,[Birthdate] DATETIME 
,[Age] INT CHECK ([Age] >=14 AND [Age]<=110)--NULL ili NOT NULL
,[Email] NVARCHAR(50) NOT NULL
)

Create Table Departments
(
Id INT PRIMARY KEY IDENTITY
,[Name] NVARCHAR(50)  NOT NULL
)

Create Table Employees
(
Id INT PRIMARY KEY IDENTITY
,[FirstName] NVARCHAR(25) 
,[LastName] NVARCHAR(25) 
,[Birthdate] DATETIME
,[Age] INT CHECK ([Age] >=18 AND [Age]<=110)--NULL ili NOT NULL
,[DepartmentId] INT FOREIGN KEY REFERENCES [Departments](Id)
)

Create Table Categories
(
Id INT PRIMARY KEY IDENTITY
,[Name] NVARCHAR(50) NOT NULL
,[DepartmentId] INT FOREIGN KEY REFERENCES [Departments](Id) NOT NULL
)
Create Table Status
(
Id INT PRIMARY KEY IDENTITY
,[Label] NVARCHAR(30) NOT NULL
)

Create Table Reports
(
Id INT PRIMARY KEY IDENTITY
,[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL
,[StatusId] INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL
,[OpenDate] DATETIME NOT NULL
,[CloseDate] DATETIME
,[Description] NVARCHAR(200) NOT NULL
,[UserId] INT FOREIGN KEY REFERENCES [Users](Id) NOT NULL
,[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) 
)


-- 02. Insert

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId) VALUES
('Marlo','O''Malley','1958-9-21',1) --date taka li se insertva
,('Niki','Stanaghan','1969-11-26',4)
,('Ayrton','Senna','1960-03-21',9)
,('Ronnie','Peterson','1944-02-14',9)
,('Giovanna','Amati','1959-07-20',5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description],UserId,EmployeeId) VALUES
(1,1,'2017-04-13',NULL,'Stuck Road on Str.133',6,2)
,(6,3,'2015-09-05','2015-12-06','Charity trail running',3,5)
,(14,2,'2015-09-07',NULL,'Falling bricks on Str.58',5,2)
,(4,3,'2017-07-03','2017-07-06','Cut off streetlight on Str.11',1,1)


-- 03. Update

UPDATE Reports
SET [CloseDate]=GETDATE()
WHERE [CloseDate] IS NULL


-- 04. Delete

DELETE FROM Reports
WHERE [StatusId]=4


-- 05. Unassigned Reports

SELECT Description, FORMAT (OpenDate,'dd-MM-yyyy') as OpenDate
FROM Reports R
WHERE EmployeeId IS NULL
ORDER BY R.OpenDate ASC,Description ASC


-- 06. Reports & Categories

SELECT [Description],c.[Name]
FROM Reports R
JOIN Categories c ON r.CategoryId=c.Id
WHERE r.CategoryId IS NOT NULL
ORDER BY r.Description ASC, c.[Name] ASC


-- 07. Most Reported Category

SELECT TOP(5) c.[Name] as CategoryName, COUNT (r.CategoryId) as ReportsNumber
FROM Reports r
JOIN Categories c ON r.CategoryId=c.Id
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC,CategoryName ASC


-- 08. Birthday Report

SELECT u.Username,c.[Name] as CategoryName
FROM Reports r
JOIN Users u ON r.UserId=u.Id
JOIN Categories c ON r.CategoryId=c.Id
WHERE DATEPART(Day,u.Birthdate)=DATEPART(Day,r.OpenDate)
ORDER BY u.Username ASC,CategoryName ASC


-- 09. User per Employee

SELECT e.FirstName+' '+e.LastName as [FullName]
	   , COUNT(DISTINCT u.Id) as [UsersCount]
FROM Employees e

LEFT JOIN Reports r ON r.EmployeeId=e.Id
LEFT JOIN Users u ON u.Id=r.UserId
GROUP BY e.FirstName,e.LastName
ORDER BY UsersCount DESC,FullName ASC


-- 10. Full Info

SELECT 
ISNULL(e.FirstName+' '+e.LastName ,'None') as [Employee]
,ISNULL(d.Name,'None') as [Department]
,ISNULL(c.Name,'None') as [Category]
,ISNULL(r.Description,'None') as [Description]
,FORMAT (r.OpenDate,'dd.MM.yyyy') as [OpenDate]
,ISNULL(s.Label,'None') as [Status]
,ISNULL(u.[Name],'None') as [User]

FROM Reports r
LEFT JOIN Categories c ON c.Id=r.CategoryId
LEFT JOIN Employees e ON r.EmployeeId=e.Id
LEFT JOIN Departments d ON d.Id=e.DepartmentId

JOIN [Status] s ON s.Id=r.StatusId
JOIN Users u ON u.Id=r.UserId
ORDER BY e.FirstName DESC,e.LastName DESC,Category ASC, [Description] ASC
,OpenDate ASC, [Status] ASC, u.[Name] ASC


-- 11. Hours to Complete

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS BEGIN
DECLARE @RESULT INT = 99999

IF (@StartDate IS NULL OR @EndDate IS NULL)
BEGIN
SET @RESULT=0
END
ELSE
BEGIN
Set @RESULT= DATEDIFF(HOUR,@StartDate,@EndDate);
END
RETURN @RESULT
END


-- 12. Assign Employee

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN TRAN

DECLARE @EmpDept INT=(SELECT DepartmentId FROM Employees WHERE Id=@EmployeeId)
DECLARE @RepCat INT =
(SELECT d.Id
FROM Reports r
JOIN Categories c ON r.CategoryId=c.Id
JOIN Departments d ON d.Id=c.DepartmentId
WHERE r.id=@ReportId)

IF (@EmpDept=@RepCat)
	BEGIN 
	UPDATE Reports
	SET EmployeeId=@EmployeeId
	WHERE Id=@ReportId
	END
ELSE
	BEGIN
	RAISERROR('Employee doesn''t belong to the appropriate department!',16,1);
	END
COMMIT 