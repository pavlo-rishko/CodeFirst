using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DAL
{
  static class Extension
    {
        public static IServiceCollection ConfigureDalDependencies(this IServiceCollection serviceCollection,
    Action<DbContextOptionsBuilder> optionsAction)
        {
            serviceCollection.AddDbContext<MYdbCodeFirstContext>(optionsAction);
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            return serviceCollection;
        }
    }
}
