using Serilog;

namespace geo_service.Extensions
{
    public static class LoggerExtension
    {
        public static IServiceCollection AddLogger(this IServiceCollection services, IConfiguration configuration, ILoggingBuilder logging)
        {
            var Logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(configuration)
                            .Enrich.FromLogContext()
                            .Enrich.WithThreadId()
                            .CreateLogger();
            logging.ClearProviders();
            logging.AddSerilog(Logger);
            services.AddHttpLogging(options =>
            {
                options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
            });
            return services;
        }
    }
}
