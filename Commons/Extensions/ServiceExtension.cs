using System;
using System.Linq;
using System.Reflection;
using BraveStory.Commons.Attributes;
using BraveStory.Commons.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace BraveStory.Commons.Extensions;

public static class ServiceExtension
{
    /// <summary>
    ///     注册ioc
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static ServiceCollection AddIoc(this ServiceCollection serviceCollection)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        var iocTypes = executingAssembly.GetTypes().Where(x => x.GetCustomAttribute<AutoIoc>() != null).ToList();
        foreach (var iocItem in iocTypes)
        {
            var autoIocAttribute = iocItem!.GetCustomAttribute<AutoIoc>();
            if (autoIocAttribute is { IocStrategy: IocStrategy.OnlyClass } && iocItem is { IsClass: true })
            {
                var isAutoIoc = iocItem.GetInterfaces().Where(x => x.GetCustomAttribute<AutoIoc>() != null).ToList()
                    .Count > 0;
                if (isAutoIoc) throw new Exception($"配置OnlyClass类型的ioc数据错误!{nameof(iocItem)}");

                var iocType = autoIocAttribute.IocLifeCycle;
                switch (iocType)
                {
                    case IocLifeCycle.Transient:
                        serviceCollection.AddTransient(iocItem);
                        break;
                    case IocLifeCycle.Scoped:
                        serviceCollection.AddScoped(iocItem);
                        break;
                    case IocLifeCycle.Singleton:
                        serviceCollection.AddSingleton(iocItem);
                        break;
                    default:
                        throw new NotSupportedException($"不支持的ioc类型: {iocType}");
                }

                continue;
            }

            if (autoIocAttribute is not { IocStrategy: IocStrategy.Interfaces } ||
                iocItem is not { IsInterface: true }) continue;
            {
                var servicesTypes = iocTypes.Where(x => x.IsClass && x.GetInterfaces().Contains(iocItem)).ToList();
                foreach (var servicesType in servicesTypes)
                {
                    var iocType = autoIocAttribute.IocLifeCycle;
                    switch (iocType)
                    {
                        case IocLifeCycle.Transient:
                            serviceCollection.AddTransient(iocItem, servicesType);
                            break;
                        case IocLifeCycle.Scoped:
                            serviceCollection.AddScoped(iocItem);
                            serviceCollection.AddScoped(iocItem, servicesType);
                            break;
                        case IocLifeCycle.Singleton:
                            serviceCollection.AddSingleton(iocItem, servicesType);
                            break;
                        default:
                            throw new NotSupportedException($"不支持的ioc类型: {iocType}");
                    }
                }
            }
        }

        return serviceCollection;
    }

    public static IServiceCollection AddIoc(this IServiceCollection serviceCollection)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        var iocTypes = executingAssembly.GetTypes().Where(x => x.GetCustomAttribute<AutoIoc>() != null).ToList();
        foreach (var iocItem in iocTypes)
        {
            var autoIocAttribute = iocItem!.GetCustomAttribute<AutoIoc>();
            if (autoIocAttribute is { IocStrategy: IocStrategy.OnlyClass } && iocItem is { IsClass: true })
            {
                var isAutoIoc = iocItem.GetInterfaces().Where(x => x.GetCustomAttribute<AutoIoc>() != null).ToList()
                    .Count > 0;
                if (isAutoIoc) throw new Exception($"配置OnlyClass类型的ioc数据错误!{nameof(iocItem)}");

                var iocType = autoIocAttribute.IocLifeCycle;
                switch (iocType)
                {
                    case IocLifeCycle.Transient:
                        serviceCollection.AddTransient(iocItem);
                        break;
                    case IocLifeCycle.Scoped:
                        serviceCollection.AddScoped(iocItem);
                        break;
                    case IocLifeCycle.Singleton:
                        serviceCollection.AddSingleton(iocItem);
                        break;
                    default:
                        throw new NotSupportedException($"不支持的ioc类型: {iocType}");
                }

                continue;
            }

            if (autoIocAttribute is not { IocStrategy: IocStrategy.Interfaces } ||
                iocItem is not { IsInterface: true }) continue;
            {
                var servicesTypes = iocTypes.Where(x => x.IsClass && x.GetInterfaces().Contains(iocItem)).ToList();
                foreach (var servicesType in servicesTypes)
                {
                    var iocType = autoIocAttribute.IocLifeCycle;
                    switch (iocType)
                    {
                        case IocLifeCycle.Transient:
                            serviceCollection.AddTransient(iocItem, servicesType);
                            break;
                        case IocLifeCycle.Scoped:
                            serviceCollection.AddScoped(iocItem);
                            serviceCollection.AddScoped(iocItem, servicesType);
                            break;
                        case IocLifeCycle.Singleton:
                            serviceCollection.AddSingleton(iocItem, servicesType);
                            break;
                        default:
                            throw new NotSupportedException($"不支持的ioc类型: {iocType}");
                    }
                }
            }
        }

        return serviceCollection;
    }

    public static ServiceCollection AddCustomService(this ServiceCollection serviceCollection)
    {
        return serviceCollection;
    }

    public static IServiceCollection AddCustomService(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}