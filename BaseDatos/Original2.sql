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
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
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
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[avisos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[avisos](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[mensaje] [varchar](30) NULL,
 CONSTRAINT [PK_mensajesAlarma] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
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
	[hora] [smallint] NOT NULL,
 CONSTRAINT [PK_turnos_avisos] PRIMARY KEY CLUSTERED 
(
	[turnoId] ASC,
	[avisoId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OpcionesAsignarHabitacion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OpcionesAsignarHabitacion](
	[id] [int] NOT NULL,
	[Detalles del Turno] [varchar](50) NULL,
 CONSTRAINT [PK_OpcionesAsignarHabitacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
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
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
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








	









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tarifas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tarifas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[catId] [int] NOT NULL,
	[catOriginalId] [int] NULL,
	[desde] [datetime] NOT NULL,
	[hasta] [datetime] NOT NULL,
	[dia] [int] NOT NULL,
	[duracion] [int] NOT NULL CONSTRAINT [DF_tarifas_duracion]  DEFAULT ((120)),
	[precio] [decimal](6, 2) NOT NULL,
	[precioMinuto]  AS (CONVERT([decimal](10,2),[precio]/[duracion],0)),
	[extension] [int] NULL,
	[precioTN] [decimal](6, 2) NULL,
	[extensionPrecio] [decimal](6, 2) NULL,
	[minAlarma] [smallint] NULL,
	[pernocte] [bit] NULL CONSTRAINT [DF_tarifas_pernocte]  DEFAULT ((0)),
 CONSTRAINT [PK_tarifas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categorias]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[categorias](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[alias] [nchar](4) NULL,
 CONSTRAINT [PK_categorias] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[parametros]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[parametros](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](25) NULL,
	[val1] [int] NULL,
 CONSTRAINT [PK_parametros] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[articulos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[stockActual] [int] NOT NULL,
	[stockRecomendado] [int] NOT NULL,
	[precio] [decimal](8, 2) NOT NULL,
	[tipoArticulo] [char](1) NULL,
	[esPromo] [bit] NULL,
 CONSTRAINT [PK_articulos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_articulos] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[descontarArticulosCompuestos]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[descontarArticulosCompuestos]
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



' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[socios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[socios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nroSocio] [int] NOT NULL,
	[puntos] [int] NOT NULL CONSTRAINT [DF_socios_puntos]  DEFAULT ((0)),
	[fechaAltaSocio] [datetime] NULL,
	[fechaVencimientoPuntaje] [datetime] NULL,
	[cantidadVisitas] [smallint] NULL CONSTRAINT [DF_socios_cantidadVisitas]  DEFAULT ((0)),
 CONSTRAINT [PK_socios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_socios] UNIQUE NONCLUSTERED 
(
	[nroSocio] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[estadoHabitacion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[estadoHabitacion](
	[id] [smallint] NOT NULL,
	[estado] [char](1) NOT NULL,
	[descripcion] [varchar](15) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mediosDePago]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[mediosDePago](
	[id] [tinyint] NOT NULL,
	[nombre] [varchar](20) NULL,
 CONSTRAINT [PK_mediosDePago] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[turnosCerrados]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[turnosCerrados](
	[id] [int] NOT NULL,
	[impHabitacion] [decimal](8, 2) NOT NULL CONSTRAINT [DF_turnos_impHabitacion_2]  DEFAULT ((0)),
	[impArticulos] [decimal](8, 2) NOT NULL CONSTRAINT [DF_turnos_impArticulos_2]  DEFAULT ((0)),
	[impExtras] [decimal](8, 2) NOT NULL CONSTRAINT [DF_turnosCerrados_impExtras]  DEFAULT ((0)),
	[descuentoAlCierre] [decimal](6, 2) NULL CONSTRAINT [DF_turnosCerrados_descuentoAlCierre]  DEFAULT ((0)),
	[efectivo] [decimal](8, 2) NULL,
	[tarjeta] [decimal](8, 2) NULL,
	[tipoTarjeta] [smallint] NULL,
	[desde] [datetime] NOT NULL,
	[hasta] [datetime] NULL CONSTRAINT [DF_turnos_hasta_2]  DEFAULT (NULL),
	[nroHabitacion] [int] NOT NULL,
	[aliasCat] [nchar](4) NOT NULL,
	[horaCierre] [datetime] NULL,
	[socioId] [int] NULL,
	[descuentoId] [int] NULL,
	[puntos] [int] NULL,
	[conserjeId] [int] NULL,
	[adelanto] [bit] NOT NULL CONSTRAINT [DF_turnos_adelanto_2]  DEFAULT ((0)),
	[cancelado] [bit] NULL,
	[pernocte] [bit] NOT NULL CONSTRAINT [DF_turnosCerrados_pernocte]  DEFAULT ((0)),
 CONSTRAINT [PK_turnos_2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[conserjes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[conserjes](
	[usuario] [int] NOT NULL,
	[nombre] [nvarchar](20) NOT NULL,
	[apellido] [nvarchar](20) NOT NULL,
	[clave] [int] NOT NULL,
	[logueado] [bit] NOT NULL CONSTRAINT [DF_conserjes_logueado]  DEFAULT ((0)),
 CONSTRAINT [PK_conserjes] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gastos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gastos](
	[gasto_id] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[conserjeId] [int] NOT NULL,
	[cuentaGastoId] [int] NOT NULL,
	[monto] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_gastos] PRIMARY KEY CLUSTERED 
(
	[gasto_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[turnos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[turnos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[impHabitacion] [decimal](8, 2) NOT NULL CONSTRAINT [DF_turnos_impHabitacion]  DEFAULT ((0)),
	[impArticulos] [decimal](8, 2) NOT NULL CONSTRAINT [DF_turnos_impArticulos]  DEFAULT ((0)),
	[impExtras] [decimal](8, 2) NOT NULL CONSTRAINT [DF_turnos_impExtras]  DEFAULT ((0)),
	[efectivo] [decimal](8, 2) NULL CONSTRAINT [DF_turnos_efectivo]  DEFAULT ((0)),
	[tarjeta] [decimal](8, 2) NULL CONSTRAINT [DF_turnos_tarjeta]  DEFAULT ((0)),
	[tipoTarjeta] [tinyint] NULL,
	[desde] [datetime] NOT NULL,
	[hasta] [datetime] NULL CONSTRAINT [DF_turnos_hasta]  DEFAULT (NULL),
	[nroHabitacion] [int] NOT NULL,
	[aliasCat] [nchar](4) NOT NULL,
	[socioId] [int] NULL,
	[descuentoId] [int] NULL,
	[descuentoAlCierre] [decimal](8, 2) NULL CONSTRAINT [DF_turnos_descuentoAlCierre]  DEFAULT ((0)),
	[puntos] [int] NULL,
	[conserjeId] [int] NULL,
	[adelanto] [bit] NOT NULL CONSTRAINT [DF_turnos_adelanto]  DEFAULT ((0)),
	[pernocte] [bit] NOT NULL CONSTRAINT [DF_turnos_pernocte]  DEFAULT ((0)),
	[alarma] [datetime] NULL,
	[tarifaId] [int] NULL,
 CONSTRAINT [PK_turnos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_turnos] UNIQUE NONCLUSTERED 
(
	[nroHabitacion] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulos_menues]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[articulos_menues](
	[menuId] [int] NOT NULL,
	[articuloId] [int] NOT NULL,
	[cantidadArticulos] [smallint] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[habitaciones]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[habitaciones](
	[id] [int] NOT NULL,
	[nroHabitacion] [int] NOT NULL,
	[habilitada] [bit] NOT NULL CONSTRAINT [DF_habitaciones_habilitada]  DEFAULT ((1)),
	[categoria] [int] NOT NULL CONSTRAINT [DF_habitaciones_categoria]  DEFAULT ((1)),
	[estado] [char](1) NOT NULL CONSTRAINT [DF_habitaciones_estado]  DEFAULT ('D'),
 CONSTRAINT [PK_habitaciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_habitaciones] UNIQUE NONCLUSTERED 
(
	[nroHabitacion] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
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
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
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
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cierresCaja]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[cierresCaja](
	[id] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[totEfectivo] [decimal](8, 2) NOT NULL CONSTRAINT [DF_cierres_totEfectivo]  DEFAULT ((0)),
	[totTarjeta] [decimal](8, 2) NOT NULL CONSTRAINT [DF_cierres_totTarjeta]  DEFAULT ((0)),
	[conserjeId] [int] NOT NULL,
 CONSTRAINT [PK_cierres] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
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
	[conserjeId] [int] NOT NULL,
 CONSTRAINT [PK_auditoria] PRIMARY KEY CLUSTERED 
(
	[auditoria_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[habitacion_obtenerAlarmas]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[habitacion_obtenerAlarmas]

AS
	
	select a.id,nroHabitacion,a.mensaje from turnos_avisos ta 
	left join avisos as a on ta.avisoId = a.id
	left join turnos as t on ta.turnoId = t.id
	where ta.hora = convert(int, dbo.hora_mm(getdate()))

	








	










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipoDescuentos_getAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[tipoDescuentos_getAll]
@nroHab int    
AS
BEGIN
	SET NOCOUNT ON;
	Declare @catId int
	Select @catId=categoria from habitaciones where nroHabitacion = @nroHab

	select distinct td.* from tipoDescuentos as td 
	left join descuentos as d on td.tipoDescuentoid = d.tipoDescuento
	left join tarifas as t on d.tarifaId = t.id
	
	where tipoDescuentoId <> 4 or 
	(d.tarifaId is not null and t.catOriginalId = @catId )
end


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[avisos_obtenerPorHabitacion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create PROCEDURE [dbo].[avisos_obtenerPorHabitacion]
@nroHab  as int
AS	
	select a.id, a.mensaje,ta.hora from turnos_avisos ta 
	left join avisos as a on ta.avisoId = a.id
	left join turnos as t on ta.turnoId = t.id
	where t.nroHabitacion = @nroHab







	










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[avisos_asignar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create PROCEDURE [dbo].[avisos_asignar]	
    @nroHab int,@hora int,@avisoId int
AS

	SET NOCOUNT ON;
	declare @turnoId int;
	

	select @turnoId=id from turnos where nroHabitacion=@nroHab

	insert into turnos_avisos (turnoId,avisoId,hora) values(@turnoId,@avisoId,@hora)

	



	










' 
END
GO
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
	select h.nroHabitacion,cat.alias as categoria, t.aliasCat as categoria2, habilitada,h.estado,t.hasta as hsalida,t.impHabitacion + t.impExtras + t.impArticulos-t.Efectivo-Tarjeta as importe,ta.turnoId as aviso 
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Descuentos_getAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[Descuentos_getAll]
@nroHab int    
AS
BEGIN
	SET NOCOUNT ON;
	Declare @catId int
	Select @catId=categoria from habitaciones where nroHabitacion = @nroHab

	select d.* from descuentos as d 
	left join tarifas as t on d.tarifaId = t.id
	
	where d.tarifaId is null 
	or (d.tarifaId is not null and t.catOriginalId = @catId )
end




' 
END
GO
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
	
	select t.impHabitacion + t.impExtras + t.impArticulos - efectivo - tarjeta as impHabitacion,nroSocio,pernocte,t.puntos,descuentoId ,d.nombre
	from turnos t left join socios s on t.socioId=s.id 
	left join descuentos d on d.id = t.descuentoId
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[asignarHabitacionTurnoNoche]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[asignarHabitacionTurnoNoche]	
    @nroHab int,@precioTotal decimal(8,2),@precioExtras decimal(8,2),@hasta datetime,@descuentoId int=null,@conserjeId int,@socioId int = null,@puntos int=null,@tarifaId2 int
AS
BEGIN TRY
begin transaction asignar
	SET NOCOUNT ON;
	
	declare @catId int
	declare @catAlias nvarchar(4)	
	Declare @tarifaId int

	update habitaciones set estado=''A'' where nroHabitacion = @nroHab
	select @catId = categoria from habitaciones where nroHabitacion = @nroHab

	SELECT * Into tablaAux FROM tarifas WHERE 1=2
	select @tarifaId = tarifaId from descuentos where id = @descuentoId 
	if @tarifaId is not null 
	BEGIN
		set @tarifaId2 = @tarifaId
		insert into tablaAux select catId,catOriginalId, desde, hasta, dia, duracion, precio, extension, precioTN,extensionPrecio,minAlarma
		FROM tarifas where id = @tarifaId
		select @catId = catId from tablaAux 
	END
	
	select @catAlias = alias from categorias where id = @catId	

	-- Aplicar descuentos de plata --
		if(@descuentoId is not null)
		BEGIN
			if((select 1 from descuentos where id = @descuentoId and descuentoFijo is not null) is not null)
			BEGIN
				set @precioTotal = @precioTotal - (select descuentoFijo from descuentos where id = @descuentoId);
			END
			if((select 1 from descuentos where id = @descuentoId and descuentoPorcentaje is not null) is not null)
			BEGIN
				set @precioTotal = @precioTotal * (1- ((select descuentoPorcentaje from descuentos where id = @descuentoId)/100.00))
			END
		END
		---------------------------------

	
	BEGIN		
		insert into turnos ( impHabitacion, impExtras, desde, hasta, nroHabitacion, aliasCat,conserjeId,socioId,descuentoId,puntos,pernocte,tarifaId)
		values (@precioTotal,@precioExtras, getdate(),@hasta,@nroHab,@catAlias,@conserjeId,@socioId,@descuentoId,@puntos,1,@tarifaId2) 
	END
	
	drop table tablaAux
COMMIT TRAN asignar
END TRY
BEGIN CATCH
	SELECT 
          ERROR_NUMBER() as ErrorNumber,
          ERROR_MESSAGE() as ErrorMessage;
	rollback tran asignar
END CATCH



	











' 
END
GO
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
	
	select impHabitacion,impArticulos,impExtras,@totalDescontar,efectivo,tarjeta as descPromo,ta.precio as PrecioOriginal from turnos t join tarifas as ta on t.tarifaId=ta.id
	where t.id=@turnoId
		
	commit transaction
end try
begin catch
	rollback transaction
end catch





' 
END
GO
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[turnos_cerrar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE procedure [dbo].[turnos_cerrar]
@nroHab as int,@descuento as decimal (6,2),@descPorArt as decimal(6,2), @medioPago as int
as
begin try
begin transaction
	declare @turnoId int
		
	select  @turnoId = id from turnos  where nroHabitacion=@nroHab
	update turnos set impArticulos=impArticulos-@descPorArt where id=@turnoId

	insert into turnosCerrados ( id, impHabitacion, impArticulos,impExtras, efectivo, tarjeta, tipoTarjeta, desde, hasta, nroHabitacion, aliasCat, horaCierre, socioId, descuentoId, descuentoAlCierre, puntos, 
                      conserjeId, adelanto, cancelado, pernocte)
	(select  id, impHabitacion, impArticulos, impExtras, efectivo, tarjeta, tipoTarjeta, desde, hasta, nroHabitacion, aliasCat,GETDATE() ,socioId, descuentoId, @descuento, puntos, 
                      conserjeId, adelanto,0, pernocte
		from turnos where nroHabitacion=@nroHab)

	if(@medioPago>0)
	begin
		update turnosCerrados set tarjeta=tarjeta+(impHabitacion+impArticulos+impExtras-efectivo-tarjeta-@descuento),tipoTarjeta=@medioPago 
		where id=@turnoId
		
	end
	else
		update turnosCerrados set efectivo=efectivo+(impHabitacion+impArticulos+impExtras-efectivo-tarjeta-@descuento) where id=@turnoId

	update habitaciones set estado = ''M'' where nroHabitacion = @nroHab

	delete from turnos where nroHabitacion = @nroHab
	
	commit transaction
end try
begin catch
	rollback transaction
end catch




' 
END
GO
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
		update turnos set tarjeta = tarjeta + @monto,tipoTarjeta = @medioPago
		where nroHabitacion = @nroHab 
	else
		update turnos set efectivo = efectivo + @monto
		where nroHabitacion = @nroHab




' 
END
GO
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
	
	insert into turnosCerrados (id, impHabitacion, impArticulos, efectivo, tarjeta,tipoTarjeta, desde, hasta, nroHabitacion, aliasCat,socioId, descuentoId, puntos,conserjeId, adelanto, horaCierre, cancelado, pernocte) 
		select id,impHabitacion, impArticulos, efectivo, tarjeta,tipoTarjeta, desde, hasta, nroHabitacion, aliasCat,socioId, descuentoId, puntos,conserjeId,adelanto,getdate(),1,pernocte  from turnos where nroHabitacion = @nroHab
	
	update habitaciones set estado = ''D'' where nroHabitacion = @nroHab
	
	delete turnos where nroHabitacion = @nroHab
	
	if(@socioId is not null and @puntos > 0)
		update socios set puntos = puntos + @puntos where id = @socioId


	
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[conserjeLogin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[conserjeLogin]	
    (@usuario int, @clave int)
AS
BEGIN
	SET NOCOUNT ON;

	select * from conserjes where usuario = @usuario and clave = @clave;
	if(@@rowcount>0)
		update conserjes set logueado = 1 where usuario = @usuario


END
	


' 
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gastos_conserjes]') AND parent_object_id = OBJECT_ID(N'[dbo].[gastos]'))
ALTER TABLE [dbo].[gastos]  WITH CHECK ADD  CONSTRAINT [FK_gastos_conserjes] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
ALTER TABLE [dbo].[gastos] CHECK CONSTRAINT [FK_gastos_conserjes]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gastos_cuentasgastos]') AND parent_object_id = OBJECT_ID(N'[dbo].[gastos]'))
ALTER TABLE [dbo].[gastos]  WITH CHECK ADD  CONSTRAINT [FK_gastos_cuentasgastos] FOREIGN KEY([cuentaGastoId])
REFERENCES [dbo].[cuentasGastos] ([id])
GO
ALTER TABLE [dbo].[gastos] CHECK CONSTRAINT [FK_gastos_cuentasgastos]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_habitaciones_turnos]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_habitaciones_turnos] FOREIGN KEY([nroHabitacion])
REFERENCES [dbo].[habitaciones] ([nroHabitacion])
GO
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_habitaciones_turnos]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_habitaciones_turnos_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_habitaciones_turnos_2] FOREIGN KEY([nroHabitacion])
REFERENCES [dbo].[habitaciones] ([nroHabitacion])
GO
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_habitaciones_turnos_2]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_conserjes]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_conserjes] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_conserjes]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_conserjes_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_conserjes_2] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_conserjes_2]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_descuentos]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_descuentos] FOREIGN KEY([descuentoId])
REFERENCES [dbo].[descuentos] ([id])
GO
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_descuentos]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_descuentos_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_descuentos_2] FOREIGN KEY([descuentoId])
REFERENCES [dbo].[descuentos] ([id])
GO
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_descuentos_2]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_mediosDePago]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos]'))
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_mediosDePago] FOREIGN KEY([tipoTarjeta])
REFERENCES [dbo].[mediosDePago] ([id])
GO
ALTER TABLE [dbo].[turnos] CHECK CONSTRAINT [FK_turnos_mediosDePago]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_articulos_menues_articulos]') AND parent_object_id = OBJECT_ID(N'[dbo].[articulos_menues]'))
ALTER TABLE [dbo].[articulos_menues]  WITH CHECK ADD  CONSTRAINT [FK_articulos_menues_articulos] FOREIGN KEY([articuloId])
REFERENCES [dbo].[articulos] ([id])
GO
ALTER TABLE [dbo].[articulos_menues] CHECK CONSTRAINT [FK_articulos_menues_articulos]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_articulos_menues_menues]') AND parent_object_id = OBJECT_ID(N'[dbo].[articulos_menues]'))
ALTER TABLE [dbo].[articulos_menues]  WITH CHECK ADD  CONSTRAINT [FK_articulos_menues_menues] FOREIGN KEY([menuId])
REFERENCES [dbo].[menues] ([id])
GO
ALTER TABLE [dbo].[articulos_menues] CHECK CONSTRAINT [FK_articulos_menues_menues]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_descuentos_descuentos]') AND parent_object_id = OBJECT_ID(N'[dbo].[descuentos]'))
ALTER TABLE [dbo].[descuentos]  WITH CHECK ADD  CONSTRAINT [FK_descuentos_descuentos] FOREIGN KEY([tarifaId])
REFERENCES [dbo].[tarifas] ([id])
GO
ALTER TABLE [dbo].[descuentos] CHECK CONSTRAINT [FK_descuentos_descuentos]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_habitaciones_categorias]') AND parent_object_id = OBJECT_ID(N'[dbo].[habitaciones]'))
ALTER TABLE [dbo].[habitaciones]  WITH CHECK ADD  CONSTRAINT [FK_habitaciones_categorias] FOREIGN KEY([categoria])
REFERENCES [dbo].[categorias] ([id])
GO
ALTER TABLE [dbo].[habitaciones] CHECK CONSTRAINT [FK_habitaciones_categorias]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_turnos_consumos_turnos_consumos]') AND parent_object_id = OBJECT_ID(N'[dbo].[turnos_consumos]'))
ALTER TABLE [dbo].[turnos_consumos]  WITH CHECK ADD  CONSTRAINT [FK_turnos_consumos_turnos_consumos] FOREIGN KEY([articulo_id])
REFERENCES [dbo].[articulos] ([id])
GO
ALTER TABLE [dbo].[turnos_consumos] CHECK CONSTRAINT [FK_turnos_consumos_turnos_consumos]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formulaArt_articulos]') AND parent_object_id = OBJECT_ID(N'[dbo].[articulosFormula]'))
ALTER TABLE [dbo].[articulosFormula]  WITH CHECK ADD  CONSTRAINT [FK_formulaArt_articulos] FOREIGN KEY([idArticuloBase])
REFERENCES [dbo].[articulos] ([id])
GO
ALTER TABLE [dbo].[articulosFormula] CHECK CONSTRAINT [FK_formulaArt_articulos]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formulaArt_articulos1]') AND parent_object_id = OBJECT_ID(N'[dbo].[articulosFormula]'))
ALTER TABLE [dbo].[articulosFormula]  WITH CHECK ADD  CONSTRAINT [FK_formulaArt_articulos1] FOREIGN KEY([idArticuloComponente])
REFERENCES [dbo].[articulos] ([id])
GO
ALTER TABLE [dbo].[articulosFormula] CHECK CONSTRAINT [FK_formulaArt_articulos1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cierres_conserjes]') AND parent_object_id = OBJECT_ID(N'[dbo].[cierresCaja]'))
ALTER TABLE [dbo].[cierresCaja]  WITH CHECK ADD  CONSTRAINT [FK_cierres_conserjes] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
ALTER TABLE [dbo].[cierresCaja] CHECK CONSTRAINT [FK_cierres_conserjes]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_auditoria_conserjes]') AND parent_object_id = OBJECT_ID(N'[dbo].[auditoria]'))
ALTER TABLE [dbo].[auditoria]  WITH CHECK ADD  CONSTRAINT [FK_auditoria_conserjes] FOREIGN KEY([conserjeId])
REFERENCES [dbo].[conserjes] ([usuario])
GO
ALTER TABLE [dbo].[auditoria] CHECK CONSTRAINT [FK_auditoria_conserjes]
