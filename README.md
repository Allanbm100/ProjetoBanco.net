# 💰 ProjetoBanco.Net - API de Contas

## 🎯 Objetivo

Este projeto tem como objetivo criar uma solução modular baseada em boas práticas de desenvolvimento e arquitetura em camadas. A aplicação consiste em uma API RESTful desenvolvida em .NET e utiliza Entity Framework Core para integração com um banco de dados Oracle.

---

## 🧱 Estrutura do Projeto

A solução está organizada em 4 projetos distintos:

- **ContasApi** – Responsável pela exposição dos endpoints REST (Web API).
- **ContasLib** – Contém os modelos e entidades da aplicação.
- **ContasBusiness** – Implementa as regras de negócio da aplicação.
- **ContasData** – Responsável pela persistência dos dados com Entity Framework Core + Oracle.

---

## 🛠️ Tecnologias Utilizadas

- .NET 9
- Entity Framework Core
- Oracle Database
- OpenAPI (Swagger)
- RESTful API

---

## 🚀 Como Executar o Projeto

### 🔧 Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Acesso ao Oracle Database FIAP:
  - **Host:** `oracle.fiap.com.br`
  - **Porta:** `1521`
  - **SID:** `ORCL`
  - **Usuário:** `RM<seu_rm>`
  - **Senha:** sua data de nascimento (ex: `030804`)
- Ferramenta para teste de API (Swagger, Postman, Insomnia etc.)

---

### 🏁 Passos

```bash
# Clone o repositório
git clone https://seu-repositorio.git

# Acesse a pasta raiz da solução
cd ProjetoBanco.net

# Restaure os pacotes NuGet
dotnet restore

# Coloque as informações de conexão na string de conexão
Em appsettings.json

# Aplique as migrations no banco Oracle
dotnet ef database update --project ContasData --startup-project ContasApi

# Execute a aplicação
dotnet run --project ContasApi
