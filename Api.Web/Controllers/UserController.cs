
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/[controller]")]
public class UserController : Controller
{
    private readonly IManager<User> _usermanager;

    public UserController(IManager<User> manager){
        _usermanager = manager ?? throw new ArgumentNullException(nameof(manager));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<User>), 200)]
    public async Task<IActionResult>  GetAllAsync()
    {
        IEnumerable<User> users = _usermanager.GetAll();
        return Ok(users);
    }

    [HttpGet("{name}")]
    public User Get(string name)
    {
        UsersManager manager = new UsersManager(new UserRepository());
        User user = manager.Get(name);
        return user;
    }

    [HttpPost]
    public void Post([FromBody]User user)
    {
        UsersManager manager = new UsersManager(new UserRepository());
        manager.Add(user);
    }

}
