create database TesteMVC
go
use TesteMVC
go

create table Categoria
(
idCategoria int identity primary key,
Descricao varchar(50)
)

insert into Categoria(Descricao) values ('Alimento'), ('Eletrônico')

select *from Categoria






