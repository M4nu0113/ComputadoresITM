CREATE DATABASE DBComputadores
GO
USE DBComputadores
GO

CREATE TABLE [TipoComputador]
(
	[Codigo] INT IDENTITY(1,1) NOT NULL,
	[Descripcion] VARCHAR(50) NOT NULL,
	CONSTRAINT [PKTipoComputador] PRIMARY KEY CLUSTERED ([Codigo]) 
) ON [PRIMARY]
GO

INSERT [dbo].[TipoComputador]([Descripcion]) 
VALUES ('Servidores'),
		('Equipo de escritorio'),
		('Portátil'),
		('Gamer'),
		('NetBooks');
GO

SELECT * FROM [TipoComputador]
GO

CREATE TABLE [Cliente]
(
	[Documento] VARCHAR(20) NOT NULL,
	[Nombre] VARCHAR(50) NOT NULL,
	[Telefono] VARCHAR(20) NOT NULL,
	[Correo] VARCHAR(200) NOT NULL,
	[Direccion] VARCHAR(200) NOT NULL,
	CONSTRAINT [PKCliente] PRIMARY KEY CLUSTERED ([Documento])
) ON [PRIMARY]
GO

INSERT [dbo].[Cliente]([Documento],[Nombre],[Telefono],[Correo],[Direccion])
VALUES 
('71663666', 'Carlos Cadavid', '3452627271', 'carloscadavid@gmail.com', 'CR 30 #30-12'),
('1089932038', 'Manuela Estrada', '3234586473', 'manuelaestrada@gmail.com', 'CL 36 #77-25'),
('123456789', 'Juanita Estrada', '3104146027', 'juanitaestrada@gmail.com', 'CL 77 #45-10'),
('1893034893', 'Juan Camilo Duarte', '3536724563', 'juanduarte@gmail.com', 'CR 20 #25-08');
GO

SELECT * FROM [Cliente]
GO

CREATE TABLE [Agencia]
( 
	[Nit] VARCHAR(200) NOT NULL,
	[Nombre] VARCHAR(50) NOT NULL,
	[Correo] VARCHAR(200) NOT NULL,
	[Ciudad] VARCHAR(50) NOT NULL,
	[Direccion] VARCHAR(200) NOT NULL,
	[SitioWeb] VARCHAR(200) NOT NULL,
	CONSTRAINT [PKAgencia] PRIMARY KEY CLUSTERED ([Nit])
) ON [PRIMARY]
GO

INSERT [dbo].[Agencia]([Nit], [Nombre], [Correo], [Ciudad], [Direccion],[SitioWeb])
VALUES ('987654321','Computadores ITM', 'servicioalcliente@compuitm.edu.co', 'Medellín' ,'Calle 75 #75-101', 'www.computadoresitm.com');

INSERT INTO [Agencia]
VALUES
	('05802801002017', 'tecnologia UdeA', 'tecnologia@udea.com', 'Bogotá', 'Carrera 50 # 60-170', 'www.UdeAtecnologia.com'),
	('05802800702023', 'hardware UNAL', 'hardware@unal.com', 'Medellin', 'Carrera 25 # 50-150', 'www.UNALhardware.com')
GO


SELECT * FROM [Agencia]
GO


CREATE TABLE [Computador]
(
	[Codigo] INT IDENTITY(1,1) NOT NULL,
	[CodigoTipo] INT NOT NULL,
	[CantProcesadores] INT NOT NULL,
	[MarcaProcesador] VARCHAR(50) NOT NULL,
	[CapacidadSD] VARCHAR(20) NOT NULL,
	[CapacidadMemoria] VARCHAR(20) NOT NULL,
	[Componentes] VARCHAR(500) NOT NULL
	CONSTRAINT [PKComputador] PRIMARY KEY CLUSTERED ([Codigo]),
	CONSTRAINT [FK_Computador_TipoComputador] FOREIGN KEY ([CodigoTipo]) REFERENCES [dbo].[TipoComputador]([Codigo])
) ON [PRIMARY]
GO

INSERT INTO [Computador]([CodigoTipo], [CantProcesadores], [MarcaProcesador], [CapacidadSD],[CapacidadMemoria],[Componentes])
VALUES
	(1, 8, 'Intel Xeon', '4TB', '64GB', 'Fuente redundante, Sistema de refrigeración, Tarjeta de red Gigabit'),
    (2, 1, 'Intel Core i3', '512GB', '8GB', 'Mouse, Teclado, Monitor, Altavoces'),
    (4, 4, 'AMD Ryzen 9', '2TB', '32GB', 'Mouse, Teclado mecánico, Monitor de 144Hz, Tarjeta gráfica NVIDIA RTX 3080'),
    (3, 1, 'Intel Core i7', '1TB', '16GB', 'Teclado integrado, Touchpad, Cámara, Altavoces'),
    (5, 1, 'Intel Core i5', '512GB', '8GB', 'Pantalla táctil, Teclado desmontable, Altavoces integrados'),
    (3, 1, 'Intel Atom', '128GB', '4GB', 'Teclado compacto, Pantalla pequeña, Batería de larga duración')
GO

SELECT * FROM [Computador]


CREATE TABLE [Venta] 
(
	[Codigo] INT IDENTITY(1,1) NOT NULL,
	[CodigoAgencia] VARCHAR(200) NOT NULL,
	[CodigoCliente] VARCHAR(20) NOT NULL,
	[CodigoComputador] INT NOT NULL,
	[FechaVenta] DATETIME NOT NULL,
	[Valor] INT NOT NULL,
	CONSTRAINT [PKVenta] PRIMARY KEY CLUSTERED ([Codigo]),
	CONSTRAINT [FK_Venta_Agencia] FOREIGN KEY ([CodigoAgencia]) REFERENCES [dbo].[Agencia]([NIT]),
	CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY ([CodigoCliente]) REFERENCES [dbo].[Cliente]([Documento]),
	CONSTRAINT [FK_Venta_Computador] FOREIGN KEY ([CodigoComputador]) REFERENCES [dbo].[Computador]([Codigo])
) ON [PRIMARY]

INSERT INTO [Venta]([CodigoAgencia],[CodigoCliente],[CodigoComputador],[FechaVenta],[Valor])
VALUES
    ('987654321', '1089932038', 8, GETDATE(), 3250000),
    ('05802801002017', '123456789', 11, GETDATE(), 1500000),
    ('05802800702023', '1893034893', 10, GETDATE(), 4500000),
    ('05802801002017', '71663666', 7, GETDATE(), 2800000),
    ('987654321', '71663666',9, GETDATE(), 2200000),
    ('05802800702023', '1089932038', 12, GETDATE(), 1000000)
GO

SELECT * FROM [Venta]
GO

CREATE TABLE [ImagenesComp]
( 
	[Codigo] INT IDENTITY(1,1) NOT NULL,
	[NombreImagen] VARCHAR(50) NOT NULL,
	[CodigoComputador] INT NOT NULL,
	CONSTRAINT [PKImagen] PRIMARY KEY CLUSTERED ([Codigo]),
	CONSTRAINT [FK_Imagen_Computador] FOREIGN KEY ([CodigoComputador]) REFERENCES [dbo].[Computador]([Codigo])
) ON [PRIMARY]

GO