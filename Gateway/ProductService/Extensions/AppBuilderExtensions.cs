namespace ProductService.Extensions
{
    using Microsoft.AspNetCore.Builder;

    internal static class AppBuilderExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(builder =>
            {
                builder.AddConfiguration(configuration.GetSection("Logging"));
                builder.AddConsole();
                builder.AddSerilog();
            });

            services.AddScoped<DownloadSourceFile>();

            services.AddScoped<IRemoteServerCall, RemoteServerCall>();
            services.AddScoped<IContentWriter, ContentWriter>();
        }
    }
}
