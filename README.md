# about
sandbox for testing out gembox features

# init
```
dotnet new sln --name demo
dotnet new console --name labs.core --output labs.core
dotnet sln add .\labs.core\labs.core.csproj
dotnet restore
dotnet build demo.sln
```
