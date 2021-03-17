# AssetManagement API (Sample Application API)

## Introduction
This project defines an .NET 5 Web API for Asset Management, Just for demo purposes.

## Gettin' Started
The solution is divided in the following layers 
- Data : Which defines the database context and the data access abstractions.
- Domain : Which defines the business logic, the data structures and data contracts.
- Web : The web application which exposes the REST Endpoints.

## Run
Using the .NET 5 SDK (CLI), in the solution root directory you can run the following command : 
```
dotnet run --project ./Hahn.ApplicationProcess.February2021.Web
```

Or using docker and go to http://localhost:8000
```
docker-compose -f "docker-compose.yml" up -d --build;
```

## Contribution
### Must do 
- Every data access abstraction requires its contract/interface.
- Respect the access modifiers and expose only the neccesary.
- The private properties and fields should start with _
- Try not to use this, use if it is totally neccesary.
- Add the XML Comments/Summary to every important public member in the code. (Abstraction Layers, Models, Logic, DataAccess)

### Suggestions 
- Use Visual Studio/Visual Studio Code

### References 
- [Code Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
- [C# Coding style](https://github.com/couven92/dotnet-corefx/blob/master/Documentation/coding-guidelines/coding-style.md)
- [Gettings Started in .NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio)
- [Swashbuckle in ASP.NET CORE](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio)
- [Design the infrastructure persistence layer](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)
- [Visual Studio Code](https://github.com/Microsoft/vscode)