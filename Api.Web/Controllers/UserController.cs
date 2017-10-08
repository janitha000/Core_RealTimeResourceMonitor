
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class UserController : Controller
{

    [HttpGet("{name}")]
    public User Get(string name)
    {
        UserManager manager = new UserManager();
        User user = manager.GetUser(name);
        return user;
    }

    [HttpPost]
    public void Post([FromBody]User user)
    {
        UserManager manager = new UserManager();
        manager.AddUser(user);
    }

}
