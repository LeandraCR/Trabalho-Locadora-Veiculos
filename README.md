# Sistema de Venda de Veículos - Projeto de Backend

Este projeto é parte da avaliação da disciplina de Backend, com o objetivo de desenvolver um sistema completo de venda de veículos, desde a modelagem do banco de dados até a criação de uma API RESTful funcional.

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: ASP.NET Core 8.0
- **ORM**: Entity Framework Core 8.0
- **Banco de Dados**: SQL Server Express
- **Documentação**: Swagger (OpenAPI)

## Etapa 1: Modelagem do Banco de Dados

Nesta primeira etapa, foi realizada a modelagem e a criação da estrutura inicial do banco de dados utilizando o padrão **Code-First** do Entity Framework Core.

### Entidades Modeladas

O banco de dados foi projetado com 5 entidades inter-relacionadas:

- **Fabricante**: A marca do veículo.
- **Veiculo**: O veículo, que pertence a um Fabricante.
- **Cliente**: O cliente que pode alugar um veículo.
- **Endereco**: Entidade adicional para guardar o endereço de um Cliente.
- **Aluguel**: Tabela que relaciona um Cliente e um Veiculo, registrando a operação de aluguel.

### Processo de Criação

O banco de dados **LocadoraVeiculosDB** e suas tabelas foram gerados através dos seguintes comandos do Entity Framework Core:

```bash
# 1. Cria o arquivo de migração (a "receita" do banco)
dotnet ef migrations add CriacaoInicial

# 2. Aplica a migração, criando o banco de dados físico
dotnet ef database update
```

## Etapa 2: Implementação do Backend (API)

Nesta segunda etapa, foi desenvolvida uma **API RESTful** com endpoints CRUD para todas as 5 entidades do sistema, utilizando o padrão de **Controllers** do ASP.NET Core.

### Endpoints CRUD

Foram criados **Controllers** para cada entidade, expondo os métodos HTTP padrão para manipulação de dados:

- `GET /api/{entidade}`: Lista todos os registros.
- `GET /api/{entidade}/{id}`: Busca um registro por ID.
- `POST /api/{entidade}`: Cria um novo registro.
- `PUT /api/{entidade}/{id}`: Atualiza um registro existente.
- `DELETE /api/{entidade}/{id}`: Remove um registro.

### Filtros Especiais com Joins

Para cumprir os requisitos, foram implementados 5 endpoints de filtro que utilizam **JOINs** (através do método `Include()` do Entity Framework Core):

- `GET /api/Veiculos/por-fabricante/{nomeFabricante}`: Retorna todos os veículos de um determinado fabricante.
- `GET /api/Veiculos/por-quilometragem/{kmMax}`: Retorna veículos com quilometragem abaixo de um valor especificado.
- `GET /api/Clientes/por-cpf/{cpf}`: Busca um cliente específico pelo seu CPF, incluindo o seu endereço.
- `GET /api/Alugueis/ativos`: Lista todos os aluguéis que ainda não tiveram o veículo devolvido.
- `GET /api/Alugueis/por-cliente/{clienteId}`: Retorna o histórico de aluguéis de um cliente específico.

## Etapa 3: Testes e Documentação

Esta etapa focou em garantir a qualidade, a funcionalidade e a clareza da API desenvolvida.

### 1. Integração do Swagger

O **Swagger** foi integrado nativamente ao projeto para fornecer uma interface de usuário interativa, permitindo a visualização e o teste de todos os endpoints diretamente pelo navegador.

### 2. Documentação das APIs

Para enriquecer a documentação gerada pelo Swagger, foram adicionados **comentários XML** (`///`) a todos os endpoints nos Controllers. Estes comentários fornecem:

- Resumos sobre a funcionalidade de cada rota.
- Parâmetros esperados.
- Possíveis códigos de resposta (ex.: 200, 201, 404).

Isso cumpre os requisitos de documentação do projeto.

### 3. Realização de Testes com Evidências

Todos os endpoints CRUD e os filtros especiais foram testados utilizando a interface do **Swagger** para simular requisições reais à API. As capturas de tela de cada teste bem-sucedido (com respostas como **200 OK**, **201 Created**, etc.) foram salvas e estão disponíveis na pasta:

```
evidencias-testes/
```
