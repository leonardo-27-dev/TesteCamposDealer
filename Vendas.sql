--Id do Venda- idVenda [numérico] 
--Cliente: Buscar de uma lista de Clientes - idCliente [numérico]
--Produto de Interesse: Buscar de uma lista de Produtos - idProduto [numérico] 
--Quantidade do produto - qtdVenda [numérico]
--Valor Unitário: Valor unitário de cada produto - vlrUnitarioVenda [numérico] 
--Data Venda: dthVenda [datetime]
--Valor da Venda: Calculado automaticamente conforme o valor unitário do Produto e a 
--quantidade informada do produto no negócio - vlrTotalVenda [float]

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
