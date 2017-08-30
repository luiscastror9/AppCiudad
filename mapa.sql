CREATE TABLE [dbo].[mapa]
(
	[mapa] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nombre] NVARCHAR(MAX) NULL, 
    [latitud] int NULL, 
    [longitud] int NULL
	[descripcion] NVARCHAR(MAX) NULL
)