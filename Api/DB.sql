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

exec sp_EditarPeliculaSerie 7,'go','nemo','4/4/2020',4,1

insert into Generos(Nombre) values ('Romance')
insert into Generos(Nombre) values ('Terror')
insert into Generos(Nombre) values ('Drama')
insert into Generos(Nombre) values ('Comedia')

select * from Personajes
select * from Peliculas_Series
select * from Generos
select * from Peliculas_Series 
join Generos g on g.id = Peliculas_Series.IdGenero
select p.Id, p.Imagen, p.Titulo, p.Calificacion, g.Nombre from Peliculas_Series p join Generos g on g.id = p.IdGenero where p.id=7
exec sp_InsertarPelicula 'xd', 'Pocahontas', '14/4/1994', 4, 2


insert into Personajes(Nombre,Imagen,Edad,Peso,Historia) values('Mickey','img1',10,10,'lindo raton')
insert into Personajes(Nombre,Imagen,Edad,Peso,Historia) values('Minnie','img2',15,26,'linda ratona')
insert into Personajes(Nombre,Imagen,Edad,Peso,Historia) values('Donald','img3',20,42,'re gd este')
insert into Personajes(Nombre,Imagen,Edad,Peso,Historia) values('Aladin','img4',25,58,'vuela con una alfombra, un capo')
insert into Personajes(Nombre,Imagen,Edad,Peso,Historia) values('Bicho azul de aladin','img5',30,74,'un amigo')
insert into Personajes(Nombre,Imagen,Edad,Peso,Historia) values('Garfio','img6',35,90,'le falta una mano')
insert into Personajes(Nombre,Imagen,Edad,Peso,Historia) values('Peter pan','img7',40,106,'no crece mas')
insert into Personajes(Nombre,Imagen,Edad,Peso,Historia) values('Nemo','img8',45,122,'perdio al nene, el nenee')
insert into Personajes(Nombre,Imagen,Edad,Peso,Historia) values('Dory','img9',50,138,'no se acuerda nada')


insert into Peliculas_Series(Imagen,Titulo,FechaCreacion,Calificacion,IdGenero) values('img1','Los amigos de Mickey','04/08/2021',3,1)
insert into Peliculas_Series(Imagen,Titulo,FechaCreacion,Calificacion,IdGenero) values('img2','Aladin','04/08/2021',5,2)
insert into Peliculas_Series(Imagen,Titulo,FechaCreacion,Calificacion,IdGenero) values('img3','Buscando a Nemo','04/08/2021',5,4)
insert into Peliculas_Series(Imagen,Titulo,FechaCreacion,Calificacion,IdGenero) values('img4','Peter pan','04/08/2021',4,3)
insert into Peliculas_Series(Imagen,Titulo,FechaCreacion,Calificacion,IdGenero) values('img5','Buscando a Dory','04/08/2021',2,2)
insert into Peliculas_Series(Imagen,Titulo,FechaCreacion,Calificacion,IdGenero) values('img6','Fantasia','04/08/2021',1,1)
insert into Peliculas_Series(Imagen,Titulo,FechaCreacion,Calificacion,IdGenero) values('img7','Los tres mosqueteros','04/08/2021',3,4)

insert into Personajes_x_PoS(IdPelicula,IdPersonaje) values (15,9)
insert into Personajes_x_PoS(IdPelicula,IdPersonaje) values (15,10)
insert into Personajes_x_PoS(IdPelicula,IdPersonaje) values (15,11)
insert into Personajes_x_PoS(IdPelicula,IdPersonaje) values (16,13)
insert into Personajes_x_PoS(IdPelicula,IdPersonaje) values (16,12)
insert into Personajes_x_PoS(IdPelicula,IdPersonaje) values (17,16)
insert into Personajes_x_PoS(IdPelicula,IdPersonaje) values (17,17)
insert into Personajes_x_PoS(IdPelicula,IdPersonaje) values (18,15)
insert into Personajes_x_PoS(IdPelicula,IdPersonaje) values (18,14)
insert into Personajes_x_PoS(IdPelicula,IdPersonaje) values (19,16)
insert into Personajes_x_PoS(IdPelicula,IdPersonaje) values (19,17)
insert into Personajes_x_PoS(IdPelicula,IdPersonaje) values (20,9)
insert into Personajes_x_PoS(IdPelicula,IdPersonaje) values (21,9)
insert into Personajes_x_PoS(IdPelicula,IdPersonaje) values (21,11)

select p.Imagen, p.Titulo, p.FechaCreacion, p.Calificacion, per.Nombre from Peliculas_Series p
join Personajes_x_PoS pp on pp.IdPelicula = p.Id
join Personajes per on per.Id = pp.IdPersonaje
where p.id = 15

select per.Nombre from Peliculas_Series p
join Personajes_x_PoS pp on pp.IdPelicula = p.Id
join Personajes per on per.Id = pp.IdPersonaje
where p.id = 15

