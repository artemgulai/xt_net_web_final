USE VacanciesDB;
GO

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