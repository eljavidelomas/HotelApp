USE [hotel]
GO
/****** Object:  Table [dbo].[articulosFormula]    Script Date: 09/08/2013 14:31:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articulosFormula](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idArticuloBase] [int] NOT NULL,
	[idArticuloComponente] [int] NOT NULL,
	[cantidadArticulosComponente] [smallint] NULL,
 CONSTRAINT [PK_articulosFormula] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[articulosFormula] ON
INSERT [dbo].[articulosFormula] ([id], [idArticuloBase], [idArticuloComponente], [cantidadArticulosComponente]) VALUES (1, 113, 15, 2)
INSERT [dbo].[articulosFormula] ([id], [idArticuloBase], [idArticuloComponente], [cantidadArticulosComponente]) VALUES (6, 117, 15, 3)
INSERT [dbo].[articulosFormula] ([id], [idArticuloBase], [idArticuloComponente], [cantidadArticulosComponente]) VALUES (7, 113, 900, 1)
INSERT [dbo].[articulosFormula] ([id], [idArticuloBase], [idArticuloComponente], [cantidadArticulosComponente]) VALUES (8, 118, 13, 1)
INSERT [dbo].[articulosFormula] ([id], [idArticuloBase], [idArticuloComponente], [cantidadArticulosComponente]) VALUES (9, 555, 907, 2)
INSERT [dbo].[articulosFormula] ([id], [idArticuloBase], [idArticuloComponente], [cantidadArticulosComponente]) VALUES (10, 555, 908, 1)
INSERT [dbo].[articulosFormula] ([id], [idArticuloBase], [idArticuloComponente], [cantidadArticulosComponente]) VALUES (11, 6, 900, 1)
INSERT [dbo].[articulosFormula] ([id], [idArticuloBase], [idArticuloComponente], [cantidadArticulosComponente]) VALUES (12, 800, 113, 2)
INSERT [dbo].[articulosFormula] ([id], [idArticuloBase], [idArticuloComponente], [cantidadArticulosComponente]) VALUES (13, 800, 13, 2)
SET IDENTITY_INSERT [dbo].[articulosFormula] OFF
/****** Object:  StoredProcedure [dbo].[articulosFormula_insertABM]    Script Date: 09/08/2013 14:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[articulosFormula_insertABM]
@artPadre int, @artHijo int,@cant int
as

if(exists(select 1 from articulosFormula where idArticuloBase=@artPadre and idArticuloComponente=@artHijo))
	update articulosFormula set cantidadArticulosComponente = @cant
	where idArticuloBase=@artPadre and idArticuloComponente=@artHijo
else
	insert into articulosFormula (idArticuloBase,idArticuloComponente,cantidadArticulosComponente)
	values(@artPadre,@artHijo,@cant)
GO
/****** Object:  Table [dbo].[articulos_descuentos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articulos_descuentos](
	[articuloId] [int] NOT NULL,
	[descuentoId] [int] NOT NULL,
 CONSTRAINT [PK_articulos_descuentos] PRIMARY KEY CLUSTERED 
(
	[articuloId] ASC,
	[descuentoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (7, 8)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (7, 9)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (8, 9)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (9, 5)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (10, 2)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (10, 5)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (10, 9)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (11, 5)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (11, 8)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (11, 9)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (13, 9)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (14, 2)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (14, 5)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (14, 8)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (14, 9)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (113, 5)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (113, 8)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (114, 5)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (114, 8)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (116, 5)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (116, 8)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (116, 9)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (117, 2)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (117, 8)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (118, 8)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (118, 9)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (119, 2)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (119, 8)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (554, 9)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (555, 9)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (800, 9)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (901, 9)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (904, 9)
INSERT [dbo].[articulos_descuentos] ([articuloId], [descuentoId]) VALUES (907, 9)
/****** Object:  Table [dbo].[articulos]    Script Date: 09/08/2013 14:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[articulos](
	[id] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[stockActual] [int] NOT NULL,
	[stockRecomendado] [int] NOT NULL,
	[precio] [decimal](8, 2) NOT NULL,
	[tipoArticulo] [char](1) NULL,
	[controlStock] [bit] NULL,
 CONSTRAINT [PK_articulos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_articulos] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (5, N'Quilmes Lata', -42, 15, CAST(14.00 AS Decimal(8, 2)), N'B', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (6, N'Quilmes 3/4', -11, 15, CAST(20.00 AS Decimal(8, 2)), N'B', 0)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (7, N'Fanta', -77, 15, CAST(14.00 AS Decimal(8, 2)), N'B', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (8, N'Papas Fritas', -54, 15, CAST(14.00 AS Decimal(8, 2)), N'B', 0)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (9, N'Champan', -49, 15, CAST(60.00 AS Decimal(8, 2)), N'B', 0)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (10, N'Brahma Lata', -182, 15, CAST(14.00 AS Decimal(8, 2)), N'B', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (11, N'Brahma 3/4', 25, 15, CAST(18.00 AS Decimal(8, 2)), N'B', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (13, N'Pancho', -191, 15, CAST(10.00 AS Decimal(8, 2)), N'B', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (14, N'Alfajor', -107, 15, CAST(6.00 AS Decimal(8, 2)), N'B', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (15, N'Servilleta', -399, 10, CAST(0.00 AS Decimal(8, 2)), N'C', 0)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (113, N'Coca-Cola', -136, 10, CAST(10.00 AS Decimal(8, 2)), N'B', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (114, N'Sprite', -67, 10, CAST(11.00 AS Decimal(8, 2)), N'B', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (116, N'Coca-Cola Zero', 25, 15, CAST(11.00 AS Decimal(8, 2)), N'B', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (117, N'Sprite Zero', 19, 15, CAST(11.00 AS Decimal(8, 2)), N'B', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (118, N'Fanta Zero', 14, 15, CAST(11.00 AS Decimal(8, 2)), N'B', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (119, N'Ser Citrus', 25, 15, CAST(11.00 AS Decimal(8, 2)), N'B', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (554, N'Hamburguesa Sola', -8, 0, CAST(15.00 AS Decimal(8, 2)), N'B', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (555, N'Hamburguesa grande', 16, 15, CAST(14.00 AS Decimal(8, 2)), N'B', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (800, N'Menu 1', -8, 0, CAST(25.00 AS Decimal(8, 2)), N'B', 0)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (900, N'Vaso vidrio', -80, 0, CAST(15.00 AS Decimal(8, 2)), N'C', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (901, N'Jabon Tocador', 100, 30, CAST(1.00 AS Decimal(8, 2)), N'C', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (903, N'Cepillo dientes', 1, 1, CAST(0.00 AS Decimal(8, 2)), N'C', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (904, N'Jabon Dove', 1, 1, CAST(1.00 AS Decimal(8, 2)), N'C', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (905, N'Secapelos Electrico 3', 1, 1, CAST(1.00 AS Decimal(8, 2)), N'C', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (906, N'Ceniceros', 0, 0, CAST(0.00 AS Decimal(8, 2)), N'C', 1)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (907, N'Jamon', -24, 0, CAST(0.00 AS Decimal(8, 2)), N'C', 0)
INSERT [dbo].[articulos] ([id], [nombre], [stockActual], [stockRecomendado], [precio], [tipoArticulo], [controlStock]) VALUES (908, N'Queso', -12, 0, CAST(0.00 AS Decimal(8, 2)), N'C', 0)
/****** Object:  Table [dbo].[turnos_consumos]    Script Date: 09/08/2013 14:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[turnos_consumos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[articulo_id] [int] NOT NULL,
	[turno_id] [int] NOT NULL,
	[cantidadArticulos] [tinyint] NOT NULL,
 CONSTRAINT [PK_turnos_consumos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[turnos_consumos] ON
INSERT [dbo].[turnos_consumos] ([id], [articulo_id], [turno_id], [cantidadArticulos]) VALUES (272, 6, 244, 8)
INSERT [dbo].[turnos_consumos] ([id], [articulo_id], [turno_id], [cantidadArticulos]) VALUES (273, 7, 244, 15)
INSERT [dbo].[turnos_consumos] ([id], [articulo_id], [turno_id], [cantidadArticulos]) VALUES (277, 5, 244, 4)
INSERT [dbo].[turnos_consumos] ([id], [articulo_id], [turno_id], [cantidadArticulos]) VALUES (278, 113, 244, 5)
INSERT [dbo].[turnos_consumos] ([id], [articulo_id], [turno_id], [cantidadArticulos]) VALUES (279, 114, 244, 1)
INSERT [dbo].[turnos_consumos] ([id], [articulo_id], [turno_id], [cantidadArticulos]) VALUES (280, 5, 248, 4)
INSERT [dbo].[turnos_consumos] ([id], [articulo_id], [turno_id], [cantidadArticulos]) VALUES (281, 9, 248, 1)
INSERT [dbo].[turnos_consumos] ([id], [articulo_id], [turno_id], [cantidadArticulos]) VALUES (282, 6, 248, 1)
INSERT [dbo].[turnos_consumos] ([id], [articulo_id], [turno_id], [cantidadArticulos]) VALUES (283, 10, 244, 2)
INSERT [dbo].[turnos_consumos] ([id], [articulo_id], [turno_id], [cantidadArticulos]) VALUES (284, 14, 244, 3)
INSERT [dbo].[turnos_consumos] ([id], [articulo_id], [turno_id], [cantidadArticulos]) VALUES (285, 5, 251, 1)
INSERT [dbo].[turnos_consumos] ([id], [articulo_id], [turno_id], [cantidadArticulos]) VALUES (286, 8, 251, 1)
SET IDENTITY_INSERT [dbo].[turnos_consumos] OFF
/****** Object:  StoredProcedure [dbo].[articulosFormula_getAll]    Script Date: 09/08/2013 14:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[articulosFormula_getAll]
	as
	select id,nombre from articulos
GO
/****** Object:  StoredProcedure [dbo].[articulosCompuestos_get]    Script Date: 09/08/2013 14:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[articulosCompuestos_get]
@artPadre int
as

select af.id, a.nombre,af.cantidadArticulosComponente 
from articulosFormula af 
left join articulos a on af.idArticuloComponente = a.id
where af.idArticuloBase = @artPadre
GO
/****** Object:  StoredProcedure [dbo].[articulosCompuestos_delete]    Script Date: 09/08/2013 14:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[articulosCompuestos_delete]
@id int
as

delete
from articulosFormula 
where id  = @id
GO
/****** Object:  StoredProcedure [dbo].[articulos_obtenerNombre]    Script Date: 09/08/2013 14:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[articulos_obtenerNombre]
@artId int
AS
BEGIN
	SET NOCOUNT ON;
	select nombre,precio from articulos
	where id=@artId
		
END
GO
/****** Object:  StoredProcedure [dbo].[articulos_obtenerListado]    Script Date: 09/08/2013 14:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[articulos_obtenerListado]
AS	
	select id,nombre,precio,stockActual from articulos
	where tipoArticulo = 'B'
GO
/****** Object:  Trigger [descontarArticulosCompuestos]    Script Date: 09/08/2013 14:31:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[descontarArticulosCompuestos]
   ON  [dbo].[articulos]
   AFTER UPDATE
AS 
BEGIN	
	SET NOCOUNT ON;

	IF UPDATE(stockActual) -- Solo si se actualiza el Stock

	BEGIN 
		declare @artId int;
		declare @cantAnt int;
		declare @cantDsp int;
		declare @artComp int;
		declare @cantArtComp int;

		select  @artId = id from inserted
		select @cantAnt = stockActual from deleted
		select @cantDsp = stockActual from inserted
		
--		if(@cantAnt <= @cantDsp)
--			return;

		if((select top(1) 1 from articulosFormula where idArticuloBase = @artId) is null )
			return;
		else
		BEGIN
			declare @idArtForm int

			select @idArtForm = min( id) from articulosFormula where idArticuloBase = @artId

			while @idArtForm is not null
			begin
					
				select @artComp=idArticuloComponente,@cantArtComp=cantidadArticulosComponente from articulosFormula where id = @idArtForm
				update articulos set stockActual=stockActual - (( @cantAnt - @cantDsp)*@cantArtComp) where id=@artComp
				select @idArtForm = min( id) from articulosFormula where id > @idArtForm and idArticuloBase = @artId
			end			
		END	

	END

END
GO
/****** Object:  Table [dbo].[categorias]    Script Date: 09/08/2013 14:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categorias](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[alias] [nchar](4) NULL,
 CONSTRAINT [PK_categorias] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[categorias] ON
INSERT [dbo].[categorias] ([id], [nombre], [alias]) VALUES (1, N'Común', N'COM ')
INSERT [dbo].[categorias] ([id], [nombre], [alias]) VALUES (4, N'Suite', N'SUI ')
INSERT [dbo].[categorias] ([id], [nombre], [alias]) VALUES (5, N'Común Express', N'EXP ')
INSERT [dbo].[categorias] ([id], [nombre], [alias]) VALUES (13, N'Suite Especial2', N'SUIE')
INSERT [dbo].[categorias] ([id], [nombre], [alias]) VALUES (15, N'Especial', N'ESP ')
SET IDENTITY_INSERT [dbo].[categorias] OFF
/****** Object:  Table [dbo].[descuentos]    Script Date: 09/08/2013 14:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[descuentos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](50) NULL,
	[descuentoFijo] [decimal](8, 2) NULL,
	[descuentoPorcentaje] [int] NULL,
	[cantidadArticulos] [int] NULL,
 CONSTRAINT [PK_descuentos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[descuentos] ON
INSERT [dbo].[descuentos] ([id], [nombre], [descripcion], [descuentoFijo], [descuentoPorcentaje], [cantidadArticulos]) VALUES (2, N'Descuento $5', N'Presentando cupón, $5 de descuento ', CAST(5.00 AS Decimal(8, 2)), NULL, NULL)
INSERT [dbo].[descuentos] ([id], [nombre], [descripcion], [descuentoFijo], [descuentoPorcentaje], [cantidadArticulos]) VALUES (5, N'10% + 2 Consumiciones', NULL, CAST(5.00 AS Decimal(8, 2)), 10, 2)
INSERT [dbo].[descuentos] ([id], [nombre], [descripcion], [descuentoFijo], [descuentoPorcentaje], [cantidadArticulos]) VALUES (6, N'Socios', N'Para cambiar puntos', NULL, NULL, NULL)
INSERT [dbo].[descuentos] ([id], [nombre], [descripcion], [descuentoFijo], [descuentoPorcentaje], [cantidadArticulos]) VALUES (8, N'3 Consumiciones', N'3 consumiciones gratis', CAST(3.00 AS Decimal(8, 2)), 5, 3)
INSERT [dbo].[descuentos] ([id], [nombre], [descripcion], [descuentoFijo], [descuentoPorcentaje], [cantidadArticulos]) VALUES (9, N'4 Consumiciones free', NULL, NULL, NULL, 4)
INSERT [dbo].[descuentos] ([id], [nombre], [descripcion], [descuentoFijo], [descuentoPorcentaje], [cantidadArticulos]) VALUES (10, N'gustavo', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[descuentos] OFF
/****** Object:  Table [dbo].[conserjes]    Script Date: 09/08/2013 14:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[conserjes](
	[usuario] [smallint] NOT NULL,
	[nombre] [nvarchar](20) NOT NULL,
	[apellido] [nvarchar](20) NOT NULL,
	[clave] [int] NOT NULL,
	[logueado] [bit] NOT NULL,
 CONSTRAINT [PK_conserjes] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[conserjes] ([usuario], [nombre], [apellido], [clave], [logueado]) VALUES (1, N'María Ines', N'Peña', 1234, 1)
INSERT [dbo].[conserjes] ([usuario], [nombre], [apellido], [clave], [logueado]) VALUES (2, N'Ricardo', N'Perez', 1234, 0)
INSERT [dbo].[conserjes] ([usuario], [nombre], [apellido], [clave], [logueado]) VALUES (3, N'julio', N'badu', 1234, 0)
INSERT [dbo].[conserjes] ([usuario], [nombre], [apellido], [clave], [logueado]) VALUES (4, N'pepe', N'sas', 1234, 0)
/****** Object:  Table [dbo].[estadoHabitacion]    Script Date: 09/08/2013 14:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[estadoHabitacion](
	[id] [smallint] NOT NULL,
	[estado] [char](1) NOT NULL,
	[descripcion] [varchar](15) NULL,
 CONSTRAINT [PK_estadoHabitacion_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[estado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[estadoHabitacion] ([id], [estado], [descripcion]) VALUES (1, N'A', N'Asignado')
INSERT [dbo].[estadoHabitacion] ([id], [estado], [descripcion]) VALUES (1, N'O', N'Ocupado')
INSERT [dbo].[estadoHabitacion] ([id], [estado], [descripcion]) VALUES (3, N'D', N'Disponible')
INSERT [dbo].[estadoHabitacion] ([id], [estado], [descripcion]) VALUES (4, N'M', N'Mucama')
INSERT [dbo].[estadoHabitacion] ([id], [estado], [descripcion]) VALUES (5, N'X', N'Fuera servicio')
/****** Object:  Table [dbo].[dias]    Script Date: 09/08/2013 14:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dias](
	[id] [tinyint] NOT NULL,
	[nombre] [nvarchar](16) NULL,
 CONSTRAINT [PK_dias] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[dias] ([id], [nombre]) VALUES (0, N'Domingo')
INSERT [dbo].[dias] ([id], [nombre]) VALUES (1, N'Lunes')
INSERT [dbo].[dias] ([id], [nombre]) VALUES (2, N'Martes')
INSERT [dbo].[dias] ([id], [nombre]) VALUES (3, N'Miercoles')
INSERT [dbo].[dias] ([id], [nombre]) VALUES (4, N'Jueves')
INSERT [dbo].[dias] ([id], [nombre]) VALUES (5, N'Viernes')
INSERT [dbo].[dias] ([id], [nombre]) VALUES (6, N'Sabado')
INSERT [dbo].[dias] ([id], [nombre]) VALUES (8, N'Feriado')
INSERT [dbo].[dias] ([id], [nombre]) VALUES (9, N'Vispera')
INSERT [dbo].[dias] ([id], [nombre]) VALUES (10, N'Vispera2')
INSERT [dbo].[dias] ([id], [nombre]) VALUES (11, N'Vispera3')
INSERT [dbo].[dias] ([id], [nombre]) VALUES (12, N'Viernes2')
/****** Object:  Table [dbo].[compras]    Script Date: 09/08/2013 14:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[compras](
	[compraId] [int] IDENTITY(1,1) NOT NULL,
	[articuloId] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[fechaIngreso] [datetime] NOT NULL,
	[comentario] [varchar](50) NOT NULL,
	[compra] [smallint] NOT NULL,
	[reposicion] [smallint] NOT NULL,
 CONSTRAINT [PK_compras] PRIMARY KEY CLUSTERED 
(
	[compraId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[compras] ON
INSERT [dbo].[compras] ([compraId], [articuloId], [descripcion], [fechaIngreso], [comentario], [compra], [reposicion]) VALUES (2, 9, N'Champan', CAST(0x0000A2330006B148 AS DateTime), N'test test', 20, 0)
INSERT [dbo].[compras] ([compraId], [articuloId], [descripcion], [fechaIngreso], [comentario], [compra], [reposicion]) VALUES (3, 554, N'Hamburguesa Sola', CAST(0x0000A22E00074BF8 AS DateTime), N'Todo Ok', 15, 0)
INSERT [dbo].[compras] ([compraId], [articuloId], [descripcion], [fechaIngreso], [comentario], [compra], [reposicion]) VALUES (4, 5, N'Quilmes Lata', CAST(0x0000A233000825F0 AS DateTime), N'lalal', 12, 10)
INSERT [dbo].[compras] ([compraId], [articuloId], [descripcion], [fechaIngreso], [comentario], [compra], [reposicion]) VALUES (28, 5, N'Quilmes Lata', CAST(0x0000A233000942B4 AS DateTime), N'lalal', 20, 5)
INSERT [dbo].[compras] ([compraId], [articuloId], [descripcion], [fechaIngreso], [comentario], [compra], [reposicion]) VALUES (29, 5, N'Quilmes Lata', CAST(0x0000A233000942B4 AS DateTime), N'', 20, 5)
INSERT [dbo].[compras] ([compraId], [articuloId], [descripcion], [fechaIngreso], [comentario], [compra], [reposicion]) VALUES (30, 7, N'Fanta', CAST(0x0000A2330009AD58 AS DateTime), N'Es prueba', 30, 0)
INSERT [dbo].[compras] ([compraId], [articuloId], [descripcion], [fechaIngreso], [comentario], [compra], [reposicion]) VALUES (31, 7, N'Fanta', CAST(0x0000A2330009AD58 AS DateTime), N'', 0, 0)
INSERT [dbo].[compras] ([compraId], [articuloId], [descripcion], [fechaIngreso], [comentario], [compra], [reposicion]) VALUES (32, 554, N'Hamburguesa Sola', CAST(0x0000A233000ABD38 AS DateTime), N'test reposicion', 0, 20)
INSERT [dbo].[compras] ([compraId], [articuloId], [descripcion], [fechaIngreso], [comentario], [compra], [reposicion]) VALUES (33, 900, N'Vaso vidrio', CAST(0x0000A233000ABD38 AS DateTime), N'se rompieron', 20, 0)
SET IDENTITY_INSERT [dbo].[compras] OFF
/****** Object:  UserDefinedFunction [dbo].[hora_ss]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[hora_ss] (@DATE datetime)
RETURNS varchar(8)
AS
BEGIN
	return (SELECT CONVERT(VARCHAR(5),@DATE,108))
end
GO
/****** Object:  UserDefinedFunction [dbo].[hora_mm]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[hora_mm] (@DATE datetime)
RETURNS varchar(8)
AS
BEGIN
	return  (SELECT REPLACE( (SELECT CONVERT(VARCHAR(5),@date,108)), ':', '')) --(SELECT CONVERT(VARCHAR(5),@DATE,108))
end
GO
/****** Object:  UserDefinedFunction [dbo].[hora]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[hora] (@DATE datetime)
RETURNS varchar(8)
AS
BEGIN
	return (SELECT CONVERT(VARCHAR,@DATE,108))
end
GO
/****** Object:  Trigger [eliminar_Articulos_descuentos]    Script Date: 09/08/2013 14:31:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create TRIGGER [dbo].[eliminar_Articulos_descuentos]
   ON  [dbo].[articulos]
   AFTER DELETE
AS 
BEGIN	
	SET NOCOUNT ON;
	
	BEGIN 
		declare @artId int;
		
		select  @artId = id from deleted
		
		delete from articulos_descuentos where articuloId = @artId
		
	END

END
GO
/****** Object:  StoredProcedure [dbo].[Descuentos_ObtenerArticulosByDescuentoId]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Descuentos_ObtenerArticulosByDescuentoId]
@descId int 
as

select articuloId,descuentoId,nombre
from articulos_descuentos ad left join articulos a on ad.articuloId = a.id 
where ad.descuentoId = @descId
GO
/****** Object:  Trigger [actualizar_Articulos_descuentos]    Script Date: 09/08/2013 14:31:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create TRIGGER [dbo].[actualizar_Articulos_descuentos]
   ON  [dbo].[articulos]
   AFTER update
AS 
BEGIN	
	SET NOCOUNT ON;
	
	BEGIN 
		declare @artId int;
		declare @artIdAnt int;
		
		select  @artId = id from inserted
		select  @artIdAnt = id from deleted
		
		update articulos_descuentos set articuloId =@artId where articuloId = @artIdAnt
		
	END

END
GO
/****** Object:  Table [dbo].[articulosConsumidos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articulosConsumidos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[articuloId] [smallint] NOT NULL,
	[cantidad] [smallint] NOT NULL,
	[cierreId] [int] NOT NULL,
	[turnoId] [int] NOT NULL,
 CONSTRAINT [PK_cierreConsumos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[articulosConsumidos] ON
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (51, 6, 8, 71, 244)
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (52, 7, 15, 71, 244)
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (53, 8, 3, 71, 246)
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (54, 13, 5, 71, 246)
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (55, 10, 3, 71, 247)
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (56, 5, 4, 71, 244)
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (57, 113, 5, 71, 244)
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (58, 114, 1, 71, 244)
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (59, 5, 4, 71, 248)
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (60, 9, 1, 71, 248)
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (61, 6, 1, 71, 248)
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (62, 10, 2, 71, 244)
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (63, 14, 3, 71, 244)
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (64, 5, 1, 71, 251)
INSERT [dbo].[articulosConsumidos] ([id], [articuloId], [cantidad], [cierreId], [turnoId]) VALUES (65, 8, 1, 71, 251)
SET IDENTITY_INSERT [dbo].[articulosConsumidos] OFF
/****** Object:  Table [dbo].[alarmas]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[alarmas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mensaje] [varchar](50) NOT NULL,
 CONSTRAINT [PK_alarmas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[alarmas] ON
INSERT [dbo].[alarmas] ([id], [mensaje]) VALUES (1, N'Despertador 1')
INSERT [dbo].[alarmas] ([id], [mensaje]) VALUES (2, N'Fin de Turno')
INSERT [dbo].[alarmas] ([id], [mensaje]) VALUES (3, N'Desayuno')
SET IDENTITY_INSERT [dbo].[alarmas] OFF
/****** Object:  Table [dbo].[avisos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[avisos](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[mensaje] [varchar](30) NULL,
 CONSTRAINT [PK_mensajesAlarma] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[avisos] ON
INSERT [dbo].[avisos] ([id], [mensaje]) VALUES (1, N'Rojo')
INSERT [dbo].[avisos] ([id], [mensaje]) VALUES (2, N'Verde')
INSERT [dbo].[avisos] ([id], [mensaje]) VALUES (3, N'Amarillo')
INSERT [dbo].[avisos] ([id], [mensaje]) VALUES (4, N'Azul')
INSERT [dbo].[avisos] ([id], [mensaje]) VALUES (5, N'Negro')
SET IDENTITY_INSERT [dbo].[avisos] OFF
/****** Object:  Table [dbo].[socios]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[socios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nroSocio] [int] NOT NULL,
	[puntos] [int] NOT NULL,
	[fechaAltaSocio] [datetime] NOT NULL,
	[fechaVencimientoPuntaje] [datetime] NULL,
	[cantidadVisitas] [smallint] NULL,
	[nombre] [varchar](20) NULL,
	[apellido] [varchar](20) NULL,
	[mail] [varchar](30) NULL,
	[edad] [tinyint] NULL,
	[sexo] [nchar](1) NULL,
 CONSTRAINT [PK_socios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_socios] UNIQUE NONCLUSTERED 
(
	[nroSocio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[socios] ON
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (3, 654321, 0, CAST(0x0000A14B01183C6E AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (4, 222222, 655, CAST(0x0000A14B0144B5FB AS DateTime), CAST(0x0000A2DD00000000 AS DateTime), 8, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (5, 444555, 0, CAST(0x0000A14D01507A28 AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (6, 555555, 0, CAST(0x0000A14D0150BFD0 AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (7, 55555, 102, CAST(0x0000A14D01521314 AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (8, 767676, 0, CAST(0x0000A14D0152213D AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (9, 444333, 0, CAST(0x0000A14D01565267 AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (10, 1234, 0, CAST(0x0000A1550165C552 AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (11, 123456, 0, CAST(0x0000A18000290F73 AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (12, 333333, 0, CAST(0x0000A180016BAB0E AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (13, 444444, 4079, CAST(0x0000A18E0011E8A1 AS DateTime), CAST(0x0000A2DA00000000 AS DateTime), 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (14, 2222, 0, CAST(0x0000A18E017B8D6D AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (15, 666666, 0, CAST(0x0000A18E0188254C AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (16, 663, 0, CAST(0x0000A18F001199D1 AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (20, 2211, 0, CAST(0x0000A18F001199D1 AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (28, 1, 20, CAST(0x0000A1DF00329E7D AS DateTime), NULL, 0, N'Javi', N'Nafasa lapi', N'nada@email.com', 20, N'M')
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (29, 9, 0, CAST(0x0000A1F4016B2367 AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (30, 7878, 80, CAST(0x0000A1FA00038A67 AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (31, 22222, 0, CAST(0x0000A1FB005A224A AS DateTime), NULL, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[socios] ([id], [nroSocio], [puntos], [fechaAltaSocio], [fechaVencimientoPuntaje], [cantidadVisitas], [nombre], [apellido], [mail], [edad], [sexo]) VALUES (32, 888888, 112, CAST(0x0000A1FB0177D2DA AS DateTime), CAST(0x0000A2AF00000000 AS DateTime), 1, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[socios] OFF
/****** Object:  Table [dbo].[seniales]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seniales](
	[id] [int] NOT NULL,
	[nroHab] [int] NULL,
	[bar] [bit] NULL,
	[luz] [bit] NULL,
	[aac] [bit] NULL,
 CONSTRAINT [PK_señales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[seniales] ([id], [nroHab], [bar], [luz], [aac]) VALUES (1, 101, 0, 0, 0)
INSERT [dbo].[seniales] ([id], [nroHab], [bar], [luz], [aac]) VALUES (2, 102, 1, 1, 0)
INSERT [dbo].[seniales] ([id], [nroHab], [bar], [luz], [aac]) VALUES (3, 103, 1, 0, 1)
INSERT [dbo].[seniales] ([id], [nroHab], [bar], [luz], [aac]) VALUES (4, 107, 0, 1, 1)
INSERT [dbo].[seniales] ([id], [nroHab], [bar], [luz], [aac]) VALUES (5, 108, 0, 0, 1)
INSERT [dbo].[seniales] ([id], [nroHab], [bar], [luz], [aac]) VALUES (6, 109, 1, 0, 0)
INSERT [dbo].[seniales] ([id], [nroHab], [bar], [luz], [aac]) VALUES (7, 112, 1, 0, 0)
/****** Object:  Table [dbo].[ropaConsumida]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ropaConsumida](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nroHabitacion] [int] NOT NULL,
	[categoriaId] [int] NOT NULL,
	[fundas] [int] NULL,
	[sabanas] [int] NULL,
	[acolchados] [int] NULL,
	[toallas] [int] NULL,
	[toallones] [int] NULL,
	[batas] [int] NULL,
	[cierreId] [int] NULL,
 CONSTRAINT [PK_ropaConsumidaPorCierreCaja] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ropaConsumida] ON
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (1, 102, 5, 2, 1, 1, 2, 2, 2, 53)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (2, 101, 1, 1, 1, 1, 2, 2, 1, 53)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (3, 102, 1, 2, 1, 1, 2, 2, 2, 53)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (4, 101, 5, 1, 1, 1, 2, 2, 1, 53)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (5, 102, 1, 2, 1, 1, 2, 2, 2, 57)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (6, 103, 5, 0, 0, 0, 0, 0, 0, 59)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (7, 107, 1, 1, 0, 0, 0, 0, 0, 59)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (8, 108, 1, 1, 0, 0, 0, 0, 0, 59)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (9, 101, 5, 1, 1, 1, 2, 2, 1, 60)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (10, 101, 1, 1, 1, 1, 2, 2, 1, 60)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (11, 103, 1, 0, 0, 0, 0, 0, 0, 60)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (12, 102, 1, 2, 1, 1, 2, 2, 2, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (13, 116, 1, 1, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (14, 114, 1, 1, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (15, 115, 1, 1, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (16, 101, 1, 1, 1, 1, 2, 2, 1, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (17, 105, 5, 1, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (18, 101, 5, 1, 1, 1, 2, 2, 1, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (19, 1, 1, 0, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (20, 1, 1, 0, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (21, 25, 1, 3, 4, 2, 2, 2, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (22, 1, 1, 0, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (23, 1, 1, 0, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (24, 5, 1, 0, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (25, 8, 1, 8, 8, 8, 8, 8, 8, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (26, 10, 1, 8, 8, 8, 8, 8, 8, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (27, 1, 1, 0, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (28, 5, 1, 0, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (29, 8, 1, 8, 8, 8, 8, 8, 8, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (30, 109, 1, 1, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (31, 25, 1, 3, 4, 2, 2, 2, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (32, 10, 1, 8, 8, 8, 8, 8, 8, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (33, 99, 1, 2, 2, 1, 2, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (34, 114, 1, 1, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (35, 115, 1, 1, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (36, 116, 1, 1, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (37, 110, 1, 1, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (38, 108, 1, 1, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (39, 8, 1, 8, 8, 8, 8, 8, 8, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (40, 106, 1, 1, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (41, 1, 1, 0, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (42, 104, 5, 1, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (43, 8, 1, 8, 8, 8, 8, 8, 8, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (44, 1, 1, 0, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (45, 1, 1, 0, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (46, 1, 1, 0, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (47, 1, 1, 0, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (48, 1, 1, 0, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (49, 1, 1, 0, 0, 0, 0, 0, 0, 61)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (50, 1, 1, 0, 0, 0, 0, 0, 0, 62)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (51, 8, 1, 8, 8, 8, 8, 8, 8, 62)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (52, 107, 1, 1, 0, 0, 0, 0, 0, 62)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (53, 5, 1, 0, 0, 0, 0, 0, 0, 62)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (54, 10, 1, 8, 8, 8, 8, 8, 8, 62)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (55, 114, 1, 1, 0, 0, 0, 0, 0, 62)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (56, 102, 5, 0, 2, 1, 2, 2, 0, 62)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (57, 5, 1, 0, 0, 0, 0, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (58, 8, 1, 8, 8, 8, 8, 8, 8, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (59, 1, 1, 0, 0, 0, 0, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (60, 56, 1, 2, 2, 2, 2, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (61, 5, 1, 0, 0, 0, 0, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (62, 10, 1, 8, 8, 8, 8, 8, 8, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (63, 1, 1, 0, 0, 0, 0, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (64, 5, 1, 0, 0, 0, 0, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (65, 56, 5, 2, 2, 2, 2, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (66, 1, 1, 0, 0, 0, 0, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (67, 5, 1, 0, 0, 0, 0, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (68, 8, 1, 8, 8, 8, 8, 8, 8, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (69, 10, 1, 8, 8, 8, 8, 8, 8, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (70, 56, 1, 2, 2, 2, 2, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (71, 99, 1, 2, 2, 1, 2, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (72, 102, 5, 0, 2, 1, 2, 2, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (73, 1, 1, 0, 0, 0, 0, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (74, 5, 1, 0, 0, 0, 0, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (75, 8, 1, 8, 8, 8, 8, 8, 8, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (76, 10, 1, 8, 8, 8, 8, 8, 8, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (77, 56, 1, 2, 2, 2, 2, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (78, 99, 1, 2, 2, 1, 2, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (79, 8, 1, 8, 8, 8, 8, 8, 8, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (80, 56, 5, 2, 2, 2, 2, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (81, 1, 1, 0, 0, 0, 0, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (82, 1, 1, 0, 0, 0, 0, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (83, 10, 1, 8, 8, 8, 8, 8, 8, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (84, 8, 1, 8, 8, 8, 8, 8, 8, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (85, 10, 1, 8, 8, 8, 8, 8, 8, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (86, 1, 1, 0, 0, 0, 0, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (87, 8, 1, 8, 8, 8, 8, 8, 8, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (88, 5, 1, 0, 0, 0, 0, 0, 0, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (89, 2, 1, 2, 1, 1, 2, 2, 2, 63)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (90, 1, 1, 0, 0, 0, 0, 0, 0, 65)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (91, 1, 1, 0, 0, 0, 0, 0, 0, 66)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (92, 1, 1, 0, 0, 0, 0, 0, 0, 66)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (93, 1, 1, 0, 0, 0, 0, 0, 0, 66)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (94, 1, 1, 0, 0, 0, 0, 0, 0, 66)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (95, 2, 1, 2, 1, 1, 2, 2, 2, 66)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (96, 5, 1, 0, 0, 0, 0, 0, 0, 66)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (97, 8, 1, 8, 8, 8, 8, 8, 8, 66)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (98, 1, 1, 0, 0, 0, 0, 0, 0, 67)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (99, 5, 1, 0, 0, 0, 0, 0, 0, 67)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (100, 10, 1, 8, 8, 8, 8, 8, 8, 67)
GO
print 'Processed 100 total records'
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (101, 107, 1, 1, 0, 0, 0, 0, 0, 67)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (102, 115, 1, 1, 0, 0, 0, 0, 0, 67)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (103, 1, 1, 0, 0, 0, 0, 0, 0, 67)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (104, 2, 1, 2, 1, 1, 2, 2, 2, 71)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (105, 2, 1, 2, 1, 1, 2, 2, 2, 71)
INSERT [dbo].[ropaConsumida] ([id], [nroHabitacion], [categoriaId], [fundas], [sabanas], [acolchados], [toallas], [toallones], [batas], [cierreId]) VALUES (106, 5, 1, 0, 0, 0, 0, 0, 0, 71)
SET IDENTITY_INSERT [dbo].[ropaConsumida] OFF
/****** Object:  Table [dbo].[ropaHotel]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ropaHotel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[stockInicial] [smallint] NOT NULL,
	[stockActual]  AS (([stockInicial]-[roto])-[saldoFinal]),
	[saldoFinal] [smallint] NOT NULL,
	[roto] [smallint] NOT NULL,
 CONSTRAINT [PK_ropaHotel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ropaHotel] ON
INSERT [dbo].[ropaHotel] ([id], [descripcion], [stockInicial], [saldoFinal], [roto]) VALUES (1, N'Toallas', 100, 15, 10)
INSERT [dbo].[ropaHotel] ([id], [descripcion], [stockInicial], [saldoFinal], [roto]) VALUES (2, N'Toallones', 100, 15, 0)
INSERT [dbo].[ropaHotel] ([id], [descripcion], [stockInicial], [saldoFinal], [roto]) VALUES (3, N'Sabanas', 100, 25, 0)
INSERT [dbo].[ropaHotel] ([id], [descripcion], [stockInicial], [saldoFinal], [roto]) VALUES (4, N'Frazadas', 100, 13, 0)
INSERT [dbo].[ropaHotel] ([id], [descripcion], [stockInicial], [saldoFinal], [roto]) VALUES (5, N'Batas', 100, 19, 0)
SET IDENTITY_INSERT [dbo].[ropaHotel] OFF
/****** Object:  Table [dbo].[parametros]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[parametros](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](25) NULL,
	[val1] [int] NULL,
	[val1_string] [varchar](250) NULL,
 CONSTRAINT [PK_parametros] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[parametros] ON
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (1, N'ticketCocina', 219, NULL)
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (2, N'planillaCaja', 135, NULL)
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (3, N'ImpresoraCaja', NULL, N'doPDF v6')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (4, N'ImpresoraCocina', NULL, N'doPDF v6')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (5, N'ImpresoraTickets', NULL, N'doPDF v6')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (6, N'portSenialIn', NULL, N'COM8')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (7, N'nombreHotel', NULL, N'Javito')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (8, N'nroHotelCodBarras', 66, N'')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (9, N'cantHabitaciones', 0, N'')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (10, N'emisionFactura', 1, NULL)
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (11, N'emisionPedidos', NULL, N'No')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (12, N'mostrarVisualEXE', 1, NULL)
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (13, N'emisionGastos', 1, NULL)
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (14, N'eliminarRegistros', 1, NULL)
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (15, N'stockCierreCaja', NULL, N'S')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (16, N'consumoRopaCierre', 1, NULL)
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (17, N'portSenialOut', NULL, N'COM1')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (18, N'loggin', 1, NULL)
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (19, N'senialOcupado', NULL, N'1')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (20, N'modSenializacion', NULL, N'INTER')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (21, N'ordenListado', NULL, N'NroHabitacion')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (22, N'minFinTurnoMayor100', 15, N'')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (23, N'minFinTurnoMenor100', 10, N'')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (24, N'bytes', 64, N'')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (25, N'claveAcceso', NULL, N'12345678')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (26, N'placaOutter', 1, NULL)
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (27, N'eventosCierre', 1, NULL)
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (28, N'totalTurnosCerrados', 3, NULL)
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (29, N'redondeo', NULL, N'4,0')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (30, N'coefPuntos', NULL, N'0,5')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (31, N'haySenializacion', 0, NULL)
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (32, N'ticketLavadero', 25, NULL)
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (33, N'directorioAudio', NULL, N'C:\Users\javier\Documents\Visual Studio 2008\Projects\HotelApp\Hoteles\Avisos')
INSERT [dbo].[parametros] ([id], [nombre], [val1], [val1_string]) VALUES (34, N'emisionTicketAsignar', 0, NULL)
SET IDENTITY_INSERT [dbo].[parametros] OFF
/****** Object:  Table [dbo].[opcionesCambioEstado]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[opcionesCambioEstado](
	[id] [int] NOT NULL,
	[Opciones] [varchar](20) NOT NULL,
 CONSTRAINT [PK_opcionesCambioEstado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[opcionesCambioEstado] ([id], [Opciones]) VALUES (1, N'Cambiar Estado')
/****** Object:  Table [dbo].[OpcionesAsignarHabitacion]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OpcionesAsignarHabitacion](
	[id] [int] NOT NULL,
	[Detalles del Turno] [varchar](50) NULL,
 CONSTRAINT [PK_OpcionesAsignarHabitacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[OpcionesAsignarHabitacion] ([id], [Detalles del Turno]) VALUES (1, N'Habitación Nro: ')
INSERT [dbo].[OpcionesAsignarHabitacion] ([id], [Detalles del Turno]) VALUES (2, N'Categoria:           ')
INSERT [dbo].[OpcionesAsignarHabitacion] ([id], [Detalles del Turno]) VALUES (3, N'Promoción:         ')
INSERT [dbo].[OpcionesAsignarHabitacion] ([id], [Detalles del Turno]) VALUES (4, N'Socio Nro:           ')
INSERT [dbo].[OpcionesAsignarHabitacion] ([id], [Detalles del Turno]) VALUES (5, N'Puntos Act.:         ')
INSERT [dbo].[OpcionesAsignarHabitacion] ([id], [Detalles del Turno]) VALUES (6, N'Pernocte:             ')
INSERT [dbo].[OpcionesAsignarHabitacion] ([id], [Detalles del Turno]) VALUES (7, N'Medio de Pago:  ')
INSERT [dbo].[OpcionesAsignarHabitacion] ([id], [Detalles del Turno]) VALUES (8, N'Imp.Adelantado:')
/****** Object:  Table [dbo].[mucamas]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mucamas](
	[id] [int] NOT NULL,
	[nombre] [varchar](20) NULL,
	[apellido] [varchar](20) NULL,
 CONSTRAINT [PK_mucamas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[mucamas] ([id], [nombre], [apellido]) VALUES (1, N'Juana', N'Elguera')
INSERT [dbo].[mucamas] ([id], [nombre], [apellido]) VALUES (2, N'Rosa', N'Brillera')
INSERT [dbo].[mucamas] ([id], [nombre], [apellido]) VALUES (3, N'Elena', N'Britani')
INSERT [dbo].[mucamas] ([id], [nombre], [apellido]) VALUES (4, N'Celeste', N'Chocha')
INSERT [dbo].[mucamas] ([id], [nombre], [apellido]) VALUES (5, N'asd', N'asd')
/****** Object:  Table [dbo].[menues]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[menues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[precio] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_menues] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[menues] ON
INSERT [dbo].[menues] ([id], [nombre], [precio]) VALUES (1, N'Desayuno Simple', CAST(0.00 AS Decimal(6, 2)))
SET IDENTITY_INSERT [dbo].[menues] OFF
/****** Object:  Table [dbo].[mediosDePago]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mediosDePago](
	[id] [tinyint] NOT NULL,
	[nombre] [varchar](20) NULL,
 CONSTRAINT [PK_mediosDePago] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[mediosDePago] ([id], [nombre]) VALUES (0, N'Efectivo')
INSERT [dbo].[mediosDePago] ([id], [nombre]) VALUES (1, N'Visa Credito')
INSERT [dbo].[mediosDePago] ([id], [nombre]) VALUES (2, N'Visa Debito')
INSERT [dbo].[mediosDePago] ([id], [nombre]) VALUES (3, N'Mastercard2')
INSERT [dbo].[mediosDePago] ([id], [nombre]) VALUES (4, N'Naranja')
INSERT [dbo].[mediosDePago] ([id], [nombre]) VALUES (5, N'Dinners Club3')
INSERT [dbo].[mediosDePago] ([id], [nombre]) VALUES (6, N'Puntos')
/****** Object:  Table [dbo].[turnos_avisos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[turnos_avisos](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[turnoId] [int] NOT NULL,
	[avisoId] [int] NOT NULL,
 CONSTRAINT [PK_turnos_avisos2] PRIMARY KEY CLUSTERED 
(
	[turnoId] ASC,
	[avisoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[turnos_alarmas]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[turnos_alarmas](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[turnoId] [int] NOT NULL,
	[alarmaId] [int] NOT NULL,
	[hora] [smallint] NOT NULL,
 CONSTRAINT [PK_turnos_avisos] PRIMARY KEY CLUSTERED 
(
	[turnoId] ASC,
	[alarmaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[turnos_alarmas] ON
INSERT [dbo].[turnos_alarmas] ([id], [turnoId], [alarmaId], [hora]) VALUES (385, 248, 2, 2259)
INSERT [dbo].[turnos_alarmas] ([id], [turnoId], [alarmaId], [hora]) VALUES (386, 249, 2, 1245)
INSERT [dbo].[turnos_alarmas] ([id], [turnoId], [alarmaId], [hora]) VALUES (388, 251, 2, 1245)
SET IDENTITY_INSERT [dbo].[turnos_alarmas] OFF
/****** Object:  Table [dbo].[turnosCerrados]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[turnosCerrados](
	[id] [int] NOT NULL,
	[catId] [tinyint] NULL,
	[impHabitacion] [decimal](8, 2) NOT NULL,
	[impArticulos] [decimal](8, 2) NOT NULL,
	[impExtras] [decimal](8, 2) NOT NULL,
	[descuentoAlCierre] [decimal](6, 2) NULL,
	[efectivo] [decimal](8, 2) NULL,
	[tarjeta] [decimal](8, 2) NULL,
	[tipoTarjeta] [tinyint] NULL,
	[desde] [datetime] NOT NULL,
	[hasta] [datetime] NULL,
	[nroHabitacion] [smallint] NOT NULL,
	[aliasCat] [nchar](4) NOT NULL,
	[horaCierre] [datetime] NULL,
	[socioId] [int] NULL,
	[descuentoId] [int] NULL,
	[puntos] [smallint] NULL,
	[conserjeId] [smallint] NULL,
	[contabilizado] [bit] NOT NULL,
	[cancelado] [bit] NULL,
	[pernocte] [bit] NOT NULL,
	[descuentos] [decimal](8, 2) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (245, 1, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(400.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A228017F10B0 AS DateTime), CAST(0x0000A22900148430 AS DateTime), 2, N'COM ', CAST(0x0000A22801847888 AS DateTime), NULL, NULL, NULL, 1, 0, 0, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (220, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(14.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A2220172571A AS DateTime), CAST(0x0000A2230007CA9A AS DateTime), 1, N'COM ', CAST(0x0000A2220172B1EC AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (99, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1B2003E3A6D AS DateTime), CAST(0x0000A1B2005F2FED AS DateTime), 105, N'COM ', CAST(0x0000A1B700166CDE AS DateTime), NULL, NULL, NULL, 1, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (102, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1B7001CABA5 AS DateTime), CAST(0x0000A1B700D63BC0 AS DateTime), 105, N'COM ', CAST(0x0000A1B7001CD361 AS DateTime), NULL, NULL, NULL, 1, 0, 1, 1, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (61, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(50.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A19B016580C9 AS DateTime), CAST(0x0000A19B01867649 AS DateTime), 102, N'COM ', CAST(0x0000A19D013ACAA2 AS DateTime), 4, 6, 10, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (68, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A19D013AD536 AS DateTime), CAST(0x0000A19D015BCAB6 AS DateTime), 106, N'COM ', CAST(0x0000A19D013ADF59 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (69, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(500.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A19D013DF7EF AS DateTime), CAST(0x0000A19D015EED6F AS DateTime), 106, N'COM ', CAST(0x0000A19D013DFF16 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (72, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(100.00 AS Decimal(8, 2)), 3, CAST(0x0000A19F0022D7B2 AS DateTime), CAST(0x0000A19F0043CD32 AS DateTime), 107, N'COM ', CAST(0x0000A1A60182825F AS DateTime), NULL, NULL, NULL, 1, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (246, 1, CAST(160.00 AS Decimal(8, 2)), CAST(92.00 AS Decimal(8, 2)), CAST(276.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(500.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A228018A4E3E AS DateTime), CAST(0x0000A229001FC1BE AS DateTime), 2, N'COM ', CAST(0x0000A2290000BCD2 AS DateTime), 4, 6, 14, 1, 0, 0, 0, CAST(14.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (250, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22E0145EBE1 AS DateTime), CAST(0x0000A22E0166E161 AS DateTime), 5, N'COM ', CAST(0x0000A22E0145FF50 AS DateTime), NULL, NULL, NULL, 1, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (223, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A223014DEE3A AS DateTime), CAST(0x0000A22400D63BC0 AS DateTime), 1, N'COM ', CAST(0x0000A224002A75DF AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (224, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A223014DF794 AS DateTime), CAST(0x0000A22400D63BC0 AS DateTime), 2, N'COM ', CAST(0x0000A224002A779D AS DateTime), NULL, NULL, NULL, 2, 0, 1, 1, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (242, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22601638F96 AS DateTime), CAST(0x0000A22601848516 AS DateTime), 1, N'COM ', CAST(0x0000A226016398AE AS DateTime), NULL, NULL, NULL, 1, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (236, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(120.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(320.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A224011D4C99 AS DateTime), CAST(0x0000A224013E4219 AS DateTime), 1, N'COM ', CAST(0x0000A22401352685 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (107, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1B7013CBEA2 AS DateTime), CAST(0x0000A1B7015DB422 AS DateTime), 116, N'COM ', CAST(0x0000A1B800DABF87 AS DateTime), NULL, NULL, NULL, 1, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (128, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1E60137581E AS DateTime), CAST(0x0000A1E700D63BC0 AS DateTime), 25, N'COM ', CAST(0x0000A1E60142B3DB AS DateTime), NULL, 5, NULL, 2, 0, 1, 1, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (132, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1E701501F98 AS DateTime), CAST(0x0000A1E701711518 AS DateTime), 10, N'COM ', CAST(0x0000A1E70159D158 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (135, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(31.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1E8017E29FA AS DateTime), CAST(0x0000A1E900139D7A AS DateTime), 104, N'COM ', CAST(0x0000A1E8017EEA3A AS DateTime), NULL, 8, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (137, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(25.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1EA0010FEFF AS DateTime), CAST(0x0000A1EA0031F47F AS DateTime), 1, N'COM ', CAST(0x0000A1EA015B3C9F AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (138, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1EA00113488 AS DateTime), CAST(0x0000A1EA00322A08 AS DateTime), 5, N'COM ', CAST(0x0000A1EA015B44CA AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (139, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(21.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1EA0154092F AS DateTime), CAST(0x0000A1EA0174FEAF AS DateTime), 8, N'COM ', CAST(0x0000A1EA015DDC27 AS DateTime), NULL, 5, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (239, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A2240138BF27 AS DateTime), CAST(0x0000A22601666DD0 AS DateTime), 2, N'COM ', CAST(0x0000A22601633EAA AS DateTime), NULL, NULL, NULL, 1, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (109, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(210.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1C0015CFC48 AS DateTime), CAST(0x0000A1C100D63BC0 AS DateTime), 104, N'COM ', CAST(0x0000A1E7014A301C AS DateTime), NULL, NULL, NULL, 2, 0, 1, 1, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (149, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1F8000FB200 AS DateTime), CAST(0x0000A1F800D63BC0 AS DateTime), 102, N'COM ', CAST(0x0000A1F8004902EC AS DateTime), NULL, NULL, NULL, 2, 0, 1, 1, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (142, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(37.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1EE0155B1AF AS DateTime), CAST(0x0000A1F8004A2860 AS DateTime), 5, N'COM ', CAST(0x0000A1F80049198C AS DateTime), NULL, NULL, NULL, 2, 0, 1, 1, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (151, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1F80033B399 AS DateTime), CAST(0x0000A1F80054A919 AS DateTime), 103, N'COM ', CAST(0x0000A1F800492327 AS DateTime), NULL, 2, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (141, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(98.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1EE01509780 AS DateTime), CAST(0x0000A1F8004A2860 AS DateTime), 1, N'COM ', CAST(0x0000A1F800492927 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (150, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1F8002B334C AS DateTime), CAST(0x0000A1F8004C28CC AS DateTime), 104, N'COM ', CAST(0x0000A1F800493248 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (144, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A1F40119EBAB AS DateTime), CAST(0x0000A1F8004A2860 AS DateTime), 56, N'COM ', CAST(0x0000A1F800493DB4 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (200, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22001525CED AS DateTime), CAST(0x0000A22100D63BC0 AS DateTime), 8, N'COM ', CAST(0x0000A221008FBF99 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 1, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (201, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A220015266E5 AS DateTime), CAST(0x0000A22100D63BC0 AS DateTime), 10, N'COM ', CAST(0x0000A221008FC3E6 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (203, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A2200155E5C3 AS DateTime), CAST(0x0000A22100D63BC0 AS DateTime), 8, N'COM ', CAST(0x0000A22100928FA6 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (204, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A2200155F350 AS DateTime), CAST(0x0000A22100D63BC0 AS DateTime), 10, N'COM ', CAST(0x0000A221009291A5 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 1, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (206, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A220016A80A0 AS DateTime), CAST(0x0000A2210008307C AS DateTime), 10, N'COM ', CAST(0x0000A220011CC86D AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (207, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A220011D1430 AS DateTime), CAST(0x0000A22001464690 AS DateTime), 10, N'COM ', CAST(0x0000A2200122E9FE AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (208, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22001230078 AS DateTime), CAST(0x0000A22001588F08 AS DateTime), 10, N'COM ', CAST(0x0000A22001251147 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (209, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A220012515F2 AS DateTime), CAST(0x0000A220014E482C AS DateTime), 10, N'COM ', CAST(0x0000A220012A2DC4 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (210, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A220012A516D AS DateTime), CAST(0x0000A220014F64F0 AS DateTime), 10, N'COM ', CAST(0x0000A220014C6D1A AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (211, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A220014C7B4C AS DateTime), CAST(0x0000A2200175AD54 AS DateTime), 10, N'COM ', CAST(0x0000A2200130E198 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (212, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A2200130E917 AS DateTime), CAST(0x0000A220015A1B20 AS DateTime), 10, N'COM ', CAST(0x0000A2200157D097 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (213, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A220012BEDA8 AS DateTime), CAST(0x0000A220018344A0 AS DateTime), 10, N'COM ', CAST(0x0000A220011D87D7 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (214, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A220011D8D19 AS DateTime), CAST(0x0000A2200146BF44 AS DateTime), 10, N'COM ', CAST(0x0000A2200145E893 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (215, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22001250883 AS DateTime), CAST(0x0000A221000AFC80 AS DateTime), 10, N'COM ', CAST(0x0000A221000A4160 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (217, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22100418571 AS DateTime), CAST(0x0000A22100DA5A70 AS DateTime), 1, N'COM ', CAST(0x0000A22100D9FDC8 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (225, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22301533B43 AS DateTime), CAST(0x0000A22400D63BC0 AS DateTime), 1, N'COM ', CAST(0x0000A224003478BA AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (226, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22301534FC8 AS DateTime), CAST(0x0000A22400D63BC0 AS DateTime), 2, N'COM ', CAST(0x0000A22400347B1D AS DateTime), NULL, NULL, NULL, 2, 0, 1, 1, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (227, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22301550133 AS DateTime), CAST(0x0000A22400D63BC0 AS DateTime), 1, N'COM ', CAST(0x0000A224004375ED AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (228, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22301551E80 AS DateTime), CAST(0x0000A22400D63BC0 AS DateTime), 2, N'COM ', CAST(0x0000A22400437A59 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 1, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (229, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A222015831F5 AS DateTime), CAST(0x0000A22300D63BC0 AS DateTime), 1, N'COM ', CAST(0x0000A221015FE865 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (230, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22201583CB6 AS DateTime), CAST(0x0000A22300D63BC0 AS DateTime), 2, N'COM ', CAST(0x0000A221015FE9C0 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 1, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (202, NULL, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A221008FCB7A AS DateTime), CAST(0x0000A22100C13BBA AS DateTime), 8, N'COM ', CAST(0x0000A221008FF9A3 AS DateTime), NULL, NULL, NULL, 2, 0, 1, 0, CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnosCerrados] ([id], [catId], [impHabitacion], [impArticulos], [impExtras], [descuentoAlCierre], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [horaCierre], [socioId], [descuentoId], [puntos], [conserjeId], [contabilizado], [cancelado], [pernocte], [descuentos]) VALUES (247, 1, CAST(160.00 AS Decimal(8, 2)), CAST(42.00 AS Decimal(8, 2)), CAST(254.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(400.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22900021B7C AS DateTime), CAST(0x0000A229002310FC AS DateTime), 5, N'COM ', CAST(0x0000A2290002DC2E AS DateTime), 4, 6, 56, 1, 0, 0, 0, CAST(56.00 AS Decimal(8, 2)))
/****** Object:  Table [dbo].[tiposCuentasGastos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tiposCuentasGastos](
	[idTipoCuenta] [int] NOT NULL,
	[nombre] [varchar](20) NULL,
 CONSTRAINT [PK_tiposCuentasGastos] PRIMARY KEY CLUSTERED 
(
	[idTipoCuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tiposCuentasGastos] ([idTipoCuenta], [nombre]) VALUES (1, N'Gastos')
INSERT [dbo].[tiposCuentasGastos] ([idTipoCuenta], [nombre]) VALUES (2, N'Servicios')
INSERT [dbo].[tiposCuentasGastos] ([idTipoCuenta], [nombre]) VALUES (3, N'Adelantos')
INSERT [dbo].[tiposCuentasGastos] ([idTipoCuenta], [nombre]) VALUES (4, N'Lavandería')
/****** Object:  Table [dbo].[tipoDescuentos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoDescuentos](
	[tipoDescuentoId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[pathImagen] [nvarchar](100) NULL,
 CONSTRAINT [PK_tipoDescuentos] PRIMARY KEY CLUSTERED 
(
	[tipoDescuentoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tipoDescuentos] ON
INSERT [dbo].[tipoDescuentos] ([tipoDescuentoId], [nombre], [pathImagen]) VALUES (1, N'Descuento en el Turno', NULL)
INSERT [dbo].[tipoDescuentos] ([tipoDescuentoId], [nombre], [pathImagen]) VALUES (2, N'Consumo de Bar', NULL)
INSERT [dbo].[tipoDescuentos] ([tipoDescuentoId], [nombre], [pathImagen]) VALUES (3, N'Socios', NULL)
INSERT [dbo].[tipoDescuentos] ([tipoDescuentoId], [nombre], [pathImagen]) VALUES (4, N'Turno Express', NULL)
SET IDENTITY_INSERT [dbo].[tipoDescuentos] OFF
/****** Object:  Table [dbo].[tarifas]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tarifas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[catId] [tinyint] NOT NULL,
	[desde] [datetime] NOT NULL,
	[hasta] [datetime] NULL,
	[dia] [tinyint] NOT NULL,
	[duracion] [int] NOT NULL,
	[precio] [decimal](6, 2) NOT NULL,
	[precioMinuto]  AS (CONVERT([decimal](10,2),[precio]/[duracion],(0))),
	[extension] [int] NULL,
	[extensionPrecio] [decimal](6, 2) NULL,
	[tolerancia] [int] NULL,
	[precioTN] [decimal](6, 2) NULL,
	[minAlarma] [smallint] NULL,
	[pernocte] [bit] NOT NULL,
 CONSTRAINT [PK_tarifas_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_tarifas] ON [dbo].[tarifas] 
(
	[catId] ASC,
	[dia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tarifas] ON
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (1, 1, CAST(0x0000A1E40062E080 AS DateTime), CAST(0x0000A1E400D63BC0 AS DateTime), 1, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(160.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (2, 1, CAST(0x0000A11600A4CB80 AS DateTime), NULL, 1, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (4, 1, CAST(0x0000A116011826C0 AS DateTime), NULL, 1, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (5, 1, CAST(0x0000A116018A2270 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 1, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(190.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (6, 1, CAST(0x0000A1160062E080 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 5, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(160.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (7, 1, CAST(0x0000A11600A4CB80 AS DateTime), NULL, 5, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (8, 1, CAST(0x0000A116011826C0 AS DateTime), NULL, 5, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (10, 1, CAST(0x0000A1160020F580 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 6, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(190.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (11, 1, CAST(0x0000A1160062E080 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 6, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(160.00 AS Decimal(6, 2)), NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (12, 1, CAST(0x0000A11600A4CB80 AS DateTime), NULL, 6, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (13, 1, CAST(0x0000A116011826C0 AS DateTime), NULL, 6, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (14, 1, CAST(0x0000A1160041EB00 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 0, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(190.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (15, 1, CAST(0x0000A1160062E080 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 0, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(160.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (16, 1, CAST(0x0000A11600A4CB80 AS DateTime), NULL, 0, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (17, 1, CAST(0x0000A116018A2270 AS DateTime), CAST(0x0000A1A700D63BC0 AS DateTime), 0, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(190.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (18, 1, CAST(0x0000A1160041EB00 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 9, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(190.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (19, 1, CAST(0x0000A1160062E080 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 9, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(160.00 AS Decimal(6, 2)), NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (20, 1, CAST(0x0000A11600A4CB80 AS DateTime), NULL, 9, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (21, 1, CAST(0x0000A1EE011826C0 AS DateTime), CAST(0x0000A1EE00D63BC0 AS DateTime), 9, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(190.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (22, 5, CAST(0x0000A1160062E080 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 1, 90, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (23, 5, CAST(0x0000A116011826C0 AS DateTime), NULL, 1, 60, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (25, 5, CAST(0x0000A116018A2270 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 1, 60, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(150.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (41, 5, CAST(0x0000A1160062E080 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 5, 90, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (42, 5, CAST(0x0000A116011826C0 AS DateTime), NULL, 5, 60, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (43, 5, CAST(0x0000A116016A8C80 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 5, 90, CAST(120.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (44, 1, CAST(0x0000A1160062E080 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 2, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(160.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (45, 1, CAST(0x0000A11600A4CB80 AS DateTime), NULL, 2, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (46, 1, CAST(0x0000A1EF011826C0 AS DateTime), CAST(0x0000A1EF018344A0 AS DateTime), 2, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(180.00 AS Decimal(6, 2)), NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (47, 1, CAST(0x0000A116018A2270 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 2, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(190.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (48, 1, CAST(0x0000A1160062E080 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 3, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(160.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (49, 1, CAST(0x0000A11600A4CB80 AS DateTime), NULL, 3, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (50, 1, CAST(0x0000A116011826C0 AS DateTime), NULL, 3, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (51, 1, CAST(0x0000A116016A8C80 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 3, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(190.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (52, 1, CAST(0x0000A1160062E080 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 4, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(160.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (53, 1, CAST(0x0000A11600A4CB80 AS DateTime), NULL, 4, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (54, 1, CAST(0x0000A116011826C0 AS DateTime), NULL, 4, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (55, 1, CAST(0x0000A116016A8C80 AS DateTime), CAST(0x0000A22200D63BC0 AS DateTime), 4, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(190.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (56, 5, CAST(0x0000A1160062E080 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 0, 90, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (57, 5, CAST(0x0000A116011826C0 AS DateTime), NULL, 0, 60, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (58, 5, CAST(0x0000A116018A2270 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 0, 60, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(150.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (59, 5, CAST(0x0000A1160062E080 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 2, 90, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (60, 5, CAST(0x0000A116011826C0 AS DateTime), NULL, 2, 60, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (61, 5, CAST(0x0000A116016A8C80 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 2, 90, CAST(120.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (62, 5, CAST(0x0000A1160062E080 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 3, 90, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (63, 5, CAST(0x0000A116011826C0 AS DateTime), NULL, 3, 60, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (64, 5, CAST(0x0000A116018A2270 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 3, 60, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(150.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (65, 5, CAST(0x0000A1160062E080 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 4, 90, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (66, 5, CAST(0x0000A116011826C0 AS DateTime), NULL, 4, 60, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (67, 5, CAST(0x0000A222018344A0 AS DateTime), CAST(0x0000A22200D63BC0 AS DateTime), 4, 60, CAST(108.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(150.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (68, 1, CAST(0x0000A1E4006B1DE0 AS DateTime), CAST(0x0000A1E400CDFE60 AS DateTime), 1, 1, CAST(1.00 AS Decimal(6, 2)), 0, CAST(0.00 AS Decimal(6, 2)), 0, CAST(0.00 AS Decimal(6, 2)), NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (69, 5, CAST(0x0000A1E400000000 AS DateTime), CAST(0x0000A1E4018B3BB0 AS DateTime), 5, 30, CAST(900.00 AS Decimal(6, 2)), NULL, NULL, 15, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (71, 5, CAST(0x0000A1E400004650 AS DateTime), CAST(0x0000A1E4000C15C0 AS DateTime), 5, 1, CAST(1.00 AS Decimal(6, 2)), 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (76, 15, CAST(0x0000A1E500B84BB0 AS DateTime), CAST(0x0000A1E500B89200 AS DateTime), 0, 90, CAST(11.00 AS Decimal(6, 2)), 11, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (77, 1, CAST(0x0000A1160041EB00 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 8, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(190.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (78, 1, CAST(0x0000A1160062E080 AS DateTime), CAST(0x0000A11600D63BC0 AS DateTime), 8, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(160.00 AS Decimal(6, 2)), NULL, 1)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (79, 1, CAST(0x0000A11600A4CB80 AS DateTime), NULL, 8, 180, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tarifas] ([id], [catId], [desde], [hasta], [dia], [duracion], [precio], [extension], [extensionPrecio], [tolerancia], [precioTN], [minAlarma], [pernocte]) VALUES (80, 1, CAST(0x0000A116017B0740 AS DateTime), CAST(0x0000A1A700D63BC0 AS DateTime), 8, 120, CAST(160.00 AS Decimal(6, 2)), 15, NULL, NULL, CAST(190.00 AS Decimal(6, 2)), NULL, 1)
SET IDENTITY_INSERT [dbo].[tarifas] OFF
/****** Object:  StoredProcedure [dbo].[Habitacion_calcularPrecioAsignarTurnoNoche]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Habitacion_calcularPrecioAsignarTurnoNoche]	
    @precioTotal decimal(8,2),@precioExtras decimal(8,2),@descuentoId int=null,@puntos int=null
AS
BEGIN TRY
begin transaction asignar
	SET NOCOUNT ON;
		
	declare @deschabitacion decimal(8,2)
	set @deschabitacion = 0
	
	-- Aplicar descuentos de plata --
		if(@descuentoId is not null)
		BEGIN
			if((select 1 from descuentos where id = @descuentoId and descuentoFijo is not null) is not null)
			BEGIN
				set @deschabitacion = (select descuentoFijo from descuentos where id = @descuentoId);
			END
			if((select 1 from descuentos where id = @descuentoId and descuentoPorcentaje is not null) is not null)
			BEGIN
				set @deschabitacion = (@precioTotal + @precioExtras) * ((select descuentoPorcentaje from descuentos where id = @descuentoId)/100.00)
			END
		END
		---------------------------------

		select @precioExtras + @precioTotal as montoTotal,
			   @deschabitacion as descTotal, 
			   isnull(@puntos,0) as descPuntos
	
	
COMMIT TRAN asignar
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage,@errorSeverity,@ERRORSTATE);
	rollback tran asignar
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[socios_registrar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[socios_registrar]	
    @nroSocio int
AS
BEGIN TRY
begin transaction registrar
	SET NOCOUNT ON;

	if((select 1 from socios where nroSocio = @nroSocio) is null)
		insert into socios (nroSocio,fechaAltaSocio) values(@nroSocio,getdate())
	
	select * from socios where nroSocio = @nroSocio
	
COMMIT TRAN registrar
END TRY
BEGIN CATCH
	SELECT 
          ERROR_NUMBER() as ErrorNumber,
          ERROR_MESSAGE() as ErrorMessage;
	rollback tran registrar
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[socios_descontarPuntos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[socios_descontarPuntos]
    @puntos int,@nroSocio int
AS
BEGIN TRY
begin transaction registrar
	SET NOCOUNT ON;

		
	update socios set puntos = puntos - @puntos  where nroSocio = @nroSocio
	
	
COMMIT TRAN registrar
END TRY
BEGIN CATCH
	SELECT 
          ERROR_NUMBER() as ErrorNumber,
          ERROR_MESSAGE() as ErrorMessage;
	rollback tran registrar
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[parametros_obtenerNroTicketLavadero]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[parametros_obtenerNroTicketLavadero]
AS
BEGIN TRY
begin transaction 
	SET NOCOUNT ON;
	
	select val1 from parametros where nombre='ticketLavadero'
	update parametros set val1=val1+1 where nombre='ticketLavadero'	
	
COMMIT TRAN 
END TRY
BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage,@errorSeverity,@ERRORSTATE);
	
	rollback tran 
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[parametros_obtenerNroTicketCocina]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[parametros_obtenerNroTicketCocina]    
AS
BEGIN TRY
begin transaction 
	SET NOCOUNT ON;
	
	select val1 from parametros where nombre='ticketCocina'
	update parametros set val1=val1+1 where nombre='ticketCocina'	
	
COMMIT TRAN 
END TRY
BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage,@errorSeverity,@ERRORSTATE);
	
	rollback tran 
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[parametros_obtenerNroPlanilla]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[parametros_obtenerNroPlanilla]    
AS
BEGIN TRY
begin transaction 
	SET NOCOUNT ON;
	
	select val1 from parametros where nombre='planillaCaja'
	update parametros set val1=val1+1 where nombre='planillaCaja'	
	
COMMIT TRAN 
END TRY
BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage,@errorSeverity,@ERRORSTATE);
	
	rollback tran 
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[ropaHotel_sumar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ropaHotel_sumar]
@nroArt int,@cant int
as

update ropaHotel set stockActual = stockActual+@cant
				 where id = @nroArt
GO
/****** Object:  StoredProcedure [dbo].[ropaHotel_obtenerSaldoAnterior]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ropaHotel_obtenerSaldoAnterior]
as
select id,descripcion,saldoFinal from ropaHotel
GO
/****** Object:  StoredProcedure [dbo].[ropaHotel_listadoRopaHotel]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ropaHotel_listadoRopaHotel]
as
select id,descripcion from ropaHotel
GO
/****** Object:  StoredProcedure [dbo].[ropaHotel_descontar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ropaHotel_descontar]
@nroArt int,@cant int
as

update ropaHotel set stockActual = stockActual-@cant
				 where id = @nroArt
GO
/****** Object:  StoredProcedure [dbo].[ropaHotel_ActualizarSaldoFinal]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ropaHotel_ActualizarSaldoFinal]	
    @id int,@cant int
AS	
	update ropaHotel set saldoFinal = @cant
	where id=@id
GO
/****** Object:  Table [dbo].[cierresCaja]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cierresCaja](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[desde] [datetime] NOT NULL,
	[hasta] [datetime] NULL,
	[totEfectivo] [decimal](8, 2) NULL,
	[totTarjeta] [decimal](8, 2) NULL,
	[conserjeId] [smallint] NOT NULL,
	[efectivoInicial] [decimal](8, 2) NOT NULL,
	[tarjetaInicial] [decimal](8, 2) NOT NULL,
	[cantTA] [smallint] NOT NULL,
	[cantTC] [smallint] NOT NULL,
 CONSTRAINT [PK_cierres] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cierresCaja] ON
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (11, CAST(0x0000A19A017D5608 AS DateTime), CAST(0x0000A19A0183E608 AS DateTime), CAST(-10.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (12, CAST(0x0000A19A0183E608 AS DateTime), CAST(0x0000A19A01847C68 AS DateTime), CAST(-111.00 AS Decimal(8, 2)), CAST(21.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (13, CAST(0x0000A19A01847C68 AS DateTime), CAST(0x0000A19A01856D9C AS DateTime), CAST(-20.00 AS Decimal(8, 2)), CAST(4.00 AS Decimal(8, 2)), 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (14, CAST(0x0000A19A01856D9C AS DateTime), CAST(0x0000A19A0187BEAF AS DateTime), CAST(-10.00 AS Decimal(8, 2)), CAST(23.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (15, CAST(0x0000A19A0187BEAF AS DateTime), CAST(0x0000A19A01880BA1 AS DateTime), CAST(4.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (16, CAST(0x0000A19A01880BA1 AS DateTime), CAST(0x0000A19A0188648F AS DateTime), CAST(100.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (17, CAST(0x0000A19A0188648F AS DateTime), CAST(0x0000A19B000EA64A AS DateTime), CAST(20.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (18, CAST(0x0000A19B000EA64A AS DateTime), CAST(0x0000A19B000EF9E5 AS DateTime), CAST(95.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (19, CAST(0x0000A19B000EF9E5 AS DateTime), CAST(0x0000A19B001108C4 AS DateTime), CAST(23.00 AS Decimal(8, 2)), CAST(50.00 AS Decimal(8, 2)), 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (20, CAST(0x0000A19B001108C4 AS DateTime), CAST(0x0000A19B0011383E AS DateTime), CAST(71.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (21, CAST(0x0000A19B0011383E AS DateTime), CAST(0x0000A19B0011B349 AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (22, CAST(0x0000A19B0011B349 AS DateTime), CAST(0x0000A19B00212315 AS DateTime), CAST(167.00 AS Decimal(8, 2)), CAST(15.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (23, CAST(0x0000A19B00212315 AS DateTime), CAST(0x0000A19B0162EF01 AS DateTime), CAST(-1.85 AS Decimal(8, 2)), CAST(28.00 AS Decimal(8, 2)), 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (24, CAST(0x0000A19B0162EF26 AS DateTime), CAST(0x0000A19B0165CCC7 AS DateTime), CAST(226.54 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (25, CAST(0x0000A19B0165CCCC AS DateTime), CAST(0x0000A19B016B80AD AS DateTime), CAST(50.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(30.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (26, CAST(0x0000A19B016B80AD AS DateTime), CAST(0x0000A19B016D570A AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(25.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (27, CAST(0x0000A19B016D570A AS DateTime), CAST(0x0000A19B016E378B AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(10.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (28, CAST(0x0000A19B016E378B AS DateTime), CAST(0x0000A19B017E9859 AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (29, CAST(0x0000A19B017E9859 AS DateTime), CAST(0x0000A19B01809F55 AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(10.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (30, CAST(0x0000A19B01809F55 AS DateTime), CAST(0x0000A19B0181DD83 AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (31, CAST(0x0000A19B0181DD83 AS DateTime), CAST(0x0000A19B0181EA86 AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (32, CAST(0x0000A19B0181EA86 AS DateTime), CAST(0x0000A19B0182C337 AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (33, CAST(0x0000A19B0182C337 AS DateTime), CAST(0x0000A19B0185B534 AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (34, CAST(0x0000A19B0185B534 AS DateTime), CAST(0x0000A19B0186AA61 AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (35, CAST(0x0000A19B0186AA61 AS DateTime), CAST(0x0000A19B01876CB8 AS DateTime), CAST(394.40 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (36, CAST(0x0000A19B01876CB8 AS DateTime), CAST(0x0000A19B01883F97 AS DateTime), CAST(-144.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(80.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (37, CAST(0x0000A19B01883F97 AS DateTime), CAST(0x0000A19B0188DF0E AS DateTime), CAST(-135.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (38, CAST(0x0000A19B0188DF0E AS DateTime), CAST(0x0000A19D01521FA7 AS DateTime), CAST(100.00 AS Decimal(8, 2)), CAST(574.17 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (39, CAST(0x0000A19D01521FA7 AS DateTime), CAST(0x0000A1A001772511 AS DateTime), CAST(663.11 AS Decimal(8, 2)), CAST(108.44 AS Decimal(8, 2)), 1, CAST(300.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (40, CAST(0x0000A1A001772516 AS DateTime), CAST(0x0000A1A0017A3A30 AS DateTime), CAST(70.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(300.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (41, CAST(0x0000A1A0017A3A30 AS DateTime), CAST(0x0000A1A10172A0F6 AS DateTime), CAST(1152.73 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(263.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (42, CAST(0x0000A1A10172A0F6 AS DateTime), CAST(0x0000A1A101767641 AS DateTime), CAST(109.66 AS Decimal(8, 2)), CAST(150.00 AS Decimal(8, 2)), 2, CAST(250.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (43, CAST(0x0000A1A101767641 AS DateTime), CAST(0x0000A1A601861EEA AS DateTime), CAST(1621.34 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(200.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (44, CAST(0x0000A1A601861EEF AS DateTime), CAST(0x0000A1A70163E88E AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(400.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (45, CAST(0x0000A1A70163E89C AS DateTime), CAST(0x0000A1A70165411D AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(100.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (46, CAST(0x0000A1A70165411D AS DateTime), CAST(0x0000A1A701658CEE AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (47, CAST(0x0000A1A701658CEE AS DateTime), CAST(0x0000A1A70166178B AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (48, CAST(0x0000A1A70166178B AS DateTime), CAST(0x0000A1A701803F67 AS DateTime), CAST(199.10 AS Decimal(8, 2)), CAST(1406.80 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 9, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (49, CAST(0x0000A1A701803F67 AS DateTime), CAST(0x0000A1B70032522B AS DateTime), CAST(583.67 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(200.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 9, 2)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (50, CAST(0x0000A1B70032522B AS DateTime), CAST(0x0000A1B70035AD1E AS DateTime), CAST(108.00 AS Decimal(8, 2)), CAST(160.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 2)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (51, CAST(0x0000A1B70035AD1E AS DateTime), CAST(0x0000A1B7012AAF53 AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(250.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (52, CAST(0x0000A1B7012AAF53 AS DateTime), CAST(0x0000A1B7012DAC31 AS DateTime), CAST(253.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (53, CAST(0x0000A1B7012DAC31 AS DateTime), CAST(0x0000A1BC0180EFF4 AS DateTime), CAST(817.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 8, 10)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (57, CAST(0x0000A1BC0180EFF4 AS DateTime), CAST(0x0000A1BC01815297 AS DateTime), CAST(31.37 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(200.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 1)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (58, CAST(0x0000A1BC01815297 AS DateTime), CAST(0x0000A1BC01816BCA AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (59, CAST(0x0000A1BC01816BCA AS DateTime), CAST(0x0000A1BC0181AEAF AS DateTime), CAST(556.57 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 3)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (60, CAST(0x0000A1BC0181AEAF AS DateTime), CAST(0x0000A1C00009B801 AS DateTime), CAST(428.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(100.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 4, 3)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (61, CAST(0x0000A1C00009B801 AS DateTime), CAST(0x0000A1FB017D6D51 AS DateTime), CAST(14461.70 AS Decimal(8, 2)), CAST(6092.10 AS Decimal(8, 2)), 2, CAST(200.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 41, 38)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (62, CAST(0x0000A1FB017D6D5A AS DateTime), CAST(0x0000A1FE016E490E AS DateTime), CAST(25926.75 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(500.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 8, 7)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (63, CAST(0x0000A1FE016E490E AS DateTime), CAST(0x0000A2220162B225 AS DateTime), CAST(115181.65 AS Decimal(8, 2)), CAST(750.00 AS Decimal(8, 2)), 2, CAST(245.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 29, 33)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (65, CAST(0x0000A2220162B225 AS DateTime), CAST(0x0000A2220168D339 AS DateTime), CAST(174.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(23456.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, 1)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (66, CAST(0x0000A2220168D339 AS DateTime), CAST(0x0000A226015FF674 AS DateTime), CAST(9374.25 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(5000.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 13, 7)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (67, CAST(0x0000A226015FF67E AS DateTime), CAST(0x0000A2280154F0EA AS DateTime), CAST(11847.50 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(2344.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 6)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (68, CAST(0x0000A2280154F0EF AS DateTime), CAST(0x0000A2280155137B AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(125.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (69, CAST(0x0000A2280155137B AS DateTime), CAST(0x0000A2280158E774 AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 1, CAST(4000.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (70, CAST(0x0000A2280158E774 AS DateTime), CAST(0x0000A22801590EB6 AS DateTime), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 2, CAST(10000.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 0, 0)
INSERT [dbo].[cierresCaja] ([id], [desde], [hasta], [totEfectivo], [totTarjeta], [conserjeId], [efectivoInicial], [tarjetaInicial], [cantTA], [cantTC]) VALUES (71, CAST(0x0000A22801590EB6 AS DateTime), NULL, NULL, NULL, 1, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), 7, 3)
SET IDENTITY_INSERT [dbo].[cierresCaja] OFF
/****** Object:  StoredProcedure [dbo].[articulosConsumidos_obtenerTodos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[articulosConsumidos_obtenerTodos]
@stock bit
as
declare @cierreId int;
select @cierreId = id from cierresCaja where hasta is null

select  a.id,a.nombre,
		case when ac.cierreId <> @cierreId  
			 then 0 
			 else isnull(ac.cantidad,0) 
		end as CantConsumida,
		stockRecomendado, 
		a.controlStock,
		a.stockActual 
from articulos a left join (select * from articulosConsumidos where cierreId = @cierreId )ac on a.id = ac.articuloId
where 
--(cierreId = @cierreId or cierreId is null) and
 (a.controlStock = @stock or @stock = 0)
order by a.id
GO
/****** Object:  StoredProcedure [dbo].[articulosConsumidos_obtenerSoloConsumidos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[articulosConsumidos_obtenerSoloConsumidos]
@stock bit
as
declare @cierreId int;
select @cierreId = id from cierresCaja where hasta is null

select a.id,a.nombre,isnull(ac.cantidad,0) as CantConsumida,stockRecomendado, a.controlStock,a.stockActual 
from articulos a 
left join articulosConsumidos ac on a.id = ac.articuloId
where (cierreId = @cierreId)
and (a.controlStock = @stock or @stock = 0)
order by a.id
GO
/****** Object:  Table [dbo].[auditoria]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[auditoria](
	[auditoria_id] [bigint] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[evento] [nvarchar](70) NOT NULL,
	[conserjeId] [smallint] NOT NULL,
 CONSTRAINT [PK_auditoria] PRIMARY KEY CLUSTERED 
(
	[auditoria_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[habitaciones]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[habitaciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nroHabitacion] [smallint] NOT NULL,
	[habilitada] [bit] NOT NULL,
	[categoria] [tinyint] NOT NULL,
	[categoria2] [tinyint] NULL,
	[categoria3] [tinyint] NULL,
	[estado] [char](1) NOT NULL,
	[fundas] [tinyint] NOT NULL,
	[sabanas] [tinyint] NOT NULL,
	[acolchado] [tinyint] NOT NULL,
	[toallas] [tinyint] NOT NULL,
	[toallones] [tinyint] NOT NULL,
	[batas] [tinyint] NOT NULL,
	[posSenializacion] [smallint] NOT NULL,
 CONSTRAINT [PK_habitaciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_habitaciones] UNIQUE NONCLUSTERED 
(
	[nroHabitacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[habitaciones] ON
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (1, 101, 1, 4, 1, 13, N'D', 1, 1, 1, 2, 2, 1, 9)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (2, 102, 1, 4, 5, 1, N'D', 0, 2, 1, 2, 2, 0, 10)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (3, 103, 1, 1, 5, NULL, N'D', 0, 0, 0, 0, 0, 0, 11)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (4, 104, 1, 13, 5, NULL, N'D', 1, 0, 0, 0, 0, 0, 12)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (5, 105, 1, 1, 5, NULL, N'X', 1, 0, 0, 0, 0, 0, 13)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (6, 106, 1, 1, 5, NULL, N'D', 1, 0, 0, 0, 0, 0, 14)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (7, 107, 1, 1, 5, NULL, N'D', 1, 0, 0, 0, 0, 0, 15)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (8, 108, 1, 1, 5, NULL, N'D', 1, 0, 0, 0, 0, 0, 16)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (9, 109, 1, 1, 5, NULL, N'D', 1, 0, 0, 0, 0, 0, 17)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (10, 110, 1, 1, 5, 13, N'D', 1, 0, 0, 0, 0, 0, 18)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (11, 111, 1, 4, NULL, NULL, N'D', 1, 0, 0, 0, 0, 0, 19)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (12, 112, 1, 1, NULL, 4, N'D', 1, 0, 0, 0, 0, 0, 20)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (13, 113, 1, 4, NULL, NULL, N'D', 1, 0, 0, 0, 0, 0, 21)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (14, 114, 1, 1, NULL, NULL, N'D', 1, 0, 0, 0, 0, 0, 22)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (15, 115, 1, 1, NULL, NULL, N'O', 1, 0, 0, 0, 0, 0, 23)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (16, 116, 1, 1, NULL, NULL, N'X', 1, 0, 0, 0, 0, 0, 24)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (17, 117, 0, 1, NULL, NULL, N'D', 0, 0, 0, 0, 0, 0, -1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (18, 118, 0, 1, NULL, NULL, N'D', 0, 0, 0, 0, 0, 0, -1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (19, 119, 0, 1, NULL, NULL, N'D', 0, 0, 0, 0, 0, 0, -1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (20, 120, 0, 1, NULL, NULL, N'O', 0, 0, 0, 0, 0, 0, -1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (21, 121, 0, 1, NULL, NULL, N'D', 0, 0, 0, 0, 0, 0, -1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (22, 122, 0, 1, NULL, NULL, N'D', 0, 0, 0, 0, 0, 0, -1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (23, 123, 0, 1, NULL, NULL, N'A', 0, 0, 0, 0, 0, 0, -1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (24, 124, 0, 1, NULL, NULL, N'D', 0, 0, 0, 0, 0, 0, -1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (25, 125, 0, 1, NULL, NULL, N'D', 0, 0, 0, 0, 0, 0, -1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (26, 126, 0, 1, NULL, NULL, N'D', 0, 0, 0, 0, 0, 0, -1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (27, 127, 0, 1, NULL, NULL, N'D', 0, 0, 0, 0, 0, 0, -1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (28, 128, 0, 1, NULL, NULL, N'D', 0, 0, 0, 0, 0, 0, -1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (29, 129, 0, 1, NULL, NULL, N'D', 0, 0, 0, 0, 0, 0, -1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (30, 130, 0, 1, NULL, NULL, N'X', 0, 0, 0, 0, 0, 0, -1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (50, 5, 1, 1, NULL, NULL, N'O', 0, 0, 0, 0, 0, 0, 3)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (51, 1, 1, 1, 5, NULL, N'O', 0, 0, 0, 0, 0, 0, 1)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (52, 8, 1, 1, NULL, NULL, N'D', 8, 8, 8, 8, 8, 8, 4)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (53, 10, 1, 1, NULL, NULL, N'D', 8, 8, 8, 8, 8, 8, 5)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (54, 25, 1, 1, 5, NULL, N'X', 3, 4, 2, 2, 2, 0, 6)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (55, 99, 1, 1, 5, NULL, N'D', 2, 2, 1, 2, 0, 0, 8)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (56, 56, 1, 1, 5, NULL, N'D', 2, 2, 2, 2, 0, 0, 7)
INSERT [dbo].[habitaciones] ([id], [nroHabitacion], [habilitada], [categoria], [categoria2], [categoria3], [estado], [fundas], [sabanas], [acolchado], [toallas], [toallones], [batas], [posSenializacion]) VALUES (57, 2, 1, 1, NULL, NULL, N'O', 2, 1, 1, 2, 2, 2, 2)
SET IDENTITY_INSERT [dbo].[habitaciones] OFF
/****** Object:  StoredProcedure [dbo].[Descuentos_getAll]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Descuentos_getAll]
--@nroHab int    
AS
BEGIN
	SET NOCOUNT ON;
	select * from descuentos	
end
GO
/****** Object:  Table [dbo].[feriados]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[feriados](
	[mes] [tinyint] NOT NULL,
	[dia] [tinyint] NOT NULL,
	[seComportaComo] [tinyint] NOT NULL,
 CONSTRAINT [PK_feriados] PRIMARY KEY CLUSTERED 
(
	[mes] ASC,
	[dia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_feriados] UNIQUE NONCLUSTERED 
(
	[mes] ASC,
	[dia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[feriados] ([mes], [dia], [seComportaComo]) VALUES (4, 29, 5)
INSERT [dbo].[feriados] ([mes], [dia], [seComportaComo]) VALUES (4, 30, 9)
INSERT [dbo].[feriados] ([mes], [dia], [seComportaComo]) VALUES (5, 1, 8)
INSERT [dbo].[feriados] ([mes], [dia], [seComportaComo]) VALUES (5, 25, 8)
INSERT [dbo].[feriados] ([mes], [dia], [seComportaComo]) VALUES (6, 19, 8)
INSERT [dbo].[feriados] ([mes], [dia], [seComportaComo]) VALUES (6, 20, 8)
INSERT [dbo].[feriados] ([mes], [dia], [seComportaComo]) VALUES (6, 21, 8)
INSERT [dbo].[feriados] ([mes], [dia], [seComportaComo]) VALUES (7, 1, 9)
INSERT [dbo].[feriados] ([mes], [dia], [seComportaComo]) VALUES (8, 16, 8)
INSERT [dbo].[feriados] ([mes], [dia], [seComportaComo]) VALUES (8, 19, 8)
INSERT [dbo].[feriados] ([mes], [dia], [seComportaComo]) VALUES (8, 23, 8)
INSERT [dbo].[feriados] ([mes], [dia], [seComportaComo]) VALUES (12, 24, 9)
INSERT [dbo].[feriados] ([mes], [dia], [seComportaComo]) VALUES (12, 25, 8)
/****** Object:  Table [dbo].[cuentasGastos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentasGastos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](20) NOT NULL,
	[idTipoCuenta] [int] NOT NULL,
	[impresion] [bit] NOT NULL,
 CONSTRAINT [PK_cuentasGastos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cuentasGastos] ON
INSERT [dbo].[cuentasGastos] ([id], [nombre], [idTipoCuenta], [impresion]) VALUES (1, N'Confiteria/Panaderia', 1, 1)
INSERT [dbo].[cuentasGastos] ([id], [nombre], [idTipoCuenta], [impresion]) VALUES (2, N'Verduleria', 1, 1)
INSERT [dbo].[cuentasGastos] ([id], [nombre], [idTipoCuenta], [impresion]) VALUES (3, N'Almacen/Supermercado', 1, 1)
INSERT [dbo].[cuentasGastos] ([id], [nombre], [idTipoCuenta], [impresion]) VALUES (4, N'Adelanto de Sueldo', 1, 1)
INSERT [dbo].[cuentasGastos] ([id], [nombre], [idTipoCuenta], [impresion]) VALUES (7, N'Plomero', 2, 1)
INSERT [dbo].[cuentasGastos] ([id], [nombre], [idTipoCuenta], [impresion]) VALUES (8, N'Electricista', 2, 1)
INSERT [dbo].[cuentasGastos] ([id], [nombre], [idTipoCuenta], [impresion]) VALUES (9, N'Conserje 1', 3, 1)
INSERT [dbo].[cuentasGastos] ([id], [nombre], [idTipoCuenta], [impresion]) VALUES (10, N'Conserje 2', 3, 1)
SET IDENTITY_INSERT [dbo].[cuentasGastos] OFF
/****** Object:  StoredProcedure [dbo].[cierresCajas_eliminarTurnosCerrados]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[cierresCajas_eliminarTurnosCerrados]
as

DECLARE @conserjeId int
declare @cierreId int

--delete from turnos_consumos where select distinct id from turnosCerrados

delete from turnosCerrados where contabilizado=1 
delete from articulosConsumidos
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_obtenerCierreActual]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cierresCajas_obtenerCierreActual]
as
	SELECT * FROM cierresCaja WHERE hasta is null
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_hacerCierre]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cierresCajas_hacerCierre]
@totEfectivo as decimal(8,2),@totTarjeta as decimal (8,2)
as

 update cierresCaja set totEfectivo=@totEfectivo,totTarjeta=@totTarjeta,hasta=GETDATE()
 where hasta is null
 
 declare @fecha date 
 set @fecha = GETDATE()
 
 if((select COUNT(*) from cierresCaja where  hasta > @fecha) = 1 )
	UPDATE parametros set val1 = 0 where nombre = 'totalTurnosCerrados' -- reinicio contador total turnos en el dia
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_abrirCierre]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cierresCajas_abrirCierre]
@efIni decimal(8,2),@tarjIni as decimal(8,2),@conserjeId as int
as


INSERT INTO cierresCaja
                      (desde, conserjeId, efectivoInicial, tarjetaInicial)
VALUES     (GETDATE(),@conserjeId,@efIni,@tarjIni)
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_contabilizarTurnosCerrados]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[cierresCajas_contabilizarTurnosCerrados]
as

DECLARE @conserjeId int
declare @cierreId int


select @cierreId=id,@conserjeId = conserjeId  from cierresCaja where hasta is NULL

select tc.*,s.nroSocio from turnosCerrados tc left join socios s on tc.socioId=s.id
where contabilizado = 0
and cancelado = 0
and conserjeId = @conserjeId

update turnosCerrados set contabilizado = 1 where contabilizado = 0
and cancelado = 0
and conserjeId = @conserjeId
GO
/****** Object:  Table [dbo].[gastos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gastos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[conserjeId] [smallint] NOT NULL,
	[cuentaGastoId] [int] NOT NULL,
	[monto] [decimal](6, 2) NOT NULL,
	[cierreId] [int] NOT NULL,
	[contabilizado] [bit] NOT NULL,
 CONSTRAINT [PK_gastos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[gastos] ON
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (7, CAST(0x0000A1940161015A AS DateTime), 1, 1, CAST(25.00 AS Decimal(6, 2)), 3, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (9, CAST(0x0000A19A017BCB40 AS DateTime), 1, 3, CAST(50.00 AS Decimal(6, 2)), 3, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (10, CAST(0x0000A19A017D35EF AS DateTime), 2, 1, CAST(45.00 AS Decimal(6, 2)), 10, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (11, CAST(0x0000A19A0183BDF7 AS DateTime), 1, 1, CAST(10.00 AS Decimal(6, 2)), 11, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (12, CAST(0x0000A19A018458B6 AS DateTime), 2, 2, CAST(23.00 AS Decimal(6, 2)), 12, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (13, CAST(0x0000A19A018460B9 AS DateTime), 2, 1, CAST(88.00 AS Decimal(6, 2)), 12, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (14, CAST(0x0000A19A01854E73 AS DateTime), 1, 1, CAST(20.00 AS Decimal(6, 2)), 13, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (15, CAST(0x0000A19A018772E0 AS DateTime), 2, 1, CAST(23.00 AS Decimal(6, 2)), 14, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (16, CAST(0x0000A19A01877C7F AS DateTime), 2, 2, CAST(10.00 AS Decimal(6, 2)), 14, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (17, CAST(0x0000A19A0187EE51 AS DateTime), 1, 2, CAST(10.00 AS Decimal(6, 2)), 15, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (18, CAST(0x0000A19B000EF20B AS DateTime), 2, 3, CAST(20.00 AS Decimal(6, 2)), 18, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (19, CAST(0x0000A19B0020BA74 AS DateTime), 2, 1, CAST(23.00 AS Decimal(6, 2)), 22, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (20, CAST(0x0000A19B01624DA5 AS DateTime), 1, 3, CAST(23.35 AS Decimal(6, 2)), 23, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (21, CAST(0x0000A19B01626206 AS DateTime), 1, 2, CAST(20.50 AS Decimal(6, 2)), 23, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (22, CAST(0x0000A19B01655596 AS DateTime), 2, 1, CAST(25.56 AS Decimal(6, 2)), 24, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (23, CAST(0x0000A19B01656B94 AS DateTime), 2, 3, CAST(7.56 AS Decimal(6, 2)), 24, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (24, CAST(0x0000A19B018739B2 AS DateTime), 1, 1, CAST(23.10 AS Decimal(6, 2)), 35, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (25, CAST(0x0000A19B0187416F AS DateTime), 1, 3, CAST(30.50 AS Decimal(6, 2)), 35, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (26, CAST(0x0000A19B01882FB0 AS DateTime), 2, 1, CAST(21.00 AS Decimal(6, 2)), 36, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (27, CAST(0x0000A19B018835BE AS DateTime), 2, 2, CAST(123.00 AS Decimal(6, 2)), 36, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (28, CAST(0x0000A19B0188D0B9 AS DateTime), 1, 2, CAST(12.00 AS Decimal(6, 2)), 37, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (29, CAST(0x0000A19B0188D690 AS DateTime), 1, 4, CAST(123.00 AS Decimal(6, 2)), 37, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (30, CAST(0x0000A19D015FC9CB AS DateTime), 1, 2, CAST(56.89 AS Decimal(6, 2)), 39, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (31, CAST(0x0000A1A10176478E AS DateTime), 2, 2, CAST(25.34 AS Decimal(6, 2)), 42, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (32, CAST(0x0000A1A20016199F AS DateTime), 1, 4, CAST(100.00 AS Decimal(6, 2)), 43, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (33, CAST(0x0000A1A300133AAE AS DateTime), 1, 3, CAST(81.17 AS Decimal(6, 2)), 43, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (34, CAST(0x0000A1A40020E458 AS DateTime), 1, 1, CAST(179.80 AS Decimal(6, 2)), 43, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (35, CAST(0x0000A1A60018EAB9 AS DateTime), 1, 2, CAST(143.14 AS Decimal(6, 2)), 43, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (36, CAST(0x0000A1A7017A6879 AS DateTime), 2, 1, CAST(78.88 AS Decimal(6, 2)), 48, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (37, CAST(0x0000A1A7017A73A4 AS DateTime), 2, 4, CAST(200.00 AS Decimal(6, 2)), 48, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (38, CAST(0x0000A1B6002B6F3E AS DateTime), 1, 1, CAST(1.00 AS Decimal(6, 2)), 49, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (39, CAST(0x0000A1C7016741CF AS DateTime), 2, 2, CAST(0.00 AS Decimal(6, 2)), 61, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (40, CAST(0x0000A1C701674BDA AS DateTime), 2, 1, CAST(90.00 AS Decimal(6, 2)), 61, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (41, CAST(0x0000A1DC015895D6 AS DateTime), 2, 7, CAST(0.00 AS Decimal(6, 2)), 61, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (42, CAST(0x0000A1EA014F1A5D AS DateTime), 2, 4, CAST(0.00 AS Decimal(6, 2)), 61, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (43, CAST(0x0000A1FB017FD4B6 AS DateTime), 1, 9, CAST(50.00 AS Decimal(6, 2)), 62, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (44, CAST(0x0000A1FE016DE04D AS DateTime), 1, 7, CAST(230.00 AS Decimal(6, 2)), 62, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (45, CAST(0x0000A1FE016DECF5 AS DateTime), 1, 8, CAST(54.00 AS Decimal(6, 2)), 62, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (46, CAST(0x0000A1FE016E04D8 AS DateTime), 1, 4, CAST(566.00 AS Decimal(6, 2)), 62, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (47, CAST(0x0000A20D01728C2A AS DateTime), 2, 9, CAST(450.00 AS Decimal(6, 2)), 63, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (48, CAST(0x0000A20D0174C3FC AS DateTime), 2, 10, CAST(600.00 AS Decimal(6, 2)), 63, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (49, CAST(0x0000A20D017D3EBB AS DateTime), 2, 1, CAST(2345.00 AS Decimal(6, 2)), 63, 1)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (50, CAST(0x0000A22B011E9D46 AS DateTime), 1, 1, CAST(50.00 AS Decimal(6, 2)), 71, 0)
INSERT [dbo].[gastos] ([id], [fecha], [conserjeId], [cuentaGastoId], [monto], [cierreId], [contabilizado]) VALUES (51, CAST(0x0000A22B011F0D8B AS DateTime), 1, 2, CAST(50.00 AS Decimal(6, 2)), 71, 0)
SET IDENTITY_INSERT [dbo].[gastos] OFF
/****** Object:  StoredProcedure [dbo].[feriados_damedia]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[feriados_damedia]
@dia int,@mes int
as
declare @aux int

select @aux = seComportaComo from feriados where mes = @mes and dia = @dia
select isnull(@aux , -1)
GO
/****** Object:  StoredProcedure [dbo].[estadoHabitacion_obtenerDatos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[estadoHabitacion_obtenerDatos]
as
begin
	declare @turnosAsignados int
	declare @turnosCerrados int
	declare @totalTurnosCerrados int
	declare @totalEfectivo decimal(8,2)
	declare @totalTarjeta decimal(8,2)
	declare @efectivoInicial decimal(8,2)
	
	select @turnosAsignados = cantTa, @turnosCerrados = cantTC, @efectivoInicial = efectivoInicial from cierresCaja where hasta is null
	select @totalTurnosCerrados = val1 from parametros where nombre = 'totalTurnosCerrados'
	
	select @turnosAsignados as ta, @turnosCerrados as tc, @totalTurnosCerrados as ttc, @efectivoInicial as ei	

end
GO
/****** Object:  Table [dbo].[turnos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[turnos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[impHabitacion] [decimal](8, 2) NOT NULL,
	[impArticulos] [decimal](8, 2) NOT NULL,
	[impExtras] [decimal](8, 2) NOT NULL,
	[efectivo] [decimal](8, 2) NULL,
	[tarjeta] [decimal](8, 2) NULL,
	[tipoTarjeta] [tinyint] NULL,
	[desde] [datetime] NOT NULL,
	[hasta] [datetime] NULL,
	[nroHabitacion] [smallint] NOT NULL,
	[aliasCat] [nchar](4) NOT NULL,
	[catId] [int] NULL,
	[socioId] [int] NULL,
	[descuentoId] [int] NULL,
	[descuentoAlCierre] [decimal](8, 2) NULL,
	[puntos] [int] NULL,
	[conserjeId] [smallint] NULL,
	[adelanto] [bit] NOT NULL,
	[pernocte] [bit] NOT NULL,
	[alarma] [datetime] NULL,
	[tarifaId] [int] NULL,
	[efectivoCerrado] [decimal](8, 2) NULL,
	[tarjetaCerrado] [decimal](8, 2) NULL,
	[descHabitacion] [decimal](8, 2) NULL,
	[contPernocte] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK_turnos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_turnos] UNIQUE NONCLUSTERED 
(
	[nroHabitacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[turnos] ON
INSERT [dbo].[turnos] ([id], [impHabitacion], [impArticulos], [impExtras], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [catId], [socioId], [descuentoId], [descuentoAlCierre], [puntos], [conserjeId], [adelanto], [pernocte], [alarma], [tarifaId], [efectivoCerrado], [tarjetaCerrado], [descHabitacion], [contPernocte]) VALUES (244, CAST(160.00 AS Decimal(8, 2)), CAST(533.00 AS Decimal(8, 2)), CAST(8030.50 AS Decimal(8, 2)), CAST(320.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22801592E07 AS DateTime), CAST(0x0000A2310151D460 AS DateTime), 1, N'COM ', 1, NULL, NULL, CAST(0.00 AS Decimal(8, 2)), NULL, 1, 0, 0, NULL, 50, CAST(320.00 AS Decimal(8, 2)), NULL, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnos] ([id], [impHabitacion], [impArticulos], [impExtras], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [catId], [socioId], [descuentoId], [descuentoAlCierre], [puntos], [conserjeId], [adelanto], [pernocte], [alarma], [tarifaId], [efectivoCerrado], [tarjetaCerrado], [descHabitacion], [contPernocte]) VALUES (248, CAST(160.00 AS Decimal(8, 2)), CAST(136.00 AS Decimal(8, 2)), CAST(3286.75 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22D015E2795 AS DateTime), CAST(0x0000A2310151D460 AS DateTime), 2, N'COM ', 1, NULL, NULL, CAST(0.00 AS Decimal(8, 2)), NULL, 1, 0, 0, NULL, 4, NULL, NULL, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnos] ([id], [impHabitacion], [impArticulos], [impExtras], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [catId], [socioId], [descuentoId], [descuentoAlCierre], [puntos], [conserjeId], [adelanto], [pernocte], [alarma], [tarifaId], [efectivoCerrado], [tarjetaCerrado], [descHabitacion], [contPernocte]) VALUES (249, CAST(160.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(2385.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22E01457F76 AS DateTime), CAST(0x0000A2310151D460 AS DateTime), 115, N'COM ', 1, NULL, NULL, CAST(0.00 AS Decimal(8, 2)), NULL, 1, 0, 1, NULL, 47, NULL, NULL, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)))
INSERT [dbo].[turnos] ([id], [impHabitacion], [impArticulos], [impExtras], [efectivo], [tarjeta], [tipoTarjeta], [desde], [hasta], [nroHabitacion], [aliasCat], [catId], [socioId], [descuentoId], [descuentoAlCierre], [puntos], [conserjeId], [adelanto], [pernocte], [alarma], [tarifaId], [efectivoCerrado], [tarjetaCerrado], [descHabitacion], [contPernocte]) VALUES (251, CAST(160.00 AS Decimal(8, 2)), CAST(28.00 AS Decimal(8, 2)), CAST(2385.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), NULL, CAST(0x0000A22E014603F9 AS DateTime), CAST(0x0000A2310151D460 AS DateTime), 5, N'COM ', 1, NULL, NULL, CAST(0.00 AS Decimal(8, 2)), NULL, 1, 0, 1, NULL, 47, NULL, NULL, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[turnos] OFF
/****** Object:  StoredProcedure [dbo].[turnos_preCierre]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[turnos_preCierre]
@nroHab as int
as
begin try
begin transaction
	declare @turnoId int
	declare @impArt decimal(8,2)
	declare @descId int
	declare @artCons int
	declare @artGratis int
	declare @precio decimal(8,2)
	declare @totalDescontar decimal(8,2) 
	set @totalDescontar = 0
	DECLARE @MaxRownum INT
	DECLARE @Iter INT
		
	select  @turnoId = id,@impArt=impArticulos,@descId=descuentoId from turnos  where nroHabitacion=@nroHab

	if @impArt>0 	--Logica de descontar articulos	
	begin
		if exists( select cantidadArticulos from descuentos where id=@descId)
		begin
			select @artGratis = cantidadArticulos from descuentos where id=@descId;
			select RowNum = ROW_NUMBER() OVER(ORDER BY a.precio desc), tc.cantidadArticulos,a.precio into #jav from turnos_consumos tc left join articulos a on tc.articulo_id=a.id where turno_id=@turnoId
						and articulo_id in (select articuloId from articulos_descuentos where descuentoId = @descId)
						order by a.precio desc;		

			SET @MaxRownum = (SELECT MAX(RowNum) FROM #jav)		
			SET @Iter = (SELECT MIN(RowNum) FROM #jav)
			
			WHILE @Iter <= @MaxRownum
			BEGIN
				SELECT @artGratis = (@artGratis - cantidadArticulos),@artCons=cantidadArticulos,@precio=precio
				FROM #jav WHERE RowNum = @Iter
			    
				if (@artGratis > 0	)
					SET @totalDescontar = @totalDescontar + (@artCons * @precio)				
				else
					set @totalDescontar = @totalDescontar + (@artCons + @artGratis)*@precio			
				
				if (@artGratis <= 0 )				
					break;		        
				
				SET @Iter = @Iter + 1
			END 
			drop table #jav
		END		
	END 
	
	select impHabitacion,impArticulos,impExtras,@totalDescontar as descPromo,efectivo,tarjeta,ta.precio as PrecioOriginal,
			t.puntos as puntos,t.descHabitacion
	from turnos t join tarifas as ta on t.tarifaId=ta.id
	where t.id=@turnoId
		
	commit transaction
end try
begin catch
	rollback transaction
end catch
GO
/****** Object:  StoredProcedure [dbo].[turnos_cerrar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[turnos_cerrar]
@nroHab as int,@descuento as decimal (6,2),@descPorArt as decimal(6,2), @medioPago as int,@impHabFaltante as decimal(7,2)
as
begin try
begin transaction
	declare @turnoId int
	declare @catId int
	declare @efectivo decimal(8,2)
	declare @tarjeta decimal(8,2)
		
	select  @turnoId = id,@catId = catId from turnos  where nroHabitacion=@nroHab
	update turnos set impArticulos=impArticulos-@descPorArt where id=@turnoId
	
	if exists(select id from turnosCerrados where id=@turnoId)--Si hay cierre parcial,creamos otra fila solo con lo recibido
	BEGIN
	
		if(@medioPago>0)-- Es tarjeta
		begin
			set @tarjeta = @impHabFaltante	
			set @efectivo = 0			
		end
		else -- es Efectivo
		begin
			set @efectivo = @impHabFaltante	
			set @tarjeta = 0			
		end
		
		insert into turnosCerrados ( id, catId, impHabitacion, impArticulos,impExtras, efectivo, tarjeta, tipoTarjeta, desde, hasta, nroHabitacion, aliasCat, horaCierre, socioId, descuentoId, descuentoAlCierre, puntos, 
						  conserjeId, contabilizado, cancelado, pernocte, descuentos)
		(select  id, @catId, impHabitacion, impArticulos, impExtras, isnull(efectivoCerrado,0)+@efectivo, isnull(tarjetaCerrado,0) + @tarjeta, tipoTarjeta, desde, hasta, nroHabitacion, aliasCat,GETDATE() ,socioId, descuentoId, @descuento, puntos, 
						  conserjeId, 0,0, pernocte,isnull(puntos,0) + descHabitacion
			from turnos where nroHabitacion=@nroHab)	
	END
		
	ELSE
	BEGIN	
		insert into turnosCerrados ( id, catId, impHabitacion, impArticulos,impExtras, efectivo, tarjeta, tipoTarjeta, desde, hasta, nroHabitacion, aliasCat, horaCierre, socioId, descuentoId, descuentoAlCierre, puntos, 
						  conserjeId, contabilizado, cancelado, pernocte, descuentos)
		(select  id, @catId, impHabitacion, impArticulos, impExtras, efectivo, tarjeta, tipoTarjeta, desde, hasta, nroHabitacion, aliasCat,GETDATE() ,socioId, descuentoId, @descuento, puntos, 
						  conserjeId, 0,0, pernocte,isnull(puntos,0) + descHabitacion
			from turnos where nroHabitacion=@nroHab)

		if(@medioPago>0)		
			update turnosCerrados set tarjeta=tarjeta+@impHabFaltante,tipoTarjeta=@medioPago where id=@turnoId
		else
			update turnosCerrados set efectivo=efectivo+@impHabFaltante where id=@turnoId		
	END
	
	-----  Agregar lo de Saldo a favor en Extra.  --------
	declare @saldo decimal(8,2)
	select @saldo = (impHabitacion+impArticulos+impExtras-descuentoAlCierre-descuentos-efectivo-tarjeta)  from turnosCerrados where id=@turnoId
	if(@saldo < 0)
		update turnosCerrados set impExtras+=-(@saldo) where id=@turnoId
	
	------------------------------------------------------
	
	delete from turnos_avisos where turnoId = @turnoId
	delete from turnos_alarmas where turnoId = @turnoId
	
	update habitaciones set estado = 'D' where nroHabitacion = @nroHab
	
	delete from turnos where nroHabitacion = @nroHab
	
	if((select val1 from parametros where nombre = 'eliminarRegistros') = 1)
	begin		
		delete from turnos_consumos where turno_id not in (select id from turnos)
	end
	
	UPDATE cierresCaja set cantTC = cantTC + 1 where hasta is null; -- Contador tunros cerrados	
	UPDATE parametros set val1 = val1 + 1 where nombre = 'totalTurnosCerrados' -- contador total turnos en el dia
	
	commit transaction
end try
begin catch
	rollback transaction
end catch
GO
/****** Object:  StoredProcedure [dbo].[calcular_descuentoPorArticulos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[calcular_descuentoPorArticulos]
@nroHab as int
as
declare @turnoId int
	declare @impArt decimal(8,2)
	declare @descId int
	declare @artCons int
	declare @artGratis int
	declare @precio decimal(8,2)
	declare @totalDescontar decimal(8,2) 
	set @totalDescontar = 0
	DECLARE @MaxRownum INT
	DECLARE @Iter INT
		
	select  @turnoId = id,@impArt=impArticulos,@descId=descuentoId from turnos where nroHabitacion=@nroHab

	if @impArt>0 	--Logica de descontar articulos	
	begin
		if exists( select cantidadArticulos from descuentos where id=@descId)
		begin
			select @artGratis = cantidadArticulos from descuentos where id=@descId;
			select RowNum = ROW_NUMBER() OVER(ORDER BY a.precio desc), tc.cantidadArticulos,a.precio into #jav from turnos_consumos tc left join articulos a on tc.articulo_id=a.id where turno_id=@turnoId
						and articulo_id in (select articuloId from articulos_descuentos where descuentoId = @descId)
						order by a.precio desc;		

			SET @MaxRownum = (SELECT MAX(RowNum) FROM #jav)		
			SET @Iter = (SELECT MIN(RowNum) FROM #jav)
			
			WHILE @Iter <= @MaxRownum
			BEGIN
				SELECT @artGratis = (@artGratis - cantidadArticulos),@artCons=cantidadArticulos,@precio=precio
				FROM #jav WHERE RowNum = @Iter
			    
				if (@artGratis > 0	)
					SET @totalDescontar = @totalDescontar + (@artCons * @precio)				
				else
					set @totalDescontar = @totalDescontar + (@artCons + @artGratis)*@precio			
				
				if (@artGratis <= 0 )				
					break;		        
				
				SET @Iter = @Iter + 1
			END 
			drop table #jav
		END		
	END 
	
	--select @totalDescontar as descuentoPorArticulos
	return @totalDescontar
GO
/****** Object:  StoredProcedure [dbo].[listaTurnos_2]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listaTurnos_2]	
@orden varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @nroHab int
	declare @Results table (nroHabitacion int,descArt decimal(8,2))
	
	declare TableCursor cursor fast_forward for
    select nroHabitacion  from turnos 

	open TableCursor

	fetch next from TableCursor into @nroHab
	while (@@FETCH_STATUS <> -1)
	begin
		declare @descArtAux decimal(8,2)
		EXEC @descArtAux = calcular_descuentoPorArticulos @nroHab
	    insert into @Results values(@nroHab,@descArtAux)
	    fetch next from TableCursor into @nroHab
	end
	close TableCursor
	deallocate TableCursor
		
	
	if(@orden='horarioSalida')
	begin	
		select h.nroHabitacion,cat.alias as categoria, t.aliasCat as categoria2, habilitada,h.estado,t.hasta as hsalida,
		t.impHabitacion + t.impExtras + t.impArticulos - t.Efectivo - t.tarjeta - t.descHabitacion - isnull(puntos,0) - ISNULL(r.descArt,0) as importe,
		ta.turnoId as aviso,
		tav.avisoId as avisoVerdad		
		from habitaciones as h 
		join categorias as cat 	on h.categoria=cat.id
		left join turnos as t on t.nroHabitacion = h.nroHabitacion
		inner join estadoHabitacion as eh on h.estado = eh.estado
		left join (Select distinct turnoId from turnos_alarmas) as ta on ta.turnoId = t.id
		left join @Results as r on t.nroHabitacion= r.nroHabitacion
		left join turnos_avisos tav on t.id = tav.turnoId
		where h.habilitada = 1
		order by eh.id,t.hasta,h.nroHabitacion
	end
	else
	begin
		select h.nroHabitacion,cat.alias as categoria, t.aliasCat as categoria2, habilitada,h.estado,t.hasta as hsalida,
		t.impHabitacion + t.impExtras + t.impArticulos - t.Efectivo - t.tarjeta - t.descHabitacion - isnull(puntos,0) - ISNULL(r.descArt,0) as importe,
		ta.turnoId as aviso,
		tav.avisoId as avisoVerdad		
		from habitaciones as h 
		join categorias as cat 	on h.categoria=cat.id
		left join turnos as t on t.nroHabitacion = h.nroHabitacion
		inner join estadoHabitacion as eh on h.estado = eh.estado
		left join (Select distinct turnoId from turnos_alarmas) as ta on ta.turnoId = t.id
		left join @Results as r on t.nroHabitacion= r.nroHabitacion
		left join turnos_avisos tav on t.id = tav.turnoId
		where h.habilitada = 1
		order by h.nroHabitacion
	end	
	return @@rowcount
END
GO
/****** Object:  StoredProcedure [dbo].[habitacion_detallesTurno]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[habitacion_detallesTurno]
    @nroHab int
AS
BEGIN TRY
begin transaction 
	SET NOCOUNT ON;
	declare @descArt decimal (8,2)
	
	exec @descArt = calcular_descuentoPorArticulos @nroHab
	
	select t.impHabitacion + t.impExtras + t.impArticulos - efectivo - tarjeta - descHabitacion - @descArt as impHabitacion,
	nroSocio,
	pernocte,
	t.puntos,
	descuentoId ,
	d.nombre,
	c.nombre as categoria,
	efectivo + tarjeta as impAdelantado,	
	desde,
	hasta,
	t.descHabitacion,
	@descArt as descArt,
	t.impArticulos as impArticulos,
	t.catId as catId,
	t.nroHabitacion as nroHab,
	t.contPernocte as contPernocte,
	t.impHabitacion as impHabIni,
	t.impExtras as impExtras
	
	from turnos t left join socios s on t.socioId=s.id 
	left join descuentos d on d.id = t.descuentoId
	left join categorias c on t.catId= c.id
	where nroHabitacion = @nroHab
	
COMMIT TRAN 
END TRY
BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage,@errorSeverity,@ERRORSTATE);
	
	rollback tran 
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[articulos_obtenerConsumos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[articulos_obtenerConsumos]
@nroHab int

AS
	declare @turnoId int;

	select @turnoId=id from turnos where nroHabitacion = @nroHab

	select a.id,tc.cantidadArticulos as cantidad,nombre,tc.cantidadArticulos * a.precio as total from turnos_consumos tc inner join
	articulos a on tc.articulo_id = a.id	
	where turno_id = @turnoId
GO
/****** Object:  StoredProcedure [dbo].[articulos_insertar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[articulos_insertar]	
    @nroHab int,@nroArt int,@cant int
AS
BEGIN TRY
begin transaction 
	SET NOCOUNT ON;
	declare @turnoId int;
	declare @descId int;
	declare @precioTotal decimal(8,2)
	declare @precioUnitario decimal(8,2)
	declare @artGratis smallint
	declare @artConsumidos smallint


	if(@nroHab=0)
		update articulos set stockActual = stockActual - @cant where id=@nroArt	
	else
	begin	
		select @turnoId=id,@descId=descuentoId from turnos where nroHabitacion=@nroHab
		select @precioTotal = (precio*@cant),@precioUnitario=precio from articulos where @nroArt=id
		if((select count(*) from turnos_consumos where articulo_id=@nroArt and @turnoId=turno_id) = 0)
			insert into turnos_consumos (articulo_id,turno_id,cantidadArticulos) values(@nroArt,@turnoId ,@cant)
		else
			update turnos_consumos set cantidadArticulos = cantidadArticulos+@cant where articulo_id=@nroArt and turno_id = @turnoId

		-----   Verifico si el articulo pertenece a promo y no lo facturo  ------------ 
	--	if exists( select cantidadArticulos from descuentos where id=@descId)
	--		if exists(select 1 from descuentos where @nroArt in (select articuloId from articulos_descuentos where descuentoId = @descId))
	--		begin
	--			select @artGratis = cantidadArticulos from descuentos where id=@descId
	--			select @artConsumidos = sum(cantidadArticulos) from turnos_consumos where turno_id=@turnoId
	--				and articulo_id in (select articuloId from articulos_descuentos where descuentoId = @descId)		
	--
	--			if (@artConsumidos-@artGratis>0)
	--			begin
	--				if(@artConsumidos-@cant >= @artGratis)
	--					update turnos set impArticulos = impArticulos + @precioTotal 
	--						where id=@turnoId
	--				else
	--					update turnos set impArticulos = impArticulos + (@artConsumidos-@artGratis)* @precioUnitario
	--						where id=@turnoId
	--			end
	--		end
	--		else
	--			update turnos set impArticulos = impArticulos + @precioTotal
	--				where id=@turnoId
	--	else
			update turnos set impArticulos = impArticulos + @precioTotal
				where id=@turnoId
		---------------------------------------------------------------------------------------

		update articulos set stockActual = stockActual - @cant where id=@nroArt	
	end
COMMIT TRAN 
END TRY

BEGIN CATCH	
	DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage,@errorSeverity,@ERRORSTATE);

	rollback tran 
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[articulos_anularPedido]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[articulos_anularPedido]	
    @nroHab int,@nroArt int,@cant int
AS
BEGIN TRY
begin transaction 
	SET NOCOUNT ON;
	declare @turnoId int;
	declare @precioTotal decimal(8,2)
	declare @precioUnitario decimal(8,2)
	declare @descId int
	declare @artGratis smallint
	declare @artRestantes smallint

	select @turnoId=id,@descId=descuentoId from turnos where nroHabitacion=@nroHab
	select @precioTotal = (precio*@cant),@precioUnitario=precio from articulos where @nroArt=id
	
	if((select cantidadArticulos-@cant as cant from turnos_consumos where articulo_id=@nroArt and turno_id=@turnoId)<0)
	BEGIN
		RAISERROR ('La habitación no posee esa cantidad de ese articulo',12,1);
		
	END
	else
	BEGIN	
		update turnos_consumos set cantidadArticulos=cantidadArticulos-@cant where articulo_id=@nroArt and turno_id=@turnoId
		delete from turnos_consumos where articulo_id=@nroArt and turno_id=@turnoId and cantidadArticulos = 0
				
		-----   Verifico si el articulo pertenece a promo y no lo facturo  ------------ 
--		if exists( select cantidadArticulos from descuentos where id=@descId)
--			if exists(select 1 from descuentos where @nroArt in (select articuloId from articulos_descuentos where descuentoId = @descId))
--			begin
--				select @artGratis = cantidadArticulos from descuentos where id=@descId
--				select @artRestantes = sum(cantidadArticulos) from turnos_consumos where turno_id=@turnoId
--					and articulo_id in (select articuloId from articulos_descuentos where descuentoId = @descId)		
--				if @artRestantes is null
--					select @artRestantes=0
--
--				if (@artRestantes>=@artGratis)
--				begin
--					update turnos set impArticulos = impArticulos - @precioTotal
--						where id=@turnoId
--				end
--				else
--					if(@cant-(@artGratis-@artRestantes))>= 0					
--						update turnos set impArticulos = impArticulos - (@cant-(@artGratis-@artRestantes))* @precioUnitario
--							where id=@turnoId
--			end
--			else
--				update turnos set impArticulos = impArticulos - @precioTotal
--					where id=@turnoId
--		else
			update turnos set impArticulos = impArticulos - @precioTotal
				where id=@turnoId
		---------------------------------------------------------------------------------------
		
		update articulos set stockActual = stockActual + @cant where id=@nroArt	
	END
	
COMMIT TRAN 
END TRY
BEGIN CATCH
	
	DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage,@errorSeverity,@ERRORSTATE);

	rollback tran 
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[Habitacion_ABM_insEdit]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Habitacion_ABM_insEdit]
@nroHab int,@catId1 int,@catId2 int=null,@catId3 int=null, @fundas int=0, @sabanas int=0,@acolchados int=0,@toallas int=0,@toallones int=0,@batas int=0,@posSenializacion int
AS
begin
		
	if(exists(select id from habitaciones where nroHabitacion=@nroHab))
		update habitaciones set nroHabitacion=@nroHab,								
								categoria= @catId1,
								categoria2= @catId2,
								categoria3=@catId3,
								fundas=@fundas,
								sabanas=@sabanas,
								acolchado=@acolchados,
								toallas=@toallas,
								toallones=@toallones,
								batas=@batas,
								posSenializacion=@posSenializacion
		where nroHabitacion=@nroHab
	else
		insert into habitaciones (nroHabitacion, habilitada, categoria, categoria2, categoria3, estado, fundas, sabanas, acolchado, toallas, toallones, batas, posSenializacion)
		values(@nroHab,1,@catId1,@catId2,@catId3,'D',@fundas,@sabanas,@acolchados,@toallas,@toallones,@batas,@posSenializacion)

end
GO
/****** Object:  StoredProcedure [dbo].[obtenerTarifaConId]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[obtenerTarifaConId]	
@catId int = null,@hora datetime = null ,@nroHab int = null
AS
BEGIN
	SET NOCOUNT ON;

	if @hora is null
		set	@hora = getdate()
	if @nroHab is not null
		select @catId = categoria from habitaciones where nroHabitacion=@nroHab

	select id, catId,catOriginalId, desde, hasta, dia, duracion, precio,precioMinuto, extension, precioTN,extensionPrecio,minAlarma,pernocte
	from tarifas
	where catId = @catId 
	and dia = datepart(dw,getdate())
	and(	
		( dbo.hora(desde) <= dbo.hora(@hora) and dbo.hora(@hora) < dbo.hora(hasta) )
		or(
			(dbo.hora(hasta) >= dbo.hora(@hora) or dbo.hora(desde)<= dbo.hora(@hora) )
			and dbo.hora(hasta) < dbo.hora(desde)
		)
	)
	
end
GO
/****** Object:  StoredProcedure [dbo].[obtenerTarifa2]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[obtenerTarifa2]	
    @catId int ,@hora datetime = null
AS
BEGIN
	SET NOCOUNT ON;

	if @hora is null
		set	@hora = getdate()

	select  catId,catOriginalId, desde, hasta, dia, duracion, precio, extension, precioTN
	from tarifas
	where catId = @catId 
	and dia = datepart(dw,getdate())
	and(	
		( dbo.hora(desde) <= dbo.hora(@hora) and dbo.hora(@hora) < dbo.hora(hasta) )
		or(
			(dbo.hora(hasta) > dbo.hora(@hora) or dbo.hora(desde)< dbo.hora(@hora) )
			and dbo.hora(hasta) < dbo.hora(desde)
		)
	)
	
end
GO
/****** Object:  StoredProcedure [dbo].[obtenerTarifa]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[obtenerTarifa]	
    @catId int = null ,@pernocte int,@nroHab int = null  
AS
BEGIN
	SET NOCOUNT ON;

IF @pernocte = 0
begin
	if @nroHab is not null
		select @catId = categoria from habitaciones where nroHabitacion=@nroHab

	select top(1)  *--catId,catOriginalId, desde, hasta, dia, duracion, precio,precioMinuto, extension, precioTN,extensionPrecio,minAlarma,pernocte
	from tarifas
	where catId = @catId 
	and dia = datepart(dw,getdate())
	and(	
		(   (datepart(hour,desde) < datepart( hour,getdate()) 
				or (datepart(hour,desde) = datepart( hour,getdate())
				and  datepart(minute,desde) <= datepart( minute,getdate()))) 
		and (datepart(hour,hasta) > datepart( hour,getdate()) 
				or (datepart(hour,hasta) = datepart( hour,getdate()) 
				and datepart(minute,hasta) > datepart( minute,getdate())))
		)
		or(
			(((datepart(hour,hasta) > datepart(hour,getdate()))
				or ( datepart(hour,hasta) = datepart(hour,getdate())
					and datepart(minute,hasta) > datepart( minute,getdate())))
			or ( (datepart(hour,desde) < datepart(hour,getdate())) 
				or ( datepart(hour,desde) = datepart(hour,getdate())
					and datepart(minute,desde) <= datepart( minute,getdate()))))
			and datepart(hour,hasta) < datepart( hour,desde)
		)
	)
	order by desde desc
end
else 
begin
	select  catId,catOriginalId, desde, hasta, dia, duracion, precio, extension, precioTN
	from tarifas
	where catId = @catId 
	and dia = datepart(dw,getdate())
	and(	
		(   (datepart(hour,desde) < datepart( hour,getdate()) 
				or (datepart(hour,desde) = datepart( hour,getdate())
				and  datepart(minute,desde) <= datepart( minute,getdate()))) 
		and (datepart(hour,hasta) > datepart( hour,getdate()) 
				or (datepart(hour,hasta) = datepart( hour,getdate()) 
				and datepart(minute,hasta) > datepart( minute,getdate())))
		)
		or(
			((datepart(hour,hasta) > datepart(hour,getdate()))
				or ( datepart(hour,hasta) = datepart(hour,getdate())
					and datepart(minute,hasta) > datepart( minute,getdate())))
			and datepart(hour,hasta) < datepart( hour,desde)
		)
	)
	and precioTN is not null
end

	
end
GO
/****** Object:  StoredProcedure [dbo].[ropaConsumida_obtener]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ropaConsumida_obtener]
as
SELECT c.nombre , SUM(isnull(fundas,0)) fundas,SUM(isnull(sabanas,0)) sabanas,SUM(isnull(acolchados,0)) acolchados,
SUM(isnull(toallas,0)) toallas,SUM(isnull(toallones,0)) toallones,SUM(isnull(batas,0)) batas FROM ropaConsumida rc
right join categorias c on rc.categoriaId=c.id
where cierreId = (select id from cierresCaja where hasta is null) or cierreId is null
GROUP BY c.nombre
union
select 'TOTAL' nombre,SUM(fundas) fundas,SUM(sabanas) sabanas,SUM(acolchados) acolchados,
SUM(toallas) toallas,SUM(toallones) toallones,SUM(batas) batas
from ropaConsumida 
where cierreId = (select id from cierresCaja where hasta is null)
GO
/****** Object:  StoredProcedure [dbo].[habitacion_cambiarEstado]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[habitacion_cambiarEstado]	
    @nroHab int,@est varchar
AS
	SET NOCOUNT ON;
	
		update habitaciones set estado = @est
		where nroHabitacion = @nroHab
GO
/****** Object:  StoredProcedure [dbo].[tarifas_obtenerActual]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tarifas_obtenerActual]
@dia int, @diaAnt int,@catId int,@hora datetime=NULL
as
BEGIN
	if @hora is null	
		set @hora=getdate()
		
	select top(1) * from tarifas 
	where dbo.hora_ss(desde) <= dbo.hora_ss (@hora)
	and dia = @dia
	and catId = @catId
	order by dbo.hora_ss (desde) desc

	IF @@rowcount = 0
		select top(1)* from tarifas where dia = @diaAnt and catId = @catId
		order by dbo.hora_ss (desde) desc
END
GO
/****** Object:  StoredProcedure [dbo].[tarifas_obtenerSiguiente]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tarifas_obtenerSiguiente]
@dia int, @diaSig int,@catId int,@hora datetime
as
BEGIN
			
	select top(1) * from tarifas 
	where dbo.hora_ss(desde) > dbo.hora_ss (@hora)
	and dia = @dia
	and catId = @catId
	order by dbo.hora_ss (desde) asc

	IF @@rowcount = 0
		select top(1)* from tarifas where dia = @diaSig and catId = @catId
		order by dbo.hora_ss (desde) asc
END
GO
/****** Object:  StoredProcedure [dbo].[tarifas_obtenerInicial]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[tarifas_obtenerInicial]
@nroHab as int
as



select * from tarifas where id = (select tarifaId from turnos where nroHabitacion = @nroHab)
GO
/****** Object:  StoredProcedure [dbo].[turnos_actualizar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[turnos_actualizar]
@nroHab as int, @monto as decimal(8,2), @hasta as datetime, @contPern as decimal(8,2)=0
as
update	turnos	set	impExtras = impExtras + @monto,
					hasta = @hasta,
					contPernocte = @contPern
				where nroHabitacion=@nroHab
GO
/****** Object:  StoredProcedure [dbo].[ropaConsumida_contabilizar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ropaConsumida_contabilizar]
@nroHab as int
as
begin

DECLARE @cierreId int
DECLARE @catId int
DECLARE @fundas int
DECLARE @sabanas int
DECLARE @acolchados int
DECLARE @toallas int
DECLARE @toallones int
DECLARE @batas int

select @cierreId = id from cierresCaja where hasta is null
select @catId = catId from turnos where nroHabitacion=@nroHab
select @fundas=fundas,@sabanas=sabanas,@acolchados=acolchado,@toallas=toallas,@toallones=toallones,@batas=batas
	from habitaciones where nroHabitacion=@nroHab

insert into ropaConsumida( nroHabitacion, categoriaId, fundas, sabanas, acolchados, toallas, toallones, batas, cierreId)
values(@nroHab,@catId,@fundas,@sabanas,@acolchados,@toallas,@toallones,@batas,@cierreId)

end
GO
/****** Object:  StoredProcedure [dbo].[listaTurnos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listaTurnos]	
AS
BEGIN
	SET NOCOUNT ON;
	select h.nroHabitacion,cat.alias as categoria, t.aliasCat as categoria2, habilitada,h.estado,t.hasta as hsalida,
	t.impHabitacion + t.impExtras + t.impArticulos - t.Efectivo - t.tarjeta - t.descHabitacion - isnull(puntos,0) as importe,
	ta.turnoId as aviso 
	from habitaciones as h 
	join categorias as cat 	on h.categoria=cat.id
	left join turnos as t on t.nroHabitacion = h.nroHabitacion
	inner join estadoHabitacion as eh on h.estado = eh.estado
	left join (Select distinct turnoId from turnos_avisos) as ta on ta.turnoId = t.id
	where h.habilitada = 1
	order by eh.id,hsalida,h.nroHabitacion

	return @@rowcount
END
GO
/****** Object:  StoredProcedure [dbo].[habitacion_cancelar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[habitacion_cancelar]	
    @nroHab int
AS
BEGIN TRY
begin transaction cancelar
	SET NOCOUNT ON;
	
	declare @puntos int	
	declare @socioId int	
	declare @turnoId int
	
    select @turnoId = id , @socioId = socioId,@puntos = puntos from turnos where nroHabitacion = @nroHab	
	
	insert into turnosCerrados (id, impHabitacion, impArticulos, efectivo, tarjeta,tipoTarjeta, desde, hasta, nroHabitacion, aliasCat,socioId, descuentoId, puntos,conserjeId, contabilizado, horaCierre, cancelado, pernocte) 
		select id,impHabitacion, impArticulos, efectivo, tarjeta,tipoTarjeta, desde, hasta, nroHabitacion, aliasCat,socioId, descuentoId, puntos,conserjeId,0,getdate(),1,pernocte  from turnos where nroHabitacion = @nroHab
	
	update habitaciones set estado = 'D' where nroHabitacion = @nroHab
	
	delete from turnos_alarmas where turnoId = @turnoId
	delete turnos where nroHabitacion = @nroHab
	
	if(@socioId is not null and @puntos > 0)
		update socios set puntos = puntos + @puntos where id = @socioId
		
	UPDATE cierresCaja set cantTA = cantTA - 1 where hasta is null;
	
COMMIT TRAN cancelar
END TRY
BEGIN CATCH
	SELECT 
          ERROR_NUMBER() as ErrorNumber,
          ERROR_MESSAGE() as ErrorMessage;
	rollback tran cancelar
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[Habitacion_calcularPrecioAsignar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Habitacion_calcularPrecioAsignar]
    @catId int, @dia int, @diaAnt int,@pernocte int,@descuentoId int=null,@puntos int = null
AS
BEGIN TRY
begin transaction asignar
	SET NOCOUNT ON;
	
	
	declare @catAlias nvarchar(4)
	declare @importe decimal(8,3)
	declare @descHabitacion decimal(8,3)
	set @descHabitacion = 0
	declare @duracion int
	Declare @hasta datetime
	Declare @hastaAux datetime
	Declare @tarifaId int

		
	select * into tablaAux from tarifas where 1=2
	set identity_insert tablaAux on		
	insert into tablaAux([id],[catId],[desde],[hasta],[dia],[duracion],[precio],[precioMinuto],[extension],[extensionPrecio],tolerancia,[precioTN],[minAlarma],[pernocte]) EXEC tarifas_obtenerActual @dia,@diaAnt,@catId
		
	select @importe = precio from tablaAux
	
	-- Aplicar descuentos de plata --
	if(@descuentoId is not null)
	BEGIN
		if((select 1 from descuentos where id = @descuentoId and descuentoFijo is not null) is not null)
		BEGIN
			set @descHabitacion = (select descuentoFijo from descuentos where id = @descuentoId);
		END
		if((select 1 from descuentos where id = @descuentoId and descuentoPorcentaje is not null) is not null)
		BEGIN
			set @descHabitacion = @importe * ((select descuentoPorcentaje from descuentos where id = @descuentoId)/100.00)
		END
	END
	---------------------------------
	
	select	@importe as montoTotal,
			@descHabitacion as descTotal,
			ISNULL(@puntos,0) as descPuntos

	drop table tablaAux
COMMIT TRAN asignar
END TRY
BEGIN CATCH

	DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage,@errorSeverity,@ERRORSTATE);

	rollback tran asignar
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[Habitacion_AsignarTurnoNoche]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Habitacion_AsignarTurnoNoche]	
    @nroHab int,@catId int,@precioTotal decimal(8,2),@precioExtras decimal(8,2),@hasta datetime,@descuentoId int=null,@conserjeId int,
    @socioId int = null,@puntos int=null,@tarifaId2 int,@descTotalHabitacion decimal(8,2) = null
AS
BEGIN TRY
begin transaction asignar
	SET NOCOUNT ON;
		
	declare @catAlias nvarchar(4)
	declare @deschabitacion decimal(8,2)
	set @deschabitacion = isnull(@descTotalHabitacion,0)
	
	if((select val1 from parametros where nombre='haySenializacion') = 0)
		update habitaciones set estado = 'O' where nroHabitacion = @nroHab
	else
		update habitaciones set estado = 'A' where nroHabitacion = @nroHab
			
	select @catAlias = alias from categorias where id = @catId	

	---- Aplicar descuentos de plata --
	--	if(@descuentoId is not null)
	--	BEGIN
	--		if((select 1 from descuentos where id = @descuentoId and descuentoFijo is not null) is not null)
	--		BEGIN
	--			set @deschabitacion = (select descuentoFijo from descuentos where id = @descuentoId);
	--		END
	--		if((select 1 from descuentos where id = @descuentoId and descuentoPorcentaje is not null) is not null)
	--		BEGIN
	--			set @deschabitacion = (@precioTotal + @precioExtras) * ((select descuentoPorcentaje from descuentos where id = @descuentoId)/100.00)
	--		END
	--	END
	--	---------------------------------
	
		insert into turnos ( catId,impHabitacion, impExtras, desde, hasta, nroHabitacion, aliasCat,conserjeId,socioId,descuentoId,puntos,pernocte,tarifaId,descHabitacion)
		values (@catId, @precioTotal,@precioExtras, getdate(),@hasta,@nroHab,@catAlias,@conserjeId,@socioId,@descuentoId,@puntos,1,@tarifaId2,@deschabitacion) 
	
COMMIT TRAN asignar
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage,@errorSeverity,@ERRORSTATE);
	rollback tran asignar
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[Habitacion_Asignar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Habitacion_Asignar]
    @nroHab int,@catId int, @dia int, @diaAnt int,
    @pernocte int,@descuentoId int=null,@conserjeId int,
    @socioId int = null,@puntos int = null,@contPernocte decimal(8,2)
AS
BEGIN TRY
begin transaction asignar
	SET NOCOUNT ON;	
	
	declare @catAlias nvarchar(4)
	declare @importe decimal(8,3)
	declare @descHabitacion decimal(8,3)
	set @descHabitacion = 0
	declare @duracion int
	Declare @hasta datetime	
	Declare @tarifaId int
	Declare @hayHasta int
	Declare @EsPernocte bit


	if((select val1 from parametros where nombre='haySenializacion') = 0)
		update habitaciones set estado = 'O' where nroHabitacion = @nroHab
	else
		update habitaciones set estado = 'A' where nroHabitacion = @nroHab
		
	select * into tablaAux from tarifas where 1=2
	set identity_insert tablaAux on		
	insert into tablaAux([id],[catId],[desde],[hasta],[dia],[duracion],[precio],[precioMinuto],[extension],[extensionPrecio],tolerancia,[precioTN],[minAlarma],[pernocte]) EXEC tarifas_obtenerActual @dia,@diaAnt,@catId
		
	select @tarifaId = id,@importe = precio,@duracion=duracion,@hasta = hasta,@EsPernocte = pernocte  from tablaAux  -- Obtengo el tarifaId,importe y duracion	
	select @catAlias = alias from categorias where id = @catId	-- Obtengo el Alias de la categoria
		
	-----------------------------------  Aplicar descuentos de plata -----------------------------------------------------
	if(@descuentoId is not null)
	BEGIN
		if((select 1 from descuentos where id = @descuentoId and descuentoFijo is not null) is not null)
		BEGIN
			set @descHabitacion = (select descuentoFijo from descuentos where id = @descuentoId);
		END
		if((select 1 from descuentos where id = @descuentoId and descuentoPorcentaje is not null) is not null)
		BEGIN
			set @descHabitacion = @importe * ((select descuentoPorcentaje from descuentos where id = @descuentoId)/100.00)
		END
	END
	----------------------------------------------------------------------------------------------------------------------
	
	insert into turnos ( impHabitacion,catId, desde, hasta, nroHabitacion, aliasCat,conserjeId,socioId,descuentoId,puntos,tarifaId,descHabitacion,contPernocte)
	values (@importe, @catId ,getdate(),DATEADD (minute ,@duracion , getdate() ),@nroHab,@catAlias,@conserjeId,@socioId,@descuentoId,@puntos,@tarifaId,@descHabitacion,@contPernocte) 
				
	if(@EsPernocte = 1 or (@hasta is not null and dbo.Hora(@hasta) > dbo.hora(getdate()))) -- Revisar a futuro si combiene ponerle fecha
	BEGIN
		update turnos 
		set contPernocte = @importe
		where nroHabitacion = @nroHab ;
	END
	drop table tablaAux
	
COMMIT TRAN asignar
END TRY

BEGIN CATCH

	DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage,@errorSeverity,@ERRORSTATE);

	rollback tran asignar
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[habitacion_adelanto]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[habitacion_adelanto]	
    @nroHab int,@monto decimal(8,2) = 0.00 ,@medioPago int = 0
AS
	SET NOCOUNT ON;
	--declare @impTotal decimal(8,2)
	--set @impTotal = @montoEfectivo + @montoTarjeta;
	if(@medioPago>0)
		update turnos set tarjeta = tarjeta + @monto,tarjetaCerrado = ISNULL(tarjetaCerrado,0) + @monto,tipoTarjeta = @medioPago
		where nroHabitacion = @nroHab 
	else
		update turnos set efectivo = efectivo + @monto,efectivoCerrado = ISNULL(efectivoCerrado,0) + @monto
		where nroHabitacion = @nroHab
GO
/****** Object:  StoredProcedure [dbo].[habitacion_adelantarPuntos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[habitacion_adelantarPuntos]	
    @nroHab int,@puntos int = 0
AS
	SET NOCOUNT ON;	
	
		update turnos set puntos = isnull(puntos,0) + @puntos
		where nroHabitacion = @nroHab
GO
/****** Object:  StoredProcedure [dbo].[gastos_obtenerListado]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gastos_obtenerListado]
@conserjeId as int
AS
declare @cierreId as int

select @cierreId = id from cierresCaja where hasta IS NULL

select cg.nombre,g.monto,cg.id from gastos g join cuentasGastos cg on g.cuentaGastoId=cg.id
where conserjeId = @conserjeId and cierreId = @cierreId and contabilizado = 0
GO
/****** Object:  StoredProcedure [dbo].[gastos_insertar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gastos_insertar]
@nroCuenta as int,@monto as decimal(8,2)
as
DECLARE @cierreId as int
DECLARE @conserjeId as int
DECLARE @gastoId as int

select @cierreId=id,@conserjeId = conserjeId from cierresCaja where hasta is NULL
select @gastoId = id from gastos where cuentaGastoId = @nroCuenta and cierreId = @cierreId

if (@gastoId is not null)
	update gastos set monto=monto+@monto where id = @gastoId
else	
	INSERT INTO gastos(cierreId, monto, cuentaGastoId, conserjeId, fecha)
	VALUES     (@cierreId,@monto,@nroCuenta,@conserjeId,GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[gastos_devolver]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[gastos_devolver]
@nroCuenta as int,@monto as decimal(8,2)
as
DECLARE @cierreId as int

select @cierreId=id from cierresCaja where hasta is NULL
update gastos set monto=monto-@monto where cierreId=@cierreId and cuentaGastoId=@nroCuenta
GO
/****** Object:  StoredProcedure [dbo].[habitacion_obtenerAlarmas]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[habitacion_obtenerAlarmas]

AS
	
	select a.id,nroHabitacion,a.mensaje from turnos_alarmas ta 
	left join alarmas as a on ta.alarmaId = a.id
	left join turnos as t on ta.turnoId = t.id
	where ta.hora = convert(int, dbo.hora_mm(getdate()))
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_obtenerTotales]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[cierresCajas_obtenerTotales]
as


DECLARE @conserjeId int
declare @cierreId int
declare @montoEfectivo as decimal (8,2)
declare @montoTarjeta as decimal (8,2)
set @montoEfectivo = 0
set @montoTarjeta = 0

select @cierreId=id,@conserjeId = conserjeId from cierresCaja where hasta is NULL

-----      Turnos Cerrados  ---------
select @montoEfectivo = @montoEfectivo + isnull(SUM(efectivo),0), @montoTarjeta = @montoTarjeta + ISNULL(SUM(tarjeta),0) 
from turnosCerrados 
where contabilizado = 0 -- significa que no se contabilizo en los cierres
and cancelado = 0
and conserjeId = @conserjeId


-----   Turnos Abiertos   ----------
select @montoEfectivo = @montoEfectivo + ISNULL(SUM(ISNULL(efectivoCerrado,0)),0)  , @montoTarjeta = @montoTarjeta + ISNULL(SUM(isnull(tarjetaCerrado,0)),0)
from turnos

-----   Gastos Actuales ----------
select @montoEfectivo = @montoEfectivo - ISNULL(SUM(monto),0)
from gastos
where cierreId = @cierreId -- significa que solo los del cierreActual
and conserjeId = @conserjeId

select @montoEfectivo as efectivo,@montoTarjeta as tarjeta
GO
/****** Object:  StoredProcedure [dbo].[conserje_login]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[conserje_login]	
    (@usuario int, @clave int)
AS
BEGIN
	SET NOCOUNT ON;

	declare @consId int
	
	select * from conserjes where usuario = @usuario and clave = @clave;	
	if(@@rowcount>0)
	begin
		update conserjes set logueado = 0
		update conserjes set logueado = 1 where usuario = @usuario
		update turnos set conserjeId = @usuario
	end


END
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_contabilizarTurnosAbiertos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[cierresCajas_contabilizarTurnosAbiertos]
as

select * from turnos where efectivoCerrado is not null or tarjetaCerrado is not null

insert into turnosCerrados ( id, catId, impHabitacion, impArticulos,impExtras, efectivo, tarjeta, tipoTarjeta, desde, hasta, nroHabitacion, aliasCat, horaCierre, socioId, descuentoId, descuentoAlCierre, puntos, 
						  conserjeId, contabilizado, cancelado, pernocte, descuentos)
		(select  id, catId, impHabitacion, impArticulos, impExtras, isnull(efectivoCerrado,0), isnull(tarjetaCerrado,0), tipoTarjeta, desde, null, nroHabitacion, aliasCat,GETDATE() ,socioId, descuentoId, 0, puntos, 
						  conserjeId, 1,0, pernocte,isnull(puntos,0) + descHabitacion
			from turnos )

update turnos set efectivoCerrado = NULL,tarjetaCerrado = NULL
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_contabilizarGastos]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[cierresCajas_contabilizarGastos]
as

DECLARE @conserjeId int
declare @cierreId int

select @cierreId = id, @conserjeId = conserjeId from cierresCaja where hasta is NULL

select g.fecha,cg.nombre,g.monto from gastos g join cuentasGastos cg on g.cuentaGastoId=cg.id
where conserjeId = @conserjeId 
and cierreId = @cierreId
and g.contabilizado = 0

update gastos set contabilizado = 1 
where conserjeId = @conserjeId 
and cierreId = @cierreId
and contabilizado = 0
GO
/****** Object:  StoredProcedure [dbo].[avisos_quitar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[avisos_quitar]
    @nroHab int,@avisoId int
AS

	SET NOCOUNT ON;
	declare @turnoId int;	

	select @turnoId=id from turnos where nroHabitacion=@nroHab
	delete from turnos_avisos where turnoId = @turnoId and avisoId= @avisoId
GO
/****** Object:  StoredProcedure [dbo].[avisos_obtenerPorHabitacion]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[avisos_obtenerPorHabitacion]
@nroHab  as int
AS	
	select a.id, a.mensaje from turnos_avisos ta 
	left join avisos as a on ta.avisoId = a.id
	left join turnos as t on ta.turnoId = t.id
	where t.nroHabitacion = @nroHab
GO
/****** Object:  StoredProcedure [dbo].[avisos_asignar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[avisos_asignar]	
    @nroHab int,@avisoId int
AS

	SET NOCOUNT ON;
	declare @turnoId int;
	

	select @turnoId=id from turnos where nroHabitacion=@nroHab

	insert into turnos_avisos (turnoId,avisoId) values(@turnoId,@avisoId)
GO
/****** Object:  StoredProcedure [dbo].[asignarHabitacion]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[asignarHabitacion]	
    @nroHab int,@pernocte int,@descuentoId int=null,@conserjeId int,@socioId int = null,@puntos int = null
AS
BEGIN TRY
begin transaction asignar
	SET NOCOUNT ON;
	
	declare @catId int
	declare @catAlias nvarchar(4)
	declare @importe decimal(8,3)
	declare @duracion int
	Declare @hasta datetime
	Declare @hastaAux datetime
	Declare @tarifaId int

	update habitaciones set estado='A' where nroHabitacion = @nroHab

	select @catId = categoria from habitaciones where nroHabitacion = @nroHab

	SELECT * Into tablaAux FROM tarifas WHERE 1=2
	SET IDENTITY_INSERT tablaAux ON
	select @tarifaId = tarifaId from descuentos where id = @descuentoId 

	if @tarifaId is not null 
	BEGIN
		insert into tablaAux (id, catId, catOriginalId, desde, hasta, dia, duracion, precio, precioMinuto, extension, precioTN, extensionPrecio, minAlarma, pernocte) select * FROM tarifas where id = @tarifaId
		select @catId = catId from tablaAux 

--		insert into tablaAux select catId,catOriginalId, desde, hasta, dia, duracion, precio,precioMinuto, extension, precioTN,extensionPrecio,minAlarma,pernocte
--		FROM tarifas where id = @tarifaId
--		select @catId = catId from tablaAux 
	END
	ELSE
	BEGIN
		insert into tablaAux (id, catId, catOriginalId, desde, hasta, dia, duracion, precio, precioMinuto, extension, precioTN, extensionPrecio, minAlarma, pernocte) EXEC obtenerTarifa  @catId,@pernocte		
	END
	
	select @tarifaId = id from tablaAux  -- Obtengo el tarifaId

	select @catAlias = alias from categorias where id = @catId	-- Obtengo el Alias en caso de ser T.Express

	if @pernocte = 0
	BEGIN
		select @importe = precio,@duracion=duracion from tablaAux
		-- Aplicar descuentos de plata --
		if(@descuentoId is not null)
		BEGIN
			if((select 1 from descuentos where id = @descuentoId and descuentoFijo is not null) is not null)
			BEGIN
				set @importe = @importe - (select descuentoFijo from descuentos where id = @descuentoId);
			END
			if((select 1 from descuentos where id = @descuentoId and descuentoPorcentaje is not null) is not null)
			BEGIN
				set @importe = @importe * (1- ((select descuentoPorcentaje from descuentos where id = @descuentoId)/100.00))
			END
		END
		---------------------------------
		insert into turnos ( impHabitacion, desde, hasta, nroHabitacion, aliasCat,conserjeId,socioId,descuentoId,puntos,tarifaId)
		values (@importe,getdate(),DATEADD (minute ,@duracion , getdate() ),@nroHab,@catAlias,@conserjeId,@socioId,@descuentoId,@puntos,@tarifaId) 
	END


	drop table tablaAux
COMMIT TRAN asignar
END TRY
BEGIN CATCH

	DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage,@errorSeverity,@ERRORSTATE);

	rollback tran asignar
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[articulosConsumidos_quitar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[articulosConsumidos_quitar]
@nroArt int,@cant int,@nroHab int
as
declare @turnoId int;
declare @cierreId int;

select @turnoId = id from turnos where nroHabitacion=@nroHab
select @cierreId = id from cierresCaja where hasta is null

update articulosConsumidos set cantidad = cantidad - @cant
where articuloId = @nroArt
and turnoId = @turnoId 
and cierreId = @cierreId
GO
/****** Object:  StoredProcedure [dbo].[articulosConsumidos_agregar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[articulosConsumidos_agregar]
@nroArt int,@cant int,@nroHab int
as

declare @turnoId int;
declare @cierreId int;


if(@nroHab=0)
	select @turnoId = -1 -- Significa todo lo consumido por la gerencia
else
	select @turnoId = id from turnos where nroHabitacion=@nroHab
select @cierreId = id from cierresCaja where hasta is null

if((select COUNT(*) from articulosConsumidos 
	where articuloId = @nroArt
	and turnoId = @turnoId 
	and cierreId = @cierreId) > 0)
	update articulosConsumidos set cantidad = cantidad + @cant 
	where articuloId = @nroArt and turnoId = @turnoId and cierreId = @cierreId
else
	insert into articulosConsumidos (articuloId, cantidad, cierreId, turnoId)
	values (@nroArt,@cant,@cierreId,@turnoId)
GO
/****** Object:  StoredProcedure [dbo].[alarmas_quitar]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[alarmas_quitar]
    @nroHab int,@avisoId int
AS

	SET NOCOUNT ON;
	declare @turnoId int;	

	select @turnoId=id from turnos where nroHabitacion=@nroHab
	delete from turnos_alarmas where turnoId = @turnoId and alarmaId= @avisoId
GO
/****** Object:  StoredProcedure [dbo].[alarmas_obtenerPorHabitacion]    Script Date: 09/08/2013 14:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[alarmas_obtenerPorHabitacion]
@nroHab  as int
AS	
	select a.id, a.mensaje,ta.hora from turnos_alarmas ta 
	left join alarmas as a on ta.alarmaId = a.id
	left join turnos as t on ta.turnoId = t.id
	where t.nroHabitacion = @nroHab
GO
/****** Object:  StoredProcedure [dbo].[alarmas_asignar]    Script Date: 09/08/2013 14:31:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[alarmas_asignar]	
    @nroHab int,@hora int,@avisoId int
AS

	SET NOCOUNT ON;
	declare @turnoId int;
	

	select @turnoId=id from turnos where nroHabitacion=@nroHab

	insert into turnos_alarmas (turnoId,alarmaId,hora) values(@turnoId,@avisoId,@hora)
GO
/****** Object:  Default [DF_compras_descripcion]    Script Date: 09/08/2013 14:31:52 ******/
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF_compras_descripcion]  DEFAULT ('') FOR [descripcion]
GO
/****** Object:  Default [DF_compras_comentario]    Script Date: 09/08/2013 14:31:52 ******/
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF_compras_comentario]  DEFAULT ('') FOR [comentario]
GO
/****** Object:  Default [DF_compras_compra]    Script Date: 09/08/2013 14:31:52 ******/
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF_compras_compra]  DEFAULT ((0)) FOR [compra]
GO
/****** Object:  Default [DF_compras_reposicion]    Script Date: 09/08/2013 14:31:52 ******/
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF_compras_reposicion]  DEFAULT ((0)) FOR [reposicion]
GO
/****** Object:  Default [DF_conserjes_logueado]    Script Date: 09/08/2013 14:31:52 ******/
ALTER TABLE [dbo].[conserjes] ADD  CONSTRAINT [DF_conserjes_logueado]  DEFAULT ((0)) FOR [logueado]
GO
/****** Object:  Default [DF_turnos_impHabitacion_2]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnos_impHabitacion_2]  DEFAULT ((0)) FOR [impHabitacion]
GO
/****** Object:  Default [DF_turnos_impArticulos_2]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnos_impArticulos_2]  DEFAULT ((0)) FOR [impArticulos]
GO
/****** Object:  Default [DF_turnosCerrados_impExtras]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnosCerrados_impExtras]  DEFAULT ((0)) FOR [impExtras]
GO
/****** Object:  Default [DF_turnosCerrados_descuentoAlCierre]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnosCerrados_descuentoAlCierre]  DEFAULT ((0)) FOR [descuentoAlCierre]
GO
/****** Object:  Default [DF_turnos_hasta_2]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnos_hasta_2]  DEFAULT (NULL) FOR [hasta]
GO
/****** Object:  Default [DF_turnos_adelanto_2]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnos_adelanto_2]  DEFAULT ((0)) FOR [contabilizado]
GO
/****** Object:  Default [DF_turnosCerrados_pernocte]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnosCerrados_pernocte]  DEFAULT ((0)) FOR [pernocte]
GO
/****** Object:  Default [DF_turnosCerrados_descuentos]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnosCerrados_descuentos]  DEFAULT ((0)) FOR [descuentos]
GO
/****** Object:  Default [DF_ropaHotel_stockInicial]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[ropaHotel] ADD  CONSTRAINT [DF_ropaHotel_stockInicial]  DEFAULT ((0)) FOR [stockInicial]
GO
/****** Object:  Default [DF_ropaHotel_saldoFinal]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[ropaHotel] ADD  CONSTRAINT [DF_ropaHotel_saldoFinal]  DEFAULT ((0)) FOR [saldoFinal]
GO
/****** Object:  Default [DF_ropaHotel_roto]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[ropaHotel] ADD  CONSTRAINT [DF_ropaHotel_roto]  DEFAULT ((0)) FOR [roto]
GO
/****** Object:  Default [DF_socios_puntos]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[socios] ADD  CONSTRAINT [DF_socios_puntos]  DEFAULT ((0)) FOR [puntos]
GO
/****** Object:  Default [DF_socios_fechaAltaSocio]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[socios] ADD  CONSTRAINT [DF_socios_fechaAltaSocio]  DEFAULT (getdate()) FOR [fechaAltaSocio]
GO
/****** Object:  Default [DF_socios_cantidadVisitas]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[socios] ADD  CONSTRAINT [DF_socios_cantidadVisitas]  DEFAULT ((0)) FOR [cantidadVisitas]
GO
/****** Object:  Default [DF_tarifas_duracion]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[tarifas] ADD  CONSTRAINT [DF_tarifas_duracion]  DEFAULT ((120)) FOR [duracion]
GO
/****** Object:  Default [DF_tarifas_pernocte]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[tarifas] ADD  CONSTRAINT [DF_tarifas_pernocte]  DEFAULT ((0)) FOR [pernocte]
GO
/****** Object:  Default [DF_cierresCaja_cantTA]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[cierresCaja] ADD  CONSTRAINT [DF_cierresCaja_cantTA]  DEFAULT ((0)) FOR [cantTA]
GO
/****** Object:  Default [DF_cierresCaja_cantTC]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[cierresCaja] ADD  CONSTRAINT [DF_cierresCaja_cantTC]  DEFAULT ((0)) FOR [cantTC]
GO
/****** Object:  Default [DF_habitaciones_habilitada]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_habilitada]  DEFAULT ((1)) FOR [habilitada]
GO
/****** Object:  Default [DF_habitaciones_categoria]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_categoria]  DEFAULT ((1)) FOR [categoria]
GO
/****** Object:  Default [DF_habitaciones_estado]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_estado]  DEFAULT ('D') FOR [estado]
GO
/****** Object:  Default [DF_habitaciones_fundas]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_fundas]  DEFAULT ((0)) FOR [fundas]
GO
/****** Object:  Default [DF_habitaciones_sabanas]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_sabanas]  DEFAULT ((0)) FOR [sabanas]
GO
/****** Object:  Default [DF_habitaciones_acolchado]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_acolchado]  DEFAULT ((0)) FOR [acolchado]
GO
/****** Object:  Default [DF_habitaciones_toallas]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_toallas]  DEFAULT ((0)) FOR [toallas]
GO
/****** Object:  Default [DF_habitaciones_toallones]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_toallones]  DEFAULT ((0)) FOR [toallones]
GO
/****** Object:  Default [DF_habitaciones_batas]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_batas]  DEFAULT ((0)) FOR [batas]
GO
/****** Object:  Default [DF_habitaciones_posSenializacion]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_posSenializacion]  DEFAULT ((0)) FOR [posSenializacion]
GO
/****** Object:  Default [DF_feriados_seComportaComo]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[feriados] ADD  CONSTRAINT [DF_feriados_seComportaComo]  DEFAULT ((8)) FOR [seComportaComo]
GO
/****** Object:  Default [DF_cuentasGastos_idTipoCuenta]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[cuentasGastos] ADD  CONSTRAINT [DF_cuentasGastos_idTipoCuenta]  DEFAULT ((1)) FOR [idTipoCuenta]
GO
/****** Object:  Default [DF_cuentasGastos_impresion]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[cuentasGastos] ADD  CONSTRAINT [DF_cuentasGastos_impresion]  DEFAULT ((0)) FOR [impresion]
GO
/****** Object:  Default [DF_gastos_contabilizado]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[gastos] ADD  CONSTRAINT [DF_gastos_contabilizado]  DEFAULT ((0)) FOR [contabilizado]
GO
/****** Object:  Default [DF_turnos_impHabitacion]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_impHabitacion]  DEFAULT ((0)) FOR [impHabitacion]
GO
/****** Object:  Default [DF_turnos_impArticulos]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_impArticulos]  DEFAULT ((0)) FOR [impArticulos]
GO
/****** Object:  Default [DF_turnos_impExtras]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_impExtras]  DEFAULT ((0)) FOR [impExtras]
GO
/****** Object:  Default [DF_turnos_efectivo]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_efectivo]  DEFAULT ((0)) FOR [efectivo]
GO
/****** Object:  Default [DF_turnos_tarjeta]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_tarjeta]  DEFAULT ((0)) FOR [tarjeta]
GO
/****** Object:  Default [DF_turnos_hasta]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_hasta]  DEFAULT (NULL) FOR [hasta]
GO
/****** Object:  Default [DF_turnos_descuentoAlCierre]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_descuentoAlCierre]  DEFAULT ((0)) FOR [descuentoAlCierre]
GO
/****** Object:  Default [DF_turnos_adelanto]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_adelanto]  DEFAULT ((0)) FOR [adelanto]
GO
/****** Object:  Default [DF_turnos_pernocte]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_pernocte]  DEFAULT ((0)) FOR [pernocte]
GO
/****** Object:  Default [DF_turnos_descHabitacion]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_descHabitacion]  DEFAULT ((0)) FOR [descHabitacion]
GO
/****** Object:  Default [DF_turnos_contPernocte]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_contPernocte]  DEFAULT ((0)) FOR [contPernocte]
GO
/****** Object:  ForeignKey [FK_formulaArt_articulos]    Script Date: 09/08/2013 14:31:42 ******/
ALTER TABLE [dbo].[articulosFormula]  WITH CHECK ADD  CONSTRAINT [FK_formulaArt_articulos] FOREIGN KEY([idArticuloBase])
REFERENCES [dbo].[articulos] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[articulosFormula] CHECK CONSTRAINT [FK_formulaArt_articulos]
GO
/****** Object:  ForeignKey [FK_formulaArtComp_articulos]    Script Date: 09/08/2013 14:31:42 ******/
ALTER TABLE [dbo].[articulosFormula]  WITH CHECK ADD  CONSTRAINT [FK_formulaArtComp_articulos] FOREIGN KEY([idArticuloComponente])
REFERENCES [dbo].[articulos] ([id])
GO
ALTER TABLE [dbo].[articulosFormula] CHECK CONSTRAINT [FK_formulaArtComp_articulos]
GO
/****** Object:  ForeignKey [FK_turnos_consumos_turnos_consumos]    Script Date: 09/08/2013 14:31:52 ******/
ALTER TABLE [dbo].[turnos_consumos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_consumos_turnos_consumos] FOREIGN KEY([articulo_id])
REFERENCES [dbo].[articulos] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[turnos_consumos] CHECK CONSTRAINT [FK_turnos_consumos_turnos_consumos]
GO
/****** Object:  ForeignKey [FK_tarifas_dias]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[tarifas]  WITH CHECK ADD  CONSTRAINT [FK_tarifas_dias] FOREIGN KEY([dia])
REFERENCES [dbo].[dias] ([id])
GO
ALTER TABLE [dbo].[tarifas] CHECK CONSTRAINT [FK_tarifas_dias]
GO
/****** Object:  ForeignKey [FK_tarifas_tarifas]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[tarifas]  WITH CHECK ADD  CONSTRAINT [FK_tarifas_tarifas] FOREIGN KEY([catId])
REFERENCES [dbo].[categorias] ([id])
GO
ALTER TABLE [dbo].[tarifas] CHECK CONSTRAINT [FK_tarifas_tarifas]
GO
/****** Object:  ForeignKey [FK_cierres_conserjes]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[cierresCaja]  WITH CHECK ADD  CONSTRAINT [FK_cierres_conserjes] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
ALTER TABLE [dbo].[cierresCaja] CHECK CONSTRAINT [FK_cierres_conserjes]
GO
/****** Object:  ForeignKey [FK_auditoria_conserjes]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[auditoria]  WITH CHECK ADD  CONSTRAINT [FK_auditoria_conserjes] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
ALTER TABLE [dbo].[auditoria] CHECK CONSTRAINT [FK_auditoria_conserjes]
GO
/****** Object:  ForeignKey [FK_habitaciones_categorias]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[habitaciones]  WITH CHECK ADD  CONSTRAINT [FK_habitaciones_categorias] FOREIGN KEY([categoria])
REFERENCES [dbo].[categorias] ([id])
GO
ALTER TABLE [dbo].[habitaciones] CHECK CONSTRAINT [FK_habitaciones_categorias]
GO
/****** Object:  ForeignKey [FK_habitaciones_categorias2]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[habitaciones]  WITH CHECK ADD  CONSTRAINT [FK_habitaciones_categorias2] FOREIGN KEY([categoria2])
REFERENCES [dbo].[categorias] ([id])
GO
ALTER TABLE [dbo].[habitaciones] CHECK CONSTRAINT [FK_habitaciones_categorias2]
GO
/****** Object:  ForeignKey [FK_habitaciones_categorias3]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[habitaciones]  WITH CHECK ADD  CONSTRAINT [FK_habitaciones_categorias3] FOREIGN KEY([categoria3])
REFERENCES [dbo].[categorias] ([id])
GO
ALTER TABLE [dbo].[habitaciones] CHECK CONSTRAINT [FK_habitaciones_categorias3]
GO
/****** Object:  ForeignKey [FK_feriados_dias]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[feriados]  WITH CHECK ADD  CONSTRAINT [FK_feriados_dias] FOREIGN KEY([seComportaComo])
REFERENCES [dbo].[dias] ([id])
GO
ALTER TABLE [dbo].[feriados] CHECK CONSTRAINT [FK_feriados_dias]
GO
/****** Object:  ForeignKey [FK_cuentasGastos_tiposCuentasGastos]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[cuentasGastos]  WITH CHECK ADD  CONSTRAINT [FK_cuentasGastos_tiposCuentasGastos] FOREIGN KEY([idTipoCuenta])
REFERENCES [dbo].[tiposCuentasGastos] ([idTipoCuenta])
GO
ALTER TABLE [dbo].[cuentasGastos] CHECK CONSTRAINT [FK_cuentasGastos_tiposCuentasGastos]
GO
/****** Object:  ForeignKey [FK_gastos_conserjes]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[gastos]  WITH CHECK ADD  CONSTRAINT [FK_gastos_conserjes] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
ALTER TABLE [dbo].[gastos] CHECK CONSTRAINT [FK_gastos_conserjes]
GO
/****** Object:  ForeignKey [FK_gastos_cuentasgastos]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[gastos]  WITH CHECK ADD  CONSTRAINT [FK_gastos_cuentasgastos] FOREIGN KEY([cuentaGastoId])
REFERENCES [dbo].[cuentasGastos] ([id])
GO
ALTER TABLE [dbo].[gastos] CHECK CONSTRAINT [FK_gastos_cuentasgastos]
GO
/****** Object:  ForeignKey [FK_habitaciones_turnos]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_habitaciones_turnos] FOREIGN KEY([nroHabitacion])
REFERENCES [dbo].[habitaciones] ([nroHabitacion])
GO
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_habitaciones_turnos]
GO
/****** Object:  ForeignKey [FK_habitaciones_turnos_2]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_habitaciones_turnos_2] FOREIGN KEY([nroHabitacion])
REFERENCES [dbo].[habitaciones] ([nroHabitacion])
GO
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_habitaciones_turnos_2]
GO
/****** Object:  ForeignKey [FK_turnos_conserjes]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_conserjes] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_conserjes]
GO
/****** Object:  ForeignKey [FK_turnos_conserjes_2]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_conserjes_2] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_conserjes_2]
GO
/****** Object:  ForeignKey [FK_turnos_descuentos]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_descuentos] FOREIGN KEY([descuentoId])
REFERENCES [dbo].[descuentos] ([id])
GO
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_descuentos]
GO
/****** Object:  ForeignKey [FK_turnos_descuentos_2]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_descuentos_2] FOREIGN KEY([descuentoId])
REFERENCES [dbo].[descuentos] ([id])
GO
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_descuentos_2]
GO
/****** Object:  ForeignKey [FK_turnos_mediosDePago]    Script Date: 09/08/2013 14:31:54 ******/
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_mediosDePago] FOREIGN KEY([tipoTarjeta])
REFERENCES [dbo].[mediosDePago] ([id])
GO
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_mediosDePago]
GO
