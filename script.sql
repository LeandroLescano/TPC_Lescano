USE [master]
GO
CREATE DATABASE [LESCANO_DB]
GO
ALTER DATABASE [LESCANO_DB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LESCANO_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LESCANO_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LESCANO_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LESCANO_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LESCANO_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LESCANO_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LESCANO_DB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LESCANO_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LESCANO_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LESCANO_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LESCANO_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LESCANO_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LESCANO_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LESCANO_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LESCANO_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LESCANO_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LESCANO_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LESCANO_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LESCANO_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LESCANO_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LESCANO_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LESCANO_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LESCANO_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LESCANO_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LESCANO_DB] SET  MULTI_USER 
GO
ALTER DATABASE [LESCANO_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LESCANO_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LESCANO_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LESCANO_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LESCANO_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LESCANO_DB] SET QUERY_STORE = OFF
GO
USE [LESCANO_DB]
GO
/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIAS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](100) NOT NULL,
	[ESTADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTES]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[APELLIDOS] [varchar](50) NOT NULL,
	[NOMBRES] [varchar](50) NOT NULL,
	[RAZONSOCIAL] [varchar](100) NOT NULL,
	[DNI] [varchar](15) NOT NULL,
	[CUIT] [varchar](20) NOT NULL,
	[FECHNAC] [date] NULL,
	[IDDOMICILIO] [int] NULL,
	[IDUSUARIO] [int] NULL,
	[IDTIPOPERSONA] [int] NOT NULL,
	[ESTADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOMICILIOS]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOMICILIOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ALTURA] [int] NOT NULL,
	[CALLE] [varchar](100) NOT NULL,
	[IDCOORDENADAS] [int] NULL,
	[ENTRECALLE1] [varchar](100) NULL,
	[ENTRECALLE2] [varchar](100) NULL,
	[IDLOCALIDAD] [int] NULL,
	[PISO] [int] NULL,
	[DEPARTAMENTO] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLEADOS]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLEADOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[APELLIDOS] [varchar](50) NOT NULL,
	[NOMBRES] [varchar](50) NOT NULL,
	[DNI] [varchar](15) NOT NULL,
	[CUIL] [varchar](20) NOT NULL,
	[IDDOMICILIO] [int] NULL,
	[IDUSUARIO] [int] NULL,
	[IDTIPOEMPLEADO] [int] NOT NULL,
	[FECHNAC] [date] NULL,
	[ESTADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOCALIDADES]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOCALIDADES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CODPOSTAL] [varchar](10) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[PARTIDO] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LOC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[CODPOSTAL] ASC,
	[NOMBRE] ASC,
	[PARTIDO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MAILS]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAILS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MAIL] [varchar](100) NOT NULL,
	[DESCRIPCION] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MAILS_X_CLIENTES]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAILS_X_CLIENTES](
	[IDCLIENTE] [int] NOT NULL,
	[IDMAIL] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCLIENTE] ASC,
	[IDMAIL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MAILS_X_EMPLEADOS]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAILS_X_EMPLEADOS](
	[IDEMPLEADO] [int] NOT NULL,
	[IDMAIL] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDEMPLEADO] ASC,
	[IDMAIL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MAILS_X_PROVEEDORES]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAILS_X_PROVEEDORES](
	[IDPROVEEDOR] [int] NOT NULL,
	[IDMAIL] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPROVEEDOR] ASC,
	[IDMAIL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MARCAS]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MARCAS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[ESTADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTOS]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCATEGORIA] [int] NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[IDMARCA] [int] NOT NULL,
	[PRECIOUNITARIO] [money] NOT NULL,
	[STOCK] [int] NOT NULL,
	[FRACCIONABLE] [bit] NOT NULL,
	[PESO] [varchar](15) NOT NULL,
	[PORCENTAJEGANANCIA] [varchar](15) NOT NULL,
	[ESTADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROVEEDORES]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROVEEDORES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[APELLIDOS] [varchar](50) NOT NULL,
	[NOMBRES] [varchar](50) NOT NULL,
	[RAZONSOCIAL] [varchar](100) NOT NULL,
	[DNI] [varchar](15) NOT NULL,
	[CUIT] [varchar](20) NOT NULL,
	[IDDOMICILIO] [int] NULL,
	[IDTIPOPERSONA] [int] NOT NULL,
	[FECHNAC] [date] NULL,
	[ESTADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROVEEDORES_X_PRODUCTO]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROVEEDORES_X_PRODUCTO](
	[IDPRODUCTO] [int] NOT NULL,
	[IDPROVEEDOR] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPRODUCTO] ASC,
	[IDPROVEEDOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TELEFONOS]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TELEFONOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TELEFONO] [varchar](20) NOT NULL,
	[DESCRIPCION] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TELEFONOS_X_CLIENTES]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TELEFONOS_X_CLIENTES](
	[IDCLIENTE] [int] NOT NULL,
	[IDTELEFONO] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCLIENTE] ASC,
	[IDTELEFONO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TELEFONOS_X_EMPLEADOS]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TELEFONOS_X_EMPLEADOS](
	[IDEMPLEADO] [int] NOT NULL,
	[IDTELEFONO] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDEMPLEADO] ASC,
	[IDTELEFONO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TELEFONOS_X_PROVEEDORES]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TELEFONOS_X_PROVEEDORES](
	[IDPROVEEDOR] [int] NOT NULL,
	[IDTELEFONO] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPROVEEDOR] ASC,
	[IDTELEFONO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPO_EMPLEADO]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_EMPLEADO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TIPO] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPO_PERSONA]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_PERSONA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TIPO] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USUARIO] [varchar](50) NOT NULL,
	[CONTRASEÑA] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CATEGORIAS] ON 
GO
INSERT [dbo].[CATEGORIAS] ([ID], [NOMBRE], [ESTADO]) VALUES (1, N'Salames', 0)
GO
INSERT [dbo].[CATEGORIAS] ([ID], [NOMBRE], [ESTADO]) VALUES (2, N'Gaseosas', 1)
GO
INSERT [dbo].[CATEGORIAS] ([ID], [NOMBRE], [ESTADO]) VALUES (3, N'Aperitivos', 1)
GO
INSERT [dbo].[CATEGORIAS] ([ID], [NOMBRE], [ESTADO]) VALUES (4, N'Quesos', 1)
GO
INSERT [dbo].[CATEGORIAS] ([ID], [NOMBRE], [ESTADO]) VALUES (5, N'Yogures', 1)
GO
INSERT [dbo].[CATEGORIAS] ([ID], [NOMBRE], [ESTADO]) VALUES (6, N'Cervezas', 1)
GO
INSERT [dbo].[CATEGORIAS] ([ID], [NOMBRE], [ESTADO]) VALUES (15, N'Fiambres', 1)
GO
SET IDENTITY_INSERT [dbo].[CATEGORIAS] OFF
GO
SET IDENTITY_INSERT [dbo].[CLIENTES] ON 
GO
INSERT [dbo].[CLIENTES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [FECHNAC], [IDDOMICILIO], [IDUSUARIO], [IDTIPOPERSONA], [ESTADO]) VALUES (1, N'Lescano', N'Leandro', N'', N'42420833', N'20-42420833-8', CAST(N'2000-03-19' AS Date), 0, NULL, 1, 1)
GO
INSERT [dbo].[CLIENTES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [FECHNAC], [IDDOMICILIO], [IDUSUARIO], [IDTIPOPERSONA], [ESTADO]) VALUES (5, N'Cassano', N'Juan Cruz', N'', N'12346578', N'10-23456789-2', CAST(N'1992-10-10' AS Date), 0, NULL, 1, 1)
GO
INSERT [dbo].[CLIENTES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [FECHNAC], [IDDOMICILIO], [IDUSUARIO], [IDTIPOPERSONA], [ESTADO]) VALUES (9, N'Valenzuela', N'Elias', N'', N'12312312', N'45645645', CAST(N'1996-04-22' AS Date), NULL, NULL, 1, 1)
GO
INSERT [dbo].[CLIENTES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [FECHNAC], [IDDOMICILIO], [IDUSUARIO], [IDTIPOPERSONA], [ESTADO]) VALUES (15, N'', N'', N'Municipio de Tigre', N'', N'60-456789321-8', CAST(N'2019-05-05' AS Date), 0, NULL, 2, 1)
GO
INSERT [dbo].[CLIENTES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [FECHNAC], [IDDOMICILIO], [IDUSUARIO], [IDTIPOPERSONA], [ESTADO]) VALUES (21, N'', N'', N'UTN', N'', N'123456789', CAST(N'2019-05-11' AS Date), 0, NULL, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[CLIENTES] OFF
GO
SET IDENTITY_INSERT [dbo].[DOMICILIOS] ON 
GO
INSERT [dbo].[DOMICILIOS] ([ID], [ALTURA], [CALLE], [IDCOORDENADAS], [ENTRECALLE1], [ENTRECALLE2], [IDLOCALIDAD], [PISO], [DEPARTAMENTO]) VALUES (1, 4551, N'Blanco Encalada', NULL, N'', N'', NULL, NULL, NULL)
GO
INSERT [dbo].[DOMICILIOS] ([ID], [ALTURA], [CALLE], [IDCOORDENADAS], [ENTRECALLE1], [ENTRECALLE2], [IDLOCALIDAD], [PISO], [DEPARTAMENTO]) VALUES (7, 2424, N'Santa Rita', NULL, N'', N'', 4, NULL, NULL)
GO
INSERT [dbo].[DOMICILIOS] ([ID], [ALTURA], [CALLE], [IDCOORDENADAS], [ENTRECALLE1], [ENTRECALLE2], [IDLOCALIDAD], [PISO], [DEPARTAMENTO]) VALUES (8, 123, N'Calle falsa', NULL, N'', N'', NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[DOMICILIOS] OFF
GO
SET IDENTITY_INSERT [dbo].[EMPLEADOS] ON 
GO
INSERT [dbo].[EMPLEADOS] ([ID], [APELLIDOS], [NOMBRES], [DNI], [CUIL], [IDDOMICILIO], [IDUSUARIO], [IDTIPOEMPLEADO], [FECHNAC], [ESTADO]) VALUES (2, N'Lescano', N'Leandro Nicolas', N'42420833', N'20-42420833-8', 22, 0, 1, CAST(N'2000-03-19' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[EMPLEADOS] OFF
GO
SET IDENTITY_INSERT [dbo].[LOCALIDADES] ON 
GO
INSERT [dbo].[LOCALIDADES] ([ID], [CODPOSTAL], [NOMBRE], [PARTIDO]) VALUES (4, N'4444', N'Tigre', N'Benavidez')
GO
INSERT [dbo].[LOCALIDADES] ([ID], [CODPOSTAL], [NOMBRE], [PARTIDO]) VALUES (6, N'1644', N'San Fernando', N'Victoria')
GO
INSERT [dbo].[LOCALIDADES] ([ID], [CODPOSTAL], [NOMBRE], [PARTIDO]) VALUES (7, N'1648', N'Tigre', N'Pacheco')
GO
SET IDENTITY_INSERT [dbo].[LOCALIDADES] OFF
GO
SET IDENTITY_INSERT [dbo].[MAILS] ON 
GO
INSERT [dbo].[MAILS] ([ID], [MAIL], [DESCRIPCION]) VALUES (1, N'leandrolescano11@gmail.com', N'Lescano, Leandro')
GO
INSERT [dbo].[MAILS] ([ID], [MAIL], [DESCRIPCION]) VALUES (2, N'tatilescano11@gmail.com', N'Lescano, Leandro')
GO
SET IDENTITY_INSERT [dbo].[MAILS] OFF
GO
INSERT [dbo].[MAILS_X_PROVEEDORES] ([IDPROVEEDOR], [IDMAIL]) VALUES (11, 11)
GO
SET IDENTITY_INSERT [dbo].[MARCAS] ON 
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (1, N'Paladini', 1)
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (2, N'Cabaña', 1)
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (3, N'La Serenisima', 1)
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (4, N'Coca-Cola', 1)
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (5, N'Manaos', 1)
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (6, N'Pepsi', 1)
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (7, N'SanCor', 1)
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (8, N'Arcor', 1)
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (9, N'Yogurisimo', 1)
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (11, N'Quilmes', 1)
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (12, N'Lays', 1)
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (13, N'Tostitos', 1)
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (14, N'Nutella', 1)
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (15, N'Cadbury', 1)
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE], [ESTADO]) VALUES (16, N'Pritty', 1)
GO
SET IDENTITY_INSERT [dbo].[MARCAS] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCTOS] ON 
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK], [FRACCIONABLE], [PESO], [PORCENTAJEGANANCIA], [ESTADO]) VALUES (1, 4, N'Queso Regiannito', 3, 20.0000, 0, 1, N'1.5', N'0', 1)
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK], [FRACCIONABLE], [PESO], [PORCENTAJEGANANCIA], [ESTADO]) VALUES (2, 2, N'Coca-Cola', 4, 30.0000, 0, 0, N'0', N'0', 1)
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK], [FRACCIONABLE], [PESO], [PORCENTAJEGANANCIA], [ESTADO]) VALUES (3, 3, N'Papas Fritas Originales', 12, 50.0000, 0, 0, N'0', N'0', 1)
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK], [FRACCIONABLE], [PESO], [PORCENTAJEGANANCIA], [ESTADO]) VALUES (4, 6, N'Cerveza Quilmes 250ml', 11, 30.0000, 0, 0, N'0', N'0', 1)
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK], [FRACCIONABLE], [PESO], [PORCENTAJEGANANCIA], [ESTADO]) VALUES (6, 2, N'Manaos Cola 750ml', 5, 20.0000, 0, 0, N'0', N'0', 1)
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK], [FRACCIONABLE], [PESO], [PORCENTAJEGANANCIA], [ESTADO]) VALUES (7, 3, N'Cadbury Yoghurt Frutilla', 15, 50.0000, 0, 0, N'0', N'0', 1)
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK], [FRACCIONABLE], [PESO], [PORCENTAJEGANANCIA], [ESTADO]) VALUES (9, 2, N'Pritty Zero 250ml', 16, 5.0000, 0, 0, N'0', N'1.00', 0)
GO
SET IDENTITY_INSERT [dbo].[PRODUCTOS] OFF
GO
SET IDENTITY_INSERT [dbo].[PROVEEDORES] ON 
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA], [FECHNAC], [ESTADO]) VALUES (2, N'', N'', N'Coca-Cola', N'', N'132456789', 8, 2, NULL, 1)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA], [FECHNAC], [ESTADO]) VALUES (4, N'', N'', N'Jumbalay', N'', N'123456780', NULL, 2, NULL, 1)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA], [FECHNAC], [ESTADO]) VALUES (6, N'', N'', N'SanCor', N'', N'123456788', NULL, 2, NULL, 1)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA], [FECHNAC], [ESTADO]) VALUES (8, N'', N'', N'Vincar', N'', N'123456786', 7, 2, NULL, 1)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA], [FECHNAC], [ESTADO]) VALUES (11, N'Lescano', N'Leandro', N'', N'42424242', N'20-42424242-8', 1, 1, NULL, 1)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA], [FECHNAC], [ESTADO]) VALUES (22, N'', N'', N'La Serenisima', N'', N'123456789', NULL, 2, CAST(N'1900-01-01' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[PROVEEDORES] OFF
GO
INSERT [dbo].[PROVEEDORES_X_PRODUCTO] ([IDPRODUCTO], [IDPROVEEDOR]) VALUES (2, 2)
GO
INSERT [dbo].[PROVEEDORES_X_PRODUCTO] ([IDPRODUCTO], [IDPROVEEDOR]) VALUES (3, 8)
GO
INSERT [dbo].[PROVEEDORES_X_PRODUCTO] ([IDPRODUCTO], [IDPROVEEDOR]) VALUES (4, 4)
GO
INSERT [dbo].[PROVEEDORES_X_PRODUCTO] ([IDPRODUCTO], [IDPROVEEDOR]) VALUES (4, 8)
GO
INSERT [dbo].[PROVEEDORES_X_PRODUCTO] ([IDPRODUCTO], [IDPROVEEDOR]) VALUES (6, 2)
GO
INSERT [dbo].[PROVEEDORES_X_PRODUCTO] ([IDPRODUCTO], [IDPROVEEDOR]) VALUES (7, 4)
GO
INSERT [dbo].[PROVEEDORES_X_PRODUCTO] ([IDPRODUCTO], [IDPROVEEDOR]) VALUES (7, 8)
GO
SET IDENTITY_INSERT [dbo].[TELEFONOS] ON 
GO
INSERT [dbo].[TELEFONOS] ([ID], [TELEFONO], [DESCRIPCION]) VALUES (2, N'01134527738', N'Particular')
GO
INSERT [dbo].[TELEFONOS] ([ID], [TELEFONO], [DESCRIPCION]) VALUES (3, N'01134527738', N'Particular')
GO
INSERT [dbo].[TELEFONOS] ([ID], [TELEFONO], [DESCRIPCION]) VALUES (4, N'45124567', N'Laboral')
GO
INSERT [dbo].[TELEFONOS] ([ID], [TELEFONO], [DESCRIPCION]) VALUES (5, N'01134527738', N'Particular')
GO
SET IDENTITY_INSERT [dbo].[TELEFONOS] OFF
GO
INSERT [dbo].[TELEFONOS_X_PROVEEDORES] ([IDPROVEEDOR], [IDTELEFONO]) VALUES (11, 5)
GO
SET IDENTITY_INSERT [dbo].[TIPO_EMPLEADO] ON 
GO
INSERT [dbo].[TIPO_EMPLEADO] ([ID], [TIPO]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[TIPO_EMPLEADO] ([ID], [TIPO]) VALUES (2, N'Vendedor')
GO
SET IDENTITY_INSERT [dbo].[TIPO_EMPLEADO] OFF
GO
SET IDENTITY_INSERT [dbo].[TIPO_PERSONA] ON 
GO
INSERT [dbo].[TIPO_PERSONA] ([ID], [TIPO]) VALUES (1, N'Física')
GO
INSERT [dbo].[TIPO_PERSONA] ([ID], [TIPO]) VALUES (2, N'Jurídica')
GO
SET IDENTITY_INSERT [dbo].[TIPO_PERSONA] OFF
GO
ALTER TABLE [dbo].[CATEGORIAS] ADD  DEFAULT ((1)) FOR [ESTADO]
GO
ALTER TABLE [dbo].[CLIENTES] ADD  DEFAULT ('') FOR [APELLIDOS]
GO
ALTER TABLE [dbo].[CLIENTES] ADD  DEFAULT ('') FOR [NOMBRES]
GO
ALTER TABLE [dbo].[CLIENTES] ADD  DEFAULT ((1)) FOR [ESTADO]
GO
ALTER TABLE [dbo].[DOMICILIOS] ADD  DEFAULT ('-') FOR [ENTRECALLE1]
GO
ALTER TABLE [dbo].[DOMICILIOS] ADD  DEFAULT ('-') FOR [ENTRECALLE2]
GO
ALTER TABLE [dbo].[EMPLEADOS] ADD  DEFAULT ((1)) FOR [ESTADO]
GO
ALTER TABLE [dbo].[MARCAS] ADD  DEFAULT ((1)) FOR [ESTADO]
GO
ALTER TABLE [dbo].[PRODUCTOS] ADD  DEFAULT ((0)) FOR [STOCK]
GO
ALTER TABLE [dbo].[PRODUCTOS] ADD  DEFAULT ((0)) FOR [FRACCIONABLE]
GO
ALTER TABLE [dbo].[PRODUCTOS] ADD  DEFAULT ((1)) FOR [ESTADO]
GO
ALTER TABLE [dbo].[PROVEEDORES] ADD  DEFAULT ('') FOR [APELLIDOS]
GO
ALTER TABLE [dbo].[PROVEEDORES] ADD  DEFAULT ('') FOR [NOMBRES]
GO
ALTER TABLE [dbo].[PROVEEDORES] ADD  DEFAULT ('') FOR [RAZONSOCIAL]
GO
ALTER TABLE [dbo].[PROVEEDORES] ADD  DEFAULT ('1/1/1900') FOR [FECHNAC]
GO
ALTER TABLE [dbo].[PROVEEDORES] ADD  DEFAULT ((1)) FOR [ESTADO]
GO
ALTER TABLE [dbo].[CLIENTES]  WITH NOCHECK ADD  CONSTRAINT [FK__CLIENTES__IDDOMI__4F7CD00D] FOREIGN KEY([IDDOMICILIO])
REFERENCES [dbo].[DOMICILIOS] ([ID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CLIENTES] NOCHECK CONSTRAINT [FK__CLIENTES__IDDOMI__4F7CD00D]
GO
ALTER TABLE [dbo].[CLIENTES]  WITH CHECK ADD FOREIGN KEY([IDTIPOPERSONA])
REFERENCES [dbo].[TIPO_PERSONA] ([ID])
GO
ALTER TABLE [dbo].[CLIENTES]  WITH CHECK ADD FOREIGN KEY([IDUSUARIO])
REFERENCES [dbo].[USUARIOS] ([ID])
GO
ALTER TABLE [dbo].[MAILS_X_CLIENTES]  WITH CHECK ADD FOREIGN KEY([IDCLIENTE])
REFERENCES [dbo].[CLIENTES] ([ID])
GO
ALTER TABLE [dbo].[MAILS_X_CLIENTES]  WITH CHECK ADD FOREIGN KEY([IDMAIL])
REFERENCES [dbo].[MAILS] ([ID])
GO
ALTER TABLE [dbo].[MAILS_X_EMPLEADOS]  WITH CHECK ADD FOREIGN KEY([IDEMPLEADO])
REFERENCES [dbo].[EMPLEADOS] ([ID])
GO
ALTER TABLE [dbo].[MAILS_X_EMPLEADOS]  WITH CHECK ADD FOREIGN KEY([IDMAIL])
REFERENCES [dbo].[MAILS] ([ID])
GO
ALTER TABLE [dbo].[MAILS_X_PROVEEDORES]  WITH CHECK ADD FOREIGN KEY([IDMAIL])
REFERENCES [dbo].[MAILS] ([ID])
GO
ALTER TABLE [dbo].[MAILS_X_PROVEEDORES]  WITH CHECK ADD FOREIGN KEY([IDPROVEEDOR])
REFERENCES [dbo].[PROVEEDORES] ([ID])
GO
ALTER TABLE [dbo].[PRODUCTOS]  WITH CHECK ADD FOREIGN KEY([IDCATEGORIA])
REFERENCES [dbo].[CATEGORIAS] ([ID])
GO
ALTER TABLE [dbo].[PRODUCTOS]  WITH CHECK ADD FOREIGN KEY([IDMARCA])
REFERENCES [dbo].[MARCAS] ([ID])
GO
ALTER TABLE [dbo].[PROVEEDORES]  WITH NOCHECK ADD  CONSTRAINT [FK__PROVEEDOR__IDDOM__6A30C649] FOREIGN KEY([IDDOMICILIO])
REFERENCES [dbo].[DOMICILIOS] ([ID])
GO
ALTER TABLE [dbo].[PROVEEDORES] CHECK CONSTRAINT [FK__PROVEEDOR__IDDOM__6A30C649]
GO
ALTER TABLE [dbo].[PROVEEDORES]  WITH CHECK ADD  CONSTRAINT [FK__PROVEEDOR__IDTIP__6B24EA82] FOREIGN KEY([IDTIPOPERSONA])
REFERENCES [dbo].[TIPO_PERSONA] ([ID])
GO
ALTER TABLE [dbo].[PROVEEDORES] CHECK CONSTRAINT [FK__PROVEEDOR__IDTIP__6B24EA82]
GO
ALTER TABLE [dbo].[PROVEEDORES_X_PRODUCTO]  WITH CHECK ADD FOREIGN KEY([IDPRODUCTO])
REFERENCES [dbo].[PRODUCTOS] ([ID])
GO
ALTER TABLE [dbo].[TELEFONOS_X_CLIENTES]  WITH CHECK ADD FOREIGN KEY([IDCLIENTE])
REFERENCES [dbo].[CLIENTES] ([ID])
GO
ALTER TABLE [dbo].[TELEFONOS_X_CLIENTES]  WITH CHECK ADD FOREIGN KEY([IDTELEFONO])
REFERENCES [dbo].[TELEFONOS] ([ID])
GO
ALTER TABLE [dbo].[TELEFONOS_X_EMPLEADOS]  WITH CHECK ADD FOREIGN KEY([IDEMPLEADO])
REFERENCES [dbo].[EMPLEADOS] ([ID])
GO
ALTER TABLE [dbo].[TELEFONOS_X_EMPLEADOS]  WITH CHECK ADD FOREIGN KEY([IDTELEFONO])
REFERENCES [dbo].[TELEFONOS] ([ID])
GO
ALTER TABLE [dbo].[TELEFONOS_X_PROVEEDORES]  WITH NOCHECK ADD FOREIGN KEY([IDTELEFONO])
REFERENCES [dbo].[TELEFONOS] ([ID])
GO
/****** Object:  Trigger [dbo].[tr_eliminarCategoria]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_eliminarCategoria] on [dbo].[CATEGORIAS]
instead of delete
as
begin
	Declare @IDCat int
	Declare @Estado bit
	select @IDCat = ID, @Estado = Estado from deleted
	if @Estado = 1 begin
	Update Categorias set Estado=0 where ID = @IDCat
	end
	else begin
		Delete from CATEGORIAS where ID = @IDCat
	end
end
GO
ALTER TABLE [dbo].[CATEGORIAS] ENABLE TRIGGER [tr_eliminarCategoria]
GO
/****** Object:  Trigger [dbo].[tr_eliminarCliente]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_eliminarCliente] on [dbo].[CLIENTES]
instead of delete
as
begin
	Declare @IDCli int
	Declare @Estado bit
	select @IDCli = ID, @Estado = Estado from deleted
	if @Estado = 1 begin
		Update Clientes set Estado=0 where ID = @IDCli
	end
	else begin
		Delete from CLIENTES where ID = @IDCli
	end
end
GO
ALTER TABLE [dbo].[CLIENTES] ENABLE TRIGGER [tr_eliminarCliente]
GO
/****** Object:  Trigger [dbo].[tr_eliminarEmpleado]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_eliminarEmpleado] on [dbo].[EMPLEADOS]
instead of delete
as
begin
	Declare @IDEmp int
	Declare @Estado bit
	select @IDEmp = ID, @Estado = Estado from deleted
	if @Estado = 1 begin
		Update Empleados set Estado=0 where ID = @IDEmp
	end
	else begin
		Delete from Empleados where ID = @IDEmp
	end
end
GO
ALTER TABLE [dbo].[EMPLEADOS] ENABLE TRIGGER [tr_eliminarEmpleado]
GO
/****** Object:  Trigger [dbo].[tr_eliminarMarca]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_eliminarMarca] on [dbo].[MARCAS]
instead of delete
as
begin
	Declare @IDMar int
	Declare @Estado bit
	select @IDMar = ID, @Estado = Estado from deleted
	if @Estado = 1 begin
		Update Marcas set Estado=0 where ID = @IDMar
	end
	else begin
		Delete from MARCAS where ID = @IDMar
	end
end
GO
ALTER TABLE [dbo].[MARCAS] ENABLE TRIGGER [tr_eliminarMarca]
GO
/****** Object:  Trigger [dbo].[tr_eliminarProducto]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_eliminarProducto] on [dbo].[PRODUCTOS]
instead of delete
as
begin
	Declare @IDProd int
	Declare @Estado bit
	select @IDProd = ID, @Estado = Estado from deleted
	if @Estado = 1 begin
		Update Productos set Estado=0 where ID = @IDProd
	end
	else begin
		Delete from PRODUCTOS where ID = @IDProd
	end
end
GO
ALTER TABLE [dbo].[PRODUCTOS] ENABLE TRIGGER [tr_eliminarProducto]
GO
/****** Object:  Trigger [dbo].[tr_eliminarProveedor]    Script Date: 1/6/2019 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_eliminarProveedor] on [dbo].[PROVEEDORES]
instead of delete
as
begin
	Declare @IDProv int
	Declare @Estado bit
	select @IDProv = ID, @Estado = Estado from deleted
	IF @Estado = 1 begin
		Update Proveedores set Estado=0 where ID = @IDProv
	end
	else begin
		delete from Proveedores where ID = @IDProv
	end
end
GO
ALTER TABLE [dbo].[PROVEEDORES] ENABLE TRIGGER [tr_eliminarProveedor]
GO
USE [master]
GO
ALTER DATABASE [LESCANO_DB] SET  READ_WRITE 
GO
CREATE TABLE COMBOS(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
NOMBRE varchar(100) NOT NULL,
DESCRIPCION VARCHAR(300) NULL,
DIASANTICIPO INT NOT NULL,
PRECIO MONEY NOT NULL CHECK(PRECIO >= 0),
RUTA VARCHAR(100) NULL,
ESTADO bit NOT NULL,
)
CREATE TABLE PRODUCTOS_X_COMBO(
IDCOMBO INT NOT NULL FOREIGN KEY REFERENCES COMBOS(ID),
IDPRODUCTO INT NOT NULL FOREIGN KEY REFERENCES PRODUCTOS(ID),
PRIMARY KEY(IDCOMBO, IDPRODUCTO)
)
GO
CREATE TRIGGER tr_eliminarCombo on Combos
instead of delete
as
begin
	Declare @IDComb int, @Estado bit
	Select @IDComb = ID, @Estado = Estado from deleted
	if @Estado = 1 begin
		UPDATE COMBOS SET ESTADO = 0 WHERE ID = @IDComb
	end
	else begin
		DELETE FROM COMBOS WHERE ID = @IDComb
	end
end

select * from combos