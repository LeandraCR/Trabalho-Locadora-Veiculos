# API de Gerenciamento de Veículos

Este projeto é uma aplicação backend desenvolvida para o gerenciamento de veículos, permitindo o cadastro, consulta, atualização e exclusão de informações relacionadas a automóveis. O sistema foi estruturado com foco em boas práticas de desenvolvimento e documentação, garantindo organização e facilidade de uso.

## 🚗 Funcionalidades Principais

- **Cadastro de veículos:** permite registrar novos veículos com informações detalhadas.  
- **Listagem de veículos:** exibe todos os veículos cadastrados.  
- **Consulta individual:** busca um veículo específico pelo ID.  
- **Atualização de dados:** possibilita alterar informações de um veículo existente.  
- **Remoção de veículos:** exclui um veículo do sistema.

## 🧩 Estrutura do Projeto

O sistema segue uma arquitetura organizada em camadas, dividindo responsabilidades de forma clara entre:
- **Model:** definição das entidades e estrutura dos dados.  
- **Controller:** controle das requisições e respostas HTTP.  
- **Service:** camada de regras de negócio.  
- **Repository:** interface de comunicação com o banco de dados.

## 📄 Documentação da API (Swagger)

A aplicação conta com **integração do Swagger**, que fornece uma interface interativa para explorar e testar as rotas da API.  
O Swagger permite visualizar os endpoints disponíveis, parâmetros esperados e respostas retornadas, facilitando a compreensão e o uso da aplicação.

Para acessar a documentação, execute o projeto e acesse no navegador:  
```
http://localhost:8080/swagger-ui/index.html
```

## 🧪 Testes e Evidências

Foram realizados testes para verificar o correto funcionamento das rotas e validações do sistema.  
Esses testes garantem que as principais operações — como criação, leitura, atualização e exclusão de veículos — estejam executando de forma estável e conforme esperado.

As evidências de testes estão documentadas e podem ser utilizadas para validação da API e conferência de resultados esperados.

## ⚙️ Tecnologias Utilizadas

- Java / Spring Boot  
- Swagger (para documentação da API)  
- JPA / Hibernate  
- H2 Database (ambiente de testes)  
- Maven

## 🚀 Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone <url-do-repositorio>
   ```

2. Acesse o diretório do projeto:
   ```bash
   cd api-veiculos
   ```

3. Execute o projeto:
   ```bash
   mvn spring-boot:run
   ```

4. Acesse a documentação interativa no navegador:
   ```bash
   http://localhost:8080/swagger-ui/index.html
   ```

---

Desenvolvido por **Leandra Costa Ramos** 💜
