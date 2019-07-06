### Install NuGet package
- [NuGet Gallery | DependencyInjection.Analyzer](https://www.nuget.org/packages/DependencyInjection.Analyzer)

```
PM> Install-Package DependencyInjection.Analyzer
```

### Edit Startup.cs
Insert code ```services.AddDependencyInjectionAnalyzer();``` and ```routes.MapDependencyInjectionAnalyzer();``` and required ```using``` directive into Startup.cs as follows.

```cs
using DependencyInjection.Analyzer; // Add
....
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    services.AddDependencyInjectionAnalyzer(); // Add
}
....
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    app.UseMvc(routes =>
    {
        routes.MapDependencyInjectionAnalyzer(); // Add
	....
    });
}
```
## View Services via Browser
```
Eg. input https://localhost:44336/services
```
![screenshot](https://github.com/188867052/DependencyInjection.Analyzer/blob/master/DependencyInjection.Analyzer/services.png)

## Technologies

* [ASP.NET Core 2.2](https://docs.microsoft.com/en-us/aspnet/core)
* [C# 7.3](https://docs.microsoft.com/en-us/dotnet/csharp)
* [Route.Generator](https://github.com/188867052/Route.Generator)
* [DependencyInjection](https://github.com/aspnet/DependencyInjection)

## Other containers with Microsoft.Extensions.DependencyInjection

* [**Autofac**](https://autofac.readthedocs.org/en/latest/integration/aspnetcore.html)
* [**DryIoc**](https://www.nuget.org/packages/DryIoc.Microsoft.DependencyInjection)
* [**Grace**](https://www.nuget.org/packages/Grace.DependencyInjection.Extensions)
* [**LightInject**](https://github.com/seesharper/LightInject.Microsoft.DependencyInjection)
* [**StructureMap**](https://github.com/structuremap/StructureMap.Microsoft.DependencyInjection)
* [**Stashbox**](https://github.com/z4kn4fein/stashbox-extensions-dependencyinjection)
* [**Unity**](https://www.nuget.org/packages/Unity.Microsoft.DependencyInjection/)
