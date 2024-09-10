Use Proyecto

CREATE TABLE Estados(
ID_estado int primary key identity(1,1),
Nombre nvarchar(50) not null);

CREATE TABLE Bodegas(
ID_bodega int primary key identity(1,1),
Fecha_llegada datetime not null,
cantidad int,
Valor_bodega decimal(10, 3));

CREATE TABLE Categorias(
ID_categoria int primary key identity(1,1),
Nombre nvarchar(100) not null,
Grupo nvarchar(100) not null);

CREATE TABLE Sucursales(
ID_sucursal int primary key identity(1,1),
ID_bodega int,
Foreign Key (ID_bodega) references Bodegas(ID_bodega),
Nombre nvarchar(100) not null,
Direccion nvarchar(100) not null);

CREATE TABLE Proveedores(
ID_proveedor int primary key identity(1,1),
Nombre nvarchar(100) not null,
Direccion nvarchar(100) not null,
Telefono nvarchar(10) not null)

CREATE TABLE Productos(
ID_producto int primary key identity(1,1),
Nombre nvarchar(100) not null,
Stock int,
Fecha_vencimiento datetime,
Precio_unitario decimal,
ID_categoria  int,
Foreign Key (ID_categoria) references Categorias(ID_categoria),
ID_estado  int,
Foreign Key (ID_estado) references Estados(ID_estado),
ID_proveedor  int,
Foreign Key (ID_proveedor) references Proveedores(ID_proveedor));

CREATE TABLE Estantes(
ID_estante int primary key identity(1,1),
Cantidad_producto int,
ID_producto  int,
Foreign Key (ID_producto) references Productos(ID_producto),
ID_bodega  int,
Foreign Key (ID_bodega) references Bodegas(ID_bodega),
ID_categoria  int,
Foreign Key (ID_categoria) references Categorias(ID_categoria))
