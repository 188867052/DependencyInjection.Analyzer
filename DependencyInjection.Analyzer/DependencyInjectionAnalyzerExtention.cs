using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Analyzer
{
    public static class DependencyInjectionAnalyzerExtention
    {
        internal static IList<DependencyInjectionInfo> ServiceCollection { get; set; }

        public static IRouteBuilder MapDependencyInjectionAnalyzer(this IRouteBuilder routes)
        {
            routes.Routes.Add(new DependencyInjectionRouter(routes.DefaultHandler, DependencyInjectionAnalyzer.DefaultRoute));
            return routes;
        }

        public static IServiceCollection AddDependencyInjectionAnalyzer(this IServiceCollection services)
        {
            services.AddSingleton<IDependencyInjectionAnalyzer, DependencyInjectionAnalyzer>();
            IList<DependencyInjectionInfo> list = new List<DependencyInjectionInfo>();
            foreach (var item in services)
            {
                DependencyInjectionInfo serviceCollection = new DependencyInjectionInfo
                {
                    ImplementationType = item.ImplementationType?.FullName,
                    Lifetime = item.Lifetime.ToString(),
                    ServiceType = item.ServiceType.Name,
                    Index = services.IndexOf(item) + 1,
                };

                list.Add(serviceCollection);
            }

            ServiceCollection = list;
            return services;
        }
    }
}
