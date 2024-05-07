using System;
using System.Collections.Generic;
using MVVMExample.Infrastructure.Services;

namespace MVVMExample.Infrastructure.Bootstrap
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, IService> _services = new();

        public static TService GetService<TService>()
        {
            return (TService)_services[typeof(TService)];
        }

        public static void AddService<TService>(IService newService) where TService : IService
        {
            _services.TryAdd(typeof(TService), newService);
        }
    }
}