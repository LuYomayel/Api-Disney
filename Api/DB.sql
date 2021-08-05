--use master
--drop database Disney
create database Disney
go
use Disney
go
create table Generos(
	id int not null primary key identity(1,1),
	Nombre varchar(50) null,
	Imagen varchar(200) null
)
go 
create table Peliculas_Series(
	Id int not null primary key identity(1,1),
	Imagen varchar(200) null,
	Titulo varchar(100) null,
	FechaCreacion date null,
	Calificacion int null,
	IdGenero int not null foreign key references Generos(id)
)
go
create table Personajes_x_PoS(
	IdPelicula int not null foreign key references Peliculas_Series(Id),
	IdPersonaje int not null foreign key references Personajes(Id)
)
ALTER table Personajes_x_PoS ADD PRIMARY KEY (IdPelicula, IdPersonaje)
go
create table Personajes(
	id int not null primary key identity(1,1),
	Nombre varchar(50) null,
	Imagen varchar(200) null,
	Edad int null ,
	Peso int null ,
	Historia varchar(300) null
)

CREATE PROCEDURE sp_InsertarPersonaje(
 @Nombre VARCHAR(50),
 @Imagen VARCHAR(200),
 @Edad int,
 @Peso int,
 @Historia VARCHAR(300)
)
AS
BEGIN
  INSERT INTO Personajes(Nombre, Imagen, Edad, Peso, Historia) VALUES(@Nombre, @Imagen, @Edad, @Peso, @Historia)
END

CREATE PROCEDURE sp_EliminarPersonajexId(
 @Id int
)
AS
BEGIN
  delete Personajes where id = @Id
END

CREATE PROCEDURE sp_EditarPersonajexId(
 @Id int,
 @Nombre VARCHAR(50),
 @Imagen VARCHAR(200),
 @Edad int,
 @Peso int,
 @Historia VARCHAR(300)
)
AS
BEGIN
  update Personajes set Nombre = @Nombre, Imagen=@Imagen, Edad=@Edad, Peso = @Peso, Historia=@Historia where Id = @Id
END
use Disney

exec sp_EliminarPersonajexId 2
select * from Personajes


Create PROCEDURE sp_InsertarPelicula(
 
	@Imagen VARCHAR(200),
	@Titulo VARCHAR(100),
	@FechaCreacion date,
	@Calificacion int,
	@IdGenero int
)
AS
BEGIN
	
	INSERT INTO Peliculas_Series(Imagen, Titulo, FechaCreacion, Calificacion, IdGenero) VALUES(@Imagen, @Titulo, @FechaCreacion, @Calificacion, @IdGenero)
END

Create PROCEDURE sp_EliminarPeliculaSerie(
	@Id int
)
AS
BEGIN
	Delete Peliculas_Series where id = @Id
END

CREATE PROCEDURE sp_EditarPeliculaSerie(
	@Id int,
	@Imagen VARCHAR(200),
	@Titulo VARCHAR(100),
	@FechaCreacion date,
	@Calificacion int,
	@IdGenero int
)
AS
BEGIN
  update Peliculas_Series set Titulo = @Titulo, Imagen=@Imagen, FechaCreacion=@FechaCreacion, Calificacion = @Calificacion, IdGenero= @IdGenero where Id = @Id
END




