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