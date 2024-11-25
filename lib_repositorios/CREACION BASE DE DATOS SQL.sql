CREATE DATABASE Inventario_db;
GO

Use Inventario_db;
GO

CREATE TABLE [Estados]
(
	[Id] INT IDENTITY(1,1),
	[Nombre] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Sucursales](
	[Id] INT IDENTITY(1,1),
	[Nombre] NVARCHAR(100) NOT NULL,
	[Direccion] NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK_Sucursales] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Bodegas](
	[Id] INT IDENTITY(1,1),
	[Nombre] NVARCHAR(100) NOT NULL,
	[Cantidad_estante] INT DEFAULT 0 NOT NULL,
	[Valor_bodega] DECIMAL(20, 2) NOT NULL,
	[Sucursal] INT NOT NULL,
	CONSTRAINT [PK_Bodegas] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Bodegas_Sucursales] FOREIGN KEY ([Sucursal]) REFERENCES [Sucursales] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

CREATE TABLE [Categorias](
	[Id] INT IDENTITY(1,1),
	[Nombre] NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Proveedores](
	[Id] INT IDENTITY(1,1),
	[Nombre] NVARCHAR(100) NOT NULL,
	[Direccion] NVARCHAR(100) NOT NULL,
	[Telefono] NVARCHAR(10) NOT NULL,
	CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Estantes](
	[Id] INT IDENTITY(1,1),
	[Nombre] NVARCHAR(100) NOT NULL,
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
	[Id] INT IDENTITY(1,1),
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
	[Id] INT IDENTITY(1,1),
	[Nombre] NVARCHAR(100) NOT NULL,
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

CREATE TABLE [Roles] (
	[Id] INT IDENTITY(1,1),
	[Nombre] NVARCHAR(50) NOT NULL,
	[Permiso] BIT DEFAULT 0,
	CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([Id]),
);
GO

CREATE TABLE [Usuarios] (
	[Id] INT IDENTITY(1,1),
	[Nombre] NVARCHAR(40) NOT NULL,
	[Apellidos] NVARCHAR(40) NOT NULL,
	[Nombre_Usuario] NVARCHAR(40) NOT NULL,
	[Clave] NVARCHAR(35)NOT NULL,
	[Rol] INT NOT NULL,
	CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY ([Rol]) REFERENCES [Roles] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
);
GO

CREATE TABLE [Acciones] (
	[Id] INT IDENTITY(1,1),
	[Nombre] NVARCHAR(15) NOT NULL,
	CONSTRAINT [PK_Acciones] PRIMARY KEY CLUSTERED ([Id]),
);
GO

CREATE TABLE [Auditorias] (
	[Id] INT IDENTITY(1,1),
	[Usuario] INT NOT NULL,
	[Fecha] DATETIME DEFAULT GETDATE(),
	[Accion] INT NOT NULL,
	[Entidad] NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [PK_Auditorias] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Auditorias_Acciones] FOREIGN KEY ([Accion]) REFERENCES [Acciones] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT [FK_Auditorias_Usuarios] FOREIGN KEY ([Usuario]) REFERENCES [Usuarios] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION,
);
GO

-- INSERTAR DATOS DE PRUEBA

Insert INTO [Sucursales] ([Nombre], [Direccion])
VALUES ('Za Principal','Calle 46 #45-67')

Insert INTO [Proveedores] ([Nombre], [Direccion],[Telefono])
VALUES ('Tiendas D1','Calle 50b #112-46', '3146578903')

Insert INTO [Estados] ([Nombre])
VALUES ('Nuevo'), ('Próximo a vencer'), ('Vencido')

Insert INTO [Bodegas] ([Nombre],[Cantidad_estante], [Valor_bodega], [Sucursal])
VALUES ('Bodega 1',200,1500000.00,1)

Insert INTO [Categorias] ([Nombre])
VALUES ('Lácteos')

Insert INTO [Estantes] ([Nombre],[Cantidad_producto], [Bodega],[Categoria],[Valor])
VALUES ('Estante 1',20,1,1,1500000.00)

INSERT INTO [Productos] ([Nombre], [Descripcion], [Stock], [Precio_venta],[Iva], [Categoria], [Estante])
VALUES ('Leche','1 Litro',1,6990,0.19,1,1)

INSERT INTO [Lotes] ([Nombre],[Producto], [Fecha_llegada], [Fecha_vencimiento], [Cantidad],[Precio_unitario], [Estado], [Proveedor])
VALUES ('Lote 1',1,'08/23/2024','09/16/2024',8,5662,3,1)

INSERT INTO [Roles] ([Nombre],[Permiso])
VALUES ('Administrador',1),('Empleado',0)

INSERT INTO [Usuarios] ([Nombre],[Apellidos],[Nombre_Usuario],[Clave],[Rol])
VALUES ('Sebastián','Pérez Araujo','D0qT0HGnFTdXNevW22I2Ng==','xliSERfQYP4SvJ99Zb0P4w==',1),
('Nathalie','Miranda Rejón','TmYn4VBsB1jABxuVnNA3GA==','JH/NLJunIt6h2dkgYJ6Qhw==',1),
('Juan','Medina Sepúlveda','kBcG/P/3lXZZvV9emVGqOg==','N7PsvbBBOvnoFf1JluX6EQ==',1),
('Samuel','Quiroz Rincón','i3VKwxMYsMwK0jIfIp7D7g==','F2Yg/f6DMMp+6i/Zd3DJzg==',1)

INSERT INTO [Acciones] ([Nombre])
VALUES ('CREAR'),('MODIFICAR'),('ELIMINAR')
