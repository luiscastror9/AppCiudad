CREATE TABLE [dbo].[registro]
(
	[Registro] INT NOT NULL PRIMARY KEY IDENTITY, 
    [usuario] NVARCHAR(MAX) NULL, 
    [contraseña] NVARCHAR(MAX) NULL, 
    [nombre] NVARCHAR(MAX) NULL, 
    [apellido] NVARCHAR(MAX) NULL, 
    [email] NVARCHAR(MAX) NULL, 
)
