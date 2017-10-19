using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public interface IRepository<TData> where TData : BaseEntity
{
    void Add(TData data);
    TData Get(Expression<Func<TData, bool>> predicate);
    void Update(TData data);
    //IEnumerable<TData> List(Expression<Func<TData, bool>> predicate);
    IEnumerable<TData> List();

    //void Delete(TData data);
}