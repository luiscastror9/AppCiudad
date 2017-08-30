CREATE TABLE [dbo].[reclamos]
(
	[Reclamos] INT NOT NULL PRIMARY KEY IDENTITY, 
    [usuario] NVARCHAR(MAX) NULL, 
    [direccion] NVARCHAR(MAX) NULL, 
    [fecha] NVARCHAR(MAX) NULL, 
    [descripcion] TEXT NULL, 
    [foto] IMAGE NULL
)
