USE VacanciesDB;
GO

-- Stored procedures for Cities table
CREATE PROCEDURE [dbo].[sp_InsertCity]
	@Name NVARCHAR(100)
AS
	INSERT INTO Cities (Name) 
	OUTPUT inserted.Id
	VALUES (@Name)
GO

CREATE PROCEDURE [dbo].[sp_SelectCityId]
	@Name NVARCHAR(100)
AS
	SELECT ID FROM Cities
	WHERE Name = @Name
GO

CREATE PROCEDURE [dbo].[sp_DeleteCityById]
	@Id INT
AS
	DELETE FROM Cities WHERE Id = @Id
GO

CREATE PROCEDURE [dbo].[sp_DeleteAllCities]
AS
	DELETE FROM Cities
GO

CREATE PROCEDURE [dbo].[sp_SelectAllCities]
AS
	SELECT * FROM Cities
GO

-- Stored procedures for Skills table
CREATE PROCEDURE [dbo].[sp_InsertSkill]
	@Name NVARCHAR(100)
AS
	INSERT INTO Skills (Name) 
	OUTPUT inserted.Id
	VALUES (@Name)
GO

CREATE PROCEDURE [dbo].[sp_SelectAllSkills]
AS
	SELECT * FROM Skills
GO

CREATE PROCEDURE [dbo].[sp_DeleteSkillById]
	@Id INT
AS
	DELETE FROM Skills WHERE Id = @Id
GO

-- Stored procedures for Admins table
CREATE PROCEDURE [dbo].[sp_InsertAdmin]
	@Login NVARCHAR(100),
	@Password NVARCHAR(100),
	@Role NVARCHAR(50)
AS
	INSERT INTO Admins 
	(Login, Password, Role_ID, Candidate)
	OUTPUT inserted.Id
	VALUES (@Login, @Password, (SELECT Id FROM Roles where Name = @Role), 1)
GO

CREATE PROCEDURE [dbo].[sp_SelectAllAdmins]
AS
	SELECT Admins.Id as Id, Login, Password, Name as Role, Candidate FROM Admins
	JOIN Roles on Role_ID = Roles.Id
GO

CREATE PROCEDURE [dbo].[sp_SelectAdminById]
	@Id INT
AS
	SELECT Admins.Id as Id, Login, Password, Roles.Name as Role, Candidate FROM Admins
	JOIN Roles on Role_ID = Roles.Id WHERE Admins.Id = @Id
GO

CREATE PROCEDURE [dbo].[sp_SelectAdminByLogin]
	@Login NVARCHAR(100)
AS
	SELECT Admins.Id as Id, Login, Password, Roles.Name as Role, Candidate FROM Admins
	JOIN Roles on Role_ID = Roles.Id WHERE Admins.Login = @Login
GO

CREATE PROCEDURE [dbo].[sp_DeleteAdminById]
	@Id INT
AS
	IF (@Id <> 1) DELETE FROM Admins WHERE Id = @Id
GO

CREATE PROCEDURE [dbo].[sp_UpdateAdminById]
	@Id INT,
	@Candidate BIT
AS
	UPDATE Admins SET Candidate = @Candidate WHERE Id = @Id
GO

-- Stored procedures for Employees table
CREATE PROCEDURE [dbo].[sp_InsertEmployee]
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Relocation BIT,
	@Experience INT,
	@Photo NVARCHAR(MAX),
	@Login NVARCHAR(100),
	@Password NVARCHAR(100),
	@City NVARCHAR(100)
AS
	INSERT INTO Employees (FirstName, LastName, Relocation, Experience, Photo, 
							Login, Password, City_Id, Role_Id)
	OUTPUT inserted.Id
	VALUES (@FirstName, @LastName, @Relocation, @Experience, @Photo,
			@Login, @Password, (SELECT Id FROM Cities WHERE Name = @City),
			(SELECT Id FROM Roles WHERE Name = 'EMPLOYEE'))
GO

CREATE PROCEDURE [dbo].[sp_SelectAllEmployees]
AS
	SELECT Employees.Id as Id, FirstName, LastName, Relocation, Experience, Photo, Login, Password, 
	Cities.Name AS City, Roles.Name AS Role FROM Employees
	JOIN Cities ON City_Id = Cities.Id
	JOIN Roles ON Role_Id = Roles.Id
GO

CREATE PROCEDURE [dbo].[sp_SelectEmployeeById]
	@Id INT
AS
	SELECT Employees.Id as Id, FirstName, LastName, Relocation, Experience, Photo, Login, Password, 
	Cities.Name AS City, Roles.Name AS Role FROM Employees
	JOIN Cities ON City_Id = Cities.Id
	JOIN Roles ON Role_Id = Roles.Id
	WHERE Employees.Id = @Id
GO

CREATE PROCEDURE [dbo].[sp_DeleteEmployeeById]
	@Id INT
AS
	DELETE FROM Employees WHERE Id = @Id
GO

CREATE PROCEDURE [dbo].[sp_DeleteAllEmployees]
AS
	DELETE FROM Employees
GO

CREATE PROCEDURE [dbo].[sp_UpdateEmployee]
	@Id INT,
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Relocation BIT,
	@Experience INT,
	@Photo NVARCHAR(MAX),
	@Password NVARCHAR(100),
	@City NVARCHAR(100)
AS
	UPDATE Employees SET
		FirstName = @FirstName, LastName = @LastName,
		Relocation = @Relocation, Experience = @Experience,
		Photo = @Photo, Password = @Password, 
		City_Id = (SELECT Id FROM Cities WHERE Name = @City)
	WHERE Id = @Id
GO

CREATE PROCEDURE [dbo].[sp_InsertSkillEmployee]
	@EmployeeId INT,
	@SkillId INT,
	@Level INT
AS
	INSERT INTO Employees_Skills
	(Employee_Id, Skill_Id, Level)
	VALUES (@EmployeeId, @SkillId, @Level)
GO

CREATE PROCEDURE [dbo].[sp_DeleteSkillEmployee]
	@SkillId INT,
	@EmployeeId INT
AS
	DELETE FROM Employees_Skills
	WHERE Skill_Id = @SkillId AND Employee_Id = @EmployeeId
GO

CREATE PROCEDURE [dbo].[sp_UpdateSkillEmployee]
	@SkillId INT,
	@EmployeeId INT,
	@Level INT
AS
	UPDATE Employees_Skills
	SET Level = @Level
	WHERE Skill_Id = @SkillId AND Employee_Id = @EmployeeId
GO

CREATE PROCEDURE [dbo].[sp_SelectSkillsByEmployee]
	@EmployeeId INT
AS
	SELECT Skills.Id as Id, Skills.Name as Name, Employees_Skills.Level as Level 
	FROM Employees_Skills
	JOIN Skills on Skills.Id = Skill_Id
	WHERE Employee_Id = @EmployeeId
GO

-- Stored procedures for Vacancies table
CREATE PROCEDURE [dbo].[sp_InsertVacancy]
	@Name NVARCHAR(200),
	@Description NVARCHAR(MAX),
	@Salary INT,
	@Remote BIT,
	@EmployerId INT
AS
	INSERT INTO Vacancies (Name, Description, Salary, Remote, Employer_Id)
	OUTPUT inserted.Id
	VALUES (@Name, @Description, @Salary, @Remote, @EmployerId)
GO

CREATE PROCEDURE [dbo].[sp_SelectVacancyById]
	@Id INT
AS
	SELECT Id, Name, Salary, Remote 
	FROM Vacancies WHERE Id = @Id
GO

CREATE PROCEDURE [dbo].[sp_SelectAllVacancies]
AS
	SELECT Id, Name, Salary, Remote 
	FROM Vacancies ORDER BY Employer_Id
GO

CREATE PROCEDURE [dbo].[sp_SelectAllVacanciesByEmployer]
	@EmployerId INT
AS
	SELECT Id, Name, Description, Salary, Remote 
	FROM Vacancies WHERE Employer_Id = @EmployerId
GO

CREATE PROCEDURE [dbo].[sp_DeleteVacancyById]
	@Id INT
AS
	DELETE FROM Vacancies WHERE Id = @Id
GO

CREATE PROCEDURE [dbo].[sp_DeleteAllVacancies]
AS
	DELETE FROM Vacancies
GO

CREATE PROCEDURE [dbo].[sp_UpdateVacancy]
	@Id INT,
	@Name NVARCHAR(200),
	@Description NVARCHAR(MAX),
	@Salary INT,
	@Remote BIT
AS
	UPDATE Vacancies SET
		Name = @Name, Description = @Description, Salary = @Salary, Remote = @Remote
	WHERE Id = @Id
GO

CREATE PROCEDURE [dbo].[sp_InsertRequirementVacancy]
	@VacancyId INT,
	@SkillId INT,
	@Level INT
AS
	INSERT INTO Vacancies_Skills (Vacancy_Id, Skill_Id, Level)
	VALUES (@VacancyId, @SkillId, @Level)
GO

CREATE PROCEDURE [dbo].[sp_DeleteRequirementVacancy]
	@VacancyId INT,
	@SkillId INT
AS
	DELETE FROM Vacancies_Skills
	WHERE Vacancy_Id = @VacancyId AND Skill_Id = @SkillId
GO

CREATE PROCEDURE [dbo].[sp_SelectRequirementsByVacancy]
	@VacancyId INT
AS
	SELECT Skills.Id as Id, Skills.Name as Name, Level FROM Vacancies_Skills
	JOIN Skills on Skill_Id = Skills.Id
	WHERE Vacancy_Id = @VacancyId
GO

-- Stored procedures for Employers table
CREATE PROCEDURE [dbo].[sp_InsertEmployer]
	@Name NVARCHAR(100),
	@Logo NVARCHAR(MAX),
	@Login NVARCHAR(100),
	@Password NVARCHAR(100),
	@City NVARCHAR(100)
AS
	INSERT INTO Employers (Name, Logo, Login, Password, City_Id, Role_Id)
	OUTPUT inserted.Id 
	VALUES (@Name, @Logo, @Login, @Password, 
	(SELECT Id FROM Cities WHERE Name = @City),
	(SELECT Id FROM Roles WHERE Name = 'EMPLOYER'))
GO

CREATE PROCEDURE [dbo].[sp_SelectEmployerById]
	@Id INT
AS
	SELECT Employers.Id as Id, Employers.Name as Name, Logo, Login, Password, Cities.Name as City, Roles.Name as Role
	FROM Employers
	JOIN Cities on Employers.City_Id = Cities.Id
	JOIN Roles on Employers.Role_Id = Roles.Id
	WHERE Employers.Id = @Id
GO

CREATE PROCEDURE [dbo].[sp_SelectAllEmployers]
AS
	SELECT Employers.Id as Id, Employers.Name as Name, Logo, Login, Password, Cities.Name as City, Roles.Name as Role
	FROM Employers
	JOIN Cities on Employers.City_Id = Cities.Id
	JOIN Roles on Employers.Role_Id = Roles.Id
GO

CREATE PROCEDURE [dbo].[sp_DeleteEmployerById]
	@Id INT
AS
	DELETE FROM Employers WHERE Id = @Id
GO

CREATE PROCEDURE [dbo].[sp_DeleteAllEmployers]
AS
	DELETE FROM Employers
GO

CREATE PROCEDURE [dbo].[sp_UpdateEmployer]
	@Id INT,
	@Name NVARCHAR(100),
	@Logo NVARCHAR(MAX),
	@Password NVARCHAR(100),
	@City NVARCHAR(100)
AS
	UPDATE Employers SET Name = @Name, Logo = @Logo, Password = @Password, 
		City_Id = (SELECT Id FROM Cities WHERE Name = @City)
	WHERE Id = @Id
GO