CREATE TABLE [dbo].[eventos]
(
	[Eventos] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nombre] NVARCHAR(MAX) NULL, 
    [fecha] NVARCHAR(MAX) NULL, 
    [direccion] NVARCHAR(MAX) NULL
	[descripcion] NVARCHAR(MAX) NULL
)