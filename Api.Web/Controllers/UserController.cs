
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Route("api/v1/[controller]")]
public class UserController : Controller
{
    private readonly IManager<User> _usermanager;

    public UserController(IManager<User> manager){
        _usermanager = manager ?? throw new ArgumentNullException(nameof(manager));
    }

    [HttpGet]
    public string GetAll(string name)
    {
        return "Janitha";
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
        manager.AddUser(user);
    }

}
