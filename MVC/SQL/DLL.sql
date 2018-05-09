create database Ristorante
use Ristorante

create table Giorno(
	id int identity(1,1) not null primary key,
	_data date
)

create table Pasto(
	id int identity(1,1) not null primary key,
	tipo nvarchar(7),
	idGiorno int foreign key references Giorno
)

create table Menu(
	id int identity(1,1) not null primary key,
	primo nvarchar(20),
	secondo nvarchar(20),
	contorno nvarchar(20),
	dolce nvarchar(20),
	idPasto int foreign key references Pasto
)
