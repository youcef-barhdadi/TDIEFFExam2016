create database EFF2014

go
use EFF2014
go


create table Categorie
(
	idCategorie int primary key ,
	nomCategorie nvarchar(50)

)

create table Organisatuer
(
	idOrg INT primary key,
	nomOrg nvarchar(50),
	prenomOrg nvarchar(50),
	emailOrg nvarchar(50),
	passOrg nvarchar(50)
	
)

update Organisatuer set nomOrg = '' , prenomOrg = '',emailOrg = '' , passOrg = '' where  idOrg ='' 


delete 
from Organisatuer


create table Campagne 
(
	idCamp int primary key,
	nomCamp nvarchar (50),
	[description]  nvarchar(50),
	dateCretion date,
	dateFin date,
	montantCamp money,
	nomBeneficiare nvarchar(50),
	prenBenficiare nvarchar(50),
	dateDernierePart date ,
	idCategorie int foreign key references Categorie(idCategorie)  


)

select C. nomCamp , C.dateCretion , C.montantCamp , (select count(*) from Participant where idP = P.idP ) as 'ss' from Campagne  C
left join Participation  P
on  C.idCamp =P.idCamp 
where (SELECT SUM(montant) from  Participation where idPart = P.idPart)  > = C.montantCamp and YEAR(C.dateCretion) = 2015 


where  idCamp = ''
create table Participant 
(
	idP int primary key,
	nomP nvarchar(50),
	prenom nvarchar(50),
	email nvarchar(50),
	passP nvarchar(50)

)

create  table Participation 
(
	idPart int primary key identity,
	[datePart]  date ,
	montant money ,
	idCamp int foreign key references Campagne(idCamp) ,
	idP int foreign key references Participant(idP)


)
--1--
select C.nomCamp , count(A.idP)
from Participant A
join Participation B 
on  A.idP = B.idP
join Campagne C
on C.idCamp = B.idCamp
group by C.nomCamp
---2---

create proc Q3
			@idCamp int 
as
begin
	
	select A.montant,B.nomP
	from Participation A
	join Participant B
	on A.idP = B.idP
	where A.idCamp = @idCamp
end




create trigger Q4
on Participation
after insert 
as
begin

	declare @idC int

	select @idC = idCamp
	from inserted

	update Campagne
	set dateDernierePart = GETDATE()
	where idCamp = @idC



end



create proc Q5 
			@montPart money ,
			@idCamp int ,
			@idP int 
as
begin



	insert into Participation 
	values (GETDATE(),@montPart,@idCamp,@idP)



end
create function Q6 (@idCmp int)
returns  money
as
begin


	declare @total money
	select  @total = SUM(P.montant)
	from Participation P
	join Campagne C
	on C.idCamp = P.idCamp
	where C.idCategorie = @idCmp

	return @total

end