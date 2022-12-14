using AngularDemo.Models;

namespace AngularDemo.Services;

public interface IUserService
{
    Task<bool> Create(User user);
    Task<bool> IsValidUser(string Email, string Password);
    Task<User> Get(string Email);
}
