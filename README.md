# Sistema de Venda de Veículos

Este projeto é parte da avaliação da disciplina de Backend, com o objetivo de criar um sistema de venda de veículos utilizando C# e .NET.

## Etapa 1: Modelagem do Banco de Dados

Nesta primeira etapa, foi realizada a modelagem e a criação da estrutura inicial do banco de dados utilizando o padrão Code-First do Entity Framework Core.

### Tecnologias Utilizadas
- **Linguagem:** C#
- **Framework:** ASP.NET Core 8.0
- **ORM:** Entity Framework Core 8.0
- **Banco de Dados:** SQL Server Express

### Entidades Modeladas
O banco de dados foi projetado com as seguintes 5 entidades, cumprindo os requisitos da avaliação:

1.  **`Veiculo`**: Armazena informações sobre os veículos, como modelo, ano e quilometragem. Relaciona-se com `Fabricante`.
2.  **`Fabricante`**: Representa a marca do veículo (ex: Fiat, Chevrolet).
3.  **`Cliente`**: Guarda os dados dos clientes, como nome, CPF e e-mail.
4.  **`Aluguel`**: Registra as operações de aluguel, ligando um `Cliente` a um `Veiculo` e controlando datas, valores e quilometragem.
5.  **`Endereco`**: Entidade adicional que armazena o endereço completo do `Cliente`, em uma relação de um-para-um.

### Processo de Criação
O banco de dados `LocadoraVeiculosDB` e as suas respectivas tabelas foram gerados através dos seguintes comandos do EF Core Tools:
```bash
# 1. Cria o arquivo de migração (a "receita" do banco)
dotnet ef migrations add CriacaoInicial

# 2. Aplica a migração, criando o banco de dados físico
dotnet ef database update
