using System.Linq;
using Api.Data;

public class UserRepository : IRepository<User>
{
    public void Add(User data)
    {
        using (Context context = new Context())
        {
            context.Users.Add(data);
            context.SaveChanges();
        }
    }

    public User Get(string name)
    {
        using (Context context = new Context())
        {
            User databaseUser = context.Users.FirstOrDefault(user => user.FirstName == name);
            return databaseUser;
        }
    }

    public void Update(string name)
    {
        using (Context context = new Context())
        {
            User databaseUser = context.Users.FirstOrDefault(user => user.FirstName == name);
            context.Users.Update(databaseUser);
        }
    }
}