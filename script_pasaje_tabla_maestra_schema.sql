USE [GD2C2019]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


INSERT INTO [NO_SRTA_E_GATOREI].[DIRECCIONES]
           ([DIRECCION]
           ,[CIUDAD]
           ,[CODIGO_POSTAL])
    SELECT Cli_Direccion, Cli_Ciudad , NULL 
    FROM [gd_esquema].[Maestra]
	GROUP BY Cli_Direccion, Cli_Ciudad 
GO

INSERT INTO [NO_SRTA_E_GATOREI].[DIRECCIONES]
           ([DIRECCION]
           ,[CIUDAD]
           ,[CODIGO_POSTAL])
    SELECT Provee_Dom, Provee_Ciudad , NULL 
    FROM [gd_esquema].[Maestra]
	WHERE Provee_Dom IS NOT NULL
	GROUP BY Provee_Dom, Provee_Ciudad 
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
     SELECT m.Cli_Dni, m.Cli_Nombre, m.Cli_Apellido, m.Cli_Mail, m.Cli_Telefono, m.Cli_Fecha_Nac, NULL , d.DIRECCION_ID
	 FROM [gd_esquema].[Maestra] m INNER JOIN [NO_SRTA_E_GATOREI].[DIRECCIONES] d ON m.Cli_Direccion = d.DIRECCION
	 GROUP BY m.Cli_Dni, m.Cli_Nombre, m.Cli_Apellido, m.Cli_Mail, m.Cli_Telefono, m.Cli_Fecha_Nac, d.DIRECCION_ID
GO

INSERT INTO [NO_SRTA_E_GATOREI].[PROVEEDORES] 
           ([CUIT]
           ,[RAZON_SOCIAL]
           ,[NOMBRE_CONTACTO]
           ,[RUBRO]
           ,[MAIL]
           ,[TELEFONO]
           ,[USUARIO_ID]
           ,[DIRECCION_ID])
    SELECT m.Provee_CUIT, m.Provee_RS, NULL, m.Provee_Rubro,NULL, m.Provee_Telefono, NULL , d.DIRECCION_ID
	FROM [gd_esquema].[Maestra] m LEFT JOIN [NO_SRTA_E_GATOREI].[DIRECCIONES] d ON m.Provee_Dom = d.DIRECCION
    WHERE Provee_CUIT IS NOT NULL -- TODO revisar esto, sino trae la primer row null y rompe, creo que es porque hay rows sin proveedores y las agrupa en null
	GROUP BY Provee_CUIT, Provee_RS,Provee_Rubro, Provee_Telefono, d.DIRECCION_ID
GO

INSERT INTO [NO_SRTA_E_GATOREI].[OFERTAS]
           ([PRECIO_LISTA]
           ,[PRECIO_OFERTA]
           ,[FECHA_PUBLICACION]
           ,[FECHA_VENCIMIENDO]
           ,[CANTIDAD]
           ,[DESCRIPCION]
           ,[FECHA_COMPRA]
           ,[CODIGO]
           ,[ENTREGADO])
    SELECT Oferta_Precio, Oferta_Precio_Ficticio, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Cantidad, Oferta_Descripcion, 
	Oferta_Fecha_Compra, Oferta_Codigo, NULL
	FROM [gd_esquema].[Maestra]
	WHERE Oferta_Codigo IS NOT NULL --mismo que arriba
	GROUP BY Oferta_Precio, Oferta_Precio_Ficticio, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Cantidad, Oferta_Descripcion, 
	Oferta_Fecha_Compra, Oferta_Codigo
GO


INSERT INTO [NO_SRTA_E_GATOREI].[COMPRAS]
           ([OFERTA_ID]
           ,[CLIENTE_ID]
           ,[FECHA_COMPRA])
    SELECT o.OFERTA_ID, c.CLIENTE_ID,  o.FECHA_COMPRA 
	FROM [gd_esquema].[Maestra] m JOIN [NO_SRTA_E_GATOREI].[OFERTAS] o ON m.Oferta_Codigo = o.CODIGO 
	JOIN [NO_SRTA_E_GATOREI].[CLIENTEs] c ON m.Cli_Dni = c.DNI
	 
GO
		   
		   