use Ristorante

create procedure AddMenu
	@data date,
	@pasto nvarchar(7),
	@primo nvarchar(20),
	@secondo  nvarchar(20),
	@contorno nvarchar(20),
	@dolce nvarchar(20)
as
	declare @idGiorno int, @idPasto int
	insert into Giorno (_data) values (@data);
	set @idGiorno = IDENT_CURRENT('Giorno');

	insert into Pasto (tipo,idGiorno) values (@pasto,@idGiorno);
	set @idPasto = IDENT_CURRENT('Pasto');

	insert into Menu (primo,secondo,contorno,dolce,idPasto) values (@primo,@secondo,@contorno,@dolce,@idPasto)
go

create procedure ListMenu
as
	select m.id, p.tipo, g._data from Menu m inner join Pasto p
		on m.idPasto=p.id
		inner join Giorno g
		on p.idGiorno=g.id
go


create procedure ShowMenu
	@id int
as
	select m.id,m.primo,m.secondo,m.contorno,m.dolce,p.tipo,g._data from Menu m inner join Pasto p
		on m.idPasto=p.id
		inner join Giorno g
		on p.idGiorno=g.id
		where m.id=@id
go

select * from Menu
select * from Pasto
select * from Giorno

exec AddMenu '09-05-2018','Pranzo','Pasta','Insalata','Niente','Lucertole'
exec ShowMenu 3
exec ListMenu
