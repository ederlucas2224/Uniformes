create table Tipo(
IdTipo int primary key identity(1,1),
Nombre nvarchar(max))

create table Grupos(
IdGrupo int primary key identity(1,1),
Nombre nvarchar(max),
IdTipo int foreign key references Tipo(IdTipo))

create table Empleados(
IdEmpleado int primary key identity(1,1),
PrimerNombre nvarchar(max),
SegundoNombre nvarchar(max),
ApellidoPaterno nvarchar(max),
ApellidoMaterno nvarchar(max),
Activo bit,
IdGrupo int foreign key references Grupos(IdGrupo))

create table Productos(
IdProducto int primary key identity(1,1),
Nombre nvarchar(max),
Cantidad int,
Costo float,
IdGrupo int foreign key references Grupos(IdGrupo))

create table Ordenes(
IdOrden int primary key identity(1,1),
Fecha datetime)

create table OrdenesSalida(
Id int primary key identity(1,1),
IdOrden int foreign key references Ordenes(IdOrden),
Cantidad int,
IdProducto int foreign key references Productos(IdProducto),
IdEmpleado int foreign key references Empleados(IdEmpleado))

create table OrdenesEntrada(
Id int primary key identity(1,1),
IdOrden int foreign key references Ordenes(IdOrden),
Cantidad int,
IdProducto int foreign key references Productos(IdProducto))

create table TablaPivote(
Id int primary key identity(1,1),
IdEmpleado int,
Estatus int)