USE [master]
GO

CREATE DATABASE [MarketMateDB]

USE [MarketMateDB]
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
/****** Object:  Table [dbo].[Clientes]    Script Date: 5/11/2024 23:40:50 ******/
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
	[Act_B] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesOrdenCompra]    Script Date: 5/11/2024 23:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesOrdenCompra](
	[NumeroOrden] [int] NOT NULL,
	[CodigoProducto] [int] NOT NULL,
	[CantidadSolicitada] [int] NOT NULL,
	[CantidadRecibida] [int] NULL,
	[PrecioUnitario] [decimal](10, 2) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[PorcentajeIVA] [decimal](5, 2) NOT NULL,
	[TotalConIVA] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK__Detalles__1FF58BE3BC603FD1] PRIMARY KEY CLUSTERED 
(
	[NumeroOrden] ASC,
	[CodigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesRecepcion]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Table [dbo].[DetallesSolicitud]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Table [dbo].[DetallesVenta]    Script Date: 5/11/2024 23:40:50 ******/
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
	[TotalConIVA] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroTicket] ASC,
	[CodigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DigitosVerificadores]    Script Date: 5/11/2024 23:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigitosVerificadores](
	[Tabla] [varchar](30) NOT NULL,
	[DVH] [char](64) NOT NULL,
	[DVV] [char](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Tabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eventos]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Table [dbo].[Facturas]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Table [dbo].[OrdenesCompra]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Table [dbo].[Permisos]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Table [dbo].[Permisos1]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Table [dbo].[PermisosPermisos]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Table [dbo].[PermisosRoles]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Table [dbo].[Productos]    Script Date: 5/11/2024 23:40:50 ******/
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
	[StockMinimo] [int] NOT NULL,
	[StockMaximo] [int] NOT NULL,
	[Act_B] [bit] NULL,
	[Marca] [nvarchar](100) NOT NULL,
	[PorcentajeIVA] [decimal](5, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos_C]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Table [dbo].[Proveedores]    Script Date: 5/11/2024 23:40:50 ******/
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
	[TipoCuenta] [char](2) NULL,
	[NumCuenta] [nvarchar](50) NULL,
	[CBU] [nvarchar](22) NULL,
	[Alias] [nvarchar](50) NULL,
	[Act_B] [bit] NOT NULL,
 CONSTRAINT [PK__Proveedo__F46C1599A93500E3] PRIMARY KEY CLUSTERED 
(
	[CUIT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProveedoresSolicitudes]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Table [dbo].[Recepciones]    Script Date: 5/11/2024 23:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recepciones](
	[NumeroRecepcion] [int] IDENTITY(1,1) NOT NULL,
	[NumeroOrden] [int] NOT NULL,
	[FechaRecepcion] [datetime] NOT NULL,
	[NumeroFactura] [int] NOT NULL,
	[MontoFactura] [numeric](18, 2) NOT NULL,
	[FechaFactura] [datetime] NOT NULL,
 CONSTRAINT [PK__Recepcio__009EBA2CC139AC96] PRIMARY KEY CLUSTERED 
(
	[NumeroRecepcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Table [dbo].[SolicitudesCotizacion]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Table [dbo].[Tickets]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 5/11/2024 23:40:50 ******/
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
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [Correo], [Telefono], [Act_B]) VALUES (N'77777777', N'Roberto', N'Bravo', N'RZeVqWHexUSDLci21xUxqeZX2KyKeD6ilq6KYgJDTBw=', 1234567890, 0)
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [Correo], [Telefono], [Act_B]) VALUES (N'88888888', N'Rodolfin', N'Bravo', N'RZeVqWHexUSDLci21xUxqeZX2KyKeD6ilq6KYgJDTBw=', 1234567890, 0)
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [Correo], [Telefono], [Act_B]) VALUES (N'99999999', N'Juan', N'Bravo', N'ZhE9g/vtTiEof9aZtxr9tlNax0jEJYmjgX/+TZ/atHo=', 1234567890, 0)
GO
INSERT [dbo].[DetallesOrdenCompra] ([NumeroOrden], [CodigoProducto], [CantidadSolicitada], [CantidadRecibida], [PrecioUnitario], [SubTotal], [PorcentajeIVA], [TotalConIVA]) VALUES (1, 1005, 5, 5, CAST(50.00 AS Decimal(10, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(5, 2)), CAST(260.00 AS Decimal(18, 2)))
INSERT [dbo].[DetallesOrdenCompra] ([NumeroOrden], [CodigoProducto], [CantidadSolicitada], [CantidadRecibida], [PrecioUnitario], [SubTotal], [PorcentajeIVA], [TotalConIVA]) VALUES (2, 1005, 5, 0, CAST(50.00 AS Decimal(10, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(5, 2)), CAST(260.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[DetallesRecepcion] ([NumeroRecepcion], [CodigoProducto], [CantidadRecibida]) VALUES (1, 1005, 3)
INSERT [dbo].[DetallesRecepcion] ([NumeroRecepcion], [CodigoProducto], [CantidadRecibida]) VALUES (2, 1005, 2)
GO
INSERT [dbo].[DetallesSolicitud] ([NumeroSolicitud], [CodigoProducto], [Cantidad]) VALUES (1, 1005, 5)
GO
INSERT [dbo].[DigitosVerificadores] ([Tabla], [DVH], [DVV]) VALUES (N'Categorias', N'180e4a4b97f09112d03d6ca3c604a67c08ac1336bd3db7db46112096eb0c0fc6', N'0375d43a5e177f15515c8e826ffe2305ecdda020a8fd7da3a842e8d149bfbf2d')
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
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (33, N'11111111Santy', CAST(N'2024-10-14' AS Date), CAST(N'09:04:35' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (34, N'11111111Santy', CAST(N'2024-10-14' AS Date), CAST(N'09:05:34' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (35, N'11111111Santy', CAST(N'2024-10-14' AS Date), CAST(N'09:08:51' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (36, N'11111111Santy', CAST(N'2024-10-14' AS Date), CAST(N'09:08:57' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (37, N'11111111Santy', CAST(N'2024-10-14' AS Date), CAST(N'09:09:53' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (38, N'11111111Santy', CAST(N'2024-10-14' AS Date), CAST(N'09:10:15' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (39, N'11111111Santy', CAST(N'2024-10-14' AS Date), CAST(N'09:10:24' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (40, N'11111111Santy', CAST(N'2024-10-14' AS Date), CAST(N'09:11:03' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (41, N'11111111Santy', CAST(N'2024-10-14' AS Date), CAST(N'09:12:18' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (42, N'11111111Santy', CAST(N'2024-10-14' AS Date), CAST(N'09:12:38' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (43, N'11111111Santy', CAST(N'2024-10-14' AS Date), CAST(N'09:12:40' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (44, N'11111111Santy', CAST(N'2024-10-14' AS Date), CAST(N'09:13:01' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (45, N'11111111Santy', CAST(N'2024-10-15' AS Date), CAST(N'12:23:47' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (46, N'11111111Santy', CAST(N'2024-10-15' AS Date), CAST(N'12:23:51' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (47, N'11111111Santy', CAST(N'2024-10-15' AS Date), CAST(N'12:26:52' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (48, N'11111111Santy', CAST(N'2024-10-15' AS Date), CAST(N'12:27:23' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (49, N'11111111Santy', CAST(N'2024-10-15' AS Date), CAST(N'12:28:20' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (50, N'11111111Santy', CAST(N'2024-10-15' AS Date), CAST(N'12:28:22' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (51, N'11111111Santy', CAST(N'2024-10-15' AS Date), CAST(N'10:07:49' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (52, N'11111111Santy', CAST(N'2024-10-15' AS Date), CAST(N'10:07:51' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1051, N'11111111Santy', CAST(N'2024-10-27' AS Date), CAST(N'01:08:06' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1052, N'11111111Santy', CAST(N'2024-10-27' AS Date), CAST(N'01:09:49' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1053, N'11111111Santy', CAST(N'2024-10-27' AS Date), CAST(N'01:10:26' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1054, N'11111111Santy', CAST(N'2024-10-27' AS Date), CAST(N'01:13:25' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1055, N'11111111Santy', CAST(N'2024-10-27' AS Date), CAST(N'01:13:30' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1056, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'04:22:38' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1057, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'04:23:24' AS Time), N'Proveedores', N'RegistrarProveedor', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1058, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'04:23:39' AS Time), N'Proveedores', N'RegistrarProveedor', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1059, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'04:28:38' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1060, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'04:29:08' AS Time), N'Compras', N'RegistroInicialCliente', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1061, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'04:32:30' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1062, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'04:33:09' AS Time), N'Compras', N'RegistroInicialCliente', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1063, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'04:34:33' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1064, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'04:36:26' AS Time), N'Compras', N'RegistroInicialCliente', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1065, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'04:39:48' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1066, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'04:42:42' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1067, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:17:13' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1068, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:17:36' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1069, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:18:36' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1070, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:31:08' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1071, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:33:02' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1072, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:35:02' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1073, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:37:17' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1074, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:38:04' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1075, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:39:35' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1076, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:40:21' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1077, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:41:00' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1078, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:41:28' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1079, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:41:57' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1080, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:46:05' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1081, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'08:46:30' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1082, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'09:33:05' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1083, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'10:02:09' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1084, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'10:03:33' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1085, N'44444444John', CAST(N'2024-10-27' AS Date), CAST(N'10:04:38' AS Time), N'Compras', N'CompletarRegistroCliente', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1086, N'44444444John', CAST(N'2024-10-28' AS Date), CAST(N'10:25:13' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1087, N'44444444John', CAST(N'2024-10-28' AS Date), CAST(N'11:36:12' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1088, N'44444444John', CAST(N'2024-10-28' AS Date), CAST(N'11:38:59' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1089, N'44444444John', CAST(N'2024-10-28' AS Date), CAST(N'10:02:29' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1090, N'44444444John', CAST(N'2024-10-28' AS Date), CAST(N'10:04:56' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1091, N'44444444John', CAST(N'2024-10-28' AS Date), CAST(N'10:05:46' AS Time), N'Compras', N'CompletarRegistroCliente', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1092, N'44444444John', CAST(N'2024-10-28' AS Date), CAST(N'11:51:04' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1093, N'44444444John', CAST(N'2024-10-28' AS Date), CAST(N'11:53:41' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1094, N'44444444John', CAST(N'2024-10-28' AS Date), CAST(N'11:55:08' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1095, N'44444444John', CAST(N'2024-10-28' AS Date), CAST(N'11:57:19' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1096, N'44444444John', CAST(N'2024-10-28' AS Date), CAST(N'11:58:25' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1097, N'44444444John', CAST(N'2024-10-29' AS Date), CAST(N'12:00:02' AS Time), N'Usuario', N'Login', 1)
GO
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1098, N'44444444John', CAST(N'2024-10-29' AS Date), CAST(N'12:02:48' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1099, N'44444444John', CAST(N'2024-10-29' AS Date), CAST(N'12:09:31' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1100, N'44444444John', CAST(N'2024-10-29' AS Date), CAST(N'02:09:14' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1101, N'44444444John', CAST(N'2024-10-29' AS Date), CAST(N'02:11:55' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1102, N'44444444John', CAST(N'2024-10-29' AS Date), CAST(N'02:15:53' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1103, N'44444444John', CAST(N'2024-10-29' AS Date), CAST(N'02:18:23' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1104, N'44444444John', CAST(N'2024-10-29' AS Date), CAST(N'02:20:18' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1105, N'44444444John', CAST(N'2024-10-29' AS Date), CAST(N'02:21:30' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1106, N'44444444John', CAST(N'2024-10-29' AS Date), CAST(N'02:22:33' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1107, N'44444444John', CAST(N'2024-10-29' AS Date), CAST(N'02:25:22' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1108, N'44444444John', CAST(N'2024-10-29' AS Date), CAST(N'04:28:50' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1109, N'44444444John', CAST(N'2024-10-29' AS Date), CAST(N'04:28:52' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1110, N'44444444John', CAST(N'2024-11-01' AS Date), CAST(N'07:51:40' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1111, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'07:52:57' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1112, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'07:57:10' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1113, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'07:58:54' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1114, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'07:59:58' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1115, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'08:03:57' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1116, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'08:04:31' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1117, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'08:16:26' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1118, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'08:20:58' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1119, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'08:30:28' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1120, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'08:33:31' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1121, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'08:36:13' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1122, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'08:36:22' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1123, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'09:19:25' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1124, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'09:20:40' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1125, N'11111111Santy', CAST(N'2024-11-01' AS Date), CAST(N'09:20:50' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1126, N'44444444John', CAST(N'2024-11-03' AS Date), CAST(N'03:35:31' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1127, N'44444444John', CAST(N'2024-11-03' AS Date), CAST(N'03:35:36' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1128, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'10:48:34' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1129, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'10:48:58' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1130, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'10:48:58' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1131, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'10:48:58' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1132, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'10:49:02' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1133, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'10:49:02' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1134, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'10:49:02' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1135, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'11:11:02' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1136, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'11:11:05' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1137, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'11:12:08' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1138, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'11:16:09' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1139, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'11:16:57' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1140, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'11:23:44' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1141, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'11:24:52' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1142, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'11:27:07' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1143, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'11:29:25' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1144, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'11:35:51' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1145, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'11:36:27' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1146, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'11:43:06' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1147, N'44444444John', CAST(N'2024-11-04' AS Date), CAST(N'11:43:27' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1148, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'08:24:48' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1149, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'08:26:40' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1150, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'08:27:39' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1151, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'08:29:24' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1152, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'08:30:06' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1153, N'11111111Santy', CAST(N'2024-11-05' AS Date), CAST(N'08:30:31' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1154, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'08:34:15' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1155, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'08:34:18' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1156, N'11111111Santy', CAST(N'2024-11-05' AS Date), CAST(N'08:34:28' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1157, N'11111111Santy', CAST(N'2024-11-05' AS Date), CAST(N'08:35:15' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1158, N'11111111Santy', CAST(N'2024-11-05' AS Date), CAST(N'08:35:29' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1159, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'08:39:07' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1160, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'08:39:11' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1161, N'11111111Santy', CAST(N'2024-11-05' AS Date), CAST(N'08:39:36' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1162, N'11111111Santy', CAST(N'2024-11-05' AS Date), CAST(N'08:41:10' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1163, N'11111111Santy', CAST(N'2024-11-05' AS Date), CAST(N'08:41:15' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1164, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'08:41:27' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1165, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'08:41:37' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1166, N'11111111Santy', CAST(N'2024-11-05' AS Date), CAST(N'08:41:43' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1167, N'11111111Santy', CAST(N'2024-11-05' AS Date), CAST(N'08:41:50' AS Time), N'Reportes', N'GenerarReporte2', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1168, N'11111111Santy', CAST(N'2024-11-05' AS Date), CAST(N'08:42:31' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1169, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'09:08:25' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1170, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'09:08:32' AS Time), N'Usuario', N'Logout', 1)
SET IDENTITY_INSERT [dbo].[Eventos] OFF
GO
SET IDENTITY_INSERT [dbo].[OrdenesCompra] ON 

INSERT [dbo].[OrdenesCompra] ([NumeroOrden], [FechaEmision], [FechaLimiteEntrega], [CUIT], [NumeroSolicitud], [NumeroCotizacion], [Estado], [Total], [NumeroTransferencia]) VALUES (1, CAST(N'2024-10-29T00:03:04.810' AS DateTime), CAST(N'2024-10-29T00:02:50.017' AS DateTime), N'12345678901', 1, 2, N'Completo', CAST(250.00 AS Decimal(18, 2)), N'0')
INSERT [dbo].[OrdenesCompra] ([NumeroOrden], [FechaEmision], [FechaLimiteEntrega], [CUIT], [NumeroSolicitud], [NumeroCotizacion], [Estado], [Total], [NumeroTransferencia]) VALUES (2, CAST(N'2024-10-29T00:09:54.173' AS DateTime), CAST(N'2024-10-29T00:09:33.000' AS DateTime), N'12345678901', 1, 0, N'Pendiente', CAST(250.00 AS Decimal(18, 2)), N'1')
SET IDENTITY_INSERT [dbo].[OrdenesCompra] OFF
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
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (3028, N'Ordenes', N'Patente')
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
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (1022, 3028)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 31)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 3021)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 3023)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 3024)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 3025)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3027, 1021)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3027, 3026)
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [StockMinimo], [StockMaximo], [Act_B], [Marca], [PorcentajeIVA]) VALUES (1005, N'Leche', 100, 1, CAST(3.00 AS Decimal(18, 2)), 10, 200, 0, N'La Serenísima', CAST(2.00 AS Decimal(5, 2)))
INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [StockMinimo], [StockMaximo], [Act_B], [Marca], [PorcentajeIVA]) VALUES (1006, N'Queso', 50, 1, CAST(5.50 AS Decimal(18, 2)), 5, 100, 0, N'La Serenísima', CAST(2.00 AS Decimal(5, 2)))
INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [StockMinimo], [StockMaximo], [Act_B], [Marca], [PorcentajeIVA]) VALUES (1007, N'Yogur', 80, 1, CAST(2.00 AS Decimal(18, 2)), 20, 150, 0, N'La Serenísima', CAST(2.00 AS Decimal(5, 2)))
INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [StockMinimo], [StockMaximo], [Act_B], [Marca], [PorcentajeIVA]) VALUES (1008, N'Agua Mineral', 120, 2, CAST(1.50 AS Decimal(18, 2)), 15, 250, 0, N'Coca-Cola', CAST(2.00 AS Decimal(5, 2)))
INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [StockMinimo], [StockMaximo], [Act_B], [Marca], [PorcentajeIVA]) VALUES (1009, N'Gaseosa', 80, 2, CAST(2.00 AS Decimal(18, 2)), 10, 200, 0, N'Coca-Cola', CAST(2.00 AS Decimal(5, 2)))
INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [StockMinimo], [StockMaximo], [Act_B], [Marca], [PorcentajeIVA]) VALUES (1010, N'Cerveza', 60, 2, CAST(3.00 AS Decimal(18, 2)), 5, 100, 0, N'Pepsi', CAST(2.00 AS Decimal(5, 2)))
INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [StockMinimo], [StockMaximo], [Act_B], [Marca], [PorcentajeIVA]) VALUES (1014, N'Mantequilla', 160, 1, CAST(4.00 AS Decimal(18, 2)), 0, 0, 0, N'La Serenísima', CAST(2.00 AS Decimal(5, 2)))
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
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (31, 1014, CAST(N'2024-10-01' AS Date), CAST(N'19:33:15.4467000' AS Time), N'Mantequilla', 160, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (32, 1014, CAST(N'2024-10-25' AS Date), CAST(N'19:59:15.1267000' AS Time), N'Mantequilla', 160, CAST(4.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (33, 1010, CAST(N'2024-10-25' AS Date), CAST(N'19:59:15.1267000' AS Time), N'Cerveza', 60, CAST(3.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (34, 1009, CAST(N'2024-10-25' AS Date), CAST(N'19:59:15.1267000' AS Time), N'Gaseosa', 80, CAST(2.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (35, 1008, CAST(N'2024-10-25' AS Date), CAST(N'19:59:15.1267000' AS Time), N'Agua Mineral', 120, CAST(1.50 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (36, 1007, CAST(N'2024-10-25' AS Date), CAST(N'19:59:15.1267000' AS Time), N'Yogur', 80, CAST(2.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (37, 1006, CAST(N'2024-10-25' AS Date), CAST(N'19:59:15.1267000' AS Time), N'Queso', 50, CAST(5.50 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (38, 1005, CAST(N'2024-10-25' AS Date), CAST(N'19:59:15.1267000' AS Time), N'Leche', 100, CAST(3.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (39, 1014, CAST(N'2024-10-29' AS Date), CAST(N'15:11:19.4400000' AS Time), N'Mantequilla', 160, CAST(4.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (40, 1010, CAST(N'2024-10-29' AS Date), CAST(N'15:11:19.4400000' AS Time), N'Cerveza', 60, CAST(3.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (41, 1009, CAST(N'2024-10-29' AS Date), CAST(N'15:11:19.4400000' AS Time), N'Gaseosa', 80, CAST(2.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (42, 1008, CAST(N'2024-10-29' AS Date), CAST(N'15:11:19.4400000' AS Time), N'Agua Mineral', 120, CAST(1.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (43, 1007, CAST(N'2024-10-29' AS Date), CAST(N'15:11:19.4400000' AS Time), N'Yogur', 80, CAST(2.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (44, 1006, CAST(N'2024-10-29' AS Date), CAST(N'15:11:19.4400000' AS Time), N'Queso', 50, CAST(5.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (45, 1005, CAST(N'2024-10-29' AS Date), CAST(N'15:11:19.4400000' AS Time), N'Leche', 100, CAST(3.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Productos_C] OFF
GO
INSERT [dbo].[Proveedores] ([CUIT], [Nombre], [RazonSocial], [Telefono], [Correo], [Direccion], [Banco], [TipoCuenta], [NumCuenta], [CBU], [Alias], [Act_B]) VALUES (N'12345678901', N'Juan', N'Razon Social 1', 1234567890, N'correo1@gmail.com', N'Dir1', N'Banco1', N'CC', N'1234', N'1234', N'banco1.alias1', 0)
INSERT [dbo].[Proveedores] ([CUIT], [Nombre], [RazonSocial], [Telefono], [Correo], [Direccion], [Banco], [TipoCuenta], [NumCuenta], [CBU], [Alias], [Act_B]) VALUES (N'20123456789', N'Rodolfo', N'Razon Social Ejemplo', 1234567890, N'proveedor@example.com', NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Proveedores] ([CUIT], [Nombre], [RazonSocial], [Telefono], [Correo], [Direccion], [Banco], [TipoCuenta], [NumCuenta], [CBU], [Alias], [Act_B]) VALUES (N'23456789012', N'Pedro', N'Razon Social 2', 1234567890, N'correo2@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Proveedores] ([CUIT], [Nombre], [RazonSocial], [Telefono], [Correo], [Direccion], [Banco], [TipoCuenta], [NumCuenta], [CBU], [Alias], [Act_B]) VALUES (N'34567890123', N'Daniel', N'Razon Social 3', 1234567890, N'correo3@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[ProveedoresSolicitudes] ([NumeroSolicitud], [CUIT]) VALUES (1, N'12345678901')
INSERT [dbo].[ProveedoresSolicitudes] ([NumeroSolicitud], [CUIT]) VALUES (1, N'20123456789')
GO
SET IDENTITY_INSERT [dbo].[Recepciones] ON 

INSERT [dbo].[Recepciones] ([NumeroRecepcion], [NumeroOrden], [FechaRecepcion], [NumeroFactura], [MontoFactura], [FechaFactura]) VALUES (1, 1, CAST(N'2024-10-29T14:25:23.757' AS DateTime), 1, CAST(100.00 AS Numeric(18, 2)), CAST(N'2024-10-29T14:25:23.750' AS DateTime))
INSERT [dbo].[Recepciones] ([NumeroRecepcion], [NumeroOrden], [FechaRecepcion], [NumeroFactura], [MontoFactura], [FechaFactura]) VALUES (2, 1, CAST(N'2024-10-29T14:26:38.443' AS DateTime), 2, CAST(50.00 AS Numeric(18, 2)), CAST(N'2024-10-29T14:26:38.440' AS DateTime))
SET IDENTITY_INSERT [dbo].[Recepciones] OFF
GO
SET IDENTITY_INSERT [dbo].[SolicitudesCotizacion] ON 

INSERT [dbo].[SolicitudesCotizacion] ([NumeroSolicitud], [FechaSolicitud]) VALUES (1, CAST(N'2024-10-27T16:42:44.647' AS DateTime))
SET IDENTITY_INSERT [dbo].[SolicitudesCotizacion] OFF
GO
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'11111111', N'Santy', N'Bravo', N'correo1@gmail.com', N'11111111Santy', N'fbf45b0b718a59431c099a2cab0c2b5cb9cc80288c957d8060d4daad85784608', 0, 1, 34, N'es')
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'22222222', N'Daniel', N'Bravo', N'correo2@gmail.com', N'22222222Daniel', N'fc2fc05df0eedb81e46bace0c1d8c3f918725755ce8062413ad121f32e500cc7', 0, 0, 35, N'es')
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'33333333', N'Juan', N'Bravo', N'correo3@gmail.com', N'33333333Juan', N'ca1955d9a81f6837da481396b94417d35bd64a5eb281122e552ef4975171fc49', 0, 1, 36, N'es')
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'44444444', N'John', N'Bravo', N'correo4@gmail.com', N'44444444John', N'3b9730b9a7a9218a392c7fe566524203e49d71fdd42a8ab3284477440b80b22a', 0, 1, 3027, N'es')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Username]    Script Date: 5/11/2024 23:40:50 ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [UC_Username] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT ((0)) FOR [Act_B]
GO
ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [DF_Act_B]  DEFAULT ((0)) FOR [Act_B]
GO
ALTER TABLE [dbo].[Productos] ADD  DEFAULT ((0)) FOR [PorcentajeIVA]
GO
ALTER TABLE [dbo].[Proveedores] ADD  DEFAULT ((0)) FOR [Act_B]
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
ALTER TABLE [dbo].[Productos_C]  WITH CHECK ADD  CONSTRAINT [FK__Productos__CodPr__10216507] FOREIGN KEY([CodigoProducto])
REFERENCES [dbo].[Productos] ([CodigoProducto])
GO
ALTER TABLE [dbo].[Productos_C] CHECK CONSTRAINT [FK__Productos__CodPr__10216507]
GO
ALTER TABLE [dbo].[ProveedoresSolicitudes]  WITH CHECK ADD FOREIGN KEY([NumeroSolicitud])
REFERENCES [dbo].[SolicitudesCotizacion] ([NumeroSolicitud])
GO
ALTER TABLE [dbo].[ProveedoresSolicitudes]  WITH CHECK ADD  CONSTRAINT [FK__Proveedore__CUIT__74AE54BC] FOREIGN KEY([CUIT])
REFERENCES [dbo].[Proveedores] ([CUIT])
GO
ALTER TABLE [dbo].[ProveedoresSolicitudes] CHECK CONSTRAINT [FK__Proveedore__CUIT__74AE54BC]
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
/****** Object:  StoredProcedure [dbo].[SP_BloquearUsuario]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Consultar]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ConsultarEventos]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ConsultarPorUsername]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ConsultarProductosC]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DeshabilitarUsuario]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ModificarUsuario]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ObtenerPermisos]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ObtenerUltimoNumeroTransaccionBancaria]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_RegistrarUsuario]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Trigger [dbo].[trg_Insert_Productos_C_After_Insert_Update]    Script Date: 5/11/2024 23:40:50 ******/
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
/****** Object:  Trigger [dbo].[trg_Restore_Productos_After_Update]    Script Date: 5/11/2024 23:40:50 ******/
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
