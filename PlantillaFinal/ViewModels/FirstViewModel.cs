using CommunityToolkit.Mvvm.ComponentModel;
using PlantillaFinal.Models;
using PlantillaFinal.Services;
using System.Collections.ObjectModel;
namespace PlantillaFinal.ViewModels;

public partial class FirstViewModel : ObservableObject
{

    [ObservableProperty]
    private ObservableCollection<ModelA>? itemsModelA;

    private readonly ModelAService modelAService;
    public FirstViewModel(ModelAService modelAService)
    {
        this.modelAService = modelAService;
    }
}
