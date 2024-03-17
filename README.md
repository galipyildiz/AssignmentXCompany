# Assignment

### Setup

- install .net 8 sdk =>https://dotnet.microsoft.com/en-us/download/dotnet/8.0
- choose your favorite IDE
- install docker => https://www.docker.com/get-started/
- pull postgres image

  ```
  docker pull postgres

  ```

- start postgresql container

```
docker run --name my-postgres-container -e POSTGRES_PASSWORD=12345 -e POSTGRES_USER=postgres -e POSTGRES_DB=GeneralDb -p 5432:5432 -d postgres

```

#### Nuget packages and external tools

- Npgsql.EntityFrameworkCore.PostgreSQL => nuget package for connection
- Microsoft.EntityFrameworkCore.Tools => nuget package for migration
- EF cli and migration commands
  ```
  dotnet tool install --global dotnet-ef
  dotnet ef migrations add InitialCreate
  dotnet ef database update
  ```

let's begin...
