using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class InMemoryUserRepository : IRepository<User>
{
    public void Add(User data)
    {
        using (InMemoryContext context = new InMemoryContext())
        {
            context.Users.Add(data);
            context.SaveChanges();
        }
    }

    public User Get(string param)
    {
        User user = new User();
        using (InMemoryContext context = new InMemoryContext())
        {
            context.Users.FirstOrDefault(x => x.FirstName == param);
        }
        return user;
    }

    public IEnumerable<User> List()
    {
        IEnumerable<User> users;
        using (InMemoryContext context = new InMemoryContext())
        {
            users = context.Users.AsEnumerable();
        }
        return users;
    }

    public void Update(User data)
    {
        using (InMemoryContext context = new InMemoryContext())
        {
            context.Entry(data).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}