using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;

namespace DependencyInjection.Analyzer
{
    public class RouteController : Controller
    {
        private readonly IDependencyInjectionAnalyzer serviceAnalyzer;
        private readonly IMemoryCache memoryCache;

        public RouteController(IDependencyInjectionAnalyzer serviceAnalyzer,
                               IMemoryCache memoryCache)
        {
            this.serviceAnalyzer = serviceAnalyzer;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        [Route(DependencyInjectionAnalyzer.DefaultRoute)]
        public IActionResult ShowAllServices()
        {
            var value = this.serviceAnalyzer.GetDependencyInjectionInfo();
            this.memoryCache.TryGetValue("DependencyInjection", out string html);
            if (string.IsNullOrEmpty(html))
            {
                html = DependencyInjectionAnalyzer.GetHtml(value);
                this.memoryCache.Set("DependencyInjection", html);
            }

            return this.Content(html, "text/html", Encoding.UTF8);
        }
    }
}
