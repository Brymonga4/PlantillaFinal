using PlantillaFinal.Data;
using PlantillaFinal.Models;
using System.Diagnostics;

namespace PlantillaFinal.Services;

public partial class ModelAService(RestService restService)
    : IServiceApi<ModelA>
{
    private readonly RestService restService = restService;

    public async Task<List<ModelA>> GetAll()
    {
        var itemsModelA = await restService.GetAllModelA();
        Trace.WriteLine(itemsModelA);
        return itemsModelA;
    }

    public async Task<ModelA> GetById(string id)
    {
        var itemModelA = await restService.GetModelAById(id);
        return itemModelA;
    }

}
