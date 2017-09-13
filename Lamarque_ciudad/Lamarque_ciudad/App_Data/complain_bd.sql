CREATE TABLE [dbo].[complain_bd]
(
	[Id] INT NULL PRIMARY KEY, 
    [user] NCHAR(10) NOT NULL, 
    [photo] IMAGE NULL, 
    [adr] NCHAR(10) NULL, 
    [desc] NCHAR(400) NOT NULL, 
    [day] DATE NOT NULL
)
