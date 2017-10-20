
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UsersManager : IManager<User>
{
    private readonly IRepository<User> _userRepository;

    public UsersManager(IRepository<User> repository){
        _userRepository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public bool IsUserNameNull(User user){
        return (user.FirstName == null);
    }

     

    public User Get(string param)
    {
        User user = _userRepository.Get(dbUser => dbUser.FirstName == param );
        return user;
    }

    public void Add(User data)
    {
         _userRepository.Add(data);
    }

    public IEnumerable<User> GetAll()
    {
       return  _userRepository.List();
    }
}