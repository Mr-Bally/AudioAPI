USE [AudioDatabase]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAudioFile]
	@Id uniqueidentifier,
	@FileName nchar(50),
	@AuthorId uniqueidentifier,
	@FilePath varchar(300)
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO [AudioFiles]
	(Id, FileName, Author, FilePath, LastUpdated)
	VALUES
	(@Id, @FileName, @AuthorId, @FilePath, GETUTCDATE())
END

GO

CREATE PROCEDURE [dbo].[DeleteAudioFile]
	@Id uniqueidentifier
AS
BEGIN
	SET NOCOUNT OFF;

	DELETE FROM [AudioFiles]
	WHERE Id = @Id
END

GO

CREATE PROCEDURE [dbo].[GetAudioFile]
	@Id uniqueidentifier
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT [Id]
		  ,[FileName]
		  ,[Author]
		  ,[FilePath]
		  ,[LastUpdated]
	  FROM [AudioDatabase].[dbo].[AudioFiles]
	  WHERE [Id] = @Id
END

GO