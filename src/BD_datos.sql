USE grupo21DB;

-- **CATEGORÍAS**
INSERT INTO CategoriaP (Nombre, Cuenta)
VALUES
    ('Peluches', 1),
    ('Figuras', 1),
    ('Otros', 1);

-- **ATRIBUTOS**
INSERT INTO Atributo (Nombre, Tipo, Cuenta)
VALUES
    ('Precio', 'Real', 1),
    ('Prime', 'Boolean', 1),
    ('Imagen', 'Image', 1),
    ('PDF', 'PDF', 1),
    ('Video', 'Video', 1);

-- **RELACIONES**
INSERT INTO Relaciones (Nombre, CuentaID)
VALUES
    ('Nintendo', 1),
    ('Sony', 1),
    ('Comprados conjuntamente', 1);

-- **PRODUCTOS**

    -- Insertar producto
    INSERT INTO Producto (SKU, GTIN, FechaCreacion, FechaModificacion, Label, Thumbnail, Cuenta)
    VALUES 	('P-1', '18456789010010', '2024-12-14 15:30:45', '2024-12-14 15:30:45', 'Kirby', 
		(SELECT * FROM OPENROWSET(BULK 'C:\BD\T_01.jpg', SINGLE_BLOB) AS Thumbnail), 1),
		('F-1', '18456789023546', '2024-12-15 18:35:45', '2024-12-15 18:35:45', 'Mario', 
		(SELECT * FROM OPENROWSET(BULK 'C:\BD\T_02.jpg', SINGLE_BLOB) AS Thumbnail), 1),
		('O-1', '18456789023324', '2024-12-16 15:30:00', '2024-12-16 15:30:00', 'Pikachu', 
		(SELECT * FROM OPENROWSET(BULK 'C:\BD\T_03.jpg', SINGLE_BLOB) AS Thumbnail), 1),
		('P-2', '18456789023317', '2024-12-17 12:30:00', '2024-12-17 12:30:00', 'AstroBot', 
		(SELECT * FROM OPENROWSET(BULK 'C:\BD\T_04.jpg', SINGLE_BLOB) AS Thumbnail), 1),
		('F-2', '18456789023102', '2024-12-13 00:30:45', '2024-12-13 00:30:45', 'Crash', 
		(SELECT * FROM OPENROWSET(BULK 'C:\BD\T_05.jpg', SINGLE_BLOB) AS Thumbnail), 1),
		('O-2', '18456789023119', '2024-12-12 15:30:45', '2024-12-12 15:30:45', 'Spyro', 
		(SELECT * FROM OPENROWSET(BULK 'C:\BD\T_06.jpg', SINGLE_BLOB) AS Thumbnail), 1),
		('P-3', '18456789023126', '2024-12-11 15:10:15', '2024-12-11 15:10:15', 'Steve', 
		(SELECT * FROM OPENROWSET(BULK 'C:\BD\T_07.jpg', SINGLE_BLOB) AS Thumbnail), 1),
		('F-3', '02456389233115', '2024-12-13 15:30:45', '2024-12-13 15:30:45', 'Sonic', 
		(SELECT * FROM OPENROWSET(BULK 'C:\BD\T_08.jpg', SINGLE_BLOB) AS Thumbnail), 1),
		('O-3', '12456389223113', '2024-12-14 12:30:45', '2024-12-14 12:30:45', 'Ryu', NULL, 1);


-- **RELACIONES_PRODUCTOS**
-- Asociar productos en relaciones de manera simple
INSERT INTO Relaciones_Productos (RelacionID, ProductoOrigenID, ProductoDestinoID)
VALUES
    (1, 1, 2),
    (1, 2, 1),
    (1, 1, 3),
    (1, 3, 1),
    (1, 2, 3),
    (1, 3, 2),
    (2, 4, 5),
    (2, 5, 4),
    (2, 4, 6),
    (2, 6, 4),
    (2, 5, 6),
    (2, 6, 5),
    (3, 1, 8),
    (3, 8, 1),
    (3, 9, 1),
    (3, 1, 9),
    (3, 3, 4),
    (3, 4, 3);


-- **CATEGORIA_PRODUCTOS**
-- Asociar productos en categoria de manera simple
INSERT INTO CategoriaProducto (Producto, Categoria)
VALUES
    (1, 1),
    (4, 1),
    (7, 1),
    (2, 2),
    (5, 2),
    (8, 2),
    (3, 3),
    (6, 3),
    (9, 3);

-- **ATRIBUTO_PRODUCTO**

    -- Precio
    INSERT INTO AtributoProducto (ContenidoReal, Atributo, Producto)
    VALUES (20.50, 1,1),
	(15.70, 1,2),
	(32.50, 1,3),
	(25.00, 1,4),
	(22.50, 1,5),
	(22.25, 1,6),
	(14.10, 1,8),
	(12.50, 1,9);

    -- Prime
    INSERT INTO AtributoProducto (ContenidoBoolean, Atributo, Producto)
    VALUES (0,2,1),
	(0,2,2),
	(0,2,3),
	(1,2,4),
	(1,2,5),
	(0,2,6),
	(0,2,7),
	(1,2,8),
	(0,2,9);

    -- Imagen
    INSERT INTO AtributoProducto (ContenidoBinario, Atributo, Producto)
    VALUES ((SELECT * FROM OPENROWSET(BULK 'C:\BD\I_01.jpg', SINGLE_BLOB) AS ContenidoBinario),3,1),
	((SELECT * FROM OPENROWSET(BULK 'C:\BD\I_02.jpg', SINGLE_BLOB) AS ContenidoBinario),3,2),
	((SELECT * FROM OPENROWSET(BULK 'C:\BD\I_03.jpg', SINGLE_BLOB) AS ContenidoBinario),3,3),
	((SELECT * FROM OPENROWSET(BULK 'C:\BD\I_04.jpg', SINGLE_BLOB) AS ContenidoBinario),3,4),
	((SELECT * FROM OPENROWSET(BULK 'C:\BD\I_05.jpg', SINGLE_BLOB) AS ContenidoBinario),3,5),
	((SELECT * FROM OPENROWSET(BULK 'C:\BD\I_06.jpg', SINGLE_BLOB) AS ContenidoBinario),3,6),
	((SELECT * FROM OPENROWSET(BULK 'C:\BD\I_07.jpg', SINGLE_BLOB) AS ContenidoBinario),3,7),
	((SELECT * FROM OPENROWSET(BULK 'C:\BD\I_08.jpg', SINGLE_BLOB) AS ContenidoBinario),3,8),
	((SELECT * FROM OPENROWSET(BULK 'C:\BD\I_09.jpg', SINGLE_BLOB) AS ContenidoBinario),3,9);


    -- PDF
    INSERT INTO AtributoProducto (ContenidoBinario, Atributo, Producto)
    VALUES ((SELECT * FROM OPENROWSET(BULK 'C:\BD\P_01.pdf', SINGLE_BLOB) AS ContenidoBinario),4,1),
	((SELECT * FROM OPENROWSET(BULK 'C:\BD\P_02.pdf', SINGLE_BLOB) AS ContenidoBinario),4,2);

    -- Video
    INSERT INTO AtributoProducto (ContenidoBinario, Atributo, Producto)
    VALUES ((SELECT * FROM OPENROWSET(BULK 'C:\BD\V_01.mp4', SINGLE_BLOB) AS ContenidoBinario),5,1),
	((SELECT * FROM OPENROWSET(BULK 'C:\BD\V_02.mp4', SINGLE_BLOB) AS ContenidoBinario),5,2),
	((SELECT * FROM OPENROWSET(BULK 'C:\BD\V_03.mp4', SINGLE_BLOB) AS ContenidoBinario),5,3);


DECLARE @ImageData VARBINARY(MAX);
SELECT @ImageData = BulkColumn 
FROM OPENROWSET(BULK N'C:\BD\L_01.jpg', SINGLE_BLOB) AS ImageFile;
UPDATE Cuenta
SET Logo = @ImageData
WHERE ID = 1;

UPDATE Cuenta
SET Nombre = 'Collector Store'
WHERE ID = 1;
