
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/[controller]")]
public class UserController : Controller
{
    private readonly IManager<User> _usermanager;

    public UserController(IManager<User> manager)
    {
        _usermanager = manager ?? throw new ArgumentNullException(nameof(manager));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<User>), 200)]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            IEnumerable<User> users = _usermanager.GetAll();
            return Ok(users);
        }
        catch (UserException)
        {
            return NotFound();
        }

    }

    [HttpGet("{name}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(string name)
    {
        try
        {
            User user = _usermanager.Get(name);
            return Ok(user);
        }
        catch (UserException)
        {
            return NotFound();
        }

    }

    [HttpPost]
    [ValidateModel] 
    [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody]User user)
    {
        var createdUser = _usermanager.Add(user);
        return Ok(createdUser);
    }

    [HttpPut("{firstname")]
    [ValidateModel] 
    public async Task<IActionResult> PutAsync(string firstname, [FromBody] User user )
    {
        if(!_usermanager.Exists(firstname)){
            return NotFound(firstname);
        }

        _usermanager.Update(user);
        return Ok();
    }

}
