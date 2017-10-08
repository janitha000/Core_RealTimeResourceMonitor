
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class UserController : Controller
{

    [HttpGet]
    public IEnumerable<User> Get()
    {
        //return new string[] { "value1", "value2" };
        return null;
    }

}
