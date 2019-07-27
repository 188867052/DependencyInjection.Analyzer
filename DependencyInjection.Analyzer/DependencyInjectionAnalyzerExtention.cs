using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Analyzer
{
    public static class DependencyInjectionAnalyzerExtention
    {
        internal static IList<DependencyInjectionInfo> ServiceCollection { get; set; }

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
}
