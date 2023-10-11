using Serilog;

namespace SaleSeeker_Api.Configurations;

public class LoggingConfigInstaller : IInstaller
{
    public static void InstallServices(WebApplicationBuilder builder, ConfigurationManager configuration)
    {
        builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

        //Add Serilog ILogger
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        builder.Services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog();
        });
    }
}