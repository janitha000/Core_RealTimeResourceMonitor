using System.Collections.Generic;

public interface IManager<T>
{
    IEnumerable<T> GetAll();
    T Get(string param);
    void Add(T data);
    bool Exists(string param);
}