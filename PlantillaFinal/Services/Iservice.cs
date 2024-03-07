namespace PlantillaFinal.Services;
public interface IService<T>
{
    public void AddItem(T item);
    public void UpdateItem(T item);
    public void DeleteItem(string id);
    public T GetItem(string id);
    public List<T> GetItems();
}

public interface IServiceApi<T>
{
    public Task<T> GetById(string id);
    public Task<List<T>> GetAll();
}
