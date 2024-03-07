using Microsoft.Extensions.DependencyInjection;
using PlantillaFinal.Data;
using PlantillaFinal.Services;
using PlantillaFinal.ViewModels;
using PlantillaFinal.Views;
using System.Globalization;
using System.Windows;

namespace PlantillaFinal;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }
    protected override void OnStartup(StartupEventArgs e)
    {

        base.OnStartup(e);

        ConfigureLanguage();

        ServiceCollection serviceCollection = new();
        ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        ServiceProvider = serviceProvider;

        //Que empiece por aquí en lugar del App.xaml, para usar IoC
        var view = serviceProvider.GetRequiredService<MainView>();
        view.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
        view.Show();
    }
    private static void ConfigureServices(IServiceCollection services)
    {
        //Views
        services.AddTransient<MainView>();
        services.AddScoped<HomeView>();
        services.AddScoped<FirstView>();
        services.AddScoped<SecondView>();
        services.AddScoped<SettingsView>();

        //ViewModels
        services.AddTransient<MainViewModel>();
        services.AddScoped<HomeViewModel>();
        services.AddScoped<FirstViewModel>();
        services.AddScoped<SecondViewModel>();
        services.AddScoped<SettingsViewModel>();

        services.AddScoped<ExamenView>();
        services.AddScoped<ExamenViewModel>();

        //Services
        services.AddSingleton<RestService>();

        services.AddSingleton<ModelAService>();
        services.AddSingleton<ModelBService>();

    }

    private void ConfigureLanguage()
    {
        var culture = PlantillaFinal.Properties.Settings.Default.Culture;
        var newCulture = new CultureInfo(culture);
        Thread.CurrentThread.CurrentCulture = newCulture;
        Thread.CurrentThread.CurrentUICulture = newCulture;
    }


}
