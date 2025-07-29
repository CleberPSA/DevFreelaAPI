# 💼 DevFreela

O **DevFreela** é uma API RESTful desenvolvida em .NET para conectar desenvolvedores com clientes interessados em contratar projetos de software, como sites, sistemas e APIs. O objetivo é oferecer uma estrutura para gerenciamento de usuários, propostas e projetos, simulando uma plataforma freelance.

---

## 🧩 Problema

Simular um sistema de intermediação entre clientes e desenvolvedores, com funcionalidades como cadastro de usuários, criação de projetos, envio de propostas e controle de status.

---

## 💡 Solução

Desenvolvimento de uma API escalável, com padrões modernos do .NET, aplicação de conceitos como injeção de dependência, migrations, paginação e separação clara de responsabilidades com uso do Entity Framework Core.

---

## ✨ Funcionalidades

- CRUD de **usuários**, **projetos**, **propostas** e **tarefas**
- Injeção de dependência com serviços desacoplados
- Controle de persistência com **Entity Framework**
- Aplicação de **migrations** para versionamento do banco de dados
- Suporte à **paginação** em endpoints de listagem
- Validações básicas e tratamento de erros

---

## 🛠️ Tecnologias Utilizadas

- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server

---

## ⚙️ Decisões Técnicas

- Optei por uma arquitetura simples com **Controllers + Services**, separando lógica de negócio da exposição da API.
- Utilizei **EF Core** pela integração natural com .NET e facilidade nas migrations.
- Organização por pastas: `Controllers`, `Services`, `Repositories`, `Models`, `ViewModels`.

---

## ⚖️ Trade-offs

- O projeto ainda não implementa autenticação/autorização (como JWT).
- Não há testes automatizados neste momento.
- A API está sem documentação Swagger configurada (previsto para próximos passos).

---

## 🚀 Como Executar

### Pré-requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- SQL Server (local ou Docker)
- Visual Studio ou VS Code

### Passo a passo

```bash
# Clone o projeto
git clone https://github.com/usuario/devfreela.git
cd devfreela

# Restaure as dependências
dotnet restore

# Execute as migrations (opcional, se usar banco real)
dotnet ef database update

# Execute a aplicação
dotnet run
