public interface IManager<T>
{
    T Get(string param);
    void Add(T data);
}