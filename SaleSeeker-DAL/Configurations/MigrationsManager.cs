using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SaleSeeker_DAL.Configurations;

public static class MigrationsManager
{
    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<SaleSeekerContext>();
        try
        {
            context.Database.Migrate();
        }
        catch (Exception)
        {
            //NOTE: EXCEPTION HANDING AND ERROR LOGING IS REQUIRED
        }
        return app;
    }
}
