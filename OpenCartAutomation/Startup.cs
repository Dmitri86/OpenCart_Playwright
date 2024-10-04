using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenCartAutomation.Core.Autofac;
using OpenCartAutomation.Models.Configuration;
using System.Runtime.CompilerServices;

namespace OpenCartAutomation;

[SetUpFixture]
public class Startup
{
    private static IConfiguration _configuration;
    private static AppConfiguration _appConfiguration;

    [ModuleInitializer]
    public static void Setup()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");

        _configuration = builder.Build();
        ConfigureService();
    }

    private static void ConfigureService()
    {
        var services = new ServiceCollection();

        _appConfiguration = new AppConfiguration();

        _configuration.Bind("OpenCartSetting", _appConfiguration.OpenCartSetting);

        services.AddSingleton(_appConfiguration);
        services.AddSingleton(_appConfiguration.OpenCartSetting.UserCredential);

        var builder = new ContainerBuilder();
        builder.Populate(services);
        var container = builder.Build();
        DependencyResolver.SetResolver(container);
    }
}