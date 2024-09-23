USE [master]
GO
/****** Object:  Database [DBMarketMate]    Script Date: 03/09/2024 22:11:26 ******/
CREATE DATABASE [DBMarketMate]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBMarketMate', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBMarketMate.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBMarketMate_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBMarketMate_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBMarketMate] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBMarketMate].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBMarketMate] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBMarketMate] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBMarketMate] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBMarketMate] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBMarketMate] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBMarketMate] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBMarketMate] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBMarketMate] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBMarketMate] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBMarketMate] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBMarketMate] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBMarketMate] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBMarketMate] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBMarketMate] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBMarketMate] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBMarketMate] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBMarketMate] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBMarketMate] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBMarketMate] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBMarketMate] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBMarketMate] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBMarketMate] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBMarketMate] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBMarketMate] SET  MULTI_USER 
GO
ALTER DATABASE [DBMarketMate] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBMarketMate] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBMarketMate] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBMarketMate] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBMarketMate] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBMarketMate] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DBMarketMate] SET QUERY_STORE = OFF
GO
USE [DBMarketMate]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 03/09/2024 22:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  Table [dbo].[DetallesVenta]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  Table [dbo].[Eventos]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  Table [dbo].[Marcas]    Script Date: 03/09/2024 22:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  Table [dbo].[Permisos1]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  Table [dbo].[PermisosPermisos]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  Table [dbo].[PermisosRoles]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  Table [dbo].[Productos]    Script Date: 03/09/2024 22:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Stock] [int] NOT NULL,
	[CodigoCategoria] [int] NOT NULL,
	[Costo] [decimal](18, 2) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[CodigoMarca] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  Table [dbo].[Tickets]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 03/09/2024 22:11:26 ******/
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

INSERT [dbo].[Categorias] ([Codigo], [Nombre], [Descripcion]) VALUES (1, N'Lácteos', N'Productos derivados de la leche')
INSERT [dbo].[Categorias] ([Codigo], [Nombre], [Descripcion]) VALUES (2, N'Bebidas Frías', N'Bebidas frías no alcohólicas y alcohólicas')
INSERT [dbo].[Categorias] ([Codigo], [Nombre], [Descripcion]) VALUES (3, N'Ingredientes para Bebidas Calientes', N'Productos utilizados para preparar bebidas calientes como café y té')
INSERT [dbo].[Categorias] ([Codigo], [Nombre], [Descripcion]) VALUES (4, N'Carnes', N'Todo tipo de carnes frescas')
INSERT [dbo].[Categorias] ([Codigo], [Nombre], [Descripcion]) VALUES (5, N'Enlatados', N'Alimentos empaquetados en latas selladas para su conservación')
INSERT [dbo].[Categorias] ([Codigo], [Nombre], [Descripcion]) VALUES (6, N'Snacks', N'Aperitivos y comidas ligeras listos para comer')
INSERT [dbo].[Categorias] ([Codigo], [Nombre], [Descripcion]) VALUES (7, N'Cuidado Personal', N'Productos relacionados con la higiene y el cuidado personal')
INSERT [dbo].[Categorias] ([Codigo], [Nombre], [Descripcion]) VALUES (8, N'Salsas', N'Condimentos líquidos utilizados para acompañar alimentos')
INSERT [dbo].[Categorias] ([Codigo], [Nombre], [Descripcion]) VALUES (9, N'Condimentos', N'Ingredientes que agregan sabor o realzan el sabor de los alimentos')
INSERT [dbo].[Categorias] ([Codigo], [Nombre], [Descripcion]) VALUES (10, N'Pasta y Granos', N'Variedades de pasta, arroz, cereales y otros granos')
INSERT [dbo].[Categorias] ([Codigo], [Nombre], [Descripcion]) VALUES (11, N'Endulzantes y Edulcorantes', N'Productos utilizados para endulzar alimentos o bebidas')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [Correo], [Telefono]) VALUES (N'99999999', N'Juan', N'Bravo', N'ZhE9g/vtTiEof9aZtxr9tlNax0jEJYmjgX/+TZ/atHo=', 1234567890)
GO
INSERT [dbo].[DetallesVenta] ([NumeroTicket], [CodigoProducto], [Cantidad], [PrecioUnitario], [SubTotal]) VALUES (1, 1, 5, CAST(70.00 AS Decimal(18, 2)), CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[DetallesVenta] ([NumeroTicket], [CodigoProducto], [Cantidad], [PrecioUnitario], [SubTotal]) VALUES (2, 1, 5, CAST(70.00 AS Decimal(18, 2)), CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[DetallesVenta] ([NumeroTicket], [CodigoProducto], [Cantidad], [PrecioUnitario], [SubTotal]) VALUES (2, 2, 10, CAST(50.00 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Eventos] ON 

INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1, N'11111111Santy', CAST(N'2024-09-03' AS Date), CAST(N'09:26:41' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2, N'11111111Santy', CAST(N'2024-09-03' AS Date), CAST(N'09:27:37' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3, N'11111111Santy', CAST(N'2024-09-03' AS Date), CAST(N'09:47:19' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (4, N'11111111Santy', CAST(N'2024-09-03' AS Date), CAST(N'09:49:00' AS Time), N'Usuario', N'Login', 1)
SET IDENTITY_INSERT [dbo].[Eventos] OFF
GO
SET IDENTITY_INSERT [dbo].[Marcas] ON 

INSERT [dbo].[Marcas] ([Codigo], [Nombre]) VALUES (1, N'La Serenísima')
INSERT [dbo].[Marcas] ([Codigo], [Nombre]) VALUES (2, N'Sancor')
INSERT [dbo].[Marcas] ([Codigo], [Nombre]) VALUES (3, N'Coca-Cola')
INSERT [dbo].[Marcas] ([Codigo], [Nombre]) VALUES (4, N'Pepsi')
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
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([Codigo], [Nombre], [Stock], [CodigoCategoria], [Costo], [Precio], [CodigoMarca]) VALUES (1, N'Leche Entera', 90, 1, CAST(50.00 AS Decimal(18, 2)), CAST(70.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Productos] ([Codigo], [Nombre], [Stock], [CodigoCategoria], [Costo], [Precio], [CodigoMarca]) VALUES (2, N'Yogur', 140, 1, CAST(30.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Productos] ([Codigo], [Nombre], [Stock], [CodigoCategoria], [Costo], [Precio], [CodigoMarca]) VALUES (3, N'Coca-Cola 500ml', 200, 2, CAST(25.00 AS Decimal(18, 2)), CAST(40.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Productos] ([Codigo], [Nombre], [Stock], [CodigoCategoria], [Costo], [Precio], [CodigoMarca]) VALUES (4, N'Pepsi 500ml', 180, 2, CAST(24.00 AS Decimal(18, 2)), CAST(38.00 AS Decimal(18, 2)), 4)
INSERT [dbo].[Productos] ([Codigo], [Nombre], [Stock], [CodigoCategoria], [Costo], [Precio], [CodigoMarca]) VALUES (5, N'ProductoA', 100, 1, CAST(500.00 AS Decimal(18, 2)), CAST(550.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 

INSERT [dbo].[Tickets] ([NumeroTicket], [NumeroTransaccionBancaria], [MetodoPago], [TipoTarjeta], [NumeroTarjeta], [AliasMP], [Fecha], [Monto], [DniCliente]) VALUES (1, NULL, N'Efectivo', NULL, NULL, NULL, CAST(N'2024-07-10' AS Date), CAST(350.00 AS Decimal(18, 2)), N'99999999')
INSERT [dbo].[Tickets] ([NumeroTicket], [NumeroTransaccionBancaria], [MetodoPago], [TipoTarjeta], [NumeroTarjeta], [AliasMP], [Fecha], [Monto], [DniCliente]) VALUES (2, 1, N'TarjetaDebito', N'Visa', CAST(3456 AS Numeric(4, 0)), NULL, CAST(N'2024-07-10' AS Date), CAST(850.00 AS Decimal(18, 2)), N'99999999')
SET IDENTITY_INSERT [dbo].[Tickets] OFF
GO
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'11111111', N'Santy', N'Bravo', N'correo1@gmail.com', N'11111111Santy', N'fbf45b0b718a59431c099a2cab0c2b5cb9cc80288c957d8060d4daad85784608', 0, 1, 34, N'en')
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'22222222', N'Daniel', N'Bravo', N'correo2@gmail.com', N'22222222Daniel', N'fc2fc05df0eedb81e46bace0c1d8c3f918725755ce8062413ad121f32e500cc7', 0, 0, 35, N'es')
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'33333333', N'Juan', N'Bravo', N'correo3@gmail.com', N'33333333Juan', N'ca1955d9a81f6837da481396b94417d35bd64a5eb281122e552ef4975171fc49', 0, 1, 36, N'es')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Username]    Script Date: 03/09/2024 22:11:26 ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [UC_Username] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetallesVenta]  WITH CHECK ADD FOREIGN KEY([CodigoProducto])
REFERENCES [dbo].[Productos] ([Codigo])
GO
ALTER TABLE [dbo].[DetallesVenta]  WITH CHECK ADD FOREIGN KEY([NumeroTicket])
REFERENCES [dbo].[Tickets] ([NumeroTicket])
GO
ALTER TABLE [dbo].[Eventos]  WITH CHECK ADD  CONSTRAINT [FK__Eventos__Usernam__756D6ECB] FOREIGN KEY([Username])
REFERENCES [dbo].[Usuarios] ([Username])
GO
ALTER TABLE [dbo].[Eventos] CHECK CONSTRAINT [FK__Eventos__Usernam__756D6ECB]
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
REFERENCES [dbo].[Categorias] ([Codigo])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Marcas] FOREIGN KEY([CodigoMarca])
REFERENCES [dbo].[Marcas] ([Codigo])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Marcas]
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
/****** Object:  StoredProcedure [dbo].[SP_BloquearUsuario]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Consultar]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ConsultarEventos]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ConsultarPorUsername]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DeshabilitarUsuario]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ModificarUsuario]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ObtenerPermisos]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ObtenerProductosConCategorias]    Script Date: 03/09/2024 22:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerProductosConCategorias]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Codigo,
		p.Nombre AS NombreProducto,
        p.Stock,
        p.Costo,
        p.Precio,
        c.Nombre AS NombreCategoria,
        c.Descripcion AS DescripcionCategoria
    FROM 
        Productos p
    INNER JOIN 
        Categorias c ON p.CodigoCategoria = c.Codigo;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerUltimoNumeroTransaccionBancaria]    Script Date: 03/09/2024 22:11:26 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_RegistrarUsuario]    Script Date: 03/09/2024 22:11:26 ******/
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
USE [master]
GO
ALTER DATABASE [DBMarketMate] SET  READ_WRITE 
GO
