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
	[Cantidad_estante] INT DEFAULT 0 NOT NULL,
	[Valor_bodega] DECIMAL(20, 2) NOT NULL,
	[Sucursal] INT NOT NULL,
	CONSTRAINT [PK_Bodegas] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Bodegas_Sucursales] FOREIGN KEY ([Sucursal]) REFERENCES [Sucursales] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE [Categorias](
	[Id] INT NOT NULL,
	[Nombre] NVARCHAR(100) NOT NULL,
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
	[Valor]  DECIMAL(20,2) NOT NULL DEFAULT 0,
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
	[Precio_venta] DECIMAL(10,2) NOT NULL,
	[Iva] DECIMAL(2,2) NOT NULL,
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
	[Precio_unitario] DECIMAL(10,2) NOT NULL,
	[Estado]  INT NOT NULL,
	[Proveedor]  INT NOT NULL,
	CONSTRAINT [PK_Lotes] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Lotes_Productos] FOREIGN KEY ([Producto]) REFERENCES [Productos] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT [FK_Lotes_Estados] FOREIGN KEY ([Estado]) REFERENCES [Estados] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT [FK_Lotes_Proveedores] FOREIGN KEY ([Proveedor]) REFERENCES [Proveedores] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

-- INSERTAR DATOS DE PRUEBA

Insert INTO [Sucursales] ([Id], [Nombre], [Direccion])
VALUES (1,'Za Principal','Calle 46 #45-67')

Insert INTO [Proveedores] ([Id], [Nombre], [Direccion],[Telefono])
VALUES (1,'Tiendas D1','Calle 50b #112-46', '3146578903')

Insert INTO [Estados] ([Id], [Nombre])
VALUES (1,'Nuevo'), (2,'Próximo a vencer'), (3,'Vencido')

Insert INTO [Bodegas] ([Id], [Cantidad_estante], [Valor_bodega], [Sucursal])
VALUES (1,200,1500000.00,1)

Insert INTO [Categorias] ([Id], [Nombre])
VALUES (1,'Lácteos')

Insert INTO [Estantes] ([Id], [Cantidad_producto], [Bodega],[Categoria],[Valor])
VALUES (1,20,1,1,1500000.00)

INSERT INTO [Productos] ([Id], [Nombre], [Descripcion], [Stock], [Precio_venta],[Iva], [Categoria], [Estante])
VALUES (1, 'Leche','1 Litro',1,6990,0.19,1,1)

INSERT INTO [Lotes] ([Id],[Producto], [Fecha_llegada], [Fecha_vencimiento], [Cantidad],[Precio_unitario], [Estado], [Proveedor])
VALUES (1,1,'08/23/2024','09/16/2024',8,5662,3,1)
