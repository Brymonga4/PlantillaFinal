using CommunityToolkit.Mvvm.ComponentModel;
using PlantillaFinal.Models;
using PlantillaFinal.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantillaFinal.ViewModels;

public partial class ExamenViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ModelA>? itemsModelA;
    [ObservableProperty]
    private ObservableCollection<ModelB>? itemsModelB;

    [ObservableProperty]
    private ModelA? selecteditemModelA;
    [ObservableProperty]
    private ModelB? selecteditemModelB;

    [ObservableProperty]
    private String image;


    private readonly ModelBService modelBService;
    private readonly ModelAService modelAService;
    public ExamenViewModel(ModelBService modelBService, 
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
        if(value != null)
        {
            Image = value.file;
        }
    }


}
