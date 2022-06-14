| Package | NuGet Stable | Downloads |
| ------- | ------------ | --------- |
| [DependencyInjection.Analyzer](https://www.nuget.org/packages/DependencyInjection.Analyzer/) | [![DependencyInjection.Analyzer](https://img.shields.io/nuget/v/DependencyInjection.Analyzer.svg)](https://www.nuget.org/packages/DependencyInjection.Analyzer/) | [![DependencyInjection.Analyzer](https://img.shields.io/nuget/dt/DependencyInjection.Analyzer.svg)](https://www.nuget.org/packages/DependencyInjection.Analyzer/) | 
### Install NuGet package
- [NuGet Gallery | DependencyInjection.Analyzer](https://www.nuget.org/packages/DependencyInjection.Analyzer)

```
PM> Install-Package DependencyInjection.Analyzer
```

### Edit Startup.cs
Insert code ```services.AddDependencyInjectionAnalyzer();``` and required ```using``` directive into Startup.cs as follows.

```cs
using DependencyInjection.Analyzer; // Add
....
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    services.AddDependencyInjectionAnalyzer(); // Add
}
....
```
## View Services via Browser
```
Eg. input https://localhost:44336/services
```
![screenshot](https://github.com/188867052/DependencyInjection.Analyzer/blob/master/DependencyInjection.Analyzer/services.png)

## Technologies

* [ASP.NET 6.0](https://docs.microsoft.com/en-us/aspnet/core)
* [C# 10](https://docs.microsoft.com/en-us/dotnet/csharp)
* [DependencyInjection](https://github.com/aspnet/DependencyInjection)

## Other containers with Microsoft.Extensions.DependencyInjection

* [**Autofac**](https://autofac.readthedocs.org/en/latest/integration/aspnetcore.html)
* [**DryIoc**](https://www.nuget.org/packages/DryIoc.Microsoft.DependencyInjection)
* [**Grace**](https://www.nuget.org/packages/Grace.DependencyInjection.Extensions)
* [**LightInject**](https://github.com/seesharper/LightInject.Microsoft.DependencyInjection)
* [**StructureMap**](https://github.com/structuremap/StructureMap.Microsoft.DependencyInjection)
* [**Stashbox**](https://github.com/z4kn4fein/stashbox-extensions-dependencyinjection)
* [**Unity**](https://www.nuget.org/packages/Unity.Microsoft.DependencyInjection/)

## My projects
* [EFCore.Scaffolding.Extension](https://github.com/188867052/EFCore.Scaffolding.Extension)
* [DependencyInjection.Analyzer](https://github.com/188867052/DependencyInjection.Analyzer)
* [Route.Generator](https://github.com/188867052/Route.Generator)
* [MatrixAdmin](https://github.com/188867052/MatrixAdmin)
* [DapperExtension](https://github.com/188867052/DapperExtension)
* [Quartz.Web](https://github.com/188867052/Quartz.Web)
