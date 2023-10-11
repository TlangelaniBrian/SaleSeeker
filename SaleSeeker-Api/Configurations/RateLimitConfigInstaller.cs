using AspNetCoreRateLimit;

namespace SaleSeeker_Api.Configurations;

public class RateLimitConfigInstaller : IInstaller
{
    public static void InstallServices(WebApplicationBuilder builder, ConfigurationManager configuration)
    {
        builder.Services.AddMemoryCache();
        builder.Services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));
        builder.Services.Configure<IpRateLimitPolicies>(configuration.GetSection("IpRateLimitPolicies"));
        builder.Services.AddInMemoryRateLimiting();
        builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
    }
}