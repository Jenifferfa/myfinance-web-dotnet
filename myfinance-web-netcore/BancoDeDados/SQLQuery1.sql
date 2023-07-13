create database myfinance
go 

use myfinance
go

create table planoconta(
	id int identity (1,1) not null,
	descricao varchar(50) not null,
	tipo char(1) not null,
	primary key(id)
)
go

drop table planoconta

insert into planoconta(descricao, tipo) values('Combustivel', 'D')
insert into planoconta(descricao, tipo) values('salario', 'R')
insert into planoconta(descricao, tipo) values('alimentacao', 'D')

insert into planoconta(descricao, tipo) values('Imposto', 'D')
insert into planoconta(descricao, tipo) values('Agua', 'D')
insert into planoconta(descricao, tipo) values('Luz', 'D')
insert into planoconta(descricao, tipo) values('Internet', 'D')
insert into planoconta(descricao, tipo) values('Cartão de credito', 'D')
insert into planoconta(descricao, tipo) values('Gastos com o Carro', 'D')
insert into planoconta(descricao, tipo) values('Peças do Carro', 'D')

select * from planoconta

create table transacao(
	id int identity(1,1) not null,
	data datetime not null,
	valor decimal(9,2) not null,
	historico varchar(100) null,
	planoconta_id int not null,
	primary key(id),
	foreign key(planoconta_id) references planoconta(id)
)
go

drop table transacao

insert into transacao(data, valor, historico, planoconta_id) values (getdate(), 25, 'Café da amanhã', 3)
insert into transacao(data, valor, historico, planoconta_id) values (getdate(), 38, 'Gasolina moto', 1)
insert into transacao(data, valor, historico, planoconta_id) values ('20230613', 1000, 'Salário empresa 1', 2)

insert into transacao(data, valor, historico, planoconta_id) values ('20230613', 350, 'Imposto', 4)
insert into transacao(data, valor, historico, planoconta_id) values ('20230620 20:43:38.890', 150, 'Sabesp', 6)
insert into transacao(data, valor, historico, planoconta_id) values ('20230613', 250, 'CPFL', 5)
insert into transacao(data, valor, historico, planoconta_id) values ('20230613', 200, 'internet', 7)
insert into transacao(data, valor, historico, planoconta_id) values ('20230613', 200, 'cartão de credito', 8)
insert into transacao(data, valor, historico, planoconta_id) values ('20230613', 500, 'Carro Gasolina', 9)
insert into transacao(data, valor, historico, planoconta_id) values ('20230613', 500, 'Carro velas', 10)

select * from transacao

select * from transacao where planoconta_id =8

--Quantas transacoes já foram realizadas
select count(*) as qtde from transacao

--Transãções já realizadas do dia 20 de junho de 2023
select * from transacao  where data = '20230620 20:43:38.890' and data <= '20230620 23:43:38.890'

select sum(valor) as total from transacao where  historico like '%Carro%'

--Total de gastos com carro
select convert(Dec(10,2), avg(valor)) as totalGastos from transacao where historico like '%Carro%' and year(data) = year(getdate())
select round(avg(valor),2) as totalGastos from transacao where historico like '%Carro%' and year(data) = year(getdate())

select max(valor) as transacao_mais_cara from transacao
select max(valor) as transacao_mais_cara from transacao group by historico
select min(valor) as transacao_mais_cara from transacao

select historico from transacao where valor =(select max(valor) as transacao_mais_cara from transacao)

--Total de receitas e despesas
select sum(valor) as total from transacao where planoconta_id = 8

select(
select sum(valor) as total from transacao join planoconta on transacao.planoconta_id  = planoconta.id where tipo = 'R') as total_receitas,
(select sum(valor) as total from transacao join planoconta on transacao.planoconta_id  = planoconta.id where tipo ='D') as total_despesas 

select id, descricao, tipo, 'abcdef' as coluna1 from planoconta 
select id, valor, (valor-0.10) as valor_desconto from transacao 

select 
	p.descricao as item,
	sum(t.valor) as total
from
	transacao t inner join  planoconta p on t.planoconta_id = p.id
group by 
	p.descricao
having 
	sum(t.valor) > 400
order by sum(t.valor) asc 

select
	t.id,
	t.historico,
	p.tipo,
	t.valor,
	t.data
from
	transacao t inner join planoconta p on t.planoconta_id = p.id
where 
	p.tipo = 'D'
order by 
	valor asc

-----------------------------------------------------------------
select
	t.id,
	t.historico,
	p.tipo,
	t.valor,
	t.data
from
	transacao t inner join planoconta p on t.planoconta_id = p.id
where 
	p.tipo = 'D'
order by 
	valor desc

update transacao set valor=475, data = '20230620 23:43:38.890' where id = 13

delete from transacao where id=16

