--CREATE DATABASE Gestion_hotel;
go
use Gestion_hotel;
go

create table Client
(
	id int identity(1,1) not null,
	noms nvarchar (100) not null,
	adresse nvarchar (100),
	contact nvarchar (100)
)

create table Reservation
(
	id int identity(1,1) not null,
	refClient int not null,
	refChabre int ,
	dateEntree date
)

create table Chambre
(
	id int identity(1,1) not null,
	numero int not null,
	contact nvarchar (100),
	refClasse int
)

create table Categorisation
(
	id int identity(1,1) not null,
	desgnation nvarchar (100)
)

create table Classe
(
	id int identity(1,1) not null,
	designation nvarchar (100),
	prix decimal (30,2)
	refCategorisation int
)

--==============================================================================================

--CREATION DES CLES PRIMAIRES

alter table Client
add constraint pk_idClient primary key(id)
alter table Reservation
add constraint pk_idReservation primary key(id)
alter table Chambre
add constraint pk_idChambre primary key(id)
alter table Categorisation
add constraint pk_idCategorisation primary key(id)
alter table Classe
add constraint pk_idClasse primary key(id)

alter table Classe
add refCategorisation int

--CREATION DES CLES ETRANGERES

alter table Reservation
add constraint fk_refClient foreign key (refClient)
references Client (id)
alter table Reservation
add constraint fk_refchambre foreign key (refChabre)
references Chambre (id)

alter table Chambre
add constraint fk_refClasse foreign key (refClasse)
references Classe (id)

alter table Classe
add constraint fk_refCategorisation foreign key (refCategorisation)
references Categorisation (id)

--==========================================================================================
--CREATION DES PROCEDURES

--FIRST TABLE

create procedure saveClient
(
	@id int,
	@noms nvarchar (100),
	@adresse nvarchar (100),
	@contact nvarchar (100)
)as
begin
if @id in (select id from Client)
begin
update Client set noms = @noms, adresse = @adresse, contact = @contact where id=@id
end
else
begin
insert into Client(noms, adresse, contact)
values(@noms, @adresse, @contact)
end
end

--SECOND TABLE

create procedure saveReservation
(
	@id int,
	@refClient int,
	@refChabre int ,
	@dateEntree date
)as
begin
if @id in (select id from Reservation)
begin
update Reservation set refClient = @refClient,refChabre = @refChabre,dateEntree = @dateEntree where id = @id
end
else
begin
insert into Reservation (refClient,refChabre,dateEntree)
values (@refClient,@refChabre,@dateEntree)
end
end

--THIRD TABLE

create procedure saveChambre
(
	@id int,
	@numero int,
	@contact nvarchar (100),
	@refClasse int
)as
begin
if @id in (select id from Chambre)
begin
update Chambre set numero = @numero,contact = @contact,refClasse = @refClasse where id = @id
end
else
begin
insert into Chambre (numero,contact,refClasse)
values (@numero,@contact,@refClasse)
end
end

--FOURTH TABLE

create procedure saveCategorisation
(
	@id int,
	@desgnation nvarchar (100)
)as
begin
if @id in (select id from Categorisation)
begin
update Categorisation set desgnation = @desgnation where id = @id
end
else
begin
insert into Categorisation (desgnation)
values (@desgnation)
end
end

--FIFTH TABLE

alter procedure saveClasse
(
	@id int,
	@designation nvarchar (100),
	@refCategorisation int,
	@prix decimal (30,2)
)as
begin
if @id in (select id from Classe)
begin
update Classe set designation = @designation, refCategorisation = @refCategorisation,prix = @prix where id = @id
end
else
begin
insert into Classe(designation,refCategorisation,prix)
values(@designation,@refCategorisation,@prix)
end
end

--=======================================THE END =====================================================================