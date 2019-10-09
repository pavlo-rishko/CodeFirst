using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using DAL.UnitOfWork;

namespace DAL
{
    public static class DalBuilder
    {
        public static IServiceCollection ConfigureDalDependencies(this IServiceCollection serviceCollection,
        Action<DbContextOptionsBuilder> optionsAction)
        {
            serviceCollection.AddDbContext<MYdbCodeFirstContext>(optionsAction);
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            return serviceCollection;
        }
    }
}
