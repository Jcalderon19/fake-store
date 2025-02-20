CREATE TABLE [dbo].[Producto] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED ([Id] ASC),
    [Nombre] VARCHAR(50) NOT NULL,
    [Detalle] VARCHAR(100) NOT NULL,
    [Precio] INT NOT NULL,
    [Categoria] VARCHAR(50) NOT NULL,
);


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Producto]') AND type in (N'U'))
DROP TABLE [dbo].[Producto]
GO

SELECT * FROM Producto;



