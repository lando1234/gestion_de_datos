	USE [GD2C2019]
	GO
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE SCHEMA [NO_SRTA_E_GATOREI] AUTHORIZATION [GDCUPON2019]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[PERMISOS](
		[PERMISO_ID] INT IDENTITY(1,1) PRIMARY KEY,
		[PERMISO_DESC] [NVARCHAR](255) NOT NULL,
		[PERMISO_CLAVE] [NVARCHAR](255) NOT NULL
	) ON [PRIMARY]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[ROLES](
			[ROL_ID] INT IDENTITY(1,1) PRIMARY KEY,
			[NOMBRE] [NVARCHAR](100) UNIQUE NOT NULL,
			[BAJA_LOGICA] [BIT] NOT NULL DEFAULT 0
	) ON [PRIMARY]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[PERMISOS_ROLES](
		[ROL_ID] INT FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[ROLES](ROL_ID) NOT NULL,
		[PERMISO_ID] INT FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[PERMISOS](PERMISO_ID) NOT NULL
	) ON [PRIMARY]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[USUARIOS](
		[USUARIO_ID] INT IDENTITY(1,1) PRIMARY KEY,
		[USERNAME] [NVARCHAR](250) UNIQUE NOT NULL,
		[PASS] [NVARCHAR](250) NOT NULL,
		[TIPO_USUARIO] [NVARCHAR](250),
		[BAJA_LOGICA] [BIT] NOT NULL DEFAULT 0,
		[LOGIN_FALLIDO] INT NOT NULL DEFAULT 0
	) ON [PRIMARY]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[USUARIOS_ROLES](
		[ROL_ID] INT FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[ROLES](ROL_ID) NOT NULL,
		[USUARIO_ID] INT FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[USUARIOS](USUARIO_ID) NOT NULL
	) ON [PRIMARY]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[DIRECCIONES](
		[DIRECCION_ID] INT IDENTITY(1,1) PRIMARY KEY,
		[DIRECCION] [NVARCHAR](255) NOT NULL,
		[CIUDAD] [NVARCHAR](255) NOT NULL,
		[CODIGO_POSTAL] [NUMERIC](4,0) DEFAULT 0	
	) ON [PRIMARY]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[CLIENTES](
		[CLIENTE_ID] INT IDENTITY(1,1) PRIMARY KEY,
		[DNI] [NUMERIC](18, 0) UNIQUE NOT NULL,
		[NOMBRE] [NVARCHAR](255) NOT NULL,
		[APELLIDO] [NVARCHAR](255) NOT NULL,
		[MAIL] [NVARCHAR](255) NOT NULL,
		[TELEFONO] [NUMERIC](18, 0) NOT NULL,
		[FECHA_NACIMIENTO] [DATETIME] NOT NULL,
		[BAJA_LOGICA] [BIT] NOT NULL DEFAULT 0,
		[USUARIO_ID] INT FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[USUARIOS](USUARIO_ID),
		[DIRECCION_ID] INT NOT NULL FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[DIRECCIONES](DIRECCION_ID),
		[CREDITO] [DECIMAL](18,2) NOT NULL DEFAULT 0
	) ON [PRIMARY]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[RUBROS](
		[RUBRO_ID] INT IDENTITY(1,1) PRIMARY KEY,
		[DESCRIPCION] [NVARCHAR](100) NOT NULL
	)
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[PROVEEDORES](
		[PROVEEDOR_ID] INT IDENTITY(1,1) PRIMARY KEY,
		[CUIT] [NVARCHAR](20) UNIQUE NOT NULL,
		[RAZON_SOCIAL] [NVARCHAR](255) UNIQUE NOT NULL,
		[NOMBRE_CONTACTO] [NVARCHAR](255),
		[RUBRO_ID] INT FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[RUBROS] (RUBRO_ID) ,
		[MAIL] [NVARCHAR](255) ,
		[TELEFONO] [NUMERIC](18, 0) NOT NULL,
		[BAJA_LOGICA] [BIT] NOT NULL DEFAULT 0,
		[USUARIO_ID] INT FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[USUARIOS](USUARIO_ID),
		[DIRECCION_ID] INT NOT NULL FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[DIRECCIONES](DIRECCION_ID)
	) ON [PRIMARY]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[TARJETAS](
		[TARJETA_ID] INT IDENTITY(1,1) PRIMARY KEY,
		[TITULAR] [NVARCHAR](255) NOT NULL,
		[FECHA_VENCIMIENTO] [NVARCHAR](5) NOT NULL,
		[NUMERO] NVARCHAR(100) NOT NULL
	) ON [PRIMARY]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[TIPOS_PAGOS](
		[TIPO_PAGO_ID] INT IDENTITY(1,1) PRIMARY KEY,
		[DESCRIPCION] [NVARCHAR](100) NOT NULL,
	)
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[CREDITOS](
		[CREDITO_ID] INT IDENTITY(1,1) PRIMARY KEY,
		[FECHA] DATETIME NOT NULL,
		[TIPO_PAGO_ID] INT NOT NULL FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[TIPOS_PAGOS](TIPO_PAGO_ID),
		[MONTO] [NUMERIC](18, 2) NOT NULL,
		[CLIENTE_ID] INT NOT NULL FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[CLIENTES](CLIENTE_ID),
		[TARJETA_ID] INT NULL FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[TARJETAS](TARJETA_ID)
	) ON [PRIMARY]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[OFERTAS](
		[OFERTA_ID] INT IDENTITY(1,1) PRIMARY KEY,
		[PRECIO_LISTA] [NUMERIC](18, 2) NULL,
		[PRECIO_OFERTA] [NUMERIC](18, 2) NULL,
		[FECHA_PUBLICACION] [DATETIME] NULL,
		[FECHA_VENCIMIENTO] [DATETIME] NULL,
		[CANTIDAD] [NUMERIC](18, 0) NULL,
		[MAXIMO_USUARIO] [DECIMAL](18,0) NULL,
		[DESCRIPCION] [NVARCHAR](255) NULL,
		[CODIGO] [NVARCHAR](50),
		[PROVEEDOR_ID] INT NOT NULL FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[PROVEEDORES](PROVEEDOR_ID)
	) ON [PRIMARY]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[CUPONES](
		[CUPON_ID] INT IDENTITY(1,1) PRIMARY KEY,
		[OFERTA_ID] INT NOT NULL FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[OFERTAS](OFERTA_ID),
		[CLIENTE_ID] INT NOT NULL FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[CLIENTES](CLIENTE_ID),
		[ESTADO] NVARCHAR(100),
		[FECHA_CONSUMO] [DATETIME] NOT NULL
	) ON [PRIMARY]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[COMPRAS](
		[COMPRA_ID] INT IDENTITY(1,1) PRIMARY KEY,
		[OFERTA_ID] INT NOT NULL FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[OFERTAS](OFERTA_ID),
		[CLIENTE_ID] INT NOT NULL FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[CLIENTES](CLIENTE_ID),
		[FECHA_COMPRA] [DATETIME] NOT NULL,
		[IMPORTE] [NUMERIC](18, 2) NULL
	) ON [PRIMARY]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[FACTURAS](
		[FACTURA_ID] INT IDENTITY(1,1) PRIMARY KEY,
		[NUMERO] [NUMERIC](18,0),
		[FECHA] datetime not null,
		[IMPORTE] [NUMERIC](18,2) not null default 0 ) ON [PRIMARY]
	GO
	CREATE TABLE [NO_SRTA_E_GATOREI].[FACTURAS_COMPRAS](
		[FACTURA_ID] INT NOT NULL FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[FACTURAS](FACTURA_ID),
		[COMPRA_ID] INT NOT NULL FOREIGN KEY REFERENCES [NO_SRTA_E_GATOREI].[COMPRAS](COMPRA_ID)
	) ON [PRIMARY]
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[DIRECCIONES]
			([DIRECCION]
			,[CIUDAD]
			,[CODIGO_POSTAL])
		SELECT CLI_DIRECCION, CLI_CIUDAD , NULL 
		FROM [GD_ESQUEMA].[MAESTRA]
		WHERE CLI_DIRECCION IS NOT NULL
		GROUP BY CLI_DIRECCION, CLI_CIUDAD 
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[DIRECCIONES]
			([DIRECCION]
			,[CIUDAD]
			,[CODIGO_POSTAL])
		SELECT PROVEE_DOM, PROVEE_CIUDAD , NULL 
		FROM [GD_ESQUEMA].[MAESTRA]
		WHERE PROVEE_DOM IS NOT NULL
		GROUP BY PROVEE_DOM, PROVEE_CIUDAD 
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[CLIENTES]
			([DNI]
			,[NOMBRE]
			,[APELLIDO]
			,[MAIL]
			,[TELEFONO]
			,[FECHA_NACIMIENTO]
			,[USUARIO_ID]
			,[DIRECCION_ID])
		SELECT M.CLI_DNI, M.CLI_NOMBRE, M.CLI_APELLIDO, M.CLI_MAIL, M.CLI_TELEFONO, M.CLI_FECHA_NAC, NULL , D.DIRECCION_ID
		FROM [GD_ESQUEMA].[MAESTRA] M INNER JOIN [NO_SRTA_E_GATOREI].[DIRECCIONES] D ON M.CLI_DIRECCION = D.DIRECCION
		WHERE M.CLI_DNI IS NOT NULL
		GROUP BY M.CLI_DNI, M.CLI_NOMBRE, M.CLI_APELLIDO, M.CLI_MAIL, M.CLI_TELEFONO, M.CLI_FECHA_NAC, D.DIRECCION_ID
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[RUBROS] (DESCRIPCION)
	SELECT DISTINCT PROVEE_RUBRO FROM GD_ESQUEMA.MAESTRA WHERE PROVEE_RUBRO IS NOT NULL
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[PROVEEDORES] 
			([CUIT]
			,[RAZON_SOCIAL]
			,[NOMBRE_CONTACTO]
			,[RUBRO_ID]
			,[MAIL]
			,[TELEFONO]
			,[USUARIO_ID]
			,[DIRECCION_ID])
		SELECT M.PROVEE_CUIT, M.PROVEE_RS, NULL, R.RUBRO_ID,NULL, M.PROVEE_TELEFONO, NULL , D.DIRECCION_ID
		FROM [GD_ESQUEMA].[MAESTRA] M LEFT JOIN [NO_SRTA_E_GATOREI].[DIRECCIONES] D ON M.PROVEE_DOM = D.DIRECCION
		JOIN [NO_SRTA_E_GATOREI].[RUBROS] R ON M.Provee_Rubro = R.DESCRIPCION
		WHERE PROVEE_CUIT IS NOT NULL
		GROUP BY PROVEE_CUIT, PROVEE_RS,R.RUBRO_ID, PROVEE_TELEFONO, D.DIRECCION_ID
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[OFERTAS]
			([PRECIO_LISTA]
			,[PRECIO_OFERTA]
			,[FECHA_PUBLICACION]
			,[FECHA_VENCIMIENtO]
			,[CANTIDAD]
			,[MAXIMO_USUARIO]
			,[DESCRIPCION]
			,[CODIGO]
			,[PROVEEDOR_ID])
		SELECT M.OFERTA_PRECIO,
		M.OFERTA_PRECIO_FICTICIO,
		M.OFERTA_FECHA, 
		M.OFERTA_FECHA_VENC,
		M.OFERTA_CANTIDAD,
		COUNT(DISTINCT CLI_DNI),
		M.OFERTA_DESCRIPCION,
		M.OFERTA_CODIGO,
		P.PROVEEDOR_ID
	FROM GD_ESQUEMA.MAESTRA M 
	LEFT JOIN [NO_SRTA_E_GATOREI].[PROVEEDORES] P ON P.CUIT = PROVEE_CUIT
	WHERE M.OFERTA_CODIGO IS NOT NULL
	GROUP BY M.OFERTA_PRECIO,M.OFERTA_PRECIO_FICTICIO,M.OFERTA_FECHA, M.OFERTA_FECHA_VENC,M.OFERTA_CANTIDAD,M.OFERTA_DESCRIPCION,M.OFERTA_CODIGO, P.PROVEEDOR_ID
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[COMPRAS]
			([OFERTA_ID]
			,[CLIENTE_ID]
			,[FECHA_COMPRA]
			,[IMPORTE])
		SELECT O.OFERTA_ID, C.CLIENTE_ID,  M.Oferta_Fecha_Compra, M.OFERTA_PRECIO_FICTICIO 
		FROM [GD_ESQUEMA].[MAESTRA] M JOIN [NO_SRTA_E_GATOREI].[OFERTAS] O ON M.OFERTA_CODIGO = O.CODIGO 
		JOIN [NO_SRTA_E_GATOREI].[CLIENTES] C ON M.CLI_DNI = C.DNI
		WHERE m.OFERTA_FECHA_COMPRA IS NOT NULL 
		AND FACTURA_NRO IS NULL
		AND OFERTA_ENTREGADO_FECHA IS NULL
		GROUP BY O.OFERTA_ID,C.CLIENTE_ID,M.Oferta_Fecha_Compra, M.OFERTA_PRECIO_FICTICIO
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[CUPONES] (OFERTA_ID,CLIENTE_ID,FECHA_CONSUMO)
	SELECT O.OFERTA_ID,C.CLIENTE_ID, M.OFERTA_ENTREGADO_FECHA 
	FROM GD_ESQUEMA.MAESTRA M
	INNER JOIN [NO_SRTA_E_GATOREI].CLIENTES C ON M.CLI_DNI = C.DNI
	INNER JOIN [NO_SRTA_E_GATOREI].OFERTAS O ON M.OFERTA_CODIGO = O.CODIGO 
	WHERE OFERTA_ENTREGADO_FECHA IS NOT NULL
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[FACTURAS]
				([NUMERO],[FECHA])
		SELECT [FACTURA_NRO], [FACTURA_FECHA]
		FROM [GD_ESQUEMA].[MAESTRA]
		WHERE [FACTURA_NRO] IS NOT NULL
		GROUP BY [FACTURA_NRO],[FACTURA_FECHA]
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[FACTURAS_COMPRAS]
				([FACTURA_ID],[COMPRA_ID])
				SELECT [FACTURA_ID] ,[COMPRA_ID]
				FROM [NO_SRTA_E_GATOREI].[COMPRAS] C
				LEFT JOIN [NO_SRTA_E_GATOREI].[OFERTAS] O ON O.[OFERTA_ID] = C.[OFERTA_ID]
				LEFT JOIN [GD_ESQUEMA].[MAESTRA] M ON O.[CODIGO] = M.[OFERTA_CODIGO]
				LEFT JOIN [NO_SRTA_E_GATOREI].[FACTURAS] F ON M.[FACTURA_NRO] = F.[NUMERO]
				WHERE M.[FACTURA_NRO] IS NOT NULL
				GROUP BY [COMPRA_ID], [FACTURA_ID]
	GO
	UPDATE [NO_SRTA_E_GATOREI].[FACTURAS]
	SET IMPORTE= (SELECT SUM(C.IMPORTE)
					FROM [NO_SRTA_E_GATOREI].[COMPRAS] C,[NO_SRTA_E_GATOREI].[FACTURAS_COMPRAS] FC
					WHERE C.[COMPRA_ID] = FC.[COMPRA_ID]
					AND FC.[FACTURA_ID] = [NO_SRTA_E_GATOREI].[FACTURAS].[FACTURA_ID]
					GROUP BY FC.[FACTURA_ID]);
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[TIPOS_PAGOS] (DESCRIPCION)
	SELECT DISTINCT(TIPO_PAGO_DESC) 
	FROM GD_ESQUEMA.MAESTRA 
	WHERE TIPO_PAGO_DESC IS NOT NULL
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[TIPOS_PAGOS] (DESCRIPCION)
	VALUES('REGALO')
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].CREDITOS (FECHA,TIPO_PAGO_ID,MONTO,CLIENTE_ID)
	SELECT M.CARGA_FECHA,(SELECT TIPO_PAGO_ID FROM [NO_SRTA_E_GATOREI].TIPOS_PAGOS WHERE DESCRIPCION = M.TIPO_PAGO_DESC),M.CARGA_CREDITO,C.CLIENTE_ID
	FROM GD_ESQUEMA.MAESTRA M
	INNER JOIN [NO_SRTA_E_GATOREI].CLIENTES C ON M.CLI_DNI = C.DNI
	WHERE M.CARGA_CREDITO IS NOT NULL
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[ROLES](NOMBRE) VALUES ('ADMINISTRATIVO') 
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[ROLES](NOMBRE) VALUES ('CLIENTE') 
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[ROLES](NOMBRE) VALUES ('PROVEEDOR') 
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].[USUARIOS](USERNAME,PASS) VALUES ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7')
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS(PERMISO_DESC,PERMISO_CLAVE) VALUES ('Abm Roles','ABM_ROLES')
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS(PERMISO_DESC,PERMISO_CLAVE) VALUES ('Abm Clientes','ABM_CLIENTES')
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS(PERMISO_DESC,PERMISO_CLAVE) VALUES ('Abm Proveedores','ABM_PROVEEDORES')
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS(PERMISO_DESC,PERMISO_CLAVE) VALUES ('Abm Usuarios','ABM_USUARIOS')
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS(PERMISO_DESC,PERMISO_CLAVE) VALUES ('Generar Reportes', 'REPORTES')
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS(PERMISO_DESC,PERMISO_CLAVE) VALUES ('Facturar','FACTURAS')
	GO 
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS(PERMISO_DESC,PERMISO_CLAVE) VALUES ('Cargar Credito','CARGAR_CREDITO')
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS(PERMISO_DESC,PERMISO_CLAVE) VALUES ('Comprar Oferta','COMPRAR_OFERTA')
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS(PERMISO_DESC,PERMISO_CLAVE) VALUES ('Armar Ofertas', 'CREAR_OFERTA')
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS(PERMISO_DESC,PERMISO_CLAVE) VALUES ('Canjear Oferta', 'CANJEAR_OFERTA')
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS_ROLES(ROL_ID,PERMISO_ID) VALUES ((SELECT ROL_ID FROM [NO_SRTA_E_GATOREI].ROLES WHERE NOMBRE = 'ADMINISTRATIVO'), (SELECT PERMISO_ID FROM [NO_SRTA_E_GATOREI].PERMISOS WHERE PERMISO_CLAVE = 'ABM_ROLES'))
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS_ROLES(ROL_ID,PERMISO_ID) VALUES ((SELECT ROL_ID FROM [NO_SRTA_E_GATOREI].ROLES WHERE NOMBRE = 'ADMINISTRATIVO'), (SELECT PERMISO_ID FROM [NO_SRTA_E_GATOREI].PERMISOS WHERE PERMISO_CLAVE = 'ABM_CLIENTES'))
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS_ROLES(ROL_ID,PERMISO_ID) VALUES ((SELECT ROL_ID FROM [NO_SRTA_E_GATOREI].ROLES WHERE NOMBRE = 'ADMINISTRATIVO'), (SELECT PERMISO_ID FROM [NO_SRTA_E_GATOREI].PERMISOS WHERE PERMISO_CLAVE = 'ABM_PROVEEDORES'))
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS_ROLES(ROL_ID,PERMISO_ID) VALUES ((SELECT ROL_ID FROM [NO_SRTA_E_GATOREI].ROLES WHERE NOMBRE = 'ADMINISTRATIVO'), (SELECT PERMISO_ID FROM [NO_SRTA_E_GATOREI].PERMISOS WHERE PERMISO_CLAVE = 'ABM_USUARIOS'))
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS_ROLES(ROL_ID,PERMISO_ID) VALUES ((SELECT ROL_ID FROM [NO_SRTA_E_GATOREI].ROLES WHERE NOMBRE = 'ADMINISTRATIVO'), (SELECT PERMISO_ID FROM [NO_SRTA_E_GATOREI].PERMISOS WHERE PERMISO_CLAVE = 'REPORTES'))
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS_ROLES(ROL_ID,PERMISO_ID) VALUES ((SELECT ROL_ID FROM [NO_SRTA_E_GATOREI].ROLES WHERE NOMBRE = 'ADMINISTRATIVO'), (SELECT PERMISO_ID FROM [NO_SRTA_E_GATOREI].PERMISOS WHERE PERMISO_CLAVE = 'FACTURAS'))
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS_ROLES(ROL_ID,PERMISO_ID) VALUES ((SELECT ROL_ID FROM [NO_SRTA_E_GATOREI].ROLES WHERE NOMBRE = 'CLIENTE'), (SELECT PERMISO_ID FROM [NO_SRTA_E_GATOREI].PERMISOS WHERE PERMISO_CLAVE = 'CARGAR_CREDITO'))
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS_ROLES(ROL_ID,PERMISO_ID) VALUES ((SELECT ROL_ID FROM [NO_SRTA_E_GATOREI].ROLES WHERE NOMBRE = 'CLIENTE'), (SELECT PERMISO_ID FROM [NO_SRTA_E_GATOREI].PERMISOS WHERE PERMISO_CLAVE = 'COMPRAR_OFERTA'))
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS_ROLES(ROL_ID,PERMISO_ID) VALUES ((SELECT ROL_ID FROM [NO_SRTA_E_GATOREI].ROLES WHERE NOMBRE = 'PROVEEDOR'), (SELECT PERMISO_ID FROM [NO_SRTA_E_GATOREI].PERMISOS WHERE PERMISO_CLAVE = 'CREAR_OFERTA'))
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].PERMISOS_ROLES(ROL_ID,PERMISO_ID) VALUES ((SELECT ROL_ID FROM [NO_SRTA_E_GATOREI].ROLES WHERE NOMBRE = 'PROVEEDOR'), (SELECT PERMISO_ID FROM [NO_SRTA_E_GATOREI].PERMISOS WHERE PERMISO_CLAVE = 'CANJEAR_OFERTA'))
	GO
	INSERT INTO [NO_SRTA_E_GATOREI].USUARIOS_ROLES(USUARIO_ID,ROL_ID)
	SELECT 1,ROL_ID FROM [NO_SRTA_E_GATOREI].ROLES
	GO
	CREATE TRIGGER [NO_SRTA_E_GATOREI].[ACTUALIZA_MONTO_FACTURA]
	ON [NO_SRTA_E_GATOREI].[FACTURAS_COMPRAS]
	AFTER INSERT 
	AS
	BEGIN
	UPDATE [NO_SRTA_E_GATOREI].[FACTURAS] 
	SET [IMPORTE] = [IMPORTE] + (SELECT SUM(C.IMPORTE) 
								FROM [NO_SRTA_E_GATOREI].[COMPRAS] C, [NO_SRTA_E_GATOREI].[FACTURAS_COMPRAS] FC
								WHERE FC.COMPRA_ID = C.COMPRA_ID
								AND FC.FACTURA_ID = (SELECT TOP 1 FACTURA_ID FROM INSERTED) )
	WHERE FACTURA_ID = (SELECT FACTURA_ID FROM INSERTED )
	END
	GO
	CREATE TRIGGER [NO_SRTA_E_GATOREI].[AGREGAR_IMPORTE_COMPRA]
	ON [NO_SRTA_E_GATOREI].[COMPRAS]
	AFTER INSERT 
	AS
	BEGIN
	UPDATE [NO_SRTA_E_GATOREI].[COMPRAS] 
	SET [IMPORTE] = (SELECT PRECIO_OFERTA 
					FROM [NO_SRTA_E_GATOREI].[OFERTAS] 
					WHERE OFERTA_ID = (SELECT OFERTA_ID FROM INSERTED ) )
	WHERE COMPRA_ID = (SELECT COMPRA_ID FROM INSERTED )                 
	END
	GO
	CREATE TRIGGER [NO_SRTA_E_GATOREI].[ASIGNAR_ROL_USUARIO]
	ON [NO_SRTA_E_GATOREI].[USUARIOS]
	AFTER INSERT 
	AS
	BEGIN
	INSERT INTO [NO_SRTA_E_GATOREI].[USUARIOS_ROLES](USUARIO_ID,ROL_ID)
	VALUES ((SELECT USUARIO_ID FROM INSERTED),(SELECT ROL_ID FROM [NO_SRTA_E_GATOREI].ROLES WHERE NOMBRE = (SELECT TIPO_USUARIO FROM INSERTED)) )
	END
	GO
	CREATE TRIGGER [NO_SRTA_E_GATOREI].[CHEQUEAR_BAJA_ROL]
	ON [NO_SRTA_E_GATOREI].[ROLES]
	AFTER UPDATE
	AS
	BEGIN 
	DECLARE @BAJA BIT

	SELECT @BAJA = BAJA_LOGICA FROM INSERTED

	IF @BAJA = 1
	BEGIN
	DELETE [NO_SRTA_E_GATOREI].[PERMISOS_ROLES] WHERE ROL_ID = (SELECT ROL_ID FROM INSERTED)
	DELETE [NO_SRTA_E_GATOREI].[USUARIOS_ROLES] WHERE ROL_ID = (SELECT ROL_ID FROM INSERTED)
	END
	END
	GO
	CREATE TRIGGER [NO_SRTA_E_GATOREI].AUMENTAR_CREDITO_CLIENTE
	ON [NO_SRTA_E_GATOREI].[CREDITOS]
	AFTER INSERT
	AS
	BEGIN
		UPDATE [NO_SRTA_E_GATOREI].CLIENTES SET CREDITO = CREDITO + (SELECT MONTO FROM INSERTED)
		WHERE CLIENTE_ID = (SELECT CLIENTE_ID FROM INSERTED);
	END
	GO
	CREATE TRIGGER [NO_SRTA_E_GATOREI].RESTAR_CREDITO_CLIENTE
	ON [NO_SRTA_E_GATOREI].[COMPRAS]
	AFTER INSERT
	AS
	BEGIN
		DECLARE @OFERTA_ID DECIMAL(18,2);
		SELECT @OFERTA_ID = OFERTA_ID FROM INSERTED;

		UPDATE [NO_SRTA_E_GATOREI].CLIENTES SET CREDITO = CREDITO + (SELECT PRECIO_OFERTA FROM [NO_SRTA_E_GATOREI].OFERTAS WHERE OFERTA_ID =  @OFERTA_ID)
		WHERE CLIENTE_ID = (SELECT CLIENTE_ID FROM INSERTED);
	END
	GO
GO
GO
CREATE PROCEDURE LOGIN_USUARIO
	@USERNAME NVARCHAR(255),
	@PASS NVARCHAR(255),
	@RESULT int OUTPUT
AS
BEGIN
	DECLARE @ID INT, @USER NVARCHAR(255),@PASSWORD NVARCHAR(255), @REINTENTOS INT, @HAB BIT

	SELECT
		@ID = USUARIO_ID,
		@USER = USERNAME,
		@PASSWORD = PASS,
		@REINTENTOS = LOGIN_FALLIDO,
		@HAB = BAJA_LOGICA
	FROM [NO_SRTA_E_GATOREI].USUARIOS
	WHERE USERNAME = @USERNAME

	IF @ID IS NULL
    BEGIN
		RETURN -1;
	END

ELSE IF @REINTENTOS >= 3
	BEGIN
		RETURN -2;
	END
	
ELSE IF @HAB = 1
	BEGIN
		RETURN -4;
	END

ELSE IF @PASSWORD <> @PASS
	BEGIN
		UPDATE [NO_SRTA_E_GATOREI].[USUARIOS]
	SET LOGIN_FALLIDO = LOGIN_FALLIDO + 1
	WHERE USUARIO_ID = @ID
		RETURN -3;
	END
ELSE 
	BEGIN
		UPDATE [NO_SRTA_E_GATOREI].[USUARIOS]
	SET LOGIN_FALLIDO = 0
	WHERE USUARIO_ID = @ID

		SELECT @RESULT = @ID
		RETURN 0;
	END
END
GO
CREATE PROCEDURE CREAR_USUARIO_CLIENTE
	@USERNAME NVARCHAR(255),
	@PASS NVARCHAR(244),
	@NOMBRE NVARCHAR(255),
	@APELLIDO NVARCHAR(255),
	@DNI NUMERIC(18, 0),
	@MAIL NVARCHAR(255),
	@TELEFONO NUMERIC(18,0),
	@DIRECCION NVARCHAR(255),
	@CP NUMERIC(4,0),
	@CIUDAD NVARCHAR(255),
	@FECHA_NACIMIENTO DATETIME,
	@FECHA_ACTUAL DATETIME
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	DECLARE @USER_ID INT, @ID_NUEVO INT
	INSERT INTO [NO_SRTA_E_GATOREI].[USUARIOS]
		(USERNAME,PASS,TIPO_USUARIO)
	VALUES
		(@USERNAME, @PASS, 'CLIENTE')

	SELECT @USER_ID= USUARIO_ID
	FROM [NO_SRTA_E_GATOREI].[USUARIOS]
	WHERE USERNAME = @USERNAME

	INSERT INTO [NO_SRTA_E_GATOREI].[DIRECCIONES]
		(DIRECCION,CIUDAD,CODIGO_POSTAL)
	VALUES
		(@DIRECCION, @CIUDAD, @CP)

	SELECT @ID_NUEVO = DIRECCION_ID
	FROM [NO_SRTA_E_GATOREI].[DIRECCIONES]
	WHERE DIRECCION = @DIRECCION
		AND CIUDAD = @CIUDAD
		AND CODIGO_POSTAL = @CP

	INSERT INTO [NO_SRTA_E_GATOREI].[CLIENTES]
		(DNI,NOMBRE,APELLIDO,MAIL,TELEFONO,FECHA_NACIMIENTO,USUARIO_ID,DIRECCION_ID)
	VALUES
		(@DNI, @NOMBRE, @APELLIDO, @MAIL, @TELEFONO, @FECHA_NACIMIENTO, @USER_ID, @ID_NUEVO)

	SELECT @ID_NUEVO = CLIENTE_ID
	FROM [NO_SRTA_E_GATOREI].[CLIENTES]
	WHERE DNI = @DNI

	INSERT INTO NO_SRTA_E_GATOREI.CREDITOS
		(FECHA,TIPO_PAGO_ID,MONTO,CLIENTE_ID)
	VALUES(@FECHA_ACTUAL, (SELECT TIPO_PAGO_ID
			FROM [NO_SRTA_E_GATOREI].[TIPOS_PAGOS]
			WHERE DESCRIPCION = 'REGALO'), 200, @ID_NUEVO)

	IF @@ERROR <> 0
		BEGIN
		ROLLBACK TRANSACTION
		RETURN @@ERROR
	END
		ELSE
		BEGIN
		COMMIT TRANSACTION
		RETURN 0
	END
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		THROW;
	END CATCH
END	
GO
CREATE PROCEDURE CREAR_CLIENTE
	@NOMBRE NVARCHAR(255),
	@APELLIDO NVARCHAR(255),
	@DNI NUMERIC(18, 0),
	@MAIL NVARCHAR(255),
	@TELEFONO NUMERIC(18,0),
	@DIRECCION NVARCHAR(255),
	@CP NUMERIC(4,0),
	@CIUDAD NVARCHAR(255),
	@FECHA_NACIMIENTO DATETIME,
	@FECHA_ACTUAL DATETIME
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	DECLARE @ID_NUEVO INT
	
	INSERT INTO [NO_SRTA_E_GATOREI].[DIRECCIONES]
		(DIRECCION,CIUDAD,CODIGO_POSTAL)
	VALUES
		(@DIRECCION, @CIUDAD, @CP)

	SELECT @ID_NUEVO = DIRECCION_ID
	FROM [NO_SRTA_E_GATOREI].[DIRECCIONES]
	WHERE DIRECCION = @DIRECCION
		AND CIUDAD = @CIUDAD
		AND CODIGO_POSTAL = @CP

	INSERT INTO [NO_SRTA_E_GATOREI].[CLIENTES]
		(DNI,NOMBRE,APELLIDO,MAIL,TELEFONO,FECHA_NACIMIENTO,DIRECCION_ID)
	VALUES
		(@DNI, @NOMBRE, @APELLIDO, @MAIL, @TELEFONO, @FECHA_NACIMIENTO, @ID_NUEVO)

	SELECT @ID_NUEVO = CLIENTE_ID
	FROM [NO_SRTA_E_GATOREI].[CLIENTES]
	WHERE DNI = @DNI

	INSERT INTO NO_SRTA_E_GATOREI.CREDITOS
		(FECHA,TIPO_PAGO_ID,MONTO,CLIENTE_ID)
	VALUES(@FECHA_ACTUAL, (SELECT TIPO_PAGO_ID
			FROM [NO_SRTA_E_GATOREI].[TIPOS_PAGOS]
			WHERE DESCRIPCION = 'REGALO'), 200, @ID_NUEVO)

	IF @@ERROR <> 0
		BEGIN
		ROLLBACK TRANSACTION
		RETURN @@ERROR
	END
		ELSE
		BEGIN
		COMMIT TRANSACTION
		RETURN 0
	END
	END TRY
	BEGIN CATCH 
	ROLLBACK TRANSACTION
			THROW;
	END CATCH
END	
GO
CREATE PROCEDURE CREAR_USUARIO_PROVEEDOR
	@USERNAME NVARCHAR(255),
	@PASS NVARCHAR(255),
	@RS NVARCHAR(255),
	@CUIT NVARCHAR(20),
	@MAIL NVARCHAR(255),
	@TELEFONO NUMERIC(18,0),
	@DIRECCION NVARCHAR(255),
	@CP NUMERIC(4,0),
	@CIUDAD NVARCHAR(255),
	@RUBRO_ID INT,
	@NOMBRE_CONTACTO NVARCHAR(255)
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	DECLARE @USER_ID INT, @ID_NUEVO INT
	INSERT INTO [NO_SRTA_E_GATOREI].[USUARIOS]
		(USERNAME,PASS,TIPO_USUARIO)
	VALUES
		(@USERNAME, @PASS, 'PROVEEDOR')

	SELECT @USER_ID= USUARIO_ID
	FROM [NO_SRTA_E_GATOREI].[USUARIOS]
	WHERE USERNAME = @USERNAME

	INSERT INTO [NO_SRTA_E_GATOREI].[DIRECCIONES]
		(DIRECCION,CIUDAD,CODIGO_POSTAL)
	VALUES
		(@DIRECCION, @CIUDAD, @CP)

	SELECT @ID_NUEVO = DIRECCION_ID
	FROM [NO_SRTA_E_GATOREI].[DIRECCIONES]
	WHERE DIRECCION = @DIRECCION
		AND CIUDAD = @CIUDAD
		AND CODIGO_POSTAL = @CP

	INSERT INTO [NO_SRTA_E_GATOREI].[PROVEEDORES]
		(CUIT,RAZON_SOCIAL,NOMBRE_CONTACTO,RUBRO_ID,MAIL,TELEFONO,USUARIO_ID,DIRECCION_ID)
	VALUES
		(@CUIT, @RS, @NOMBRE_CONTACTO, @RUBRO_ID, @MAIL, @TELEFONO, @USER_ID, @ID_NUEVO)

	IF @@ERROR <> 0
		BEGIN
		ROLLBACK TRANSACTION
		RETURN @@ERROR
	END
		ELSE
		BEGIN
		COMMIT TRANSACTION
		RETURN 0
	END
	END TRY
	BEGIN CATCH
	ROLLBACK TRANSACTION
			THROW;
	END CATCH
END	
GO
CREATE PROCEDURE CREAR_PROVEEDOR
	@RS NVARCHAR(255),
	@CUIT NVARCHAR(20),
	@MAIL NVARCHAR(255),
	@TELEFONO NUMERIC(18,0),
	@DIRECCION NVARCHAR(255),
	@CP NUMERIC(4,0),
	@CIUDAD NVARCHAR(255),
	@RUBRO_ID INT,
	@NOMBRE_CONTACTO NVARCHAR(255)
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	DECLARE @ID_NUEVO INT

	INSERT INTO [NO_SRTA_E_GATOREI].[DIRECCIONES]
		(DIRECCION,CIUDAD,CODIGO_POSTAL)
	VALUES
		(@DIRECCION, @CIUDAD, @CP)

	SELECT @ID_NUEVO = DIRECCION_ID
	FROM [NO_SRTA_E_GATOREI].[DIRECCIONES]
	WHERE DIRECCION = @DIRECCION
		AND CIUDAD = @CIUDAD
		AND CODIGO_POSTAL = @CP

	INSERT INTO [NO_SRTA_E_GATOREI].[PROVEEDORES]
		(CUIT,RAZON_SOCIAL,NOMBRE_CONTACTO,RUBRO_ID,MAIL,TELEFONO,DIRECCION_ID)
	VALUES
		(@CUIT, @RS, @NOMBRE_CONTACTO, @RUBRO_ID, @MAIL, @TELEFONO, @ID_NUEVO)

	IF @@ERROR <> 0
		BEGIN
		ROLLBACK TRANSACTION
		RETURN @@ERROR
	END
		ELSE
		BEGIN
		COMMIT TRANSACTION
		RETURN 0
	END
		END TRY
	BEGIN CATCH
	ROLLBACK TRANSACTION
			THROW;
	END CATCH
END	
GO
CREATE PROCEDURE CARGAR_CREDITO
	@FECHA DATETIME,
	@USUARIO_ID INT,
	@TIPO_PAGO_ID INT,
	@MONTO NUMERIC(18,2),
	@NOMBRE NVARCHAR(255),
	@FECHA_VENCIMIENTO NVARCHAR(5),
	@NUMERO NVARCHAR(100)
AS
BEGIN

	DECLARE @CLIENTE_ID INT; 
	
	SELECT @CLIENTE_ID = CLIENTE_ID 
	FROM [NO_SRTA_E_GATOREI].CLIENTES
	WHERE USUARIO_ID = @USUARIO_ID
	AND BAJA_LOGICA = 0;

	IF @CLIENTE_ID IS NULL
	BEGIN
	RETURN -1
	END

	BEGIN TRANSACTION
	BEGIN TRY
	DECLARE @TARJETA_ID INT

	INSERT INTO [NO_SRTA_E_GATOREI].[TARJETAS]
		(TITULAR,FECHA_VENCIMIENTO, NUMERO)
	VALUES
		(@NOMBRE, @FECHA_VENCIMIENTO, @NUMERO)

	SELECT @TARJETA_ID = TARJETA_ID
	FROM [NO_SRTA_E_GATOREI].[TARJETAS]
	WHERE NUMERO = @NUMERO

	INSERT INTO [NO_SRTA_E_GATOREI].[CREDITOS]
		(FECHA,TIPO_PAGO_ID,MONTO,CLIENTE_ID,TARJETA_ID)
	VALUES
		(@FECHA, @TIPO_PAGO_ID, @MONTO, @CLIENTE_ID, @TARJETA_ID)
	IF @@ERROR <> 0
		BEGIN
		ROLLBACK TRANSACTION
		RETURN @@ERROR
	END
		ELSE
		BEGIN
		COMMIT TRANSACTION
		RETURN 0
	END
		END TRY
	BEGIN CATCH
	ROLLBACK TRANSACTION
		THROW;
	END CATCH
END
GO
CREATE PROCEDURE FACTURAR_PROVEEDOR
	@PROVEEDOR_ID INT,
	@FECHA_DESDE DATETIME,
	@FECHA_HASTA DATETIME,
	@FECHA_FACTURACION DATETIME,
	@NUMERO BIGINT OUTPUT,
	@IMPORTE DECIMAL(10,2) OUTPUT
AS
BEGIN
	DECLARE @FACTURA_ID INT
	BEGIN TRANSACTION
	BEGIN TRY
	SELECT @NUMERO = MAX(NUMERO) + 1
	FROM FACTURA;

	INSERT INTO [NO_SRTA_E_GATOREI].[FACTURAS]
		(NUMERO,FECHA)
	VALUES
		(@NUMERO, @FECHA_FACTURACION)

	INSERT INTO FACTURAS_COMPRAS
		(FACTURA_ID,COMPRA_ID )
	SELECT SCOPE_IDENTITY(), C.COMPRA_ID
	FROM COMPRAS C, OFERTAS O
	WHERE C.OFERTA_ID = O.OFERTA_ID
		AND NOT EXISTS ( SELECT 1
		FROM FACTURAS_COMPRAS FC
		WHERE FC.COMPRA_ID = C.COMPRA_ID )
		AND C.FECHA_COMPRA BETWEEN @FECHA_DESDE AND @FECHA_HASTA

	SELECT @IMPORTE = IMPORTE
	FROM FACTURAS
	WHERE FACTURA_ID = @FACTURA_ID
	IF @@ERROR <> 0
		BEGIN
		ROLLBACK TRANSACTION
		RETURN @@ERROR
	END
		ELSE
		BEGIN
		COMMIT TRANSACTION
		RETURN 0
	END
		END TRY
	BEGIN CATCH
	ROLLBACK TRANSACTION
			THROW;
	END CATCH
END
GO
CREATE PROCEDURE INVERTIR_BAJA_LOGICA_CLIENTE
	@CLIENTE_ID INT
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	DECLARE @STATE BIT, @USER_ID BIT
	SELECT @STATE = ~BAJA_LOGICA, @USER_ID = USUARIO_ID
	FROM [NO_SRTA_E_GATOREI].CLIENTES
	WHERE CLIENTE_ID = @CLIENTE_ID

	UPDATE [NO_SRTA_E_GATOREI].CLIENTES 
	SET BAJA_LOGICA = @STATE 
	WHERE CLIENTE_ID = @CLIENTE_ID

	IF @USER_ID IS NOT NULL
	BEGIN
		UPDATE [NO_SRTA_E_GATOREI].USUARIOS
		SET BAJA_LOGICA = @STATE
		WHERE USUARIO_ID = @USER_ID
	END

	IF @@ERROR <> 0
		BEGIN
		ROLLBACK TRANSACTION
		RETURN @@ERROR
	END
		ELSE
		BEGIN
		COMMIT TRANSACTION
		RETURN 0
	END
		END TRY
	BEGIN CATCH
	ROLLBACK TRANSACTION
			THROW;
	END CATCH
END
GO
CREATE PROCEDURE INVERTIR_BAJA_LOGICA_PROVEEDOR
	@PROVEEDOR_ID INT
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	DECLARE @STATE BIT, @USER_ID BIT
	SELECT @STATE = ~BAJA_LOGICA, @USER_ID = USUARIO_ID
	FROM [NO_SRTA_E_GATOREI].PROVEEDORES
	WHERE PROVEEDOR_ID = @PROVEEDOR_ID

	UPDATE [NO_SRTA_E_GATOREI].PROVEEDORES 
	SET BAJA_LOGICA = @STATE 
	WHERE PROVEEDOR_ID = @PROVEEDOR_ID

	IF @USER_ID IS NOT NULL
	BEGIN
		UPDATE [NO_SRTA_E_GATOREI].USUARIOS
		SET BAJA_LOGICA = @STATE
		WHERE USUARIO_ID = @USER_ID
	END

	IF @@ERROR <> 0
		BEGIN
		ROLLBACK TRANSACTION
		RETURN @@ERROR
	END
		ELSE
		BEGIN
		COMMIT TRANSACTION
		RETURN 0
	END
		END TRY
	BEGIN CATCH
	ROLLBACK TRANSACTION
			THROW;
	END CATCH
END
GO
CREATE FUNCTION STRING_SPLIT
(
    @string    nvarchar(max),
    @delimiter nvarchar(max)
)
RETURNS TABLE AS RETURN
(
    SELECT
	ROW_NUMBER ( ) over(order by (select 0))  id     --  Not sure if it works correct
         , Split.a.value('.', 'NVARCHAR(MAX)')       value
FROM
	(
        SELECT CAST('<X>'+REPLACE(@string, @delimiter, '</X><X>')+'</X>' AS XML) AS String
    ) AS a
    CROSS APPLY String.nodes('/X') AS Split(a)
)
GO
CREATE PROCEDURE ACTUALIZAR_ROL
	@ROL_ID INT,
	@ROL_DESC NVARCHAR(100),
	@PERMISOS NVARCHAR(255)
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	UPDATE [NO_SRTA_E_GATOREI].[ROLES] 
SET NOMBRE = @ROL_DESC
WHERE ROL_ID = @ROL_ID

	DELETE [NO_SRTA_E_GATOREI].[PERMISOS_ROLES]
WHERE ROL_ID = @ROL_ID

	INSERT INTO [NO_SRTA_E_GATOREI].[PERMISOS_ROLES]
		(PERMISO_ID,ROL_ID)
	SELECT VALUE, @ROL_ID
	FROM STRING_SPLIT(@PERMISOS,'|')

	IF @@ERROR <> 0 
BEGIN
		ROLLBACK
		RETURN @@ERROR
	END
ELSE 
BEGIN
		COMMIT TRANSACTION
		RETURN 0
	END
		END TRY
	BEGIN CATCH
	ROLLBACK TRANSACTION
			THROW;
	END CATCH
END
GO
CREATE PROCEDURE CREAR_ROL
	@ROL_DESC NVARCHAR(100),
	@PERMISOS NVARCHAR(255)
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	DECLARE @ROL_ID INT;

	INSERT INTO [NO_SRTA_E_GATOREI].ROLES
		(NOMBRE)
	VALUES
		(@ROL_DESC);
	SELECT @ROL_ID
	FROM [NO_SRTA_E_GATOREI].ROLES
	WHERE NOMBRE = @ROL_DESC;

	INSERT INTO [NO_SRTA_E_GATOREI].[PERMISOS_ROLES]
		(PERMISO_ID,ROL_ID)
	SELECT VALUE, @ROL_ID
	FROM STRING_SPLIT(@PERMISOS,'|')

	IF @@ERROR <> 0 
BEGIN
		ROLLBACK
		RETURN @@ERROR
	END
ELSE 
BEGIN
		COMMIT TRANSACTION
		RETURN 0
	END
		END TRY
	BEGIN CATCH
	ROLLBACK TRANSACTION
		THROW;
			END CATCH
END
GO
CREATE PROCEDURE COMPRAR_OFERTA
	@CLIENTE_ID INT,
	@OFERTA_ID INT,
	@FECHA_COMPRA DATETIME,
	@CODIGO_CUPON INT OUTPUT
AS
BEGIN
	DECLARE @CREDITO DECIMAL(18,2),@PRECIO DECIMAL(18,2), @MAX INT,@CANT INT;

	SELECT @CREDITO = CREDITO
	FROM [NO_SRTA_E_GATOREI].CLIENTES
	WHERE CLIENTE_ID = @CLIENTE_ID;

	SELECT @PRECIO = PRECIO_OFERTA, @MAX = MAXIMO_USUARIO
	FROM [NO_SRTA_E_GATOREI].OFERTAS
	WHERE OFERTA_ID = @OFERTA_ID;

	SELECT @CANT = COUNT(*)
	FROM [NO_SRTA_E_GATOREI].COMPRAS
	WHERE OFERTA_ID = @OFERTA_ID
		AND CLIENTE_ID = @CLIENTE_ID
	GROUP BY OFERTA_ID,CLIENTE_ID;

	IF @MAX <= @CANT
BEGIN
		RETURN -1;
	END
ELSE IF @CREDITO < @PRECIO
BEGIN
		RETURN -2;
	END
ELSE 
BEGIN
		INSERT INTO [NO_SRTA_E_GATOREI].COMPRAS
			(CLIENTE_ID,OFERTA_ID,FECHA_COMPRA)
		VALUES
			(@CLIENTE_ID, @OFERTA_ID, @FECHA_COMPRA);

		SET @CODIGO_CUPON = SCOPE_IDENTITY();

		RETURN 0;
	END
END
GO
CREATE PROCEDURE CONSUMIR_CUPON
	@PROVEEDOR_ID INT,
	@FECHA_CONSUMO DATETIME,
	@CODIGO_CUPON INT
AS
BEGIN
	DECLARE @FECHA_VENCIMIENTO DATETIME, @PROVEEDOR INT, @FECHA_ENTREGA DATETIME;

	SELECT @FECHA_VENCIMIENTO = O.FECHA_VENCIMIENTO, @PROVEEDOR = O.PROVEEDOR_ID, @FECHA_ENTREGA = C.FECHA_CONSUMO
	FROM [NO_SRTA_E_GATOREI].OFERTAS O
		INNER JOIN [NO_SRTA_E_GATOREI].CUPONES C
		ON O.OFERTA_ID = C.OFERTA_ID
	WHERE C.CUPON_ID = @CODIGO_CUPON

	IF @PROVEEDOR_ID <> @PROVEEDOR
BEGIN
		RETURN -1
	END
ELSE IF @FECHA_VENCIMIENTO > @FECHA_CONSUMO
BEGIN
		UPDATE [NO_SRTA_E_GATOREI].CUPONES SET ESTADO = 'VENCIDO' WHERE CUPON_ID = @CODIGO_CUPON
	END
ELSE IF @FECHA_ENTREGA IS NOT NULL 
BEGIN
		RETURN -1
	END
ELSE 
BEGIN
		UPDATE [NO_SRTA_E_GATOREI].CUPONES SET FECHA_CONSUMO = @FECHA_CONSUMO, ESTADO='ENTREGADO' WHERE CUPON_ID = @CODIGO_CUPON
	END
END