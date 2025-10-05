# 🚗 Sistema de Venda de Veículos

O **Sistema de Venda de Veículos** é uma aplicação desenvolvida em **C#** com **ASP.NET Core** e **Entity Framework Core**, com o objetivo de gerenciar o cadastro, a venda e o aluguel de veículos.  
A aplicação oferece funcionalidades completas de CRUD, integração com banco de dados SQL Server e endpoints RESTful organizados e seguros.

---

## 🧩 Visão Geral

O sistema permite gerenciar veículos, fabricantes, clientes e endereços, além de registrar operações de aluguel, mantendo um controle eficiente sobre as informações e seus relacionamentos.

Ele foi desenvolvido seguindo o padrão **Model-View-Controller (MVC)** e utiliza o **Entity Framework Core** com o padrão **Code-First** para geração automática do banco de dados.

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C#  
- **Framework:** ASP.NET Core 8.0  
- **ORM:** Entity Framework Core 8.0  
- **Banco de Dados:** SQL Server Express  
- **Ferramentas:** Swagger / Postman para testes de API  

---

## 🗃️ Estrutura do Banco de Dados

O sistema possui cinco entidades principais:

1. **`Veiculo`** — Contém informações sobre o veículo (modelo, ano, quilometragem, status, valor, etc.).  
2. **`Fabricante`** — Representa a marca do veículo (exemplo: Fiat, Chevrolet, Volkswagen).  
3. **`Cliente`** — Armazena dados dos clientes, como nome, CPF, e-mail e telefone.  
4. **`Aluguel`** — Controla as operações de aluguel, relacionando um cliente a um veículo e registrando datas e valores.  
5. **`Endereco`** — Relaciona-se com o cliente em uma relação 1:1, armazenando informações completas de endereço.

O banco é gerado automaticamente via migrações do **Entity Framework**.

### ⚙️ Comandos de Geração do Banco

```bash
# Criar a migração
dotnet ef migrations add CriacaoInicial

# Atualizar o banco de dados
dotnet ef database update
```

---

## 🚀 Funcionalidades Principais

### 🔹 Endpoints CRUD
A API disponibiliza operações de **criação, leitura, atualização e exclusão** para todas as entidades:
- `/api/veiculos`
- `/api/fabricantes`
- `/api/clientes`
- `/api/alugueis`
- `/api/enderecos`

### 🔹 Validação de Dados e Tratamento de Erros
- Validação de CPF único e formato correto  
- Campos obrigatórios e limites de tamanho  
- Tratamento de exceções com mensagens padronizadas em JSON  
- Retornos claros em casos de erro (400, 404, 500)

### 🔹 Consultas e Filtros Avançados
O sistema permite filtros dinâmicos com **joins** entre entidades, possibilitando:
- Buscar veículos por fabricante, ano ou disponibilidade  
- Consultar clientes de determinada cidade  
- Listar veículos alugados com informações do cliente e fabricante  
- Verificar aluguéis ativos e históricos  

---

## 🧪 Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/sistema-veiculos.git
   ```
2. Acesse o diretório do projeto:
   ```bash
   cd sistema-veiculos
   ```
3. Restaure as dependências:
   ```bash
   dotnet restore
   ```
4. Atualize o banco de dados:
   ```bash
   dotnet ef database update
   ```
5. Execute a aplicação:
   ```bash
   dotnet run
   ```
6. Acesse a documentação interativa via Swagger:  
   [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 💡 Possíveis Melhorias Futuras

- Implementação de autenticação e controle de acesso (JWT)  
- Integração com gateway de pagamento para vendas online  
- Dashboard administrativo com gráficos de desempenho  
- Implementação de testes automatizados  

---

## 👩‍💻 Desenvolvedora

**Leandra Costa Ramos**  
Engenharia de Software — Backend Developer  
💼 Desenvolvimento de soluções em .NET, APIs RESTful e banco de dados relacionais.
