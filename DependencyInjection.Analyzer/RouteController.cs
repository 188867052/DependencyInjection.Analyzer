using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;

namespace DependencyInjection.Analyzer;

public class DependencyInjectionController : Controller
{
    private readonly IDependencyInjectionAnalyzer serviceAnalyzer;
    private readonly IMemoryCache memoryCache;

    public DependencyInjectionController(IDependencyInjectionAnalyzer serviceAnalyzer,
                           IMemoryCache memoryCache)
    {
        this.serviceAnalyzer = serviceAnalyzer;
        this.memoryCache = memoryCache;
    }

    [HttpGet]
    [Route(DependencyInjectionAnalyzer.DefaultRoute)]
    public IActionResult ShowAllServices()
    {
        this.memoryCache.TryGetValue(nameof(DependencyInjection), out string html);
        if (string.IsNullOrEmpty(html))
        {
            var value = this.serviceAnalyzer.GetDependencyInjectionInfo();
            html = DependencyInjectionAnalyzer.GetHtml(value);
            this.memoryCache.Set(nameof(DependencyInjection), html);
        }

        return this.Content(html, "text/html", Encoding.UTF8);
    }
}
