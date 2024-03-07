using PlantillaFinal.Data;
using PlantillaFinal.Models;
namespace PlantillaFinal.Services;

public partial class ModelBService(RestService restService)
    : IServiceApi<ModelB>
{
    private readonly RestService restService = restService;

    public async Task<List<ModelB>> GetAll()
    {
        var itemsModelB = await restService.GetAllModelB();
        return itemsModelB;
    }

    public async Task<ModelB> GetById(string id)
    {
        var itemModelB = await restService.GetModelBById(id);
        return itemModelB;
    }
}
