# TesteBecomexRobo
Repositório para subir R.O.B.O de acordo com avaliação de conhecimentos da Becomex/Narwal

## Tecnologias e bibliotecas
- Web API Restful
  - NET 8.0
    - Entity Framework Core 8.0.6
    - Microsoft.EntityFrameworkCore.InMemory 8.0.6
    - XUnit 2.4.2
- Frontend    
  - NodeJS v18.18.0
    - Http-server 14.1.1

## Como subir o projeto
- Primeiro, suba a API dentro de src/api utilizando o comando: `dotnet run --project roboApi.RestAPI`
- Para consultar a interface gráfica, dentro de src/webapp, rode: `npm install` e depois: `npm run start`
