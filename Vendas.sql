--Id do Venda- idVenda [num�rico] 
--Cliente: Buscar de uma lista de Clientes - idCliente [num�rico]
--Produto de Interesse: Buscar de uma lista de Produtos - idProduto [num�rico] 
--Quantidade do produto - qtdVenda [num�rico]
--Valor Unit�rio: Valor unit�rio de cada produto - vlrUnitarioVenda [num�rico] 
--Data Venda: dthVenda [datetime]
--Valor da Venda: Calculado automaticamente conforme o valor unit�rio do Produto e a 
--quantidade informada do produto no neg�cio - vlrTotalVenda [float]

create table dbo.vendas
(
	idVenda int primary key not null,
	idCliente int not null,
	idProduto int not null,
	qtdVenda int not null,
	vlrUnitarioVenda float not null,
	dthVenda datetime not null,
	vlrTotalVenda float not null,
)
