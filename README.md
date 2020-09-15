#Teste#
Este teste busca avaliar quesitos técnicos para as pessoas que se candidatem a vaga de Desenvolvedor .NET Júnior.

Desafio
Seu objetivo é criar um CRUD de Cliente utilizando ASP.NET MVC e persistência de dados utilizando (EF, Dapper).

O que sua aplicação deverá fazer
 * Listar cliente
 * Incluir um cliente (Nome, Email, CPF)
 * Atualizar um cliente
 * Excluir um cliente

O que será avaliado
 * Conhecimento de ASP.NET MVC, SQL Server
 * Persistência de Dados (EF, Dapper)
 * Código Limpo

Diferencial
 * Refatoração 
 * SOLID
 
#Segunda Etapa#

Desafio
Ter um CRUD de Produtos, ao cadastrar o cliente, é preciso selecionar um produto.

O que sua aplicação deverá fazer 
 * Listar produto
 * Incluir um produto (Nome, Ativo)
 * Atualizar um produto
 * Excluir um produto

Regras:
- Não pode existir dois clientes com nomes repetidos
- Um produto pode estar associado a apenas um cliente
- No cadastro de cliente, não pode exibir produtos inativos
- Só é possível inativar ou excluir um produto caso este não esteja associado com nenhum cliente
