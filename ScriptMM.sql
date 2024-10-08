USE [master]
GO
/****** Object:  Database [MarketMateDB]    Script Date: 1/10/2024 20:45:45 ******/
CREATE DATABASE [MarketMateDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MarketMateDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MarketMateDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MarketMateDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MarketMateDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MarketMateDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MarketMateDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MarketMateDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MarketMateDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MarketMateDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MarketMateDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MarketMateDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MarketMateDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MarketMateDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MarketMateDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MarketMateDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MarketMateDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MarketMateDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MarketMateDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MarketMateDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MarketMateDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MarketMateDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MarketMateDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MarketMateDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MarketMateDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MarketMateDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MarketMateDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MarketMateDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MarketMateDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MarketMateDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MarketMateDB] SET  MULTI_USER 
GO
ALTER DATABASE [MarketMateDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MarketMateDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MarketMateDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MarketMateDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MarketMateDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MarketMateDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MarketMateDB', N'ON'
GO
ALTER DATABASE [MarketMateDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [MarketMateDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MarketMateDB]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[CodigoCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Dni] [char](8) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](254) NOT NULL,
	[Telefono] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesOrdenCompra]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesOrdenCompra](
	[NumeroOrden] [int] NOT NULL,
	[CodigoProducto] [int] NOT NULL,
	[CantidadSolicitada] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK__Detalles__1FF58BE3BC603FD1] PRIMARY KEY CLUSTERED 
(
	[NumeroOrden] ASC,
	[CodigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesRecepcion]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesRecepcion](
	[NumeroRecepcion] [int] NOT NULL,
	[CodigoProducto] [int] NOT NULL,
	[CantidadRecibida] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroRecepcion] ASC,
	[CodigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesSolicitud]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesSolicitud](
	[NumeroSolicitud] [int] NOT NULL,
	[CodigoProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroSolicitud] ASC,
	[CodigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesVenta]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesVenta](
	[NumeroTicket] [int] NOT NULL,
	[CodigoProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroTicket] ASC,
	[CodigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eventos]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eventos](
	[EventoID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Hora] [time](0) NOT NULL,
	[Modulo] [nvarchar](50) NOT NULL,
	[Operacion] [nvarchar](100) NOT NULL,
	[Criticidad] [int] NOT NULL,
 CONSTRAINT [PK__Eventos__1EEB59011DDACD7A] PRIMARY KEY CLUSTERED 
(
	[EventoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[NumeroFactura] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[MontoTotal] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[CodigoMarca] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenesCompra]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenesCompra](
	[NumeroOrden] [int] IDENTITY(1,1) NOT NULL,
	[FechaEmision] [datetime] NOT NULL,
	[FechaLimiteEntrega] [datetime] NOT NULL,
	[CUIT] [nvarchar](11) NOT NULL,
	[NumeroSolicitud] [int] NOT NULL,
	[NumeroCotizacion] [int] NOT NULL,
	[Estado] [nvarchar](50) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[NumeroTransferencia] [nvarchar](25) NULL,
 CONSTRAINT [PK__OrdenesC__9A75529412717D19] PRIMARY KEY CLUSTERED 
(
	[NumeroOrden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Tipo] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos1]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos1](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Tipo] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermisosPermisos]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermisosPermisos](
	[PermisoPadreCod] [int] NOT NULL,
	[PermisoHijoCod] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PermisoPadreCod] ASC,
	[PermisoHijoCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermisosRoles]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermisosRoles](
	[PermisoCod] [int] NOT NULL,
	[RolCod] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PermisoCod] ASC,
	[RolCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[CodigoProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Stock] [int] NOT NULL,
	[CodigoCategoria] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[CodigoMarca] [int] NOT NULL,
	[StockMinimo] [int] NOT NULL,
	[StockMaximo] [int] NOT NULL,
	[Act_B] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos_C]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos_C](
	[CambioID] [int] IDENTITY(1,1) NOT NULL,
	[CodigoProducto] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Hora] [time](4) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Stock] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Act] [bit] NOT NULL,
 CONSTRAINT [PK__Producto__3B5F60400925AA14] PRIMARY KEY CLUSTERED 
(
	[CambioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[CUIT] [nvarchar](11) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[RazonSocial] [nvarchar](150) NOT NULL,
	[Telefono] [bigint] NOT NULL,
	[Correo] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](200) NULL,
	[Banco] [nvarchar](100) NULL,
	[TipoCuenta] [nvarchar](50) NULL,
	[NumCuenta] [nvarchar](50) NULL,
	[CBU] [nvarchar](22) NULL,
	[Alias] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CUIT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProveedoresSolicitudes]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProveedoresSolicitudes](
	[NumeroSolicitud] [int] NOT NULL,
	[CUIT] [nvarchar](11) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroSolicitud] ASC,
	[CUIT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recepciones]    Script Date: 1/10/2024 20:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recepciones](
	[NumeroRecepcion] [int] IDENTITY(1,1) NOT NULL,
	[NumeroOrden] [int] NOT NULL,
	[FechaRecepcion] [datetime] NOT NULL,
	[EstadoRecepcion] [nvarchar](50) NOT NULL,
	[NumeroFactura] [int] NOT NULL,
	[MontoFactura] [numeric](18, 2) NOT NULL,
	[FechaFactura] [datetime] NOT NULL,
 CONSTRAINT [PK__Recepcio__009EBA2CC139AC96] PRIMARY KEY CLUSTERED 
(
	[NumeroRecepcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SolicitudesCotizacion]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolicitudesCotizacion](
	[NumeroSolicitud] [int] IDENTITY(1,1) NOT NULL,
	[FechaSolicitud] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[NumeroTicket] [int] IDENTITY(1,1) NOT NULL,
	[NumeroTransaccionBancaria] [int] NULL,
	[MetodoPago] [nvarchar](50) NULL,
	[TipoTarjeta] [nvarchar](50) NULL,
	[NumeroTarjeta] [numeric](4, 0) NULL,
	[AliasMP] [nvarchar](100) NULL,
	[Fecha] [date] NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[DniCliente] [char](8) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroTicket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Dni] [char](8) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](254) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](64) NOT NULL,
	[Bloqueo] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
	[Rol] [int] NOT NULL,
	[Idioma] [varchar](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([CodigoCategoria], [Nombre], [Descripcion]) VALUES (1, N'Lácteos', N'Productos derivados de la leche')
INSERT [dbo].[Categorias] ([CodigoCategoria], [Nombre], [Descripcion]) VALUES (2, N'Bebidas Frías', N'Bebidas frías no alcohólicas y alcohólicas')
INSERT [dbo].[Categorias] ([CodigoCategoria], [Nombre], [Descripcion]) VALUES (3, N'Ingredientes para Bebidas Calientes', N'Productos utilizados para preparar bebidas calientes como café y té')
INSERT [dbo].[Categorias] ([CodigoCategoria], [Nombre], [Descripcion]) VALUES (4, N'Carnes', N'Todo tipo de carnes frescas')
INSERT [dbo].[Categorias] ([CodigoCategoria], [Nombre], [Descripcion]) VALUES (5, N'Enlatados', N'Alimentos empaquetados en latas selladas para su conservación')
INSERT [dbo].[Categorias] ([CodigoCategoria], [Nombre], [Descripcion]) VALUES (6, N'Snacks', N'Aperitivos y comidas ligeras listos para comer')
INSERT [dbo].[Categorias] ([CodigoCategoria], [Nombre], [Descripcion]) VALUES (7, N'Cuidado Personal', N'Productos relacionados con la higiene y el cuidado personal')
INSERT [dbo].[Categorias] ([CodigoCategoria], [Nombre], [Descripcion]) VALUES (8, N'Salsas', N'Condimentos líquidos utilizados para acompañar alimentos')
INSERT [dbo].[Categorias] ([CodigoCategoria], [Nombre], [Descripcion]) VALUES (9, N'Condimentos', N'Ingredientes que agregan sabor o realzan el sabor de los alimentos')
INSERT [dbo].[Categorias] ([CodigoCategoria], [Nombre], [Descripcion]) VALUES (10, N'Pasta y Granos', N'Variedades de pasta, arroz, cereales y otros granos')
INSERT [dbo].[Categorias] ([CodigoCategoria], [Nombre], [Descripcion]) VALUES (11, N'Endulzantes y Edulcorantes', N'Productos utilizados para endulzar alimentos o bebidas')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [Correo], [Telefono]) VALUES (N'77777777', N'Roberto', N'Bravo', N'RZeVqWHexUSDLci21xUxqeZX2KyKeD6ilq6KYgJDTBw=', 1234567890)
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [Correo], [Telefono]) VALUES (N'88888888', N'Rodolfin', N'Bravo', N'RZeVqWHexUSDLci21xUxqeZX2KyKeD6ilq6KYgJDTBw=', 1234567890)
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [Correo], [Telefono]) VALUES (N'99999999', N'Juan', N'Bravo', N'ZhE9g/vtTiEof9aZtxr9tlNax0jEJYmjgX/+TZ/atHo=', 1234567890)
GO
SET IDENTITY_INSERT [dbo].[Eventos] ON 

INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1, N'11111111Santy', CAST(N'2024-09-03' AS Date), CAST(N'09:26:41' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2, N'11111111Santy', CAST(N'2024-09-03' AS Date), CAST(N'09:27:37' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3, N'11111111Santy', CAST(N'2024-09-03' AS Date), CAST(N'09:47:19' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (4, N'11111111Santy', CAST(N'2024-09-03' AS Date), CAST(N'09:49:00' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (5, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'10:37:56' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (6, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'10:41:01' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (7, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'10:42:36' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (8, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'10:46:11' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (9, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'10:49:15' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (10, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'10:49:47' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (11, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'10:50:09' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (12, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'10:50:58' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (13, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'10:59:53' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (14, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:01:50' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (15, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:03:20' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (16, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:06:35' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (17, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:09:55' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (18, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:19:20' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (19, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:20:09' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (20, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:27:16' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (21, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:27:31' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (22, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:30:24' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (23, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:31:21' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (24, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:32:37' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (25, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:32:53' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (26, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:51:16' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (27, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:52:12' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (28, N'11111111Santy', CAST(N'2024-09-17' AS Date), CAST(N'11:53:39' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (29, N'11111111Santy', CAST(N'2024-09-18' AS Date), CAST(N'12:09:57' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (30, N'11111111Santy', CAST(N'2024-10-01' AS Date), CAST(N'07:03:09' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (31, N'11111111Santy', CAST(N'2024-10-01' AS Date), CAST(N'07:03:52' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (32, N'11111111Santy', CAST(N'2024-10-01' AS Date), CAST(N'07:04:01' AS Time), N'Respaldos', N'Backup', 5)
SET IDENTITY_INSERT [dbo].[Eventos] OFF
GO
SET IDENTITY_INSERT [dbo].[Marcas] ON 

INSERT [dbo].[Marcas] ([CodigoMarca], [Nombre]) VALUES (1, N'La Serenísima')
INSERT [dbo].[Marcas] ([CodigoMarca], [Nombre]) VALUES (2, N'Sancor')
INSERT [dbo].[Marcas] ([CodigoMarca], [Nombre]) VALUES (3, N'Coca-Cola')
INSERT [dbo].[Marcas] ([CodigoMarca], [Nombre]) VALUES (4, N'Pepsi')
SET IDENTITY_INSERT [dbo].[Marcas] OFF
GO
SET IDENTITY_INSERT [dbo].[Permisos] ON 

INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (21, N'Login', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (22, N'Logout', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (23, N'Cambiar Clave', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (24, N'Cambiar Idioma', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (25, N'Admin', N'Familia')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (26, N'Gestion Usuarios', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (27, N'Gestion Perfiles', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (28, N'Maestros', N'Familia')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (29, N'Clientes', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (30, N'Inventario', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (31, N'Proveedores', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (32, N'Ventas', N'Familia')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (33, N'Generar Ticket', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (34, N'Administrador', N'Rol')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (35, N'Vendedor', N'Rol')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (36, N'Vendedor2', N'Rol')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (1020, N'F1', N'Familia')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (1021, N'Usuario', N'Familia')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (1022, N'Reportes', N'Familia')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (1023, N'Tickets', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (3020, N'AuditoriaEventos', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (3021, N'AuditoriaCambios', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (3022, N'Respaldos', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (3023, N'GenerarSolicitudCotizacion', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (3024, N'GenerarOrdenCompra', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (3025, N'Recepcion', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (3026, N'Compras', N'Familia')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (3027, N'Comprador', N'Rol')
SET IDENTITY_INSERT [dbo].[Permisos] OFF
GO
SET IDENTITY_INSERT [dbo].[Permisos1] ON 

INSERT [dbo].[Permisos1] ([Codigo], [Nombre], [Tipo]) VALUES (1, N'Usuario', N'Familia')
INSERT [dbo].[Permisos1] ([Codigo], [Nombre], [Tipo]) VALUES (2, N'Login', N'Patente')
INSERT [dbo].[Permisos1] ([Codigo], [Nombre], [Tipo]) VALUES (3, N'Logout', N'Patente')
INSERT [dbo].[Permisos1] ([Codigo], [Nombre], [Tipo]) VALUES (4, N'Cambiar Clave', N'Patente')
INSERT [dbo].[Permisos1] ([Codigo], [Nombre], [Tipo]) VALUES (5, N'Cambiar Idioma', N'Patente')
INSERT [dbo].[Permisos1] ([Codigo], [Nombre], [Tipo]) VALUES (6, N'Admin', N'Familia')
INSERT [dbo].[Permisos1] ([Codigo], [Nombre], [Tipo]) VALUES (7, N'Gestion Usuarios', N'Patente')
INSERT [dbo].[Permisos1] ([Codigo], [Nombre], [Tipo]) VALUES (8, N'Gestion Perfiles', N'Patente')
INSERT [dbo].[Permisos1] ([Codigo], [Nombre], [Tipo]) VALUES (9, N'Ventas', N'Familia')
INSERT [dbo].[Permisos1] ([Codigo], [Nombre], [Tipo]) VALUES (10, N'GenerarTicket', N'Patente')
INSERT [dbo].[Permisos1] ([Codigo], [Nombre], [Tipo]) VALUES (14, N'Administrador', N'Rol')
SET IDENTITY_INSERT [dbo].[Permisos1] OFF
GO
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (25, 26)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (25, 27)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (25, 3020)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (25, 3021)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (25, 3022)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (28, 29)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (28, 30)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (28, 31)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (32, 33)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (34, 25)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (34, 28)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (34, 1021)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (34, 1022)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (35, 32)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (35, 1021)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (36, 29)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (36, 32)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (36, 1021)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (1021, 21)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (1021, 22)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (1021, 23)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (1021, 24)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (1022, 1023)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 31)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 3021)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 3023)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 3024)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 3025)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3027, 1021)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3027, 3026)
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [CodigoMarca], [StockMinimo], [StockMaximo], [Act_B]) VALUES (1005, N'Leche', 100, 1, CAST(3.00 AS Decimal(18, 2)), 1, 10, 200, 0)
INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [CodigoMarca], [StockMinimo], [StockMaximo], [Act_B]) VALUES (1006, N'Queso', 50, 1, CAST(5.50 AS Decimal(18, 2)), 1, 5, 100, 0)
INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [CodigoMarca], [StockMinimo], [StockMaximo], [Act_B]) VALUES (1007, N'Yogur', 80, 1, CAST(2.00 AS Decimal(18, 2)), 1, 20, 150, 0)
INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [CodigoMarca], [StockMinimo], [StockMaximo], [Act_B]) VALUES (1008, N'Agua Mineral', 120, 2, CAST(1.50 AS Decimal(18, 2)), 3, 15, 250, 0)
INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [CodigoMarca], [StockMinimo], [StockMaximo], [Act_B]) VALUES (1009, N'Gaseosa', 80, 2, CAST(2.00 AS Decimal(18, 2)), 3, 10, 200, 0)
INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [CodigoMarca], [StockMinimo], [StockMaximo], [Act_B]) VALUES (1010, N'Cerveza', 60, 2, CAST(3.00 AS Decimal(18, 2)), 4, 5, 100, 0)
INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [CodigoMarca], [StockMinimo], [StockMaximo], [Act_B]) VALUES (1014, N'Mantequilla', 160, 1, CAST(4.00 AS Decimal(18, 2)), 1, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos_C] ON 

INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (2, 1014, CAST(N'2024-09-17' AS Date), CAST(N'23:18:56' AS Time), N'Mantequilla', 150, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (3, 1014, CAST(N'2024-09-17' AS Date), CAST(N'23:32:58' AS Time), N'Mantequilla', 150, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (4, 1014, CAST(N'2024-09-17' AS Date), CAST(N'23:35:37' AS Time), N'Mantequilla', 150, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (5, 1014, CAST(N'2024-09-17' AS Date), CAST(N'23:39:03' AS Time), N'Mantequilla', 150, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (6, 1014, CAST(N'2024-09-17' AS Date), CAST(N'23:41:03' AS Time), N'Mantequilla', 150, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (7, 1014, CAST(N'2024-09-17' AS Date), CAST(N'23:41:30' AS Time), N'Mantequilla', 151, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (8, 1014, CAST(N'2024-09-17' AS Date), CAST(N'23:45:28' AS Time), N'Mantequilla', 151, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (9, 1014, CAST(N'2024-09-17' AS Date), CAST(N'23:49:12' AS Time), N'Mantequilla', 151, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (10, 1014, CAST(N'2024-09-17' AS Date), CAST(N'23:49:22' AS Time), N'Mantequilla', 152, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (11, 1014, CAST(N'2024-09-17' AS Date), CAST(N'23:53:53' AS Time), N'Mantequilla', 155, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (12, 1014, CAST(N'2024-09-17' AS Date), CAST(N'23:54:48' AS Time), N'Mantequilla', 150, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (13, 1014, CAST(N'2024-09-17' AS Date), CAST(N'23:56:41' AS Time), N'Mantequilla', 152, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (14, 1014, CAST(N'2024-09-17' AS Date), CAST(N'23:59:20' AS Time), N'Mantequilla', 152, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (15, 1014, CAST(N'2024-09-18' AS Date), CAST(N'00:01:14' AS Time), N'Mantequilla', 152, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (16, 1014, CAST(N'2024-09-18' AS Date), CAST(N'00:01:20' AS Time), N'Mantequilla', 152, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (17, 1014, CAST(N'2024-09-18' AS Date), CAST(N'00:01:20' AS Time), N'Mantequilla', 152, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (18, 1014, CAST(N'2024-09-18' AS Date), CAST(N'00:01:21' AS Time), N'Mantequilla', 152, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (19, 1014, CAST(N'2024-09-18' AS Date), CAST(N'00:03:41.7933000' AS Time), N'Mantequilla', 152, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (20, 1014, CAST(N'2024-09-18' AS Date), CAST(N'00:03:58.5967000' AS Time), N'Mantequilla', 152, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (21, 1014, CAST(N'2024-09-18' AS Date), CAST(N'00:05:39.8933000' AS Time), N'Mantequilla', 152, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (22, 1014, CAST(N'2024-09-18' AS Date), CAST(N'00:06:53.1267000' AS Time), N'Mantequilla', 152, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (23, 1014, CAST(N'2024-09-18' AS Date), CAST(N'00:08:51.4900000' AS Time), N'Mantequilla', 152, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (24, 1014, CAST(N'2024-09-18' AS Date), CAST(N'00:08:57.3267000' AS Time), N'Mantequilla', 152, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (25, 1014, CAST(N'2024-09-18' AS Date), CAST(N'00:08:57.6500000' AS Time), N'Mantequilla', 152, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (26, 1014, CAST(N'2024-09-18' AS Date), CAST(N'00:10:06.8300000' AS Time), N'Mantequilla', 155, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (27, 1014, CAST(N'2024-10-01' AS Date), CAST(N'19:32:04.5833000' AS Time), N'Mantequilla', 160, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (28, 1014, CAST(N'2024-10-01' AS Date), CAST(N'19:33:08.6767000' AS Time), N'Mantequilla', 160, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (29, 1014, CAST(N'2024-10-01' AS Date), CAST(N'19:33:14.7000000' AS Time), N'Mantequilla', 160, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (30, 1014, CAST(N'2024-10-01' AS Date), CAST(N'19:33:15.1000000' AS Time), N'Mantequilla', 160, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (31, 1014, CAST(N'2024-10-01' AS Date), CAST(N'19:33:15.4467000' AS Time), N'Mantequilla', 160, CAST(4.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Productos_C] OFF
GO
INSERT [dbo].[Proveedores] ([CUIT], [Nombre], [RazonSocial], [Telefono], [Correo], [Direccion], [Banco], [TipoCuenta], [NumCuenta], [CBU], [Alias]) VALUES (N'20123456789', N'Rodolfo', N'Razon Social Ejemplo', 1234567890, N'proveedor@example.com', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'11111111', N'Santy', N'Bravo', N'correo1@gmail.com', N'11111111Santy', N'fbf45b0b718a59431c099a2cab0c2b5cb9cc80288c957d8060d4daad85784608', 0, 1, 34, N'es')
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'22222222', N'Daniel', N'Bravo', N'correo2@gmail.com', N'22222222Daniel', N'fc2fc05df0eedb81e46bace0c1d8c3f918725755ce8062413ad121f32e500cc7', 0, 0, 35, N'es')
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'33333333', N'Juan', N'Bravo', N'correo3@gmail.com', N'33333333Juan', N'ca1955d9a81f6837da481396b94417d35bd64a5eb281122e552ef4975171fc49', 0, 1, 36, N'es')
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'44444444', N'John', N'Bravo', N'correo4@gmail.com', N'44444444John', N'3b9730b9a7a9218a392c7fe566524203e49d71fdd42a8ab3284477440b80b22a', 0, 1, 3027, N'es')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Username]    Script Date: 1/10/2024 20:45:46 ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [UC_Username] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetallesOrdenCompra]  WITH CHECK ADD  CONSTRAINT [FK__DetallesO__CodPr__3552E9B6] FOREIGN KEY([CodigoProducto])
REFERENCES [dbo].[Productos] ([CodigoProducto])
GO
ALTER TABLE [dbo].[DetallesOrdenCompra] CHECK CONSTRAINT [FK__DetallesO__CodPr__3552E9B6]
GO
ALTER TABLE [dbo].[DetallesOrdenCompra]  WITH CHECK ADD  CONSTRAINT [FK__DetallesO__Numer__345EC57D] FOREIGN KEY([NumeroOrden])
REFERENCES [dbo].[OrdenesCompra] ([NumeroOrden])
GO
ALTER TABLE [dbo].[DetallesOrdenCompra] CHECK CONSTRAINT [FK__DetallesO__Numer__345EC57D]
GO
ALTER TABLE [dbo].[DetallesRecepcion]  WITH CHECK ADD FOREIGN KEY([CodigoProducto])
REFERENCES [dbo].[Productos] ([CodigoProducto])
GO
ALTER TABLE [dbo].[DetallesRecepcion]  WITH CHECK ADD  CONSTRAINT [FK__DetallesR__Numer__308E3499] FOREIGN KEY([NumeroRecepcion])
REFERENCES [dbo].[Recepciones] ([NumeroRecepcion])
GO
ALTER TABLE [dbo].[DetallesRecepcion] CHECK CONSTRAINT [FK__DetallesR__Numer__308E3499]
GO
ALTER TABLE [dbo].[DetallesSolicitud]  WITH CHECK ADD FOREIGN KEY([CodigoProducto])
REFERENCES [dbo].[Productos] ([CodigoProducto])
GO
ALTER TABLE [dbo].[DetallesSolicitud]  WITH CHECK ADD FOREIGN KEY([NumeroSolicitud])
REFERENCES [dbo].[SolicitudesCotizacion] ([NumeroSolicitud])
GO
ALTER TABLE [dbo].[DetallesVenta]  WITH CHECK ADD FOREIGN KEY([CodigoProducto])
REFERENCES [dbo].[Productos] ([CodigoProducto])
GO
ALTER TABLE [dbo].[DetallesVenta]  WITH CHECK ADD FOREIGN KEY([NumeroTicket])
REFERENCES [dbo].[Tickets] ([NumeroTicket])
GO
ALTER TABLE [dbo].[Eventos]  WITH CHECK ADD  CONSTRAINT [FK__Eventos__Usernam__756D6ECB] FOREIGN KEY([Username])
REFERENCES [dbo].[Usuarios] ([Username])
GO
ALTER TABLE [dbo].[Eventos] CHECK CONSTRAINT [FK__Eventos__Usernam__756D6ECB]
GO
ALTER TABLE [dbo].[OrdenesCompra]  WITH CHECK ADD  CONSTRAINT [FK__OrdenesCo__Numer__2AD55B43] FOREIGN KEY([NumeroSolicitud])
REFERENCES [dbo].[SolicitudesCotizacion] ([NumeroSolicitud])
GO
ALTER TABLE [dbo].[OrdenesCompra] CHECK CONSTRAINT [FK__OrdenesCo__Numer__2AD55B43]
GO
ALTER TABLE [dbo].[OrdenesCompra]  WITH CHECK ADD  CONSTRAINT [FK__OrdenesCom__CUIT__29E1370A] FOREIGN KEY([CUIT])
REFERENCES [dbo].[Proveedores] ([CUIT])
GO
ALTER TABLE [dbo].[OrdenesCompra] CHECK CONSTRAINT [FK__OrdenesCom__CUIT__29E1370A]
GO
ALTER TABLE [dbo].[PermisosPermisos]  WITH CHECK ADD FOREIGN KEY([PermisoPadreCod])
REFERENCES [dbo].[Permisos] ([Codigo])
GO
ALTER TABLE [dbo].[PermisosPermisos]  WITH CHECK ADD FOREIGN KEY([PermisoHijoCod])
REFERENCES [dbo].[Permisos] ([Codigo])
GO
ALTER TABLE [dbo].[PermisosRoles]  WITH CHECK ADD FOREIGN KEY([PermisoCod])
REFERENCES [dbo].[Permisos] ([Codigo])
GO
ALTER TABLE [dbo].[PermisosRoles]  WITH CHECK ADD FOREIGN KEY([RolCod])
REFERENCES [dbo].[Roles] ([Codigo])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([CodigoCategoria])
REFERENCES [dbo].[Categorias] ([CodigoCategoria])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Marcas] FOREIGN KEY([CodigoMarca])
REFERENCES [dbo].[Marcas] ([CodigoMarca])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Marcas]
GO
ALTER TABLE [dbo].[Productos_C]  WITH CHECK ADD  CONSTRAINT [FK__Productos__CodPr__10216507] FOREIGN KEY([CodigoProducto])
REFERENCES [dbo].[Productos] ([CodigoProducto])
GO
ALTER TABLE [dbo].[Productos_C] CHECK CONSTRAINT [FK__Productos__CodPr__10216507]
GO
ALTER TABLE [dbo].[ProveedoresSolicitudes]  WITH CHECK ADD FOREIGN KEY([NumeroSolicitud])
REFERENCES [dbo].[SolicitudesCotizacion] ([NumeroSolicitud])
GO
ALTER TABLE [dbo].[ProveedoresSolicitudes]  WITH CHECK ADD FOREIGN KEY([CUIT])
REFERENCES [dbo].[Proveedores] ([CUIT])
GO
ALTER TABLE [dbo].[Recepciones]  WITH CHECK ADD  CONSTRAINT [FK__Recepcion__Numer__2DB1C7EE] FOREIGN KEY([NumeroOrden])
REFERENCES [dbo].[OrdenesCompra] ([NumeroOrden])
GO
ALTER TABLE [dbo].[Recepciones] CHECK CONSTRAINT [FK__Recepcion__Numer__2DB1C7EE]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD FOREIGN KEY([DniCliente])
REFERENCES [dbo].[Clientes] ([Dni])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Permisos] FOREIGN KEY([Rol])
REFERENCES [dbo].[Permisos] ([Codigo])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Permisos]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD CHECK  (([Dni] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Permisos1]  WITH CHECK ADD  CONSTRAINT [CHK_Permisos1_Tipo] CHECK  (([Tipo]='Rol' OR [Tipo]='Familia' OR [Tipo]='Patente'))
GO
ALTER TABLE [dbo].[Permisos1] CHECK CONSTRAINT [CHK_Permisos1_Tipo]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD CHECK  (([DNI] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD CHECK  ((len([Password])>=(8) AND len([Password])<=(64)))
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD CHECK  ((len([Username])>=(6) AND len([Username])<=(50)))
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [CK_Idioma_ISO] CHECK  (([Idioma]='es' OR [Idioma]='en'))
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [CK_Idioma_ISO]
GO
/****** Object:  StoredProcedure [dbo].[SP_BloquearUsuario]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BloquearUsuario]
    @Username NVARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[Usuarios]
    SET [Bloqueo] = 1
    WHERE [Username] = @Username;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Consultar]
    @NombreTabla NVARCHAR(50),
    @CampoID NVARCHAR(50) = NULL,
    @ValorID NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = 'SELECT * FROM ' + QUOTENAME(@NombreTabla);
    IF @CampoID IS NOT NULL AND @ValorID IS NOT NULL
    BEGIN
        SET @SQL = @SQL + ' WHERE ' + QUOTENAME(@CampoID) + ' = @ID';
    END

    EXEC sp_executesql @SQL, N'@ID NVARCHAR(50)', @ID = @ValorID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultarEventos]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ConsultarEventos]
    @Username NVARCHAR(50) = NULL,
    @FechaInicio DATE = NULL,
    @FechaFin DATE = NULL,
    @Modulo NVARCHAR(50) = NULL,
    @Operacion NVARCHAR(100) = NULL,
    @Criticidad INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SQL NVARCHAR(MAX) = 'SELECT * FROM Eventos WHERE 1=1';

    IF @Username IS NOT NULL
        SET @SQL = @SQL + ' AND Username = @Username';

    IF @FechaInicio IS NOT NULL
        SET @SQL = @SQL + ' AND Fecha >= @FechaInicio';

    IF @FechaFin IS NOT NULL
        SET @SQL = @SQL + ' AND Fecha <= @FechaFin';

    IF @Modulo IS NOT NULL
        SET @SQL = @SQL + ' AND Modulo = @Modulo';

    IF @Operacion IS NOT NULL
        SET @SQL = @SQL + ' AND Operacion = @Operacion';

    IF @Criticidad IS NOT NULL
        SET @SQL = @SQL + ' AND Criticidad = @Criticidad';

    EXEC sp_executesql @SQL,
        N'@Username NVARCHAR(50), @FechaInicio DATE, @FechaFin DATE, @Modulo NVARCHAR(50), @Operacion NVARCHAR(100), @Criticidad INT',
        @Username, @FechaInicio, @FechaFin, @Modulo, @Operacion, @Criticidad;
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultarPorUsername]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ConsultarPorUsername]
    @Username NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM Usuarios
    WHERE Username = @Username;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultarProductosC]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ConsultarProductosC]
    @CodigoProducto INT = NULL,
    @FechaInicio DATE = NULL,
    @FechaFin DATE = NULL,
    @Nombre NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SQL NVARCHAR(MAX) = 'SELECT * FROM Productos_C WHERE 1=1';

    -- Filtrar por Código de Producto
    IF @CodigoProducto IS NOT NULL
        SET @SQL = @SQL + ' AND CodigoProducto = @CodigoProducto';

    -- Filtrar por Fecha de Inicio
    IF @FechaInicio IS NOT NULL
        SET @SQL = @SQL + ' AND Fecha >= @FechaInicio';

    -- Filtrar por Fecha de Fin
    IF @FechaFin IS NOT NULL
        SET @SQL = @SQL + ' AND Fecha <= @FechaFin';

    -- Filtrar por Nombre
    IF @Nombre IS NOT NULL
        SET @SQL = @SQL + ' AND Nombre LIKE @Nombre';

    -- Ejecutar la consulta dinámica
    EXEC sp_executesql @SQL,
        N'@CodProd INT, @FechaInicio DATE, @FechaFin DATE, @Nombre NVARCHAR(100)',
        @CodigoProducto, @FechaInicio, @FechaFin, @Nombre;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeshabilitarUsuario]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeshabilitarUsuario]
    @Dni CHAR(8)
AS
BEGIN
    SET NOCOUNT ON;

    -- Actualizar el campo Activo a 0 para deshabilitar el usuario
    UPDATE [dbo].[Usuarios]
    SET [Activo] = 0
    WHERE [Dni] = @Dni;
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ModificarUsuario]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ModificarUsuario]
    @Dni CHAR(8),
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Correo NVARCHAR(254),
    @RolID INT,
    @Username NVARCHAR(50),
    @Password NVARCHAR(64),
    @Bloqueo BIT,
    @Activo BIT,
    @Idioma VARCHAR(2)
AS
BEGIN
    SET NOCOUNT ON;

    -- Actualizar los datos del usuario
    UPDATE [dbo].[Usuarios]
    SET
        [Nombre] = @Nombre,
        [Apellido] = @Apellido,
        [Correo] = @Correo,
        [Rol] = @RolID,
        [Username] = @Username,
        [Password] = @Password,
        [Bloqueo] = @Bloqueo,
        [Activo] = @Activo,
        [Idioma] = @Idioma
    WHERE
        [Dni] = @Dni;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerPermisos]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerPermisos]
    @TipoPermiso VARCHAR(50) = NULL,
    @CodigoPermiso INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    WITH RecursivePermisos AS (
    SELECT 
        p1.Codigo AS CodigoPadre,
        p1.Nombre AS NombrePadre,
        p1.Tipo AS TipoPadre,
        pp.PermisoHijoCod AS CodigoHijo,
        p2.Nombre AS NombreHijo,
        p2.Tipo AS TipoHijo,
        1 AS Nivel
    FROM 
        PermisosPermisos pp
    INNER JOIN 
        Permisos p1 ON pp.PermisoPadreCod = p1.Codigo
    INNER JOIN 
        Permisos p2 ON pp.PermisoHijoCod = p2.Codigo
    WHERE 
        (@TipoPermiso IS NULL OR p1.Tipo = @TipoPermiso) AND
        (@CodigoPermiso IS NULL OR p1.Codigo = @CodigoPermiso)

    UNION ALL

    SELECT 
        rp.CodigoHijo AS CodigoPadre,
        rp.NombreHijo AS NombrePadre,
        rp.TipoHijo AS TipoPadre,
        pp.PermisoHijoCod AS CodigoHijo,
        p2.Nombre AS NombreHijo,
        p2.Tipo AS TipoHijo,
        rp.Nivel + 1 AS Nivel
    FROM 
        RecursivePermisos rp
    INNER JOIN 
        PermisosPermisos pp ON rp.CodigoHijo = pp.PermisoPadreCod
    INNER JOIN 
        Permisos p2 ON pp.PermisoHijoCod = p2.Codigo
)
SELECT DISTINCT
    CodigoPadre,
    NombrePadre,
    TipoPadre,
    CodigoHijo,
    NombreHijo,
    TipoHijo,
    Nivel  -- Asegúrate de incluir Nivel en la lista de selección
FROM 
    RecursivePermisos
ORDER BY 
    CodigoPadre, Nivel, CodigoHijo;
END


GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerUltimoNumeroTransaccionBancaria]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerUltimoNumeroTransaccionBancaria]
AS
BEGIN
    SELECT TOP 1 NumeroTransaccionBancaria
    FROM Tickets
    WHERE NumeroTransaccionBancaria IS NOT NULL
    ORDER BY NumeroTransaccionBancaria DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarUsuario]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RegistrarUsuario]
    @Dni CHAR(8),
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Correo NVARCHAR(254),
    @RolID INT,
    @Username NVARCHAR(50),
    @Password NVARCHAR(64),
    @Bloqueo BIT,
    @Activo BIT,
    @Idioma VARCHAR(2)  -- Añadir el parámetro para el idioma
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar nuevo usuario con el idioma especificado
    INSERT INTO [dbo].[Usuarios] (Dni, Nombre, Apellido, Correo, Rol, Username, Password, Bloqueo, Activo, Idioma)
    VALUES (@Dni, @Nombre, @Apellido, @Correo, @RolID, @Username, @Password, @Bloqueo, @Activo, @Idioma);
END
GO
/****** Object:  Trigger [dbo].[trg_Insert_Productos_C_After_Insert_Update]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_Insert_Productos_C_After_Insert_Update]
ON [dbo].[Productos]
AFTER UPDATE, INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Declarar variables para almacenar la fecha y hora del último registro insertado
    DECLARE @FechaActual DATE;
    DECLARE @HoraActual TIME(4);

    -- Obtener la fecha y hora actual
    SET @FechaActual = CAST(GETDATE() AS DATE);
    SET @HoraActual = CONVERT(TIME(4), GETDATE());

    -- Insertar un nuevo registro en Productos_C cuando se inserta o actualiza un producto
    INSERT INTO Productos_C (CodigoProducto, Fecha, Hora, Nombre, Stock, Precio, Act)
    SELECT
        i.CodigoProducto,
        @FechaActual AS Fecha,
        @HoraActual AS Hora,
        i.Nombre,
        i.Stock,
        i.Precio,
        1 AS Act
    FROM
        INSERTED i;

    -- Desactivar los registros anteriores de Productos_C (Act = 0)
    -- Usa las variables para comparar la fecha y la hora
    UPDATE pc
    SET pc.Act = 0
    FROM Productos_C pc
    INNER JOIN INSERTED i ON pc.CodigoProducto = i.CodigoProducto
    WHERE pc.Act = 1
    AND (
        (pc.Fecha < @FechaActual) 
        OR (pc.Fecha = @FechaActual AND pc.Hora < @HoraActual)
    )
    AND pc.CodigoProducto = i.CodigoProducto;
END;
GO
ALTER TABLE [dbo].[Productos] ENABLE TRIGGER [trg_Insert_Productos_C_After_Insert_Update]
GO
/****** Object:  Trigger [dbo].[trg_Restore_Productos_After_Update]    Script Date: 1/10/2024 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_Restore_Productos_After_Update]
ON [dbo].[Productos_C]
AFTER UPDATE
AS
BEGIN
    -- Verificamos si el campo Act fue cambiado a 1
    IF EXISTS (
        SELECT 1
        FROM INSERTED i
        JOIN DELETED d ON i.CambioID = d.CambioID
        WHERE i.Act = 1 AND d.Act = 0
    )
    BEGIN
        -- Actualizamos los valores en la tabla Productos usando el CodProd de Productos_C
        UPDATE p
        SET p.Nombre = i.Nombre,
            p.Stock = i.Stock,
			P.Precio = i.Precio
        FROM Productos p
        JOIN INSERTED i ON p.CodigoProducto = i.CodigoProducto
        WHERE i.Act = 1;
    END
END;
GO
ALTER TABLE [dbo].[Productos_C] ENABLE TRIGGER [trg_Restore_Productos_After_Update]
GO
USE [master]
GO
ALTER DATABASE [MarketMateDB] SET  READ_WRITE 
GO
