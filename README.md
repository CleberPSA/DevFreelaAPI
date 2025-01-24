# DevFreela

O **DevFreela** é uma API que conecta desenvolvedores com clientes para desenvolver projetos de programação, como sites, APIs, entre outros. Este projeto visa facilitar a comunicação e a execução de tarefas entre desenvolvedores e clientes, fornecendo uma plataforma para gerenciar projetos e suas etapas de desenvolvimento.

## Índice

- [Descrição](#descrição)
- [Funcionalidades](#funcionalidades)
- [Próximos Passos](#próximos-passos)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Instalação](#instalação)

## Descrição

O **DevFreela** é uma API construída para conectar desenvolvedores com clientes que buscam realizar projetos de programação. A API oferece uma interface simples para gerenciar tarefas, propostas e projetos, facilitando a colaboração entre desenvolvedores e clientes.

## Funcionalidades

- **Fundamentos da API**: Estrutura básica de uma API RESTful para gerenciar projetos de programação.
- **Controllers e Actions**: Implementação de controllers e actions para gerenciar as operações de criação, leitura, atualização e exclusão (CRUD).
- **Criação dos Endpoints CRUD**: Desenvolvimento de endpoints para CRUD de usuários, projetos, propostas e tarefas.
- **Injeção de Dependência**: Aplicação do padrão de Injeção de Dependência para uma arquitetura limpa e testável.
- **Integração com Banco de Dados**: Implementação da persistência de dados utilizando um banco de dados relacional.
- **Entity Framework**: Integração com o Entity Framework para mapeamento objeto-relacional (ORM) e operações no banco de dados.
- **Migrations**: Implementação de migrations para o controle da evolução do esquema do banco de dados.
- **Paginação**: Adição de suporte à paginação para melhorar o desempenho em grandes listas de projetos, usuários, propostas e tarefas.

## Próximos Passos

- **Arquitetura Limpa**: Estrutura de código mais organizada, escalável e mantível.


## Tecnologias Utilizadas

- **.NET Core** (para desenvolvimento da API)
- **ASP.NET Core** (para construção de endpoints RESTful)
- **Entity Framework** (um framework de acesso a dados)

## Instalação

### Pré-requisitos

- **.NET Core SDK** (recomendado a versão 6.0 ou superior)
- **Visual Studio** ou **VS Code** (para desenvolvimento)
- **SQL Server** ou outro banco de dados (para persistência dos dados, quando integrado)

### Instalando

1. Clone o repositório:
    ```bash
    git clone https://github.com/usuario/devfreela.git
    ```

2. Acesse a pasta do projeto:
    ```bash
    cd devfreela
    ```

3. Restaure as dependências do projeto:
    ```bash
    dotnet restore
    ```

4. Execute a aplicação:
    ```bash
    dotnet run
    ```

A API estará disponível em `http://localhost:5297` por padrão.





