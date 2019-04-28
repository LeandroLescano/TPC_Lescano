USE master
GO
CREATE DATABASE FIAMBRERIA
GO
USE FIAMBRERIA

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
CREATE TABLE EDIFICIOS(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
PISO INT NOT NULL,
DEPARTAMENTO VARCHAR(10) NOT NULL,
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
IDEDIFICIO INT NULL FOREIGN KEY REFERENCES EDIFICIOS(ID),
IDLOCALIDAD INT NULL FOREIGN KEY REFERENCES LOCALIDADES(ID),
)
GO
CREATE TABLE USUARIOS(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
USUARIO VARCHAR(50) NOT NULL,
CONTRASEŅA VARCHAR(50) NOT NULL
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
RAZONSOCIAL VARCHAR(100) NOT NULL,
DNI VARCHAR(15) NOT NULL,
CUIT VARCHAR(20) NOT NULL,
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
STOCK INT NOT NULL DEFAULT(0),
)
GO
CREATE TABLE PROVEEDORES_X_PRODUCTO(
IDPRODUCTO INT NOT NULL FOREIGN KEY REFERENCES PRODUCTOS(ID),
IDPROVEEDOR INT NOT NULL FOREIGN KEY REFERENCES PROVEEDORES(ID),
PRIMARY KEY (IDPRODUCTO, IDPROVEEDOR)
)


Select P.ID, P.NOMBRE, M.NOMBRE as MARCA ,P.PRECIOUNITARIO ,P.STOCK, PROV.RAZONSOCIAL,C.NOMBRE from PRODUCTOS AS P 
LEFT JOIN MARCAS AS M ON M.ID = P.IDMARCA 
LEFT JOIN PROVEEDORES_X_PRODUCTO AS PP ON PP.IDPRODUCTO = P.ID
LEFT JOIN PROVEEDORES AS PROV ON PROV.ID = PP.IDPROVEEDOR 
LEFT JOIN CATEGORIAS AS C ON C.ID = P.IDCATEGORIA

SELECT * FROM PRODUCTOS

Select * FROM PROVEEDORES

SELECT RAZONSOCIAL AS NOMBRE FROM PROVEEDORES
WHERE IDTIPOPERSONA = 2
UNION
Select (APELLIDOS +', ' + NOMBRES) AS NOMBRE FROM PROVEEDORES
WHERE IDTIPOPERSONA = 1

SELECT RAZONSOCIAL AS NOMBRE FROM CLIENTES
WHERE IDTIPOPERSONA = 2
UNION
Select (APELLIDOS +', ' + NOMBRES) AS NOMBRE FROM CLIENTES
WHERE IDTIPOPERSONA = 1