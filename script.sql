USE [master]
GO
CREATE DATABASE [LESCANO_DB]
GO
USE LESCANO_DB
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
/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 16/5/2019 23:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIAS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTES]    Script Date: 16/5/2019 23:12:35 ******/
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
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOMICILIOS]    Script Date: 16/5/2019 23:12:35 ******/
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
/****** Object:  Table [dbo].[EMPLEADOS]    Script Date: 16/5/2019 23:12:35 ******/
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
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOCALIDADES]    Script Date: 16/5/2019 23:12:35 ******/
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
/****** Object:  Table [dbo].[MAILS]    Script Date: 16/5/2019 23:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAILS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MAIL] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MAILS_X_CLIENTES]    Script Date: 16/5/2019 23:12:35 ******/
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
/****** Object:  Table [dbo].[MAILS_X_EMPLEADOS]    Script Date: 16/5/2019 23:12:35 ******/
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
/****** Object:  Table [dbo].[MAILS_X_PROVEEDORES]    Script Date: 16/5/2019 23:12:35 ******/
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
/****** Object:  Table [dbo].[MARCAS]    Script Date: 16/5/2019 23:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MARCAS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTOS]    Script Date: 16/5/2019 23:12:35 ******/
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
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROVEEDORES]    Script Date: 16/5/2019 23:12:35 ******/
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
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROVEEDORES_X_PRODUCTO]    Script Date: 16/5/2019 23:12:35 ******/
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
/****** Object:  Table [dbo].[TELEFONOS]    Script Date: 16/5/2019 23:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TELEFONOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TELEFONO] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TELEFONOS_X_CLIENTES]    Script Date: 16/5/2019 23:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TELEFONOS_X_CLIENTES](
	[IDCLIENTE] [int] NOT NULL,
	[IDTELEFONOS] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCLIENTE] ASC,
	[IDTELEFONOS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TELEFONOS_X_EMPLEADOS]    Script Date: 16/5/2019 23:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TELEFONOS_X_EMPLEADOS](
	[IDEMPLEADO] [int] NOT NULL,
	[IDTELEFONOS] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDEMPLEADO] ASC,
	[IDTELEFONOS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TELEFONOS_X_PROVEEDORES]    Script Date: 16/5/2019 23:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TELEFONOS_X_PROVEEDORES](
	[IDPROVEEDOR] [int] NOT NULL,
	[IDTELEFONOS] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPROVEEDOR] ASC,
	[IDTELEFONOS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPO_EMPLEADO]    Script Date: 16/5/2019 23:12:35 ******/
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
/****** Object:  Table [dbo].[TIPO_PERSONA]    Script Date: 16/5/2019 23:12:35 ******/
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
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 16/5/2019 23:12:35 ******/
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
INSERT [dbo].[CATEGORIAS] ([ID], [NOMBRE]) VALUES (1, N'Salames')
GO
INSERT [dbo].[CATEGORIAS] ([ID], [NOMBRE]) VALUES (2, N'Gaseosas')
GO
INSERT [dbo].[CATEGORIAS] ([ID], [NOMBRE]) VALUES (3, N'Aperitivos')
GO
INSERT [dbo].[CATEGORIAS] ([ID], [NOMBRE]) VALUES (4, N'Quesos')
GO
INSERT [dbo].[CATEGORIAS] ([ID], [NOMBRE]) VALUES (5, N'Yogures')
GO
INSERT [dbo].[CATEGORIAS] ([ID], [NOMBRE]) VALUES (6, N'Cervezas')
GO
INSERT [dbo].[CATEGORIAS] ([ID], [NOMBRE]) VALUES (15, N'Fiambres')
GO
SET IDENTITY_INSERT [dbo].[CATEGORIAS] OFF
GO
SET IDENTITY_INSERT [dbo].[CLIENTES] ON 
GO
INSERT [dbo].[CLIENTES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [FECHNAC], [IDDOMICILIO], [IDUSUARIO], [IDTIPOPERSONA]) VALUES (1, N'Lescano', N'Leandro', N'', N'42420833', N'20-42420833-8', CAST(N'2000-03-19' AS Date), NULL, NULL, 1)
GO
INSERT [dbo].[CLIENTES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [FECHNAC], [IDDOMICILIO], [IDUSUARIO], [IDTIPOPERSONA]) VALUES (5, N'Cassano', N'Juan Cruz', N'', N'12346578', N'10-23456789-2', CAST(N'1992-10-10' AS Date), 0, NULL, 1)
GO
INSERT [dbo].[CLIENTES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [FECHNAC], [IDDOMICILIO], [IDUSUARIO], [IDTIPOPERSONA]) VALUES (9, N'Valenzuela', N'Elias', N'', N'12312312', N'45645645', CAST(N'1996-04-22' AS Date), NULL, NULL, 1)
GO
INSERT [dbo].[CLIENTES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [FECHNAC], [IDDOMICILIO], [IDUSUARIO], [IDTIPOPERSONA]) VALUES (15, N'', N'', N'Municipio de Tigre', N'', N'60-456789321-8', CAST(N'2019-05-05' AS Date), 0, NULL, 2)
GO
INSERT [dbo].[CLIENTES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [FECHNAC], [IDDOMICILIO], [IDUSUARIO], [IDTIPOPERSONA]) VALUES (21, N'', N'', N'UTN', N'', N'123456789', CAST(N'2019-05-11' AS Date), 0, NULL, 2)
GO
SET IDENTITY_INSERT [dbo].[CLIENTES] OFF
GO
SET IDENTITY_INSERT [dbo].[DOMICILIOS] ON 
GO
INSERT [dbo].[DOMICILIOS] ([ID], [ALTURA], [CALLE], [IDCOORDENADAS], [ENTRECALLE1], [ENTRECALLE2], [IDLOCALIDAD], [PISO], [DEPARTAMENTO]) VALUES (1, 4551, N'Blanco Encalada', NULL, N'', N'', NULL, NULL, NULL)
GO
INSERT [dbo].[DOMICILIOS] ([ID], [ALTURA], [CALLE], [IDCOORDENADAS], [ENTRECALLE1], [ENTRECALLE2], [IDLOCALIDAD], [PISO], [DEPARTAMENTO]) VALUES (7, 2424, N'Santa Rita', NULL, N'', N'', 4, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[DOMICILIOS] OFF
GO
SET IDENTITY_INSERT [dbo].[EMPLEADOS] ON 
GO
INSERT [dbo].[EMPLEADOS] ([ID], [APELLIDOS], [NOMBRES], [DNI], [CUIL], [IDDOMICILIO], [IDUSUARIO], [IDTIPOEMPLEADO], [FECHNAC]) VALUES (2, N'Lescano', N'Leandro Nicolas', N'42420833', N'20-42420833-8', 22, 0, 1, CAST(N'2000-03-19' AS Date))
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
SET IDENTITY_INSERT [dbo].[MARCAS] ON 
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (1, N'Paladini')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (2, N'Cabaña')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (3, N'La Serenisima')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (4, N'Coca-Cola')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (5, N'Manaos')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (6, N'Pepsi')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (7, N'SanCor')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (8, N'Arcor')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (9, N'Yogurisimo')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (11, N'Quilmes')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (12, N'Lays')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (13, N'Tostitos')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (14, N'Nutella')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (15, N'Cadbury')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (16, N'Pritty')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (17, N'Paladini')
GO
SET IDENTITY_INSERT [dbo].[MARCAS] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCTOS] ON 
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK], [FRACCIONABLE], [PESO], [PORCENTAJEGANANCIA]) VALUES (1, 4, N'Queso Regiannito', 3, 20.0000, 0, 1, N'1.5', N'0')
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK], [FRACCIONABLE], [PESO], [PORCENTAJEGANANCIA]) VALUES (2, 2, N'Coca-Cola', 4, 30.0000, 0, 0, N'0', N'0')
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK], [FRACCIONABLE], [PESO], [PORCENTAJEGANANCIA]) VALUES (3, 3, N'Papas Fritas Originales', 12, 50.0000, 0, 0, N'0', N'0')
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK], [FRACCIONABLE], [PESO], [PORCENTAJEGANANCIA]) VALUES (4, 6, N'Cerveza Quilmes 250ml', 11, 30.0000, 0, 0, N'0', N'0')
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK], [FRACCIONABLE], [PESO], [PORCENTAJEGANANCIA]) VALUES (6, 2, N'Manaos Cola 750ml', 5, 20.0000, 0, 0, N'0', N'0')
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK], [FRACCIONABLE], [PESO], [PORCENTAJEGANANCIA]) VALUES (7, 3, N'Cadbury Yoghurt Frutilla', 15, 50.0000, 0, 0, N'0', N'0')
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK], [FRACCIONABLE], [PESO], [PORCENTAJEGANANCIA]) VALUES (9, 2, N'Pritty Zero 250ml', 16, 5.0000, 0, 0, N'0', N'1.00')
GO
SET IDENTITY_INSERT [dbo].[PRODUCTOS] OFF
GO
SET IDENTITY_INSERT [dbo].[PROVEEDORES] ON 
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA], [FECHNAC]) VALUES (2, N'', N'', N'Coca-Cola', N'', N'132456789', 13, 2, NULL)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA], [FECHNAC]) VALUES (4, N'', N'', N'Jumbalay', N'', N'123456780', 0, 2, NULL)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA], [FECHNAC]) VALUES (6, N'', N'', N'SanCor', N'', N'123456788', 0, 2, NULL)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA], [FECHNAC]) VALUES (8, N'', N'', N'Vincar', N'', N'123456786', 7, 2, NULL)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA], [FECHNAC]) VALUES (11, N'Lescano', N'Leandro', N'', N'42424242', N'20-42424242-8', 1, 1, NULL)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA], [FECHNAC]) VALUES (22, N'', N'', N'La Serenisima', N'', N'123456789', 18, 2, CAST(N'1900-01-01' AS Date))
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
INSERT [dbo].[PROVEEDORES_X_PRODUCTO] ([IDPRODUCTO], [IDPROVEEDOR]) VALUES (9, 8)
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
ALTER TABLE [dbo].[CLIENTES] ADD  DEFAULT ('') FOR [APELLIDOS]
GO
ALTER TABLE [dbo].[CLIENTES] ADD  DEFAULT ('') FOR [NOMBRES]
GO
ALTER TABLE [dbo].[DOMICILIOS] ADD  DEFAULT ('-') FOR [ENTRECALLE1]
GO
ALTER TABLE [dbo].[DOMICILIOS] ADD  DEFAULT ('-') FOR [ENTRECALLE2]
GO
ALTER TABLE [dbo].[PRODUCTOS] ADD  DEFAULT ((0)) FOR [STOCK]
GO
ALTER TABLE [dbo].[PRODUCTOS] ADD  DEFAULT ((0)) FOR [FRACCIONABLE]
GO
ALTER TABLE [dbo].[PROVEEDORES] ADD  DEFAULT ('') FOR [APELLIDOS]
GO
ALTER TABLE [dbo].[PROVEEDORES] ADD  DEFAULT ('') FOR [NOMBRES]
GO
ALTER TABLE [dbo].[PROVEEDORES] ADD  DEFAULT ('') FOR [RAZONSOCIAL]
GO
ALTER TABLE [dbo].[PROVEEDORES] ADD  DEFAULT ('1/1/1900') FOR [FECHNAC]
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
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[PROVEEDORES] CHECK CONSTRAINT [FK__PROVEEDOR__IDDOM__6A30C649]
GO
ALTER TABLE [dbo].[PROVEEDORES]  WITH CHECK ADD  CONSTRAINT [FK__PROVEEDOR__IDTIP__6B24EA82] FOREIGN KEY([IDTIPOPERSONA])
REFERENCES [dbo].[TIPO_PERSONA] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PROVEEDORES] CHECK CONSTRAINT [FK__PROVEEDOR__IDTIP__6B24EA82]
GO
ALTER TABLE [dbo].[PROVEEDORES_X_PRODUCTO]  WITH CHECK ADD FOREIGN KEY([IDPRODUCTO])
REFERENCES [dbo].[PRODUCTOS] ([ID])
GO
ALTER TABLE [dbo].[TELEFONOS_X_CLIENTES]  WITH CHECK ADD FOREIGN KEY([IDCLIENTE])
REFERENCES [dbo].[CLIENTES] ([ID])
GO
ALTER TABLE [dbo].[TELEFONOS_X_CLIENTES]  WITH CHECK ADD FOREIGN KEY([IDTELEFONOS])
REFERENCES [dbo].[TELEFONOS] ([ID])
GO
ALTER TABLE [dbo].[TELEFONOS_X_EMPLEADOS]  WITH CHECK ADD FOREIGN KEY([IDEMPLEADO])
REFERENCES [dbo].[EMPLEADOS] ([ID])
GO
ALTER TABLE [dbo].[TELEFONOS_X_EMPLEADOS]  WITH CHECK ADD FOREIGN KEY([IDTELEFONOS])
REFERENCES [dbo].[TELEFONOS] ([ID])
GO
ALTER TABLE [dbo].[TELEFONOS_X_PROVEEDORES]  WITH CHECK ADD FOREIGN KEY([IDTELEFONOS])
REFERENCES [dbo].[TELEFONOS] ([ID])
GO
USE [master]
GO
ALTER DATABASE [LESCANO_DB] SET  READ_WRITE 
GO
