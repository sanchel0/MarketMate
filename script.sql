USE [master]
GO
/****** Object:  Database [DBMarketMate]    Script Date: 30/05/2024 0:23:17 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 30/05/2024 0:23:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RolID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 30/05/2024 0:23:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[DNI] [char](8) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](254) NOT NULL,
	[RolID] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](64) NOT NULL,
	[Bloqueo] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RolID], [Nombre]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RolID], [Nombre]) VALUES (2, N'Cajero')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
INSERT [dbo].[Usuarios] ([DNI], [Nombre], [Apellido], [Correo], [RolID], [Username], [Password], [Bloqueo], [Activo]) VALUES (N'12345678', N'Santi', N'Bravo', N'correo@gmail.com', 1, N'12345678Santy', N'd21a4dee283640cf860a8b50618f144b0b8ba6967a99e349ce94b39b1477af1f', 0, 1)
INSERT [dbo].[Usuarios] ([DNI], [Nombre], [Apellido], [Correo], [RolID], [Username], [Password], [Bloqueo], [Activo]) VALUES (N'18273645', N'Roberto', N'Bravo', N'correo4@gmail.com', 2, N'18273645Roberto', N'4d5085c8ecd0e3c64f2d76792df232aabd30df9604735ae72c49da7da8b75436', 0, 0)
INSERT [dbo].[Usuarios] ([DNI], [Nombre], [Apellido], [Correo], [RolID], [Username], [Password], [Bloqueo], [Activo]) VALUES (N'43215678', N'Maty', N'Bravo', N'correo5@gmail.com', 2, N'43215678Maty', N'649c705cccb0d5f3447a7de112e47de0aca0a8f61e474db5f5693879f25d2646', 1, 1)
INSERT [dbo].[Usuarios] ([DNI], [Nombre], [Apellido], [Correo], [RolID], [Username], [Password], [Bloqueo], [Activo]) VALUES (N'87651234', N'Juan', N'Bravo', N'correo3@gmail.com', 2, N'87651234Juan', N'619ec8fd0050c1772bdb224dad344a1df9f4a1d0d938574bf105ad2dd9857485', 0, 1)
INSERT [dbo].[Usuarios] ([DNI], [Nombre], [Apellido], [Correo], [RolID], [Username], [Password], [Bloqueo], [Activo]) VALUES (N'87654321', N'Daniel', N'Bravo', N'correo2@gmail.com', 1, N'87654321Daniel', N'4e53ba0a31fb7d712f2b27c705dea712a01b59a6a9e65fdea602274bac6eca13', 0, 1)
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([RolID])
REFERENCES [dbo].[Roles] ([RolID])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD CHECK  (([DNI] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD CHECK  ((len([Password])>=(8) AND len([Password])<=(64)))
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD CHECK  ((len([Username])>=(6) AND len([Username])<=(50)))
GO
/****** Object:  StoredProcedure [dbo].[SP_BloquearUsuario]    Script Date: 30/05/2024 0:23:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Consultar]    Script Date: 30/05/2024 0:23:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ConsultarPorUsername]    Script Date: 30/05/2024 0:23:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DeshabilitarUsuario]    Script Date: 30/05/2024 0:23:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeshabilitarUsuario]
    @DNI CHAR(8)
AS
BEGIN
    SET NOCOUNT ON;

    -- Actualizar el campo Activo a 0 para deshabilitar el usuario
    UPDATE [dbo].[Usuarios]
    SET [Activo] = 0
    WHERE [DNI] = @DNI;
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ModificarUsuario]    Script Date: 30/05/2024 0:23:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ModificarUsuario]
    @DNI CHAR(8),
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Correo NVARCHAR(254),
    @RolID INT,
    @Username NVARCHAR(50),
    @Password NVARCHAR(64),
    @Bloqueo BIT,
    @Activo BIT
AS
BEGIN
    SET NOCOUNT ON;

    -- Actualizar los datos del usuario
    UPDATE [dbo].[Usuarios]
    SET
        [Nombre] = @Nombre,
        [Apellido] = @Apellido,
        [Correo] = @Correo,
        [RolID] = @RolID,
        [Username] = @Username,
        [Password] = @Password,
        [Bloqueo] = @Bloqueo,
        [Activo] = @Activo
    WHERE
        [DNI] = @DNI;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarUsuario]    Script Date: 30/05/2024 0:23:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RegistrarUsuario]
	@DNI CHAR(8),
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Correo NVARCHAR(254),
    @RolID INT,
    @Username NVARCHAR(50),
    @Password NVARCHAR(64),
    @Bloqueo BIT,
    @Activo BIT
AS
BEGIN
	INSERT INTO [dbo].[Usuarios] (DNI, Nombre, Apellido, Correo, RolID, Username, Password, Bloqueo, Activo)
	VALUES (@DNI, @Nombre, @Apellido, @Correo, @RolID, @Username, @Password, @Bloqueo, @Activo);
END
GO
USE [master]
GO
ALTER DATABASE [DBMarketMate] SET  READ_WRITE 
GO
