--Id do Cliente - idCliente [numérico] 
--Nome - nmCliente [string] 
--Cidade - Nome da Cidade - Cidade[Texto]


create table dbo.clientes
(
	idCliente int primary key NOT NULL,
    nmCliente varchar(30) NOT NULL,
	nmCidade varchar(30) NOT NULL
)