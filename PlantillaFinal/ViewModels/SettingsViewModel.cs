using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using PlantillaFinal.Views;
using System.Diagnostics;
using System.Globalization;
using System.Windows;

namespace PlantillaFinal.ViewModels;

partial class SettingsViewModel : ObservableObject
{
    public SettingsViewModel() { }

    [RelayCommand]
    public void SpanishLang()
    {
        SetCulture("es");
    }

    [RelayCommand]
    public void EngLang()
    {
        SetCulture("en");
    }


    public void SetCulture(string culture)
    {
        var newCulture = new CultureInfo(culture);
        Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
        Thread.CurrentThread.CurrentUICulture = newCulture;

        Properties.Settings.Default.Culture = culture;
        Properties.Settings.Default.Save();
        RestartApplication();
    }

    private static void RestartApplication()
    {
        Process.Start(Process.GetCurrentProcess().MainModule.FileName);
        Application.Current.Shutdown();
    }
}
