using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DependencyInjection.Analyzer
{
    public class RouteController : Controller
    {
        private readonly IDependencyInjectionAnalyzer serviceAnalyzer;

        public RouteController(IDependencyInjectionAnalyzer serviceAnalyzer)
        {
            this.serviceAnalyzer = serviceAnalyzer;
        }

        [HttpGet]
        [Route(DependencyInjectionAnalyzer.DefaultRoute)]
        public IActionResult ShowAllServices()
        {
            var value = this.serviceAnalyzer.GetDependencyInjectionInfo();
            var html = DependencyInjectionAnalyzer.GetHtml(value.ToList());
            return this.Content(html, "text/html", Encoding.UTF8);
        }
    }
}