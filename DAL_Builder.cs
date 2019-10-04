using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public static class DAL_Builder
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
