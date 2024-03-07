using CommunityToolkit.Mvvm.ComponentModel;
using PlantillaFinal.Models;
using PlantillaFinal.Services;
using System.Collections.ObjectModel;

namespace PlantillaFinal.ViewModels;

public partial class SecondViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ModelB>? itemsModelB;

    private readonly ModelBService modelBService;

    public SecondViewModel(ModelBService modelBService)
    {
        this.modelBService = modelBService;
    }
}
