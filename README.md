## ProductAPI

## Descrição
Este projeto é uma API para consultar CEP.

## Configuração e Execução

## Requisitos
- [.NET Core SDK 8.0 ou superior](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/downloads)
- [SQL Server](https://www.microsoft.com/sql-server)

- ## :computer: Tecnologias
Esse projeto foi feito utilizando as seguintes tecnologias:

* [EF Core](https://learn.microsoft.com/pt-br/ef/)      
* [ASP.Net](https://dotnet.microsoft.com/pt-br/apps/aspnet)      
* [SQL Server](https://www.microsoft.com/sql-server)      

## :construction_worker: Instalação
```bash
# Clone o Repositório
$ git clone https://github.com/ViniRodriguess/cepAPI.git
```
## 📦 Configuração do Banco de Dados

1. Abra o arquivo `appsettings.json` e configure a conexão com o banco de dados SQL Server.

2. Configure o dotnet-ef para rodar as migrations:

```bash
# Instale o dotnet-ef global
$ dotnet tool install --global dotnet-ef
# Faça update da ferramente
$ dotnet tool update --global dotnet-ef
# Verifique a instalação
$ dotnet ef
```

3. Execute as migrations para criar o banco de dados, as tabelas e os dados iniciais:
```bash
# Rode as migrations (em alguns casos, é necessário especificar o caminho do projeto com a flag --project)
$ dotnet ef database update
```

## Executando a API
1. Para iniciar a aplicação, execute o seguinte comando na raiz do projeto:

```bash
$ dotnet run
```

### Swagger screenshot
![Swagger](https://github.com/ViniRodriguess/cepAPI/assets/79362178/db44fc77-3d7f-4498-9812-0f433c8a369d)


💻 Acesse a API através do URL base: `https://localhost:5001` (ou a url informada no terminal).

## Rotas da API
- `GET /api/Cep/{cep}`: Retorna os dados pelo seu CEP.


## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para enviar pull requests ou relatar problemas.


