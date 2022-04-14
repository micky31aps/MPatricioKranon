CREATE DATABASE Ejemplo1
USE Ejemplo1
GO

CREATE TABLE Autor
(
IdAutor INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50),
ApellidoPaterno VARCHAR(50),
ApellidoMaterno VARCHAR(50),
Imagen VARBINARY(MAX)
)
GO

CREATE TABLE Editorial
(
IdEditorial INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50),
Imagen VARBINARY(MAX)
)
GO

CREATE TABLE Libro
(
IdLibro INT PRIMARY KEY IDENTITY(1,1),
TituloLibro VARCHAR(50),
AñoPublicacion SMALLINT,
Imagen VARBINARY(MAX)
)
GO

CREATE TABLE AutorLibro
(
IdAutorLibro INT PRIMARY KEY IDENTITY(1,1),
IdAutor INT
FOREIGN KEY (IdAutor) REFERENCES Autor(IdAutor),
IdLibro INT
FOREIGN KEY (IdLibro) REFERENCES Libro(IdLibro)
)
GO

CREATE TABLE LibroEditorial
(
IdLibroEditorial INT PRIMARY KEY IDENTITY(1,1),
IdLibro INT
FOREIGN KEY (Idlibro) REFERENCES Libro(IdLibro),
IdEditorial INT
FOREIGN KEY (IdEditorial) REFERENCES Editorial(IdEditorial)
)
GO

CREATE PROCEDURE GetAllAutor
AS
SELECT IdAutor,
		Nombre,
		ApellidoPaterno,
		ApellidoMaterno,
		Imagen
FROM Autor
GO

CREATE PROCEDURE GetAllLibro
AS
SELECT IdLibro,
		TituloLibro,
		AñoPublicacion,
		Imagen
FROM Libro
GO

CREATE PROCEDURE GetByIdLibro
@IdLibro INT
AS
SELECT IdLibro,
		TituloLibro,
		AñoPublicacion,
		Imagen
FROM Libro
WHERE IdLibro = @IdLibro
GO

CREATE PROCEDURE LibroAdd 
@TituloLibro VARCHAR(50),
@AñoPublicacion SMALLINT,
@Imagen VARBINARY(MAX)
AS
INSERT INTO Libro (TituloLibro, AñoPublicacion, Imagen) VALUES (@TituloLibro, @AñoPublicacion, @Imagen)
GO

CREATE PROCEDURE UpdateLibro
@IdLibro INT,
@TituloLibro VARCHAR(50),
@AñoPublicacion SMALLINT,
@Imagen VARBINARY(MAX)
AS
UPDATE Libro SET TituloLibro = @TituloLibro, AñoPublicacion = @AñoPublicacion, Imagen = @Imagen
WHERE IdLibro = @IdLibro
GO

CREATE PROCEDURE DeleteLibro
@IdLibro INT
AS
DELETE Libro 
WHERE IdLibro = @IdLibro
GO

CREATE PROCEDURE LibroGetAutor
@IdAutor INT
AS
SELECT Libro.IdLibro,
		Libro.TituloLibro,
		Libro.AñoPublicacion,
		Autor.Nombre,
		Autor.ApellidoPaterno,
		Libro.Imagen
FROM AutorLibro
INNER JOIN Libro 
ON Libro.IdLibro = AutorLibro.IdLibro
INNER JOIN Autor
ON Autor.IdAutor = AutorLibro.IdAutor
WHERE AutorLibro.IdAutor = @IdAutor
GO

CREATE PROCEDURE TituloGet 
@TituloLibro VARCHAR(50)
AS
IF (@TituloLibro = '')
BEGIN
SELECT IdLibro,
	TituloLibro,
	AñoPublicacion,
	Imagen
FROM Libro 
END
ELSE
BEGIN
SELECT IdLibro,
	TituloLibro,
	AñoPublicacion,
	Imagen
FROM Libro 
WHERE TituloLibro LIKE '%'+@TituloLibro+'%'
END

GO

CREATE PROCEDURE AñoPublicacionGet 
@AñoPublicacion SMALLINT
AS
SELECT IdLibro,
		TituloLibro,
		AñoPublicacion,
		Imagen
FROM Libro
WHERE AñoPublicacion = @AñoPublicacion
GO

CREATE PROCEDURE LibroGetEditorial 
@IdEditorial INT
AS
SELECT LibroEditorial.IdLibro,
		Libro.TituloLibro,
		Libro.AñoPublicacion,
		Libro.Imagen AS LibroImagen,
		Editorial.Nombre,
		Editorial.Imagen AS EditorialImagen
FROM LibroEditorial
INNER JOIN Editorial
ON Editorial.IdEditorial = LibroEditorial.IdEditorial
INNER JOIN Libro
ON Libro.IdLibro = LibroEditorial.IdLibro
WHERE LibroEditorial.IdEditorial = @IdEditorial
GO

CREATE PROCEDURE AutorGetFecha 
@IdAutor INT,
@AñoPublicacion SMALLINT
AS
SELECT AutorLibro.IdLibro,
		Libro.TituloLibro,
		Libro.AñoPublicacion,
		Libro.Imagen
FROM AutorLibro	
INNER JOIN Libro
ON Libro.IdLibro = AutorLibro.IdLibro
WHERE AutorLibro.IdAutor = @IdAutor AND Libro.AñoPublicacion = @AñoPublicacion
GO

CREATE PROCEDURE AutorDelete 
@IdAutorLibro INT
AS
DELETE AutorLibro 
WHERE IdAutorLibro = @IdAutorLibro
GO

CREATE PROCEDURE EditorialDelete
@IdLibroEditorial INT
AS
DELETE LibroEditorial 
WHERE IdLibroEditorial = @IdLibroEditorial
GO