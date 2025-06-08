# FindMyPet Api DotNet

**FindMyPet Api DotNet** é uma API desenvolvida em .NET para o sistema **de resgate e adoção de animais em desastres**. A plataforma permite mapear animais resgatados, registrar denúncias de animais perdidos, gerenciar processos de adoção (temporária ou definitiva) e integrar sensores de movimento em áreas de risco. A solução é modularizada em camadas e utiliza Entity Framework Core com banco de dados Oracle. Conta também com documentação interativa via Swagger.

---

## 📌 Funcionalidades

- Gerenciamento de **usuários**
- Cadastro e mapeamento de **animais resgatados**
- Registro de **denúncias de animais perdidos**
- Processo de **adoção temporária ou definitiva**
- Monitoramento de áreas de risco com **sensores de movimento**
- API RESTful com respostas em JSON
- Documentação interativa via Swagger
- Integração com Oracle via Entity Framework Core
- Migrações de banco com EF Core

---

# 👩‍💻 Participantes

- Pedro Henrique Mendonça de Novais - RM555276
- Davi Alves de Lima - RM556008
- Rodrigo Alcides Bohac Ríos - RM554826

---

## 🏗 Estrutura do Projeto

- **api**: Camada de apresentação (controllers, Swagger, configurações iniciais)
- **service**: Camada de regras de negócio (serviços e lógica da aplicação)
- **data**: Acesso a dados e contexto do banco (AppDbContext, migrations)
- **library**: Camada de domínio (entidades e modelos do sistema)

---

## 💻 Tecnologias Utilizadas

- .NET 8 / .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- Oracle.EntityFrameworkCore
- Swagger / Swashbuckle
- C#

---

## 🚀 Como Executar o Projeto

Clone o repositório:

```bash
git clone https://github.com/seu-usuario/findmypet-api-dotnet
cd findmypet-api-dotnet
```

Restaure os pacotes:

```bash
dotnet restore
```

Aplique as migrations:

```bash
dotnet ef database update --project ./data --startup-project ./api
```

Execute a aplicação:
```bash
cd api
dotnet run
```

Acesse a documentação Swagger:
```bash
https://localhost:{porta}/swagger
```

## 📬 Endpoints da API

### 🔹 Usuários (`/api/Usuario`)

| Método | Rota                         | Descrição                   |
|--------|------------------------------|-----------------------------|
| GET    | `/api/Usuario`               | Lista todos os usuários     |
| GET    | `/api/Usuario/{id}`          | Retorna um usuário por ID   |
| POST   | `/api/Usuario`               | Cria um novo usuário        |
| PUT    | `/api/Usuario/{id}`          | Atualiza um usuário         |
| DELETE | `/api/Usuario/{id}`          | Remove um usuário           |

---

### 🔹 Animais Resgatados (`/api/AnimalResgatado`)

| Método | Rota                                   | Descrição                             |
|--------|----------------------------------------|---------------------------------------|
| GET    | `/api/AnimalResgatado`                 | Lista todos os animais resgatados     |
| GET    | `/api/AnimalResgatado/{id}`            | Retorna um animal resgatado por ID    |
| POST   | `/api/AnimalResgatado`                 | Registra um novo animal resgatado     |
| PUT    | `/api/AnimalResgatado/{id}`            | Atualiza informações de um animal     |
| DELETE | `/api/AnimalResgatado/{id}`            | Remove um registro de animal          |

---

### 🔹 Denúncias de Animais Perdidos (`/api/Denuncia`)

| Método | Rota                         | Descrição                                 |
|--------|------------------------------|-------------------------------------------|
| GET    | `/api/Denuncia`              | Lista todas as denúncias de animais perdidos |
| GET    | `/api/Denuncia/{id}`         | Retorna uma denúncia por ID               |
| POST   | `/api/Denuncia`              | Registra uma nova denúncia                |
| PUT    | `/api/Denuncia/{id}`         | Atualiza uma denúncia                     |
| DELETE | `/api/Denuncia/{id}`         | Remove uma denúncia                       |

---

### 🔹 Adoções (`/api/Adocao`)

| Método | Rota                         | Descrição                           |
|--------|------------------------------|-------------------------------------|
| GET    | `/api/Adocao`                | Lista todos os processos de adoção  |
| GET    | `/api/Adocao/{id}`           | Retorna um processo de adoção por ID|
| POST   | `/api/Adocao`                | Inicia um novo processo de adoção   |
| PUT    | `/api/Adocao/{id}`           | Atualiza um processo de adoção      |
| DELETE | `/api/Adocao/{id}`           | Remove um processo de adoção        |

---

### 🔹 Sensores de Movimento (`/api/SensorMovimento`)

| Método | Rota                                  | Descrição                              |
|--------|---------------------------------------|----------------------------------------|
| GET    | `/api/SensorMovimento`                | Lista todos os sensores de movimento   |
| GET    | `/api/SensorMovimento/{id}`           | Retorna um sensor por ID               |
| POST   | `/api/SensorMovimento`                | Cadastra um novo sensor de movimento   |
| PUT    | `/api/SensorMovimento/{id}`           | Atualiza um sensor existente           |
| DELETE | `/api/SensorMovimento/{id}`           | Remove um sensor                       |

---

## 📊 Diagrama da Arquitetura

```mermaid
classDiagram
    direction TB

    %% === ENTIDADES DE DOMÍNIO ===
    class Animal {
        +int Id
        +string Nome
        +string Especie
        +string Raca
        +string Sexo
        +int Idade
        +bool Disponivel
        +int PessoaId
        +Pessoa Responsavel
        +List~Adocao~ Adocoes
    }

    class Pessoa {
        +int Id
        +string Nome
        +string Email
        +string Telefone
        +List~Animal~ Animais
        +List~Adocao~ Adocoes
    }

    class Adocao {
        +int Id
        +int AnimalId
        +int PessoaId
        +DateTime DataAdocao
        +Animal Animal
        +Pessoa Pessoa
    }

    class Sensor {
        +int Id
        +string Codigo
        +string Tipo
        +int AnimalId
        +Animal Animal
    }

    class Local {
        +int Id
        +string Descricao
        +double Latitude
        +double Longitude
        +DateTime DataRegistro
        +int SensorId
        +Sensor Sensor
    }

    class Report {
        +int Id
        +string Tipo
        +DateTime DataGeracao
        +string Conteudo
    }

    %% === DB CONTEXT ===
    class AppDbContext {
        +DbSet~Animal~ Animais
        +DbSet~Pessoa~ Pessoas
        +DbSet~Adocao~ Adocoes
        +DbSet~Sensor~ Sensores
        +DbSet~Local~ Locais
        +DbSet~Report~ Relatorios
    }

    %% === INTERFACES DE SERVIÇO ===
    class IAnimalService
    class IPessoaService
    class IAdocaoService
    class ISensorService
    class ILocalService
    class IReportService

    %% === IMPLEMENTAÇÕES DE SERVIÇO ===
    class AnimalService {
        -AppDbContext _context
    }

    class PessoaService {
        -AppDbContext _context
    }

    class AdocaoService {
        -AppDbContext _context
    }

    class SensorService {
        -AppDbContext _context
    }

    class LocalService {
        -AppDbContext _context
    }

    class ReportService {
        -AppDbContext _context
    }

    %% === CONTROLLERS ===
    class AnimalController
    class PessoaController
    class AdocaoController
    class SensorController
    class LocalController
    class ReportController

    %% === RELACIONAMENTOS ENTRE ENTIDADES ===
    Pessoa "1" --> "*" Animal : possui
    Pessoa "1" --> "*" Adocao : realiza
    Animal "1" --> "*" Adocao : é adotado em
    Animal "1" --> "0..1" Sensor : possui
    Sensor "1" --> "*" Local : registra

    %% === DB CONTEXT RELATIONS ===
    AppDbContext --> Animal
    AppDbContext --> Pessoa
    AppDbContext --> Adocao
    AppDbContext --> Sensor
    AppDbContext --> Local
    AppDbContext --> Report

    %% === SERVICES E INTERFACES ===
    AnimalService ..|> IAnimalService
    PessoaService ..|> IPessoaService
    AdocaoService ..|> IAdocaoService
    SensorService ..|> ISensorService
    LocalService ..|> ILocalService
    ReportService ..|> IReportService

    %% === CONTROLLERS PARA SERVIÇOS ===
    AnimalController --> IAnimalService
    PessoaController --> IPessoaService
    AdocaoController --> IAdocaoService
    SensorController --> ISensorService
    LocalController --> ILocalService
    ReportController --> IReportService


```
