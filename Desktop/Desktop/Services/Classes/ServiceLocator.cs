using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Desktop.Services.Classes;

public class ServiceLocator
{
    private static IHost? _host;

    public static void Initialize(IHost host)
    {
        _host = host;
    }
    
    public static T GetService<T>()
    {
        if (_host is null)
            throw new InvalidOperationException("ServiceLocator has not been initialized. Call Initialize method first.");

        return _host.Services.GetRequiredService<T>();
    }
}