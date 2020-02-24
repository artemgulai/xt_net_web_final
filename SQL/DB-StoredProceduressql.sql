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