public interface IRepository<TData>
{
    void Add(TData data);
    TData Get(string name);
    void Update(string name);
}