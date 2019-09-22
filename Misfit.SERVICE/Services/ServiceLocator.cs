using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Misfit.CORE.Domains;
using Misfit.CORE.Interfaces;
using Misfit.DA.DataAccesses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misfit.SERVICE.Services
{
    public class ServiceLocator
    {
        private static IServiceCollection _collection;
        public static void InjectDependencies(IServiceCollection collection, IConfiguration configuration)
        {
            _collection = collection;

            _collection.AddScoped<IUserRepository, UserDataAccess>();
            _collection.AddScoped<IGenericRepository<User>, UserDataAccess>();

            _collection.AddScoped<ICalculationRepository, CalculationDataAccess>();
            _collection.AddScoped<IGenericRepository<Calculation>, CalculationDataAccess>();


        }
        public static T GetInstance<T>()
        {
            try
            {
                var ty = typeof(T).ToString();
                var serviceProvider = _collection.BuildServiceProvider();
                //var services = serviceProvider.GetService<T>();
                //var serviceB = services.First(o => o.GetType() == typeof(T));
                return serviceProvider.GetService<T>();
            }
            catch
            {
                return default(T);
            }
        }

    }
}
