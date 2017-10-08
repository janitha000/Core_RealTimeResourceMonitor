
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class UserController : Controller
{

    [HttpGet("{name}")]
    public User Get(string name)
    {
        UsersManager manager = new UsersManager();
        User user = manager.GetUser(name);
        return user;
    }

    [HttpPost]
    public void Post([FromBody]User user)
    {
        UsersManager manager = new UsersManager();
        manager.AddUser(user);
    }

}
