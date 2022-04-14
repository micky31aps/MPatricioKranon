
INSERT INTO Autor (Nombre, ApellidoPaterno, ApellidoMaterno, Imagen) VALUES ('Jorge Luis', 'Borges', '', null)
INSERT INTO Autor (Nombre, ApellidoPaterno, ApellidoMaterno, Imagen) VALUES ('Hans Christian', 'Andersen', '', null)
INSERT INTO Autor (Nombre, ApellidoPaterno, ApellidoMaterno, Imagen) VALUES ('Miguel de Cervantes', 'Saavedra', '', null)
INSERT INTO Autor (Nombre, ApellidoPaterno, ApellidoMaterno, Imagen) VALUES ('Geoffrey', 'Chaucer', '', null)
INSERT INTO Autor (Nombre, ApellidoPaterno, ApellidoMaterno, Imagen) VALUES ('Denis', 'Diderot', '', null)
INSERT INTO Autor (Nombre, ApellidoPaterno, ApellidoMaterno, Imagen) VALUES ('Fiodor', 'Dosteievski', '', null)
INSERT INTO Autor (Nombre, ApellidoPaterno, ApellidoMaterno, Imagen) VALUES ('William', 'Faulkner', '', null)
INSERT INTO Autor (Nombre, ApellidoPaterno, ApellidoMaterno, Imagen) VALUES ('Gustave', 'Flaubert', '', null)
INSERT INTO Autor (Nombre, ApellidoPaterno, ApellidoMaterno, Imagen) VALUES ('Gabriel', 'Garcia', 'Marquez', null)
INSERT INTO Autor (Nombre, ApellidoPaterno, ApellidoMaterno, Imagen) VALUES ('Federico', 'Garcia', 'Lorca', null)
GO 

INSERT INTO Libro ( TituloLibro, AñoPublicacion, Imagen) VALUES ( 'Ficciones', '1947', null)
INSERT INTO Libro ( TituloLibro, AñoPublicacion, Imagen) VALUES ( 'La sirenita', '1837', null)
INSERT INTO Libro ( TituloLibro, AñoPublicacion, Imagen) VALUES ( 'Don Quijote de la Mancha', '1890', null)
INSERT INTO Libro ( TituloLibro, AñoPublicacion, Imagen) VALUES ( 'Los cuentos de Canterbury', '1484', null)
INSERT INTO Libro ( TituloLibro, AñoPublicacion, Imagen) VALUES ( 'Jacques el fatalista', '1796', null)
INSERT INTO Libro ( TituloLibro, AñoPublicacion, Imagen) VALUES ( 'Crimer y castigo', '1869', null)
INSERT INTO Libro ( TituloLibro, AñoPublicacion, Imagen) VALUES ( 'El riudo y la furia', '1929', null)
INSERT INTO Libro ( TituloLibro, AñoPublicacion, Imagen) VALUES ( 'La educacion sentimental', '1869', null)
INSERT INTO Libro ( TituloLibro, AñoPublicacion, Imagen) VALUES ( 'El amor en los tiempos del colera', '1985', null)
INSERT INTO Libro ( TituloLibro, AñoPublicacion, Imagen) VALUES ( 'Romancero gitano', '1928', null)
GO
--SELECT * FROM Libro

INSERT INTO Editorial (Nombre, Imagen) VALUES ('Emecé Editores', null)
INSERT INTO Editorial (Nombre, Imagen) VALUES ('Ignác Leopold Kober', null)
INSERT INTO Editorial (Nombre, Imagen) VALUES ('Librería de Garnier Hermanos', null)
INSERT INTO Editorial (Nombre, Imagen) VALUES ('Catedra', null)
INSERT INTO Editorial (Nombre, Imagen) VALUES ('ALMA Clasicos Ilustrados', null)
INSERT INTO Editorial (Nombre, Imagen) VALUES ('Gandhi', null)
INSERT INTO Editorial (Nombre, Imagen) VALUES ('La Oveja Negra', null)
GO


INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (1,1)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (1,2)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (1,3)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (2,10)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (2,9)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (2,2)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (3,3)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (3,4)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (3,5)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (4,4)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (4,1)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (4,10)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (5,5)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (6,6)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (7,7)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (8,8)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (9,9)
INSERT INTO AutorLibro (IdAutor, IdLibro) VALUES (10,10)
GO


INSERT INTO LibroEditorial (IdLibro, IdEditorial) VALUES (1,1)
INSERT INTO LibroEditorial (IdLibro, IdEditorial) VALUES (2,2)
INSERT INTO LibroEditorial (IdLibro, IdEditorial) VALUES (3,3)
INSERT INTO LibroEditorial (IdLibro, IdEditorial) VALUES (4,4)
INSERT INTO LibroEditorial (IdLibro, IdEditorial) VALUES (5,4)
INSERT INTO LibroEditorial (IdLibro, IdEditorial) VALUES (6,6)
INSERT INTO LibroEditorial (IdLibro, IdEditorial) VALUES (7,7)
INSERT INTO LibroEditorial (IdLibro, IdEditorial) VALUES (8,7)
INSERT INTO LibroEditorial (IdLibro, IdEditorial) VALUES (9,9)
INSERT INTO LibroEditorial (IdLibro, IdEditorial) VALUES (10,4)
GO
SELECT * FROM Libro
SELECT * FROM Editorial
SELECT * FROM LibroEditorial
TRUNCATE TABLE LibroEditorial