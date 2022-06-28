--Id do Produto- idProduto [numérico] 
--Descrição - dscProduto [string] 
--Valor Unitário - vlrUnitario [float]

create table dbo.produtos
(
	idProduto int primary key NOT NULL,
    dscProduto varchar(30) NOT NULL,
	vlrUnitario float NOT NULL
)
