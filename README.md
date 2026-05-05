# APICatalogo

Este projeto é uma Web API desenvolvida com **ASP.NET Core** para o gerenciamento de um catálogo de produtos e categorias. O objetivo principal é consolidar conhecimentos em desenvolvimento de APIs RESTful, persistência de dados e arquitetura de software utilizando o ecossistema .NET.

---

## 🛠️ Tecnologias e Ferramentas

* **Framework:** .NET 9 (C#)
* **API:** ASP.NET Core Web API
* **ORM:** Entity Framework Core (EF Core)
* **Banco de Dados:** MySql
* **Documentação:** Scalar

---

## 📖 Funcionalidades e Conceitos Aplicados

O projeto abrange o ciclo completo de desenvolvimento de uma API, focando nos seguintes pilares:

### 1. Modelagem e Validação
- **Entidades:** Implementação das classes `Produto` e `Categoria` com relacionamentos.
- **Data Annotations:** Uso de atributos como `[Required]`, `[StringLength]` e `[Column(TypeName="decimal(10,2)")]` para garantir a integridade dos dados no banco e na API.

### 2. Persistência de Dados
- **AppDbContext:** Configuração do contexto do Entity Framework para mapeamento objeto-relacional (ORM).
- **Migrations:** Controle de versão do esquema do banco de dados, facilitando a evolução da estrutura da aplicação.
- **Data Seeding:** Scripting para população inicial automática de tabelas de categorias e produtos.

### 3. Endpoints RESTful
- Implementação de **Controllers** para operações completas de CRUD:
  - `GET`: Recuperação de listas e itens por ID.
  - `POST`: Criação de novos registros.
  - `PUT`: Atualização de dados existentes.
  - `DELETE`: Remoção lógica ou física de registros.

---

## 🏗️ Estrutura do Projeto

A organização segue os padrões de separação de responsabilidades:

- `/Models`: Classes que definem a estrutura de dados.
- `/Context`: Configuração do banco de dados e contexto do EF Core.
- `/Controllers`: Lógica de rotas e processamento de requisições.
- `/Migrations`: Histórico de evolução do banco de dados.

---

## 🚀 Como Executar

1. **Clone o repositório:**
   `git clone https://github.com/seu-usuario/APICatalogo.git`

2. **Execute o banco com Docker:**
   Rode o comando: `docker-compose up`

3. **Atualize o Banco de Dados:**
   Execute: `dotnet ef database update`

4. **Inicie a Aplicação:**
   Execute: `dotnet run`

5. **Acesse a Documentação Scalar:**
   Navegue até a rota `https://localhost:PORTA/scalar/v1`.

---

> Projeto desenvolvido por **Wellington**