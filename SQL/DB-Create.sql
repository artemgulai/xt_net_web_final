USE master;
GO

DROP DATABASE IF EXISTS  VacanciesDB;
GO

CREATE DATABASE VacanciesDB;
GO

USE VacanciesDB;
GO

-- cities where the company is located 
-- and employer lives
CREATE TABLE Cities (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
	CONSTRAINT Cities_Name_Unique UNIQUE (Name)
);
GO

-- roles for registered users
CREATE TABLE Roles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
	CONSTRAINT Roles_Name_Unique UNIQUE (Name)
);
GO

CREATE TABLE Skills (
	Id INT PRIMARY KEY IDENTITY(1,1), 
	Name NVARCHAR (100) NOT NULL,
	CONSTRAINT Skills_Name_Unique UNIQUE (Name)
);
GO

-- Users with administrator rights
CREATE TABLE Admins (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Login NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Role_ID INT NOT NULL,
	Candidate BIT NOT NULL,
	CONSTRAINT FK_Role_ID FOREIGN KEY (Role_Id) REFERENCES Roles(Id),
	CONSTRAINT Admins_Login_Unique UNIQUE (Login)
);
GO

-- Employers
CREATE TABLE Employers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Login NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
	Logo NVARCHAR(MAX),
    City_Id INT NOT NULL,
    Role_Id INT NOT NULL,
	CONSTRAINT FK_City_ID FOREIGN KEY (City_Id) REFERENCES Cities(Id),
	CONSTRAINT FK_Employer_Role_ID FOREIGN KEY (Role_Id) REFERENCES Roles(Id),
	CONSTRAINT Employer_Login_Unique UNIQUE (Login)
);
GO

-- Employers' Vacancies
CREATE TABLE Vacancies (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(200) NOT NULL,
	Description NVARCHAR(MAX) NOT NULL,
	Salary INT NOT NULL,
    Remote BIT NOT NULL,
	Employer_Id INT NOT NULL,
	CONSTRAINT FK_Employer_ID FOREIGN KEY (Employer_Id) REFERENCES Employers(Id) ON DELETE CASCADE
);
GO

-- Requirements (Skills) for Vacancies
CREATE TABLE Vacancies_Skills (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Level INT NOT NULL,
	Vacancy_Id INT NOT NULL,
	Skill_Id INT NOT NULL,
	CONSTRAINT FK_Vacancy_ID FOREIGN KEY (Vacancy_Id) REFERENCES Vacancies(Id) ON DELETE CASCADE,
	CONSTRAINT FK_Skill_ID FOREIGN KEY (Skill_Id) REFERENCES Skills(Id) ON DELETE CASCADE,
	CONSTRAINT Vacancies_Skills_VacancyId_SkillId_Unique UNIQUE (Vacancy_Id, Skill_Id)
);
GO

-- Employees
CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	Relocation BIT NOT NULL,
	Experience INT NOT NULL,
	Photo NVARCHAR(MAX),
	Login NVARCHAR(100) NOT NULL,
	Password NVARCHAR(100) NOT NULL,
	City_Id INT NOT NULL,
	Role_Id INT NOT NULL,
	CONSTRAINT FK_Employee_City_ID FOREIGN KEY (City_Id) REFERENCES Cities(Id),
	CONSTRAINT FK_Employee_Role_ID FOREIGN KEY (Role_Id) REFERENCES Roles(Id),
	CONSTRAINT Unique_Login_Employee UNIQUE (Login)
);
GO

-- Employees' Skills 
CREATE TABLE Employees_Skills (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Level INT NOT NULL,
	Employee_Id INT NOT NULL,
	Skill_Id INT NOT NULL,
	CONSTRAINT FK_Employee_ID FOREIGN KEY (Employee_Id) REFERENCES Employees(Id) ON DELETE CASCADE,
	CONSTRAINT FK_Employees_Skills_Skill_ID FOREIGN KEY (Skill_Id) REFERENCES Skills(Id) ON DELETE CASCADE,
	CONSTRAINT Employees_Skills_EmployeeId_SkillId_Unique UNIQUE (Employee_Id, Skill_Id)
);
GO

--Unique login constraints across all tables
CREATE FUNCTION get_Num_Employee_Logins(@Login NVARCHAR(100))
    RETURNS INT
AS
    BEGIN
        RETURN (SELECT COUNT(*) FROM Employees WHERE Login=@Login)
    END;
GO

CREATE FUNCTION get_Num_Employer_Logins(@Login NVARCHAR(100))
    RETURNS INT
AS
    BEGIN
        RETURN (SELECT COUNT(*) FROM Employers WHERE Login=@Login)
    END;
GO

CREATE FUNCTION get_Num_Admin_Logins(@Login NVARCHAR(100))
    RETURNS INT
AS
    BEGIN
        RETURN (SELECT COUNT(*) FROM Admins WHERE Login=@Login)
    END;
GO

ALTER TABLE Employers WITH CHECK
   ADD CONSTRAINT CHK_Login_Employers   
   CHECK (dbo.get_Num_Admin_Logins(Login) = 0 AND dbo.get_Num_Employee_Logins(Login) = 0);
GO

ALTER TABLE Employees WITH CHECK
   ADD CONSTRAINT CHK_Login_Employees   
   CHECK (dbo.get_Num_Admin_Logins(Login) = 0 AND dbo.get_Num_Employer_Logins(Login) = 0 );
GO

ALTER TABLE Admins WITH CHECK
   ADD CONSTRAINT CHK_Login_Admins  
   CHECK (dbo.get_Num_Employee_Logins(Login) = 0 AND dbo.get_Num_Employer_Logins(Login) = 0 );
GO

-- Initial data
INSERT INTO Roles (Name) VALUES ('ADMIN');
INSERT INTO Roles (Name) VALUES ('EMPLOYER');
INSERT INTO Roles (Name) VALUES ('EMPLOYEE');

INSERT INTO Admins (Login, Password, Role_ID, Candidate) 
	VALUES ('admin', 'admin', (SELECT Id FROM Roles WHERE Name = 'ADMIN'), 0);