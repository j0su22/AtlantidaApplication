-- Creacion de la BD
CREATE DATABASE AtlantidaApplication;

GO
-- Utilizacion de la BD
USE AtlantidaApplication;

GO
-- Creacion de las tablas con sus llaves primarias
CREATE TABLE AGENCIA(
	id INT IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(100) NOT NULL,
	direccion VARCHAR(500),
	telefono VARCHAR(8),
	extension VARCHAR(5)
);

CREATE TABLE CARGO(
	id INT IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(100) NOT NULL,
	descripcion VARCHAR(500)
);

CREATE TABLE PERSONA(
	id INT IDENTITY(1,1) PRIMARY KEY,
	dui CHAR(10) UNIQUE NOT NULL,
	nombres VARCHAR(50) NOT NULL,
	apellidos VARCHAR(50) NOT NULL,
	correo VARCHAR(100),
	telefono VARCHAR(8),
	fchnacimiento DATE NOT NULL
);

CREATE TABLE EJECUTIVO(
	id INT IDENTITY(1,1) PRIMARY KEY,
	idpersona INT NOT NULL,
	usuario VARCHAR(100) UNIQUE NOT NULL,
	contrasena VARCHAR(100) NOT NULL,
	idagencia INT,
	idcargo INT
);

CREATE TABLE CLIENTE(
	id INT IDENTITY(1,1) PRIMARY KEY,
	idpersona INT NOT NULL,
	usuario VARCHAR(100) UNIQUE NOT NULL,
	contrasena VARCHAR(100) NOT NULL
);

CREATE TABLE PRODUCTO(
	id INT IDENTITY(1,1) PRIMARY KEY,
	codigo VARCHAR(20) UNIQUE NOT NULL,
	nombre VARCHAR(100),
	descripcion VARCHAR(500),
	ptjinteres FLOAT,
	ptjsaldominimo FLOAT,
	rngminimo INT,
	rngmaximo INT
);

CREATE TABLE CLIENTEXPRODUCTO(
	id INT IDENTITY(1,1),
	idcliente INT NOT NULL,
	idproducto INT NOT NULL,
	fchsolicitud DATETIME,
	fchaprobacion DATETIME,
	saldoaprobado MONEY,
	saldodisponible MONEY,

	CONSTRAINT PK_CLIENTEXPRODUCTO PRIMARY KEY (id, idcliente, idproducto)
);

CREATE TABLE TIPOTRANSACCION(
	id INT IDENTITY(1,1) PRIMARY KEY,
	codigo VARCHAR(20) UNIQUE NOT NULL,
	nombre VARCHAR(100),
	descripcion VARCHAR(500)
);

CREATE TABLE TRANSACCION(
	id INT IDENTITY(1,1) PRIMARY KEY,
	idtipotransaccion INT NOT NULL,
	idcliente INT NOT NULL,
	idejecutivo INT NOT NULL,
	idproducto INT NOT NULL,
	idagencia INT,
	fechahora DATETIME,
	monto MONEY,
	descripcion VARCHAR(500)
);

GO
-- Creacion de relaciones (llaves foraneas)
ALTER TABLE EJECUTIVO
ADD CONSTRAINT FK_EJECUTIVO_PERSONA
FOREIGN KEY (idpersona) REFERENCES PERSONA(id)
;

ALTER TABLE EJECUTIVO
ADD CONSTRAINT FK_EJECUTIVO_AGENCIA
FOREIGN KEY (idagencia) REFERENCES AGENCIA(id)
;

ALTER TABLE EJECUTIVO
ADD CONSTRAINT FK_EJECUTIVO_CARGO
FOREIGN KEY (idcargo) REFERENCES CARGO(id)
;

ALTER TABLE CLIENTE
ADD CONSTRAINT FK_CLIENTE_PERSONA
FOREIGN KEY (idpersona) REFERENCES PERSONA(id)
;

ALTER TABLE CLIENTEXPRODUCTO
ADD CONSTRAINT FK_CXP_CLIENTE
FOREIGN KEY (idcliente) REFERENCES CLIENTE(id)
;

ALTER TABLE CLIENTEXPRODUCTO
ADD CONSTRAINT FK_CXP_PRODUCTO
FOREIGN KEY (idproducto) REFERENCES PRODUCTO(id)
;

ALTER TABLE TRANSACCION
ADD CONSTRAINT FK_TRANSACCION_TIPOTRANSACCION
FOREIGN KEY (idtipotransaccion) REFERENCES TIPOTRANSACCION(id)
;

ALTER TABLE TRANSACCION
ADD CONSTRAINT FK_TRANSACCION_CLIENTE
FOREIGN KEY (idcliente) REFERENCES CLIENTE(id)
;

ALTER TABLE TRANSACCION
ADD CONSTRAINT FK_TRANSACCION_EJECUTIVO
FOREIGN KEY (idejecutivo) REFERENCES EJECUTIVO(id)
;

ALTER TABLE TRANSACCION
ADD CONSTRAINT FK_TRANSACCION_PRODUCTO
FOREIGN KEY (idproducto) REFERENCES PRODUCTO(id)
;

ALTER TABLE TRANSACCION
ADD CONSTRAINT FK_TRANSACCION_AGENCIA
FOREIGN KEY (idagencia) REFERENCES AGENCIA(id)
;
