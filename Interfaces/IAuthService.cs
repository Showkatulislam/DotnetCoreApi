namespace Ecommerceapi.Interfaces;

using Ecommerceapi.Dto;
using Ecommerceapi.Models;
using Ecommerceapi.Request_Models;

public interface IAuthService
{
        User AddUser(User user);
        LogRes Login(LoginRequest loginRequest);
}