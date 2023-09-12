namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddMailService(
        this IServiceCollection services,
        Action<SMTPOptions> config)
    {
        services.AddSingleton<Sender>();
        services.Configure<SMTPOptions>(config);

        return services;
    }
}
