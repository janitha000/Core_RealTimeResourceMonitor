using System;
using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IRepository<User>
{
    // private readonly Context _context;

    // public UserRepository(Context context)
    // {
    //     _context = context;
    // }

    public void Add(User data)
    {
         using (Context context = new Context())
        {
            context.Users.Add(data);
            context.SaveChanges();
        }
    }

    public User Get(string param)
    {
        User  user = new User();
        using (Context context = new Context())
        {
            context.Users.FirstOrDefault(x => x.FirstName == param); 
        }
        return user;
    }

    public IEnumerable<User> List()
    {
        IEnumerable<User> users;
        using (Context context = new Context())
        {
            users = context.Users.AsEnumerable();
        }
        return users;
    }

    public void Update(User data)
    {
        using (Context context = new Context())
        {
            context.Entry(data).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}