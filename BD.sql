USE [master]
GO
/****** Object:  Database [PLANTANOBLE]    Script Date: 19/10/2024 21:27:24 ******/
CREATE DATABASE [PLANTANOBLE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PLANTANOBLE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PLANTANOBLE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PLANTANOBLE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PLANTANOBLE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PLANTANOBLE] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PLANTANOBLE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PLANTANOBLE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET ARITHABORT OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PLANTANOBLE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PLANTANOBLE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PLANTANOBLE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PLANTANOBLE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PLANTANOBLE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PLANTANOBLE] SET  MULTI_USER 
GO
ALTER DATABASE [PLANTANOBLE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PLANTANOBLE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PLANTANOBLE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PLANTANOBLE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PLANTANOBLE] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PLANTANOBLE] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PLANTANOBLE] SET QUERY_STORE = ON
GO
ALTER DATABASE [PLANTANOBLE] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PLANTANOBLE]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 19/10/2024 21:27:24 ******/
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
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesVenta]    Script Date: 19/10/2024 21:27:24 ******/
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
/****** Object:  Table [dbo].[Marcas]    Script Date: 19/10/2024 21:27:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoProveedor]    Script Date: 19/10/2024 21:27:24 ******/
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
/****** Object:  Table [dbo].[Productos]    Script Date: 19/10/2024 21:27:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[IdTipo] [int] NULL,
	[IdMarca] [int] NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[StockActual] [int] NOT NULL,
	[StockMinimo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 19/10/2024 21:27:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Direccion] [varchar](255) NULL,
	[CorreoElectronico] [varchar](100) NULL,
	[Telefono] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos]    Script Date: 19/10/2024 21:27:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos](
	[IdTipo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 19/10/2024 21:27:24 ******/
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
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([IdCliente], [Nombre], [Direccion], [CorreoElectronico], [Telefono]) VALUES (1, N'Cliente A', N'Dirección A', N'clienteA@correo.com', N'111222333')
INSERT [dbo].[Clientes] ([IdCliente], [Nombre], [Direccion], [CorreoElectronico], [Telefono]) VALUES (2, N'Cliente B', N'Dirección B', N'clienteB@correo.com', N'444555666')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[DetallesVenta] ON 

INSERT [dbo].[DetallesVenta] ([IdDetalleVenta], [IdVenta], [IdProducto], [Cantidad], [PrecioUnitario], [Subtotal]) VALUES (1, 1, 1, 2, CAST(25.00 AS Decimal(10, 2)), CAST(50.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallesVenta] ([IdDetalleVenta], [IdVenta], [IdProducto], [Cantidad], [PrecioUnitario], [Subtotal]) VALUES (2, 1, 2, 1, CAST(15.00 AS Decimal(10, 2)), CAST(15.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[DetallesVenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Marcas] ON 

INSERT [dbo].[Marcas] ([IdMarca], [Nombre]) VALUES (1, N'MarcaA')
INSERT [dbo].[Marcas] ([IdMarca], [Nombre]) VALUES (2, N'MarcaB')
INSERT [dbo].[Marcas] ([IdMarca], [Nombre]) VALUES (3, N'MarcaC')
SET IDENTITY_INSERT [dbo].[Marcas] OFF
GO
INSERT [dbo].[ProductoProveedor] ([IdProducto], [IdProveedor]) VALUES (1, 1)
INSERT [dbo].[ProductoProveedor] ([IdProducto], [IdProveedor]) VALUES (2, 2)
INSERT [dbo].[ProductoProveedor] ([IdProducto], [IdProveedor]) VALUES (3, 1)
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdTipo], [IdMarca], [Precio], [StockActual], [StockMinimo]) VALUES (1, N'Fertilizante X', 1, 1, CAST(25.00 AS Decimal(10, 2)), 100, 10)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdTipo], [IdMarca], [Precio], [StockActual], [StockMinimo]) VALUES (2, N'Pesticida Y', 2, 2, CAST(15.00 AS Decimal(10, 2)), 50, 5)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [IdTipo], [IdMarca], [Precio], [StockActual], [StockMinimo]) VALUES (3, N'Sustrato Z', 3, 3, CAST(10.00 AS Decimal(10, 2)), 200, 20)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([IdProveedor], [Nombre], [Direccion], [CorreoElectronico], [Telefono]) VALUES (1, N'Proveedor 1', N'Dirección 1', N'contacto@proveedor1.com', N'123456789')
INSERT [dbo].[Proveedores] ([IdProveedor], [Nombre], [Direccion], [CorreoElectronico], [Telefono]) VALUES (2, N'Proveedor 2', N'Dirección 2', N'contacto@proveedor2.com', N'987654321')
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipos] ON 

INSERT [dbo].[Tipos] ([IdTipo], [Nombre]) VALUES (1, N'Fertilizante')
INSERT [dbo].[Tipos] ([IdTipo], [Nombre]) VALUES (2, N'Pesticida')
INSERT [dbo].[Tipos] ([IdTipo], [Nombre]) VALUES (3, N'Sustrato')
SET IDENTITY_INSERT [dbo].[Tipos] OFF
GO
SET IDENTITY_INSERT [dbo].[Ventas] ON 

INSERT [dbo].[Ventas] ([IdVenta], [IdCliente], [Fecha], [Total]) VALUES (1, 1, CAST(N'2024-08-17T02:33:40.330' AS DateTime), CAST(65.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Ventas] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Clientes__531402F33375632E]    Script Date: 19/10/2024 21:27:24 ******/
ALTER TABLE [dbo].[Clientes] ADD UNIQUE NONCLUSTERED 
(
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([IdTipo])
REFERENCES [dbo].[Tipos] ([IdTipo])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
/****** Object:  StoredProcedure [dbo].[SelProductoPorId]    Script Date: 19/10/2024 21:27:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelProductoPorId]
    @IdProducto INT
AS
BEGIN
    SELECT IdProducto, Nombre, IdTipo, IdMarca, Precio, StockActual, StockMinimo
    FROM Productos
    WHERE IdProducto = @IdProducto
END
GO
/****** Object:  StoredProcedure [dbo].[SelProductos]    Script Date: 19/10/2024 21:27:24 ******/
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
        IdTipo,
        IdMarca,
        Precio,
        StockActual,
        StockMinimo
    FROM 
        dbo.Productos;
END
GO
USE [master]
GO
ALTER DATABASE [PLANTANOBLE] SET  READ_WRITE 
GO
