USE [master]
GO
/****** Object:  Database [PROYECTACOMERCIO]    Script Date: 9/12/2024 16:18:00 ******/
CREATE DATABASE [PROYECTACOMERCIO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PLANTANOBLE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PLANTANOBLE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PLANTANOBLE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PLANTANOBLE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PROYECTACOMERCIO] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PROYECTACOMERCIO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PROYECTACOMERCIO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET ARITHABORT OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET  MULTI_USER 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PROYECTACOMERCIO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PROYECTACOMERCIO] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PROYECTACOMERCIO] SET QUERY_STORE = ON
GO
ALTER DATABASE [PROYECTACOMERCIO] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PROYECTACOMERCIO]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Direccion] [varchar](255) NULL,
	[CorreoElectronico] [varchar](100) NOT NULL,
	[Telefono] [varchar](15) NULL,
	[DNI] [varchar](20) NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[FechaCompra] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesCompra]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesCompra](
	[IdDetalleCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdCompra] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioCompra] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesVenta]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesVenta](
	[IdDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](10, 2) NOT NULL,
	[Subtotal] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoProveedor]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoProveedor](
	[IdProducto] [int] NOT NULL,
	[IdProveedor] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[IdCategoria] [int] NULL,
	[IdMarca] [int] NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[StockActual] [int] NOT NULL,
	[StockMinimo] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Detalle] [varchar](255) NULL,
	[CorreoElectronico] [varchar](100) NULL,
	[Telefono] [varchar](15) NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[CorreoElectronico] [nvarchar](255) NOT NULL,
	[DNI] [int] NOT NULL,
	[Telefono] [nvarchar](15) NULL,
	[TipoUsuario] [int] NOT NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[Fecha] [datetime] NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [Activo]) VALUES (1, N'Fertilizante', 0)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [Activo]) VALUES (2, N'PesticidaX', 0)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [Activo]) VALUES (3, N'Sustrato', 0)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [Activo]) VALUES (4, N'Herramientas', 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [Activo]) VALUES (5, N'Adornos jardin', 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [Activo]) VALUES (6, N'Plantas', 0)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [Activo]) VALUES (7, N'Tierra', 0)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [Activo]) VALUES (8, N'Tierra', 0)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [Activo]) VALUES (9, N'Regadores', 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [Activo]) VALUES (10, N'Semillas', 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [Activo]) VALUES (11, N'Piedras', 0)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([IdCliente], [Nombre], [Direccion], [CorreoElectronico], [Telefono], [DNI], [Activo]) VALUES (1, N'Cliente U', N'clienteA@correo.com', N'clienteA@correo.com', N'111222333', N'39517187', 1)
INSERT [dbo].[Clientes] ([IdCliente], [Nombre], [Direccion], [CorreoElectronico], [Telefono], [DNI], [Activo]) VALUES (2, N'Cliente B', N'Dirección B', N'clienteB@correo.com', N'444555666', N'39477188', 1)
INSERT [dbo].[Clientes] ([IdCliente], [Nombre], [Direccion], [CorreoElectronico], [Telefono], [DNI], [Activo]) VALUES (5, N'Andres', N'Combate De San Lorenzo', N'andresben18@gmail.com', N'01133277216', N'39517168', 0)
INSERT [dbo].[Clientes] ([IdCliente], [Nombre], [Direccion], [CorreoElectronico], [Telefono], [DNI], [Activo]) VALUES (6, N'Juan', N'Juan@hotmail.com', N'Juan@hotmail.com', N'1235344', N'4733633', 0)
INSERT [dbo].[Clientes] ([IdCliente], [Nombre], [Direccion], [CorreoElectronico], [Telefono], [DNI], [Activo]) VALUES (7, N'Agustin', N'agus@gmail.com', N'agus@gmail.com', N'123341', N'1234422', 1)
INSERT [dbo].[Clientes] ([IdCliente], [Nombre], [Direccion], [CorreoElectronico], [Telefono], [DNI], [Activo]) VALUES (8, N'Julian', N'Julian@hotmail.com', N'Julian@hotmail.com', N'245223', N'39517189', 1)
INSERT [dbo].[Clientes] ([IdCliente], [Nombre], [Direccion], [CorreoElectronico], [Telefono], [DNI], [Activo]) VALUES (9, N'Miguel', N'Guido 282', N'Migue@hotmail.com', N'1145223', N'3556522', 1)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Compras] ON 

INSERT [dbo].[Compras] ([IdCompra], [IdProveedor], [FechaCompra]) VALUES (1, 1, CAST(N'2024-11-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Compras] ([IdCompra], [IdProveedor], [FechaCompra]) VALUES (2, 2, CAST(N'2024-11-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Compras] ([IdCompra], [IdProveedor], [FechaCompra]) VALUES (3, 1, CAST(N'2024-11-03T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Compras] OFF
GO
SET IDENTITY_INSERT [dbo].[DetallesCompra] ON 

INSERT [dbo].[DetallesCompra] ([IdDetalleCompra], [IdCompra], [IdProducto], [Cantidad], [PrecioCompra]) VALUES (1, 1, 1, 10, CAST(1200.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallesCompra] ([IdDetalleCompra], [IdCompra], [IdProducto], [Cantidad], [PrecioCompra]) VALUES (2, 1, 2, 5, CAST(20000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallesCompra] ([IdDetalleCompra], [IdCompra], [IdProducto], [Cantidad], [PrecioCompra]) VALUES (3, 2, 1, 15, CAST(1500.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[DetallesCompra] OFF
GO
SET IDENTITY_INSERT [dbo].[DetallesVenta] ON 

INSERT [dbo].[DetallesVenta] ([IdDetalleVenta], [IdVenta], [IdProducto], [Cantidad], [PrecioUnitario], [Subtotal]) VALUES (1, 1, 1, 2, CAST(2500.00 AS Decimal(10, 2)), CAST(50.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallesVenta] ([IdDetalleVenta], [IdVenta], [IdProducto], [Cantidad], [PrecioUnitario], [Subtotal]) VALUES (2, 1, 2, 1, CAST(1500.00 AS Decimal(10, 2)), CAST(15.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[DetallesVenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Marcas] ON 

INSERT [dbo].[Marcas] ([IdMarca], [Nombre], [Activo]) VALUES (1, N'Marcayh', 1)
INSERT [dbo].[Marcas] ([IdMarca], [Nombre], [Activo]) VALUES (2, N'MarcaTe', 0)
INSERT [dbo].[Marcas] ([IdMarca], [Nombre], [Activo]) VALUES (3, N'MarcaC', 1)
INSERT [dbo].[Marcas] ([IdMarca], [Nombre], [Activo]) VALUES (4, N'Matarazzo', 0)
INSERT [dbo].[Marcas] ([IdMarca], [Nombre], [Activo]) VALUES (5, N'SantaDs', 0)
SET IDENTITY_INSERT [dbo].[Marcas] OFF
GO
INSERT [dbo].[ProductoProveedor] ([IdProducto], [IdProveedor]) VALUES (1, 1)
INSERT [dbo].[ProductoProveedor] ([IdProducto], [IdProveedor]) VALUES (2, 2)
INSERT [dbo].[ProductoProveedor] ([IdProducto], [IdProveedor]) VALUES (3, 1)
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdCategoria], [IdMarca], [Precio], [StockActual], [StockMinimo], [Activo]) VALUES (1, N'Fertilizante X', 1, 1, CAST(2000.00 AS Decimal(10, 2)), 100, 10, 1)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdCategoria], [IdMarca], [Precio], [StockActual], [StockMinimo], [Activo]) VALUES (2, N'Pesticida Y', 2, 2, CAST(7777.00 AS Decimal(10, 2)), 50, 5, 1)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdCategoria], [IdMarca], [Precio], [StockActual], [StockMinimo], [Activo]) VALUES (3, N'Sustrato Z', 3, 3, CAST(4000.00 AS Decimal(10, 2)), 200, 20, 1)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdCategoria], [IdMarca], [Precio], [StockActual], [StockMinimo], [Activo]) VALUES (5, N'Macetas', 5, 2, CAST(15000.00 AS Decimal(10, 2)), 5, 2, 1)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdCategoria], [IdMarca], [Precio], [StockActual], [StockMinimo], [Activo]) VALUES (6, N'Rastrillo', 4, 1, CAST(14000.00 AS Decimal(10, 2)), 5, 2, 1)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdCategoria], [IdMarca], [Precio], [StockActual], [StockMinimo], [Activo]) VALUES (7, N'Macetas', 5, 1, CAST(15000.00 AS Decimal(10, 2)), 5, 2, 1)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdCategoria], [IdMarca], [Precio], [StockActual], [StockMinimo], [Activo]) VALUES (8, N'Pala', 4, 1, CAST(15000.00 AS Decimal(10, 2)), 3, 2, 1)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdCategoria], [IdMarca], [Precio], [StockActual], [StockMinimo], [Activo]) VALUES (9, N'Pala Ancha', 3, 3, CAST(15000.00 AS Decimal(10, 2)), 4, 5, 1)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdCategoria], [IdMarca], [Precio], [StockActual], [StockMinimo], [Activo]) VALUES (10, N'Pala', 4, 1, CAST(15000.00 AS Decimal(10, 2)), 3, 2, 0)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdCategoria], [IdMarca], [Precio], [StockActual], [StockMinimo], [Activo]) VALUES (11, N'Pala', 4, 3, CAST(15000.00 AS Decimal(10, 2)), 3, 2, 0)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdCategoria], [IdMarca], [Precio], [StockActual], [StockMinimo], [Activo]) VALUES (12, N'Pala', 5, 3, CAST(15000.00 AS Decimal(10, 2)), 3, 2, 0)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdCategoria], [IdMarca], [Precio], [StockActual], [StockMinimo], [Activo]) VALUES (13, N'Pala fina', 4, 1, CAST(15000.00 AS Decimal(10, 2)), 3, 2, 1)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdCategoria], [IdMarca], [Precio], [StockActual], [StockMinimo], [Activo]) VALUES (14, N'Palita', 2, 3, CAST(15000.00 AS Decimal(10, 2)), 2, 2, 1)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([IdProveedor], [Nombre], [Detalle], [CorreoElectronico], [Telefono], [Activo]) VALUES (1, N'Proveedor 1', N'Viene los jueves', N'contacto@proveedor1.com', N'123456789', 0)
INSERT [dbo].[Proveedores] ([IdProveedor], [Nombre], [Detalle], [CorreoElectronico], [Telefono], [Activo]) VALUES (2, N'Proveedor 2', N'Trae macetas', N'contacto@proveedor2.com', N'987654321', 1)
INSERT [dbo].[Proveedores] ([IdProveedor], [Nombre], [Detalle], [CorreoElectronico], [Telefono], [Activo]) VALUES (5, N'Proveedor 3', N'Pagar en el momento', N'Carlos@gmail.com', N'155377416', 1)
INSERT [dbo].[Proveedores] ([IdProveedor], [Nombre], [Detalle], [CorreoElectronico], [Telefono], [Activo]) VALUES (6, N'Marce', N'viene en la mañana', N'marce@hotmail.com', N'152133124', 1)
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Nombre], [CorreoElectronico], [DNI], [Telefono], [TipoUsuario], [Activo]) VALUES (2, N'Brenda', N'brenda@hotmail.com', 384447171, N'1133277216', 1, 1)
INSERT [dbo].[Usuarios] ([IdUsuario], [Nombre], [CorreoElectronico], [DNI], [Telefono], [TipoUsuario], [Activo]) VALUES (4, N'Juancito', N'Juan@hotmail.com', 1313122, N'12333', 1, 0)
INSERT [dbo].[Usuarios] ([IdUsuario], [Nombre], [CorreoElectronico], [DNI], [Telefono], [TipoUsuario], [Activo]) VALUES (5, N'Agustin', N'Agus@gmail.com', 3817732, N'176272', 0, 1)
INSERT [dbo].[Usuarios] ([IdUsuario], [Nombre], [CorreoElectronico], [DNI], [Telefono], [TipoUsuario], [Activo]) VALUES (7, N'Isma', N'ismael@gmail.com', 367323245, N'123345123', 0, 1)
INSERT [dbo].[Usuarios] ([IdUsuario], [Nombre], [CorreoElectronico], [DNI], [Telefono], [TipoUsuario], [Activo]) VALUES (8, N'Franco', N'franco@hotmail.com', 2332133, N'12331234', 1, 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Ventas] ON 

INSERT [dbo].[Ventas] ([IdVenta], [IdCliente], [Fecha], [Total]) VALUES (1, 1, CAST(N'2024-08-17T02:33:40.330' AS DateTime), CAST(65.00 AS Decimal(10, 2)))
INSERT [dbo].[Ventas] ([IdVenta], [IdCliente], [Fecha], [Total]) VALUES (2, 1, CAST(N'2024-11-18T00:00:00.000' AS DateTime), CAST(2500.00 AS Decimal(10, 2)))
INSERT [dbo].[Ventas] ([IdVenta], [IdCliente], [Fecha], [Total]) VALUES (3, 2, CAST(N'2024-11-18T00:00:00.000' AS DateTime), CAST(1500.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Ventas] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Clientes__531402F33375632E]    Script Date: 9/12/2024 16:18:01 ******/
ALTER TABLE [dbo].[Clientes] ADD UNIQUE NONCLUSTERED 
(
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__USUARIOS__C035B8DD50CED3B1]    Script Date: 9/12/2024 16:18:01 ******/
ALTER TABLE [dbo].[Usuarios] ADD UNIQUE NONCLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_CorreoElectronico]    Script Date: 9/12/2024 16:18:01 ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [UQ_CorreoElectronico] UNIQUE NONCLUSTERED 
(
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categoria] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Marcas] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Productos] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedores] ([IdProveedor])
GO
ALTER TABLE [dbo].[DetallesCompra]  WITH CHECK ADD FOREIGN KEY([IdCompra])
REFERENCES [dbo].[Compras] ([IdCompra])
GO
ALTER TABLE [dbo].[DetallesCompra]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[DetallesVenta]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[DetallesVenta]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Ventas] ([IdVenta])
GO
ALTER TABLE [dbo].[ProductoProveedor]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[ProductoProveedor]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedores] ([IdProveedor])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marcas] ([IdMarca])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
/****** Object:  StoredProcedure [dbo].[DelCategoria]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DelCategoria]
    @IdCategoria INT
AS
BEGIN
    UPDATE Categoria SET Activo = 0 WHERE IdCategoria = @IdCategoria
END
GO
/****** Object:  StoredProcedure [dbo].[delCliente]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delCliente]
    @DNI INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [dbo].[Clientes]
    SET [Activo] = 0
    WHERE DNI = @DNI;
END;
GO
/****** Object:  StoredProcedure [dbo].[DelCompra]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DelCompra]
    @IdCompra INT
AS
BEGIN
    DELETE FROM Compras 
    WHERE IdCompra = @IdCompra
END
GO
/****** Object:  StoredProcedure [dbo].[DelMarca]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DelMarca]
    @IdMarca INT
AS
BEGIN
    UPDATE Marcas
    SET Activo = 0
    WHERE IdMarca = @IdMarca
END

GO
/****** Object:  StoredProcedure [dbo].[DelProducto]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DelProducto]
    @IdProducto INT
AS
BEGIN
    SET NOCOUNT ON;

   UPDATE Productos 
    SET Activo = 0
    WHERE IdProducto = @IdProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[delProveedor]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delProveedor]
    @IdProveedor INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Proveedores
    SET Activo = 0
    WHERE IdProveedor = @IdProveedor;
END
GO
/****** Object:  StoredProcedure [dbo].[DelUsuario]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DelUsuario]
    @IdUsuario INT
AS
BEGIN
    -- Actualiza la columna Activo a 0 en lugar de eliminar el usuario
    UPDATE USUARIOS
    SET Activo = 0
    WHERE IdUsuario = @IdUsuario;
END
GO
/****** Object:  StoredProcedure [dbo].[DelVenta]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DelVenta]
    @IdVenta INT
AS
BEGIN
    DELETE FROM Ventas
    WHERE IdVenta = @IdVenta
END
GO
/****** Object:  StoredProcedure [dbo].[insCategoria]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insCategoria]
    @Nombre NVARCHAR(100),
    @Activo BIT
AS
BEGIN
    INSERT INTO Categoria (Nombre, Activo) VALUES (@Nombre, @Activo)
END
GO
/****** Object:  StoredProcedure [dbo].[insCliente]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insCliente]
    @Nombre NVARCHAR(100),
    @Direccion NVARCHAR(200),
    @CorreoElectronico NVARCHAR(100),
    @Telefono NVARCHAR(20),
	@DNI NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Clientes (Nombre, Direccion, CorreoElectronico, Telefono, DNI, Activo)
    VALUES (@Nombre, @Direccion, @CorreoElectronico, @Telefono, @DNI, 1);
END;
GO
/****** Object:  StoredProcedure [dbo].[insCompra]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insCompra]
    @IdProveedor INT,
    @FechaCompra DATETIME
AS
BEGIN
    INSERT INTO Compras (IdProveedor, FechaCompra)
    VALUES (@IdProveedor, @FechaCompra)
END
GO
/****** Object:  StoredProcedure [dbo].[InsMarca]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsMarca]
    @Nombre NVARCHAR(100),
	@Activo BIT
AS
BEGIN
    INSERT INTO Marcas (Nombre, Activo)
    VALUES (@Nombre, @Activo)
END
GO
/****** Object:  StoredProcedure [dbo].[insProducto]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insProducto]
    @Nombre NVARCHAR(100),
    @IdCategoria INT,
    @IdMarca INT,
    @Precio DECIMAL(18, 2),
    @StockActual INT,
    @StockMinimo INT

AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Productos (Nombre, IdCategoria, IdMarca, Precio, StockActual, StockMinimo, Activo)
    VALUES (@Nombre, @IdCategoria, @IdMarca, @Precio, @StockActual, @StockMinimo, 1);
    
    SELECT SCOPE_IDENTITY() AS IdProducto; 
END;
GO
/****** Object:  StoredProcedure [dbo].[insProveedor]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insProveedor]
@Nombre NVARCHAR(100),
@Detalle NVARCHAR(200),
@CorreoElectronico NVARCHAR(100),
@Telefono NVARCHAR(20),
@Activo BIT = 1
AS
BEGIN
    INSERT INTO Proveedores (Nombre, Detalle, CorreoElectronico, Telefono, Activo)
    VALUES (@Nombre, @Detalle, @CorreoElectronico, @Telefono, @Activo);
END
GO
/****** Object:  StoredProcedure [dbo].[InsUsuario]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsUsuario]
    @Nombre NVARCHAR(100),
    @CorreoElectronico NVARCHAR(255),
    @DNI INT,
    @Telefono NVARCHAR(15),
    @TipoUsuario INT
AS
BEGIN
    INSERT INTO USUARIOS (Nombre, CorreoElectronico, DNI, Telefono, TipoUsuario,Activo )
    VALUES (@Nombre, @CorreoElectronico, @DNI, @Telefono, @TipoUsuario, 1)
END
GO
/****** Object:  StoredProcedure [dbo].[InsVenta]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsVenta]
    @IdCliente INT,
    @Fecha DATETIME,
    @Total DECIMAL(18, 2)
AS
BEGIN
    INSERT INTO Ventas (IdCliente, Fecha, Total)
    VALUES (@IdCliente, @Fecha, @Total)
END
GO
/****** Object:  StoredProcedure [dbo].[Loguear]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Loguear]
    @CorreoElectronico NVARCHAR(255),
    @DNI INT
AS
BEGIN
    SELECT IdUsuario, Nombre, TipoUsuario
    FROM USUARIOS
    WHERE CorreoElectronico = @CorreoElectronico AND DNI = @DNI
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerProductosBajoStock]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerProductosBajoStock]
AS
BEGIN
    SELECT 
        [IdProducto],
        [Nombre],
        [IdCategoria],
        [IdMarca],
        [Precio],
        [StockActual],
        [StockMinimo],
        [Activo]
    FROM [PROYECTACOMERCIO].[dbo].[Productos]
    WHERE [StockActual] <= [StockMinimo]
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuarioPorId]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerUsuarioPorId]
    @IdUsuario INT
AS
BEGIN
    SELECT IdUsuario, Nombre, CorreoElectronico, DNI, Telefono, TipoUsuario, Activo
    FROM USUARIOS
    WHERE IdUsuario = @IdUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[SelCategorias]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelCategorias]
AS
BEGIN
    SELECT IdCategoria, Nombre, Activo 
    FROM Categoria 
 
END
GO
/****** Object:  StoredProcedure [dbo].[SelCategoriasActivas]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelCategoriasActivas]
AS
BEGIN
    SELECT IdCategoria, Nombre, Activo
    FROM Categoria
    WHERE Activo = 1; -- Opcional: Filtrar solo categorías activas.
END
GO
/****** Object:  StoredProcedure [dbo].[SelClientePorId]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelClientePorId]
    @DNI INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdCliente, 
        Nombre, 
        Direccion, 
        CorreoElectronico, 
        Telefono,
		DNI
    FROM 
        Clientes 
    WHERE 
        DNI = @DNI
		AND Activo = 1;
END

GO
/****** Object:  StoredProcedure [dbo].[SelClientes]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelClientes]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdCliente, 
        Nombre, 
        Direccion, 
        CorreoElectronico, 
        Telefono, 
		DNI
    FROM 
        Clientes
		WHERE
        Activo = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[SelCompraPorId]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelCompraPorId]
    @IdCompra INT
AS
BEGIN
    SELECT 
        c.IdCompra, 
        c.IdProveedor, 
        p.Nombre AS NombreProveedor, 
        c.FechaCompra 
    FROM 
        Compras c
    INNER JOIN 
        Proveedores p ON c.IdProveedor = p.IdProveedor  
    WHERE 
        c.IdCompra = @IdCompra
END
GO
/****** Object:  StoredProcedure [dbo].[SelCompras]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelCompras]
AS
BEGIN
    SELECT 
        c.IdCompra, 
        c.IdProveedor, 
        p.Nombre AS NombreProveedor,  
        c.FechaCompra 
    FROM 
        Compras c
    INNER JOIN 
        Proveedores p ON c.IdProveedor = p.IdProveedor  
END
GO
/****** Object:  StoredProcedure [dbo].[SelDetallesCompra]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelDetallesCompra]
    @IdCompra INT
AS
BEGIN
    SELECT 
        dc.IdDetalleCompra, 
        dc.IdProducto, 
        p.Nombre,  
        dc.Cantidad, 
        dc.PrecioCompra 
    FROM 
        DetallesCompra dc
    INNER JOIN 
        Productos p ON dc.IdProducto = p.IdProducto  
    WHERE 
        dc.IdCompra = @IdCompra
END
GO
/****** Object:  StoredProcedure [dbo].[SelDetallesPorVenta]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelDetallesPorVenta]
    @IdVenta INT
AS
BEGIN
    SELECT 
        DV.IdDetalleVenta, 
        DV.IdVenta, 
        DV.IdProducto, 
        P.Nombre AS NombreProducto,  
        DV.Cantidad, 
        DV.PrecioUnitario, 
        DV.Subtotal
    FROM DetallesVenta DV
    INNER JOIN Productos P ON DV.IdProducto = P.IdProducto  
    WHERE DV.IdVenta = @IdVenta
END
GO
/****** Object:  StoredProcedure [dbo].[SelDetallesVenta]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelDetallesVenta]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP (1000) 
        DV.[IdDetalleVenta], 
        DV.[IdVenta], 
        DV.[IdProducto], 
        P.Nombre AS NombreProducto, 
        DV.[Cantidad], 
        DV.[PrecioUnitario], 
        (DV.[Cantidad] * DV.[PrecioUnitario]) AS Subtotal  
    FROM [PROYECTACOMERCIO].[dbo].[DetallesVenta] DV
    INNER JOIN [PROYECTACOMERCIO].[dbo].[Productos] P ON DV.IdProducto = P.IdProducto
END
GO
/****** Object:  StoredProcedure [dbo].[SelMarcaPorId]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelMarcaPorId]
    @IdMarca INT
AS
BEGIN
    SELECT IdMarca, Nombre, Activo
    FROM Marcas
    WHERE IdMarca = @IdMarca
END
GO
/****** Object:  StoredProcedure [dbo].[SelMarcas]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelMarcas]
AS
BEGIN
    SELECT IdMarca, Nombre, Activo
    FROM Marcas
END
GO
/****** Object:  StoredProcedure [dbo].[SelMarcasActivas]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelMarcasActivas]
AS
BEGIN
    SELECT IdMarca, Nombre, Activo
    FROM Marcas
    WHERE Activo = 1; -- Opcional: Filtrar solo marcas activas.
END
GO
/****** Object:  StoredProcedure [dbo].[SelProductoPorId]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelProductoPorId]
    @IdProducto INT
AS
BEGIN
    SELECT IdProducto, Nombre, IdCategoria, IdMarca, Precio, StockActual, StockMinimo
    FROM Productos
    WHERE IdProducto = @IdProducto
	AND Activo = 1
END
GO
/****** Object:  StoredProcedure [dbo].[SelProductoPorNombre]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelProductoPorNombre]
    @Nombre NVARCHAR(100)
AS
BEGIN
    SELECT IdProducto, Nombre, IdCategoria, IdMarca, Precio, StockActual, StockMinimo
    FROM Productos
    WHERE Nombre LIKE '%' + @Nombre + '%'
	  AND Activo = 1 -- Solo devolver productos activos

END
GO
/****** Object:  StoredProcedure [dbo].[SelProductos]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelProductos]
AS
BEGIN
    -- Selecciona todos los productos
    SELECT 
        IdProducto,
        Nombre,
        IdCategoria,
        IdMarca,
        Precio,
        StockActual,
        StockMinimo
    FROM 
        dbo.Productos
	WHERE 
        Activo = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[SelProductosConDetalles]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelProductosConDetalles]
AS
BEGIN
    SELECT 
        p.IdProducto,
        p.Nombre,
        c.IdCategoria,  -- ID de la categoría
        c.Nombre AS NombreCategoria,
        m.IdMarca,      -- ID de la marca
        m.Nombre AS NombreMarca,
        p.Precio,
        p.StockActual,
        p.StockMinimo
    FROM 
        Productos p
    INNER JOIN Categoria c ON p.IdCategoria = c.IdCategoria
    INNER JOIN Marcas m ON p.IdMarca = m.IdMarca
	WHERE 
        p.Activo = 1; 
END
GO
/****** Object:  StoredProcedure [dbo].[SelProductosPorNombre]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelProductosPorNombre]
    @Nombre NVARCHAR(100)
AS
BEGIN
    SELECT IdProducto, Nombre, IdCategoria, IdMarca, Precio, StockActual, StockMinimo
    FROM Productos
    WHERE Nombre LIKE @Nombre AND Activo = 1
END
GO
/****** Object:  StoredProcedure [dbo].[SelProveedores]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelProveedores]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IdProveedor, Nombre, Detalle, CorreoElectronico, Telefono, Activo
    FROM Proveedores
	WHERE Activo = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[selProveedorPorId]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[selProveedorPorId]
    @IdProveedor INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IdProveedor, Nombre, Detalle, CorreoElectronico, Telefono, Activo
    FROM Proveedores
    WHERE IdProveedor = @IdProveedor
	AND Activo = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[SelTotalClientes]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelTotalClientes]
AS
BEGIN
    SELECT COUNT(*) AS TotalClientes
    FROM Clientes;  
END;
GO
/****** Object:  StoredProcedure [dbo].[SelTotalProductos]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelTotalProductos]
AS
BEGIN
    SELECT COUNT(*) AS TotalProductos
    FROM Productos  
    WHERE StockActual > 0;  
END;
GO
/****** Object:  StoredProcedure [dbo].[SelTotalProveedores]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelTotalProveedores]
AS
BEGIN
    SELECT COUNT(*) AS TotalProveedores
    FROM Proveedores 
    WHERE Activo = 1;  
END;
GO
/****** Object:  StoredProcedure [dbo].[SelTotalVentasMes]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelTotalVentasMes]
AS
BEGIN
    SELECT SUM(Total) AS TotalVentas
    FROM Ventas
    WHERE MONTH(Fecha) = MONTH(GETDATE()) AND YEAR(Fecha) = YEAR(GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[SelUsuariosCompleto]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelUsuariosCompleto]
AS
BEGIN
    SELECT IdUsuario, Nombre, CorreoElectronico, DNI, Telefono, TipoUsuario, Activo
    FROM USUARIOS
	WHERE Activo = 1
END
GO
/****** Object:  StoredProcedure [dbo].[SelVentas]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelVentas]
AS
BEGIN
    SELECT V.IdVenta, 
           V.IdCliente, 
           C.Nombre AS NombreCliente, 
           V.Fecha, 
           V.Total
    FROM Ventas V
    INNER JOIN Clientes C ON V.IdCliente = C.IdCliente
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerCategoriaPorId]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerCategoriaPorId]
    @IdCategoria INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdCategoria,
        Nombre,
        Activo
    FROM 
        Categoria
    WHERE 
        IdCategoria = @IdCategoria;
END;
GO
/****** Object:  StoredProcedure [dbo].[updCategoria]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updCategoria]
    @IdCategoria INT,
    @Nombre NVARCHAR(100),
    @Activo BIT
AS
BEGIN
    UPDATE Categoria SET Nombre = @Nombre, Activo = @Activo WHERE IdCategoria = @IdCategoria
END
GO
/****** Object:  StoredProcedure [dbo].[updCliente]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updCliente]
    @IdCliente INT,
    @Nombre NVARCHAR(100),
    @Direccion NVARCHAR(200),
    @CorreoElectronico NVARCHAR(100),
    @Telefono NVARCHAR(20),
	@DNI NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Clientes
    SET Nombre = @Nombre,
        Direccion = @Direccion,
        CorreoElectronico = @CorreoElectronico,
        Telefono = @Telefono,
		DNI= @DNI
    WHERE DNI = @DNI;
END;
GO
/****** Object:  StoredProcedure [dbo].[updCompra]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updCompra]
    @IdCompra INT,
    @IdProveedor INT,
    @FechaCompra DATETIME
AS
BEGIN
    UPDATE Compras
    SET IdProveedor = @IdProveedor, FechaCompra = @FechaCompra
    WHERE IdCompra = @IdCompra
END
GO
/****** Object:  StoredProcedure [dbo].[UpdMarca]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdMarca]
    @IdMarca INT,
    @Nombre NVARCHAR(255),
    @Activo BIT -- Agregar el parámetro para el estado activo
AS
BEGIN
    UPDATE Marcas
    SET 
        Nombre = @Nombre,
        Activo = @Activo -- Actualizar el estado activo
    WHERE IdMarca = @IdMarca
END
GO
/****** Object:  StoredProcedure [dbo].[updProducto]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updProducto]
    @IdProducto INT,
    @Nombre NVARCHAR(100),
    @IdCategoria INT,
    @IdMarca INT,
    @Precio DECIMAL(18, 2),
    @StockActual INT,
    @StockMinimo INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Productos
    SET Nombre = @Nombre,
        IdCategoria = @IdCategoria,
        IdMarca = @IdMarca,
        Precio = @Precio,
        StockActual = @StockActual,
        StockMinimo = @StockMinimo
    WHERE IdProducto = @IdProducto
	AND Activo = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[updProveedor]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updProveedor]
    @IdProveedor INT,
    @Nombre NVARCHAR(100),
    @Detalle NVARCHAR(200),
    @CorreoElectronico NVARCHAR(100),
    @Telefono NVARCHAR(20),
	@Activo BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Proveedores
    SET Nombre = @Nombre,
        Detalle = @Detalle,
        CorreoElectronico = @CorreoElectronico,
        Telefono = @Telefono,
		Activo = @Activo
    WHERE IdProveedor = @IdProveedor;
END
GO
/****** Object:  StoredProcedure [dbo].[updUsuario]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updUsuario]
    @IdUsuario INT,
    @Nombre NVARCHAR(100),
    @CorreoElectronico NVARCHAR(100),
    @DNI INT,
    @Telefono NVARCHAR(15),
    @TipoUsuario INT
	
AS
BEGIN
    UPDATE USUARIOS
    SET Nombre = @Nombre,
        CorreoElectronico = @CorreoElectronico,
        DNI = @DNI,
        Telefono = @Telefono,
        TipoUsuario = @TipoUsuario,
		 Activo = 1
    WHERE IdUsuario = @IdUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[UpdVenta]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdVenta]
    @IdVenta INT,
    @IdCliente INT,
    @Fecha DATETIME,
    @Total DECIMAL(18, 2)
AS
BEGIN
    UPDATE Ventas
    SET IdCliente = @IdCliente, Fecha = @Fecha, Total = @Total
    WHERE IdVenta = @IdVenta
END
GO
/****** Object:  StoredProcedure [dbo].[verificarUsuarioExistente]    Script Date: 9/12/2024 16:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[verificarUsuarioExistente]
    @DNI INT,
    @CorreoElectronico NVARCHAR(255)
AS
BEGIN
    DECLARE @Existe INT;
    SELECT @Existe = COUNT(*)
    FROM USUARIOS
    WHERE (DNI = @DNI OR CorreoElectronico = @CorreoElectronico) AND Activo = 1;
    
    SELECT @Existe AS Existe;
END
GO
USE [master]
GO
ALTER DATABASE [PROYECTACOMERCIO] SET  READ_WRITE 
GO
