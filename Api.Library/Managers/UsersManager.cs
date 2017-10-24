
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UsersManager : IManager<User>
{
    private readonly IRepository<User> _userRepository;

    public UsersManager(IRepository<User> repository)
    {
        _userRepository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public User Get(string param)
    {
        User user = _userRepository.Get(param);
        return user;
    }

    public User Add(User data)
    {
        _userRepository.Add(data);
        return data;
    }

    public IEnumerable<User> GetAll()
    {
        return _userRepository.List();
    }

    public bool Exists(string param)
    {
        User user = Get(param);
        return user != null;
    }
}