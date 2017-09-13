CREATE TABLE [dbo].[map]
(
	[Id] INT NULL PRIMARY KEY, 
    [name] NCHAR(20) NOT NULL, 
    [lat] INT NOT NULL, 
    [leng] INT NOT NULL, 
    [desc] NCHAR(50) NULL
)
