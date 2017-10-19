using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Api.Data;
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly Context _context;

    // public Repository(Context context)
    // {
    //     _context = context;
    // }

    public void Add(T data)
    {
        using (Context context = new Context())
        {
            context.Set<T>().Add(data);
            context.SaveChanges();
        }
    }

    public T Get(Expression<Func<T, bool>> predicate)
    {
        using (Context context = new Context())
        {
            T item = context.Set<T>().Where(predicate).FirstOrDefault();
            return item;
        }
    }

    public IEnumerable<T> List()
    {
        using (Context context = new Context())
        {
            return context.Set<T>().AsEnumerable();
        }
    }

    public void Update(T Data)
    {
        using (Context context = new Context())
        {
            context.Entry(Data).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}