USE [GD2C2019]
GO
/****** Object:  Table [gd_esquema].[Maestra]    Script Date: 09/09/2019 1:43:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE SCHEMA [NO_SRTA_E_GATOREI] AUTHORIZATION [gdCupon2019]
GO
create table [NO_SRTA_E_GATOREI].[PERMISOS](
	[PERMISO_ID] int IDENTITY(1,1) primary key,
	[PERMISO_DESC] [nvarchar](255) not null,
	[PERMISO_CLAVE] [nvarchar](255) not null
) ON [PRIMARY]
GO
create table [NO_SRTA_E_GATOREI].[ROLES](
		[ROL_ID] int IDENTITY(1,1) primary key,
		[NOMBRE] [nvarchar](100) not null,
		[BAJA_LOGICA] [bit] not null default 0
) ON [PRIMARY]
GO
create table [NO_SRTA_E_GATOREI].[PERMISOS_ROLES](
	[ROL_ID] int foreign KEY REFERENCES [NO_SRTA_E_GATOREI].[ROLES](ROL_ID) not null,
	[PERMISO_ID] int foreign KEY REFERENCES [NO_SRTA_E_GATOREI].[PERMISOS](PERMISO_ID) not null
) ON [PRIMARY]
GO
create table [NO_SRTA_E_GATOREI].[USUARIOS](
	[USUARIO_ID] int IDENTITY(1,1) primary key,
	[USERNAME] [nvarchar](250) unique not null,
	[PASSWORD] [nvarchar](250) not null,
	[TIPO_USUARIO] [nvarchar](250),
	[MAXIMO_OFERTAS] int not null default 0,
	[BAJA_LOGICA] [BIT] not null default 0,
	[LOGIN_FALLIDO] int not null default 0
) ON [PRIMARY]
GO
create table [NO_SRTA_E_GATOREI].[USUARIOS_ROLES](
	[ROL_ID] int foreign KEY REFERENCES [NO_SRTA_E_GATOREI].[ROLES](ROL_ID) not null,
	[USUARIO_ID] int foreign KEY REFERENCES [NO_SRTA_E_GATOREI].[USUARIOS](USUARIO_ID) not null
) ON [PRIMARY]
GO
create table [NO_SRTA_E_GATOREI].[DIRECCIONES](
	[DIRECCION_ID] int IDENTITY(1,1) primary key,
	[DIRECCION] [nvarchar](255) not null,
	[CIUDAD] [nvarchar](255) not null,
	[CODIGO_POSTAL] [numeric](4,0) default 0	
) ON [PRIMARY]
GO
create table [NO_SRTA_E_GATOREI].[CLIENTES](
	[CLIENTE_ID] int IDENTITY(1,1) primary key,
	[DNI] [numeric](18, 0) unique not null,
	[NOMBRE] [nvarchar](255) not null,
	[APELLIDO] [nvarchar](255) not null,
	[MAIL] [nvarchar](255) not null,
	[TELEFONO] [numeric](18, 0) not null,
	[FECHA_NACIMIENTO] [DATETIME] not null,
	[USUARIO_ID] int foreign key REFERENCES [NO_SRTA_E_GATOREI].[USUARIOS](USUARIO_ID),
	[DIRECCION_ID] int not null foreign key REFERENCES [NO_SRTA_E_GATOREI].[DIRECCIONES](DIRECCION_ID)
) ON [PRIMARY]
GO
create table [NO_SRTA_E_GATOREI].[PROVEEDORES](
	[PROVEEDOR_ID] int IDENTITY(1,1) primary key,
	[CUIT] [nvarchar](20) unique not null,
	[RAZON_SOCIAL] [nvarchar](255) unique not null,
	[NOMBRE_CONTACTO] [nvarchar](255),
	[RUBRO] [nvarchar](100) not null,
	[MAIL] [nvarchar](255) ,
	[TELEFONO] [numeric](18, 0) not null,
	[USUARIO_ID] int foreign key REFERENCES [NO_SRTA_E_GATOREI].[USUARIOS](USUARIO_ID),
	[DIRECCION_ID] int not null foreign key REFERENCES [NO_SRTA_E_GATOREI].[DIRECCIONES](DIRECCION_ID)
) ON [PRIMARY]
GO
create table [NO_SRTA_E_GATOREI].[TARJETAS](
	[TARJETA_ID] int IDENTITY(1,1) primary key,
	[TITULAR] [nvarchar](255) not null,
	[FECHA_VENCIMIENTO] [nvarchar](5) not null
) ON [PRIMARY]
GO
create table [NO_SRTA_E_GATOREI].[CREDITOS](
	[CREDITO_ID] int IDENTITY(1,1) primary key,
	[FECHA] datetime not null,
	[TIPO_PAGO] [nvarchar](100) not null,
	[MONTO] [numeric](18, 2) not null,
	[CLIENTE_ID] int not null foreign key REFERENCES [NO_SRTA_E_GATOREI].[CLIENTES](CLIENTE_ID),
	[TARJETA_ID] int not null foreign key REFERENCES [NO_SRTA_E_GATOREI].[TARJETAS](TARJETA_ID)
) ON [PRIMARY]
GO
create table [NO_SRTA_E_GATOREI].[OFERTAS](
	[OFERTA_ID] int IDENTITY(1,1) primary key,
	[PRECIO_LISTA] [numeric](18, 2) NULL,
	[PRECIO_OFERTA] [numeric](18, 2) NULL,
	[FECHA_PUBLICACION] [datetime] NULL,
	[FECHA_VENCIMIENDO] [datetime] NULL,
	[CANTIDAD] [numeric](18, 0) NULL,
	[DESCRIPCION] [nvarchar](255) NULL,
	[FECHA_COMPRA] [datetime],
	[CODIGO] [nvarchar](50),
	[ENTREGADO] [datetime]
) ON [PRIMARY]
GO
create table [NO_SRTA_E_GATOREI].[CONSUMOS_CUPONES](
	[CONSUMO_CUPON_ID] int IDENTITY(1,1) primary key,
	[OFERTA_ID] int not null foreign key REFERENCES [NO_SRTA_E_GATOREI].[OFERTAS](OFERTA_ID),
	[CLIENTE_ID] int not null foreign key REFERENCES [NO_SRTA_E_GATOREI].[CLIENTES](CLIENTE_ID),
	[FECHA_CONSUMO] [datetime] not null
) ON [PRIMARY]
GO
create table [NO_SRTA_E_GATOREI].[COMPRAS](
	[COMPRA_ID] int IDENTITY(1,1) primary key,
	[OFERTA_ID] int not null foreign key REFERENCES [NO_SRTA_E_GATOREI].[OFERTAS](OFERTA_ID),
	[CLIENTE_ID] int not null foreig,0)
) ON [PRIMARY]
GO
create table [NO_SRTA_E_GATOREI].[FACTURAS_COMPRAS](
	[FACTURA_ID] int not null foreign key REFERENCES [NO_SRTA_E_GATOREI].[FACTURAS](FACTURA_ID),
	[COMPRA_ID] int not null foreign key REFERENCES [NO_SRTA_E_GATOREI].[COMPRAS](COMPRA_ID)
) ON [PRIMARY] n key REFERENCES [NO_SRTA_E_GATOREI].[CLIENTES](CLIENTE_ID),
	[FECHA_COMPRA] [datetime] not null
) ON [PRIMARY]
GO
create table [NO_SRTA_E_GATOREI].[FACTURAS](
	[FACTURA_ID] int IDENTITY(1,1) primary key,
	[IMPORTE] [numeric](1
GO