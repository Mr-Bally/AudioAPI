USE [AudioDatabase]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AudioFiles](
	[Id] [uniqueidentifier] NOT NULL,
	[FileName] [nchar](50) NOT NULL,
	[Author] [uniqueidentifier] NOT NULL,
	[FilePath] [varchar](300) NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
 CONSTRAINT [Id_Index] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AudioFiles] ADD  CONSTRAINT [DF_AudioFiles_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
GO
