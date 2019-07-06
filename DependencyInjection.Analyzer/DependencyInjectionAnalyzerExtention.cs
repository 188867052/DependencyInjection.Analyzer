using System.Collections.Generic;
using System.Threading.Tasks;
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
                    ImplementationFactory = item.ImplementationFactory?.Target?.GetType().FullName,
                    ImplementationType = item.ImplementationType?.Name,
                    Namespace = item.ImplementationType?.Namespace,
                    Instance = item.ImplementationInstance?.GetType()?.Name,
                    Lifetime = item.Lifetime.ToString(),
                    ServiceType = item.ServiceType.Name,
                    ServiceAssembly = item.ServiceType?.Assembly?.ManifestModule.Name,
                    Index = services.IndexOf(item) + 1,

                };

                list.Add(serviceCollection);
            }

            ServiceCollection = list;
            return services;
        }
    }

    internal class DependencyInjectionRouter : IRouter
    {
        private readonly IRouter defaultRouter;
        private readonly string routePath;

        internal DependencyInjectionRouter(IRouter defaultRouter, string routePath)
        {
            this.defaultRouter = defaultRouter;
            this.routePath = routePath;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }

        public async Task RouteAsync(RouteContext context)
        {
            if (context.HttpContext.Request.Path == this.routePath)
            {
                var routeData = new RouteData(context.RouteData);
                routeData.Routers.Add(this.defaultRouter);
                routeData.Values["controller"] = nameof(RouteController).Replace("Controller", "");
                routeData.Values["action"] = nameof(RouteController.ShowAllServices);
                context.RouteData = routeData;
                await this.defaultRouter.RouteAsync(context);
            }
        }
    }
}
