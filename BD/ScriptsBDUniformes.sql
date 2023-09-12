Create Database [Uniformes]
USE [Uniformes]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 11/09/2023 22:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[PrimerNombre] [nvarchar](max) NULL,
	[SegundoNombre] [nvarchar](max) NULL,
	[ApellidoPaterno] [nvarchar](max) NULL,
	[ApellidoMaterno] [nvarchar](max) NULL,
	[Activo] [bit] NULL,
	[IdGrupo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenesSalida]    Script Date: 11/09/2023 22:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenesSalida](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdOrden] [int] NULL,
	[Cantidad] [int] NULL,
	[IdProducto] [int] NULL,
	[IdEmpleado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 11/09/2023 22:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Cantidad] [int] NULL,
	[Costo] [float] NULL,
	[IdTipo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[OrdenesSalidaView]    Script Date: 11/09/2023 22:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[OrdenesSalidaView] as
Select orden.IdOrden,orden.Cantidad,prod.Nombre as NombreProducto,emp.PrimerNombre,emp.ApellidoPaterno 
from OrdenesSalida as orden inner join Productos as prod
on orden.IdProducto = prod.IdProducto inner join Empleados as emp
on orden.IdEmpleado = emp.IdEmpleado;
GO
/****** Object:  Table [dbo].[Grupos]    Script Date: 11/09/2023 22:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupos](
	[IdGrupo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[IdTipo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordenes]    Script Date: 11/09/2023 22:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordenes](
	[IdOrden] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOrden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenesEntrada]    Script Date: 11/09/2023 22:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenesEntrada](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdOrden] [int] NULL,
	[Cantidad] [int] NULL,
	[IdProducto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TablaPivote]    Script Date: 11/09/2023 22:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TablaPivote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpleado] [int] NULL,
	[Estatus] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo]    Script Date: 11/09/2023 22:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo](
	[IdTipo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupos] ([IdGrupo])
GO
ALTER TABLE [dbo].[Grupos]  WITH CHECK ADD FOREIGN KEY([IdTipo])
REFERENCES [dbo].[Tipo] ([IdTipo])
GO
ALTER TABLE [dbo].[OrdenesEntrada]  WITH CHECK ADD FOREIGN KEY([IdOrden])
REFERENCES [dbo].[Ordenes] ([IdOrden])
GO
ALTER TABLE [dbo].[OrdenesEntrada]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[OrdenesSalida]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
GO
ALTER TABLE [dbo].[OrdenesSalida]  WITH CHECK ADD FOREIGN KEY([IdOrden])
REFERENCES [dbo].[Ordenes] ([IdOrden])
GO
ALTER TABLE [dbo].[OrdenesSalida]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([IdTipo])
REFERENCES [dbo].[Tipo] ([IdTipo])
GO
/****** Object:  StoredProcedure [dbo].[OrdenEntradaSP]    Script Date: 11/09/2023 22:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[OrdenEntradaSP]
@Id nvarchar(max),
@Cantidad nvarchar(max),
@IdOrden int,
@Result bit output
as
begin try
	Declare @IdProducto int,@CantidadProducto int, @IdEmpleado int,@CantidadNueva int
	Set @IdProducto = (select IdProducto from Productos where IdProducto = CONVERT(int,@Id))
	Set @CantidadProducto = CONVERT(int, @Cantidad)
	Set @IdEmpleado = (select top 1 IdEmpleado from TablaPivote where Estatus = 1 order by 1 desc)
	insert into OrdenesSalida values(@IdOrden,@Cantidad,@IdProducto,@IdEmpleado)

	update Productos set Cantidad = Cantidad - @CantidadProducto where IdProducto = @IdProducto

	update TablaPivote set Estatus = 2 where IdEmpleado = @IdEmpleado

	Set @Result = 1;
end try
begin catch
	Set @Result = 0;
	Select @@ERROR
end catch
GO
