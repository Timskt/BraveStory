using System;
using Microsoft.Extensions.DependencyInjection;

namespace BraveStory.Commons.Ioc;

public static class Program
{

    public static IServiceProvider Services  = ConfigureServices();
    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        return services.BuildServiceProvider();
    }

}
