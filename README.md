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
Eg. input http://localhost:27634/routes.html
```
![screenshot](https://github.com/188867052/DependencyInjection.Analyzer/blob/master/DependencyInjection.Analyzer/services.png)
