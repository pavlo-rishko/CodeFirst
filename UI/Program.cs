using System;
using BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile(@"C:\Users\User\source\repos\UI\jsonPath.json")
            .Build();

            var serviceCollection = new ServiceCollection()
                .ConfigureBllDependencies(options => options
                .UseSqlServer(configuration.GetConnectionString("default")));

            using var serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
