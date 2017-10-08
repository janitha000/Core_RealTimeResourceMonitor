
using System.Collections.Generic;


public class UsersManager
{
    public User GetUser(string name)
    {
        UserRepository repo = new UserRepository();
        User user = repo.Get(name);
        return user;
    }

    public void AddUser(User user)
    {
        UserRepository repo = new UserRepository();
        repo.Add(user);
    }
}