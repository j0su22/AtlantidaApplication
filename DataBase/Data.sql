use AtlantidaApplication;

-- Insertar datos en la tabla AGENCIA
INSERT INTO AGENCIA(nombre, direccion, telefono, extension) VALUES
('Sucursal Centro', 'Calle Principal #123, Centro', '12345678', '100'),
('Sucursal Norte', 'Avenida Norte #456, Zona 10', '23456789', '200');

-- Insertar datos en la tabla CARGO
INSERT INTO CARGO(nombre, descripcion) VALUES
('Gerente', 'Responsable de la gestión y liderazgo del equipo'),
('Asesor Financiero', 'Proporciona asesoramiento financiero a los clientes');

-- Insertar datos en la tabla PERSONA QUE SERAN EJECUTIVOS
INSERT INTO PERSONA(dui, nombres, apellidos, correo, telefono, fchnacimiento, flgejecutivo) VALUES
('01234567-8', 'Juan', 'Pérez', 'juan.perez@example.com', '87654321', '1980-01-01', 'S'),
('87654321-0', 'Ana', 'López', 'ana.lopez@example.com', '98765432', '1990-02-02', 'S');

-- Insertar datos en la tabla PERSONA QUE SERAN CLIENTES
INSERT INTO PERSONA(dui, nombres, apellidos, correo, telefono, fchnacimiento) VALUES
('23456789-1', 'Carlos', 'Martínez', 'carlos.martinez@example.com', '87654321', '1985-03-03'),
('34567890-2', 'María', 'Rodríguez', 'maria.rodriguez@example.com', '98765432', '1992-04-04'),
('45678901-3', 'Luis', 'Hernández', 'luis.hernandez@example.com', '87654321', '1988-05-05');

-- Insertar datos en la tabla EJECUTIVO
-- Nota: Asegúrate de que los ID de persona, agencia y cargo existan.
INSERT INTO EJECUTIVO(idpersona, idagencia, idcargo) VALUES
(1, 1, 1),
(2, 2, 2);

-- Insertar datos en la tabla PRODUCTO
INSERT INTO PRODUCTO(codigo, nombre, descripcion, ptjinteres, ptjsaldominimo, rngminimo, rngmaximo) VALUES
('PROD001', 'Cuenta de Ahorro', 'Cuenta para ahorros', 2.5, 13.00, 100, 10000),
('PROD002', 'Cuenta Corriente', 'Cuenta para manejo diario de dinero', 4.8, 13.00, 100, 10000),
('PROD003', 'Tarjeta de Credito Silver', 'Cuenta para para ahorros asociada a una tarjeta de credito', 1.3, 13.0, 300, 900),
('PROD004', 'Tarjeta de Credito Gold', 'Cuenta para para ahorros asociada a una tarjeta de credito', 1.3, 13.0, 900, 2000);

-- Insertar datos en la tabla CLIENTEXPRODUCTO
-- Nota: Asegúrate de que los ID de cliente y producto existan.
INSERT INTO CLIENTEXPRODUCTO(idcliente, idproducto, fchsolicitud, fchaprobacion, saldoaprobado, saldodisponible) VALUES
(3, 4, '2023-04-15', '2023-05-05', 1000.00, 1000.00),
(4, 4, '2023-07-26', '2023-08-14', 1200.00, 1200.00),
(5, 3, '2023-01-10', '2023-03-15', 500.00, 500.00);

-- Insertar datos en la tabla TIPOTRANSACCION
INSERT INTO TIPOTRANSACCION(codigo, nombre, descripcion) VALUES
('DEP', 'Depósito', 'Depósito de dinero en cuenta'),
('GTO', 'Gastos', 'Retiro de dinero de cuenta');

-- Insertar datos en la tabla TRANSACCION
-- Nota: Asegúrate de que los ID correspondientes existan.
INSERT INTO TRANSACCION(idtipotransaccion, idcliente, idejecutivo, idproducto, idagencia, fechahora, monto, descripcion) VALUES
(2, 3, 1, 4, 1, '2023-05-06 10:00:00', 100.00, 'Retiro de efectivo'),
(2, 3, 1, 4, 1, '2023-05-07 10:15:00', 150.00, 'Retiro por cajero'),
(2, 3, 1, 4, 1, '2023-05-08 11:00:00', 200.00, 'Retiro de emergencia'),
(2, 4, 1, 4, 1, '2023-08-15 09:00:00', 200.00, 'Pago de servicios'),
(2, 4, 1, 4, 1, '2023-08-16 14:30:00', 250.00, 'Compra online'),
(2, 4, 1, 4, 1, '2023-08-17 16:45:00', 300.00, 'Retiro personal'),
(2, 5, 1, 3, 1, '2023-03-16 08:30:00', 50.00, 'Retiro pequeño'),
(2, 5, 1, 3, 1, '2023-03-17 12:45:00', 75.00, 'Pago de deuda'),
(2, 5, 1, 3, 1, '2023-03-18 17:00:00', 125.00, 'Retiro de fin de semana'),
(2, 3, 1, 4, 1, '2023-05-09 12:00:00', 250.00, 'Retiro semanal'),
(2, 4, 1, 4, 1, '2023-08-18 13:00:00', 350.00, 'Gastos médicos'),
(2, 5, 1, 3, 1, '2023-03-19 14:30:00', 150.00, 'Retiro para regalos');
