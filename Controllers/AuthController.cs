using Ecommerceapi.Dto;
using Ecommerceapi.Interfaces;
using Ecommerceapi.Models;
using Ecommerceapi.Request_Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }


    // POST api/<AuthController>
    [HttpPost]
    public LogRes Login([FromBody] LoginRequest loginModel)
    {
        var result = _authService.Login(loginModel);
        return result;
    }

    // PUT api/<AuthController>/5
    [HttpPost("addUser")]
    public User AddUser([FromBody] User value)
    {
        var user = _authService.AddUser(value);
        return user;
    }


}