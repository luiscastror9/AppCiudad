CREATE TABLE [dbo].[servicios]
(
	[Servicios] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nombre] NVARCHAR(MAX) NULL, 
    [telefono] NVARCHAR(MAX) NULL, 
    [direccion] NVARCHAR(MAX) NULL,
)
