CREATE TABLE [dbo].[people_bd]
(
	[Id] INT NULL PRIMARY KEY, 
    [user] NCHAR(10) NOT NULL, 
    [photo] IMAGE NULL, 
    [pass] NCHAR(20) NOT NULL, 
    [name] NCHAR(20) NOT NULL, 
    [lastname] NCHAR(20) NOT NULL, 
    [birth] DATE NOT NULL, 
    [mail] NCHAR(20) NOT NULL
)
