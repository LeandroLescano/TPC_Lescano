USE master
GO
CREATE DATABASE LESCANO_DB
GO
USE LESCANO_DB

GO
CREATE TABLE TIPO_PERSONA(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
TIPO VARCHAR(10) NOT NULL
)
GO
CREATE TABLE TIPO_EMPLEADO(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
TIPO VARCHAR(15) NOT NULL
)
GO
CREATE TABLE LOCALIDADES(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
CODPOSTAL VARCHAR(10) NOT NULL,
NOMBRE VARCHAR(50) NOT NULL,
PARTIDO VARCHAR(50) NOT NULL
)
GO
CREATE TABLE PROVINCIAS(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
NOMBRE VARCHAR(20) NOT NULL
)
GO
CREATE TABLE DOMICILIOS(
ID INT NOT NULL PRIMARY KEY IDENTITY (1,1),
ALTURA INT NOT NULL,
CALLE VARCHAR(100) NOT NULL,
IDCOORDENADAS INT NULL,
ENTRECALLE1 VARCHAR(100) NOT NULL DEFAULT ('-'),
ENTRECALLE2 VARCHAR(100) NOT NULL DEFAULT('-'),
PISO INT NULL,
DEPARTAMENTO VARCHAR(10) NULL,
IDLOCALIDAD INT NULL FOREIGN KEY REFERENCES LOCALIDADES(ID),
)
GO
CREATE TABLE USUARIOS(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
USUARIO VARCHAR(50) NOT NULL,
CONTRASE�A VARCHAR(50) NOT NULL
)
GO
CREATE TABLE EMPLEADOS(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
APELLIDOS VARCHAR(50) NOT NULL,
NOMBRES VARCHAR(50) NOT NULL,
DNI VARCHAR(15) NOT NULL,
CUIL VARCHAR(20) NOT NULL,
IDDOMICILIO INT NULL FOREIGN KEY REFERENCES DOMICILIOS(ID),
IDUSUARIO INT NULL FOREIGN KEY REFERENCES USUARIOS(ID),
IDTIPOEMPLEADO INT NOT NULL FOREIGN KEY REFERENCES TIPO_EMPLEADO(ID)
)
GO
CREATE TABLE CLIENTES(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
APELLIDOS VARCHAR(50) NOT NULL DEFAULT(''),
NOMBRES VARCHAR(50) NOT NULL DEFAULT (''),
RAZONSOCIAL VARCHAR(100) NOT NULL DEFAULT (''),
DNI VARCHAR(15) NOT NULL,
CUIT VARCHAR(20) NOT NULL,
FECHNAC DATE NOT NULL,
IDDOMICILIO INT NULL FOREIGN KEY REFERENCES DOMICILIOS(ID),
IDUSUARIO INT NULL FOREIGN KEY REFERENCES USUARIOS(ID),
IDTIPOPERSONA INT NOT NULL FOREIGN KEY REFERENCES TIPO_PERSONA(ID)
)
GO
CREATE TABLE TELEFONOS(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
TELEFONO VARCHAR(20) NOT NULL,
)
GO
CREATE TABLE MAILS(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
MAIL VARCHAR(100) NOT NULL,
)
GO
CREATE TABLE TELEFONOS_X_EMPLEADOS(
IDEMPLEADO INT NOT NULL FOREIGN KEY REFERENCES EMPLEADOS(ID),
IDTELEFONOS INT NOT NULL FOREIGN KEY REFERENCES TELEFONOS(ID),
PRIMARY KEY (IDEMPLEADO, IDTELEFONOS)
)
GO
CREATE TABLE MAILS_X_EMPLEADOS(
IDEMPLEADO INT NOT NULL FOREIGN KEY REFERENCES EMPLEADOS(ID),
IDMAIL INT NOT NULL FOREIGN KEY REFERENCES MAILS(ID),
PRIMARY KEY (IDEMPLEADO, IDMAIL)
)
GO
CREATE TABLE TELEFONOS_X_CLIENTES(
IDCLIENTE INT NOT NULL FOREIGN KEY REFERENCES CLIENTES(ID),
IDTELEFONOS INT NOT NULL FOREIGN KEY REFERENCES TELEFONOS(ID),
PRIMARY KEY (IDCLIENTE, IDTELEFONOS)
)
GO
CREATE TABLE MAILS_X_CLIENTES(
IDCLIENTE INT NOT NULL FOREIGN KEY REFERENCES CLIENTES(ID),
IDMAIL INT NOT NULL FOREIGN KEY REFERENCES MAILS(ID),
PRIMARY KEY (IDCLIENTE, IDMAIL)
)
GO
CREATE TABLE PROVEEDORES(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
APELLIDOS VARCHAR(50) NOT NULL DEFAULT (''),
NOMBRES VARCHAR(50) NOT NULL DEFAULT (''),
RAZONSOCIAL VARCHAR(100) NOT NULL DEFAULT (''),
DNI VARCHAR(15) NOT NULL,
CUIT VARCHAR(20) NOT NULL,
IDDOMICILIO INT NULL FOREIGN KEY REFERENCES DOMICILIOS(ID),
IDTIPOPERSONA INT NOT NULL FOREIGN KEY REFERENCES TIPO_PERSONA(ID)
)
GO
CREATE TABLE TELEFONOS_X_PROVEEDORES(
IDPROVEEDOR INT NOT NULL FOREIGN KEY REFERENCES PROVEEDORES(ID),
IDTELEFONOS INT NOT NULL FOREIGN KEY REFERENCES TELEFONOS(ID),
PRIMARY KEY (IDPROVEEDOR, IDTELEFONOS)
)
GO
CREATE TABLE MAILS_X_PROVEEDORES(
IDPROVEEDOR INT NOT NULL FOREIGN KEY REFERENCES PROVEEDORES(ID),
IDMAIL INT NOT NULL FOREIGN KEY REFERENCES MAILS(ID),
PRIMARY KEY (IDPROVEEDOR, IDMAIL)
)
GO
CREATE TABLE MARCAS(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
NOMBRE VARCHAR(50) NOT NULL
)
GO
CREATE TABLE CATEGORIAS(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
NOMBRE VARCHAR(100) NOT NULL
)
GO
CREATE TABLE PRODUCTOS(
ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
IDCATEGORIA INT FOREIGN KEY REFERENCES CATEGORIAS(ID) NOT NULL,
NOMBRE VARCHAR(50) NOT NULL,
IDMARCA INT NOT NULL FOREIGN KEY REFERENCES MARCAS(ID),
PRECIOUNITARIO MONEY NOT NULL,
FRACCIONABLE BIT NOT NULL,
PESO DECIMAL NOT NULL,
PORCENTAJEGANANCIA DECIMAL NOT NULL,
STOCK INT NOT NULL DEFAULT(0),
)
GO
CREATE TABLE PROVEEDORES_X_PRODUCTO(
IDPRODUCTO INT NOT NULL FOREIGN KEY REFERENCES PRODUCTOS(ID),
IDPROVEEDOR INT NOT NULL FOREIGN KEY REFERENCES PROVEEDORES(ID),
PRIMARY KEY (IDPRODUCTO, IDPROVEEDOR)
)

USE [LESCANO_DB]
GO
SET IDENTITY_INSERT [dbo].[TIPO_PERSONA] ON 
GO
INSERT [dbo].[TIPO_PERSONA] ([ID], [TIPO]) VALUES (1, N'F�sica')
GO
INSERT [dbo].[TIPO_PERSONA] ([ID], [TIPO]) VALUES (2, N'Jur�dica')
GO
SET IDENTITY_INSERT [dbo].[TIPO_PERSONA] OFF
GO
SET IDENTITY_INSERT [dbo].[CLIENTES] ON 
GO
INSERT [dbo].[CLIENTES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDUSUARIO], [IDTIPOPERSONA], [FECHNAC]) VALUES (1, N'Lescano', N'Leandro', N'', N'42420833', N'20-42420833-8', NULL, NULL, 1, CAST(N'2000-03-19' AS Date))
GO
INSERT [dbo].[CLIENTES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDUSUARIO], [IDTIPOPERSONA], [FECHNAC]) VALUES (2, N'Cassano', N'Juan Cruz', N'', N'123465789', N'10-23456789-2', NULL, NULL, 1, CAST(N'1992-10-10' AS Date))
GO
INSERT [dbo].[CLIENTES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDUSUARIO], [IDTIPOPERSONA], [FECHNAC]) VALUES (3, N'Valenzuela', N'Elias', N'', N'12312312', N'45645645', NULL, NULL, 1, CAST(N'1996-04-22' AS Date))
GO
SET IDENTITY_INSERT [dbo].[CLIENTES] OFF
GO
SET IDENTITY_INSERT [dbo].[PROVEEDORES] ON 
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA]) VALUES (1, N'', N'', N'Coca-Cola', N'123456789', N'132456789', NULL, 2)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA]) VALUES (2, N'', N'', N'Jumbalay', N'123456780', N'123456780', NULL, 2)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA]) VALUES (3, N'', N'', N'SanCor', N'123456788', N'123456788', NULL, 2)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA]) VALUES (4, N'', N'', N'La Serenisima', N'123456787', N'123456787', NULL, 2)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA]) VALUES (5, N'', N'', N'Vincar', N'123456786', N'123456786', NULL, 2)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA]) VALUES (6, N'Gonzalez', N'Ramiro', N' ', N'123456785', N'123456785', NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[PROVEEDORES] OFF
GO
SET IDENTITY_INSERT [dbo].[TIPO_EMPLEADO] ON 
GO
INSERT [dbo].[TIPO_EMPLEADO] ([ID], [TIPO]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[TIPO_EMPLEADO] ([ID], [TIPO]) VALUES (2, N'Vendedor')
GO
SET IDENTITY_INSERT [dbo].[TIPO_EMPLEADO] OFF
GO
SET IDENTITY_INSERT [dbo].[MARCAS] ON 
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (1, N'Paladini')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (2, N'Caba�a')
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
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (10, N'Ser')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (11, N'Quilmes')
GO
INSERT [dbo].[MARCAS] ([ID], [NOMBRE]) VALUES (12, N'Lays')
GO
SET IDENTITY_INSERT [dbo].[MARCAS] OFF
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
SET IDENTITY_INSERT [dbo].[CATEGORIAS] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCTOS] ON 
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK]) VALUES (1, 4, N'Queso Regiannito', 3, 20.0000, 300)
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK]) VALUES (2, 2, N'Coca-Cola', 4, 30.0000, 50)
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK]) VALUES (3, 3, N'Papas Fritas Originales', 12, 50.0000, 60)
GO
INSERT [dbo].[PRODUCTOS] ([ID], [IDCATEGORIA], [NOMBRE], [IDMARCA], [PRECIOUNITARIO], [STOCK]) VALUES (4, 6, N'Cerveza Quilmes 250ml', 11, 30.0000, 70)
GO
SET IDENTITY_INSERT [dbo].[PRODUCTOS] OFF
GO
INSERT [dbo].[PROVEEDORES_X_PRODUCTO] ([IDPRODUCTO], [IDPROVEEDOR]) VALUES (1, 4)
GO
INSERT [dbo].[PROVEEDORES_X_PRODUCTO] ([IDPRODUCTO], [IDPROVEEDOR]) VALUES (2, 1)
GO
INSERT [dbo].[PROVEEDORES_X_PRODUCTO] ([IDPRODUCTO], [IDPROVEEDOR]) VALUES (3, 5)
GO
INSERT [dbo].[PROVEEDORES_X_PRODUCTO] ([IDPRODUCTO], [IDPROVEEDOR]) VALUES (4, 2)
GO

Select P.*, D.CALLE, D.ALTURA, L.NOMBRE from PROVEEDORES AS P LEFT JOIN DOMICILIOS AS D ON D.ID = P.IDDOMICILIO LEFT JOIN LOCALIDADES AS L ON L.ID = D.IDLOCALIDAD

select * from DOMICILIOS

UPDATE DOMICILIOS SET DEPARTAMENTO=NULL

ALTER TABLE LOCALIDADES
NOCHECK CONSTRAINT FK__DOMICILIO__IDLOC__440B1D61

Select ID FROM DOMICILIOS where CALLE LIKE '%Santa Ritaaa%' AND ALTURA LIKE 2424 AND ENTRECALLE1 LIKE '' AND ENTRECALLE2 LIKE ''


ALTER TABLE LOCALIDADES NOCHECK CONSTRAINT FK__DOMICILIO__IDLOC__440B1D61 Select ID FROM LOCALIDADES where NOMBRE LIKE '' AND PARTIDO LIKE ''  ALTER TABLE LOCALIDADES CHECK CONSTRAINT FK__DOMICILIO__IDLOC__440B1D61
