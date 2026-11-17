# FinanceAI



**Intelligent Financial Decision Platform**



FinanceAI is an evolving, AI-powered financial decision platform designed to help users understand their financial activity, manage budgets, evaluate financial scenarios, and make more informed decisions.



The project combines a .NET-based financial backend with a planned AI assistant capable of analyzing financial information through controlled, auditable tools.



FinanceAI is being developed incrementally, with an emphasis on maintainable architecture, secure data handling, automated testing, and responsible AI integration.



## Project Status



**Status: Early Development — Backend Foundation**



The initial backend provides transaction management capabilities backed by PostgreSQL.



AI capabilities, authentication, budgeting, financial simulations, and the frontend application are planned for subsequent development phases.



## Technology Stack



### Current Implementation



| Category | Technology |

|---|---|

| Language | C# |

| Backend | .NET 10, ASP.NET Core Web API |

| Data Access | Entity Framework Core, Npgsql |

| Database | PostgreSQL |

| API Style | REST |

| Architecture | Layered architecture |

| Data Modeling | EF Core Code-First Migrations |

| Dependency Management | Built-in .NET Dependency Injection |



### Planned Technologies



The following technologies are part of the technical roadmap and are not yet implemented:



- **Frontend:** Angular and TypeScript

- **Authentication:** JWT-based authentication and authorization

- **Testing:** Unit and integration tests

- **Containerization:** Docker

- **CI/CD:** GitHub Actions

- **Caching:** Redis, where justified by performance requirements

- **Messaging:** RabbitMQ, where asynchronous workflows require it

- **AI Integration:** LLM integration and structured tool calling

- **Agentic Workflows:** Controlled financial assistant operations

- **Interoperability:** Model Context Protocol (MCP)



Technology choices will be evaluated against actual product requirements rather than introduced solely for demonstration purposes.



## Current Architecture



The backend is organized into four projects:



```text

FinanceAI/

├── backend/

│   ├── FinanceAI.Api/

│   ├── FinanceAI.Business/

│   ├── FinanceAI.DataAccess/

│   ├── FinanceAI.Entities/

│   └── backend.slnx

└── README.md

```



### Layer Responsibilities



**FinanceAI.Api**



Exposes HTTP endpoints, handles incoming requests, and coordinates application operations.



**FinanceAI.Business**



Contains application services and interfaces used to coordinate transaction operations.



**FinanceAI.DataAccess**



Implements persistence through Entity Framework Core, including the database context, repositories, and migrations.



**FinanceAI.Entities**



Contains domain entities shared across the application.



### Transaction Request Flow



```text

HTTP Request

     |

     v

TransactionsController

     |

     v

TransactionService

     |

     v

TransactionRepository

     |

     v

FinanceAIDbContext

     |

     v

PostgreSQL

```



The architecture will evolve as domain complexity and product requirements increase.



## Implemented Capabilities



The current backend includes:



- Transaction entity and persistence model

- Transaction repository abstraction

- Transaction application service

- Transaction API controller

- PostgreSQL integration through EF Core

- Initial database migration

- Dependency injection configuration

- Asynchronous transaction operations



The API currently supports transaction creation, retrieval, and deletion operations.



## Development Roadmap



### Phase 1 — Financial Backend Foundation



- [x] Initialize the .NET backend solution

- [x] Establish the initial layered architecture

- [x] Configure PostgreSQL and EF Core

- [x] Create the transaction persistence model

- [x] Implement initial transaction endpoints

- [ ] Introduce consistent validation and error handling

- [ ] Add authentication and user-level data isolation

- [ ] Implement automated tests

- [ ] Expand income and expense management



### Phase 2 — Financial Intelligence



- [ ] Budget management

- [ ] Spending categorization and summaries

- [ ] Financial reporting

- [ ] Scenario simulations, including installment-based spending

- [ ] Financial insights and explainable calculations



### Phase 3 — AI-Powered Financial Assistant



- [ ] Integrate an LLM through a provider-agnostic abstraction

- [ ] Implement structured tool calling

- [ ] Enable read-only financial analysis tools

- [ ] Ground AI responses in application data

- [ ] Add evaluation and observability mechanisms

- [ ] Introduce approval-controlled operations

- [ ] Explore MCP-based tool interoperability



### Phase 4 — Product Experience and Operations



- [ ] Build an Angular frontend

- [ ] Introduce containerized development

- [ ] Establish CI/CD pipelines

- [ ] Add operational monitoring

- [ ] Improve performance and deployment readiness



The roadmap is subject to change as implementation and architectural decisions evolve.



## Security Principles



FinanceAI is intended to handle financial information with explicit attention to security and privacy.



Development principles include:



- Never commit credentials or API keys to source control

- Keep sensitive configuration outside committed source files

- Validate incoming data

- Enforce authorization and user-level data isolation before supporting multiple users

- Minimize sensitive information in logs

- Require explicit user approval for AI-initiated write operations

- Treat AI-generated outputs as untrusted until validated



Authentication, authorization, and AI operation controls remain planned work.



## AI Engineering Approach



The planned financial assistant will operate through explicitly defined application tools rather than unrestricted database access.



The intended design separates:



1\. **Financial domain logic:** Deterministic calculations and business rules

2\. **Application tools:** Controlled operations exposed to the AI layer

3\. **LLM orchestration:** Interpretation, tool selection, and response generation

4\. **Authorization and approval:** Enforcement of access rights and confirmation of sensitive operations

5\. **Evaluation and observability:** Assessment of tool execution, response quality, and operational behavior



Financial calculations and access control will remain under application control rather than being delegated entirely to a language model.



## Getting Started



### Prerequisites



- .NET 10 SDK

- PostgreSQL

- Visual Studio or another .NET-compatible development environment



### Local Setup



Clone the repository:



```bash

git clone https://github.com/rusent/FinanceAI.git

cd FinanceAI/backend

```



Restore dependencies:



```bash

dotnet restore backend.slnx

```



Configure a local PostgreSQL connection using .NET User Secrets or another appropriate local configuration provider.



Apply the EF Core migrations to the configured database, then start the API:



```bash

dotnet run --project FinanceAI.Api

```



Database setup and API verification instructions will be expanded as the project evolves.



## Engineering Practices



The project aims to follow these engineering practices as development progresses:



- Small, focused commits

- Clear separation of responsibilities

- Dependency injection

- Asynchronous I/O

- Code review and maintainability

- Automated testing

- Security-conscious configuration

- Documentation of meaningful architectural decisions



## Disclaimer



FinanceAI is an experimental software engineering project under active development.



It is not a production-ready financial service and does not provide regulated financial advice. Any future AI-generated financial insights will be designed to support user understanding rather than replace professional financial judgment.

