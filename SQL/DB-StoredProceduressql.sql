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

CREATE PROCEDURE [dbo].[sp_GetCityId]
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

CREATE PROCEDURE [dbo].[sp_GetAllCities]
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

CREATE PROCEDURE [dbo].[sp_GetAllSkills]
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

CREATE PROCEDURE [dbo].[sp_GetAllAdmins]
AS
	SELECT Admins.Id as Id, Login, Password, Name as Role, Candidate FROM Admins
	JOIN Roles on Role_ID = Roles.Id
GO

CREATE PROCEDURE [dbo].[sp_GetAdminById]
	@Id INT
AS
	SELECT Admins.Id as Id, Login, Password, Roles.Name as Role, Candidate FROM Admins
	JOIN Roles on Role_ID = Roles.Id WHERE Admins.Id = @Id
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
	@Login NVARCHAR(100),
	@Password NVARCHAR(100),
	@City NVARCHAR(100)
AS
	INSERT INTO Employees (FirstName, LastName, Relocation, Experience, 
							Login, Password, City_Id, Role_Id)
	OUTPUT inserted.Id
	VALUES (@FirstName, @LastName, @Relocation, @Experience,
			@Login, @Password, (SELECT Id FROM Cities WHERE Name = @City),
			(SELECT Id FROM Roles WHERE Name = 'EMPLOYEE'))
GO

CREATE PROCEDURE [dbo].[sp_GetAllEmployees]
AS
	SELECT Employees.Id as Id, FirstName, LastName, Relocation, Experience, Login, Password, 
	Cities.Name AS City, Roles.Name AS Role FROM Employees
	JOIN Cities ON City_Id = Cities.Id
	JOIN Roles ON Role_Id = Roles.Id
GO

CREATE PROCEDURE [dbo].[sp_GetEmployeeById]
	@Id INT
AS
	SELECT Employees.Id as Id, FirstName, LastName, Relocation, Experience, Login, Password, 
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
	@Password NVARCHAR(100),
	@City NVARCHAR(100)
AS
	UPDATE Employees SET
		FirstName = @FirstName, LastName = @LastName,
		Relocation = @Relocation, Experience = @Experience,
		Password = @Password, 
		City_Id = (SELECT Id FROM Cities WHERE Name = @City)
	WHERE Id = @Id
GO

CREATE PROCEDURE [dbo].[sp_AddSkillEmployee]
	@EmployeeId INT,
	@SkillId INT,
	@Level INT
AS
	INSERT INTO Employees_Skills
	(Employee_Id, Skill_Id, Level)
	VALUES (@EmployeeId, @SkillId, @Level)
GO

CREATE PROCEDURE [dbo].[sp_RemoveSkillEmployee]
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

CREATE PROCEDURE [dbo].[sp_GetSkillsByEmployee]
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
	@Salary INT,
	@Remote BIT,
	@EmployerId INT
AS
	INSERT INTO Vacancies (Name, Salary, Remote, Employer_Id)
	OUTPUT inserted.Id
	VALUES (@Name, @Salary, @Remote, @EmployerId)
GO

CREATE PROCEDURE [dbo].[sp_GetVacancyById]
	@Id INT
AS
	SELECT Id, Name, Salary, Remote 
	FROM Vacancies WHERE Id = @Id
GO

CREATE PROCEDURE [dbo].[sp_GetAllVacancies]
AS
	SELECT Id, Name, Salary, Remote 
	FROM Vacancies
GO

CREATE PROCEDURE [dbo].[sp_GetAllVacanciesByEmployer]
	@EmployerId INT
AS
	SELECT Id, Name, Salary, Remote 
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
	@Salary INT,
	@Remote BIT
AS
	UPDATE Vacancies SET
		Name = @Name, Salary = @Salary, Remote = @Remote
	WHERE Id = @Id
GO

CREATE PROCEDURE [dbo].[sp_AddRequirementVacancy]
	@VacancyId INT,
	@SkillId INT,
	@Level INT
AS
	INSERT INTO Vacancies_Skills (Vacancy_Id, Skill_Id, Level)
	VALUES (@VacancyId, @SkillId, @Level)
GO

CREATE PROCEDURE [dbo].[sp_RemoveRequirementVacancy]
	@VacancyId INT,
	@SkillId INT
AS
	DELETE FROM Vacancies_Skills
	WHERE Vacancy_Id = @VacancyId AND Skill_Id = @SkillId
GO

CREATE PROCEDURE [dbo].[sp_GetRequirementsByVacancy]
	@VacancyId INT
AS
	SELECT Skills.Id as Id, Skills.Name as Name, Level FROM Vacancies_Skills
	JOIN Skills on Skill_Id = Skills.Id
	WHERE Vacancy_Id = @VacancyId
GO