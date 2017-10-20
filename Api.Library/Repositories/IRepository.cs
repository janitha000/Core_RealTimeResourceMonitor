using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public interface IRepository<TData> where TData : BaseEntity
{
    void Add(TData data);
    TData Get(String param);
    void Update(TData data);
    IEnumerable<TData> List();

    //void Delete(TData data);
    //IEnumerable<TData> List(Expression<Func<TData, bool>> predicate);
    //TData Get(Expression<Func<TData, bool>> predicate);

}