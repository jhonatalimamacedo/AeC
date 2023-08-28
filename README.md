# AeC

devido ao um bug no sqlserve ele nao esta fazendo a migração do banco de priemira, entao eu dou o comando docker-compose up --build 2x antes de testar, a primeira espero concluir a migração e dou um ctrl + c e devou dou o comando docker-compose up --build nomavemte. Depois disso o banco faz migração 100% e todas as funções funcionam

# Developer Challenge: API de Clima

Este é um desafio de desenvolvimento para criar uma API RESTful que consome dados da [Brasil API](https://brasilapi.com.br/docs) para fornecer informações climáticas de cidades ou aeroportos. O objetivo é criar uma API limpa e organizada, usando as seguintes tecnologias:

- Tecnologias Utilizadas:
  - API RESTful
  - Docker e Orquestração
  - .NET 6
  - SQL Server
  - Dapper

## Tarefas a Realizar

1. Crie pelo menos uma rota para obter o clima de uma cidade.
2. Crie pelo menos uma rota para obter o clima de um aeroporto.
3. Persista os dados no SQL Server a cada requisição.
4. Salve logs no SQL Server em caso de erros de processamento de dados.
5. Documente a API usando o Swagger para facilitar o entendimento.
6. Crie um container Docker para a sua API.
7. **Extra:** Crie testes unitários para validar as funcionalidades acima.

## Detalhes do Desenvolvimento

- Horas gastas na implementação: 15 horas
- Tempo total de estudos: 4 dias

## Tecnologias Requeridas

- .NET 6 ou superior com C#
- Dapper para acesso ao banco de dados
- SQL Server para persistência de dados
- Docker para criação do container
- Testes unitários usando frameworks como xUnit ou NUnit (opcional)

Lembre-se de adotar boas práticas de programação, manter o código limpo e organizado, e documentar adequadamente o seu projeto. Divirta-se codificando!

**AeC - Seu Futuro, Nossa Missão!**
