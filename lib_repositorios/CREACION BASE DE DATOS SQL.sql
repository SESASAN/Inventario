CREATE DATABASE Inventario_db;
GO

Use Inventario_db;
GO

CREATE TABLE [Estados]
(
	[Id] INT NOT NULL,
	[Nombre] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Sucursales](
	[Id] INT NOT NULL,
	[Nombre] NVARCHAR(100) NOT NULL,
	[Direccion] NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK_Sucursales] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Bodegas](
	[Id] INT NOT NULL,
	[Cantidad_estante] INT DEFAULT 0,
	[Valor_bodega] DECIMAL(10, 3),
	[Sucursal] INT NOT NULL,
	CONSTRAINT [PK_Bodegas] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Bodegas_Sucursales] FOREIGN KEY ([Sucursal]) REFERENCES [Sucursales] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE [Categorias](
	[Id] INT NOT NULL,
	[Nombre] NVARCHAR(100) NOT NULL,
	[Grupo] INT NOT NULL,
	CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Proveedores](
	[Id] INT NOT NULL,
	[Nombre] NVARCHAR(100) NOT NULL,
	[Direccion] NVARCHAR(100) NOT NULL,
	[Telefono] NVARCHAR(10) NOT NULL,
	CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Estantes](
	[Id] INT NOT NULL,
	[Cantidad_producto] INT DEFAULT 0,
	[Bodega]  INT NOT NULL,
	[Categoria]  INT NOT NULL,
	[Valor]  DECIMAL(15,2) NOT NULL DEFAULT 0,
	CONSTRAINT [PK_Estantes] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Estantes_Bodegas] FOREIGN KEY ([Bodega]) REFERENCES [Bodegas] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT [FK_Estantes_Categorias] FOREIGN KEY ([Categoria]) REFERENCES [Categorias] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO


CREATE TABLE [Productos](
	[Id] INT NOT NULL,
	[Nombre] NVARCHAR(60) NOT NULL,
	[Descripcion] NVARCHAR(150),
	[Stock] INT DEFAULT 0,
	[Precio_unitario] DECIMAL(6,2) NOT NULL,
	[Categoria] INT NOT NULL,
	[Estante] INT NOT NULL,
	CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Productos_Categorias] FOREIGN KEY ([Categoria]) REFERENCES [Categorias] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT [FK_Productos_Estantes] FOREIGN KEY ([Estante]) REFERENCES [Estantes] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE [Lotes] (
	[Id] INT NOT NULL,
	[Producto] INT NOT NULL,
	[Fecha_llegada] DATETIME NOT NULL,
	[Fecha_vencimiento] DATETIME NOT NULL,
	[Cantidad] INT DEFAULT 0 NOT NULL,
	[Estado]  INT NOT NULL,
	[Proveedor]  INT NOT NULL,
	CONSTRAINT [PK_Lotes] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Lotes_Productos] FOREIGN KEY ([Producto]) REFERENCES [Productos] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT [FK_Lotes_Estados] FOREIGN KEY ([Estado]) REFERENCES [Estados] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT [FK_Lotes_Proveedores] FOREIGN KEY ([Proveedor]) REFERENCES [Proveedores] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

