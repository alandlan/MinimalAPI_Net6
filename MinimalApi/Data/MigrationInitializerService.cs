using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;

namespace MinimalApi.Data
{
    public static class MigrationInitializerService
    {
        public static void MigrationInitializer(this IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope()){
                var serviceDb = serviceScope.ServiceProvider.GetService<MinimalContextDb>();

                serviceDb.Database.Migrate();
            }
        }
    }
}


