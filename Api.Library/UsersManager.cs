
using System.Collections.Generic;


public class UsersManager
{
    private IUserRepository _userRepository;

    public UsersManager(IUserRepository repository){
        _userRepository = repository;
    }

    public User GetUser(string name)
    {     
        User user = _userRepository.Get(name);
        return user;
    }

    public void AddUser(User user)
    {
        _userRepository.Add(user);
    }

    public bool IsUserNameNull(User user){
        return (user.FirstName == null);
    }
}