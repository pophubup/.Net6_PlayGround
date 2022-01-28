using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using zNpgsqlClient.Entities;

namespace zNpgsqlClient
{
    public static class AddNpgsqlClient
    {
        public static IServiceCollection AddPostgreSQLClient(this IServiceCollection service, string conn)
        {
            service.AddPooledDbContextFactory<Test3Context>(options => options
   .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
   .UseNpgsql(conn));
            //var buidler = service.BuildServiceProvider();
            //IDbContextFactory < Test2Context > dbContext = buidler.GetService<IDbContextFactory<Test2Context>>();
            return service;
        }
    }
}
