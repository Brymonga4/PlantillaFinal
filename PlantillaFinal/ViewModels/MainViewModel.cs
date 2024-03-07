using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlantillaFinal.Models;
using PlantillaFinal.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace PlantillaFinal.ViewModels;

internal partial class MainViewModel : ObservableObject
{

    [ObservableProperty]
    private ObservableCollection<ModelA>? itemsModelA;
    [ObservableProperty]
    private ObservableCollection<ModelB>? itemsModelB;
    [ObservableProperty]
    private ObservableCollection<ModelB>? listafiltrada;

    [ObservableProperty]
    private ModelA? selecteditemModelA;
    [ObservableProperty]
    private ModelB? selecteditemModelB;

    [ObservableProperty]
    private String image;


    private readonly ModelBService modelBService;
    private readonly ModelAService modelAService;

    public MainViewModel(ModelBService modelBService,
                           ModelAService modelAService)
    {
        this.modelBService = modelBService;
        this.modelAService = modelAService;

        ItemsModelA = new ObservableCollection<ModelA>();
        ItemsModelB = new ObservableCollection<ModelB>();

        LoadData();
    }
    public async Task LoadData()
    {

        Trace.WriteLine("Cargando items");
        var itemsB = await modelBService.GetAll();
        Trace.WriteLine(itemsB.Count.ToString());
        ItemsModelB = new ObservableCollection<ModelB>(itemsB);

        var itemsA = await modelAService.GetAll();
        Trace.WriteLine(itemsA.Count.ToString());
        ItemsModelA = new ObservableCollection<ModelA>(itemsA);

        //    OnPropertyChanged(nameof(Characters)); 
    }

    partial void OnSelecteditemModelBChanged(ModelB? value)
    {
        if (value != null)
        {
            Image = value.file;
        }
    }

    [RelayCommand]
    public void Filtrar()
    {
        listafiltrada = new ObservableCollection<ModelB>();
        foreach (var pinturas in itemsModelB)
        {
            if (pinturas.artist.name == selecteditemModelA.name) 
            {
                listafiltrada.Add(pinturas);
            }
        }

        ItemsModelB = listafiltrada;
    }


}
