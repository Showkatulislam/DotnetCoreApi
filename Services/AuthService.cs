using Ecommerceapi.Interfaces;
using Ecommerceapi.Context;
using Ecommerceapi.Models;
using Ecommerceapi.Request_Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ecommerceapi.Dto;

namespace Ecommerceapi.Services;

public class AuthService : IAuthService
{
    private readonly DataContext _jwtService;
    private readonly IConfiguration _configuration;
    public AuthService(DataContext jwtContext, IConfiguration configuration)
    {
        _jwtService = jwtContext;
        _configuration = configuration;
    }
    public User AddUser(User user)
    {
        var existUser=_jwtService.Users.SingleOrDefault(s => s.Email == user.Email && s.Password == user.Password);

        if(existUser!=null){
            throw new Exception("user is exist");
        }
    
        var addedUser = _jwtService.Add(user);
        _jwtService.SaveChanges();
        return addedUser.Entity;

    }

    public LogRes Login(LoginRequest loginRequest)
    {
        if (loginRequest.Email != null && loginRequest.Password != null)
        {
            var user = _jwtService.Users.SingleOrDefault(s => s.Email == loginRequest.Email && s.Password == loginRequest.Password);
            if (user != null)
            {
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", user.Name),
                        new Claim("Email", user.Email)
                    };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                LogRes _logRes=new LogRes(){
                    Token=jwtToken,
                    user=user
                };
                return _logRes;
            }
            else
            {
                throw new Exception("user is not valid");
            }
        }
        else
        {
            throw new Exception("credentials are not valid");
        }
    }
}