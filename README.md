# vitalis-api

````markdown
# 🌱 Vitalis API — Back-end da Plataforma de Bem-Estar

Este é o repositório da API back-end para a plataforma Vitalis. Desenvolvida em C# com .NET, esta API é responsável por toda a lógica de negócio, gerenciamento de dados e autenticação, servindo o front-end desenvolvido em Angular. O deploy da aplicação é feito na plataforma [Railway](https://railway.app/).

---

### 🚀 Tecnologias e Plataformas

* **.NET 8**: Framework principal para desenvolvimento da aplicação.
* **ASP.NET Core**: Para a construção da API RESTful.
* **Entity Framework Core (EF Core)**: ORM para interação com o banco de dados.
* **MySQL**: Banco de dados relacional.
* **JWT (JSON Web Tokens)**: Para autenticação e autorização de rotas.
* **Docker**: Para conteinerização do ambiente de desenvolvimento.
* **Railway.app**: Plataforma de hospedagem e deploy contínuo.

---

### 📂 Endpoints Principais da API

A API fornece as seguintes funcionalidades para o front-end:

* **Autenticação de Usuários**
    * `POST /api/users/register`: Cadastro de novos usuários.
    * `POST /api/sessions/login`: Login e geração de token de acesso.

* **Estação Vital (Planta Emocional)**
    * `POST /api/moods`: Registro de um novo humor diário.
    * `GET /api/moods/history`: Histórico de humor do usuário logado.

* **Aprender+ (Conteúdo Psicoeducativo)**
    * `GET /api/content`: Listagem de todos os vídeos, artigos e eventos.
    * `GET /api/content/{id}`: Detalhes de um conteúdo específico.

* **Cuidar+ (Agendamentos)**
    * `GET /api/psychologists`: Listagem de psicólogos parceiros.
    * `POST /api/appointments`: Agendamento de uma nova consulta.
    * `GET /api/appointments/me`: Listagem das consultas do usuário logado.

---

### 📦 Desenvolvimento Local

Siga os passos abaixo para executar a API em um ambiente de desenvolvimento local.

#### 🔧 Pré-requisitos
* **[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)**
* **[Docker](https://www.docker.com/)** (para rodar o MySQL localmente)
* Um editor de código como **[Visual Studio 2022](https://visualstudio.microsoft.com/)** ou **[VS Code](https://code.visualstudio.com/)** com a extensão C# Dev Kit.

#### 1. Clone o repositório
```bash
git clone [https://github.com/seu-usuario/vitalis-api.git](https://github.com/seu-usuario/vitalis-api.git)
cd vitalis-api
````

#### 2\. Configure a conexão com o banco de dados local

Abra o arquivo `appsettings.Development.json`. Configure a sua `ConnectionString` para o banco de dados MySQL que rodará localmente.

**Exemplo:**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=vitalis_db;Uid=root;Pwd=sua_senha_segura;"
  }
}
```

*Observação: Esta configuração é **apenas** para o ambiente de desenvolvimento. No Railway, as variáveis de ambiente serão usadas.*

#### 3\. Inicie o banco de dados local com Docker

```bash
docker run --name mysql-vitalis -e MYSQL_ROOT_PASSWORD=sua_senha_segura -e MYSQL_DATABASE=vitalis_db -p 3306:3306 -d mysql:latest
```

#### 4\. Aplique as Migrations do Entity Framework Core

```bash
# Restaura as dependências do projeto
dotnet restore

# Instala a ferramenta de linha de comando do EF Core (se ainda não tiver)
dotnet tool install --global dotnet-ef

# Aplica as migrations no banco de dados local
dotnet ef database update
```

#### 5\. Inicie o servidor de desenvolvimento

```bash
dotnet watch run
```

A API será iniciada em URLs como `https://localhost:7123` e `http://localhost:5123`.

-----

### 🚀 Implantação no Railway

Este projeto está configurado para deploy contínuo (CI/CD) na plataforma Railway.

1.  **Conecte o Repositório**: No seu painel do Railway, crie um novo projeto e conecte este repositório do GitHub.
2.  **Adicione o Banco de Dados**: No mesmo projeto, adicione um serviço de banco de dados "MySQL".
3.  **Configure as Variáveis de Ambiente**:
      * Vá até o serviço da sua API .NET no Railway e abra a aba "Variables".
      * O Railway já expõe as variáveis de conexão do banco. Você precisa criar uma variável chamada `ConnectionStrings__DefaultConnection`.
      * No valor dela, coloque a variável que o Railway oferece, geralmente algo como `${{MySQL.CONNECTION_STRING}}`. O .NET irá mapear isso automaticamente para a sua `ConnectionString`.
4.  **Deploy e Migrations**:
      * A cada `git push` na branch principal, o Railway fará o build e o deploy automaticamente.
      * **Importante**: Para aplicar as migrations no banco de dados de produção, você pode configurar um "Deploy Command" nas configurações do serviço no Railway: `dotnet ef database update`.

-----

### 💡 Observações

  * Este projeto faz parte de um Trabalho de Conclusão de Curso (TCC).

-----

Feito com ❤️ pela equipe Vitalis

````

---

### English Version (for .NET/C# API with MySQL and Railway)

```markdown
# 🌱 Vitalis API — Well-being Platform Back-end

This is the back-end API repository for the Vitalis platform. Built with C# and .NET, this API handles all business logic, data management, and authentication, serving the front-end application built with Angular. The application is deployed on the [Railway](https://railway.app/) platform.

---

### 🚀 Technologies & Platforms

* **.NET 8**: Core framework for application development.
* **ASP.NET Core**: For building the RESTful API.
* **Entity Framework Core (EF Core)**: ORM for database interaction.
* **MySQL**: Relational database.
* **JWT (JSON Web Tokens)**: For route authentication and authorization.
* **Docker**: For containerizing the development environment.
* **Railway.app**: Continuous deployment and hosting platform.

---

### 📂 Core API Endpoints

The API provides the following features for the front-end client:

* **User Authentication**
    * `POST /api/users/register`: Register a new user.
    * `POST /api/sessions/login`: Log in and generate an access token.

* **Vital Station (Emotional Plant)**
    * `POST /api/moods`: Log a new daily mood entry.
    * `GET /api/moods/history`: Get the logged-in user's mood history.

* **Learn+ (Psychoeducational Content)**
    * `GET /api/content`: List all available videos, articles, and events.
    * `GET /api/content/{id}`: Get details for a specific piece of content.

* **Care+ (Session Booking)**
    * `GET /api/psychologists`: List all partner psychologists.
    * `POST /api/appointments`: Book a new session.
    * `GET /api/appointments/me`: List all appointments for the logged-in user.

---

### 📦 Local Development

Follow the steps below to run the API in a local development environment.

#### 🔧 Prerequisites
* **[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)**
* **[Docker](https://www.docker.com/)** (to run MySQL locally)
* A code editor like **[Visual Studio 2022](https://visualstudio.microsoft.com/)** or **[VS Code](https://code.visualstudio.com/)** with the C# Dev Kit extension.

#### 1. Clone the repository
```bash
git clone [https://github.com/your-user/vitalis-api.git](https://github.com/your-user/vitalis-api.git)
cd vitalis-api
````

#### 2\. Configure the local database connection

Open the `appsettings.Development.json` file. Set up your `ConnectionString` for the MySQL database that will run locally.

**Example:**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=vitalis_db;Uid=root;Pwd=your_secure_password;"
  }
}
```

*Note: This configuration is **only** for the development environment. On Railway, environment variables will be used.*

#### 3\. Start the local database with Docker

```bash
docker run --name mysql-vitalis -e MYSQL_ROOT_PASSWORD=your_secure_password -e MYSQL_DATABASE=vitalis_db -p 3306:3306 -d mysql:latest
```

#### 4\. Apply Entity Framework Core Migrations

```bash
# Restore project dependencies
dotnet restore

# Install the EF Core command-line tool (if you don't have it yet)
dotnet tool install --global dotnet-ef

# Apply migrations to the local database
dotnet ef database update
```

#### 5\. Start the development server

```bash
dotnet watch run
```

The API will start on URLs like `https://localhost:7123` and `http://localhost:5123`.

-----

### 🚀 Deployment to Railway

This project is configured for continuous deployment (CI/CD) on the Railway platform.

1.  **Connect the Repository**: In your Railway dashboard, create a new project and connect this GitHub repository.
2.  **Add the Database**: In the same project, add a "MySQL" database service.
3.  **Configure Environment Variables**:
      * Navigate to your .NET API service on Railway and open the "Variables" tab.
      * Railway already exposes the database connection variables. You need to create a new variable named `ConnectionStrings__DefaultConnection`.
      * For its value, use the variable that Railway provides, which is typically something like `${{MySQL.CONNECTION_STRING}}`. .NET will automatically map this to your `ConnectionString`.
4.  **Deploy and Migrations**:
      * On every `git push` to the main branch, Railway will automatically build and deploy your application.
      * **Important**: To apply migrations to the production database, you can set a "Deploy Command" in your service's settings on Railway: `dotnet ef database update`.

-----

### 💡 Notes

  * This project was developed as part of a final graduation project (TCC).

-----

Made with ❤️ by the Vitalis team

```
```
