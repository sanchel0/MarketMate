USE [MarketMateDB]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[Clientes]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[DetallesOrdenCompra]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[DetallesRecepcion]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[DetallesSolicitud]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[DetallesVenta]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[DigitosVerificadores]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[Eventos]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[Facturas]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[OrdenesCompra]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[Permisos]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[Permisos1]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[PermisosPermisos]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[PermisosRoles]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[Productos]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[Productos_C]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[Proveedores]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[ProveedoresSolicitudes]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[Recepciones]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[SolicitudesCotizacion]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[Tickets]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 26/11/2024 23:58:09 ******/
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
INSERT [dbo].[DetallesOrdenCompra] ([NumeroOrden], [CodigoProducto], [CantidadSolicitada], [CantidadRecibida], [PrecioUnitario], [SubTotal], [PorcentajeIVA], [TotalConIVA]) VALUES (7, 1005, 5, 9, CAST(55.00 AS Decimal(10, 2)), CAST(275.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(5, 2)), CAST(283.25 AS Decimal(18, 2)))
INSERT [dbo].[DetallesOrdenCompra] ([NumeroOrden], [CodigoProducto], [CantidadSolicitada], [CantidadRecibida], [PrecioUnitario], [SubTotal], [PorcentajeIVA], [TotalConIVA]) VALUES (8, 1005, 4, 0, CAST(4.00 AS Decimal(10, 2)), CAST(16.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(5, 2)), CAST(16.64 AS Decimal(18, 2)))
INSERT [dbo].[DetallesOrdenCompra] ([NumeroOrden], [CodigoProducto], [CantidadSolicitada], [CantidadRecibida], [PrecioUnitario], [SubTotal], [PorcentajeIVA], [TotalConIVA]) VALUES (9, 1005, 4, 0, CAST(4.00 AS Decimal(10, 2)), CAST(16.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(5, 2)), CAST(16.64 AS Decimal(18, 2)))
INSERT [dbo].[DetallesOrdenCompra] ([NumeroOrden], [CodigoProducto], [CantidadSolicitada], [CantidadRecibida], [PrecioUnitario], [SubTotal], [PorcentajeIVA], [TotalConIVA]) VALUES (10, 1005, 5, 0, CAST(66.00 AS Decimal(10, 2)), CAST(330.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(5, 2)), CAST(346.50 AS Decimal(18, 2)))
INSERT [dbo].[DetallesOrdenCompra] ([NumeroOrden], [CodigoProducto], [CantidadSolicitada], [CantidadRecibida], [PrecioUnitario], [SubTotal], [PorcentajeIVA], [TotalConIVA]) VALUES (11, 1005, 5, 0, CAST(66.00 AS Decimal(10, 2)), CAST(330.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(5, 2)), CAST(346.50 AS Decimal(18, 2)))
INSERT [dbo].[DetallesOrdenCompra] ([NumeroOrden], [CodigoProducto], [CantidadSolicitada], [CantidadRecibida], [PrecioUnitario], [SubTotal], [PorcentajeIVA], [TotalConIVA]) VALUES (12, 1005, 5, 0, CAST(66.00 AS Decimal(10, 2)), CAST(330.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(5, 2)), CAST(346.50 AS Decimal(18, 2)))
INSERT [dbo].[DetallesOrdenCompra] ([NumeroOrden], [CodigoProducto], [CantidadSolicitada], [CantidadRecibida], [PrecioUnitario], [SubTotal], [PorcentajeIVA], [TotalConIVA]) VALUES (13, 1005, 5, 0, CAST(66.00 AS Decimal(10, 2)), CAST(330.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(5, 2)), CAST(346.50 AS Decimal(18, 2)))
GO
INSERT [dbo].[DetallesRecepcion] ([NumeroRecepcion], [CodigoProducto], [CantidadRecibida]) VALUES (1, 1005, 3)
INSERT [dbo].[DetallesRecepcion] ([NumeroRecepcion], [CodigoProducto], [CantidadRecibida]) VALUES (2, 1005, 2)
INSERT [dbo].[DetallesRecepcion] ([NumeroRecepcion], [CodigoProducto], [CantidadRecibida]) VALUES (15, 1005, 4)
INSERT [dbo].[DetallesRecepcion] ([NumeroRecepcion], [CodigoProducto], [CantidadRecibida]) VALUES (16, 1005, 5)
GO
INSERT [dbo].[DetallesSolicitud] ([NumeroSolicitud], [CodigoProducto], [Cantidad]) VALUES (1, 1005, 5)
INSERT [dbo].[DetallesSolicitud] ([NumeroSolicitud], [CodigoProducto], [Cantidad]) VALUES (2, 1005, 5)
INSERT [dbo].[DetallesSolicitud] ([NumeroSolicitud], [CodigoProducto], [Cantidad]) VALUES (2, 1006, 2)
INSERT [dbo].[DetallesSolicitud] ([NumeroSolicitud], [CodigoProducto], [Cantidad]) VALUES (3, 1005, 5)
GO
INSERT [dbo].[DetallesVenta] ([NumeroTicket], [CodigoProducto], [Cantidad], [PrecioUnitario], [SubTotal], [TotalConIVA]) VALUES (1, 1005, 1, CAST(3.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(3.09 AS Decimal(18, 2)))
INSERT [dbo].[DetallesVenta] ([NumeroTicket], [CodigoProducto], [Cantidad], [PrecioUnitario], [SubTotal], [TotalConIVA]) VALUES (2, 1005, 5, CAST(3.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(15.45 AS Decimal(18, 2)))
INSERT [dbo].[DetallesVenta] ([NumeroTicket], [CodigoProducto], [Cantidad], [PrecioUnitario], [SubTotal], [TotalConIVA]) VALUES (2, 1006, 10, CAST(5.50 AS Decimal(18, 2)), CAST(55.00 AS Decimal(18, 2)), CAST(56.10 AS Decimal(18, 2)))
INSERT [dbo].[DetallesVenta] ([NumeroTicket], [CodigoProducto], [Cantidad], [PrecioUnitario], [SubTotal], [TotalConIVA]) VALUES (3, 1005, 10, CAST(3.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)), CAST(30.90 AS Decimal(18, 2)))
INSERT [dbo].[DetallesVenta] ([NumeroTicket], [CodigoProducto], [Cantidad], [PrecioUnitario], [SubTotal], [TotalConIVA]) VALUES (3, 1006, 1, CAST(5.50 AS Decimal(18, 2)), CAST(5.50 AS Decimal(18, 2)), CAST(5.80 AS Decimal(18, 2)))
INSERT [dbo].[DetallesVenta] ([NumeroTicket], [CodigoProducto], [Cantidad], [PrecioUnitario], [SubTotal], [TotalConIVA]) VALUES (3, 1007, 5, CAST(2.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(10.20 AS Decimal(18, 2)))
GO
INSERT [dbo].[DigitosVerificadores] ([Tabla], [DVH], [DVV]) VALUES (N'Categorias', N'180e4a4b97f09112d03d6ca3c604a67c08ac1336bd3db7db46112096eb0c0fc6', N'0375d43a5e177f15515c8e826ffe2305ecdda020a8fd7da3a842e8d149bfbf2d')
INSERT [dbo].[DigitosVerificadores] ([Tabla], [DVH], [DVV]) VALUES (N'Clientes', N'0cab290edd4cdadcf86a6e3cf8e10a4f912fe8710a6f009acd9681431eed00b8', N'688ac63587481fca912bc8be17b846d75ff290fbae18819915a08c33921ab80f')
INSERT [dbo].[DigitosVerificadores] ([Tabla], [DVH], [DVV]) VALUES (N'DetallesOrdenCompra', N'6497d55eaa71997c60d8c461f8de835c3b6fcd423cc1b53f6254f5af6d77c259', N'9624057cef2e36a1065bd81235dfc0b0a930bbe565004023a866ce863f64436e')
INSERT [dbo].[DigitosVerificadores] ([Tabla], [DVH], [DVV]) VALUES (N'DetallesRecepcion', N'cb71149b340eaa5095c4f13eb87d00815977106efbb4271d05879ee0ac550eb1', N'0125a57e96152b43c70c1d0464126db7a18d3cdc84251b20d9bad7059eea9dc2')
INSERT [dbo].[DigitosVerificadores] ([Tabla], [DVH], [DVV]) VALUES (N'DetallesSolicitud', N'e30ad39d34917b4b613a6b9a80fa21d1d90165c56e50a9681dba9e59aae7eed8', N'30e1d3cb98a242360a43532000d981aa895c53ee99e381895dd45c8fa0b8b427')
INSERT [dbo].[DigitosVerificadores] ([Tabla], [DVH], [DVV]) VALUES (N'DetallesVenta', N'1e17bbc5ccfc7b817207796c67e694beeafa86f64a299a72d72e55f9d20a805a', N'e7c3d252b03982191190f2a313d369ac83e210880b561c3576a0bf00bc97207b')
INSERT [dbo].[DigitosVerificadores] ([Tabla], [DVH], [DVV]) VALUES (N'OrdenesCompra', N'f592c49e0b4abcc5a85d6ef2f243e8e3c2dd19b354adc0bce4e903645b90f01e', N'ce6fecb9b07f23b6a1b17f95b2e516828a265ddcd39c190680465376a939ce3c')
INSERT [dbo].[DigitosVerificadores] ([Tabla], [DVH], [DVV]) VALUES (N'Productos', N'd34a6994529f898b63fa5213cf41fc4b80e575279e1661f071c48d03ec7d806b', N'2da3f7ca7c9e41bded361f21b0e407e4b45e971be9b88cc18b79459a007639ea')
INSERT [dbo].[DigitosVerificadores] ([Tabla], [DVH], [DVV]) VALUES (N'Proveedores', N'0e00b68874385e80791c732b467d79a7209d05ffeb92499fdae0cdff7ee007a4', N'312256b09703c272aa24287b6334bf2c80f88a3764e2821d8b99f35cd354c93c')
INSERT [dbo].[DigitosVerificadores] ([Tabla], [DVH], [DVV]) VALUES (N'ProveedoresSolicitudes', N'3d32ffb8e438c2e2cd97b8372df48d69b23835e33ba8b2b6198b1758b5363997', N'e9678bec7f9db93d6187e328fcfdb594aaaf2ae0ec107f9eb35dcc32480c3227')
INSERT [dbo].[DigitosVerificadores] ([Tabla], [DVH], [DVV]) VALUES (N'Recepciones', N'd1c39e6202448a96d8bc2929eaf1e3a9bc3732e2be4795bd78ead6b4c60eb4dd', N'f254cec3fc0de737b45b8efca73ced3d2cd5f2e95635b715040b45fa2829b3a4')
INSERT [dbo].[DigitosVerificadores] ([Tabla], [DVH], [DVV]) VALUES (N'SolicitudesCotizacion', N'0f8e6197b5c53570a6e22c6dac950dfd4d7fbf181ede18219794be27551b4113', N'6147fb53c52bb817d530a8158cedb4cea4c5ad1dc856d0996ba7073568814f06')
INSERT [dbo].[DigitosVerificadores] ([Tabla], [DVH], [DVV]) VALUES (N'Tickets', N'7e1df4f3de7bb401cc65d63efdb98a803f0221116f4df8182bae2fd160ccbf92', N'be9a9e665ab3ac6beffc40d1b1695dc5be0a521d5dc274738c5706d5c69e8891')
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
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1171, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'11:47:56' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (1172, N'44444444John', CAST(N'2024-11-05' AS Date), CAST(N'11:48:11' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2126, N'44444444John', CAST(N'2024-11-16' AS Date), CAST(N'08:47:10' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2127, N'44444444John', CAST(N'2024-11-16' AS Date), CAST(N'08:47:12' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2128, N'44444444John', CAST(N'2024-11-16' AS Date), CAST(N'09:22:52' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2129, N'44444444John', CAST(N'2024-11-16' AS Date), CAST(N'09:22:55' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2130, N'11111111Santy', CAST(N'2024-11-16' AS Date), CAST(N'09:28:43' AS Time), N'DigitoVerificador', N'RecalcularDVs', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2131, N'11111111Santy', CAST(N'2024-11-16' AS Date), CAST(N'09:29:01' AS Time), N'DigitoVerificador', N'RecalcularDVs', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2132, N'11111111Santy', CAST(N'2024-11-16' AS Date), CAST(N'09:29:04' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2133, N'11111111Santy', CAST(N'2024-11-16' AS Date), CAST(N'09:29:05' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2134, N'11111111Santy', CAST(N'2024-11-17' AS Date), CAST(N'11:59:51' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2135, N'11111111Santy', CAST(N'2024-11-17' AS Date), CAST(N'12:00:21' AS Time), N'Perfiles', N'ModificarRol', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2136, N'11111111Santy', CAST(N'2024-11-17' AS Date), CAST(N'12:01:03' AS Time), N'Perfiles', N'ModificarFamilia', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2137, N'11111111Santy', CAST(N'2024-11-17' AS Date), CAST(N'12:01:56' AS Time), N'Perfiles', N'ModificarRol', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2138, N'11111111Santy', CAST(N'2024-11-17' AS Date), CAST(N'12:02:06' AS Time), N'Perfiles', N'ModificarRol', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2139, N'11111111Santy', CAST(N'2024-11-17' AS Date), CAST(N'12:02:44' AS Time), N'Perfiles', N'ModificarRol', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2140, N'11111111Santy', CAST(N'2024-11-17' AS Date), CAST(N'12:05:47' AS Time), N'Perfiles', N'RegistrarRol', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2141, N'11111111Santy', CAST(N'2024-11-17' AS Date), CAST(N'12:07:40' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2142, N'11111111Santy', CAST(N'2024-11-17' AS Date), CAST(N'12:10:08' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2143, N'11111111Santy', CAST(N'2024-11-17' AS Date), CAST(N'12:10:27' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2144, N'33333333Juan', CAST(N'2024-11-17' AS Date), CAST(N'12:13:20' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2145, N'33333333Juan', CAST(N'2024-11-17' AS Date), CAST(N'12:14:20' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2146, N'33333333Juan', CAST(N'2024-11-17' AS Date), CAST(N'05:18:32' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2147, N'33333333Juan', CAST(N'2024-11-17' AS Date), CAST(N'05:18:39' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2148, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'05:18:57' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2149, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'05:20:00' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2150, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'05:20:11' AS Time), N'Usuario', N'Logout', 1)
GO
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2151, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'05:56:38' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2152, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'05:57:55' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2153, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'05:58:35' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2154, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'05:59:19' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2155, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'05:59:41' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2156, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:17:25' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2157, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:18:38' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2158, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:21:06' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2159, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:21:11' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2160, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:22:22' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2161, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:22:28' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2162, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:23:46' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2163, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:24:01' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2164, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:24:40' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2165, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:24:59' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2166, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:25:32' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2167, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:25:42' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2168, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:25:54' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2169, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:25:58' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2170, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:27:35' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2171, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:27:39' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2172, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:27:51' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2173, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:27:55' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2174, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:28:20' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2175, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:29:01' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2176, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:32:43' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2177, N'44444444John', CAST(N'2024-11-17' AS Date), CAST(N'07:32:46' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2178, N'44444444John', CAST(N'2024-11-18' AS Date), CAST(N'03:29:03' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2179, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:09:56' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2180, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:10:11' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2181, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'02:22:52' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2182, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'02:22:59' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2183, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'02:27:25' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2184, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'02:27:33' AS Time), N'Reportes', N'GenerarReporte2', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2185, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'02:27:36' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2186, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'03:07:01' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2187, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'03:07:53' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2188, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'03:08:15' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2189, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'03:08:21' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2190, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'03:09:00' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2191, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'03:09:11' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2192, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'10:26:24' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2193, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'10:26:40' AS Time), N'Reportes', N'GenerarReporte2', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2194, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'10:26:44' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2195, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:22:03' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2196, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:22:55' AS Time), N'Compras', N'GenerarSolicitudCotizacion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2197, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:22:55' AS Time), N'Compras', N'RegistrarDetallesSolicitud', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2198, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:22:55' AS Time), N'Compras', N'RegistrarProveedoresSolicitud', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2199, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:25:50' AS Time), N'Compras', N'GenerarOrdenCompra', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2200, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:28:56' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2201, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:30:33' AS Time), N'Compras', N'GenerarOrdenCompra', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2202, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:33:10' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2203, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:33:27' AS Time), N'Compras', N'GenerarOrdenCompra', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2204, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:36:21' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2205, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:36:37' AS Time), N'Compras', N'GenerarOrdenCompra', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2206, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:39:34' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2207, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:39:46' AS Time), N'Compras', N'GenerarOrdenCompra', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2208, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:39:46' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2209, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:40:01' AS Time), N'Compras', N'ModificarOrdenCompra', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2210, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:40:08' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2211, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:56:45' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2212, N'44444444John', CAST(N'2024-11-19' AS Date), CAST(N'11:58:02' AS Time), N'Compras', N'RegistrarRecepcion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2213, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:00:29' AS Time), N'Compras', N'RegistrarRecepcion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2214, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:00:33' AS Time), N'Compras', N'RegistrarRecepcion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2215, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:00:58' AS Time), N'Compras', N'RegistrarRecepcion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2216, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:01:59' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2217, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:02:38' AS Time), N'Compras', N'RegistrarRecepcion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2218, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:02:56' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2219, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:04:05' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2220, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:10:04' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2221, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:11:33' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2222, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:12:03' AS Time), N'Compras', N'RegistrarRecepcion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2223, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:12:03' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2224, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:12:25' AS Time), N'Compras', N'RegistrarRecepcion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2225, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:12:25' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2226, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:12:29' AS Time), N'Compras', N'RegistrarRecepcion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2227, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:12:29' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2228, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:12:36' AS Time), N'Compras', N'RegistrarRecepcion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2229, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:12:36' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2230, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:12:44' AS Time), N'Compras', N'RegistrarRecepcion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2231, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:12:44' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2232, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:13:46' AS Time), N'Compras', N'RegistrarRecepcion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2233, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:15:02' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2234, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:15:30' AS Time), N'Compras', N'RegistrarRecepcion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2235, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:15:30' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2236, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:18:16' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2237, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:18:27' AS Time), N'Compras', N'RegistrarRecepcion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2238, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:18:27' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2239, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:18:27' AS Time), N'Inventario', N'ModificarProducto', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2240, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:18:27' AS Time), N'Compras', N'ModificarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2241, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:19:00' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2242, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:21:11' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2243, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:21:29' AS Time), N'Compras', N'RegistrarRecepcion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2244, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:21:29' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2245, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:21:29' AS Time), N'Inventario', N'ModificarProducto', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2246, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:21:29' AS Time), N'Compras', N'ModificarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2247, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:21:29' AS Time), N'Compras', N'ModificarOrdenCompra', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2248, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:22:53' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2249, N'44444444John', CAST(N'2024-11-20' AS Date), CAST(N'12:23:06' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2250, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'12:28:49' AS Time), N'DigitoVerificador', N'RecalcularDVs', 5)
GO
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2251, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'12:28:58' AS Time), N'DigitoVerificador', N'RecalcularDVs', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2252, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'12:35:43' AS Time), N'DigitoVerificador', N'RecalcularDVs', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2253, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'12:35:45' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2254, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'12:36:32' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2255, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'12:38:33' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2256, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'12:38:39' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2257, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'12:48:02' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2258, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:48:27' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2259, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:49:19' AS Time), N'Ventas', N'GenerarTicket', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2260, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:49:27' AS Time), N'Ventas', N'ModificarTicket', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2261, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:49:27' AS Time), N'Inventario', N'ModificarProducto', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2262, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:49:27' AS Time), N'Ventas', N'RegistrarDetallesTicket', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2263, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:49:27' AS Time), N'Reportes', N'GenerarReporte1', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2264, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:50:06' AS Time), N'Ventas', N'GenerarTicket', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2265, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:50:11' AS Time), N'Ventas', N'ModificarTicket', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2266, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:50:11' AS Time), N'Inventario', N'ModificarProducto', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2267, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:50:11' AS Time), N'Inventario', N'ModificarProducto', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2268, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:50:11' AS Time), N'Ventas', N'RegistrarDetallesTicket', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2269, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:50:11' AS Time), N'Reportes', N'GenerarReporte1', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2270, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:50:41' AS Time), N'Ventas', N'GenerarTicket', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2271, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:50:45' AS Time), N'Ventas', N'ModificarTicket', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2272, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:50:45' AS Time), N'Inventario', N'ModificarProducto', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2273, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:50:45' AS Time), N'Inventario', N'ModificarProducto', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2274, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:50:45' AS Time), N'Inventario', N'ModificarProducto', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2275, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:50:45' AS Time), N'Ventas', N'RegistrarDetallesTicket', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2276, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:50:45' AS Time), N'Reportes', N'GenerarReporte1', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2277, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:52:44' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2278, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:52:49' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2279, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'12:53:04' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2280, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'12:53:41' AS Time), N'Perfiles', N'ModificarRol', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2281, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'12:53:45' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2282, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:54:34' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2283, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:55:05' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2284, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:57:37' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2285, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:58:52' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2286, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'12:59:30' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2287, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'01:00:05' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2288, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'01:00:52' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2289, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'01:01:30' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2290, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'01:02:07' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2291, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'01:03:35' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2292, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'01:04:56' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2293, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'01:05:12' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2294, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'01:06:27' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2295, N'33333333Juan', CAST(N'2024-11-20' AS Date), CAST(N'01:15:25' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2296, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:16:29' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2297, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:27:03' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2298, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:28:07' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2299, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:28:20' AS Time), N'Perfiles', N'ModificarRol', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2300, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:28:28' AS Time), N'Perfiles', N'ModificarRol', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2301, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:28:38' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2302, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:29:13' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2303, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:29:15' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2304, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:29:34' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2305, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:29:36' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2306, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:29:52' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2307, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:30:02' AS Time), N'Perfiles', N'ModificarRol', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2308, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:30:06' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2309, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:31:13' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2310, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:32:00' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2311, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:32:09' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2312, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:32:38' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2313, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:33:29' AS Time), N'Perfiles', N'ModificarFamilia', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2314, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:33:36' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2315, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:37:14' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2316, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:37:18' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2317, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:37:28' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2318, N'11111111Santy', CAST(N'2024-11-20' AS Date), CAST(N'01:37:35' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2319, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:33:35' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2320, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:33:43' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2321, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:33:43' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2322, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:33:43' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2323, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:34:42' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2324, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:35:36' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2325, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:35:49' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2326, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:36:22' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2327, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:43:30' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2328, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:46:49' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2329, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:46:57' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2330, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:50:34' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2331, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:51:51' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2332, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:52:44' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2333, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:55:44' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2334, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:55:51' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2335, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:56:08' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2336, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:57:09' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2337, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:58:08' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2338, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'02:58:18' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2339, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'03:07:28' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2340, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'03:08:11' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2341, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'03:09:15' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2342, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'03:09:26' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2343, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'03:10:17' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2344, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'03:10:48' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2345, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'03:11:49' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2346, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'03:19:11' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2347, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:23:44' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2348, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:23:51' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2349, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:23:51' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2350, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:23:51' AS Time), N'Usuario', N'CambiarIdioma', 1)
GO
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2351, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:24:56' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2352, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:25:07' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2353, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:25:28' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2354, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:28:08' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2355, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:28:34' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2356, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:31:17' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2357, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:32:01' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2358, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:33:24' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2359, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:36:43' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2360, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:38:53' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2361, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:39:32' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2362, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:41:46' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2363, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'03:44:44' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2364, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'06:43:43' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2365, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'06:46:20' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2366, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'06:50:27' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2367, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'07:02:53' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2368, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'07:02:59' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2369, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'07:02:59' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2370, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'07:02:59' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2371, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'07:06:01' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2372, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'07:08:30' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2373, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'07:13:30' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2374, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'07:15:16' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2375, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'07:16:37' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2376, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'07:18:54' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2377, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'07:28:01' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2378, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'07:28:15' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2379, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'07:28:45' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2380, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'07:29:34' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2381, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'07:29:42' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2382, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'07:31:38' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2383, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'07:41:21' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2384, N'11111111Santy', CAST(N'2024-11-22' AS Date), CAST(N'07:44:42' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2385, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'07:55:58' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2386, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'07:59:09' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2387, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'08:01:26' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2388, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'08:02:43' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2389, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'08:03:42' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2390, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'08:05:03' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2391, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'08:08:34' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2392, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'08:16:49' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2393, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'10:12:22' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2394, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'10:20:24' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2395, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'10:21:12' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2396, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'10:22:56' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2397, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'10:23:23' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2398, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'10:41:14' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2399, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'10:51:06' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2400, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'10:52:14' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2401, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'10:56:14' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2402, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'10:56:26' AS Time), N'Reportes', N'GenerarReporte2', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2403, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'11:10:13' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2404, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'11:23:23' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2405, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'11:26:16' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2406, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'11:44:22' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2407, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'11:45:15' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2408, N'44444444John', CAST(N'2024-11-22' AS Date), CAST(N'11:46:29' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2409, N'33333333Juan', CAST(N'2024-11-22' AS Date), CAST(N'11:55:15' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2410, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'11:57:26' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2411, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'11:58:41' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2412, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'11:58:41' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2413, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'11:58:41' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2414, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'11:59:47' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2415, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'11:59:47' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2416, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'11:59:47' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2417, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'12:02:51' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2418, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'12:03:41' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2419, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'12:04:40' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2420, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'12:04:40' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2421, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'12:04:40' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2422, N'44444444John', CAST(N'2024-11-23' AS Date), CAST(N'12:20:06' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2423, N'44444444John', CAST(N'2024-11-23' AS Date), CAST(N'12:21:29' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2424, N'44444444John', CAST(N'2024-11-23' AS Date), CAST(N'12:22:06' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2425, N'44444444John', CAST(N'2024-11-23' AS Date), CAST(N'12:22:06' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2426, N'44444444John', CAST(N'2024-11-23' AS Date), CAST(N'12:22:06' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2427, N'44444444John', CAST(N'2024-11-23' AS Date), CAST(N'12:29:56' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2428, N'44444444John', CAST(N'2024-11-23' AS Date), CAST(N'12:32:26' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2429, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'02:16:31' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2430, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'02:17:44' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2431, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'02:20:01' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2432, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'02:20:32' AS Time), N'Ventas', N'GenerarTicket', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2433, N'33333333Juan', CAST(N'2024-11-23' AS Date), CAST(N'02:28:55' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2434, N'11111111Santy', CAST(N'2024-11-23' AS Date), CAST(N'02:32:01' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2435, N'11111111Santy', CAST(N'2024-11-23' AS Date), CAST(N'02:32:11' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2436, N'11111111Santy', CAST(N'2024-11-23' AS Date), CAST(N'02:32:11' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2437, N'11111111Santy', CAST(N'2024-11-23' AS Date), CAST(N'02:32:11' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2438, N'11111111Santy', CAST(N'2024-11-23' AS Date), CAST(N'02:33:48' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2439, N'11111111Santy', CAST(N'2024-11-23' AS Date), CAST(N'02:37:11' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2440, N'11111111Santy', CAST(N'2024-11-23' AS Date), CAST(N'02:37:13' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2441, N'11111111Santy', CAST(N'2024-11-23' AS Date), CAST(N'03:22:24' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2442, N'44444444John', CAST(N'2024-11-24' AS Date), CAST(N'02:10:34' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2443, N'44444444John', CAST(N'2024-11-24' AS Date), CAST(N'02:13:22' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2444, N'44444444John', CAST(N'2024-11-24' AS Date), CAST(N'02:13:27' AS Time), N'Reportes', N'GenerarReporte2', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2445, N'44444444John', CAST(N'2024-11-24' AS Date), CAST(N'02:54:22' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2446, N'44444444John', CAST(N'2024-11-24' AS Date), CAST(N'02:54:29' AS Time), N'Reportes', N'GenerarReporte2', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2447, N'44444444John', CAST(N'2024-11-24' AS Date), CAST(N'02:58:44' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (2448, N'44444444John', CAST(N'2024-11-24' AS Date), CAST(N'02:58:48' AS Time), N'Reportes', N'GenerarReporte2', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3442, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'10:53:23' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3443, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'10:53:29' AS Time), N'Usuario', N'ModificarUsuario', 5)
GO
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3444, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'10:53:29' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3445, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'10:53:29' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3446, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'10:53:34' AS Time), N'Reportes', N'GenerarReporte2', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3447, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'10:55:53' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3448, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'10:55:58' AS Time), N'Reportes', N'GenerarReporte2', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3449, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'10:56:53' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3450, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'11:05:20' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3451, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'11:05:23' AS Time), N'Reportes', N'GenerarReporte2', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3452, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'11:05:40' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3453, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'11:07:37' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3454, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'11:08:21' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3455, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'11:11:13' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3456, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'11:11:18' AS Time), N'Reportes', N'GenerarReporte2', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3457, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'11:22:05' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3458, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'11:22:13' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3459, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'11:22:13' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3460, N'44444444John', CAST(N'2024-11-25' AS Date), CAST(N'11:22:13' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3461, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'01:02:40' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3462, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'01:02:46' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3463, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'01:02:46' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3464, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'01:02:46' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3465, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'01:03:15' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3466, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'03:40:20' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3467, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'03:40:25' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3468, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'03:40:25' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3469, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'03:40:25' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3470, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'03:41:46' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3471, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'03:45:12' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3472, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'03:45:30' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3473, N'33333333Juan', CAST(N'2024-11-26' AS Date), CAST(N'03:46:01' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3474, N'33333333Juan', CAST(N'2024-11-26' AS Date), CAST(N'03:46:17' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3475, N'33333333Juan', CAST(N'2024-11-26' AS Date), CAST(N'03:46:17' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3476, N'33333333Juan', CAST(N'2024-11-26' AS Date), CAST(N'03:46:17' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3477, N'33333333Juan', CAST(N'2024-11-26' AS Date), CAST(N'03:48:32' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3478, N'33333333Juan', CAST(N'2024-11-26' AS Date), CAST(N'03:49:32' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3479, N'33333333Juan', CAST(N'2024-11-26' AS Date), CAST(N'03:49:59' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3480, N'33333333Juan', CAST(N'2024-11-26' AS Date), CAST(N'03:52:04' AS Time), N'Ventas', N'GenerarTicket', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3481, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'03:54:05' AS Time), N'DigitoVerificador', N'RecalcularDVs', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3482, N'33333333Juan', CAST(N'2024-11-26' AS Date), CAST(N'03:54:15' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3483, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'03:54:45' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3484, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'04:01:02' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3485, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'04:03:37' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3486, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'04:05:36' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3487, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'04:05:40' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3488, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'04:05:40' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3489, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'04:05:40' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3490, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'04:06:14' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3491, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'04:06:39' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3492, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'04:07:17' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3493, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'04:09:40' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3494, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'04:09:45' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3495, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'04:09:45' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3496, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'04:09:45' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3497, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'04:16:00' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3498, N'33333333Juan', CAST(N'2024-11-26' AS Date), CAST(N'04:16:13' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3499, N'33333333Juan', CAST(N'2024-11-26' AS Date), CAST(N'04:17:05' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3500, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:06:23' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3501, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:06:55' AS Time), N'Compras', N'GenerarOrdenCompra', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3502, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:06:55' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3503, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:07:31' AS Time), N'Compras', N'GenerarOrdenCompra', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3504, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:07:31' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3505, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:09:38' AS Time), N'Compras', N'GenerarSolicitudCotizacion', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3506, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:09:38' AS Time), N'Compras', N'RegistrarDetallesSolicitud', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3507, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:09:38' AS Time), N'Compras', N'RegistrarProveedoresSolicitud', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3508, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:09:43' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3509, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:09:44' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3510, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:10:05' AS Time), N'Compras', N'GenerarOrdenCompra', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3511, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:10:05' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3512, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:11:01' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3513, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:11:15' AS Time), N'Compras', N'GenerarOrdenCompra', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3514, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:11:15' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3515, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:11:36' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3516, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:11:36' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3517, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:11:36' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3518, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:11:52' AS Time), N'Compras', N'GenerarOrdenCompra', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3519, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:11:52' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3520, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:12:13' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3521, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:12:29' AS Time), N'Compras', N'GenerarOrdenCompra', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3522, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:12:29' AS Time), N'Compras', N'RegistrarDetallesOrden', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3523, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:46:30' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3524, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:46:54' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3525, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:49:52' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3526, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'05:52:56' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3527, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:33:07' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3528, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:33:34' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3529, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:49:12' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3530, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:51:14' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3531, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:51:31' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3532, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:52:02' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3533, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:55:05' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3534, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:55:39' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3535, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:56:11' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3536, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:56:32' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3537, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:56:53' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3538, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:57:20' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3539, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:58:13' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3540, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:59:08' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3541, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'06:59:38' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3542, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:39:43' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3543, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:42:06' AS Time), N'Usuario', N'Login', 1)
GO
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3544, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:46:04' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3545, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:48:08' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3546, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:48:30' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3547, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:49:34' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3548, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:49:37' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3549, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:49:37' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3550, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:49:37' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3551, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:49:41' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3552, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:49:50' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3553, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:51:52' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3554, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:52:07' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3555, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:52:56' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3556, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:53:16' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3557, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'10:53:37' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3558, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'10:54:08' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3559, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'10:54:39' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3560, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:54:52' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3561, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:55:02' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3562, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:55:02' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3563, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:55:02' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3564, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'10:55:08' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3565, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'10:55:13' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3566, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'10:55:22' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3567, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'11:11:02' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3568, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'11:11:08' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3569, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'11:11:08' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3570, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'11:11:08' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3571, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'11:11:44' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3572, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'11:29:21' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3573, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'11:29:28' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3574, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:29:42' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3575, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:30:53' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3576, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:30:56' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3577, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:30:56' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3578, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:30:56' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3579, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:34:58' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3580, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'11:42:31' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3581, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'11:42:38' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3582, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'11:42:38' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3583, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'11:42:38' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3584, N'11111111Santy', CAST(N'2024-11-26' AS Date), CAST(N'11:42:58' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3585, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:48:53' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3586, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:49:32' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3587, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:49:38' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3588, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:49:38' AS Time), N'Usuario', N'ModificarUsuario', 5)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3589, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:49:38' AS Time), N'Usuario', N'CambiarIdioma', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3590, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:49:45' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3591, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:49:54' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3592, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:50:02' AS Time), N'Usuario', N'Logout', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3593, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:54:24' AS Time), N'Usuario', N'Login', 1)
INSERT [dbo].[Eventos] ([EventoID], [Username], [Fecha], [Hora], [Modulo], [Operacion], [Criticidad]) VALUES (3594, N'44444444John', CAST(N'2024-11-26' AS Date), CAST(N'11:54:33' AS Time), N'Usuario', N'Logout', 1)
SET IDENTITY_INSERT [dbo].[Eventos] OFF
GO
SET IDENTITY_INSERT [dbo].[OrdenesCompra] ON 

INSERT [dbo].[OrdenesCompra] ([NumeroOrden], [FechaEmision], [FechaLimiteEntrega], [CUIT], [NumeroSolicitud], [NumeroCotizacion], [Estado], [Total], [NumeroTransferencia]) VALUES (1, CAST(N'2024-10-29T00:03:04.810' AS DateTime), CAST(N'2024-10-29T00:02:50.017' AS DateTime), N'12345678901', 1, 2, N'Completo', CAST(250.00 AS Decimal(18, 2)), N'0')
INSERT [dbo].[OrdenesCompra] ([NumeroOrden], [FechaEmision], [FechaLimiteEntrega], [CUIT], [NumeroSolicitud], [NumeroCotizacion], [Estado], [Total], [NumeroTransferencia]) VALUES (2, CAST(N'2024-10-29T00:09:54.173' AS DateTime), CAST(N'2024-10-29T00:09:33.000' AS DateTime), N'12345678901', 1, 0, N'Pendiente', CAST(250.00 AS Decimal(18, 2)), N'1')
INSERT [dbo].[OrdenesCompra] ([NumeroOrden], [FechaEmision], [FechaLimiteEntrega], [CUIT], [NumeroSolicitud], [NumeroCotizacion], [Estado], [Total], [NumeroTransferencia]) VALUES (7, CAST(N'2024-11-19T23:39:46.420' AS DateTime), CAST(N'2024-11-20T23:39:35.000' AS DateTime), N'12345678901', 2, 5, N'Completo', CAST(275.00 AS Decimal(18, 2)), N'423423423')
INSERT [dbo].[OrdenesCompra] ([NumeroOrden], [FechaEmision], [FechaLimiteEntrega], [CUIT], [NumeroSolicitud], [NumeroCotizacion], [Estado], [Total], [NumeroTransferencia]) VALUES (8, CAST(N'2024-11-26T17:06:55.543' AS DateTime), CAST(N'2024-11-26T17:06:33.847' AS DateTime), N'20123456789', 1, 234, N'Pendiente', CAST(16.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrdenesCompra] ([NumeroOrden], [FechaEmision], [FechaLimiteEntrega], [CUIT], [NumeroSolicitud], [NumeroCotizacion], [Estado], [Total], [NumeroTransferencia]) VALUES (9, CAST(N'2024-11-26T17:07:31.697' AS DateTime), CAST(N'2024-11-26T17:06:33.847' AS DateTime), N'12345678901', 1, 234, N'Pendiente', CAST(16.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrdenesCompra] ([NumeroOrden], [FechaEmision], [FechaLimiteEntrega], [CUIT], [NumeroSolicitud], [NumeroCotizacion], [Estado], [Total], [NumeroTransferencia]) VALUES (10, CAST(N'2024-11-26T17:10:05.790' AS DateTime), CAST(N'2024-11-26T17:09:49.733' AS DateTime), N'12345678901', 3, 53453453, N'Pendiente', CAST(330.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrdenesCompra] ([NumeroOrden], [FechaEmision], [FechaLimiteEntrega], [CUIT], [NumeroSolicitud], [NumeroCotizacion], [Estado], [Total], [NumeroTransferencia]) VALUES (11, CAST(N'2024-11-26T17:11:15.007' AS DateTime), CAST(N'2024-11-26T17:11:02.990' AS DateTime), N'12345678901', 3, 5345345, N'Pendiente', CAST(330.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrdenesCompra] ([NumeroOrden], [FechaEmision], [FechaLimiteEntrega], [CUIT], [NumeroSolicitud], [NumeroCotizacion], [Estado], [Total], [NumeroTransferencia]) VALUES (12, CAST(N'2024-11-26T17:11:52.387' AS DateTime), CAST(N'2024-11-26T17:11:38.760' AS DateTime), N'12345678901', 3, 645645654, N'Pendiente', CAST(330.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrdenesCompra] ([NumeroOrden], [FechaEmision], [FechaLimiteEntrega], [CUIT], [NumeroSolicitud], [NumeroCotizacion], [Estado], [Total], [NumeroTransferencia]) VALUES (13, CAST(N'2024-11-26T17:12:29.173' AS DateTime), CAST(N'2024-11-26T17:12:15.833' AS DateTime), N'12345678901', 3, 423423, N'Pendiente', CAST(330.00 AS Decimal(18, 2)), NULL)
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
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (3029, N'RotacionProductos', N'Patente')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (3030, N'Gerente', N'Rol')
INSERT [dbo].[Permisos] ([Codigo], [Nombre], [Tipo]) VALUES (3031, N'Ayuda', N'Patente')
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
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (25, 3022)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (28, 29)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (28, 30)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (28, 31)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (32, 33)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (34, 25)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (34, 1021)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (34, 3031)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (35, 32)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (35, 1021)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (35, 1023)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (36, 29)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (36, 30)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (36, 32)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (36, 1021)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (36, 1023)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (36, 3029)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (36, 3031)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (1021, 21)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (1021, 22)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (1021, 23)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (1021, 24)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (1022, 1023)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (1022, 3028)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (1022, 3029)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 31)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 3021)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 3023)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 3024)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3026, 3025)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3027, 1021)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3027, 3026)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3027, 3028)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3027, 3029)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3027, 3031)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3030, 28)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3030, 32)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3030, 1021)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3030, 1022)
INSERT [dbo].[PermisosPermisos] ([PermisoPadreCod], [PermisoHijoCod]) VALUES (3030, 3026)
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [StockMinimo], [StockMaximo], [Act_B], [Marca], [PorcentajeIVA]) VALUES (1005, N'Leche', 93, 1, CAST(3.00 AS Decimal(18, 2)), 10, 200, 0, N'La Serenísima', CAST(3.00 AS Decimal(5, 2)))
INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [StockMinimo], [StockMaximo], [Act_B], [Marca], [PorcentajeIVA]) VALUES (1006, N'Queso', 39, 1, CAST(5.50 AS Decimal(18, 2)), 5, 100, 0, N'La Serenísima', CAST(5.50 AS Decimal(5, 2)))
INSERT [dbo].[Productos] ([CodigoProducto], [Nombre], [Stock], [CodigoCategoria], [Precio], [StockMinimo], [StockMaximo], [Act_B], [Marca], [PorcentajeIVA]) VALUES (1007, N'Yogur', 75, 1, CAST(2.00 AS Decimal(18, 2)), 20, 150, 0, N'La Serenísima', CAST(2.00 AS Decimal(5, 2)))
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
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (43, 1007, CAST(N'2024-10-29' AS Date), CAST(N'15:11:19.4400000' AS Time), N'Yogur', 80, CAST(2.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (44, 1006, CAST(N'2024-10-29' AS Date), CAST(N'15:11:19.4400000' AS Time), N'Queso', 50, CAST(5.50 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (45, 1005, CAST(N'2024-10-29' AS Date), CAST(N'15:11:19.4400000' AS Time), N'Leche', 100, CAST(3.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (46, 1005, CAST(N'2024-11-20' AS Date), CAST(N'00:18:27.3500000' AS Time), N'Leche', 104, CAST(3.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (47, 1005, CAST(N'2024-11-20' AS Date), CAST(N'00:21:29.8700000' AS Time), N'Leche', 109, CAST(3.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (48, 1005, CAST(N'2024-11-20' AS Date), CAST(N'00:49:27.5967000' AS Time), N'Leche', 108, CAST(3.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (49, 1006, CAST(N'2024-11-20' AS Date), CAST(N'00:50:11.2800000' AS Time), N'Queso', 40, CAST(5.50 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (50, 1005, CAST(N'2024-11-20' AS Date), CAST(N'00:50:11.2800000' AS Time), N'Leche', 103, CAST(3.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (51, 1005, CAST(N'2024-11-20' AS Date), CAST(N'00:50:45.4100000' AS Time), N'Leche', 93, CAST(3.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (52, 1007, CAST(N'2024-11-20' AS Date), CAST(N'00:50:45.4133000' AS Time), N'Yogur', 75, CAST(2.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Productos_C] ([CambioID], [CodigoProducto], [Fecha], [Hora], [Nombre], [Stock], [Precio], [Act]) VALUES (53, 1006, CAST(N'2024-11-20' AS Date), CAST(N'00:50:45.4167000' AS Time), N'Queso', 39, CAST(5.50 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Productos_C] OFF
GO
INSERT [dbo].[Proveedores] ([CUIT], [Nombre], [RazonSocial], [Telefono], [Correo], [Direccion], [Banco], [TipoCuenta], [NumCuenta], [CBU], [Alias], [Act_B]) VALUES (N'12345678901', N'Juan', N'Razon Social 1', 1234567890, N'correo1@gmail.com', N'Dir1', N'Banco1', N'CC', N'1234', N'1234', N'banco1.alias1', 0)
INSERT [dbo].[Proveedores] ([CUIT], [Nombre], [RazonSocial], [Telefono], [Correo], [Direccion], [Banco], [TipoCuenta], [NumCuenta], [CBU], [Alias], [Act_B]) VALUES (N'20123456789', N'Rodolfo', N'Razon Social Ejemplo', 1234567890, N'proveedor@example.com', NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Proveedores] ([CUIT], [Nombre], [RazonSocial], [Telefono], [Correo], [Direccion], [Banco], [TipoCuenta], [NumCuenta], [CBU], [Alias], [Act_B]) VALUES (N'23456789012', N'Pedro', N'Razon Social 2', 1234567890, N'correo2@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Proveedores] ([CUIT], [Nombre], [RazonSocial], [Telefono], [Correo], [Direccion], [Banco], [TipoCuenta], [NumCuenta], [CBU], [Alias], [Act_B]) VALUES (N'34567890123', N'Daniel', N'Razon Social 3', 1234567890, N'correo3@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[ProveedoresSolicitudes] ([NumeroSolicitud], [CUIT]) VALUES (1, N'12345678901')
INSERT [dbo].[ProveedoresSolicitudes] ([NumeroSolicitud], [CUIT]) VALUES (1, N'20123456789')
INSERT [dbo].[ProveedoresSolicitudes] ([NumeroSolicitud], [CUIT]) VALUES (2, N'12345678901')
INSERT [dbo].[ProveedoresSolicitudes] ([NumeroSolicitud], [CUIT]) VALUES (2, N'20123456789')
INSERT [dbo].[ProveedoresSolicitudes] ([NumeroSolicitud], [CUIT]) VALUES (2, N'23456789012')
INSERT [dbo].[ProveedoresSolicitudes] ([NumeroSolicitud], [CUIT]) VALUES (3, N'12345678901')
INSERT [dbo].[ProveedoresSolicitudes] ([NumeroSolicitud], [CUIT]) VALUES (3, N'20123456789')
INSERT [dbo].[ProveedoresSolicitudes] ([NumeroSolicitud], [CUIT]) VALUES (3, N'23456789012')
INSERT [dbo].[ProveedoresSolicitudes] ([NumeroSolicitud], [CUIT]) VALUES (3, N'34567890123')
GO
SET IDENTITY_INSERT [dbo].[Recepciones] ON 

INSERT [dbo].[Recepciones] ([NumeroRecepcion], [NumeroOrden], [FechaRecepcion], [NumeroFactura], [MontoFactura], [FechaFactura]) VALUES (1, 1, CAST(N'2024-10-29T14:25:23.757' AS DateTime), 1, CAST(100.00 AS Numeric(18, 2)), CAST(N'2024-10-29T14:25:23.750' AS DateTime))
INSERT [dbo].[Recepciones] ([NumeroRecepcion], [NumeroOrden], [FechaRecepcion], [NumeroFactura], [MontoFactura], [FechaFactura]) VALUES (2, 1, CAST(N'2024-10-29T14:26:38.443' AS DateTime), 2, CAST(50.00 AS Numeric(18, 2)), CAST(N'2024-10-29T14:26:38.440' AS DateTime))
INSERT [dbo].[Recepciones] ([NumeroRecepcion], [NumeroOrden], [FechaRecepcion], [NumeroFactura], [MontoFactura], [FechaFactura]) VALUES (3, 7, CAST(N'2024-11-20T23:56:47.000' AS DateTime), 21, CAST(275.00 AS Numeric(18, 2)), CAST(N'2024-11-20T23:56:47.000' AS DateTime))
INSERT [dbo].[Recepciones] ([NumeroRecepcion], [NumeroOrden], [FechaRecepcion], [NumeroFactura], [MontoFactura], [FechaFactura]) VALUES (4, 7, CAST(N'2024-11-20T23:56:47.000' AS DateTime), 21, CAST(275.00 AS Numeric(18, 2)), CAST(N'2024-11-20T23:56:47.000' AS DateTime))
INSERT [dbo].[Recepciones] ([NumeroRecepcion], [NumeroOrden], [FechaRecepcion], [NumeroFactura], [MontoFactura], [FechaFactura]) VALUES (5, 7, CAST(N'2024-11-20T23:56:47.000' AS DateTime), 21, CAST(275.00 AS Numeric(18, 2)), CAST(N'2024-11-20T23:56:47.000' AS DateTime))
INSERT [dbo].[Recepciones] ([NumeroRecepcion], [NumeroOrden], [FechaRecepcion], [NumeroFactura], [MontoFactura], [FechaFactura]) VALUES (6, 7, CAST(N'2024-11-20T23:56:47.000' AS DateTime), 21, CAST(275.00 AS Numeric(18, 2)), CAST(N'2024-11-20T23:56:47.000' AS DateTime))
INSERT [dbo].[Recepciones] ([NumeroRecepcion], [NumeroOrden], [FechaRecepcion], [NumeroFactura], [MontoFactura], [FechaFactura]) VALUES (13, 7, CAST(N'2024-11-20T00:11:34.000' AS DateTime), 77, CAST(100.00 AS Numeric(18, 2)), CAST(N'2024-11-20T00:11:34.000' AS DateTime))
INSERT [dbo].[Recepciones] ([NumeroRecepcion], [NumeroOrden], [FechaRecepcion], [NumeroFactura], [MontoFactura], [FechaFactura]) VALUES (15, 7, CAST(N'2024-11-20T00:18:17.890' AS DateTime), 34, CAST(534.00 AS Numeric(18, 2)), CAST(N'2024-11-20T00:18:17.887' AS DateTime))
INSERT [dbo].[Recepciones] ([NumeroRecepcion], [NumeroOrden], [FechaRecepcion], [NumeroFactura], [MontoFactura], [FechaFactura]) VALUES (16, 7, CAST(N'2024-11-20T00:21:13.280' AS DateTime), 665, CAST(54.00 AS Numeric(18, 2)), CAST(N'2024-11-20T00:21:13.273' AS DateTime))
SET IDENTITY_INSERT [dbo].[Recepciones] OFF
GO
SET IDENTITY_INSERT [dbo].[SolicitudesCotizacion] ON 

INSERT [dbo].[SolicitudesCotizacion] ([NumeroSolicitud], [FechaSolicitud]) VALUES (1, CAST(N'2024-10-27T16:42:44.647' AS DateTime))
INSERT [dbo].[SolicitudesCotizacion] ([NumeroSolicitud], [FechaSolicitud]) VALUES (2, CAST(N'2024-11-19T23:22:55.103' AS DateTime))
INSERT [dbo].[SolicitudesCotizacion] ([NumeroSolicitud], [FechaSolicitud]) VALUES (3, CAST(N'2024-11-26T17:09:38.883' AS DateTime))
SET IDENTITY_INSERT [dbo].[SolicitudesCotizacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 

INSERT [dbo].[Tickets] ([NumeroTicket], [NumeroTransaccionBancaria], [MetodoPago], [TipoTarjeta], [NumeroTarjeta], [AliasMP], [Fecha], [Monto], [DniCliente]) VALUES (1, NULL, N'Efectivo', NULL, NULL, NULL, CAST(N'2024-11-20' AS Date), CAST(3.09 AS Decimal(18, 2)), N'77777777')
INSERT [dbo].[Tickets] ([NumeroTicket], [NumeroTransaccionBancaria], [MetodoPago], [TipoTarjeta], [NumeroTarjeta], [AliasMP], [Fecha], [Monto], [DniCliente]) VALUES (2, NULL, N'Efectivo', NULL, NULL, NULL, CAST(N'2024-11-20' AS Date), CAST(71.55 AS Decimal(18, 2)), N'77777777')
INSERT [dbo].[Tickets] ([NumeroTicket], [NumeroTransaccionBancaria], [MetodoPago], [TipoTarjeta], [NumeroTarjeta], [AliasMP], [Fecha], [Monto], [DniCliente]) VALUES (3, NULL, N'Efectivo', NULL, NULL, NULL, CAST(N'2024-11-20' AS Date), CAST(46.90 AS Decimal(18, 2)), N'77777777')
SET IDENTITY_INSERT [dbo].[Tickets] OFF
GO
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'11111111', N'Santy', N'Bravo', N'correo1@gmail.com', N'11111111Santy', N'fbf45b0b718a59431c099a2cab0c2b5cb9cc80288c957d8060d4daad85784608', 0, 1, 34, N'en')
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'22222222', N'Daniel', N'Bravo', N'correo2@gmail.com', N'22222222Daniel', N'fc2fc05df0eedb81e46bace0c1d8c3f918725755ce8062413ad121f32e500cc7', 0, 0, 35, N'es')
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'33333333', N'Juan', N'Bravo', N'correo3@gmail.com', N'33333333Juan', N'ca1955d9a81f6837da481396b94417d35bd64a5eb281122e552ef4975171fc49', 0, 1, 36, N'en')
INSERT [dbo].[Usuarios] ([Dni], [Nombre], [Apellido], [Correo], [Username], [Password], [Bloqueo], [Activo], [Rol], [Idioma]) VALUES (N'44444444', N'John', N'Bravo', N'correo4@gmail.com', N'44444444John', N'3b9730b9a7a9218a392c7fe566524203e49d71fdd42a8ab3284477440b80b22a', 0, 1, 3027, N'en')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Username]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_BloquearUsuario]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Consultar]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ConsultarEventos]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ConsultarPorUsername]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ConsultarProductosC]    Script Date: 26/11/2024 23:58:09 ******/
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
        N'@CodigoProducto INT, @FechaInicio DATE, @FechaFin DATE, @Nombre NVARCHAR(100)',
        @CodigoProducto, @FechaInicio, @FechaFin, @Nombre;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeshabilitarUsuario]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ModificarUsuario]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ObtenerPermisos]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ObtenerUltimoNumeroTransaccionBancaria]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_RegistrarUsuario]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Trigger [dbo].[trg_Insert_Productos_C_After_Insert_Update]    Script Date: 26/11/2024 23:58:09 ******/
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
/****** Object:  Trigger [dbo].[trg_Restore_Productos_After_Update]    Script Date: 26/11/2024 23:58:09 ******/
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
