--Id do Produto- idProduto [num�rico] 
--Descri��o - dscProduto [string] 
--Valor Unit�rio - vlrUnitario [float]

create table dbo.produtos
(
	idProduto int primary key NOT NULL,
    dscProduto varchar(30) NOT NULL,
	vlrUnitario float NOT NULL
)
