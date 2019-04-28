USE [FIAMBRERIA]
GO
SET IDENTITY_INSERT [dbo].[TIPO_PERSONA] ON 
GO
INSERT [dbo].[TIPO_PERSONA] ([ID], [TIPO]) VALUES (1, N'Física')
GO
INSERT [dbo].[TIPO_PERSONA] ([ID], [TIPO]) VALUES (2, N'Jurídica')
GO
SET IDENTITY_INSERT [dbo].[TIPO_PERSONA] OFF
GO
SET IDENTITY_INSERT [dbo].[PROVEEDORES] ON 
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA]) VALUES (2, '', '', N'Coca-Cola', N'123456789', '132456789', NULL, 2)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA]) VALUES (4, '', '', N'Jumbalay', N'123456780', '123456780', NULL, 2)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA]) VALUES (6, '', '', N'SanCor', N'123456788', '123456788', NULL, 2)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA]) VALUES (7, '', '', N'La Serenisima', N'123456787', '123456787', NULL, 2)
GO
INSERT [dbo].[PROVEEDORES] ([ID], [APELLIDOS], [NOMBRES], [RAZONSOCIAL], [DNI], [CUIT], [IDDOMICILIO], [IDTIPOPERSONA]) VALUES (8, '', '', N'Vincar', N'123456786', '123456786', NULL, 2)
GO
SET IDENTITY_INSERT [dbo].[PROVEEDORES] OFF
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
SET IDENTITY_INSERT [dbo].[TIPO_EMPLEADO] ON 
GO
INSERT [dbo].[TIPO_EMPLEADO] ([ID], [TIPO]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[TIPO_EMPLEADO] ([ID], [TIPO]) VALUES (2, N'Vendedor')
GO
SET IDENTITY_INSERT [dbo].[TIPO_EMPLEADO] OFF
GO


