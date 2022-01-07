using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POC.GraphQL.Repository.Data.Context;
using System;
using POC.GraphQL.Repository.Data;

namespace POC.GraphQL.Api.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<SchoolContext>())
                {
                    try
                    {
                        
                        appContext.Database.Migrate();
                        DbInitializer.Initialize(appContext);
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }

            return webHost;
        }
    }
}
