INSERT INTO [dbo].[Usuario] (nombre, apellido, correo, clave, tipoUsuario, estado, idTipoVehiculo, idGestor)
VALUES 
('Juan', 'Pérez', 'juan.perez@mail.com', 'clave123', 1, 1, 1, 1),
('Ana', 'Gómez', 'ana.gomez@mail.com', 'pass456', 2, 1, 2, 1),
('Carlos', 'Lopez', 'carlos.lopez@mail.com', 'secreta789', 1, 0, 1, 2),
('Lucía', 'Martinez', 'lucia.m@mail.com', 'clave321', 2, 1, 2, 2),
('Pedro', 'Ramirez', 'pedro.r@mail.com', 'clave654', 1, 1, 1, 1);


INSERT INTO [dbo].[Vehiculo] ([idTipoVehiculo], [nombreVehiculo], [imagenUrl])
VALUES 
(1, 'Motocicleta', 'https://www.freepik.es/vector-premium/pedido-entrega-domicilio-ilustracion-color-semi-rgb_9784799.htm#fromView=search&page=1&position=45&uuid=2e5bc9f5-f269-4e84-941d-d7d114e55093&query=motocicleta+delivery'),
(2, 'Monopatín', 'https://www.freepik.es/vector-gratis/concepto-servicio-entrega_16692186.htm#fromView=search&page=1&position=44&uuid=3f8098cf-bdfa-48b2-b4a0-c70f34e333b8&query=monopatin+delivery'),
(3, 'Bicicleta', 'https://www.freepik.es/vector-gratis/ilustracion-concepto-reparto-bicicleta-dibujada-mano_4424571.htm#fromView=search&page=1&position=0&uuid=e99a17ff-e362-4986-bbf3-4405ce3371de&query=bicicleta+delivery');


-- Usuario 1-3: Motocicleta
INSERT INTO [dbo].[Usuario] ([nombre], [apellido], [correo], [clave], [tipoUsuario], [estado], [idTipoVehiculo], [idGestor])
VALUES
('Juan', 'Pérez', 'juan.perez@example.com', 'clave123', 1, 1, 1, 1),
('Ana', 'García', 'ana.garcia@example.com', 'clave123', 1, 1, 1, 5001),
('Luis', 'Martínez', 'luis.martinez@example.com', 'clave123', 1, 1, 1, 1);

-- Usuario 4-6: Bicicleta
INSERT INTO [dbo].[Usuario] ([nombre], [apellido], [correo], [clave], [tipoUsuario], [estado], [idTipoVehiculo], [idGestor])
VALUES
('María', 'López', 'maria.lopez@example.com', 'clave123', 1, 1, 3, 5001),
('Carlos', 'Sosa', 'carlos.sosa@example.com', 'clave123', 1, 1, 3, 1),
('Lucía', 'Ramírez', 'lucia.ramirez@example.com', 'clave123', 1, 1, 3, 5001);

-- Usuario 7-9: Monopatín
INSERT INTO [dbo].[Usuario] ([nombre], [apellido], [correo], [clave], [tipoUsuario], [estado], [idTipoVehiculo], [idGestor])
VALUES
('Diego', 'Fernández', 'diego.fernandez@example.com', 'clave123', 1, 1, 2, 1),
('Sofía', 'Morales', 'sofia.morales@example.com', 'clave123', 1, 1, 2, 5001),
('Pedro', 'Gómez', 'pedro.gomez@example.com', 'clave123', 1, 1, 2, 1);

INSERT INTO [dbo].[Poliza] (nombrePack, descripcionCobertura, precio, estado)
VALUES
('Ruta Segura', 'Robo total y asistencia vial.', 12000, 1),

('Guardian Total', 'Robo, daños y gastos médicos.', 20000, 1),

('Escudo Básico', 'Robo total y asistencia vial.', 5000, 1),

('Protección Máxima', 'Robo, daños y accidentes personales.', 9000, 1),

('Pedal Seguro', 'Robo total y asistencia vial.', 4500, 1),

('Ciclo completo', 'Robo, daños y accidentes personales.', 7500, 1);

INSERT INTO [dbo].[Siniestro] (fechaSiniestro, horaSiniestro, descripcion, idusuario, idpoliza, estado)
VALUES
('2025-05-01', '14:30', 'Robo de bicicleta en vía pública', 1, 10, 1),
('2025-05-03', '09:15', 'Daños por accidente en cruce peatonal', 2, 120, 1),
('2025-05-05', '17:45', 'Robo de bici en cochera de edificio', 3, 230, 1),
('2025-05-07', '20:00', 'Accidente con auto, lesiones leves', 4, 340, 1),
('2025-05-08', '12:20', 'Bici sustraída de parque público', 5, 450, 1),
('2025-05-10', '16:00', 'Daños materiales tras caída en calzada', 6, 560, 1);


INSERT INTO [dbo].[Siniestro] 
(idSiniestro, fecha, hora, descripcion, imagenUrl, estadoSolicitud, idUsuario, idPoliza)
VALUES
(3000, '2025-05-01', '14:30', 'Robo de bicicleta en vía pública', NULL, 'ACEPTADA', 2, 10),
(3001, '2025-05-03', '09:15', 'Daños por accidente en cruce peatonal', NULL, 'RECHAZADA', 3, 120),
(3002, '2025-05-05', '17:45', 'Robo de bici en cochera de edificio', NULL, 'EN CURSO', 4, 230),
(3003, '2025-05-07', '20:00', 'Accidente con auto, lesiones leves', NULL, 'ACEPTADA', 5, 340),
(3004, '2025-05-08', '12:20', 'Bici sustraída de parque público', NULL, 'RECHAZADA', 6, 450),
(3005, '2025-05-10', '16:00', 'Daños materiales tras caída en calzada', NULL, 'EN CURSO', 7, 560);
