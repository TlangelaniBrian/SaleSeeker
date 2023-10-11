using Microsoft.EntityFrameworkCore;
using SaleSeeker_Api.Repositories;
using SaleSeeker_DAL;

namespace SaleSeeker_Api.Configurations
{
    public abstract class RepositoryConfigInstaller : IInstaller
    {
        public static void InstallServices(WebApplicationBuilder builder, ConfigurationManager configuration)
        {
            builder.Services.AddDbContextPool<SaleSeekerContext>(
                options =>
                {
                    options.UseSqlServer(configuration["ConnectionStrings:SaleSeekerDB"]);
                });

            builder.Services.AddScoped<IDbService, DbService>();
        }
    }
}
