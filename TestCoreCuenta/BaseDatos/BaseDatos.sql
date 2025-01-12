USE [master]
GO
/****** Object:  Database [CoreCuenta]    Script Date: 7/10/2024 1:01:22 ******/
CREATE DATABASE [CoreCuenta]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CoreCuenta', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLSERVERDEV\MSSQL\DATA\CoreCuenta.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CoreCuenta_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLSERVERDEV\MSSQL\DATA\CoreCuenta_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CoreCuenta] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CoreCuenta].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CoreCuenta] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CoreCuenta] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CoreCuenta] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CoreCuenta] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CoreCuenta] SET ARITHABORT OFF 
GO
ALTER DATABASE [CoreCuenta] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CoreCuenta] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CoreCuenta] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CoreCuenta] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CoreCuenta] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CoreCuenta] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CoreCuenta] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CoreCuenta] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CoreCuenta] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CoreCuenta] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CoreCuenta] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CoreCuenta] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CoreCuenta] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CoreCuenta] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CoreCuenta] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CoreCuenta] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CoreCuenta] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CoreCuenta] SET RECOVERY FULL 
GO
ALTER DATABASE [CoreCuenta] SET  MULTI_USER 
GO
ALTER DATABASE [CoreCuenta] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CoreCuenta] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CoreCuenta] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CoreCuenta] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CoreCuenta] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CoreCuenta] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CoreCuenta', N'ON'
GO
ALTER DATABASE [CoreCuenta] SET QUERY_STORE = ON
GO
ALTER DATABASE [CoreCuenta] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CoreCuenta]
GO
/****** Object:  Schema [cu]    Script Date: 7/10/2024 1:01:23 ******/
CREATE SCHEMA [cu]
GO
/****** Object:  Table [cu].[Cliente]    Script Date: 7/10/2024 1:01:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cu].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[PersonaId] [int] NULL,
	[Clave] [varchar](220) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cu].[ClienteCuenta]    Script Date: 7/10/2024 1:01:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cu].[ClienteCuenta](
	[ClienteCuentaId] [int] IDENTITY(1,1) NOT NULL,
	[CuentaId] [int] NULL,
	[ClienteId] [int] NULL,
 CONSTRAINT [PK_CLIENTECUENTA] PRIMARY KEY CLUSTERED 
(
	[ClienteCuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cu].[Cuenta]    Script Date: 7/10/2024 1:01:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cu].[Cuenta](
	[CuentaId] [int] IDENTITY(1,1) NOT NULL,
	[NumeroCuenta] [bigint] NULL,
	[TipoCuenta] [varchar](9) NULL,
	[SaldoInicial] [decimal](18, 0) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_CUENTA] PRIMARY KEY CLUSTERED 
(
	[CuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cu].[Movimiento]    Script Date: 7/10/2024 1:01:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cu].[Movimiento](
	[MovimientoId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NULL,
	[CuentaId] [int] NULL,
	[Fecha] [datetime] NULL,
	[TipoMovimiento] [varchar](9) NULL,
	[Valor] [decimal](18, 0) NULL,
	[Saldo] [decimal](18, 0) NULL,
 CONSTRAINT [PK_MOVIMIENTO] PRIMARY KEY CLUSTERED 
(
	[MovimientoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cu].[Persona]    Script Date: 7/10/2024 1:01:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cu].[Persona](
	[PersonaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](220) NULL,
	[Genero] [varchar](1) NULL,
	[Edad] [int] NULL,
	[Identificacion] [varchar](13) NULL,
	[Direccion] [varchar](220) NULL,
	[Telefono] [varchar](16) NULL,
 CONSTRAINT [PK_PERSONA] PRIMARY KEY CLUSTERED 
(
	[PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [cu].[Cliente] ON 

INSERT [cu].[Cliente] ([ClienteId], [PersonaId], [Clave], [Estado]) VALUES (11, 30, N'admin123', 1)
SET IDENTITY_INSERT [cu].[Cliente] OFF
GO
SET IDENTITY_INSERT [cu].[ClienteCuenta] ON 

INSERT [cu].[ClienteCuenta] ([ClienteCuentaId], [CuentaId], [ClienteId]) VALUES (9, 10, 11)
SET IDENTITY_INSERT [cu].[ClienteCuenta] OFF
GO
SET IDENTITY_INSERT [cu].[Cuenta] ON 

INSERT [cu].[Cuenta] ([CuentaId], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (10, 123124, N'AHORROS', CAST(500 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [cu].[Cuenta] OFF
GO
SET IDENTITY_INSERT [cu].[Movimiento] ON 

INSERT [cu].[Movimiento] ([MovimientoId], [ClienteId], [CuentaId], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (1, 11, 10, CAST(N'2024-10-06T14:30:00.000' AS DateTime), N'DEPOSITO', CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)))
INSERT [cu].[Movimiento] ([MovimientoId], [ClienteId], [CuentaId], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (4, 11, 10, CAST(N'2024-10-07T14:30:00.000' AS DateTime), N'RETIRO', CAST(-500 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)))
INSERT [cu].[Movimiento] ([MovimientoId], [ClienteId], [CuentaId], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (5, 11, 10, CAST(N'2024-10-07T14:32:00.000' AS DateTime), N'RETIRO', CAST(-500 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [cu].[Movimiento] ([MovimientoId], [ClienteId], [CuentaId], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (7, 11, 10, CAST(N'2024-10-07T15:30:00.000' AS DateTime), N'DEPOSITO', CAST(350 AS Decimal(18, 0)), CAST(350 AS Decimal(18, 0)))
SET IDENTITY_INSERT [cu].[Movimiento] OFF
GO
SET IDENTITY_INSERT [cu].[Persona] ON 

INSERT [cu].[Persona] ([PersonaId], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (30, N'Javier Valverde P', N'M', 30, N'1765456567', N'Calle miguel de S', N'0987678765')
SET IDENTITY_INSERT [cu].[Persona] OFF
GO
ALTER TABLE [cu].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_CLIENTE] FOREIGN KEY([PersonaId])
REFERENCES [cu].[Persona] ([PersonaId])
GO
ALTER TABLE [cu].[Cliente] CHECK CONSTRAINT [FK_CLIENTE]
GO
ALTER TABLE [cu].[ClienteCuenta]  WITH CHECK ADD  CONSTRAINT [FK_CLIENTE_CUENTA] FOREIGN KEY([ClienteId])
REFERENCES [cu].[Cliente] ([ClienteId])
GO
ALTER TABLE [cu].[ClienteCuenta] CHECK CONSTRAINT [FK_CLIENTE_CUENTA]
GO
ALTER TABLE [cu].[ClienteCuenta]  WITH CHECK ADD  CONSTRAINT [FK_CUENTA] FOREIGN KEY([CuentaId])
REFERENCES [cu].[Cuenta] ([CuentaId])
GO
ALTER TABLE [cu].[ClienteCuenta] CHECK CONSTRAINT [FK_CUENTA]
GO
ALTER TABLE [cu].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_CLIENTE_MOVIMIENTO] FOREIGN KEY([ClienteId])
REFERENCES [cu].[Cliente] ([ClienteId])
GO
ALTER TABLE [cu].[Movimiento] CHECK CONSTRAINT [FK_CLIENTE_MOVIMIENTO]
GO
ALTER TABLE [cu].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_CUENTA_MOVIMIENTO] FOREIGN KEY([CuentaId])
REFERENCES [cu].[Cuenta] ([CuentaId])
GO
ALTER TABLE [cu].[Movimiento] CHECK CONSTRAINT [FK_CUENTA_MOVIMIENTO]
GO
ALTER TABLE [cu].[Cuenta]  WITH CHECK ADD  CONSTRAINT [CKC_TIPOCUENTA_OPTION] CHECK  (([TipoCuenta]='AHORROS' OR [TipoCuenta]='CORRIENTE'))
GO
ALTER TABLE [cu].[Cuenta] CHECK CONSTRAINT [CKC_TIPOCUENTA_OPTION]
GO
ALTER TABLE [cu].[Movimiento]  WITH CHECK ADD  CONSTRAINT [CKC_TIPOMOVIMIENTO_OPTION] CHECK  (([TipoMovimiento]='DEPOSITO' OR [TipoMovimiento]='RETIRO'))
GO
ALTER TABLE [cu].[Movimiento] CHECK CONSTRAINT [CKC_TIPOMOVIMIENTO_OPTION]
GO
/****** Object:  StoredProcedure [cu].[sp_consultar_cuenta_movimiento]    Script Date: 7/10/2024 1:01:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [cu].[sp_consultar_cuenta_movimiento]
(
	@fechaInicio datetime,
    @fechaFin datetime
)
AS
BEGIN 
SELECT DISTINCT m.Fecha,p.Nombre,cu.NumeroCuenta,cu.TipoCuenta,cu.SaldoInicial,cu.Estado,m.TipoMovimiento,m.Valor,m.Saldo
FROM  [cu].[Persona] p
INNER JOIN [cu].[Cliente] cl		ON p.PersonaId=cl.PersonaId
INNER JOIN [cu].[ClienteCuenta] cc  ON cc.ClienteId=cl.ClienteId
INNER JOIN [cu].[Cuenta] cu			ON cc.CuentaId=cu.CuentaId
INNER JOIN [cu].[Movimiento] m		ON m.CuentaId=cu.CuentaId  AND m.ClienteId=cl.ClienteId
ORDER BY m.Fecha  DESC  
END
GO
USE [master]
GO
ALTER DATABASE [CoreCuenta] SET  READ_WRITE 
GO
