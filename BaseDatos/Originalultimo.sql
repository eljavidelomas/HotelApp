USE [hotel]
GO
/****** Object:  Table [dbo].[turnos_consumos]    Script Date: 06/12/2013 23:34:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[turnos_consumos]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[articulos]    Script Date: 06/12/2013 23:34:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulos]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[articulos_obtenerNombre]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulos_obtenerNombre]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create PROCEDURE [dbo].[articulos_obtenerNombre]
@artId int
AS
BEGIN
	SET NOCOUNT ON;
	select nombre,precio from articulos
	where id=@artId
		
END












' 
END
GO
/****** Object:  StoredProcedure [dbo].[articulos_obtenerListado]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulos_obtenerListado]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[articulos_obtenerListado]
AS	
	select id,nombre,precio,stockActual from articulos
	where tipoArticulo = ''B''








	









' 
END
GO
/****** Object:  Table [dbo].[articulosFormula]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulosFormula]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[categorias]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categorias]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[categorias](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[alias] [nchar](4) NULL,
 CONSTRAINT [PK_categorias] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[articulosConsumidos]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulosConsumidos]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[articulos_descuentos]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulos_descuentos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[articulos_descuentos](
	[articuloId] [int] NOT NULL,
	[descuentoId] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[alarmas]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[alarmas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[alarmas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mensaje] [varchar](50) NOT NULL,
 CONSTRAINT [PK_alarmas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[avisos]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[avisos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[avisos](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[mensaje] [varchar](30) NULL,
 CONSTRAINT [PK_mensajesAlarma] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[descuentos]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[descuentos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[descuentos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](50) NULL,
	[descuentoFijo] [decimal](8, 3) NULL,
	[descuentoPorcentaje] [int] NULL,
	[pathImagen] [varchar](150) NULL,
	[cantidadArticulos] [int] NULL,
	[acumulaPuntaje] [int] NULL,
	[tarifaId] [int] NULL,
	[menuId] [int] NULL,
 CONSTRAINT [PK_descuentos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cuentasGastos]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cuentasGastos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[cuentasGastos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_cuentasGastos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[conserjes]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[conserjes]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[estadoHabitacion]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[estadoHabitacion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[estadoHabitacion](
	[id] [smallint] NOT NULL,
	[estado] [char](1) NOT NULL,
	[descripcion] [varchar](15) NULL,
 CONSTRAINT [PK_estadoHabitacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dias]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dias]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dias](
	[id] [int] NOT NULL,
	[nombre] [nvarchar](16) NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[feriados]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[feriados]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[feriados](
	[mes] [tinyint] NOT NULL,
	[dia] [tinyint] NOT NULL,
 CONSTRAINT [IX_feriados] UNIQUE NONCLUSTERED 
(
	[mes] ASC,
	[dia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[mucamas]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mucamas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[mucamas](
	[id] [int] NOT NULL,
	[nombre] [varchar](20) NULL,
	[apellido] [varchar](20) NULL,
 CONSTRAINT [PK_mucamas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[menues]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[menues]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[menues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[precio] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_menues] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mediosDePago]    Script Date: 06/12/2013 23:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mediosDePago]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[mediosDePago](
	[id] [tinyint] NOT NULL,
	[nombre] [varchar](20) NULL,
 CONSTRAINT [PK_mediosDePago] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[hora_ss]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hora_ss]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[hora_ss] (@DATE datetime)
RETURNS varchar(8)
AS
BEGIN
	return (SELECT CONVERT(VARCHAR(5),@DATE,108))
end

' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[hora_mm]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hora_mm]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[hora_mm] (@DATE datetime)
RETURNS varchar(8)
AS
BEGIN
	return  (SELECT REPLACE( (SELECT CONVERT(VARCHAR(5),@date,108)), '':'', '''')) --(SELECT CONVERT(VARCHAR(5),@DATE,108))
end



' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[hora]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hora]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[hora] (@DATE datetime)
RETURNS varchar(8)
AS
BEGIN
	return (SELECT CONVERT(VARCHAR,@DATE,108))
end
' 
END
GO
/****** Object:  Table [dbo].[turnosCerrados]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[turnosCerrados]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[turnos_avisos]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[turnos_avisos]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[turnos_alarmas]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[turnos_alarmas]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[socios]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[socios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[socios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nroSocio] [int] NOT NULL,
	[puntos] [int] NOT NULL,
	[fechaAltaSocio] [datetime] NULL,
	[fechaVencimientoPuntaje] [datetime] NULL,
	[cantidadVisitas] [smallint] NULL,
 CONSTRAINT [PK_socios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_socios] UNIQUE NONCLUSTERED 
(
	[nroSocio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[seniales]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[seniales]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[parametros]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[parametros]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[parametros](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](25) NULL,
	[val1] [int] NULL,
	[val1_string] [varchar](50) NULL,
 CONSTRAINT [PK_parametros] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[opcionesCambioEstado]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[opcionesCambioEstado]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[opcionesCambioEstado](
	[id] [int] NOT NULL,
	[Opciones] [varchar](20) NOT NULL,
 CONSTRAINT [PK_opcionesCambioEstado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OpcionesAsignarHabitacion]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OpcionesAsignarHabitacion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OpcionesAsignarHabitacion](
	[id] [int] NOT NULL,
	[Detalles del Turno] [varchar](50) NULL,
 CONSTRAINT [PK_OpcionesAsignarHabitacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tarifas]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tarifas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tarifas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[catId] [int] NOT NULL,
	[desde] [datetime] NOT NULL,
	[hasta] [datetime] NULL,
	[dia] [int] NOT NULL,
	[duracion] [int] NOT NULL,
	[precio] [decimal](6, 2) NOT NULL,
	[precioMinuto]  AS (CONVERT([decimal](10,2),[precio]/[duracion],(0))),
	[extension] [int] NULL,
	[extensionPrecio] [decimal](6, 2) NULL,
	[tolerancia] [int] NULL,
	[precioTN] [decimal](6, 2) NULL,
	[minAlarma] [smallint] NULL,
	[pernocte] [bit] NULL,
 CONSTRAINT [PK_tarifas_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tarifas]') AND name = N'IX_tarifas')
CREATE NONCLUSTERED INDEX [IX_tarifas] ON [dbo].[tarifas] 
(
	[catId] ASC,
	[dia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ropaConsumida]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ropaConsumida]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[tipoDescuentos]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipoDescuentos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tipoDescuentos](
	[tipoDescuentoId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[pathImagen] [nvarchar](100) NULL,
 CONSTRAINT [PK_tipoDescuentos] PRIMARY KEY CLUSTERED 
(
	[tipoDescuentoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[tarifas_obtenerSiguiente]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tarifas_obtenerSiguiente]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE procedure [dbo].[tarifas_obtenerSiguiente]
@dia int, @diaSig int,@catId int,@hora datetime
as
BEGIN
			
	select top(1) * from tarifas 
	where dbo.hora_ss(desde) > dbo.hora_ss (@hora)
	and dia = @dia
	and catId = @catId
	order by desde asc

	IF @@rowcount = 0
		select top(1)* from tarifas where dia = @diaSig and catId = @catId
		order by desde asc
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[tarifas_obtenerActual]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tarifas_obtenerActual]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
	order by desde desc

	IF @@rowcount = 0
		select top(1)* from tarifas where dia = @diaAnt and catId = @catId
		order by desde desc
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[parametros_obtenerNroTicketCocina]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[parametros_obtenerNroTicketCocina]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[parametros_obtenerNroTicketCocina]    
AS
BEGIN TRY
begin transaction 
	SET NOCOUNT ON;
	
	select val1 from parametros where nombre=''ticketCocina''
	update parametros set val1=val1+1 where nombre=''ticketCocina''	
	
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[parametros_obtenerNroPlanilla]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[parametros_obtenerNroPlanilla]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create PROCEDURE [dbo].[parametros_obtenerNroPlanilla]    
AS
BEGIN TRY
begin transaction 
	SET NOCOUNT ON;
	
	select val1 from parametros where nombre=''planillaCaja''
	update parametros set val1=val1+1 where nombre=''planillaCaja''	
	
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[socios_registrar]    Script Date: 06/12/2013 23:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[socios_registrar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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



	








' 
END
GO
/****** Object:  StoredProcedure [dbo].[socios_descontarPuntos]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[socios_descontarPuntos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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



	







' 
END
GO
/****** Object:  Table [dbo].[habitaciones]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[habitaciones]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[obtenerTarifa2]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[obtenerTarifa2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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






' 
END
GO
/****** Object:  StoredProcedure [dbo].[Habitacion_calcularPrecioAsignarTurnoNoche]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Habitacion_calcularPrecioAsignarTurnoNoche]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

		select @precioExtras + @precioTotal - @deschabitacion - isnull(@puntos,0)	
	
	
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



	











' 
END
GO
/****** Object:  StoredProcedure [dbo].[Descuentos_getAll]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Descuentos_getAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[Descuentos_getAll]
--@nroHab int    
AS
BEGIN
	SET NOCOUNT ON;
	select * from descuentos
	
	--Declare @catId int
	--Select @catId=categoria from habitaciones where nroHabitacion = @nroHab

	--select d.* from descuentos as d 
	--left join tarifas as t on d.tarifaId = t.id	
	--where d.tarifaId is null 
	--or (d.tarifaId is not null )
end




' 
END
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_eliminarTurnosCerrados]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cierresCajas_eliminarTurnosCerrados]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE procedure [dbo].[cierresCajas_eliminarTurnosCerrados]
as

DECLARE @conserjeId int
declare @cierreId int

--delete from turnos_consumos where select distinct id from turnosCerrados

delete from turnosCerrados where contabilizado=1 
delete from cierreConsumos
' 
END
GO
/****** Object:  Table [dbo].[gastos]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gastos]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[auditoria]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[auditoria]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[cierresCaja]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cierresCaja]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  StoredProcedure [dbo].[articulosConsumidos_obtenerTodos]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulosConsumidos_obtenerTodos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	
CREATE procedure [dbo].[articulosConsumidos_obtenerTodos]
@stock bit
as
declare @cierreId int;
select @cierreId = id from cierresCaja where hasta is null

select a.id,a.nombre,isnull(ac.cantidad,0) as CantConsumida,stockRecomendado, a.controlStock,a.stockActual 
from articulos a left join articulosConsumidos ac on a.id = ac.articuloId
where (cierreId = @cierreId or cierreId is null)
and (a.controlStock = @stock or @stock = 0)
order by a.id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[articulosConsumidos_obtenerSoloConsumidos]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulosConsumidos_obtenerSoloConsumidos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	
create procedure [dbo].[articulosConsumidos_obtenerSoloConsumidos]
@stock bit
as
declare @cierreId int;
select @cierreId = id from cierresCaja where hasta is null

select a.id,a.nombre,isnull(ac.cantidad,0) as CantConsumida,stockRecomendado, a.controlStock,a.stockActual 
from articulos a left join articulosConsumidos ac on a.id = ac.articuloId
where (cierreId = @cierreId)
and (a.controlStock = @stock or @stock = 0)
order by a.id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_contabilizarGastos]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cierresCajas_contabilizarGastos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

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
and contabilizado = 0' 
END
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_abrirCierre]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cierresCajas_abrirCierre]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[cierresCajas_abrirCierre]
@efIni decimal(8,2),@tarjIni as decimal(8,2),@conserjeId as int
as


INSERT INTO cierresCaja
                      (desde, conserjeId, efectivoInicial, tarjetaInicial)
VALUES     (GETDATE(),@conserjeId,@efIni,@tarjIni)' 
END
GO
/****** Object:  StoredProcedure [dbo].[Habitacion_ABM_insEdit]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Habitacion_ABM_insEdit]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
		values(@nroHab,1,@catId1,@catId2,@catId3,''D'',@fundas,@sabanas,@acolchados,@toallas,@toallones,@batas,@posSenializacion)

end' 
END
GO
/****** Object:  StoredProcedure [dbo].[gastos_obtenerListado]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gastos_obtenerListado]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[gastos_obtenerListado]
@conserjeId as int
AS
declare @cierreId as int

select @cierreId = id from cierresCaja where hasta IS NULL

select cg.nombre,g.monto,cg.id from gastos g join cuentasGastos cg on g.cuentaGastoId=cg.id
where conserjeId = @conserjeId and cierreId = @cierreId and contabilizado = 0' 
END
GO
/****** Object:  StoredProcedure [dbo].[gastos_insertar]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gastos_insertar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[gastos_insertar]
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
	VALUES     (@cierreId,@monto,@nroCuenta,@conserjeId,GETDATE()) ' 
END
GO
/****** Object:  StoredProcedure [dbo].[gastos_devolver]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gastos_devolver]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [dbo].[gastos_devolver]
@nroCuenta as int,@monto as decimal(8,2)
as
DECLARE @cierreId as int

select @cierreId=id from cierresCaja where hasta is NULL
update gastos set monto=monto-@monto where cierreId=@cierreId and cuentaGastoId=@nroCuenta
' 
END
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_obtenerCierreActual]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cierresCajas_obtenerCierreActual]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[cierresCajas_obtenerCierreActual]
as
	SELECT * FROM cierresCaja WHERE hasta is null
' 
END
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_hacerCierre]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cierresCajas_hacerCierre]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[cierresCajas_hacerCierre]
@totEfectivo as decimal(8,2),@totTarjeta as decimal (8,2)
as

 update cierresCaja set totEfectivo=@totEfectivo,totTarjeta=@totTarjeta,hasta=GETDATE()
 where hasta is null
 
 declare @fecha date 
 set @fecha = GETDATE()
 
 if((select COUNT(*) from cierresCaja where  hasta > @fecha) = 1 )
	UPDATE parametros set val1 = 0 where nombre = ''totalTurnosCerrados'' -- reinicio contador total turnos en el dia
 ' 
END
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_contabilizarTurnosCerrados]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cierresCajas_contabilizarTurnosCerrados]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[Habitacion_calcularPrecioAsignar]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Habitacion_calcularPrecioAsignar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
	
	select @importe - @descHabitacion - ISNULL(@puntos,0)

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



	












' 
END
GO
/****** Object:  StoredProcedure [dbo].[estadoHabitacion_obtenerDatos]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[estadoHabitacion_obtenerDatos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
	select @totalTurnosCerrados = val1 from parametros where nombre = ''totalTurnosCerrados''
	
	select @turnosAsignados as ta, @turnosCerrados as tc, @totalTurnosCerrados as ttc, @efectivoInicial as ei	

end' 
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerTarifa]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[obtenerTarifa]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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










' 
END
GO
/****** Object:  StoredProcedure [dbo].[habitacion_cambiarEstado]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[habitacion_cambiarEstado]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create PROCEDURE [dbo].[habitacion_cambiarEstado]	
    @nroHab int,@est varchar
AS
	SET NOCOUNT ON;
	
		update habitaciones set estado = @est
		where nroHabitacion = @nroHab 
	




' 
END
GO
/****** Object:  Table [dbo].[turnos]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[turnos]') AND type in (N'U'))
BEGIN
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
 CONSTRAINT [PK_turnos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_turnos] UNIQUE NONCLUSTERED 
(
	[nroHabitacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[turnos_preCierre]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[turnos_preCierre]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE procedure [dbo].[turnos_preCierre]
@nroHab as int
as
begin try
begin transaction
	declare @turnoId int
	declare @impArt decimal(5,2)
	declare @descId int
	declare @artCons int
	declare @artGratis int
	declare @precio decimal(6,2)
	declare @totalDescontar decimal(6,2) 
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





' 
END
GO
/****** Object:  StoredProcedure [dbo].[turnos_cerrar]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[turnos_cerrar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
	
	if exists(select id from turnosCerrados where id=@turnoId)--Si el hay cierre parcial,creamos otra fila solo con lo recibido
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
	
	else
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
	
	delete from turnos_avisos where turnoId = @turnoId
	delete from turnos_alarmas where turnoId = @turnoId
	
	update habitaciones set estado = ''M'' where nroHabitacion = @nroHab
	
	delete from turnos where nroHabitacion = @nroHab
	
	if((select val1 from parametros where nombre = ''eliminarRegistros'') = 1)
	begin		
		delete from turnos_consumos where turno_id not in (select id from turnos)
	end
	
	UPDATE cierresCaja set cantTC = cantTC + 1 where hasta is null; -- Contador tunros cerrados	
	UPDATE parametros set val1 = val1 + 1 where nombre = ''totalTurnosCerrados'' -- contador total turnos en el dia
	
	commit transaction
end try
begin catch
	rollback transaction
end catch




' 
END
GO
/****** Object:  StoredProcedure [dbo].[calcular_descuentoPorArticulos]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[calcular_descuentoPorArticulos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE procedure [dbo].[calcular_descuentoPorArticulos]
@nroHab as int
as
declare @turnoId int
	declare @impArt decimal(5,2)
	declare @descId int
	declare @artCons int
	declare @artGratis int
	declare @precio decimal(6,2)
	declare @totalDescontar decimal(6,2) 
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
	return @totalDescontar ' 
END
GO
/****** Object:  StoredProcedure [dbo].[listaTurnos_2]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[listaTurnos_2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
		
	
	if(@orden=''horarioSalida'')
	begin	
		select h.nroHabitacion,cat.alias as categoria, t.aliasCat as categoria2, habilitada,h.estado,t.hasta as hsalida,
		t.impHabitacion + t.impExtras + t.impArticulos - t.Efectivo - t.tarjeta - t.descHabitacion - isnull(puntos,0) - ISNULL(r.descArt,0) as importe,
		ta.turnoId as aviso	
		from habitaciones as h 
		join categorias as cat 	on h.categoria=cat.id
		left join turnos as t on t.nroHabitacion = h.nroHabitacion
		inner join estadoHabitacion as eh on h.estado = eh.estado
		left join (Select distinct turnoId from turnos_alarmas) as ta on ta.turnoId = t.id
		left join @Results as r on t.nroHabitacion= r.nroHabitacion
		where h.habilitada = 1
		order by eh.id,t.hasta,h.nroHabitacion
	end
	else
	begin
		select h.nroHabitacion,cat.alias as categoria, t.aliasCat as categoria2, habilitada,h.estado,t.hasta as hsalida,
		t.impHabitacion + t.impExtras + t.impArticulos - t.Efectivo - t.tarjeta - t.descHabitacion - isnull(puntos,0) - ISNULL(r.descArt,0) as importe,
		ta.turnoId as aviso	
		from habitaciones as h 
		join categorias as cat 	on h.categoria=cat.id
		left join turnos as t on t.nroHabitacion = h.nroHabitacion
		inner join estadoHabitacion as eh on h.estado = eh.estado
		left join (Select distinct turnoId from turnos_alarmas) as ta on ta.turnoId = t.id
		left join @Results as r on t.nroHabitacion= r.nroHabitacion
		where h.habilitada = 1
		order by h.nroHabitacion
	end	
	return @@rowcount
END












' 
END
GO
/****** Object:  StoredProcedure [dbo].[habitacion_detallesTurno]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[habitacion_detallesTurno]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[habitacion_detallesTurno]
    @nroHab int
AS
BEGIN TRY
begin transaction 
	SET NOCOUNT ON;
	declare @descArt decimal (8,2)
	exec @descArt = calcular_descuentoPorArticulos @nroHab
	select t.impHabitacion + t.impExtras + t.impArticulos - efectivo - tarjeta - descHabitacion - @descArt as impHabitacion,nroSocio,pernocte,
	t.puntos,descuentoId ,d.nombre,c.nombre as categoria,efectivo + tarjeta as impAdelantado,
	desde,hasta
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



	










' 
END
GO
/****** Object:  StoredProcedure [dbo].[articulos_obtenerConsumos]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulos_obtenerConsumos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[articulos_obtenerConsumos]
@nroHab int

AS
	declare @turnoId int;

	select @turnoId=id from turnos where nroHabitacion = @nroHab

	select a.id,tc.cantidadArticulos as cantidad,nombre,tc.cantidadArticulos * a.precio as total from turnos_consumos tc inner join
	articulos a on tc.articulo_id = a.id	
	where turno_id = @turnoId
	




' 
END
GO
/****** Object:  StoredProcedure [dbo].[articulos_insertar]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulos_insertar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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



	













' 
END
GO
/****** Object:  StoredProcedure [dbo].[articulos_anularPedido]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulos_anularPedido]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
		RAISERROR (''La habitación no posee esa cantidad de ese articulo'',12,1);
		
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



	













' 
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerTarifaConId]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[obtenerTarifaConId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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







' 
END
GO
/****** Object:  StoredProcedure [dbo].[ropaConsumida_obtener]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ropaConsumida_obtener]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[ropaConsumida_obtener]
as
SELECT c.nombre , SUM(isnull(fundas,0)) fundas,SUM(isnull(sabanas,0)) sabanas,SUM(isnull(acolchados,0)) acolchados,
SUM(isnull(toallas,0)) toallas,SUM(isnull(toallones,0)) toallones,SUM(isnull(batas,0)) batas FROM ropaConsumida rc
right join categorias c on rc.categoriaId=c.id
where cierreId = (select id from cierresCaja where hasta is null) or cierreId is null
GROUP BY c.nombre
union
select ''TOTAL'' nombre,SUM(fundas) fundas,SUM(sabanas) sabanas,SUM(acolchados) acolchados,
SUM(toallas) toallas,SUM(toallones) toallones,SUM(batas) batas
from ropaConsumida 
where cierreId = (select id from cierresCaja where hasta is null)' 
END
GO
/****** Object:  StoredProcedure [dbo].[ropaConsumida_contabilizar]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ropaConsumida_contabilizar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

end' 
END
GO
/****** Object:  StoredProcedure [dbo].[listaTurnos]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[listaTurnos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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












' 
END
GO
/****** Object:  StoredProcedure [dbo].[habitacion_cancelar]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[habitacion_cancelar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[habitacion_cancelar]	
    @nroHab int
AS
BEGIN TRY
begin transaction cancelar
	SET NOCOUNT ON;
	
	declare @puntos int	
	declare @socioId int	
	
    select @socioId = socioId,@puntos = puntos from turnos where nroHabitacion = @nroHab	
	
	insert into turnosCerrados (id, impHabitacion, impArticulos, efectivo, tarjeta,tipoTarjeta, desde, hasta, nroHabitacion, aliasCat,socioId, descuentoId, puntos,conserjeId, contabilizado, horaCierre, cancelado, pernocte) 
		select id,impHabitacion, impArticulos, efectivo, tarjeta,tipoTarjeta, desde, hasta, nroHabitacion, aliasCat,socioId, descuentoId, puntos,conserjeId,0,getdate(),1,pernocte  from turnos where nroHabitacion = @nroHab
	
	update habitaciones set estado = ''D'' where nroHabitacion = @nroHab
	
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



	









' 
END
GO
/****** Object:  StoredProcedure [dbo].[Habitacion_AsignarTurnoNoche]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Habitacion_AsignarTurnoNoche]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[Habitacion_AsignarTurnoNoche]	
    @nroHab int,@catId int,@precioTotal decimal(8,2),@precioExtras decimal(8,2),@hasta datetime,@descuentoId int=null,@conserjeId int,@socioId int = null,@puntos int=null,@tarifaId2 int
AS
BEGIN TRY
begin transaction asignar
	SET NOCOUNT ON;
		
	declare @catAlias nvarchar(4)
	declare @deschabitacion decimal(8,2)
	set @deschabitacion = 0
	
	update habitaciones set estado=''A'' where nroHabitacion = @nroHab
			
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



	











' 
END
GO
/****** Object:  StoredProcedure [dbo].[Habitacion_Asignar]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Habitacion_Asignar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[Habitacion_Asignar]
    @nroHab int,@catId int, @dia int, @diaAnt int,@pernocte int,@descuentoId int=null,@conserjeId int,@socioId int = null,@puntos int = null
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

	update habitaciones set estado=''A'' where nroHabitacion = @nroHab
	
	select * into tablaAux from tarifas where 1=2
	set identity_insert tablaAux on		
	insert into tablaAux([id],[catId],[desde],[hasta],[dia],[duracion],[precio],[precioMinuto],[extension],[extensionPrecio],tolerancia,[precioTN],[minAlarma],[pernocte]) EXEC tarifas_obtenerActual @dia,@diaAnt,@catId
		
	select @tarifaId = id from tablaAux  -- Obtengo el tarifaId
	
	select @catAlias = alias from categorias where id = @catId	-- Obtengo el Alias de la categoria
	
	select @importe = precio,@duracion=duracion from tablaAux
	
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
	
	insert into turnos ( impHabitacion,catId, desde, hasta, nroHabitacion, aliasCat,conserjeId,socioId,descuentoId,puntos,tarifaId,descHabitacion)
	values (@importe, @catId ,getdate(),DATEADD (minute ,@duracion , getdate() ),@nroHab,@catAlias,@conserjeId,@socioId,@descuentoId,@puntos,@tarifaId,@descHabitacion) 

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



	












' 
END
GO
/****** Object:  StoredProcedure [dbo].[habitacion_adelanto]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[habitacion_adelanto]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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




' 
END
GO
/****** Object:  StoredProcedure [dbo].[habitacion_obtenerAlarmas]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[habitacion_obtenerAlarmas]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[habitacion_obtenerAlarmas]

AS
	
	select a.id,nroHabitacion,a.mensaje from turnos_alarmas ta 
	left join alarmas as a on ta.alarmaId = a.id
	left join turnos as t on ta.turnoId = t.id
	where ta.hora = convert(int, dbo.hora_mm(getdate()))

	








	










' 
END
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_contabilizarTurnosAbiertos]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cierresCajas_contabilizarTurnosAbiertos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE procedure [dbo].[cierresCajas_contabilizarTurnosAbiertos]
as

select * from turnos where efectivoCerrado is not null or tarjetaCerrado is not null

insert into turnosCerrados ( id, catId, impHabitacion, impArticulos,impExtras, efectivo, tarjeta, tipoTarjeta, desde, hasta, nroHabitacion, aliasCat, horaCierre, socioId, descuentoId, descuentoAlCierre, puntos, 
						  conserjeId, contabilizado, cancelado, pernocte, descuentos)
		(select  id, catId, impHabitacion, impArticulos, impExtras, isnull(efectivoCerrado,0), isnull(tarjetaCerrado,0), tipoTarjeta, desde, null, nroHabitacion, aliasCat,GETDATE() ,socioId, descuentoId, 0, puntos, 
						  conserjeId, 1,0, pernocte,isnull(puntos,0) + descHabitacion
			from turnos )

update turnos set efectivoCerrado = NULL,tarjetaCerrado = NULL


' 
END
GO
/****** Object:  StoredProcedure [dbo].[conserje_login]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[conserje_login]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
	


' 
END
GO
/****** Object:  StoredProcedure [dbo].[cierresCajas_obtenerTotales]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cierresCajas_obtenerTotales]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

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

select @montoEfectivo as efectivo,@montoTarjeta as tarjeta' 
END
GO
/****** Object:  StoredProcedure [dbo].[articulosConsumidos_quitar]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulosConsumidos_quitar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE procedure [dbo].[articulosConsumidos_quitar]
@artId int,@cantArt int,@nroHab int
as
declare @turnoId int;
declare @cierreId int;

select @turnoId = id from turnos where nroHabitacion=@nroHab
select @cierreId = id from cierresCaja where hasta is null

update articulosConsumidos set cantidad = cantidad - @cantArt 
where articuloId = @artId and turnoId = @turnoId and cierreId = @cierreId' 
END
GO
/****** Object:  StoredProcedure [dbo].[avisos_quitar]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[avisos_quitar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create PROCEDURE [dbo].[avisos_quitar]
    @nroHab int,@avisoId int
AS

	SET NOCOUNT ON;
	declare @turnoId int;	

	select @turnoId=id from turnos where nroHabitacion=@nroHab
	delete from turnos_avisos where turnoId = @turnoId and avisoId= @avisoId



	










' 
END
GO
/****** Object:  StoredProcedure [dbo].[avisos_obtenerPorHabitacion]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[avisos_obtenerPorHabitacion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[avisos_obtenerPorHabitacion]
@nroHab  as int
AS	
	select a.id, a.mensaje from turnos_avisos ta 
	left join avisos as a on ta.avisoId = a.id
	left join turnos as t on ta.turnoId = t.id
	where t.nroHabitacion = @nroHab







	










' 
END
GO
/****** Object:  StoredProcedure [dbo].[avisos_asignar]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[avisos_asignar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[avisos_asignar]	
    @nroHab int,@avisoId int
AS

	SET NOCOUNT ON;
	declare @turnoId int;
	

	select @turnoId=id from turnos where nroHabitacion=@nroHab

	insert into turnos_avisos (turnoId,avisoId) values(@turnoId,@avisoId)

	



	










' 
END
GO
/****** Object:  StoredProcedure [dbo].[asignarHabitacion]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[asignarHabitacion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

	update habitaciones set estado=''A'' where nroHabitacion = @nroHab

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



	












' 
END
GO
/****** Object:  StoredProcedure [dbo].[articulosConsumidos_agregar]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulosConsumidos_agregar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[articulosConsumidos_agregar]
@nroArt int,@cant int,@nroHab int
as

declare @turnoId int;
declare @cierreId int;

select @turnoId = id from turnos where nroHabitacion=@nroHab
select @cierreId = id from cierresCaja where hasta is null

if((select COUNT(*) from articulosConsumidos where articuloId = @nroArt)>0)
	update articulosConsumidos set cantidad = cantidad + @cant 
	where articuloId = @nroArt and turnoId = @turnoId and cierreId = @cierreId
else
	insert into articulosConsumidos (articuloId, cantidad, cierreId, turnoId)
	values (@nroArt,@cant,@cierreId,@cierreId)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[alarmas_quitar]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[alarmas_quitar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create PROCEDURE [dbo].[alarmas_quitar]
    @nroHab int,@avisoId int
AS

	SET NOCOUNT ON;
	declare @turnoId int;	

	select @turnoId=id from turnos where nroHabitacion=@nroHab
	delete from turnos_alarmas where turnoId = @turnoId and alarmaId= @avisoId



	










' 
END
GO
/****** Object:  StoredProcedure [dbo].[alarmas_obtenerPorHabitacion]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[alarmas_obtenerPorHabitacion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[alarmas_obtenerPorHabitacion]
@nroHab  as int
AS	
	select a.id, a.mensaje,ta.hora from turnos_alarmas ta 
	left join alarmas as a on ta.alarmaId = a.id
	left join turnos as t on ta.turnoId = t.id
	where t.nroHabitacion = @nroHab







	










' 
END
GO
/****** Object:  StoredProcedure [dbo].[alarmas_asignar]    Script Date: 06/12/2013 23:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[alarmas_asignar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create PROCEDURE [dbo].[alarmas_asignar]	
    @nroHab int,@hora int,@avisoId int
AS

	SET NOCOUNT ON;
	declare @turnoId int;
	

	select @turnoId=id from turnos where nroHabitacion=@nroHab

	insert into turnos_alarmas (turnoId,alarmaId,hora) values(@turnoId,@avisoId,@hora)

	



	










' 
END
GO
/****** Object:  Default [DF_conserjes_logueado]    Script Date: 06/12/2013 23:34:28 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_conserjes_logueado]') AND parent_object_id = OBJECT_ID(N'[dbo].[conserjes]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_conserjes_logueado]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[conserjes] ADD  CONSTRAINT [DF_conserjes_logueado]  DEFAULT ((0)) FOR [logueado]
END


End
GO
/****** Object:  Default [DF_turnos_impHabitacion_2]    Script Date: 06/12/2013 23:34:29 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnos_impHabitacion_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnosCerrados]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnos_impHabitacion_2]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnos_impHabitacion_2]  DEFAULT ((0)) FOR [impHabitacion]
END


End
GO
/****** Object:  Default [DF_turnos_impArticulos_2]    Script Date: 06/12/2013 23:34:29 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnos_impArticulos_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnosCerrados]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnos_impArticulos_2]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnos_impArticulos_2]  DEFAULT ((0)) FOR [impArticulos]
END


End
GO
/****** Object:  Default [DF_turnosCerrados_impExtras]    Script Date: 06/12/2013 23:34:29 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnosCerrados_impExtras]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnosCerrados]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnosCerrados_impExtras]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnosCerrados_impExtras]  DEFAULT ((0)) FOR [impExtras]
END


End
GO
/****** Object:  Default [DF_turnosCerrados_descuentoAlCierre]    Script Date: 06/12/2013 23:34:29 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnosCerrados_descuentoAlCierre]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnosCerrados]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnosCerrados_descuentoAlCierre]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnosCerrados_descuentoAlCierre]  DEFAULT ((0)) FOR [descuentoAlCierre]
END


End
GO
/****** Object:  Default [DF_turnos_hasta_2]    Script Date: 06/12/2013 23:34:29 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnos_hasta_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnosCerrados]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnos_hasta_2]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnos_hasta_2]  DEFAULT (NULL) FOR [hasta]
END


End
GO
/****** Object:  Default [DF_turnos_adelanto_2]    Script Date: 06/12/2013 23:34:29 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnos_adelanto_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnosCerrados]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnos_adelanto_2]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnos_adelanto_2]  DEFAULT ((0)) FOR [contabilizado]
END


End
GO
/****** Object:  Default [DF_turnosCerrados_pernocte]    Script Date: 06/12/2013 23:34:29 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnosCerrados_pernocte]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnosCerrados]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnosCerrados_pernocte]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnosCerrados_pernocte]  DEFAULT ((0)) FOR [pernocte]
END


End
GO
/****** Object:  Default [DF_turnosCerrados_descuentos]    Script Date: 06/12/2013 23:34:29 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnosCerrados_descuentos]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnosCerrados]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnosCerrados_descuentos]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnosCerrados] ADD  CONSTRAINT [DF_turnosCerrados_descuentos]  DEFAULT ((0)) FOR [descuentos]
END


End
GO
/****** Object:  Default [DF_socios_puntos]    Script Date: 06/12/2013 23:34:29 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_socios_puntos]') AND parent_object_id = OBJECT_ID(N'[dbo].[socios]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_socios_puntos]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[socios] ADD  CONSTRAINT [DF_socios_puntos]  DEFAULT ((0)) FOR [puntos]
END


End
GO
/****** Object:  Default [DF_socios_cantidadVisitas]    Script Date: 06/12/2013 23:34:29 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_socios_cantidadVisitas]') AND parent_object_id = OBJECT_ID(N'[dbo].[socios]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_socios_cantidadVisitas]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[socios] ADD  CONSTRAINT [DF_socios_cantidadVisitas]  DEFAULT ((0)) FOR [cantidadVisitas]
END


End
GO
/****** Object:  Default [DF_tarifas_duracion]    Script Date: 06/12/2013 23:34:29 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_tarifas_duracion]') AND parent_object_id = OBJECT_ID(N'[dbo].[tarifas]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_tarifas_duracion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tarifas] ADD  CONSTRAINT [DF_tarifas_duracion]  DEFAULT ((120)) FOR [duracion]
END


End
GO
/****** Object:  Default [DF_tarifas_pernocte]    Script Date: 06/12/2013 23:34:29 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_tarifas_pernocte]') AND parent_object_id = OBJECT_ID(N'[dbo].[tarifas]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_tarifas_pernocte]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tarifas] ADD  CONSTRAINT [DF_tarifas_pernocte]  DEFAULT ((0)) FOR [pernocte]
END


End
GO
/****** Object:  Default [DF_habitaciones_habilitada]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_habitaciones_habilitada]') AND parent_object_id = OBJECT_ID(N'[dbo].[habitaciones]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_habitaciones_habilitada]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_habilitada]  DEFAULT ((1)) FOR [habilitada]
END


End
GO
/****** Object:  Default [DF_habitaciones_categoria]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_habitaciones_categoria]') AND parent_object_id = OBJECT_ID(N'[dbo].[habitaciones]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_habitaciones_categoria]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_categoria]  DEFAULT ((1)) FOR [categoria]
END


End
GO
/****** Object:  Default [DF_habitaciones_estado]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_habitaciones_estado]') AND parent_object_id = OBJECT_ID(N'[dbo].[habitaciones]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_habitaciones_estado]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_estado]  DEFAULT ('D') FOR [estado]
END


End
GO
/****** Object:  Default [DF_habitaciones_fundas]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_habitaciones_fundas]') AND parent_object_id = OBJECT_ID(N'[dbo].[habitaciones]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_habitaciones_fundas]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_fundas]  DEFAULT ((0)) FOR [fundas]
END


End
GO
/****** Object:  Default [DF_habitaciones_sabanas]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_habitaciones_sabanas]') AND parent_object_id = OBJECT_ID(N'[dbo].[habitaciones]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_habitaciones_sabanas]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_sabanas]  DEFAULT ((0)) FOR [sabanas]
END


End
GO
/****** Object:  Default [DF_habitaciones_acolchado]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_habitaciones_acolchado]') AND parent_object_id = OBJECT_ID(N'[dbo].[habitaciones]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_habitaciones_acolchado]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_acolchado]  DEFAULT ((0)) FOR [acolchado]
END


End
GO
/****** Object:  Default [DF_habitaciones_toallas]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_habitaciones_toallas]') AND parent_object_id = OBJECT_ID(N'[dbo].[habitaciones]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_habitaciones_toallas]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_toallas]  DEFAULT ((0)) FOR [toallas]
END


End
GO
/****** Object:  Default [DF_habitaciones_toallones]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_habitaciones_toallones]') AND parent_object_id = OBJECT_ID(N'[dbo].[habitaciones]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_habitaciones_toallones]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_toallones]  DEFAULT ((0)) FOR [toallones]
END


End
GO
/****** Object:  Default [DF_habitaciones_batas]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_habitaciones_batas]') AND parent_object_id = OBJECT_ID(N'[dbo].[habitaciones]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_habitaciones_batas]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_batas]  DEFAULT ((0)) FOR [batas]
END


End
GO
/****** Object:  Default [DF_habitaciones_posSenializacion]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_habitaciones_posSenializacion]') AND parent_object_id = OBJECT_ID(N'[dbo].[habitaciones]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_habitaciones_posSenializacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[habitaciones] ADD  CONSTRAINT [DF_habitaciones_posSenializacion]  DEFAULT ((0)) FOR [posSenializacion]
END


End
GO
/****** Object:  Default [DF_gastos_contabilizado]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_gastos_contabilizado]') AND parent_object_id = OBJECT_ID(N'[dbo].[gastos]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_gastos_contabilizado]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[gastos] ADD  CONSTRAINT [DF_gastos_contabilizado]  DEFAULT ((0)) FOR [contabilizado]
END


End
GO
/****** Object:  Default [DF_cierresCaja_cantTA]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cierresCaja_cantTA]') AND parent_object_id = OBJECT_ID(N'[dbo].[cierresCaja]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cierresCaja_cantTA]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cierresCaja] ADD  CONSTRAINT [DF_cierresCaja_cantTA]  DEFAULT ((0)) FOR [cantTA]
END


End
GO
/****** Object:  Default [DF_cierresCaja_cantTC]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_cierresCaja_cantTC]') AND parent_object_id = OBJECT_ID(N'[dbo].[cierresCaja]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_cierresCaja_cantTC]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[cierresCaja] ADD  CONSTRAINT [DF_cierresCaja_cantTC]  DEFAULT ((0)) FOR [cantTC]
END


End
GO
/****** Object:  Default [DF_turnos_impHabitacion]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnos_impHabitacion]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnos_impHabitacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_impHabitacion]  DEFAULT ((0)) FOR [impHabitacion]
END


End
GO
/****** Object:  Default [DF_turnos_impArticulos]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnos_impArticulos]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnos_impArticulos]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_impArticulos]  DEFAULT ((0)) FOR [impArticulos]
END


End
GO
/****** Object:  Default [DF_turnos_impExtras]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnos_impExtras]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnos_impExtras]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_impExtras]  DEFAULT ((0)) FOR [impExtras]
END


End
GO
/****** Object:  Default [DF_turnos_efectivo]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnos_efectivo]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnos_efectivo]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_efectivo]  DEFAULT ((0)) FOR [efectivo]
END


End
GO
/****** Object:  Default [DF_turnos_tarjeta]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnos_tarjeta]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnos_tarjeta]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_tarjeta]  DEFAULT ((0)) FOR [tarjeta]
END


End
GO
/****** Object:  Default [DF_turnos_hasta]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnos_hasta]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnos_hasta]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_hasta]  DEFAULT (NULL) FOR [hasta]
END


End
GO
/****** Object:  Default [DF_turnos_descuentoAlCierre]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnos_descuentoAlCierre]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnos_descuentoAlCierre]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_descuentoAlCierre]  DEFAULT ((0)) FOR [descuentoAlCierre]
END


End
GO
/****** Object:  Default [DF_turnos_adelanto]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnos_adelanto]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnos_adelanto]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_adelanto]  DEFAULT ((0)) FOR [adelanto]
END


End
GO
/****** Object:  Default [DF_turnos_pernocte]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnos_pernocte]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnos_pernocte]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_pernocte]  DEFAULT ((0)) FOR [pernocte]
END


End
GO
/****** Object:  Default [DF_turnos_descHabitacion]    Script Date: 06/12/2013 23:34:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_turnos_descHabitacion]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_turnos_descHabitacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[turnos] ADD  CONSTRAINT [DF_turnos_descHabitacion]  DEFAULT ((0)) FOR [descHabitacion]
END


End
GO
/****** Object:  ForeignKey [FK_turnos_consumos_turnos_consumos]    Script Date: 06/12/2013 23:34:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_consumos_turnos_consumos]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos_consumos]'))
ALTER TABLE [dbo].[turnos_consumos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_consumos_turnos_consumos] FOREIGN KEY([articulo_id])
REFERENCES [dbo].[articulos] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_consumos_turnos_consumos]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos_consumos]'))
ALTER TABLE [dbo].[turnos_consumos] CHECK CONSTRAINT [FK_turnos_consumos_turnos_consumos]
GO
/****** Object:  ForeignKey [FK_formulaArt_articulos]    Script Date: 06/12/2013 23:34:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formulaArt_articulos]') AND parent_object_id = OBJECT_ID(N'[dbo].[articulosFormula]'))
ALTER TABLE [dbo].[articulosFormula]  WITH CHECK ADD  CONSTRAINT [FK_formulaArt_articulos] FOREIGN KEY([idArticuloBase])
REFERENCES [dbo].[articulos] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formulaArt_articulos]') AND parent_object_id = OBJECT_ID(N'[dbo].[articulosFormula]'))
ALTER TABLE [dbo].[articulosFormula] CHECK CONSTRAINT [FK_formulaArt_articulos]
GO
/****** Object:  ForeignKey [FK_formulaArt_articulos1]    Script Date: 06/12/2013 23:34:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formulaArt_articulos1]') AND parent_object_id = OBJECT_ID(N'[dbo].[articulosFormula]'))
ALTER TABLE [dbo].[articulosFormula]  WITH CHECK ADD  CONSTRAINT [FK_formulaArt_articulos1] FOREIGN KEY([idArticuloComponente])
REFERENCES [dbo].[articulos] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formulaArt_articulos1]') AND parent_object_id = OBJECT_ID(N'[dbo].[articulosFormula]'))
ALTER TABLE [dbo].[articulosFormula] CHECK CONSTRAINT [FK_formulaArt_articulos1]
GO
/****** Object:  ForeignKey [FK_habitaciones_categorias]    Script Date: 06/12/2013 23:34:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_habitaciones_categorias]') AND parent_object_id = OBJECT_ID(N'[dbo].[habitaciones]'))
ALTER TABLE [dbo].[habitaciones]  WITH CHECK ADD  CONSTRAINT [FK_habitaciones_categorias] FOREIGN KEY([categoria])
REFERENCES [dbo].[categorias] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_habitaciones_categorias]') AND parent_object_id = OBJECT_ID(N'[dbo].[habitaciones]'))
ALTER TABLE [dbo].[habitaciones] CHECK CONSTRAINT [FK_habitaciones_categorias]
GO
/****** Object:  ForeignKey [FK_gastos_conserjes]    Script Date: 06/12/2013 23:34:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gastos_conserjes]') AND parent_object_id = OBJECT_ID(N'[dbo].[gastos]'))
ALTER TABLE [dbo].[gastos]  WITH CHECK ADD  CONSTRAINT [FK_gastos_conserjes] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gastos_conserjes]') AND parent_object_id = OBJECT_ID(N'[dbo].[gastos]'))
ALTER TABLE [dbo].[gastos] CHECK CONSTRAINT [FK_gastos_conserjes]
GO
/****** Object:  ForeignKey [FK_gastos_cuentasgastos]    Script Date: 06/12/2013 23:34:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gastos_cuentasgastos]') AND parent_object_id = OBJECT_ID(N'[dbo].[gastos]'))
ALTER TABLE [dbo].[gastos]  WITH CHECK ADD  CONSTRAINT [FK_gastos_cuentasgastos] FOREIGN KEY([cuentaGastoId])
REFERENCES [dbo].[cuentasGastos] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gastos_cuentasgastos]') AND parent_object_id = OBJECT_ID(N'[dbo].[gastos]'))
ALTER TABLE [dbo].[gastos] CHECK CONSTRAINT [FK_gastos_cuentasgastos]
GO
/****** Object:  ForeignKey [FK_auditoria_conserjes]    Script Date: 06/12/2013 23:34:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_auditoria_conserjes]') AND parent_object_id = OBJECT_ID(N'[dbo].[auditoria]'))
ALTER TABLE [dbo].[auditoria]  WITH CHECK ADD  CONSTRAINT [FK_auditoria_conserjes] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_auditoria_conserjes]') AND parent_object_id = OBJECT_ID(N'[dbo].[auditoria]'))
ALTER TABLE [dbo].[auditoria] CHECK CONSTRAINT [FK_auditoria_conserjes]
GO
/****** Object:  ForeignKey [FK_cierres_conserjes]    Script Date: 06/12/2013 23:34:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cierres_conserjes]') AND parent_object_id = OBJECT_ID(N'[dbo].[cierresCaja]'))
ALTER TABLE [dbo].[cierresCaja]  WITH CHECK ADD  CONSTRAINT [FK_cierres_conserjes] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cierres_conserjes]') AND parent_object_id = OBJECT_ID(N'[dbo].[cierresCaja]'))
ALTER TABLE [dbo].[cierresCaja] CHECK CONSTRAINT [FK_cierres_conserjes]
GO
/****** Object:  ForeignKey [FK_habitaciones_turnos]    Script Date: 06/12/2013 23:34:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_habitaciones_turnos]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_habitaciones_turnos] FOREIGN KEY([nroHabitacion])
REFERENCES [dbo].[habitaciones] ([nroHabitacion])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_habitaciones_turnos]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_habitaciones_turnos]
GO
/****** Object:  ForeignKey [FK_habitaciones_turnos_2]    Script Date: 06/12/2013 23:34:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_habitaciones_turnos_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_habitaciones_turnos_2] FOREIGN KEY([nroHabitacion])
REFERENCES [dbo].[habitaciones] ([nroHabitacion])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_habitaciones_turnos_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_habitaciones_turnos_2]
GO
/****** Object:  ForeignKey [FK_turnos_conserjes]    Script Date: 06/12/2013 23:34:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_conserjes]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_conserjes] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_conserjes]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_conserjes]
GO
/****** Object:  ForeignKey [FK_turnos_conserjes_2]    Script Date: 06/12/2013 23:34:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_conserjes_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_conserjes_2] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_conserjes_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_conserjes_2]
GO
/****** Object:  ForeignKey [FK_turnos_descuentos]    Script Date: 06/12/2013 23:34:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_descuentos]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_descuentos] FOREIGN KEY([descuentoId])
REFERENCES [dbo].[descuentos] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_descuentos]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_descuentos]
GO
/****** Object:  ForeignKey [FK_turnos_descuentos_2]    Script Date: 06/12/2013 23:34:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_descuentos_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_descuentos_2] FOREIGN KEY([descuentoId])
REFERENCES [dbo].[descuentos] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_descuentos_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_descuentos_2]
GO
/****** Object:  ForeignKey [FK_turnos_mediosDePago]    Script Date: 06/12/2013 23:34:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_mediosDePago]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_mediosDePago] FOREIGN KEY([tipoTarjeta])
REFERENCES [dbo].[mediosDePago] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_mediosDePago]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_mediosDePago]
GO
